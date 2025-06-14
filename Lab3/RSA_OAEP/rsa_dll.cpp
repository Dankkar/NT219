#include <string>
#include <iostream>
#include <fstream>
#include <sstream>
#include <locale>
#include <codecvt>
#include <cryptopp/rsa.h>
#include <cryptopp/osrng.h>
#include <cryptopp/base64.h>
#include <cryptopp/hex.h>
#include <cryptopp/files.h>
#include <cryptopp/oaep.h>
#include <cryptopp/sha.h>
#include <cryptopp/aes.h>
#include <cryptopp/modes.h>
#include <cryptopp/gcm.h>
#include <windows.h>

using namespace CryptoPP;

// Key formats
enum KeyFormat {
    KEY_FORMAT_PEM = 0,     // PEM format (default)
    KEY_FORMAT_DER = 1,     // DER format
    KEY_FORMAT_BASE64 = 2   // Base64 only (no headers)
};

// UTF-8 helper functions
namespace UTF8Helper {
    // Convert UTF-8 to wide string
    std::wstring utf8_to_wstring(const std::string& str) {
        if (str.empty()) return std::wstring();
        int size_needed = MultiByteToWideChar(CP_UTF8, 0, &str[0], (int)str.size(), NULL, 0);
        std::wstring wstrTo(size_needed, 0);
        MultiByteToWideChar(CP_UTF8, 0, &str[0], (int)str.size(), &wstrTo[0], size_needed);
        return wstrTo;
    }

    // Convert wide string to UTF-8
    std::string wstring_to_utf8(const std::wstring& wstr) {
        if (wstr.empty()) return std::string();
        int size_needed = WideCharToMultiByte(CP_UTF8, 0, &wstr[0], (int)wstr.size(), NULL, 0, NULL, NULL);
        std::string strTo(size_needed, 0);
        WideCharToMultiByte(CP_UTF8, 0, &wstr[0], (int)wstr.size(), &strTo[0], size_needed, NULL, NULL);
        return strTo;
    }

    // UTF-8 safe file operations using Windows API
    bool writeFileUTF8(const std::string& filename, const std::string& content) {
        std::wstring wfilename = utf8_to_wstring(filename);
        
        HANDLE hFile = CreateFileW(
            wfilename.c_str(),
            GENERIC_WRITE,
            0,
            NULL,
            CREATE_ALWAYS,
            FILE_ATTRIBUTE_NORMAL,
            NULL
        );
        
        if (hFile == INVALID_HANDLE_VALUE) return false;
        
        DWORD bytesWritten;
        BOOL result = TRUE;
        
        // Write UTF-8 BOM for text files
        if (filename.find(".txt") != std::string::npos || filename.find(".pem") != std::string::npos) {
            const char bom[] = "\xEF\xBB\xBF";
            result = WriteFile(hFile, bom, 3, &bytesWritten, NULL);
        }
        
        if (result && !content.empty()) {
            result = WriteFile(hFile, content.c_str(), static_cast<DWORD>(content.size()), &bytesWritten, NULL);
        }
        
        CloseHandle(hFile);
        return result == TRUE;
    }

    std::string readFileUTF8(const std::string& filename) {
        std::wstring wfilename = utf8_to_wstring(filename);
        
        HANDLE hFile = CreateFileW(
            wfilename.c_str(),
            GENERIC_READ,
            FILE_SHARE_READ,
            NULL,
            OPEN_EXISTING,
            FILE_ATTRIBUTE_NORMAL,
            NULL
        );
        
        if (hFile == INVALID_HANDLE_VALUE) return "";
        
        DWORD fileSize = GetFileSize(hFile, NULL);
        if (fileSize == INVALID_FILE_SIZE) {
            CloseHandle(hFile);
            return "";
        }
        
        std::string content(fileSize, 0);
        DWORD bytesRead;
        BOOL result = ReadFile(hFile, &content[0], fileSize, &bytesRead, NULL);
        CloseHandle(hFile);
        
        if (!result) return "";
        
        content.resize(bytesRead);
        
        // Remove UTF-8 BOM if present
        if (content.size() >= 3 && content.substr(0, 3) == "\xEF\xBB\xBF") {
            content = content.substr(3);
        }
        
        return content;
    }
}

// Export functions for DLL
extern "C" {
    // Basic functions (backward compatibility)
     __declspec(dllexport) int generateRSAKeys(const char* publicKeyFile, const char* privateKeyFile, int keySize);
    __declspec(dllexport) int encryptFile(const char* publicKeyFile, const char* inputFile, const char* outputFile);
    __declspec(dllexport) int decryptFile(const char* privateKeyFile, const char* inputFile, const char* outputFile);
    __declspec(dllexport) const char* encryptString(const char* publicKeyFile, const char* plaintext);
    __declspec(dllexport) const char* decryptString(const char* privateKeyFile, const char* ciphertext);
    
    // Extended functions with format support
    __declspec(dllexport) int generateRSAKeysWithFormat(const char* publicKeyFile, const char* privateKeyFile, int keySize, int keyFormat);
    __declspec(dllexport) int encryptFileWithFormat(const char* publicKeyFile, const char* inputFile, const char* outputFile, int keyFormat);
    __declspec(dllexport) int decryptFileWithFormat(const char* privateKeyFile, const char* inputFile, const char* outputFile, int keyFormat);
    __declspec(dllexport) const char* encryptStringWithFormat(const char* publicKeyFile, const char* plaintext, int keyFormat);
    __declspec(dllexport) const char* decryptStringWithFormat(const char* privateKeyFile, const char* ciphertext, int keyFormat);
    
    // Utility functions
    __declspec(dllexport) const char* getLastError();
}

class RSA_DLL {
public:
    RSA_DLL() {}
    
    // Key generation
    bool generateKeys(int keySize = 3072) {
        try {
            privateKey.GenerateRandomWithKeySize(rng, keySize);
            publicKey.AssignFrom(privateKey);
            return true;
        } catch (const std::exception& e) {
            lastError = "Error generating keys: " + std::string(e.what());
            return false;
        }
    }

    bool savePublicKey(const std::string& filename, KeyFormat format = KEY_FORMAT_PEM) {
        try {
            ByteQueue queue;
            publicKey.Save(queue);
            
            if (format == KEY_FORMAT_DER) {
                // Save as DER format (binary)
                FileSink sink(filename.c_str());
                queue.CopyTo(sink);
                sink.MessageEnd();
            } else {
                // Convert to Base64
                std::string base64Data;
                Base64Encoder encoder(new StringSink(base64Data), true, 64);
                queue.CopyTo(encoder);
                encoder.MessageEnd();

                if (!base64Data.empty() && base64Data.back() == '\n') {
                    base64Data.pop_back();
                }

                std::string fileContent;
                if (format == KEY_FORMAT_PEM) {
                    // PEM format with headers
                    fileContent = "-----BEGIN PUBLIC KEY-----\n" + base64Data + "\n-----END PUBLIC KEY-----";
                } else if (format == KEY_FORMAT_BASE64) {
                    // Base64 only, no headers
                    fileContent = base64Data;
                }
                
                if (!UTF8Helper::writeFileUTF8(filename, fileContent)) {
                    throw std::runtime_error("Cannot write to file: " + filename);
                }
            }
            return true;
        } catch (const std::exception& e) {
            lastError = "Error saving public key: " + std::string(e.what());
            return false;
        }
    }

    bool savePrivateKey(const std::string& filename, KeyFormat format = KEY_FORMAT_PEM) {
        try {
            ByteQueue queue;
            privateKey.Save(queue);
            
            if (format == KEY_FORMAT_DER) {
                // Save as DER format (binary)
                FileSink sink(filename.c_str());
                queue.CopyTo(sink);
                sink.MessageEnd();
            } else {
                // Convert to Base64
                std::string base64Data;
                Base64Encoder encoder(new StringSink(base64Data), true, 64);
                queue.CopyTo(encoder);
                encoder.MessageEnd();

                if (!base64Data.empty() && base64Data.back() == '\n') {
                    base64Data.pop_back();
                }

                std::string fileContent;
                if (format == KEY_FORMAT_PEM) {
                    // PEM format with headers
                    fileContent = "-----BEGIN RSA PRIVATE KEY-----\n" + base64Data + "\n-----END RSA PRIVATE KEY-----";
                } else if (format == KEY_FORMAT_BASE64) {
                    // Base64 only, no headers
                    fileContent = base64Data;
                }
                
                if (!UTF8Helper::writeFileUTF8(filename, fileContent)) {
                    throw std::runtime_error("Cannot write to file: " + filename);
                }
            }
            return true;
        } catch (const std::exception& e) {
            lastError = "Error saving private key: " + std::string(e.what());
            return false;
        }
    }

    bool loadPublicKey(const std::string& filename, KeyFormat format = KEY_FORMAT_PEM) {
        try {
            if (format == KEY_FORMAT_DER) {
                // Load DER format directly
                FileSource fs(filename.c_str(), true);
                publicKey.Load(fs);
            } else if (format == KEY_FORMAT_BASE64) {
                // Load Base64 only (no headers)
                std::string base64Data = UTF8Helper::readFileUTF8(filename);
                if (base64Data.empty()) {
                    throw std::runtime_error("Cannot read public key file: " + filename);
                }
                
                std::string derData;
                StringSource ss(base64Data, true,
                    new Base64Decoder(
                        new StringSink(derData)
                    )
                );
                ArraySource as(reinterpret_cast<const byte*>(derData.data()), derData.size(), true);
                publicKey.Load(as);
            } else {
                // Load PEM format (auto-detect or explicit)
                std::string fileContent = UTF8Helper::readFileUTF8(filename);
                if (fileContent.empty()) {
                    throw std::runtime_error("Cannot read public key file: " + filename);
                }

                std::string line, base64Data;
                bool inKey = false;
                std::string firstLine;
                bool firstLineRead = false;
                std::istringstream iss(fileContent);

                while (std::getline(iss, line)) {
                    if (!firstLineRead) {
                        firstLine = line;
                        firstLineRead = true;
                    }
                    if (line == "-----BEGIN PUBLIC KEY-----") {
                        inKey = true;
                    }
                    else if (line == "-----END PUBLIC KEY-----") {
                        inKey = false;
                        break;
                    }
                    else if (inKey) {
                        base64Data += line;
                    }
                }

                if (!base64Data.empty() && firstLine == "-----BEGIN PUBLIC KEY-----") {
                    std::string derData;
                    StringSource ss(base64Data, true,
                        new Base64Decoder(
                            new StringSink(derData)
                        )
                    );
                    ArraySource as(reinterpret_cast<const byte*>(derData.data()), derData.size(), true);
                    publicKey.Load(as);
                } else {
                    // Try as DER format
                    FileSource fs(filename.c_str(), true);
                    publicKey.Load(fs);
                }
            }

            return true;
        } catch (const std::exception& e) {
            lastError = "Error loading public key: " + std::string(e.what());
            return false;
        }
    }

    bool loadPrivateKey(const std::string& filename, KeyFormat format = KEY_FORMAT_PEM) {
        try {
            if (format == KEY_FORMAT_DER) {
                // Load DER format directly
                FileSource fs(filename.c_str(), true);
                privateKey.Load(fs);
            } else if (format == KEY_FORMAT_BASE64) {
                // Load Base64 only (no headers)
                std::string base64Data = UTF8Helper::readFileUTF8(filename);
                if (base64Data.empty()) {
                    throw std::runtime_error("Cannot read private key file: " + filename);
                }
                
                std::string derData;
                StringSource ss(base64Data, true,
                    new Base64Decoder(
                        new StringSink(derData)
                    )
                );
                ArraySource as(reinterpret_cast<const byte*>(derData.data()), derData.size(), true);
                privateKey.Load(as);
            } else {
                // Load PEM format (auto-detect or explicit)
                std::string fileContent = UTF8Helper::readFileUTF8(filename);
                if (fileContent.empty()) {
                    throw std::runtime_error("Cannot read private key file: " + filename);
                }

                std::string line, base64Data;
                bool inKey = false;
                std::string beginMarker1 = "-----BEGIN RSA PRIVATE KEY-----";
                std::string beginMarker2 = "-----BEGIN PRIVATE KEY-----";
                std::string endMarker1 = "-----END RSA PRIVATE KEY-----";
                std::string endMarker2 = "-----END PRIVATE KEY-----";
                std::string firstLine;
                bool firstLineRead = false;
                std::istringstream iss(fileContent);

                while (std::getline(iss, line)) {
                    if (!firstLineRead) {
                        firstLine = line;
                        firstLineRead = true;
                    }
                    if (line == beginMarker1 || line == beginMarker2) {
                        inKey = true;
                    }
                    else if (line == endMarker1 || line == endMarker2) {
                        inKey = false;
                        break;
                    }
                    else if (inKey) {
                        base64Data += line;
                    }
                }

                if (!base64Data.empty() && (firstLine == beginMarker1 || firstLine == beginMarker2)) {
                    std::string derData;
                    StringSource ss(base64Data, true,
                        new Base64Decoder(
                            new StringSink(derData)
                        )
                    );
                    ArraySource as(reinterpret_cast<const byte*>(derData.data()), derData.size(), true);
                    privateKey.Load(as);
                } else {
                    // Try as DER format
                    FileSource fs(filename.c_str(), true);
                    privateKey.Load(fs);
                }
            }

            return true;
        } catch (const std::exception& e) {
            lastError = "Error loading private key: " + std::string(e.what());
            return false;
        }
    }

    std::string encrypt(const std::string& plaintext, bool outputBase64 = true) {
        try {
            RSAES_OAEP_SHA_Encryptor encryptor(publicKey);
            size_t maxPlaintextLength = encryptor.FixedMaxPlaintextLength();

            if (plaintext.length() > maxPlaintextLength) {
                // Use AES-256-GCM for large data
                SecByteBlock aesKey(32);  // 256-bit key
                SecByteBlock iv(12);      // 96-bit IV for GCM
                rng.GenerateBlock(aesKey, aesKey.size());
                rng.GenerateBlock(iv, iv.size());

                std::string aesCiphertext;
                GCM<AES>::Encryption aesEncryption;
                aesEncryption.SetKeyWithIV(aesKey, aesKey.size(), iv);
                StringSource(plaintext, true,
                    new AuthenticatedEncryptionFilter(aesEncryption,
                        new StringSink(aesCiphertext)
                    )
                );

                std::string encryptedKey;
                StringSource(aesKey, aesKey.size(), true,
                    new PK_EncryptorFilter(rng, encryptor,
                        new StringSink(encryptedKey)
                    )
                );

                // Format: [4-byte key length][encrypted AES key][12-byte IV][GCM ciphertext+tag]
                std::string result;
                result.reserve(4 + encryptedKey.size() + iv.size() + aesCiphertext.size());

                word32 keyLength = static_cast<word32>(encryptedKey.size());
                result.push_back((keyLength >> 24) & 0xFF);
                result.push_back((keyLength >> 16) & 0xFF);
                result.push_back((keyLength >> 8) & 0xFF);
                result.push_back(keyLength & 0xFF);

                result += encryptedKey;
                result.append(reinterpret_cast<const char*>(iv.data()), iv.size());
                result += aesCiphertext;

                return outputBase64 ? encodeBase64(result) : encodeHex(result);
            } else {
                // Direct RSA encryption for small data
                std::string ciphertext;
                StringSource(plaintext, true,
                    new PK_EncryptorFilter(rng, encryptor,
                        new StringSink(ciphertext)
                    )
                );

                return outputBase64 ? encodeBase64(ciphertext) : encodeHex(ciphertext);
            }
        } catch (const std::exception& e) {
            lastError = "Encryption error: " + std::string(e.what());
            return "";
        }
    }

    std::string decrypt(const std::string& ciphertext, bool inputBase64 = true) {
        try {
            std::string decodedCiphertext = inputBase64 ? decodeBase64(ciphertext) : decodeHex(ciphertext);
            
            if (decodedCiphertext.length() > 4) {
                word32 keyLength = (static_cast<word32>(decodedCiphertext[0] & 0xFF) << 24) |
                                 (static_cast<word32>(decodedCiphertext[1] & 0xFF) << 16) |
                                 (static_cast<word32>(decodedCiphertext[2] & 0xFF) << 8) |
                                 (static_cast<word32>(decodedCiphertext[3] & 0xFF));

                // Check if this is GCM format (12-byte IV)
                if (decodedCiphertext.length() > 4 + keyLength + 12) {
                    size_t offset = 4;
                    
                    std::string encryptedKey = decodedCiphertext.substr(offset, keyLength);
                    offset += keyLength;

                    SecByteBlock iv(12); // GCM uses 12-byte IV
                    std::memcpy(iv.data(), decodedCiphertext.data() + offset, 12);
                    offset += 12;

                    std::string aesCiphertext = decodedCiphertext.substr(offset);

                    SecByteBlock aesKey(32); // AES-256 key
                    RSAES_OAEP_SHA_Decryptor rsaDecryptor(privateKey);
                    StringSource(encryptedKey, true,
                        new PK_DecryptorFilter(rng, rsaDecryptor,
                            new ArraySink(aesKey, aesKey.size())
                        )
                    );

                    std::string decrypted;
                    GCM<AES>::Decryption aesDecryption;
                    aesDecryption.SetKeyWithIV(aesKey, aesKey.size(), iv);
                    StringSource(aesCiphertext, true,
                        new AuthenticatedDecryptionFilter(aesDecryption,
                            new StringSink(decrypted)
                        )
                    );

                    return decrypted;
                }
            }

            // Try direct RSA decryption
            RSAES_OAEP_SHA_Decryptor decryptor(privateKey);
            std::string decrypted;
            StringSource(decodedCiphertext, true,
                new PK_DecryptorFilter(rng, decryptor,
                    new StringSink(decrypted)
                )
            );

            return decrypted;
        } catch (const std::exception& e) {
            lastError = "Decryption error: " + std::string(e.what());
            return "";
        }
    }

    std::string getLastError() const {
        return lastError;
    }

private:
    AutoSeededRandomPool rng;
    RSA::PrivateKey privateKey;
    RSA::PublicKey publicKey;
    std::string lastError;

    std::string encodeBase64(const std::string& data) {
        std::string encoded;
        StringSource(data, true,
            new Base64Encoder(
                new StringSink(encoded)
            )
        );
        return encoded;
    }

    std::string decodeBase64(const std::string& encoded) {
        std::string decoded;
        StringSource(encoded, true,
            new Base64Decoder(
                new StringSink(decoded)
            )
        );
        return decoded;
    }

    std::string encodeHex(const std::string& data) {
        std::string encoded;
        StringSource(data, true,
            new HexEncoder(
                new StringSink(encoded)
            )
        );
        return encoded;
    }

    std::string decodeHex(const std::string& encoded) {
        std::string decoded;
        StringSource(encoded, true,
            new HexDecoder(
                new StringSink(decoded)
            )
        );
        return decoded;
    }
};

// Global instance for DLL functions
static RSA_DLL g_rsa;
static std::string g_lastResult;

// DLL Export functions
extern "C" {
    __declspec(dllexport) int generateRSAKeys(const char* publicKeyFile, const char* privateKeyFile, int keySize) {
        if (!g_rsa.generateKeys(keySize)) {
            return 0;
        }
        
        if (!g_rsa.savePublicKey(publicKeyFile)) {
            return 0;
        }
        
        if (!g_rsa.savePrivateKey(privateKeyFile)) {
            return 0;
        }
        
        return 1; // Success
    }

    __declspec(dllexport) int generateRSAKeysWithFormat(const char* publicKeyFile, const char* privateKeyFile, int keySize, int keyFormat) {
        if (!g_rsa.generateKeys(keySize)) {
            return 0;
        }
        
        KeyFormat format = static_cast<KeyFormat>(keyFormat);
        
        if (!g_rsa.savePublicKey(publicKeyFile, format)) {
            return 0;
        }
        
        if (!g_rsa.savePrivateKey(privateKeyFile, format)) {
            return 0;
        }
        
        return 1; // Success
    }

    __declspec(dllexport) int encryptFile(const char* publicKeyFile, const char* inputFile, const char* outputFile) {
        if (!g_rsa.loadPublicKey(publicKeyFile)) {
            return 0;
        }

        std::string input_data = UTF8Helper::readFileUTF8(inputFile);
        if (input_data.empty()) {
            return 0;
        }

        std::string output_data = g_rsa.encrypt(input_data);
        if (output_data.empty()) {
            return 0;
        }

        if (!UTF8Helper::writeFileUTF8(outputFile, output_data)) {
            return 0;
        }

        return 1; // Success
    }

    __declspec(dllexport) int encryptFileWithFormat(const char* publicKeyFile, const char* inputFile, const char* outputFile, int keyFormat) {
        KeyFormat format = static_cast<KeyFormat>(keyFormat);
        
        if (!g_rsa.loadPublicKey(publicKeyFile, format)) {
            return 0;
        }

        std::string input_data = UTF8Helper::readFileUTF8(inputFile);
        if (input_data.empty()) {
            return 0;
        }

        std::string output_data = g_rsa.encrypt(input_data);
        if (output_data.empty()) {
            return 0;
        }

        if (!UTF8Helper::writeFileUTF8(outputFile, output_data)) {
            return 0;
        }

        return 1; // Success
    }

    __declspec(dllexport) int decryptFile(const char* privateKeyFile, const char* inputFile, const char* outputFile) {
        if (!g_rsa.loadPrivateKey(privateKeyFile)) {
            return 0;
        }

        std::string input_data = UTF8Helper::readFileUTF8(inputFile);
        if (input_data.empty()) {
            return 0;
        }

        std::string output_data = g_rsa.decrypt(input_data);
        if (output_data.empty()) {
            return 0;
        }

        if (!UTF8Helper::writeFileUTF8(outputFile, output_data)) {
            return 0;
        }

        return 1; // Success
    }

    __declspec(dllexport) int decryptFileWithFormat(const char* privateKeyFile, const char* inputFile, const char* outputFile, int keyFormat) {
        KeyFormat format = static_cast<KeyFormat>(keyFormat);
        
        if (!g_rsa.loadPrivateKey(privateKeyFile, format)) {
            return 0;
        }

        std::string input_data = UTF8Helper::readFileUTF8(inputFile);
        if (input_data.empty()) {
            return 0;
        }

        std::string output_data = g_rsa.decrypt(input_data);
        if (output_data.empty()) {
            return 0;
        }

        if (!UTF8Helper::writeFileUTF8(outputFile, output_data)) {
            return 0;
        }

        return 1; // Success
    }

    __declspec(dllexport) const char* encryptString(const char* publicKeyFile, const char* plaintext) {
        if (!g_rsa.loadPublicKey(publicKeyFile)) {
            return nullptr;
        }

        g_lastResult = g_rsa.encrypt(plaintext);
        return g_lastResult.empty() ? nullptr : g_lastResult.c_str();
    }

    __declspec(dllexport) const char* encryptStringWithFormat(const char* publicKeyFile, const char* plaintext, int keyFormat) {
        KeyFormat format = static_cast<KeyFormat>(keyFormat);
        
        if (!g_rsa.loadPublicKey(publicKeyFile, format)) {
            return nullptr;
        }

        g_lastResult = g_rsa.encrypt(plaintext);
        return g_lastResult.empty() ? nullptr : g_lastResult.c_str();
    }

    __declspec(dllexport) const char* decryptString(const char* privateKeyFile, const char* ciphertext) {
        if (!g_rsa.loadPrivateKey(privateKeyFile)) {
            return nullptr;
        }

        g_lastResult = g_rsa.decrypt(ciphertext);
        return g_lastResult.empty() ? nullptr : g_lastResult.c_str();
    }

    __declspec(dllexport) const char* decryptStringWithFormat(const char* privateKeyFile, const char* ciphertext, int keyFormat) {
        KeyFormat format = static_cast<KeyFormat>(keyFormat);
        
        if (!g_rsa.loadPrivateKey(privateKeyFile, format)) {
            return nullptr;
        }

        g_lastResult = g_rsa.decrypt(ciphertext);
        return g_lastResult.empty() ? nullptr : g_lastResult.c_str();
    }

    __declspec(dllexport) const char* getLastError() {
        g_lastResult = g_rsa.getLastError();
        return g_lastResult.c_str();
    }
}

// DLL Entry Point
BOOL APIENTRY DllMain(HMODULE hModule, DWORD ul_reason_for_call, LPVOID lpReserved) {
    switch (ul_reason_for_call) {
        case DLL_PROCESS_ATTACH:
        case DLL_THREAD_ATTACH:
        case DLL_THREAD_DETACH:
        case DLL_PROCESS_DETACH:
            break;
    }
    return TRUE;
} 