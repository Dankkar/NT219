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
    public partial class Encrypt : Form
    {
        [DllImport("AES_dll_gcc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr AESEncrypt(string mode, string keyIVFormat, string keyFile, string ivFile,
                                             string cipherFormat, string plainText);
        public Encrypt()
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

        private void Plaintextbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                ofd.Title = "Select plaintext File";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string fileContent = File.ReadAllText(ofd.FileName);
                        Plaintextrtb.Text = fileContent;  // Gán nội dung vào TextBox
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading the file: " + ex.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Cipherrtb.Text))
            {
                MessageBox.Show("No ciphertext to save!");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                sfd.Title = "Save Ciphertext";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(sfd.FileName, Cipherrtb.Text);
                        MessageBox.Show("Ciphertext saved successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving file: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrEmpty(Plaintextrtb.Text))
            {
                MessageBox.Show("Please enter plaintext or select a file!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                // Call the encryption function
                IntPtr resultPtr = AESEncrypt(
                    mode,
                    format,
                    KeyFiletb.Text,
                    IVFiletb.Text,
                    cipherFormat,
                    Plaintextrtb.Text
                );

                // Convert the result to a string
                string result = Marshal.PtrToStringAnsi(resultPtr);
                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Encryption failed: No result returned", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the result is an error message
                if (result.StartsWith("Error:"))
                {
                    MessageBox.Show(result, "Encryption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Cipherrtb.Text = result;
                MessageBox.Show("Encryption completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during encryption: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
