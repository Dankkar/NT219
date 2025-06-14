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

namespace DES_GUI
{
    public partial class Encrypt : Form
    {
        

        [DllImport("DES_dll_gcc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DESEncrypt(string mode, string keyIVFormat, string keyFile, string ivFile,
                                             string cipherFormat, string plainText);

        public Encrypt()
        {
            InitializeComponent();
        }

        private void BrowseKeybtn_Click(object sender, EventArgs e)
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

        private void BrowseIVbtn_Click(object sender, EventArgs e)
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

        private void SaveFilebtn_Click(object sender, EventArgs e)
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

        private void Encryptbtn_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrEmpty(Plaintextrtb.Text))
            {
                MessageBox.Show("Please enter plaintext or select a file!");
                return;
            }

            if (string.IsNullOrEmpty(KeyFiletb.Text))
            {
                MessageBox.Show("Please select a key file!");
                return;
            }

            string mode = DESModecb.SelectedItem.ToString();
            if (mode != "ECB" && string.IsNullOrEmpty(IVFiletb.Text))
            {
                MessageBox.Show("Please select an IV file for non-ECB modes!");
                return;
            }

            try
            {
                // Call the encryption function
                IntPtr resultPtr = DESEncrypt(
                    mode,
                    Formatcb.SelectedItem.ToString(),
                    KeyFiletb.Text,
                    IVFiletb.Text,
                    Ciphercb.SelectedItem.ToString(),
                    Plaintextrtb.Text
                );

                // Convert the result to a string
                string result = Marshal.PtrToStringAnsi(resultPtr);
                if (!string.IsNullOrEmpty(result))
                {
                    Cipherrtb.Text = result;
                    MessageBox.Show("Encryption completed successfully!");
                }
                else
                {
                    MessageBox.Show("Encryption failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during encryption: " + ex.Message);
            }
        }
    }
}
