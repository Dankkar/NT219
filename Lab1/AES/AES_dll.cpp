#include <iostream>
using std::cerr;
using std::cin;
using std::cout;
using std::endl;

#include <string>
using std::string;

#include <iostream>
using std::cerr;
using std::cin;
using std::cout;
using std::endl;

#include "assert.h"

#include <cstdlib>
using std::exit;

#include "cryptopp/cryptlib.h"
using CryptoPP::AuthenticatedSymmetricCipher;
using CryptoPP::Exception;

#include "cryptopp/hex.h"
using CryptoPP::HexDecoder;
using CryptoPP::HexEncoder;

#include "cryptopp/filters.h"
using CryptoPP::ArraySink;
using CryptoPP::ArraySource;
using CryptoPP::AuthenticatedDecryptionFilter;
using CryptoPP::AuthenticatedEncryptionFilter;
using CryptoPP::Redirector;
using CryptoPP::StreamTransformationFilter;
using CryptoPP::StringSink;
using CryptoPP::StringSource;

#include "cryptopp/DES.h"
using CryptoPP::DES;

#include "cryptopp/modes.h"
using CryptoPP::CBC_Mode;
using CryptoPP::CFB_Mode;
using CryptoPP::ECB_Mode;
using CryptoPP::OFB_Mode;

#include "cryptopp/ccm.h"
using CryptoPP::CTR_Mode;

#include "cryptopp/xts.h"
using CryptoPP::XTS;

#include <cryptopp/ccm.h>
using CryptoPP::CCM;
#include "cryptopp/gcm.h"
using CryptoPP::GCM;

#include "cryptopp/files.h"
using CryptoPP::FileSink;
using CryptoPP::FileSource;

#include "cryptopp/base64.h"
using CryptoPP::Base64Decoder;
using CryptoPP::Base64Encoder;

#include "cryptopp/osrng.h"
using CryptoPP::AutoSeededRandomPool;

#include "cryptopp/DES.h"
using CryptoPP::DES;

#include "cryptopp/filters.h"
using CryptoPP::ArraySink;
using CryptoPP::ArraySource;
using CryptoPP::StreamTransformationFilter;
using CryptoPP::StringSink;
using CryptoPP::StringSource;

#include "cryptopp/files.h"
using CryptoPP::FileSink;

#ifdef _WIN32
#include <windows.h>
#endif

using namespace std;
using namespace CryptoPP;

string encoded, decoded, plain, cipher, recovered;

// Define DLL export macro
#ifndef DLL_EXPORT
#ifdef _WIN32
#define DLL_EXPORT __declspec(dllexport) // define class specifier
#else
#define DLL_EXPORT
#endif
#endif

extern "C"
{
    DLL_EXPORT void GenerateKeyAndIV(const char* mode, int keySize, const char* format, const char* keyFile, const char* ivFile);
    DLL_EXPORT const char* AESEncrypt(const char* mode, const char* keyIVFormat, const char* keyFile, const char* ivFile,
                                      const char* cipherFormat,
                                      const char* plainText);
    DLL_EXPORT const char* AESDecrypt(const char* mode, const char* keyIVFormat, const char* keyFile, const char* ivFile,
                                      const char* cipherFormat,
                                      const char* cipherText);
};

string hexdecode(CryptoPP::byte encoded[], unsigned int size);
string hexencode(CryptoPP::byte decoded[], unsigned int size);
string base64decode(CryptoPP::byte encoded[], unsigned int size);
string base64encode(CryptoPP::byte decoded[], unsigned int size);
string hexdecode(string encoded);
string hexencode(string decoded);
string base64decode(string encoded);
string base64encode(string decoded);

void GenerateKeyAndIV(const char* mode, int keySize, const char* format, const char* keyFile, const char* ivFile)
{
    string strMode(mode);
    string strFormat(format);
    string strKeyFile(keyFile);
    string strIVFile(ivFile);
    string encoded;

    AutoSeededRandomPool prng;
    int ivSize;
    if (strMode == "CCM")
    {
        ivSize = 12;
    }
    else
        ivSize = 16;
    CryptoPP::byte* iv = new CryptoPP::byte[ivSize];

    CryptoPP::byte* key = new CryptoPP::byte[keySize];
    if (strMode == "XTS" && keySize != 32)
    {
        cout << "Invalid key size for XTS mode! Please choose 32 instead!";
        exit(1);
    }
    prng.GenerateBlock(key, keySize);
    cout << "Generate key successfully!" << endl;

    if (strMode != "ECB")
    {
        prng.GenerateBlock(iv, ivSize);
        cout << "Generate IV successfully!" << endl;
    }
    if (strFormat == "Binary")
    {
        // Write key in binary format
        FileSink keyOut(keyFile, true);
        keyOut.Put(key, keySize);
        keyOut.MessageEnd();
        cout << "Key saved in Binary format in file " << keyFile << endl;

        if (strMode != "ECB")
        {
            FileSink ivOut(ivFile, true);
            ivOut.Put(iv, ivSize);
            ivOut.MessageEnd();
            cout << "IV saved in Binary format in file " << ivFile << endl;
        }
    }
    else if (strFormat == "Hex")
    {
        encoded = hexencode(key, keySize);
        StringSource(encoded, true, new FileSink(keyFile));
        cout << "Key saved in Hex format in file " << keyFile << endl;

        if (strMode != "ECB")
        {
            encoded = hexencode(iv, ivSize);
            StringSource(encoded, true, new FileSink(ivFile));
            cout << "IV saved in Hex format in file " << ivFile << endl;
        }
    }
    else if (strFormat == "Base64")
    {
        encoded = base64encode(key, keySize);
        StringSource(encoded, true, new FileSink(keyFile));
        cout << "Key saved in Base64 format in file " << keyFile << endl;

        if (strMode != "ECB")
        {
            encoded = base64encode(iv, ivSize);
            StringSource(encoded, true, new FileSink(ivFile));
            cout << "IV saved in Base64 format in file " << ivFile << endl;
        }
    }
    else
    {
        exit(1);
    }
}

const char* AESEncrypt(const char* mode, const char* keyIVFormat, const char* keyFile, const char* ivFile,
                       const char* cipherFormat,
                       const char* plainText)
{
    try {
        string dataKey, dataIV, decodedKey, decodedIV;
        string strMode(mode);
        string strFormat(keyIVFormat);
        string strCFormat(cipherFormat);

        // Validate inputs
        if (!mode || !keyIVFormat || !keyFile || !cipherFormat || !plainText) {
            return "Error: Invalid input parameters";
        }

        // Load key from file
        try {
            FileSource(keyFile, true, new StringSink(dataKey));
        }
        catch (const Exception& e) {
            return "Error: Failed to read key file";
        }

        // Load IV from file if needed
        if (strMode != "ECB") {
            if (!ivFile) {
                return "Error: IV file required for non-ECB modes";
            }
            try {
                FileSource(ivFile, true, new StringSink(dataIV));
            }
            catch (const Exception& e) {
                return "Error: Failed to read IV file";
            }
        }

        // Decode key and IV based on format
        if (strFormat == "Binary") {
            decodedKey = dataKey;
            if (strMode != "ECB")
                decodedIV = dataIV;
        }
        else if (strFormat == "Hex") {
            try {
                decodedKey = hexdecode(dataKey);
                if (strMode != "ECB")
                    decodedIV = hexdecode(dataIV);
            }
            catch (const Exception& e) {
                return "Error: Invalid hex format";
            }
        }
        else if (strFormat == "Base64") {
            try {
                decodedKey = base64decode(dataKey);
                if (strMode != "ECB")
                    decodedIV = base64decode(dataIV);
            }
            catch (const Exception& e) {
                return "Error: Invalid base64 format";
            }
        }
        else {
            return "Error: Invalid key/IV format";
        }

        int ivSize = (strMode == "CCM") ? 12 : 16;
        std::unique_ptr<CryptoPP::byte[]> iv(new CryptoPP::byte[ivSize]);
        std::unique_ptr<CryptoPP::byte[]> key(new CryptoPP::byte[decodedKey.length()]);

        int keySize = decodedKey.length();
        StringSource(decodedKey, true, new ArraySink(key.get(), keySize));
        if (strMode != "ECB") {
            StringSource(decodedIV, true, new ArraySink(iv.get(), ivSize));
        }

        string plain(plainText);
        string cipher;

        if (strMode == "ECB")
        {
            ECB_Mode<AES>::Encryption e;
            e.SetKey(key.get(), keySize);
            cipher.clear();
            StringSource s(plain, true, new StreamTransformationFilter(e, new StringSink(cipher)));
        }
        else if (strMode == "CBC")
        {
            CBC_Mode<AES>::Encryption e;
            e.SetKeyWithIV(key.get(), keySize, iv.get());
            cipher.clear();
            StringSource s(plain, true, new StreamTransformationFilter(e, new StringSink(cipher)));
        }
        else if (strMode == "OFB")
        {
            OFB_Mode<AES>::Encryption e;
            e.SetKeyWithIV(key.get(), keySize, iv.get());
            cipher.clear();
            StringSource s(plain, true, new StreamTransformationFilter(e, new StringSink(cipher)));
        }
        else if (strMode == "CFB")
        {
            CFB_Mode<AES>::Encryption e;
            e.SetKeyWithIV(key.get(), keySize, iv.get());

            cipher.clear();
            StringSource s(plain, true, new StreamTransformationFilter(e, new StringSink(cipher)));
        }
        else if (strMode == "CTR")
        {
            CTR_Mode<AES>::Encryption e;
            e.SetKeyWithIV(key.get(), keySize, iv.get());
            cipher.clear();
            StringSource s(plain, true, new StreamTransformationFilter(e, new StringSink(cipher)));
        }
        else if (strMode == "XTS")
        {
            XTS<AES>::Encryption e;
            e.SetKeyWithIV(key.get(), 32, iv.get());
            cipher.clear();
            StringSource s(plain, true, new StreamTransformationFilter(e, new StringSink(cipher), StreamTransformationFilter::NO_PADDING)); // StringSource
        }
        else if (strMode == "CCM")
        {
            const int TAG_SIZE = 8;
            CCM<AES, TAG_SIZE>::Encryption e;
            e.SetKeyWithIV(key.get(), keySize, iv.get(), ivSize);
            e.SpecifyDataLengths(0, plain.size(), 0);
            cipher.clear();
            StringSource s(plain, true, new AuthenticatedEncryptionFilter(e, new StringSink(cipher)));
        }
        else if (strMode == "GCM")
        {
            GCM<AES>::Encryption e;
            e.SetKeyWithIV(key.get(), keySize, iv.get(), ivSize);
            cipher.clear();
            StringSource s(plain, true, new AuthenticatedEncryptionFilter(e, new StringSink(cipher)));
        }
        else
        {
            cout << "Error!";
            exit(1);
        }

        // Convert cipher to requested format
        if (strCFormat == "Binary") {
            return cipher.c_str();
        }
        else if (strCFormat == "Hex") {
            return hexencode(cipher).c_str();
        }
        else if (strCFormat == "Base64") {
            return base64encode(cipher).c_str();
        }
        else {
            return "Error: Invalid cipher format";
        }
    }
    catch (const Exception& e) {
        return "Error: Encryption failed";
    }
    catch (...) {
        return "Error: Unexpected error during encryption";
    }
}

const char* AESDecrypt(const char* mode, const char* keyIVFormat, const char* keyFile, const char* ivFile,
                       const char* cipherFormat,
                       const char* cipherText)
{
    try {
        string dataKey, dataIV, decodedKey, decodedIV;
        string strMode(mode);
        string strFormat(keyIVFormat);
        string strCFormat(cipherFormat);

        // Validate inputs
        if (!mode || !keyIVFormat || !keyFile || !cipherFormat || !cipherText) {
            return "Error: Invalid input parameters";
        }

        // Load key from file
        try {
            FileSource(keyFile, true, new StringSink(dataKey));
        }
        catch (const Exception& e) {
            return "Error: Failed to read key file";
        }

        // Load IV from file if needed
        if (strMode != "ECB") {
            if (!ivFile) {
                return "Error: IV file required for non-ECB modes";
            }
            try {
                FileSource(ivFile, true, new StringSink(dataIV));
            }
            catch (const Exception& e) {
                return "Error: Failed to read IV file";
            }
        }

        // Decode key and IV based on format
        if (strFormat == "Binary") {
            decodedKey = dataKey;
            if (strMode != "ECB")
                decodedIV = dataIV;
        }
        else if (strFormat == "Hex") {
            try {
                decodedKey = hexdecode(dataKey);
                if (strMode != "ECB")
                    decodedIV = hexdecode(dataIV);
            }
            catch (const Exception& e) {
                return "Error: Invalid hex format";
            }
        }
        else if (strFormat == "Base64") {
            try {
                decodedKey = base64decode(dataKey);
                if (strMode != "ECB")
                    decodedIV = base64decode(dataIV);
            }
            catch (const Exception& e) {
                return "Error: Invalid base64 format";
            }
        }
        else {
            return "Error: Invalid key/IV format";
        }

        int ivSize = (strMode == "CCM") ? 12 : 16;
        vector<unsigned char> iv(ivSize);
        vector<unsigned char> key(decodedKey.length());

        int keySize = decodedKey.length();
        StringSource(decodedKey, true, new ArraySink(key.data(), keySize));
        if (strMode != "ECB") {
            StringSource(decodedIV, true, new ArraySink(iv.data(), ivSize));
        }

        string cipher(cipherText);
        string decoded;

        if (strCFormat == "Binary") {
            decoded = cipher;
        }
        else if (strCFormat == "Hex") {
            decoded = hexdecode(cipher);
        }
        else if (strCFormat == "Base64") {
            decoded = base64decode(cipher);
        }
        else {
            return "Error: Invalid cipher format";
        }

        string recovered;
        if (strMode == "ECB") {
            ECB_Mode<AES>::Decryption d;
            d.SetKey(key.data(), keySize);
            StringSource s(decoded, true, new StreamTransformationFilter(d, new StringSink(recovered)));
        }
        else if (strMode == "CBC") {
            CBC_Mode<AES>::Decryption d;
            d.SetKeyWithIV(key.data(), keySize, iv.data());
            StringSource s(decoded, true, new StreamTransformationFilter(d, new StringSink(recovered)));
        }
        else if (strMode == "OFB") {
            OFB_Mode<AES>::Decryption d;
            d.SetKeyWithIV(key.data(), keySize, iv.data());
            StringSource s(decoded, true, new StreamTransformationFilter(d, new StringSink(recovered)));
        }
        else if (strMode == "CFB") {
            CFB_Mode<AES>::Decryption d;
            d.SetKeyWithIV(key.data(), keySize, iv.data());
            StringSource s(decoded, true, new StreamTransformationFilter(d, new StringSink(recovered)));
        }
        else if (strMode == "CTR") {
            CTR_Mode<AES>::Decryption d;
            d.SetKeyWithIV(key.data(), keySize, iv.data());
            StringSource s(decoded, true, new StreamTransformationFilter(d, new StringSink(recovered)));
        }
        else if (strMode == "XTS") {
            XTS_Mode<AES>::Decryption d;
            d.SetKeyWithIV(key.data(), keySize, iv.data());
            StringSource s(decoded, true, new StreamTransformationFilter(d, new StringSink(recovered), StreamTransformationFilter::NO_PADDING));
        }
        else if (strMode == "CCM") {
            const int TAG_SIZE = 8;
            CCM<AES, TAG_SIZE>::Decryption d;
            d.SetKeyWithIV(key.data(), keySize, iv.data(), ivSize);
            d.SpecifyDataLengths(0, decoded.size() - TAG_SIZE, 0);
            StringSource s(decoded, true, new AuthenticatedDecryptionFilter(d, new StringSink(recovered)));
        }
        else if (strMode == "GCM") {
            GCM<AES>::Decryption d;
            d.SetKeyWithIV(key.data(), keySize, iv.data(), ivSize);
            StringSource s(decoded, true, new AuthenticatedDecryptionFilter(d, new StringSink(recovered)));
        }
        else {
            return "Error: Invalid encryption mode";
        }

        return recovered.c_str();
    }
    catch (const Exception& e) {
        static string err;
        err = string("Error: ") + e.what();
        return err.c_str();
    }
    catch (const std::exception& e) {
        static string err;
        err = string("Error: ") + e.what();
        return err.c_str();
    }
    catch (...) {
        return "Error: Unexpected error during decryption";
    }
}

int main(int argc, char* argv[])
{
#ifdef __linux__
    std::locale::global(std::locale("C.UTF-8"));
#endif

#ifdef _WIN32
    // Set console code page to UTF-8 on Windows
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);
#endif

    if (argc < 2)
    {
        cout << "Usage: " << endl
            << "genKeyIV <mode> <keySize> <format> <keyFile> <ivFile>" << endl
            << "encrypt <mode> <keyFile> <keyFormat> <cipherTextFormat> <plaintextFile> <cipherTextFile> " << endl
            << "decrypt <mode> <keyFile> <keyFormat> <cipherTextFormat> <cipherTextFile> <recoverTextFile>" << endl;
    }
    string action(argv[1]);
    if (action == "genKeyIV")
    {
        int keySize = std::stoi(argv[3]);
        GenerateKeyAndIV(argv[2], keySize, argv[4], argv[5], argv[6]);
    }
    else if (action == "encrypt")
    {
        cout << AESEncrypt(argv[2], argv[3], argv[4], argv[5], argv[6], argv[7]);
    }
    else if (action == "decrypt")
    {
        cout << AESDecrypt(argv[2], argv[3], argv[4], argv[5], argv[6], argv[7]);
    }
    else
    {
        cout << "Invalid argument: " << action;
        return 1;
    }

    return 0;
}

string base64encode(CryptoPP::byte decoded[], unsigned int size)
{
    string encoded;
    encoded.clear();
    StringSource(decoded, size, true, new Base64Encoder(new StringSink(encoded), false));
    return encoded;
}
string base64decode(CryptoPP::byte encoded[], unsigned int size)
{
    string decoded;
    decoded.clear();
    StringSource(encoded, size, true, new Base64Decoder(new StringSink(decoded)));
    return decoded;
}
string hexencode(CryptoPP::byte decoded[], unsigned int size)
{
    string encoded;
    encoded.clear();
    StringSource(decoded, size, true, new HexEncoder(new StringSink(encoded), false));
    return encoded;
}
string hexdecode(CryptoPP::byte encoded[], unsigned int size)
{
    string decoded;
    decoded.clear();
    StringSource(encoded, size, true, new HexDecoder(new StringSink(decoded)));
    return decoded;
}
string base64encode(string decoded)
{
    string encoded;
    encoded.clear();
    StringSource(decoded, true, new Base64Encoder(new StringSink(encoded), false));
    return encoded;
}
string base64decode(string encoded)
{
    string decoded;
    decoded.clear();
    StringSource(encoded, true, new Base64Decoder(new StringSink(decoded)));
    return decoded;
}
string hexencode(string decoded)
{
    string encoded;
    encoded.clear();
    StringSource(decoded, true, new HexEncoder(new StringSink(encoded), false));
    return encoded;
}
string hexdecode(string encoded)
{
    string decoded;
    decoded.clear();
    StringSource(encoded, true, new HexDecoder(new StringSink(decoded)));
    return decoded;
}