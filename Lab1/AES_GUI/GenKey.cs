using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AES_GUI
{
    public partial class GenKey : Form
    {
        [DllImport("AES_dll_gcc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GenerateAESKey([Out] byte[] key, [Out] byte[] iv);
        [DllImport("AES_dll_gcc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SaveKeyToFile(string filename, byte[] key, byte[] iv);
        [DllImport("AES_dll_gcc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GenerateKeyAndIV(string mode, int keySize, string format, string keyFile, string ivFile);
        private readonly string defaultKeyDirectory;
        public GenKey()
        {
            InitializeComponent();
            Generatebtn.Visible = true;
            AESModecb.SelectedIndex = 0; // Chọn chế độ mặc định
            KeySizetb.Text = "16"; // Kích thước khóa mặc định
            Formatcb.SelectedIndex = 0; // Chọn định dạng mặc định
            defaultKeyDirectory = Path.Combine(Application.StartupPath, "Keys");
            if (!Directory.Exists(defaultKeyDirectory))
            {
                Directory.CreateDirectory(defaultKeyDirectory);
            }
        }

        private void KeyFilebtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                ofd.Title = "Select Key File";
                ofd.InitialDirectory = defaultKeyDirectory;

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
                ofd.InitialDirectory = defaultKeyDirectory;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    IVFiletb.Text = ofd.FileName;
                }
            }
        }

        private string GetFullPath(string filePath)
        {
            if (Path.IsPathRooted(filePath))
                return filePath;
            return Path.Combine(defaultKeyDirectory, filePath);
        }


        private void Genbtn_Click(object sender, EventArgs e)
        {
            string mode = AESModecb.SelectedItem.ToString();
            string format = Formatcb.SelectedItem.ToString();
            string keyFile = KeyFiletb.Text.Trim();
            string ivFile = IVFiletb.Text.Trim();
            if (!int.TryParse(KeySizetb.Text.Trim(), out int keySize))
            {
                MessageBox.Show("Key size must be a number (16, 24, 32)", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (mode == "XTS")
            {
                if (keySize != 32)
                {
                    MessageBox.Show("For AES-XTS, key size must be 32 (XTS-128).", "Invalid Key Size", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (keySize != 16 && keySize != 24 && keySize != 32)
                {
                    MessageBox.Show("Key size must be 16, 24, or 32 bytes.", "Invalid Key Size", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (string.IsNullOrEmpty(keyFile))
            {
                MessageBox.Show("Please specify a key file path.");
                return;
            }
            if (mode != "ECB" && string.IsNullOrEmpty(ivFile))
            {
                MessageBox.Show("Please specify an IV file path for non-ECB modes.");
                return;
            }
            keyFile = GetFullPath(keyFile);
            if (mode != "ECB")
                ivFile = GetFullPath(ivFile);
            try
            {
                string keyDir = Path.GetDirectoryName(keyFile);
                if (!string.IsNullOrEmpty(keyDir) && !Directory.Exists(keyDir))
                    Directory.CreateDirectory(keyDir);
                if (mode != "ECB")
                {
                    string ivDir = Path.GetDirectoryName(ivFile);
                    if (!string.IsNullOrEmpty(ivDir) && !Directory.Exists(ivDir))
                        Directory.CreateDirectory(ivDir);
                }
                GenerateKeyAndIV(mode, keySize, format, keyFile, ivFile);
                MessageBox.Show($"Key and IV generated successfully!\nKey file: {keyFile}\nIV file: {(mode != "ECB" ? ivFile : "Not required")}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating key/IV: " + ex.Message);
            }
        }
    }
}
