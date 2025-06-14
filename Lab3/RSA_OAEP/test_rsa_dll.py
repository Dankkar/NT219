import ctypes
import os
import sys

def load_rsa_dll():
    """Load the RSA DLL"""
    dll_files = [
        "rsa_dll_msvc.dll",
        "rsa_dll_gcc.dll", 
        "rsa_dll_clang.dll"
    ]
    
    for dll_file in dll_files:
        if os.path.exists(dll_file):
            try:
                print(f"Loading {dll_file}...")
                # Try with absolute path
                abs_path = os.path.abspath(dll_file)
                print(f"Absolute path: {abs_path}")
                
                # Add current directory to PATH for dependency loading
                current_dir = os.path.dirname(abs_path)
                if current_dir not in os.environ.get("PATH", ""):
                    os.environ["PATH"] = current_dir + ";" + os.environ.get("PATH", "")
                    print(f"Added to PATH: {current_dir}")
                
                dll = ctypes.CDLL(abs_path)
                print(f"Successfully loaded {dll_file}")
                return dll
            except Exception as e:
                print(f"Failed to load {dll_file}: {e}")
                print(f"Error type: {type(e).__name__}")
                
                # Try WinDLL as alternative
                try:
                    print(f"Trying WinDLL for {dll_file}...")
                    dll = ctypes.WinDLL(abs_path)
                    print(f"Successfully loaded {dll_file} with WinDLL")
                    return dll
                except Exception as e2:
                    print(f"WinDLL also failed: {e2}")
                continue
    
    print("Error: No RSA DLL found or could not be loaded!")
    print("Available DLL files should be one of:", dll_files)
    print("Make sure all dependencies are available.")
    return None

def setup_dll_functions(dll):
    """Setup function signatures for the DLL"""
    # Basic functions (backward compatibility)
    dll.generateRSAKeys.argtypes = [ctypes.c_char_p, ctypes.c_char_p, ctypes.c_int]
    dll.generateRSAKeys.restype = ctypes.c_int
    
    dll.encryptFile.argtypes = [ctypes.c_char_p, ctypes.c_char_p, ctypes.c_char_p]
    dll.encryptFile.restype = ctypes.c_int
    
    dll.decryptFile.argtypes = [ctypes.c_char_p, ctypes.c_char_p, ctypes.c_char_p]
    dll.decryptFile.restype = ctypes.c_int
    
    dll.encryptString.argtypes = [ctypes.c_char_p, ctypes.c_char_p]
    dll.encryptString.restype = ctypes.c_char_p
    
    dll.decryptString.argtypes = [ctypes.c_char_p, ctypes.c_char_p]
    dll.decryptString.restype = ctypes.c_char_p
    
    # Extended functions with format support
    dll.generateRSAKeysWithFormat.argtypes = [ctypes.c_char_p, ctypes.c_char_p, ctypes.c_int, ctypes.c_int]
    dll.generateRSAKeysWithFormat.restype = ctypes.c_int
    
    dll.encryptFileWithFormat.argtypes = [ctypes.c_char_p, ctypes.c_char_p, ctypes.c_char_p, ctypes.c_int]
    dll.encryptFileWithFormat.restype = ctypes.c_int
    
    dll.decryptFileWithFormat.argtypes = [ctypes.c_char_p, ctypes.c_char_p, ctypes.c_char_p, ctypes.c_int]
    dll.decryptFileWithFormat.restype = ctypes.c_int
    
    dll.encryptStringWithFormat.argtypes = [ctypes.c_char_p, ctypes.c_char_p, ctypes.c_int]
    dll.encryptStringWithFormat.restype = ctypes.c_char_p
    
    dll.decryptStringWithFormat.argtypes = [ctypes.c_char_p, ctypes.c_char_p, ctypes.c_int]
    dll.decryptStringWithFormat.restype = ctypes.c_char_p
    
    # Utility functions
    dll.getLastError.argtypes = []
    dll.getLastError.restype = ctypes.c_char_p

def test_key_generation(dll):
    """Test RSA key generation"""
    print("\n=== Testing Key Generation ===")
    
    key_size = 2048  # Smaller key size for faster testing
    
    # Test different formats
    formats = [
        (0, "PEM", "test_public.pem", "test_private.pem"),
        (1, "DER", "test_public.der", "test_private.der"),
        (2, "BASE64", "test_public.b64", "test_private.b64")
    ]
    
    for format_id, format_name, pub_file, priv_file in formats:
        print(f"\nTesting {format_name} format...")
        
        result = dll.generateRSAKeysWithFormat(
            pub_file.encode(), 
            priv_file.encode(), 
            key_size, 
            format_id
        )
        
        if result == 1:
            print(f"✅ {format_name} key generation successful!")
            print(f"Public key: {pub_file}")
            print(f"Private key: {priv_file}")
        else:
            error = dll.getLastError()
            print(f"❌ {format_name} key generation failed: {error.decode() if error else 'Unknown error'}")
            return False
    
    return True

def test_string_encryption(dll):
    """Test string encryption and decryption with different formats"""
    print("\n=== Testing String Encryption with Different Formats ===")
    
    # Test with different formats
    formats = [
        (0, "PEM", "test_public.pem", "test_private.pem"),
        (1, "DER", "test_public.der", "test_private.der"),
        (2, "BASE64", "test_public.b64", "test_private.b64")
    ]
    
    test_string = "Hello from RSA encryption with format support!"
    
    for format_id, format_name, pub_file, priv_file in formats:
        print(f"\n--- Testing {format_name} format ---")
        print(f"Original: {test_string}")
        
        # Encrypt with format
        ciphertext_ptr = dll.encryptStringWithFormat(
            pub_file.encode(), 
            test_string.encode(), 
            format_id
        )
        if not ciphertext_ptr:
            error = dll.getLastError()
            print(f"❌ {format_name} encryption failed: {error.decode() if error else 'Unknown error'}")
            continue
            
        ciphertext = ciphertext_ptr.decode()
        print(f"Encrypted length: {len(ciphertext)} characters")
        print(f"Ciphertext (first 100 chars): {ciphertext[:100]}...")
        
        # Decrypt with format
        decrypted_ptr = dll.decryptStringWithFormat(
            priv_file.encode(), 
            ciphertext.encode(), 
            format_id
        )
        if not decrypted_ptr:
            error = dll.getLastError()
            print(f"❌ {format_name} decryption failed: {error.decode() if error else 'Unknown error'}")
            continue
            
        decrypted = decrypted_ptr.decode()
        
        if decrypted == test_string:
            print(f"✅ {format_name} encryption/decryption successful!")
        else:
            print(f"❌ {format_name} decryption result doesn't match original!")
            print(f"Expected: {test_string}")
            print(f"Got: {decrypted}")
    
    # Test hybrid encryption with PEM format
    print(f"\n--- Testing Hybrid Encryption (Large Data) ---")
    large_string = "A" * 1000  # Large string to trigger hybrid encryption
    print(f"Testing large string of {len(large_string)} characters...")
    
    ciphertext_ptr = dll.encryptStringWithFormat(
        b"test_public.pem", 
        large_string.encode(), 
        0  # PEM format
    )
    if ciphertext_ptr:
        ciphertext = ciphertext_ptr.decode()
        print(f"Large data encrypted successfully ({len(ciphertext)} chars)")
        
        decrypted_ptr = dll.decryptStringWithFormat(
            b"test_private.pem", 
            ciphertext.encode(), 
            0  # PEM format
        )
        if decrypted_ptr:
            decrypted = decrypted_ptr.decode()
            if decrypted == large_string:
                print("✅ Hybrid encryption/decryption successful!")
            else:
                print("❌ Hybrid decryption failed!")
        else:
            print("❌ Hybrid decryption failed!")
    else:
        print("❌ Hybrid encryption failed!")

def test_file_encryption(dll):
    """Test file encryption and decryption"""
    print("\n=== Testing File Encryption ===")
    
    public_key_file = b"test_public.pem"
    private_key_file = b"test_private.pem"
    
    # Create test files with different sizes
    test_files = [
        ("test_small.txt", "Hello from file encryption!"),
        ("test_medium.txt", "A" * 1000),  # 1KB file
        ("test_large.txt", "B" * 5000)    # 5KB file
    ]
    
    for filename, content in test_files:
        print(f"\nTesting file: {filename} ({len(content)} bytes)")
        
        # Create test file
        with open(filename, 'w') as f:
            f.write(content)
        
        # Encrypt file
        encrypted_file = f"encrypted_{filename}.bin"
        result = dll.encryptFile(public_key_file, filename.encode(), encrypted_file.encode())
        
        if result != 1:
            error = dll.getLastError()
            print(f"❌ File encryption failed: {error.decode() if error else 'Unknown error'}")
            continue
        
        print(f"✅ File encrypted successfully: {encrypted_file}")
        
        # Decrypt file
        decrypted_file = f"decrypted_{filename}"
        result = dll.decryptFile(private_key_file, encrypted_file.encode(), decrypted_file.encode())
        
        if result != 1:
            error = dll.getLastError()
            print(f"❌ File decryption failed: {error.decode() if error else 'Unknown error'}")
            continue
        
        # Verify content
        with open(decrypted_file, 'r') as f:
            decrypted_content = f.read()
        
        if decrypted_content == content:
            print(f"✅ File decryption successful: {decrypted_file}")
        else:
            print("❌ Decrypted file content doesn't match original!")
        
        # Cleanup test files
        try:
            os.remove(filename)
            os.remove(encrypted_file)
            os.remove(decrypted_file)
        except:
            pass

def cleanup_test_files():
    """Clean up test files"""
    test_files = [
        # Key files (different formats)
        "test_public.pem", "test_private.pem",
        "test_public.der", "test_private.der", 
        "test_public.b64", "test_private.b64",
        # Test data files
        "test_small.txt", "test_medium.txt", "test_large.txt",
        # Encrypted files
        "encrypted_test_small.txt.bin",
        "encrypted_test_medium.txt.bin",
        "encrypted_test_large.txt.bin",
        # Decrypted files
        "decrypted_test_small.txt",
        "decrypted_test_medium.txt",
        "decrypted_test_large.txt"
    ]
    
    for filename in test_files:
        try:
            if os.path.exists(filename):
                os.remove(filename)
        except:
            pass

def main():
    """Main test function"""
    print("RSA DLL Test Script")
    print("==================")
    
    # Load DLL
    dll = load_rsa_dll()
    if not dll:
        return 1
    
    # Setup function signatures
    setup_dll_functions(dll)
    
    try:
        # Test key generation
        if not test_key_generation(dll):
            print("Key generation failed, stopping tests.")
            return 1
        
        # Test string encryption
        test_string_encryption(dll)
        
        # Test file encryption
        test_file_encryption(dll)
        
        print("\n=== All Tests Completed ===")
        
    except Exception as e:
        print(f"Error during testing: {e}")
        return 1
    
    finally:
        # Cleanup
        print("\nCleaning up test files...")
        cleanup_test_files()
    
    return 0

if __name__ == "__main__":
    sys.exit(main()) 