namespace RSA_GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.KeyGenbtn = new System.Windows.Forms.Button();
            this.KeyGen_PrivKeybtn = new System.Windows.Forms.Button();
            this.KeyGen_PubKeybtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.KeyGen_PrivKeyPath = new System.Windows.Forms.TextBox();
            this.KeyGen_PubKeyPath = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Encrypt = new System.Windows.Forms.Button();
            this.Encrypt_Ciphertext = new System.Windows.Forms.Button();
            this.Encrypt_Plaintext = new System.Windows.Forms.Button();
            this.Encrypt_Ciphertextrtb = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.Encrypt_Plaintextrtb = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Encrypt_PubKeybtn = new System.Windows.Forms.Button();
            this.Encrypt_PubKeyPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Decrypt = new System.Windows.Forms.Button();
            this.Decrypt_Plaintext = new System.Windows.Forms.Button();
            this.Decrypt_Ciphertext = new System.Windows.Forms.Button();
            this.Decrypt_Plaintextrtb = new System.Windows.Forms.RichTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Decrypt_PrivateKeybtn = new System.Windows.Forms.Button();
            this.Decrypt_PrivateKeyPath = new System.Windows.Forms.TextBox();
            this.Decrypt_Ciphertextrtb = new System.Windows.Forms.RichTextBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(610, 520);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.KeyGenbtn);
            this.tabPage1.Controls.Add(this.KeyGen_PrivKeybtn);
            this.tabPage1.Controls.Add(this.KeyGen_PubKeybtn);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.KeyGen_PrivKeyPath);
            this.tabPage1.Controls.Add(this.KeyGen_PubKeyPath);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(602, 494);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "KeyGen";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // KeyGenbtn
            // 
            this.KeyGenbtn.Location = new System.Drawing.Point(296, 223);
            this.KeyGenbtn.Name = "KeyGenbtn";
            this.KeyGenbtn.Size = new System.Drawing.Size(87, 33);
            this.KeyGenbtn.TabIndex = 10;
            this.KeyGenbtn.Text = "Generate";
            this.KeyGenbtn.UseVisualStyleBackColor = true;
            this.KeyGenbtn.Click += new System.EventHandler(this.KeyGenbtn_Click);
            // 
            // KeyGen_PrivKeybtn
            // 
            this.KeyGen_PrivKeybtn.Location = new System.Drawing.Point(495, 153);
            this.KeyGen_PrivKeybtn.Name = "KeyGen_PrivKeybtn";
            this.KeyGen_PrivKeybtn.Size = new System.Drawing.Size(75, 23);
            this.KeyGen_PrivKeybtn.TabIndex = 9;
            this.KeyGen_PrivKeybtn.Text = "Browse";
            this.KeyGen_PrivKeybtn.UseVisualStyleBackColor = true;
            this.KeyGen_PrivKeybtn.Click += new System.EventHandler(this.KeyGen_PrivKeybtn_Click);
            // 
            // KeyGen_PubKeybtn
            // 
            this.KeyGen_PubKeybtn.Location = new System.Drawing.Point(495, 114);
            this.KeyGen_PubKeybtn.Name = "KeyGen_PubKeybtn";
            this.KeyGen_PubKeybtn.Size = new System.Drawing.Size(75, 23);
            this.KeyGen_PubKeybtn.TabIndex = 8;
            this.KeyGen_PubKeybtn.Text = "Browse";
            this.KeyGen_PubKeybtn.UseVisualStyleBackColor = true;
            this.KeyGen_PubKeybtn.Click += new System.EventHandler(this.KeyGen_PubKeybtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.Location = new System.Drawing.Point(34, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Private Key Path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.Location = new System.Drawing.Point(34, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Public Key Path";
            // 
            // KeyGen_PrivKeyPath
            // 
            this.KeyGen_PrivKeyPath.BackColor = System.Drawing.SystemColors.Window;
            this.KeyGen_PrivKeyPath.Location = new System.Drawing.Point(188, 153);
            this.KeyGen_PrivKeyPath.Name = "KeyGen_PrivKeyPath";
            this.KeyGen_PrivKeyPath.Size = new System.Drawing.Size(281, 20);
            this.KeyGen_PrivKeyPath.TabIndex = 5;
            // 
            // KeyGen_PubKeyPath
            // 
            this.KeyGen_PubKeyPath.BackColor = System.Drawing.SystemColors.Window;
            this.KeyGen_PubKeyPath.Location = new System.Drawing.Point(188, 114);
            this.KeyGen_PubKeyPath.Name = "KeyGen_PubKeyPath";
            this.KeyGen_PubKeyPath.Size = new System.Drawing.Size(281, 20);
            this.KeyGen_PubKeyPath.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(188, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(34, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Key Size (bit)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(34, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Choose Key Format";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "PEM",
            "DER",
            "BASE64"});
            this.comboBox1.Location = new System.Drawing.Point(188, 71);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(125, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Encrypt);
            this.tabPage2.Controls.Add(this.Encrypt_Ciphertext);
            this.tabPage2.Controls.Add(this.Encrypt_Plaintext);
            this.tabPage2.Controls.Add(this.Encrypt_Ciphertextrtb);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.comboBox3);
            this.tabPage2.Controls.Add(this.Encrypt_Plaintextrtb);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.Encrypt_PubKeybtn);
            this.tabPage2.Controls.Add(this.Encrypt_PubKeyPath);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(602, 494);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Encrypt";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Encrypt
            // 
            this.Encrypt.Location = new System.Drawing.Point(256, 404);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(89, 34);
            this.Encrypt.TabIndex = 13;
            this.Encrypt.Text = "Encrypt";
            this.Encrypt.UseVisualStyleBackColor = true;
            this.Encrypt.Click += new System.EventHandler(this.Encrypt_Click);
            // 
            // Encrypt_Ciphertext
            // 
            this.Encrypt_Ciphertext.Location = new System.Drawing.Point(468, 287);
            this.Encrypt_Ciphertext.Name = "Encrypt_Ciphertext";
            this.Encrypt_Ciphertext.Size = new System.Drawing.Size(75, 23);
            this.Encrypt_Ciphertext.TabIndex = 12;
            this.Encrypt_Ciphertext.Text = "Save to file";
            this.Encrypt_Ciphertext.UseVisualStyleBackColor = true;
            this.Encrypt_Ciphertext.Click += new System.EventHandler(this.Encrypt_Ciphertext_Click);
            // 
            // Encrypt_Plaintext
            // 
            this.Encrypt_Plaintext.Location = new System.Drawing.Point(468, 110);
            this.Encrypt_Plaintext.Name = "Encrypt_Plaintext";
            this.Encrypt_Plaintext.Size = new System.Drawing.Size(75, 23);
            this.Encrypt_Plaintext.TabIndex = 11;
            this.Encrypt_Plaintext.Text = "Browse";
            this.Encrypt_Plaintext.UseVisualStyleBackColor = true;
            this.Encrypt_Plaintext.Click += new System.EventHandler(this.Encrypt_Plaintext_Click);
            // 
            // Encrypt_Ciphertextrtb
            // 
            this.Encrypt_Ciphertextrtb.Location = new System.Drawing.Point(171, 287);
            this.Encrypt_Ciphertextrtb.Name = "Encrypt_Ciphertextrtb";
            this.Encrypt_Ciphertextrtb.ReadOnly = true;
            this.Encrypt_Ciphertextrtb.Size = new System.Drawing.Size(291, 96);
            this.Encrypt_Ciphertextrtb.TabIndex = 10;
            this.Encrypt_Ciphertextrtb.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label10.Location = new System.Drawing.Point(17, 287);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "Ciphertext";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label9.Location = new System.Drawing.Point(17, 244);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Ciphertext Format";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "HEX",
            "BASE64"});
            this.comboBox3.Location = new System.Drawing.Point(171, 240);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 7;
            // 
            // Encrypt_Plaintextrtb
            // 
            this.Encrypt_Plaintextrtb.Location = new System.Drawing.Point(171, 110);
            this.Encrypt_Plaintextrtb.Name = "Encrypt_Plaintextrtb";
            this.Encrypt_Plaintextrtb.Size = new System.Drawing.Size(291, 96);
            this.Encrypt_Plaintextrtb.TabIndex = 6;
            this.Encrypt_Plaintextrtb.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label8.Location = new System.Drawing.Point(17, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Plaintext";
            // 
            // Encrypt_PubKeybtn
            // 
            this.Encrypt_PubKeybtn.Location = new System.Drawing.Point(468, 72);
            this.Encrypt_PubKeybtn.Name = "Encrypt_PubKeybtn";
            this.Encrypt_PubKeybtn.Size = new System.Drawing.Size(75, 23);
            this.Encrypt_PubKeybtn.TabIndex = 4;
            this.Encrypt_PubKeybtn.Text = "Browse";
            this.Encrypt_PubKeybtn.UseVisualStyleBackColor = true;
            this.Encrypt_PubKeybtn.Click += new System.EventHandler(this.Encrypt_PubKeybtn_Click);
            // 
            // Encrypt_PubKeyPath
            // 
            this.Encrypt_PubKeyPath.Location = new System.Drawing.Point(171, 75);
            this.Encrypt_PubKeyPath.Name = "Encrypt_PubKeyPath";
            this.Encrypt_PubKeyPath.Size = new System.Drawing.Size(291, 20);
            this.Encrypt_PubKeyPath.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label7.Location = new System.Drawing.Point(17, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Public Key Path";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "PEM",
            "DER",
            "BASE64"});
            this.comboBox2.Location = new System.Drawing.Point(171, 31);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label6.Location = new System.Drawing.Point(17, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Choose Key Format";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Decrypt);
            this.tabPage3.Controls.Add(this.Decrypt_Plaintext);
            this.tabPage3.Controls.Add(this.Decrypt_Ciphertext);
            this.tabPage3.Controls.Add(this.Decrypt_Plaintextrtb);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.comboBox5);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.Decrypt_PrivateKeybtn);
            this.tabPage3.Controls.Add(this.Decrypt_PrivateKeyPath);
            this.tabPage3.Controls.Add(this.Decrypt_Ciphertextrtb);
            this.tabPage3.Controls.Add(this.comboBox4);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(602, 494);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Decrypt";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Decrypt
            // 
            this.Decrypt.Location = new System.Drawing.Point(265, 417);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(81, 38);
            this.Decrypt.TabIndex = 21;
            this.Decrypt.Text = "Decrypt";
            this.Decrypt.UseVisualStyleBackColor = true;
            this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // Decrypt_Plaintext
            // 
            this.Decrypt_Plaintext.Location = new System.Drawing.Point(488, 315);
            this.Decrypt_Plaintext.Name = "Decrypt_Plaintext";
            this.Decrypt_Plaintext.Size = new System.Drawing.Size(75, 23);
            this.Decrypt_Plaintext.TabIndex = 20;
            this.Decrypt_Plaintext.Text = "Save to File";
            this.Decrypt_Plaintext.UseVisualStyleBackColor = true;
            this.Decrypt_Plaintext.Click += new System.EventHandler(this.Decrypt_Plaintext_Click);
            // 
            // Decrypt_Ciphertext
            // 
            this.Decrypt_Ciphertext.Location = new System.Drawing.Point(488, 194);
            this.Decrypt_Ciphertext.Name = "Decrypt_Ciphertext";
            this.Decrypt_Ciphertext.Size = new System.Drawing.Size(75, 23);
            this.Decrypt_Ciphertext.TabIndex = 19;
            this.Decrypt_Ciphertext.Text = "Browse";
            this.Decrypt_Ciphertext.UseVisualStyleBackColor = true;
            this.Decrypt_Ciphertext.Click += new System.EventHandler(this.Decrypt_Ciphertext_Click);
            // 
            // Decrypt_Plaintextrtb
            // 
            this.Decrypt_Plaintextrtb.Location = new System.Drawing.Point(171, 315);
            this.Decrypt_Plaintextrtb.Name = "Decrypt_Plaintextrtb";
            this.Decrypt_Plaintextrtb.ReadOnly = true;
            this.Decrypt_Plaintextrtb.Size = new System.Drawing.Size(291, 96);
            this.Decrypt_Plaintextrtb.TabIndex = 14;
            this.Decrypt_Plaintextrtb.Text = "";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label15.Location = new System.Drawing.Point(17, 315);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 17);
            this.label15.TabIndex = 18;
            this.label15.Text = "Plaintext";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label14.Location = new System.Drawing.Point(17, 194);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 17);
            this.label14.TabIndex = 17;
            this.label14.Text = "Ciphertext";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "HEX",
            "BASE64"});
            this.comboBox5.Location = new System.Drawing.Point(171, 126);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(121, 21);
            this.comboBox5.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label13.Location = new System.Drawing.Point(17, 130);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 17);
            this.label13.TabIndex = 16;
            this.label13.Text = "Ciphertext Format";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label12.Location = new System.Drawing.Point(17, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 17);
            this.label12.TabIndex = 15;
            this.label12.Text = "Private Key Path";
            // 
            // Decrypt_PrivateKeybtn
            // 
            this.Decrypt_PrivateKeybtn.Location = new System.Drawing.Point(488, 80);
            this.Decrypt_PrivateKeybtn.Name = "Decrypt_PrivateKeybtn";
            this.Decrypt_PrivateKeybtn.Size = new System.Drawing.Size(75, 23);
            this.Decrypt_PrivateKeybtn.TabIndex = 14;
            this.Decrypt_PrivateKeybtn.Text = "Browse";
            this.Decrypt_PrivateKeybtn.UseVisualStyleBackColor = true;
            this.Decrypt_PrivateKeybtn.Click += new System.EventHandler(this.Decrypt_PrivateKeybtn_Click);
            // 
            // Decrypt_PrivateKeyPath
            // 
            this.Decrypt_PrivateKeyPath.Location = new System.Drawing.Point(171, 80);
            this.Decrypt_PrivateKeyPath.Name = "Decrypt_PrivateKeyPath";
            this.Decrypt_PrivateKeyPath.Size = new System.Drawing.Size(291, 20);
            this.Decrypt_PrivateKeyPath.TabIndex = 14;
            // 
            // Decrypt_Ciphertextrtb
            // 
            this.Decrypt_Ciphertextrtb.Location = new System.Drawing.Point(171, 194);
            this.Decrypt_Ciphertextrtb.Name = "Decrypt_Ciphertextrtb";
            this.Decrypt_Ciphertextrtb.Size = new System.Drawing.Size(291, 96);
            this.Decrypt_Ciphertextrtb.TabIndex = 14;
            this.Decrypt_Ciphertextrtb.Text = "";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "PEM",
            "DER",
            "BASE64"});
            this.comboBox4.Location = new System.Drawing.Point(171, 31);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 21);
            this.comboBox4.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label11.Location = new System.Drawing.Point(17, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Choose Key Format";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "2352669 - Phạm Lê Đăng Kha - NT219.P21.ANTT";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 553);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "RSA_GUI";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox KeyGen_PrivKeyPath;
        private System.Windows.Forms.TextBox KeyGen_PubKeyPath;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button KeyGenbtn;
        private System.Windows.Forms.Button KeyGen_PrivKeybtn;
        private System.Windows.Forms.Button KeyGen_PubKeybtn;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Encrypt_PubKeybtn;
        private System.Windows.Forms.TextBox Encrypt_PubKeyPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.RichTextBox Encrypt_Plaintextrtb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Encrypt;
        private System.Windows.Forms.Button Encrypt_Ciphertext;
        private System.Windows.Forms.Button Encrypt_Plaintext;
        private System.Windows.Forms.RichTextBox Encrypt_Ciphertextrtb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox Decrypt_Plaintextrtb;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button Decrypt_PrivateKeybtn;
        private System.Windows.Forms.TextBox Decrypt_PrivateKeyPath;
        private System.Windows.Forms.RichTextBox Decrypt_Ciphertextrtb;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button Decrypt;
        private System.Windows.Forms.Button Decrypt_Plaintext;
        private System.Windows.Forms.Button Decrypt_Ciphertext;
    }
}

