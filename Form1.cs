
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SymmetricEncryptionApp
{
    public partial class Form1 : Form
    {
        private SymmetricAlgorithm algorithm;

        public Form1()
        {
            InitializeComponent();
            comboBoxAlgorithm.Items.AddRange(new string[] { "AES", "DES", "TripleDES", "RC2" });
            comboBoxAlgorithm.SelectedIndex = 0;
            SelectAlgorithm();
        }

        private void SelectAlgorithm()
        {
            switch (comboBoxAlgorithm.SelectedItem.ToString())
            {
                case "AES":
                    algorithm = Aes.Create();
                    break;
                case "DES":
                    algorithm = DES.Create();
                    break;
                case "TripleDES":
                    algorithm = TripleDES.Create();
                    break;
                case "RC2":
                    algorithm = RC2.Create();
                    break;
            }
        }

        private void btnGenerateKeyIV_Click(object sender, EventArgs e)
        {
            algorithm.GenerateKey();
            algorithm.GenerateIV();
            textBoxKey.Text = BitConverter.ToString(algorithm.Key).Replace("-", "");
            textBoxIV.Text = BitConverter.ToString(algorithm.IV).Replace("-", "");
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            byte[] encrypted;
            ICryptoTransform encryptor = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV);
            using (var ms = new System.IO.MemoryStream())
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            using (var swriter = new System.IO.StreamWriter(cs))
            {
                swriter.Write(textBoxPlainASCII.Text);
            encrypted = ms.ToArray();
            }
            sw.Stop();
            textBoxCipherASCII.Text = Encoding.ASCII.GetString(encrypted);
            textBoxCipherHEX.Text = BitConverter.ToString(encrypted).Replace("-", "");
            textBoxEncryptTime.Text = sw.ElapsedMilliseconds + " ms";
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            byte[] cipherBytes = Encoding.ASCII.GetBytes(textBoxCipherASCII.Text);
            string decrypted;
            ICryptoTransform decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV);
            using (var ms = new System.IO.MemoryStream(cipherBytes))
            using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
            using (var sreader = new System.IO.StreamReader(cs))
            {
                decrypted = sreader.ReadToEnd();
            }
            sw.Stop();
            textBoxPlainASCII.Text = decrypted;
            textBoxDecryptTime.Text = sw.ElapsedMilliseconds + " ms";
        }

        private void comboBoxAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectAlgorithm();
        }
    }
}
