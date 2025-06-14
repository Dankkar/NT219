using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AES_GUI
{
    public partial class Form1 : Form
    {
        // DLL Import declarations
        [DllImport("aes_dll_gcc.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int AES_EncryptCBC(
            byte[] key, ulong keyLength,
            byte[] iv, ulong ivLength,
            byte[] plaintext, ulong plaintextLength,
            byte[] ciphertext, ref ulong ciphertextLength);

        [DllImport("aes_dll_gcc.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int AES_DecryptCBC(
            byte[] key, ulong keyLength,
            byte[] iv, ulong ivLength,
            byte[] ciphertext, ulong ciphertextLength,
            byte[] plaintext, ref ulong plaintextLength);

        public Form1()
        {
            InitializeComponent();
        }

        private void Enc_Keybtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Enc_Keytb.Text = File.ReadAllText(ofd.FileName);
                }
            }
        }

        private void Enc_IVbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Enc_IVtb.Text = File.ReadAllText(ofd.FileName);
                }
            }
        }

        private void Enc_Plaintextbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Enc_Plainrtb.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void Enc_Savebtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, Enc_Cipherrtb.Text);
                    MessageBox.Show("Đã lưu ciphertext thành công!");
                }
            }
        }

        private void Dec_Keybtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Dec_Keytb.Text = File.ReadAllText(ofd.FileName);
                }
            }
        }

        private void Dec_IVbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Dec_IVtb.Text = File.ReadAllText(ofd.FileName);
                }
            }
        }

        private void Dec_Ciphertextbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Dec_Cipherrtb.Text = File.ReadAllText(ofd.FileName);
                }
            }
        }

        private void Dec_Savebtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, Dec_Plainrtb.Text);
                    MessageBox.Show("Đã lưu plaintext thành công!");
                }
            }
        }

        private void Encryptbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Convert hex strings to byte arrays
                byte[] key = StringToByteArray(Enc_Keytb.Text.Trim());
                byte[] iv = StringToByteArray(Enc_IVtb.Text.Trim());
                byte[] plaintext = Encoding.UTF8.GetBytes(Enc_Plainrtb.Text);

                // Validate key and IV lengths
                if (key.Length != 16 && key.Length != 24 && key.Length != 32)
                {
                    MessageBox.Show("Invalid key length. Must be 16, 24, or 32 bytes.");
                    return;
                }
                if (iv.Length != 16)
                {
                    MessageBox.Show("Invalid IV length. Must be 16 bytes.");
                    return;
                }

                // Prepare output buffer (plaintext length + padding)
                ulong ciphertextLength = (ulong)((plaintext.Length / 16 + 1) * 16);
                byte[] ciphertext = new byte[ciphertextLength];

                // Call encryption function
                int result = AES_EncryptCBC(
                    key, (ulong)key.Length,
                    iv, (ulong)iv.Length,
                    plaintext, (ulong)plaintext.Length,
                    ciphertext, ref ciphertextLength);

                if (result == 0)
                {
                    // Convert result to hex string
                    Enc_Cipherrtb.Text = BitConverter.ToString(ciphertext, 0, (int)ciphertextLength).Replace("-", "");
                    MessageBox.Show("Encryption successful!");
                }
                else
                {
                    MessageBox.Show($"Encryption failed with error code: {result}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during encryption: {ex.Message}");
            }
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            try
            {
                // Convert hex strings to byte arrays
                byte[] key = StringToByteArray(Dec_Keytb.Text.Trim());
                byte[] iv = StringToByteArray(Dec_IVtb.Text.Trim());
                byte[] ciphertext = StringToByteArray(Dec_Cipherrtb.Text.Trim());

                // Validate key and IV lengths
                if (key.Length != 16 && key.Length != 24 && key.Length != 32)
                {
                    MessageBox.Show("Invalid key length. Must be 16, 24, or 32 bytes.");
                    return;
                }
                if (iv.Length != 16)
                {
                    MessageBox.Show("Invalid IV length. Must be 16 bytes.");
                    return;
                }

                // Prepare output buffer
                ulong plaintextLength = (ulong)ciphertext.Length;
                byte[] plaintext = new byte[plaintextLength];

                // Call decryption function
                int result = AES_DecryptCBC(
                    key, (ulong)key.Length,
                    iv, (ulong)iv.Length,
                    ciphertext, (ulong)ciphertext.Length,
                    plaintext, ref plaintextLength);

                if (result == 0)
                {
                    // Convert result to string
                    Dec_Plainrtb.Text = Encoding.UTF8.GetString(plaintext, 0, (int)plaintextLength);
                    MessageBox.Show("Decryption successful!");
                }
                else
                {
                    MessageBox.Show($"Decryption failed with error code: {result}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during decryption: {ex.Message}");
            }
        }

        // Helper function to convert hex string to byte array
        private byte[] StringToByteArray(string hex)
        {
            hex = hex.Replace(" ", "").Replace("-", "");
            if (hex.Length % 2 != 0)
                throw new ArgumentException("Hex string must have an even length");

            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return bytes;
        }
    }
}
