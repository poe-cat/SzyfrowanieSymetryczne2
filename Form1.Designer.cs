
using System.Windows.Forms;
using System.Drawing;

namespace SymmetricEncryptionApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboBoxAlgorithm;
        private Button btnGenerateKeyIV;
        private TextBox textBoxKey;
        private TextBox textBoxIV;
        private TextBox textBoxPlainASCII;
        private TextBox textBoxCipherASCII;
        private TextBox textBoxCipherHEX;
        private TextBox textBoxEncryptTime;
        private TextBox textBoxDecryptTime;
        private Button btnEncrypt;
        private Button btnDecrypt;
        private Label labelKey;
        private Label labelIV;
        private Label labelPlainText;
        private Label labelCipherText;
        private Label labelEncryptTime;
        private Label labelDecryptTime;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            int margin = 12;
            int labelHeight = 20;
            int fieldHeight = 24;
            int spacing = 8;
            int y = margin + fieldHeight;

            this.comboBoxAlgorithm = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(margin, margin),
                Size = new Size(200, fieldHeight)
            };
            this.comboBoxAlgorithm.SelectedIndexChanged += new System.EventHandler(this.comboBoxAlgorithm_SelectedIndexChanged);

            this.btnGenerateKeyIV = new Button
            {
                Text = "Generate Key and IV",
                Location = new Point(230, margin),
                Size = new Size(200, fieldHeight)
            };
            this.btnGenerateKeyIV.Click += new System.EventHandler(this.btnGenerateKeyIV_Click);

            this.labelKey = new Label { Text = "Key", Location = new Point(margin, y), AutoSize = true };
            y += labelHeight;
            this.textBoxKey = new TextBox { Location = new Point(margin, y), Width = 418 };
            y += fieldHeight + spacing;

            this.labelIV = new Label { Text = "IV", Location = new Point(margin, y), AutoSize = true };
            y += labelHeight;
            this.textBoxIV = new TextBox { Location = new Point(margin, y), Width = 418 };
            y += fieldHeight + spacing;

            this.labelPlainText = new Label { Text = "PlainText (ASCII)", Location = new Point(margin, y), AutoSize = true };
            y += labelHeight;
            this.textBoxPlainASCII = new TextBox { Location = new Point(margin, y), Width = 418 };
            y += fieldHeight + spacing;

            this.btnEncrypt = new Button
            {
                Text = "Encrypt",
                Location = new Point(margin, y),
                Size = new Size(100, fieldHeight)
            };
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            y += fieldHeight + spacing;

            this.labelCipherText = new Label { Text = "CipherText (ASCII / HEX)", Location = new Point(margin, y), AutoSize = true };
            y += labelHeight;
            this.textBoxCipherASCII = new TextBox { Location = new Point(margin, y), Width = 418 };
            y += fieldHeight + spacing;
            this.textBoxCipherHEX = new TextBox { Location = new Point(margin, y), Width = 418 };
            y += fieldHeight + spacing;

            this.btnDecrypt = new Button
            {
                Text = "Decrypt",
                Location = new Point(margin, y),
                Size = new Size(100, fieldHeight)
            };
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            y += fieldHeight + spacing;

            this.labelEncryptTime = new Label { Text = "Encryption Time", Location = new Point(margin, y), AutoSize = true };
            y += labelHeight;
            this.textBoxEncryptTime = new TextBox { Location = new Point(margin, y), Width = 418 };
            y += fieldHeight + spacing;

            this.labelDecryptTime = new Label { Text = "Decryption Time", Location = new Point(margin, y), AutoSize = true };
            y += labelHeight;
            this.textBoxDecryptTime = new TextBox { Location = new Point(margin, y), Width = 418 };
            y += fieldHeight + spacing;

            this.ClientSize = new Size(460, y);
            this.Text = "Symmetric Encryption Test";
            this.Controls.AddRange(new Control[] {
                comboBoxAlgorithm, btnGenerateKeyIV,
                labelKey, textBoxKey,
                labelIV, textBoxIV,
                labelPlainText, textBoxPlainASCII,
                btnEncrypt,
                labelCipherText, textBoxCipherASCII, textBoxCipherHEX,
                btnDecrypt,
                labelEncryptTime, textBoxEncryptTime,
                labelDecryptTime, textBoxDecryptTime
            });
        }
    }
}
