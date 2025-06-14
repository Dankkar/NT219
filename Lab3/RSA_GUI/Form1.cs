using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace RSA_GUI
{
    public partial class Form1 : Form
    {
        // Import RSA DLL functions
        [DllImport("rsa_dll_gcc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int generateRSAKeysWithFormat(string publicKeyFile, string privateKeyFile, int keySize, int keyFormat);

        [DllImport("rsa_dll_gcc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr getLastError();

        // Encryption functions with byte arrays for proper UTF-8 support
        [DllImport("rsa_dll_gcc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr encryptStringWithFormat(byte[] publicKeyFile, byte[] plaintext, int keyFormat);

        [DllImport("rsa_dll_gcc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int encryptFileWithFormat(byte[] publicKeyFile, byte[] inputFile, byte[] outputFile, int keyFormat);

        // Decryption functions with byte arrays for proper UTF-8 support
        [DllImport("rsa_dll_gcc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr decryptStringWithFormat(byte[] privateKeyFile, byte[] ciphertext, int keyFormat);

        [DllImport("rsa_dll_gcc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int decryptFileWithFormat(byte[] privateKeyFile, byte[] inputFile, byte[] outputFile, int keyFormat);

        // Key format constants
        private const int KEY_FORMAT_PEM = 0;
        private const int KEY_FORMAT_DER = 1;
        private const int KEY_FORMAT_BASE64 = 2;

        public Form1()
        {
            InitializeComponent();
            
            // Set default values for KeyGen tab
            textBox1.Text = "2048"; // Default key size
            comboBox1.SelectedIndex = 0; // Default to PEM format
            
            // Set default file paths
            KeyGen_PubKeyPath.Text = "public_key.pem";
            KeyGen_PrivKeyPath.Text = "private_key.pem";

            // Set default values for Encrypt tab
            comboBox2.SelectedIndex = 0; // Default to PEM format
            comboBox3.SelectedIndex = 1; // Default to BASE64 output format
            Encrypt_PubKeyPath.Text = "public_key.pem";

            // Set default values for Decrypt tab
            comboBox4.SelectedIndex = 0; // Default to PEM format
            comboBox5.SelectedIndex = 1; // Default to BASE64 input format
            Decrypt_PrivateKeyPath.Text = "private_key.pem";
        }

        #region KeyGen Tab Event Handlers

        private void KeyGen_PubKeybtn_Click(object sender, EventArgs e)
        {
            // Browse for public key save location
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Select Public Key Save Location";
            
            // Set filter based on selected format
            string format = comboBox1.SelectedItem?.ToString() ?? "PEM";
            switch (format.ToUpper())
            {
                case "PEM":
                    saveDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*";
                    saveDialog.DefaultExt = "pem";
                    break;
                case "DER":
                    saveDialog.Filter = "DER files (*.der)|*.der|All files (*.*)|*.*";
                    saveDialog.DefaultExt = "der";
                    break;
                case "BASE64":
                    saveDialog.Filter = "Base64 files (*.b64)|*.b64|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveDialog.DefaultExt = "b64";
                    break;
                default:
                    saveDialog.Filter = "All files (*.*)|*.*";
                    break;
            }
            
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                KeyGen_PubKeyPath.Text = saveDialog.FileName;
            }
        }

        private void KeyGen_PrivKeybtn_Click(object sender, EventArgs e)
        {
            // Browse for private key save location
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Select Private Key Save Location";
            
            // Set filter based on selected format
            string format = comboBox1.SelectedItem?.ToString() ?? "PEM";
            switch (format.ToUpper())
            {
                case "PEM":
                    saveDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*";
                    saveDialog.DefaultExt = "pem";
                    break;
                case "DER":
                    saveDialog.Filter = "DER files (*.der)|*.der|All files (*.*)|*.*";
                    saveDialog.DefaultExt = "der";
                    break;
                case "BASE64":
                    saveDialog.Filter = "Base64 files (*.b64)|*.b64|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveDialog.DefaultExt = "b64";
                    break;
                default:
                    saveDialog.Filter = "All files (*.*)|*.*";
                    break;
            }
            
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                KeyGen_PrivKeyPath.Text = saveDialog.FileName;
            }
        }

        private void KeyGenbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Please enter a key size.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(textBox1.Text, out int keySize) || keySize < 1024)
                {
                    MessageBox.Show("Please enter a valid key size (minimum 1024 bits).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(KeyGen_PubKeyPath.Text))
                {
                    MessageBox.Show("Please specify a public key file path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(KeyGen_PrivKeyPath.Text))
                {
                    MessageBox.Show("Please specify a private key file path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get selected format
                string format = comboBox1.SelectedItem?.ToString() ?? "PEM";
                int keyFormat;
                switch (format.ToUpper())
                {
                    case "PEM":
                        keyFormat = KEY_FORMAT_PEM;
                        break;
                    case "DER":
                        keyFormat = KEY_FORMAT_DER;
                        break;
                    case "BASE64":
                        keyFormat = KEY_FORMAT_BASE64;
                        break;
                    default:
                        keyFormat = KEY_FORMAT_PEM;
                        break;
                }

                // Show progress
                this.Cursor = Cursors.WaitCursor;
                KeyGenbtn.Enabled = false;
                KeyGenbtn.Text = "Generating...";
                Application.DoEvents();

                // Generate keys using DLL
                int result = generateRSAKeysWithFormat(
                    KeyGen_PubKeyPath.Text,
                    KeyGen_PrivKeyPath.Text,
                    keySize,
                    keyFormat
                );

                if (result == 1)
                {
                    MessageBox.Show(
                        $"RSA keys generated successfully!\n\n" +
                        $"Key Size: {keySize} bits\n" +
                        $"Format: {format}\n" +
                        $"Public Key: {KeyGen_PubKeyPath.Text}\n" +
                        $"Private Key: {KeyGen_PrivKeyPath.Text}",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    // Get error message from DLL
                    IntPtr errorPtr = getLastError();
                    string errorMessage = "Unknown error";
                    if (errorPtr != IntPtr.Zero)
                    {
                        errorMessage = PtrToStringAnsi(errorPtr);
                    }

                    MessageBox.Show(
                        $"Failed to generate RSA keys.\n\nError: {errorMessage}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                // Restore UI
                this.Cursor = Cursors.Default;
                KeyGenbtn.Enabled = true;
                KeyGenbtn.Text = "Generate Keys";
            }
        }

        // Update file extension when format changes
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string format = comboBox1.SelectedItem?.ToString() ?? "PEM";
            string extension;
            
            switch (format.ToUpper())
            {
                case "PEM":
                    extension = ".pem";
                    break;
                case "DER":
                    extension = ".der";
                    break;
                case "BASE64":
                    extension = ".b64";
                    break;
                default:
                    extension = ".pem";
                    break;
            }

            // Update file paths with new extension if they have default names
            if (KeyGen_PubKeyPath.Text.StartsWith("public_key."))
            {
                KeyGen_PubKeyPath.Text = "public_key" + extension;
            }
            
            if (KeyGen_PrivKeyPath.Text.StartsWith("private_key."))
            {
                KeyGen_PrivKeyPath.Text = "private_key" + extension;
            }
        }

        #endregion

        #region Encrypt Tab Event Handlers

        private void Encrypt_PubKeybtn_Click(object sender, EventArgs e)
        {
            // Browse for public key file to load
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select Public Key File";
            
            // Set filter based on selected format
            string format = comboBox2.SelectedItem?.ToString() ?? "PEM";
            switch (format.ToUpper())
            {
                case "PEM":
                    openDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*";
                    break;
                case "DER":
                    openDialog.Filter = "DER files (*.der)|*.der|All files (*.*)|*.*";
                    break;
                case "BASE64":
                    openDialog.Filter = "Base64 files (*.b64)|*.b64|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    break;
                default:
                    openDialog.Filter = "All files (*.*)|*.*";
                    break;
            }
            
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Encrypt_PubKeyPath.Text = openDialog.FileName;
            }
        }

        private void Encrypt_Plaintext_Click(object sender, EventArgs e)
        {
            // Browse for plaintext file to load
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select Plaintext File";
            openDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Read file content and display in RichTextBox
                    string content = File.ReadAllText(openDialog.FileName, Encoding.UTF8);
                    Encrypt_Plaintextrtb.Text = content;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Failed to read file: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void Encrypt_Ciphertext_Click(object sender, EventArgs e)
        {
            // Save ciphertext to file
            if (string.IsNullOrWhiteSpace(Encrypt_Ciphertextrtb.Text))
            {
                MessageBox.Show("No ciphertext to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save Ciphertext to File";
            
            // Set filter based on output format
            string outputFormat = comboBox3.SelectedItem?.ToString() ?? "BASE64";
            switch (outputFormat.ToUpper())
            {
                case "HEX":
                    saveDialog.Filter = "Hex files (*.hex)|*.hex|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveDialog.DefaultExt = "hex";
                    break;
                case "BASE64":
                    saveDialog.Filter = "Base64 files (*.b64)|*.b64|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveDialog.DefaultExt = "b64";
                    break;
                default:
                    saveDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveDialog.DefaultExt = "txt";
                    break;
            }
            
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveDialog.FileName, Encrypt_Ciphertextrtb.Text, Encoding.UTF8);
                    MessageBox.Show(
                        $"Ciphertext saved successfully to:\n{saveDialog.FileName}",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Failed to save file: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(Encrypt_PubKeyPath.Text))
                {
                    MessageBox.Show("Please select a public key file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(Encrypt_PubKeyPath.Text))
                {
                    MessageBox.Show($"Public key file does not exist:\n{Encrypt_PubKeyPath.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(Encrypt_Plaintextrtb.Text))
                {
                    MessageBox.Show("Please enter text to encrypt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get key format
                string keyFormat = comboBox2.SelectedItem?.ToString() ?? "PEM";
                int keyFormatInt;
                switch (keyFormat.ToUpper())
                {
                    case "PEM":
                        keyFormatInt = KEY_FORMAT_PEM;
                        break;
                    case "DER":
                        keyFormatInt = KEY_FORMAT_DER;
                        break;
                    case "BASE64":
                        keyFormatInt = KEY_FORMAT_BASE64;
                        break;
                    default:
                        keyFormatInt = KEY_FORMAT_PEM;
                        break;
                }

                // Show progress
                this.Cursor = Cursors.WaitCursor;
                Encrypt.Enabled = false;
                Encrypt.Text = "Encrypting...";
                Application.DoEvents();

                // Debug info
                string debugInfo = $"Debug Info:\n" +
                                 $"Key File: {Encrypt_PubKeyPath.Text}\n" +
                                 $"Key Format: {keyFormat} ({keyFormatInt})\n" +
                                 $"Plaintext Length: {Encrypt_Plaintextrtb.Text.Length} chars\n" +
                                 $"File Exists: {File.Exists(Encrypt_PubKeyPath.Text)}\n" +
                                 $"Working Directory: {Directory.GetCurrentDirectory()}";

                // Encrypt using DLL with UTF-8 byte arrays
                byte[] pubKeyPathBytes = StringToUTF8Bytes(Encrypt_PubKeyPath.Text);
                byte[] plaintextBytes = StringToUTF8Bytes(Encrypt_Plaintextrtb.Text);
                
                IntPtr resultPtr = encryptStringWithFormat(
                    pubKeyPathBytes,
                    plaintextBytes,
                    keyFormatInt
                );

                if (resultPtr != IntPtr.Zero)
                {
                    // Get encrypted text from DLL
                    string encryptedText = PtrToStringUTF8(resultPtr);
                    
                    if (!string.IsNullOrEmpty(encryptedText))
                    {
                        // Get output format
                        string outputFormat = comboBox3.SelectedItem?.ToString() ?? "BASE64";
                        string displayText = encryptedText;
                        
                        // Convert to HEX if needed
                        if (outputFormat.ToUpper() == "HEX")
                        {
                            try
                            {
                                // Assume encryptedText is BASE64, convert to bytes then to HEX
                                byte[] bytes = Convert.FromBase64String(encryptedText);
                                displayText = BitConverter.ToString(bytes).Replace("-", "");
                            }
                            catch (Exception hexEx)
                            {
                                // If conversion fails, show error but keep original BASE64
                                MessageBox.Show(
                                    $"Warning: Could not convert to HEX format: {hexEx.Message}\n\nShowing BASE64 format instead.",
                                    "Format Conversion Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                                displayText = encryptedText;
                                outputFormat = "BASE64";
                            }
                        }
                        
                        Encrypt_Ciphertextrtb.Text = displayText;
                        
                        MessageBox.Show(
                            $"Text encrypted successfully!\n\n" +
                            $"Key Format: {keyFormat}\n" +
                            $"Output Format: {outputFormat}\n" +
                            $"Plaintext Length: {Encrypt_Plaintextrtb.Text.Length} characters\n" +
                            $"Ciphertext Length: {displayText.Length} characters",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            "Encryption returned empty result.\n\n" + debugInfo,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                else
                {
                    // Get error message from DLL
                    IntPtr errorPtr = getLastError();
                    string errorMessage = "Unknown error";
                    if (errorPtr != IntPtr.Zero)
                    {
                        errorMessage = PtrToStringAnsi(errorPtr);
                    }
                    
                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        errorMessage = "DLL returned null pointer (function failed)";
                    }

                    // Show detailed error with debug info
                    MessageBox.Show(
                        $"Failed to encrypt text.\n\n" +
                        $"Error: {errorMessage}\n\n" +
                        debugInfo,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An exception occurred: {ex.Message}\n\n" +
                    $"Stack Trace:\n{ex.StackTrace}",
                    "Exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                // Restore UI
                this.Cursor = Cursors.Default;
                Encrypt.Enabled = true;
                Encrypt.Text = "Encrypt";
            }
        }

        #endregion

        #region Decrypt Tab Event Handlers

        private void Decrypt_PrivateKeybtn_Click(object sender, EventArgs e)
        {
            // Browse for private key file to load
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select Private Key File";
            
            // Set filter based on selected format
            string format = comboBox4.SelectedItem?.ToString() ?? "PEM";
            switch (format.ToUpper())
            {
                case "PEM":
                    openDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*";
                    break;
                case "DER":
                    openDialog.Filter = "DER files (*.der)|*.der|All files (*.*)|*.*";
                    break;
                case "BASE64":
                    openDialog.Filter = "Base64 files (*.b64)|*.b64|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    break;
                default:
                    openDialog.Filter = "All files (*.*)|*.*";
                    break;
            }
            
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Decrypt_PrivateKeyPath.Text = openDialog.FileName;
            }
        }

        private void Decrypt_Ciphertext_Click(object sender, EventArgs e)
        {
            // Browse for ciphertext file to load
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select Ciphertext File";
            
            // Set filter based on input format
            string inputFormat = comboBox5.SelectedItem?.ToString() ?? "BASE64";
            switch (inputFormat.ToUpper())
            {
                case "HEX":
                    openDialog.Filter = "Hex files (*.hex)|*.hex|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    break;
                case "BASE64":
                    openDialog.Filter = "Base64 files (*.b64)|*.b64|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    break;
                default:
                    openDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    break;
            }
            
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Read file content and display in RichTextBox
                    string content = File.ReadAllText(openDialog.FileName, Encoding.UTF8);
                    Decrypt_Ciphertextrtb.Text = content;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Failed to read file: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void Decrypt_Plaintext_Click(object sender, EventArgs e)
        {
            // Save plaintext to file
            if (string.IsNullOrWhiteSpace(Decrypt_Plaintextrtb.Text))
            {
                MessageBox.Show("No plaintext to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save Plaintext to File";
            saveDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveDialog.DefaultExt = "txt";
            
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveDialog.FileName, Decrypt_Plaintextrtb.Text, Encoding.UTF8);
                    MessageBox.Show(
                        $"Plaintext saved successfully to:\n{saveDialog.FileName}",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Failed to save file: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(Decrypt_PrivateKeyPath.Text))
                {
                    MessageBox.Show("Please select a private key file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(Decrypt_PrivateKeyPath.Text))
                {
                    MessageBox.Show($"Private key file does not exist:\n{Decrypt_PrivateKeyPath.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(Decrypt_Ciphertextrtb.Text))
                {
                    MessageBox.Show("Please enter ciphertext to decrypt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get key format
                string keyFormat = comboBox4.SelectedItem?.ToString() ?? "PEM";
                int keyFormatInt;
                switch (keyFormat.ToUpper())
                {
                    case "PEM":
                        keyFormatInt = KEY_FORMAT_PEM;
                        break;
                    case "DER":
                        keyFormatInt = KEY_FORMAT_DER;
                        break;
                    case "BASE64":
                        keyFormatInt = KEY_FORMAT_BASE64;
                        break;
                    default:
                        keyFormatInt = KEY_FORMAT_PEM;
                        break;
                }

                // Get input format and prepare ciphertext
                string inputFormat = comboBox5.SelectedItem?.ToString() ?? "BASE64";
                string ciphertextForDLL = Decrypt_Ciphertextrtb.Text.Trim();

                // Convert HEX to BASE64 if needed (DLL expects BASE64)
                if (inputFormat.ToUpper() == "HEX")
                {
                    try
                    {
                        // Convert HEX to bytes then to BASE64
                        byte[] bytes = new byte[ciphertextForDLL.Length / 2];
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            bytes[i] = Convert.ToByte(ciphertextForDLL.Substring(i * 2, 2), 16);
                        }
                        ciphertextForDLL = Convert.ToBase64String(bytes);
                    }
                    catch (Exception hexEx)
                    {
                        MessageBox.Show(
                            $"Failed to convert HEX format to BASE64: {hexEx.Message}",
                            "Format Conversion Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return;
                    }
                }

                // Show progress
                this.Cursor = Cursors.WaitCursor;
                Decrypt.Enabled = false;
                Decrypt.Text = "Decrypting...";
                Application.DoEvents();

                // Debug info
                string debugInfo = $"Debug Info:\n" +
                                 $"Key File: {Decrypt_PrivateKeyPath.Text}\n" +
                                 $"Key Format: {keyFormat} ({keyFormatInt})\n" +
                                 $"Input Format: {inputFormat}\n" +
                                 $"Ciphertext Length: {Decrypt_Ciphertextrtb.Text.Length} chars\n" +
                                 $"File Exists: {File.Exists(Decrypt_PrivateKeyPath.Text)}\n" +
                                 $"Working Directory: {Directory.GetCurrentDirectory()}";

                // Decrypt using DLL with UTF-8 byte arrays
                byte[] privKeyPathBytes = StringToUTF8Bytes(Decrypt_PrivateKeyPath.Text);
                byte[] ciphertextBytes = StringToUTF8Bytes(ciphertextForDLL);
                
                IntPtr resultPtr = decryptStringWithFormat(
                    privKeyPathBytes,
                    ciphertextBytes,
                    keyFormatInt
                );

                if (resultPtr != IntPtr.Zero)
                {
                    // Get decrypted text from DLL
                    string decryptedText = PtrToStringUTF8(resultPtr);
                    
                    if (!string.IsNullOrEmpty(decryptedText))
                    {
                        Decrypt_Plaintextrtb.Text = decryptedText;
                        
                        MessageBox.Show(
                            $"Text decrypted successfully!\n\n" +
                            $"Key Format: {keyFormat}\n" +
                            $"Input Format: {inputFormat}\n" +
                            $"Ciphertext Length: {Decrypt_Ciphertextrtb.Text.Length} characters\n" +
                            $"Plaintext Length: {decryptedText.Length} characters",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            "Decryption returned empty result.\n\n" + debugInfo,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                else
                {
                    // Get error message from DLL
                    IntPtr errorPtr = getLastError();
                    string errorMessage = "Unknown error";
                    if (errorPtr != IntPtr.Zero)
                    {
                        errorMessage = PtrToStringAnsi(errorPtr);
                    }
                    
                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        errorMessage = "DLL returned null pointer (function failed)";
                    }

                    // Show detailed error with debug info
                    MessageBox.Show(
                        $"Failed to decrypt text.\n\n" +
                        $"Error: {errorMessage}\n\n" +
                        debugInfo,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An exception occurred: {ex.Message}\n\n" +
                    $"Stack Trace:\n{ex.StackTrace}",
                    "Exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                // Restore UI
                this.Cursor = Cursors.Default;
                Decrypt.Enabled = true;
                Decrypt.Text = "Decrypt";
            }
        }

        #endregion

        // Helper to convert string to null-terminated UTF-8 bytes
        private byte[] StringToUTF8Bytes(string str)
        {
            if (string.IsNullOrEmpty(str)) return new byte[] { 0 };
            
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(str);
            byte[] result = new byte[utf8Bytes.Length + 1]; // +1 for null terminator
            Array.Copy(utf8Bytes, result, utf8Bytes.Length);
            result[utf8Bytes.Length] = 0; // null terminator
            return result;
        }

        // Helper method to get UTF-8 string from IntPtr
        private string PtrToStringUTF8(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                return string.Empty;
            
            // Get the length of the string by looking for null terminator
            int length = 0;
            while (Marshal.ReadByte(ptr, length) != 0)
                length++;
            
            // Create byte array and copy data
            byte[] bytes = new byte[length];
            Marshal.Copy(ptr, bytes, 0, length);
            
            // Convert from UTF-8 bytes to string
            return Encoding.UTF8.GetString(bytes);
        }

        // Helper method to get string from IntPtr (fallback to ANSI for error messages)
        private string PtrToStringAnsi(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                return string.Empty;
            
            return Marshal.PtrToStringAnsi(ptr) ?? string.Empty;
        }
    }
}
