using Feodosiya.Lib.Security;
using System;
using System.Windows.Forms;


namespace HashGenerator {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void HashButton_Click(object sender, EventArgs e) {
            string src = SourceBox.Text;
            if (string.IsNullOrWhiteSpace(src)) {
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            try {
                ResultBox.Text = Pbkdf2Cryptography.HashPassword(src);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClipboardButton_Click(object sender, EventArgs e) {
            string res = ResultBox.Text;
            if (string.IsNullOrWhiteSpace(res)) {
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            try {
                Clipboard.SetText(res, TextDataFormat.Text);
                MessageBox.Show("Скопировано в буфер обмена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
