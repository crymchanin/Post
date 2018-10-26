using System;
using System.Windows.Forms;
using Feodosiya.Lib.Security;


namespace OASU_RPO.GUI {
    public partial class AdminWindow : Form {
        public AdminWindow() {
            InitializeComponent();
        }

        private void Check() {
            try {
                if (!Pbkdf2Cryptography.ValidatePassword(UsernameBox.Text, AppHelper.Configuration.Admin.RootName) ||
                        !Pbkdf2Cryptography.ValidatePassword(PasswordBox.Text, AppHelper.Configuration.Admin.RootPassword)) {
                    ErrorLabel.Visible = true;
                    System.Media.SystemSounds.Beep.Play();
                    return;
                }

                ErrorLabel.Visible = false;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception error) {
                MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e) {
            Check();
        }

        private void UsernameBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (string.IsNullOrWhiteSpace(PasswordBox.Text)) {
                    SelectNextControl((Control)sender,true, true, true, true);
                }
                else {
                    Check();
                }
            }
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (string.IsNullOrWhiteSpace(UsernameBox.Text)) {
                    SelectNextControl((Control)sender, false, true, true, true);
                }
                else {
                    Check();
                }
            }
        }
    }
}
