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

namespace DES_GUI
{
    public partial class GenKey : Form
    {
        private readonly string defaultKeyDirectory;

        [DllImport("DES_dll_gcc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GenerateKeyAndIV(string mode, int keySize, string format, string keyFile, string ivFile);
        
        public GenKey()
        {
            InitializeComponent();
            DESModecb.SelectedIndex = 0; // Chọn chế độ mặc định
            KeySizetb.Text = "8"; // Kích thước khóa mặc định
            Formatcb.SelectedIndex = 0; // Chọn định dạng mặc định

            // Set up default key directory in the application's directory
            defaultKeyDirectory = Path.Combine(Application.StartupPath, "Keys");
            if (!Directory.Exists(defaultKeyDirectory))
            {
                Directory.CreateDirectory(defaultKeyDirectory);
            }
        }

        private void BrowseKeybtn_Click(object sender, EventArgs e)
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

        private void BrowseIVbtn_Click(object sender, EventArgs e)
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
            // If the path is already absolute, return it
            if (Path.IsPathRooted(filePath))
            {
                return filePath;
            }

            // Otherwise, combine with the default directory
            return Path.Combine(defaultKeyDirectory, filePath);
        }

        private void Generatebtn_Click(object sender, EventArgs e)
        {
            // Kiểm tra tbKeySize phải là 8 bytes cho DES
            if (KeySizetb.Text != "8")
            {
                MessageBox.Show("Key size must be 8 bytes for DES!");
                return;
            }

            // Lấy các giá trị từ các control
            string mode = DESModecb.SelectedItem.ToString();  // Chế độ DES
            int keySize = int.Parse(KeySizetb.Text);         // Key size (8 bytes cho DES)
            string format = Formatcb.SelectedItem.ToString(); // Định dạng file (Binary, Hex, Base64)
            string keyFile = KeyFiletb.Text;
            string ivFile = IVFiletb.Text;

            // Kiểm tra và xử lý key file
            if (string.IsNullOrEmpty(keyFile))
            {
                MessageBox.Show("Please specify a key file path!");
                return;
            }

            // Get full paths for the files
            keyFile = GetFullPath(keyFile);
            if (mode != "ECB")
            {
                ivFile = GetFullPath(ivFile);
            }

            // Kiểm tra và xử lý IV file nếu không phải ECB mode
            if (mode != "ECB" && string.IsNullOrEmpty(ivFile))
            {
                MessageBox.Show("Please specify an IV file path for non-ECB modes!");
                return;
            }

            try
            {
                // Tạo thư mục nếu chưa tồn tại
                string keyDir = Path.GetDirectoryName(keyFile);
                if (!string.IsNullOrEmpty(keyDir) && !Directory.Exists(keyDir))
                {
                    Directory.CreateDirectory(keyDir);
                }

                if (mode != "ECB")
                {
                    string ivDir = Path.GetDirectoryName(ivFile);
                    if (!string.IsNullOrEmpty(ivDir) && !Directory.Exists(ivDir))
                    {
                        Directory.CreateDirectory(ivDir);
                    }
                }

                // Gọi hàm từ DLL để sinh Key và IV
                GenerateKeyAndIV(mode, keySize, format, keyFile, ivFile);
                MessageBox.Show($"Key and IV generated successfully!\nKey file: {keyFile}\nIV file: {(mode != "ECB" ? ivFile : "Not required for ECB mode")}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
