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
    DLL_EXPORT const char* DESEncrypt(const char* mode, const char* keyIVFormat, const char* keyFile, const char* ivFile,
                                      const char* cipherFormat,
                                      const char* plainText);
    DLL_EXPORT const char* DESDecrypt(const char* mode, const char* keyIVFormat, const char* keyFile, const char* ivFile,
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
    int ivSize = 16;
    CryptoPP::byte* iv = new CryptoPP::byte[ivSize];

    CryptoPP::byte* key = new CryptoPP::byte[keySize];
    prng.GenerateBlock(key, keySize);
    cout << "Generate key successfully!" << endl;

    if (strMode != "ECB")
    {
        prng.GenerateBlock(iv, ivSize);
        cout << "Generate IV successfully!" << endl;
    }

    try {
        if (strFormat == "Binary")
        {
            // Write key in binary format
            ofstream keyOut(keyFile, ios::binary);
            if (!keyOut) {
                throw runtime_error("Could not open key file for writing");
            }
            keyOut.write(reinterpret_cast<const char*>(key), keySize);
            keyOut.close();
            cout << "Key saved in Binary format in file " << keyFile << endl;

            // Write IV in binary format if not ECB mode
            if (strMode != "ECB")
            {
                ofstream ivOut(ivFile, ios::binary);
                if (!ivOut) {
                    throw runtime_error("Could not open IV file for writing");
                }
                ivOut.write(reinterpret_cast<const char*>(iv), ivSize);
                ivOut.close();
                cout << "IV saved in Binary format in file " << ivFile << endl;
            }
        }
        else if (strFormat == "Hex")
        {
            // Convert key to hex and write
            encoded = hexencode(key, keySize);
            ofstream keyOut(keyFile);
            if (!keyOut) {
                throw runtime_error("Could not open key file for writing");
            }
            keyOut << encoded;
            keyOut.close();
            cout << "Key saved in Hex format in file " << keyFile << endl;

            // Convert IV to hex and write if not ECB mode
            if (strMode != "ECB")
            {
                encoded = hexencode(iv, ivSize);
                ofstream ivOut(ivFile);
                if (!ivOut) {
                    throw runtime_error("Could not open IV file for writing");
                }
                ivOut << encoded;
                ivOut.close();
                cout << "IV saved in Hex format in file " << ivFile << endl;
            }
        }
        else if (strFormat == "Base64")
        {
            // Convert key to base64 and write
            encoded = base64encode(key, keySize);
            ofstream keyOut(keyFile);
            if (!keyOut) {
                throw runtime_error("Could not open key file for writing");
            }
            keyOut << encoded;
            keyOut.close();
            cout << "Key saved in Base64 format in file " << keyFile << endl;

            // Convert IV to base64 and write if not ECB mode
            if (strMode != "ECB")
            {
                encoded = base64encode(iv, ivSize);
                ofstream ivOut(ivFile);
                if (!ivOut) {
                    throw runtime_error("Could not open IV file for writing");
                }
                ivOut << encoded;
                ivOut.close();
                cout << "IV saved in Base64 format in file " << ivFile << endl;
            }
        }
        else
        {
            throw runtime_error("Invalid format specified");
        }
    }
    catch (const exception& e) {
        cerr << "Error: " << e.what() << endl;
        exit(1);
    }

    delete[] key;
    delete[] iv;
}

const char* DESEncrypt(const char* mode, const char* keyIVFormat, const char* keyFile, const char* ivFile,
                       const char* cipherFormat,
                       const char* plainText)
{
    string dataKey, dataIV, decodedKey, decodedIV;
    string strMode(mode);
    string strFormat(keyIVFormat);
    string strCFormat(cipherFormat);

    // Load key and IV from file
    FileSource(keyFile, true, new StringSink(dataKey));
    if (strMode != "ECB")
        FileSource(ivFile, true, new StringSink(dataIV));
    if (strFormat == "Binary")
    {
        decodedKey = dataKey;
        if (strMode != "ECB")
            decodedIV = dataIV;
    }
    else if (strFormat == "Hex")
    {
        decodedKey = hexdecode(dataKey);
        if (strMode != "ECB")
            decodedIV = hexdecode(dataIV);
    }
    else if (strFormat == "Base64")
    {
        decodedKey = base64decode(dataKey);
        if (strMode != "ECB")
            decodedIV = base64decode(dataIV);
    }
    else
    {
        exit(1);
    }

    int ivSize = 16;
    CryptoPP::byte* iv = new CryptoPP::byte[ivSize];

    CryptoPP::byte* key = new CryptoPP::byte[decodedKey.length()];
    int keySize = decodedKey.length();
    // int ivSize = decodedIV.length();
    StringSource(decodedKey, true, new ArraySink(key, keySize));
    StringSource(decodedIV, true, new ArraySink(iv, ivSize));

    string plain(plainText);

    if (strMode == "ECB")
    {
        ECB_Mode<DES>::Encryption e;
        e.SetKey(key, keySize);
        cipher.clear();
        StringSource s(plain, true, new StreamTransformationFilter(e, new StringSink(cipher)));
    }
    else if (strMode == "CBC")
    {
        CBC_Mode<DES>::Encryption e;
        e.SetKeyWithIV(key, keySize, iv);
        cipher.clear();
        StringSource s(plain, true, new StreamTransformationFilter(e, new StringSink(cipher)));
    }
    else if (strMode == "OFB")
    {
        OFB_Mode<DES>::Encryption e;
        e.SetKeyWithIV(key, keySize, iv);
        cipher.clear();
        StringSource s(plain, true, new StreamTransformationFilter(e, new StringSink(cipher)));
    }
    else if (strMode == "CFB")
    {
        CFB_Mode<DES>::Encryption e;
        e.SetKeyWithIV(key, keySize, iv);

        cipher.clear();
        StringSource s(plain, true, new StreamTransformationFilter(e, new StringSink(cipher)));
    }
    else if (strMode == "CTR")
    {
        CTR_Mode<DES>::Encryption e;
        e.SetKeyWithIV(key, keySize, iv);
        cipher.clear();
        StringSource s(plain, true, new StreamTransformationFilter(e, new StringSink(cipher)));
    }
    else
    {
        cout << "Error!";
        exit(1);
    }

    encoded.clear();
    if (strCFormat == "Binary")
    {
        encoded = cipher;
    }
    else if (strCFormat == "Hex")
    {
        encoded = hexencode(cipher);
    }
    else if (strCFormat == "Base64")
    {
        encoded = base64encode(cipher);
    }
    else
    {
        cout << "Invalid format for cipher text.";
        exit(1);
    }
    // cout << encoded << endl;
    const char* result = encoded.c_str();
    return result;
}

const char* DESDecrypt(const char* mode, const char* keyIVFormat, const char* keyFile, const char* ivFile,
                       const char* cipherFormat,
                       const char* cipherText)
{
    string dataKey, dataIV, decodedKey, decodedIV;
    string strMode(mode);
    string strFormat(keyIVFormat);
    string strCFormat(cipherFormat);

    // Load key and IV from file
    FileSource(keyFile, true, new StringSink(dataKey));
    if (strMode != "ECB")
        FileSource(ivFile, true, new StringSink(dataIV));
    if (strFormat == "Binary")
    {
        decodedKey = dataKey;
        if (strMode != "ECB")
            decodedIV = dataIV;
    }
    else if (strFormat == "Hex")
    {
        decodedKey = hexdecode(dataKey);
        if (strMode != "ECB")
            decodedIV = hexdecode(dataIV);
    }
    else if (strFormat == "Base64")
    {
        decodedKey = base64decode(dataKey);
        if (strMode != "ECB")
            decodedIV = base64decode(dataIV);
    }
    else
    {
        exit(1);
    }

    int ivSize = 16;
    CryptoPP::byte* iv = new CryptoPP::byte[ivSize];

    CryptoPP::byte* key = new CryptoPP::byte[decodedKey.length()];
    int keySize = decodedKey.length();
    // int ivSize = decodedIV.length();
    StringSource(decodedKey, true, new ArraySink(key, keySize));
    StringSource(decodedIV, true, new ArraySink(iv, ivSize));

    string cipher(cipherText);

    decoded.clear();
    if (strCFormat == "Binary")
    {
        decoded = cipher;
    }
    else if (strCFormat == "Hex")
    {
        decoded = hexdecode(cipher);
    }
    else if (strCFormat == "Base64")
    {
        decoded = base64decode(cipher);
    }
    else
    {
        cout << "Invalid format for cipher text.";
        exit(1);
    }

    if (strMode == "ECB")
    {
        ECB_Mode<DES>::Decryption d;
        d.SetKey(key, keySize);

        recovered.clear();
        StringSource s(decoded, true, new StreamTransformationFilter(d, new StringSink(recovered)));
    }
    else if (strMode == "CBC")
    {
        CBC_Mode<DES>::Decryption d;
        d.SetKeyWithIV(key, keySize, iv);

        recovered.clear();
        StringSource s(decoded, true, new StreamTransformationFilter(d, new StringSink(recovered)));
    }
    else if (strMode == "OFB")
    {
        OFB_Mode<DES>::Decryption d;
        d.SetKeyWithIV(key, keySize, iv);

        recovered.clear();
        StringSource s(decoded, true, new StreamTransformationFilter(d, new StringSink(recovered)));
    }
    else if (strMode == "CFB")
    {
        CFB_Mode<DES>::Decryption d;
        d.SetKeyWithIV(key, keySize, iv);

        recovered.clear();
        StringSource s(decoded, true, new StreamTransformationFilter(d, new StringSink(recovered)));
    }
    else if (strMode == "CTR")
    {
        CTR_Mode<DES>::Decryption d;
        d.SetKeyWithIV(key, keySize, iv);

        recovered.clear();
        StringSource s(decoded, true, new StreamTransformationFilter(d, new StringSink(recovered)));
    }
    else
    {
        cout << "Error!";
        exit(0);
    }
    const char* result = recovered.c_str();
    return result;
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
        cout << DESEncrypt(argv[2], argv[3], argv[4], argv[5], argv[6], argv[7]);
    }
    else if (action == "decrypt")
    {
        cout << DESDecrypt(argv[2], argv[3], argv[4], argv[5], argv[6], argv[7]);
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