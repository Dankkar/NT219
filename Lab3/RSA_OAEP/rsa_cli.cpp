#include <string>
#include <iostream>
#include <fstream>
#include <locale>
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
#include <chrono>
#include <vector>

using namespace CryptoPP;

// Padding schemes
enum RSAPaddingScheme {
    RSA_PADDING_UNKNOWN = 0,
    RSA_PADDING_PKCS1 = 1,
    RSA_PADDING_OAEP = 2
};

// Output/Input formats
enum RSADataFormat {
    RSA_FORMAT_UNKNOWN = 0,
    RSA_FORMAT_BINARY = 1,
    RSA_FORMAT_BASE64 = 2,
    RSA_FORMAT_HEX = 3
};

class RSA_OAEP {
public:
    RSA_OAEP() {}
    
    // Key generation
    bool generateKeys(int keySize = 3072) {
        try {
            privateKey.GenerateRandomWithKeySize(rng, keySize);
            publicKey.AssignFrom(privateKey);
            return true;
        } catch (const std::exception& e) {
            std::cerr << "Error generating keys: " << e.what() << std::endl;
            return false;
        }
    }

    bool savePublicKey(const std::string& filename, bool derFormat = false) {
        try {
            if (derFormat) {
                ByteQueue queue;
                publicKey.Save(queue);
                FileSink sink(filename.c_str());
                queue.CopyTo(sink);
                sink.MessageEnd();
            } else {
                ByteQueue queue;
                publicKey.Save(queue);
                
                std::string base64Data;
                Base64Encoder encoder(new StringSink(base64Data), true, 64);
                queue.CopyTo(encoder);
                encoder.MessageEnd();

                if (!base64Data.empty() && base64Data.back() == '\n') {
                    base64Data.pop_back();
                }

                std::ofstream file(filename);
                if (!file.is_open()) {
                    throw std::runtime_error("Cannot open file for writing: " + filename);
                }
                file << "-----BEGIN PUBLIC KEY-----\n";
                file << base64Data;
                file << "\n-----END PUBLIC KEY-----";
                file.close();
            }
            return true;
        } catch (const std::exception& e) {
            std::cerr << "Error saving public key: " << e.what() << std::endl;
            return false;
        }
    }

    bool savePrivateKey(const std::string& filename, bool derFormat = false) {
        try {
            if (derFormat) {
                ByteQueue queue;
                privateKey.Save(queue);
                FileSink sink(filename.c_str());
                queue.CopyTo(sink);
                sink.MessageEnd();
            } else {
                ByteQueue queue;
                privateKey.Save(queue);
                
                std::string base64Data;
                Base64Encoder encoder(new StringSink(base64Data), true, 64);
                queue.CopyTo(encoder);
                encoder.MessageEnd();

                if (!base64Data.empty() && base64Data.back() == '\n') {
                    base64Data.pop_back();
                }

                std::ofstream file(filename);
                if (!file.is_open()) {
                    throw std::runtime_error("Cannot open file for writing: " + filename);
                }
                file << "-----BEGIN RSA PRIVATE KEY-----\n";
                file << base64Data;
                file << "\n-----END RSA PRIVATE KEY-----";
                file.close();
            }
            return true;
        } catch (const std::exception& e) {
            std::cerr << "Error saving private key: " << e.what() << std::endl;
            return false;
        }
    }

    bool loadPublicKey(const std::string& filename, bool derFormat = false) {
        try {
            std::cout << "Loading public key from: " << filename << std::endl;
            std::ifstream file(filename);
            if (!file.is_open()) {
                throw std::runtime_error("Cannot open public key file: " + filename);
            }

            std::string line, base64Data;
            bool inKey = false;
            std::string firstLine;
            bool firstLineRead = false;

            while (std::getline(file, line)) {
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
            file.close();

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
                FileSource fs(filename.c_str(), true);
                publicKey.Load(fs);
            }

            std::cout << "Public key loaded successfully" << std::endl;
            return true;
        } catch (const std::exception& e) {
            std::cerr << "Error loading public key: " << e.what() << std::endl;
            return false;
        }
    }

    bool loadPrivateKey(const std::string& filename, bool derFormat = false) {
        try {
            std::cout << "Loading private key from: " << filename << std::endl;
            std::ifstream file(filename);
            if (!file.is_open()) {
                throw std::runtime_error("Cannot open private key file: " + filename);
            }

            std::string line, base64Data;
            bool inKey = false;
            std::string beginMarker1 = "-----BEGIN RSA PRIVATE KEY-----";
            std::string beginMarker2 = "-----BEGIN PRIVATE KEY-----";
            std::string endMarker1 = "-----END RSA PRIVATE KEY-----";
            std::string endMarker2 = "-----END PRIVATE KEY-----";
            std::string firstLine;
            bool firstLineRead = false;

            while (std::getline(file, line)) {
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
            file.close();

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
                FileSource fs(filename.c_str(), true);
                privateKey.Load(fs);
            }

            std::cout << "Private key loaded successfully" << std::endl;
            return true;
        } catch (const std::exception& e) {
            std::cerr << "Error loading private key: " << e.what() << std::endl;
            return false;
        }
    }

    std::string encrypt(const std::string& plaintext, RSAPaddingScheme paddingScheme = RSA_PADDING_OAEP, bool outputBase64 = true, bool showMessage = true) {
        try {
            size_t maxPlaintextLength = 0;
            if (paddingScheme == RSA_PADDING_PKCS1) {
                RSAES_PKCS1v15_Encryptor encryptor(publicKey);
                maxPlaintextLength = encryptor.FixedMaxPlaintextLength();
            } else {
                RSAES_OAEP_SHA_Encryptor encryptor(publicKey);
                maxPlaintextLength = encryptor.FixedMaxPlaintextLength();
            }

            if (plaintext.length() > maxPlaintextLength) {
                if (showMessage) {
                    std::cout << "Data size exceeds RSA limit, using hybrid encryption with AES-256-GCM..." << std::endl;
                }
                
                // Use AES-256 (32 bytes key)
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
                if (paddingScheme == RSA_PADDING_PKCS1) {
                    RSAES_PKCS1v15_Encryptor rsaEncryptor(publicKey);
                    StringSource(aesKey, aesKey.size(), true,
                        new PK_EncryptorFilter(rng, rsaEncryptor,
                            new StringSink(encryptedKey)
                        )
                    );
                } else {
                    RSAES_OAEP_SHA_Encryptor rsaEncryptor(publicKey);
                    StringSource(aesKey, aesKey.size(), true,
                        new PK_EncryptorFilter(rng, rsaEncryptor,
                            new StringSink(encryptedKey)
                        )
                    );
                }

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
                std::unique_ptr<PK_Encryptor> encryptor;
                if (paddingScheme == RSA_PADDING_PKCS1) {
                    encryptor.reset(new RSAES_PKCS1v15_Encryptor(publicKey));
                } else {
                    encryptor.reset(new RSAES_OAEP_SHA_Encryptor(publicKey));
                }
                
                std::string ciphertext;
                StringSource(plaintext, true,
                    new PK_EncryptorFilter(rng, *encryptor,
                        new StringSink(ciphertext)
                    )
                );

                return outputBase64 ? encodeBase64(ciphertext) : encodeHex(ciphertext);
            }
        } catch (const std::exception& e) {
            std::cerr << "Encryption error: " << e.what() << std::endl;
            return "";
        }
    }

    // Legacy CBC version (kept for compatibility)
    std::string encryptCBC(const std::string& plaintext, RSAPaddingScheme paddingScheme = RSA_PADDING_OAEP, bool outputBase64 = true, bool showMessage = true) {
        try {
            size_t maxPlaintextLength = 0;
            if (paddingScheme == RSA_PADDING_PKCS1) {
                RSAES_PKCS1v15_Encryptor encryptor(publicKey);
                maxPlaintextLength = encryptor.FixedMaxPlaintextLength();
            } else {
                RSAES_OAEP_SHA_Encryptor encryptor(publicKey);
                maxPlaintextLength = encryptor.FixedMaxPlaintextLength();
            }

            if (plaintext.length() > maxPlaintextLength) {
                if (showMessage) {
                    std::cout << "Data size exceeds RSA limit, using hybrid encryption..." << std::endl;
                }
                
                SecByteBlock aesKey(AES::DEFAULT_KEYLENGTH);
                SecByteBlock iv(AES::BLOCKSIZE);
                rng.GenerateBlock(aesKey, aesKey.size());
                rng.GenerateBlock(iv, iv.size());

                std::string aesCiphertext;
                CBC_Mode<AES>::Encryption aesEncryption;
                aesEncryption.SetKeyWithIV(aesKey, aesKey.size(), iv);
                StringSource(plaintext, true,
                    new StreamTransformationFilter(aesEncryption,
                        new StringSink(aesCiphertext)
                    )
                );

                std::string encryptedKey;
                if (paddingScheme == RSA_PADDING_PKCS1) {
                    RSAES_PKCS1v15_Encryptor rsaEncryptor(publicKey);
                    StringSource(aesKey, aesKey.size(), true,
                        new PK_EncryptorFilter(rng, rsaEncryptor,
                            new StringSink(encryptedKey)
                        )
                    );
                } else {
                    RSAES_OAEP_SHA_Encryptor rsaEncryptor(publicKey);
                    StringSource(aesKey, aesKey.size(), true,
                        new PK_EncryptorFilter(rng, rsaEncryptor,
                            new StringSink(encryptedKey)
                        )
                    );
                }

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
                std::unique_ptr<PK_Encryptor> encryptor;
                if (paddingScheme == RSA_PADDING_PKCS1) {
                    encryptor.reset(new RSAES_PKCS1v15_Encryptor(publicKey));
                } else {
                    encryptor.reset(new RSAES_OAEP_SHA_Encryptor(publicKey));
                }
                
                std::string ciphertext;
                StringSource(plaintext, true,
                    new PK_EncryptorFilter(rng, *encryptor,
                        new StringSink(ciphertext)
                    )
                );

                return outputBase64 ? encodeBase64(ciphertext) : encodeHex(ciphertext);
            }
        } catch (const std::exception& e) {
            std::cerr << "Encryption error: " << e.what() << std::endl;
            return "";
        }
    }

    std::string decrypt(const std::string& ciphertext, RSAPaddingScheme paddingScheme = RSA_PADDING_OAEP, bool inputBase64 = true) {
        try {
            std::string decodedCiphertext = inputBase64 ? decodeBase64(ciphertext) : decodeHex(ciphertext);
            
            if (decodedCiphertext.length() > 4) {
                word32 keyLength = (static_cast<word32>(decodedCiphertext[0] & 0xFF) << 24) |
                                 (static_cast<word32>(decodedCiphertext[1] & 0xFF) << 16) |
                                 (static_cast<word32>(decodedCiphertext[2] & 0xFF) << 8) |
                                 (static_cast<word32>(decodedCiphertext[3] & 0xFF));

                // Check if this is GCM format (12-byte IV instead of 16-byte)
                if (decodedCiphertext.length() > 4 + keyLength + 12) {
                    size_t offset = 4;
                    
                    std::string encryptedKey = decodedCiphertext.substr(offset, keyLength);
                    offset += keyLength;

                    SecByteBlock iv(12); // GCM uses 12-byte IV
                    std::memcpy(iv.data(), decodedCiphertext.data() + offset, 12);
                    offset += 12;

                    std::string aesCiphertext = decodedCiphertext.substr(offset);

                    SecByteBlock aesKey(32); // AES-256 key
                    if (paddingScheme == RSA_PADDING_PKCS1) {
                        RSAES_PKCS1v15_Decryptor rsaDecryptor(privateKey);
                        StringSource(encryptedKey, true,
                            new PK_DecryptorFilter(rng, rsaDecryptor,
                                new ArraySink(aesKey, aesKey.size())
                            )
                        );
                    } else {
                        RSAES_OAEP_SHA_Decryptor rsaDecryptor(privateKey);
                        StringSource(encryptedKey, true,
                            new PK_DecryptorFilter(rng, rsaDecryptor,
                                new ArraySink(aesKey, aesKey.size())
                            )
                        );
                    }

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
            std::unique_ptr<PK_Decryptor> decryptor;
            if (paddingScheme == RSA_PADDING_PKCS1) {
                decryptor.reset(new RSAES_PKCS1v15_Decryptor(privateKey));
            } else {
                decryptor.reset(new RSAES_OAEP_SHA_Decryptor(privateKey));
            }
            
            std::string decrypted;
            StringSource(decodedCiphertext, true,
                new PK_DecryptorFilter(rng, *decryptor,
                    new StringSink(decrypted)
                )
            );

            return decrypted;
        } catch (const std::exception& e) {
            // std::cerr << "Decryption error: " << e.what() << std::endl;
            return "";
        }
    }

    // Legacy CBC version (kept for compatibility)
    std::string decryptCBC(const std::string& ciphertext, RSAPaddingScheme paddingScheme = RSA_PADDING_OAEP, bool inputBase64 = true) {
        try {
            std::string decodedCiphertext = inputBase64 ? decodeBase64(ciphertext) : decodeHex(ciphertext);
            
            if (decodedCiphertext.length() > 4) {
                word32 keyLength = (static_cast<word32>(decodedCiphertext[0]) << 24) |
                                 (static_cast<word32>(decodedCiphertext[1]) << 16) |
                                 (static_cast<word32>(decodedCiphertext[2]) << 8) |
                                 (static_cast<word32>(decodedCiphertext[3]));

                if (decodedCiphertext.length() > 4 + keyLength + AES::BLOCKSIZE) {
                    size_t offset = 4;
                    
                    std::string encryptedKey = decodedCiphertext.substr(offset, keyLength);
                    offset += keyLength;

                    SecByteBlock iv(AES::BLOCKSIZE);
                    std::memcpy(iv.data(), decodedCiphertext.data() + offset, AES::BLOCKSIZE);
                    offset += AES::BLOCKSIZE;

                    std::string aesCiphertext = decodedCiphertext.substr(offset);

                    SecByteBlock aesKey(AES::DEFAULT_KEYLENGTH);
                    if (paddingScheme == RSA_PADDING_PKCS1) {
                        RSAES_PKCS1v15_Decryptor rsaDecryptor(privateKey);
                        StringSource(encryptedKey, true,
                            new PK_DecryptorFilter(rng, rsaDecryptor,
                                new ArraySink(aesKey, aesKey.size())
                            )
                        );
                    } else {
                        RSAES_OAEP_SHA_Decryptor rsaDecryptor(privateKey);
                        StringSource(encryptedKey, true,
                            new PK_DecryptorFilter(rng, rsaDecryptor,
                                new ArraySink(aesKey, aesKey.size())
                            )
                        );
                    }

                    std::string decrypted;
                    CBC_Mode<AES>::Decryption aesDecryption;
                    aesDecryption.SetKeyWithIV(aesKey, aesKey.size(), iv);
                    StringSource(aesCiphertext, true,
                        new StreamTransformationFilter(aesDecryption,
                            new StringSink(decrypted)
                        )
                    );

                    return decrypted;
                }
            }

            std::unique_ptr<PK_Decryptor> decryptor;
            if (paddingScheme == RSA_PADDING_PKCS1) {
                decryptor.reset(new RSAES_PKCS1v15_Decryptor(privateKey));
            } else {
                decryptor.reset(new RSAES_OAEP_SHA_Decryptor(privateKey));
            }
            
            std::string decrypted;
            StringSource(decodedCiphertext, true,
                new PK_DecryptorFilter(rng, *decryptor,
                    new StringSink(decrypted)
                )
            );

            return decrypted;
        } catch (const std::exception& e) {
            // std::cerr << "CBC Decryption error: " << e.what() << std::endl;
            return "";
        }
    }

    void benchmark(const std::string& inputFile, const std::string& outputFile, bool isEncrypt, RSAPaddingScheme paddingScheme = RSA_PADDING_OAEP) {
        std::ifstream in_file(inputFile, std::ios::binary);
        if (!in_file) {
            throw std::runtime_error("Cannot open input file");
        }
        std::string input_data(
            (std::istreambuf_iterator<char>(in_file)),
            std::istreambuf_iterator<char>()
        );
        in_file.close();

        std::string output_data;
        auto start = std::chrono::high_resolution_clock::now();
        
        for (int i = 0; i < 10000; ++i) {
            if (isEncrypt) {
                output_data = encrypt(input_data, paddingScheme, true, i == 0);
            } else {
                output_data = decrypt(input_data, paddingScheme, true);
                if (output_data.empty()) {
                    std::cout << "Decryption failed at iteration " << i << std::endl;
                    break;
                }
            }
        }
        
        auto end = std::chrono::high_resolution_clock::now();
        auto duration = std::chrono::duration_cast<std::chrono::milliseconds>(end - start).count();
        double averageTime = static_cast<double>(duration) / 10000.0;
        
        std::ofstream out_file(outputFile, std::ios::binary);
        if (!out_file) {
            throw std::runtime_error("Cannot open output file");
        }
        out_file << output_data;
        out_file.close();

        std::cout << (isEncrypt ? "Encryption" : "Decryption") << " (RSA-OAEP + AES-256-GCM) | " 
                  << input_data.size() * 8 << " bits | "
                  << "Average time over 10000 rounds: " << averageTime << " ms" << std::endl;
    }

private:
    AutoSeededRandomPool rng;
    RSA::PrivateKey privateKey;
    RSA::PublicKey publicKey;

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

void displayRSAParameters(const RSA::PrivateKey& privateKey, const RSA::PublicKey& publicKey) {
    std::cout << "\nRSA Parameters:\n";
    std::cout << "Modulus (n): " << privateKey.GetModulus() << "\n";
    std::cout << "Prime p: " << privateKey.GetPrime1() << "\n";
    std::cout << "Prime q: " << privateKey.GetPrime2() << "\n";
    std::cout << "Private exponent (d): " << privateKey.GetPrivateExponent() << "\n";
    std::cout << "Public exponent (e): " << publicKey.GetPublicExponent() << "\n";
    std::cout << "Phi(n): " << (privateKey.GetPrime1() - 1) * (privateKey.GetPrime2() - 1) << "\n";
}

void handleKeyGeneration(RSA_OAEP& rsa) {
    std::string keyPrefix;
    std::cout << "Enter key file prefix: ";
    std::cin >> keyPrefix;

    std::cout << "Generating 3072-bit RSA keys...\n";
    if (!rsa.generateKeys(3072)) {
        std::cerr << "Error generating keys!\n";
        return;
    }

    std::string pub_key_file = keyPrefix + "_public.pem";
    std::string priv_key_file = keyPrefix + "_private.pem";

    if (rsa.savePublicKey(pub_key_file) && rsa.savePrivateKey(priv_key_file)) {
        std::cout << "Keys saved successfully:\n"
                 << "Public key: " << pub_key_file << "\n"
                 << "Private key: " << priv_key_file << "\n";
    } else {
        std::cerr << "Error saving keys!\n";
    }
}

void handleEncryption(RSA_OAEP& rsa) {
    std::string keyFile, inputFile, outputFile;
    std::cout << "Enter public key file: ";
    std::cin >> keyFile;
    std::cout << "Enter input file: ";
    std::cin >> inputFile;
    std::cout << "Enter output file: ";
    std::cin >> outputFile;

    if (!rsa.loadPublicKey(keyFile)) {
        std::cerr << "Error loading public key!\n";
        return;
    }

    std::ifstream in_file(inputFile, std::ios::binary);
    if (!in_file) {
        std::cerr << "Error: Cannot open input file\n";
        return;
    }
    std::string input_data(
        (std::istreambuf_iterator<char>(in_file)),
        std::istreambuf_iterator<char>()
    );
    in_file.close();

    std::string output_data = rsa.encrypt(input_data);
    std::ofstream out_file(outputFile, std::ios::binary);
    if (!out_file) {
        std::cerr << "Error: Cannot open output file\n";
        return;
    }
    out_file << output_data;
    out_file.close();

    std::cout << "Encryption successful. Ciphertext saved to: " << outputFile << "\n";
}

void handleDecryption(RSA_OAEP& rsa) {
    std::string keyFile, inputFile, outputFile;
    std::cout << "Enter private key file: ";
    std::cin >> keyFile;
    std::cout << "Enter input file: ";
    std::cin >> inputFile;
    std::cout << "Enter output file: ";
    std::cin >> outputFile;

    if (!rsa.loadPrivateKey(keyFile)) {
        std::cerr << "Error loading private key!\n";
        return;
    }

    std::ifstream in_file(inputFile, std::ios::binary);
    if (!in_file) {
        std::cerr << "Error: Cannot open input file\n";
        return;
    }
    std::string input_data(
        (std::istreambuf_iterator<char>(in_file)),
        std::istreambuf_iterator<char>()
    );
    in_file.close();

    std::string output_data = rsa.decrypt(input_data);
    std::ofstream out_file(outputFile, std::ios::binary);
    if (!out_file) {
        std::cerr << "Error: Cannot open output file\n";
        return;
    }
    out_file << output_data;
    out_file.close();

    std::cout << "Decryption successful. Plaintext saved to: " << outputFile << "\n";
}

void handleBenchmark(RSA_OAEP& rsa) {
    std::string keyPrefix;
    std::cout << "Enter key file prefix: ";
    std::cin >> keyPrefix;

    std::string pub_key_file = keyPrefix + "_public.pem";
    std::string priv_key_file = keyPrefix + "_private.pem";

    if (!rsa.loadPublicKey(pub_key_file) || !rsa.loadPrivateKey(priv_key_file)) {
        std::cerr << "Error loading keys!\n";
        return;
    }

    std::vector<int> bitSizes = {128, 192, 256, 512}; // bit sizes
    
    std::cout << "\nBenchmark Results (RSA-OAEP + AES-256-GCM):\n";
    std::cout << "Size(bits)\tEncryption(ms)\tDecryption(ms)\n";
    std::cout << "----------------------------------------\n";
    
    for (int bitSize : bitSizes) {
        int byteSize = bitSize / 8; // Convert bits to bytes
        std::string inputFile = "test_" + std::to_string(bitSize) + "bit.txt";
        std::string cipherFile = "cipher_rsa_" + std::to_string(bitSize) + "bit.bin";
        std::string plainFile = "plain_rsa_" + std::to_string(bitSize) + "bit.txt";

        // Generate test file if it doesn't exist
        if (!std::ifstream(inputFile)) {
            std::ofstream ofs(inputFile, std::ios::binary);
            for (int i = 0; i < byteSize; ++i) {
                ofs.put('A' + (rand() % 26));
            }
            ofs.close();
        }

        // Run encryption benchmark
        auto start = std::chrono::high_resolution_clock::now();
        rsa.benchmark(inputFile, cipherFile, true);
        auto end = std::chrono::high_resolution_clock::now();
        auto enc_time = std::chrono::duration_cast<std::chrono::milliseconds>(end - start).count() / 10000.0;

        // Run decryption benchmark
        start = std::chrono::high_resolution_clock::now();
        rsa.benchmark(cipherFile, plainFile, false);
        end = std::chrono::high_resolution_clock::now();
        auto dec_time = std::chrono::duration_cast<std::chrono::milliseconds>(end - start).count() / 10000.0;

        std::cout << bitSize << "\t\t" << enc_time << "\t\t" << dec_time << "\n";
    }
}

int main() {
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);
    
    RSA_OAEP rsa;
    int choice;

    while (true) {
        std::cout << "\nRSA Cryptography System\n";
        std::cout << "1. Generate Keys\n";
        std::cout << "2. Encrypt\n";
        std::cout << "3. Decrypt\n";
        std::cout << "4. Benchmark\n";
        std::cout << "5. Exit\n";
        std::cout << "Enter your choice: ";
        std::cin >> choice;

        switch (choice) {
            case 1:
                handleKeyGeneration(rsa);
                break;
            case 2:
                handleEncryption(rsa);
                break;
            case 3:
                handleDecryption(rsa);
                break;
            case 4:
                handleBenchmark(rsa);
                break;
            case 5:
                std::cout << "Goodbye!\n";
                return 0;
            default:
                std::cout << "Invalid choice. Please try again.\n";
        }
    }

    return 0;
} 