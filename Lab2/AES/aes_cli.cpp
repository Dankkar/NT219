#include <iostream>
#include <vector>
#include <string>
#include <iomanip>
#include <sstream>
#include <codecvt>
#include <locale>
#include <windows.h>
#include <fstream>
#include <algorithm> 
#include <chrono>

// AES Constants and class implementation 

const unsigned char S_BOX[256] = {
    0x63, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5, 0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76,
    0xca, 0x82, 0xc9, 0x7d, 0xfa, 0x59, 0x47, 0xf0, 0xad, 0xd4, 0xa2, 0xaf, 0x9c, 0xa4, 0x72, 0xc0,
    0xb7, 0xfd, 0x93, 0x26, 0x36, 0x3f, 0xf7, 0xcc, 0x34, 0xa5, 0xe5, 0xf1, 0x71, 0xd8, 0x31, 0x15,
    0x04, 0xc7, 0x23, 0xc3, 0x18, 0x96, 0x05, 0x9a, 0x07, 0x12, 0x80, 0xe2, 0xeb, 0x27, 0xb2, 0x75,
    0x09, 0x83, 0x2c, 0x1a, 0x1b, 0x6e, 0x5a, 0xa0, 0x52, 0x3b, 0xd6, 0xb3, 0x29, 0xe3, 0x2f, 0x84,
    0x53, 0xd1, 0x00, 0xed, 0x20, 0xfc, 0xb1, 0x5b, 0x6a, 0xcb, 0xbe, 0x39, 0x4a, 0x4c, 0x58, 0xcf,
    0xd0, 0xef, 0xaa, 0xfb, 0x43, 0x4d, 0x33, 0x85, 0x45, 0xf9, 0x02, 0x7f, 0x50, 0x3c, 0x9f, 0xa8,
    0x51, 0xa3, 0x40, 0x8f, 0x92, 0x9d, 0x38, 0xf5, 0xbc, 0xb6, 0xda, 0x21, 0x10, 0xff, 0xf3, 0xd2,
    0xcd, 0x0c, 0x13, 0xec, 0x5f, 0x97, 0x44, 0x17, 0xc4, 0xa7, 0x7e, 0x3d, 0x64, 0x5d, 0x19, 0x73,
    0x60, 0x81, 0x4f, 0xdc, 0x22, 0x2a, 0x90, 0x88, 0x46, 0xee, 0xb8, 0x14, 0xde, 0x5e, 0x0b, 0xdb,
    0xe0, 0x32, 0x3a, 0x0a, 0x49, 0x06, 0x24, 0x5c, 0xc2, 0xd3, 0xac, 0x62, 0x91, 0x95, 0xe4, 0x79,
    0xe7, 0xc8, 0x37, 0x6d, 0x8d, 0xd5, 0x4e, 0xa9, 0x6c, 0x56, 0xf4, 0xea, 0x65, 0x7a, 0xae, 0x08,
    0xba, 0x78, 0x25, 0x2e, 0x1c, 0xa6, 0xb4, 0xc6, 0xe8, 0xdd, 0x74, 0x1f, 0x4b, 0xbd, 0x8b, 0x8a,
    0x70, 0x3e, 0xb5, 0x66, 0x48, 0x03, 0xf6, 0x0e, 0x61, 0x35, 0x57, 0xb9, 0x86, 0xc1, 0x1d, 0x9e,
    0xe1, 0xf8, 0x98, 0x11, 0x69, 0xd9, 0x8e, 0x94, 0x9b, 0x1e, 0x87, 0xe9, 0xce, 0x55, 0x28, 0xdf,
    0x8c, 0xa1, 0x89, 0x0d, 0xbf, 0xe6, 0x42, 0x68, 0x41, 0x99, 0x2d, 0x0f, 0xb0, 0x54, 0xbb, 0x16
};

const unsigned char INV_S_BOX[256] = {
    0x52, 0x09, 0x6a, 0xd5, 0x30, 0x36, 0xa5, 0x38, 0xbf, 0x40, 0xa3, 0x9e, 0x81, 0xf3, 0xd7, 0xfb,
    0x7c, 0xe3, 0x39, 0x82, 0x9b, 0x2f, 0xff, 0x87, 0x34, 0x8e, 0x43, 0x44, 0xc4, 0xde, 0xe9, 0xcb,
    0x54, 0x7b, 0x94, 0x32, 0xa6, 0xc2, 0x23, 0x3d, 0xee, 0x4c, 0x95, 0x0b, 0x42, 0xfa, 0xc3, 0x4e,
    0x08, 0x2e, 0xa1, 0x66, 0x28, 0xd9, 0x24, 0xb2, 0x76, 0x5b, 0xa2, 0x49, 0x6d, 0x8b, 0xd1, 0x25,
    0x72, 0xf8, 0xf6, 0x64, 0x86, 0x68, 0x98, 0x16, 0xd4, 0xa4, 0x5c, 0xcc, 0x5d, 0x65, 0xb6, 0x92,
    0x6c, 0x70, 0x48, 0x50, 0xfd, 0xed, 0xb9, 0xda, 0x5e, 0x15, 0x46, 0x57, 0xa7, 0x8d, 0x9d, 0x84,
    0x90, 0xd8, 0xab, 0x00, 0x8c, 0xbc, 0xd3, 0x0a, 0xf7, 0xe4, 0x58, 0x05, 0xb8, 0xb3, 0x45, 0x06,
    0xd0, 0x2c, 0x1e, 0x8f, 0xca, 0x3f, 0x0f, 0x02, 0xc1, 0xaf, 0xbd, 0x03, 0x01, 0x13, 0x8a, 0x6b,
    0x3a, 0x91, 0x11, 0x41, 0x4f, 0x67, 0xdc, 0xea, 0x97, 0xf2, 0xcf, 0xce, 0xf0, 0xb4, 0xe6, 0x73,
    0x96, 0xac, 0x74, 0x22, 0xe7, 0xad, 0x35, 0x85, 0xe2, 0xf9, 0x37, 0xe8, 0x1c, 0x75, 0xdf, 0x6e,
    0x47, 0xf1, 0x1a, 0x71, 0x1d, 0x29, 0xc5, 0x89, 0x6f, 0xb7, 0x62, 0x0e, 0xaa, 0x18, 0xbe, 0x1b,
    0xfc, 0x56, 0x3e, 0x4b, 0xc6, 0xd2, 0x79, 0x20, 0x9a, 0xdb, 0xc0, 0xfe, 0x78, 0xcd, 0x5a, 0xf4,
    0x1f, 0xdd, 0xa8, 0x33, 0x88, 0x07, 0xc7, 0x31, 0xb1, 0x12, 0x10, 0x59, 0x27, 0x80, 0xec, 0x5f,
    0x60, 0x51, 0x7f, 0xa9, 0x19, 0xb5, 0x4a, 0x0d, 0x2d, 0xe5, 0x7a, 0x9f, 0x93, 0xc9, 0x9c, 0xef,
    0xa0, 0xe0, 0x3b, 0x4d, 0xae, 0x2a, 0xf5, 0xb0, 0xc8, 0xeb, 0xbb, 0x3c, 0x83, 0x53, 0x99, 0x61,
    0x17, 0x2b, 0x04, 0x7e, 0xba, 0x77, 0xd6, 0x26, 0xe1, 0x69, 0x14, 0x63, 0x55, 0x21, 0x0c, 0x7d
};

const unsigned char RCON[10][4] = {
    {0x01, 0x00, 0x00, 0x00},
    {0x02, 0x00, 0x00, 0x00},
    {0x04, 0x00, 0x00, 0x00},
    {0x08, 0x00, 0x00, 0x00},
    {0x10, 0x00, 0x00, 0x00},
    {0x20, 0x00, 0x00, 0x00},
    {0x40, 0x00, 0x00, 0x00},
    {0x80, 0x00, 0x00, 0x00},
    {0x1B, 0x00, 0x00, 0x00},
    {0x36, 0x00, 0x00, 0x00}
};

class AES {
private:
    std::vector<unsigned char> key;
    std::vector<std::vector<unsigned char>> round_keys;
    int key_length;

    // Helper functions
    unsigned char gmul(unsigned char a, unsigned char b) {
        unsigned char p = 0;
        for (int i = 0; i < 8; i++) {
            if (b & 1) {
                p ^= a;
            }
            bool hi_bit_set = a & 0x80;
            a <<= 1;
            if (hi_bit_set) {
                a ^= 0x1b;
            }
            b >>= 1;
        }
        return p;
    }

    std::vector<unsigned char> sub_word(std::vector<unsigned char> word) {
        for (int i = 0; i < 4; i++) {
            word[i] = S_BOX[word[i]];
        }
        return word;
    }

    std::vector<unsigned char> rot_word(std::vector<unsigned char> word) {
        unsigned char temp = word[0];
        word[0] = word[1];
        word[1] = word[2];
        word[2] = word[3];
        word[3] = temp;
        return word;
    }

    void key_expansion() {
        int nk = key_length / 32;  // Number of 32-bit words in the key
        int nr = nk + 6;          // Number of rounds
        int total_words = 4 * (nr + 1);

        round_keys.resize(total_words, std::vector<unsigned char>(4));

        // Copy initial key
        for (int i = 0; i < nk; i++) {
            for (int j = 0; j < 4; j++) {
                round_keys[i][j] = key[4 * i + j];
            }
        }

        // Generate remaining round keys
        for (int i = nk; i < total_words; i++) {
            std::vector<unsigned char> temp = round_keys[i - 1];
            if (i % nk == 0) {
                temp = sub_word(rot_word(temp));
                for (int j = 0; j < 4; j++) {
                    temp[j] ^= RCON[(i / nk) - 1][j];
                }
            }
            for (int j = 0; j < 4; j++) {
                round_keys[i][j] = round_keys[i - nk][j] ^ temp[j];
            }
        }
    }

    void sub_bytes(std::vector<std::vector<unsigned char>>& state) {
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                state[i][j] = S_BOX[state[i][j]];
            }
        }
    }

    void inv_sub_bytes(std::vector<std::vector<unsigned char>>& state) {
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                state[i][j] = INV_S_BOX[state[i][j]];
            }
        }
    }

    void shift_rows(std::vector<std::vector<unsigned char>>& state) {
        // Second row: shift left by one
        unsigned char temp = state[1][0];
        state[1][0] = state[1][1];
        state[1][1] = state[1][2];
        state[1][2] = state[1][3];
        state[1][3] = temp;

        // Third row: shift left by two
        std::swap(state[2][0], state[2][2]);
        std::swap(state[2][1], state[2][3]);

        // Fourth row: shift left by three
        temp = state[3][3];
        state[3][3] = state[3][2];
        state[3][2] = state[3][1];
        state[3][1] = state[3][0];
        state[3][0] = temp;
    }

    void inv_shift_rows(std::vector<std::vector<unsigned char>>& state) {
        // Second row: shift right by one
        unsigned char temp = state[1][3];
        state[1][3] = state[1][2];
        state[1][2] = state[1][1];
        state[1][1] = state[1][0];
        state[1][0] = temp;

        // Third row: shift right by two
        std::swap(state[2][0], state[2][2]);
        std::swap(state[2][1], state[2][3]);

        // Fourth row: shift right by three
        temp = state[3][0];
        state[3][0] = state[3][1];
        state[3][1] = state[3][2];
        state[3][2] = state[3][3];
        state[3][3] = temp;
    }

    void mix_columns(std::vector<std::vector<unsigned char>>& state) {
        for (int i = 0; i < 4; i++) {
            unsigned char s0 = state[0][i];
            unsigned char s1 = state[1][i];
            unsigned char s2 = state[2][i];
            unsigned char s3 = state[3][i];

            state[0][i] = gmul(0x02, s0) ^ gmul(0x03, s1) ^ s2 ^ s3;
            state[1][i] = s0 ^ gmul(0x02, s1) ^ gmul(0x03, s2) ^ s3;
            state[2][i] = s0 ^ s1 ^ gmul(0x02, s2) ^ gmul(0x03, s3);
            state[3][i] = gmul(0x03, s0) ^ s1 ^ s2 ^ gmul(0x02, s3);
        }
    }

    void inv_mix_columns(std::vector<std::vector<unsigned char>>& state) {
        for (int i = 0; i < 4; i++) {
            unsigned char s0 = state[0][i];
            unsigned char s1 = state[1][i];
            unsigned char s2 = state[2][i];
            unsigned char s3 = state[3][i];

            state[0][i] = gmul(0x0E, s0) ^ gmul(0x0B, s1) ^ gmul(0x0D, s2) ^ gmul(0x09, s3);
            state[1][i] = gmul(0x09, s0) ^ gmul(0x0E, s1) ^ gmul(0x0B, s2) ^ gmul(0x0D, s3);
            state[2][i] = gmul(0x0D, s0) ^ gmul(0x09, s1) ^ gmul(0x0E, s2) ^ gmul(0x0B, s3);
            state[3][i] = gmul(0x0B, s0) ^ gmul(0x0D, s1) ^ gmul(0x09, s2) ^ gmul(0x0E, s3);
        }
    }

    void add_round_key(std::vector<std::vector<unsigned char>>& state, int round) {
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                state[j][i] ^= round_keys[round * 4 + i][j];
            }
        }
    }

    std::vector<unsigned char> pkcs7_padding(const std::vector<unsigned char>& data) {
        int padding_length = 16 - (data.size() % 16);
        std::vector<unsigned char> padded_data = data;
        padded_data.insert(padded_data.end(), padding_length, padding_length);
        return padded_data;
    }

    std::vector<unsigned char> pkcs7_unpadding(const std::vector<unsigned char>& data) {
        int padding_length = data.back();
        return std::vector<unsigned char>(data.begin(), data.end() - padding_length);
    }

public:
    AES(const std::vector<unsigned char>& key_data) : key(key_data) {
        key_length = key.size() * 8;
        if (key_length != 128 && key_length != 192 && key_length != 256) {
            throw std::invalid_argument("Invalid key length. Must be 128, 192, or 256 bits.");
        }
        key_expansion();
    }

    std::vector<unsigned char> encrypt_block(const std::vector<unsigned char>& block) {
        std::vector<std::vector<unsigned char>> state(4, std::vector<unsigned char>(4));

        // Convert block to state matrix
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                state[j][i] = block[i * 4 + j];
            }
        }

        int nr = key_length / 32 + 6;  // Number of rounds

        // Initial round
        add_round_key(state, 0);

        // Main rounds
        for (int round = 1; round < nr; round++) {
            sub_bytes(state);
            shift_rows(state);
            mix_columns(state);
            add_round_key(state, round);
        }

        // Final round
        sub_bytes(state);
        shift_rows(state);
        add_round_key(state, nr);

        // Convert state matrix back to block
        std::vector<unsigned char> result(16);
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                result[i * 4 + j] = state[j][i];
            }
        }

        return result;
    }

    std::vector<unsigned char> decrypt_block(const std::vector<unsigned char>& block) {
        std::vector<std::vector<unsigned char>> state(4, std::vector<unsigned char>(4));

        // Convert block to state matrix
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                state[j][i] = block[i * 4 + j];
            }
        }

        int nr = key_length / 32 + 6;  // Number of rounds

        // Initial round
        add_round_key(state, nr);

        // Main rounds
        for (int round = nr - 1; round > 0; round--) {
            inv_shift_rows(state);
            inv_sub_bytes(state);
            add_round_key(state, round);
            inv_mix_columns(state);
        }

        // Final round
        inv_shift_rows(state);
        inv_sub_bytes(state);
        add_round_key(state, 0);

        // Convert state matrix back to block
        std::vector<unsigned char> result(16);
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                result[i * 4 + j] = state[j][i];
            }
        }

        return result;
    }

    std::vector<unsigned char> cbc_encrypt(const std::vector<unsigned char>& plaintext, const std::vector<unsigned char>& iv) {
        std::vector<unsigned char> padded_data = pkcs7_padding(plaintext);
        std::vector<unsigned char> ciphertext;
        std::vector<unsigned char> previous_block = iv;

        for (size_t i = 0; i < padded_data.size(); i += 16) {
            std::vector<unsigned char> block(padded_data.begin() + i, padded_data.begin() + i + 16);

            // XOR with previous block
            for (int j = 0; j < 16; j++) {
                block[j] ^= previous_block[j];
            }

            // Encrypt block
            std::vector<unsigned char> encrypted_block = encrypt_block(block);
            ciphertext.insert(ciphertext.end(), encrypted_block.begin(), encrypted_block.end());
            previous_block = encrypted_block;
        }

        return ciphertext;
    }

    std::vector<unsigned char> cbc_decrypt(const std::vector<unsigned char>& ciphertext, const std::vector<unsigned char>& iv) {
        std::vector<unsigned char> plaintext;
        std::vector<unsigned char> previous_block = iv;

        for (size_t i = 0; i < ciphertext.size(); i += 16) {
            std::vector<unsigned char> block(ciphertext.begin() + i, ciphertext.begin() + i + 16);

            // Decrypt block
            std::vector<unsigned char> decrypted_block = decrypt_block(block);

            // XOR with previous block
            for (int j = 0; j < 16; j++) {
                decrypted_block[j] ^= previous_block[j];
            }

            plaintext.insert(plaintext.end(), decrypted_block.begin(), decrypted_block.end());
            previous_block = block;
        }

        return pkcs7_unpadding(plaintext);
    }
};
// Helper function to convert string to hex
std::string bytes_to_hex(const std::vector<unsigned char>& data) {
    std::stringstream ss;
    ss << std::hex << std::setfill('0');
    for (unsigned char byte : data) {
        ss << std::setw(2) << static_cast<int>(byte);
    }
    return ss.str();
}

// Helper function to convert hex to bytes
std::vector<unsigned char> hex_to_bytes(const std::string& hex) {
    std::vector<unsigned char> bytes;
    std::string clean_hex;
    
    // Remove whitespace manually
    for (char c : hex) {
        if (!isspace(c)) {
            clean_hex += c;
        }
    }
    
    // Check if the string length is even
    if (clean_hex.length() % 2 != 0) {
        throw std::invalid_argument("Invalid hex string length");
    }

    for (size_t i = 0; i < clean_hex.length(); i += 2) {
        std::string byteString = clean_hex.substr(i, 2);
        try {
            unsigned char byte = static_cast<unsigned char>(std::stoi(byteString, nullptr, 16));
            bytes.push_back(byte);
        } catch (const std::exception& e) {
            throw std::invalid_argument("Invalid hex character in string");
        }
    }
    return bytes;
}

void print_usage() {
    std::cout << "Usage: aes_cli.exe [options]\n"
              << "Options:\n"
              << "  -e, --encrypt    Encrypt mode\n"
              << "  -d, --decrypt    Decrypt mode\n"
              << "  -k, --key KEY    Encryption key (hex string)\n"
              << "  -i, --iv IV      Initialization vector (hex string)\n"
              << "  -f, --file FILE  Input file\n"
              << "  -o, --out FILE   Output file\n"
              << "  -h, --help       Show this help message\n";
}

// Benchmark function for AES encryption/decryption
void benchmark_aes(const std::vector<unsigned char>& key, const std::vector<unsigned char>& iv, size_t size_kb, bool encrypt_mode, int iterations = 10000) {
    size_t size_bytes = size_kb * 1024;
    std::vector<unsigned char> input_data(size_bytes, 0x41); // Fill with 'A'
    AES aes(key);
    std::vector<unsigned char> output_data;
    std::string mode = encrypt_mode ? "encrypt" : "decrypt";

    // For decryption, first encrypt once to get valid ciphertext
    if (!encrypt_mode) {
        output_data = aes.cbc_encrypt(input_data, iv);
        input_data = output_data;
    }

    auto start = std::chrono::high_resolution_clock::now();
    for (int i = 0; i < iterations; ++i) {
        if (encrypt_mode) {
            output_data = aes.cbc_encrypt(input_data, iv);
        } else {
            output_data = aes.cbc_decrypt(input_data, iv);
        }
    }
    auto end = std::chrono::high_resolution_clock::now();
    double avg_ms = std::chrono::duration<double, std::milli>(end - start).count() / iterations;
    std::cout << "[" << mode << "] Input size: " << size_kb << "KB, average of " << iterations << " iterations is: " << avg_ms << " ms" << std::endl;
}

int main(int argc, char* argv[]) {
    // Set console to UTF-8 mode for Vietnamese support
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);

    // Benchmark mode
    if (argc == 2 && std::string(argv[1]) == "--benchmark") {
        // Example 128-bit key and IV (all zeros)
        std::vector<unsigned char> key(16, 0x00);
        std::vector<unsigned char> iv(16, 0x00);
        std::vector<size_t> sizes_kb = {1, 30, 50, 100, 500, 1024}; 
        for (size_t sz : sizes_kb) {
            benchmark_aes(key, iv, sz, true);  // Encrypt
            benchmark_aes(key, iv, sz, false); // Decrypt
        }
        return 0;
    }

    if (argc < 2) {
        print_usage();
        return 1;
    }

    bool encrypt_mode = false;
    bool decrypt_mode = false;
    std::string key_str;
    std::string iv_str;
    std::string input_file;
    std::string output_file;

    // Parse command line arguments
    for (int i = 1; i < argc; i++) {
        std::string arg = argv[i];
        if (arg == "-e" || arg == "--encrypt") {
            encrypt_mode = true;
        }
        else if (arg == "-d" || arg == "--decrypt") {
            decrypt_mode = true;
        }
        else if (arg == "-k" || arg == "--key") {
            if (i + 1 < argc) key_str = argv[++i];
        }
        else if (arg == "-i" || arg == "--iv") {
            if (i + 1 < argc) iv_str = argv[++i];
        }
        else if (arg == "-f" || arg == "--file") {
            if (i + 1 < argc) input_file = argv[++i];
        }
        else if (arg == "-o" || arg == "--out") {
            if (i + 1 < argc) output_file = argv[++i];
        }
        else if (arg == "-h" || arg == "--help") {
            print_usage();
            return 0;
        }
    }

    // Validate arguments
    if (!encrypt_mode && !decrypt_mode) {
        std::cerr << "Error: Must specify either encrypt or decrypt mode\n";
        return 1;
    }
    if (key_str.empty()) {
        std::cerr << "Error: Key is required\n";
        return 1;
    }
    if (iv_str.empty()) {
        std::cerr << "Error: IV is required\n";
        return 1;
    }
    if (input_file.empty()) {
        std::cerr << "Error: Input file is required\n";
        return 1;
    }
    if (output_file.empty()) {
        std::cerr << "Error: Output file is required\n";
        return 1;
    }

    try {
        // Convert key and IV to bytes
        std::cout << "Reading key from: " << key_str << std::endl;
        std::vector<unsigned char> key = hex_to_bytes(key_str);
        std::cout << "Key length: " << key.size() << " bytes" << std::endl;
        
        std::cout << "Reading IV from: " << iv_str << std::endl;
        std::vector<unsigned char> iv = hex_to_bytes(iv_str);
        std::cout << "IV length: " << iv.size() << " bytes" << std::endl;

        // Read input file
        std::ifstream in_file(input_file, std::ios::binary);
        if (!in_file) {
            std::cerr << "Error: Cannot open input file\n";
            return 1;
        }
        std::vector<unsigned char> input_data(
            (std::istreambuf_iterator<char>(in_file)),
            std::istreambuf_iterator<char>()
        );
        in_file.close();

        // Create AES instance
        AES aes(key);

        // Process data
        std::vector<unsigned char> output_data;
        if (encrypt_mode) {
            output_data = aes.cbc_encrypt(input_data, iv);
        }
        else {
            output_data = aes.cbc_decrypt(input_data, iv);
        }

        // Write output file
        std::ofstream out_file(output_file, std::ios::binary);
        if (!out_file) {
            std::cerr << "Error: Cannot open output file\n";
            return 1;
        }
        out_file.write(reinterpret_cast<const char*>(output_data.data()), output_data.size());
        out_file.close();

        // Print result
        if (encrypt_mode) {
            std::cout << "Encryption successful\n";
            std::cout << "Ciphertext (hex): " << bytes_to_hex(output_data) << std::endl;
        }
        else {
            std::cout << "Decryption successful\n";
            std::string decrypted_text(output_data.begin(), output_data.end());
            std::cout << "Decrypted text: " << decrypted_text << std::endl;
        }

    }
    catch (const std::exception& e) {
        std::cerr << "Error: " << e.what() << std::endl;
        return 1;
    }

    return 0;
} 