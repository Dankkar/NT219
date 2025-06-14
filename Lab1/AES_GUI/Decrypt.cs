using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AES_GUI
{
    public partial class Decrypt : Form
    {
        [DllImport("AES_dll_gcc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr AESDecrypt(string mode, string keyIVFormat, string keyFile, string ivFile,
                                             string cipherFormat, string cipherText);
        public Decrypt()
        {
            InitializeComponent();
        }

        private void KeyFilebtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                ofd.Title = "Select Key File";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    KeyFiletb.Text = ofd.FileName;
                }
            }
        }

        private void IVFilebtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                ofd.Title = "Select IV File";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    IVFiletb.Text = ofd.FileName;
                }
            }
        }

        private void Ciphertextbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                ofd.Title = "Select ciphertext File";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string fileContent = File.ReadAllText(ofd.FileName);
                        Ciphertextrtb.Text = fileContent;  // Gán nội dung vào TextBox
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading the file: " + ex.Message);
                    }
                }
            }
        }

        private void Decryptbtn_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrEmpty(Ciphertextrtb.Text))
            {
                MessageBox.Show("Please enter ciphertext or select a file!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(KeyFiletb.Text))
            {
                MessageBox.Show("Please select a key file!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mode = AESModecb.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(mode))
            {
                MessageBox.Show("Please select an encryption mode!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (mode != "ECB" && string.IsNullOrEmpty(IVFiletb.Text))
            {
                MessageBox.Show("Please select an IV file for non-ECB modes!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string format = Formatcb.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(format))
            {
                MessageBox.Show("Please select a key/IV format!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cipherFormat = Ciphercb.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(cipherFormat))
            {
                MessageBox.Show("Please select a cipher format!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Call the decryption function
                IntPtr resultPtr = AESDecrypt(
                    mode,
                    format,
                    KeyFiletb.Text,
                    IVFiletb.Text,
                    cipherFormat,
                    Ciphertextrtb.Text
                );

                // Convert the result to a string
                string result = Marshal.PtrToStringAnsi(resultPtr);
                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Decryption failed: No result returned", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the result is an error message
                if (result.StartsWith("Error:"))
                {
                    MessageBox.Show(result, "Decryption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Plaintextrtb.Text = result;
                MessageBox.Show("Decryption completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during decryption: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
