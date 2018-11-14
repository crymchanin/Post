using Feodosiya.Lib.Security;
using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;


namespace OASU_RPO.GUI {
    public partial class SettingsWindow : Form {

        public SettingsWindow() {
            InitializeComponent();

            LoadConfiguration();

            GuidBox.Text = AppHelper.GUID;
        }

        /// <summary>
        /// Загружает конфигурацию
        /// </summary>
        private void LoadConfiguration() {
            try {
                ShedulerBox.Value = Math.Min(Math.Max(AppHelper.Configuration.Global.ShedulerInterval, (int)ShedulerBox.Minimum),
                    (int)ShedulerBox.Maximum);
                SearchDaysCountBox.Value = Math.Min(Math.Max(AppHelper.Configuration.Global.SearchDaysCount, (int)SearchDaysCountBox.Minimum),
                    (int)SearchDaysCountBox.Maximum);
                MsTimespanLabel.Text = string.Format("мс ({0})", MillisecondsToHours((int)ShedulerBox.Value));
                SoundNotificationsBox.Checked = AppHelper.Configuration.Global.SoundNotifications;
                OpacityBox.Value = Math.Min(Math.Max(AppHelper.Configuration.Global.NotifyWindowOpacity, OpacityBox.Minimum),
                    (int)OpacityBox.Maximum);
                AutorunBox.Checked = AppHelper.Configuration.Global.EnableAutorun;
                MinimizedBox.Checked = AppHelper.Configuration.Global.RunMinimized;
                CheckUpdatesBox.Checked = AppHelper.Configuration.Global.CheckUpdates;
                UpdatesBox.Text = AppHelper.Configuration.Global.UpdatesServerName;

                FBDatasourceBox.Text = AppHelper.Configuration.FBConnection.Datasource;
                FBDatabaseBox.Text = AppHelper.Configuration.FBConnection.Database;
                try {
                    if (!string.IsNullOrWhiteSpace(AppHelper.Configuration.FBConnection.Username)) {
                        FBUsernameBox.Text = AppHelper.Configuration.FBConnection.Username.GetDecryptedString();
                    }
                }
                catch (Exception error) {
                    AppHelper.Log.Write("Ошибка загрузки конфигурации: " + error.ToString(), Feodosiya.Lib.Logs.MessageType.Error);
                }
                try {
                    if (!string.IsNullOrWhiteSpace(AppHelper.Configuration.FBConnection.Password)) {
                        FBPasswordBox.Text = AppHelper.Configuration.FBConnection.Password.GetDecryptedString();
                    }
                }
                catch (Exception error) {
                    AppHelper.Log.Write("Ошибка загрузки конфигурации: " + error.ToString(), Feodosiya.Lib.Logs.MessageType.Error);
                }
                FBCharsetBox.Text = AppHelper.Configuration.FBConnection.Charset;
                FBConnLifetimeBox.Value = Math.Min(Math.Max(AppHelper.Configuration.FBConnection.ConnectionLifetime, (int)FBConnLifetimeBox.Minimum),
                    (int)FBConnLifetimeBox.Maximum);
                FBPoolingBox.Checked = AppHelper.Configuration.FBConnection.Pooling;

                ExServerNameBox.Text = AppHelper.Configuration.Exchange.ServerName;
                ExDomainBox.Text = AppHelper.Configuration.Exchange.Domain;
                try {
                    if (!string.IsNullOrWhiteSpace(AppHelper.Configuration.Exchange.Username)) {
                        ExUsernameBox.Text = AppHelper.Configuration.Exchange.Username.GetDecryptedString();
                    }
                }
                catch (Exception error) {
                    AppHelper.Log.Write("Ошибка загрузки конфигурации: " + error.ToString(), Feodosiya.Lib.Logs.MessageType.Error);
                }
                try {
                    if (!string.IsNullOrWhiteSpace(AppHelper.Configuration.Exchange.Password)) {
                        ExPassBox.Text = AppHelper.Configuration.Exchange.Password.GetDecryptedString();
                    }
                }
                catch (Exception error) {
                    AppHelper.Log.Write("Ошибка загрузки конфигурации: " + error.ToString(), Feodosiya.Lib.Logs.MessageType.Error);
                }
                ExSenderBox.Text = AppHelper.Configuration.Exchange.SenderName;
                ExRegexBox.Text = AppHelper.Configuration.Exchange.MessageRegex;
            }
            catch (Exception error) {
                AppHelper.Log.Write("Ошибка загрузки конфигурации: " + error.ToString(), Feodosiya.Lib.Logs.MessageType.Error);
                MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Преобразует миллисекунды в форматированную строку с датой
        /// </summary>
        /// <param name="ms">Миллисекунды</param>
        /// <returns></returns>
        private string MillisecondsToHours(int ms) {
            int seconds = (ms / 1000) % 60;
            int minutes = (ms / (60 * 1000)) % 60;
            int hourses = ms / (60 * (60 * 1000));

            return string.Format("{0:00}:{1:00}:{2:00}", hourses, minutes, seconds);
        }

        /// <summary>
        /// Присваевает значение свойству, если оно отличается от его текущего значения
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="t1">Текущее значание свойства</param>
        /// <param name="t2">Новое значение свойства</param>
        /// <param name="t3">Объект которому принадлежит свойство</param>
        /// <param name="propName">Имя свойства</param>
        /// <returns></returns>
        private bool UpdateValue<T, T2>(T t1, T t2, T2 t3, string propName) {
            //IComparable comp = (IComparable)t1;
            //comp.CompareTo(t2);
            if (!t1.Equals(t2)) {
                PropertyInfo prop = t3.GetType().GetProperty(propName);
                prop.SetValue(t3, t2);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Сохранение настроек
        /// </summary>
        private void Save() {
            AppHelper.ConfHelper.SaveConfig(AppHelper.Configuration);
            if (!AppHelper.ConfHelper.Success) {
                MessageBox.Show(AppHelper.ConfHelper.LastError.ToString(), "Ошибка сохранения настроек", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Настройки сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Сохраняет параметры планировщика
        private void ShedulerButton_Click(object sender, EventArgs e) {
            try {
                bool flag = false;
                bool result = UpdateValue(AppHelper.Configuration.Global.ShedulerInterval, (int)ShedulerBox.Value, AppHelper.Configuration.Global,
                    nameof(AppHelper.Configuration.Global.ShedulerInterval));
                flag = flag || result;
                result = UpdateValue(AppHelper.Configuration.Global.SearchDaysCount, (int)SearchDaysCountBox.Value, AppHelper.Configuration.Global,
                    nameof(AppHelper.Configuration.Global.SearchDaysCount));
                flag = flag || result;

                if (flag) {
                    Save();
                }
            }
            catch (Exception error) {
                AppHelper.Log.Write("Ошибка изменения конфигурации: " + error.ToString(), Feodosiya.Lib.Logs.MessageType.Error);
                MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Сохраняет параметры интерфейса
        private void InterfaceButton_Click(object sender, EventArgs e) {
            try {
                bool flag = false;
                bool result = UpdateValue(AppHelper.Configuration.Global.SoundNotifications, SoundNotificationsBox.Checked, AppHelper.Configuration.Global,
                    nameof(AppHelper.Configuration.Global.SoundNotifications));
                flag = flag || result;
                result = UpdateValue(AppHelper.Configuration.Global.NotifyWindowOpacity, (int)OpacityBox.Value, AppHelper.Configuration.Global,
                    nameof(AppHelper.Configuration.Global.NotifyWindowOpacity));
                flag = flag || result;

                if (flag) {
                    Save();
                }
            }
            catch (Exception error) {
                AppHelper.Log.Write("Ошибка изменения конфигурации: " + error.ToString(), Feodosiya.Lib.Logs.MessageType.Error);
                MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Сохраняет параметры запуска и обновлений
        private void RunAndUpdatesButton_Click(object sender, EventArgs e) {
            try {
                bool flag = false;
                bool result = UpdateValue(AppHelper.Configuration.Global.EnableAutorun, AutorunBox.Checked, AppHelper.Configuration.Global,
                    nameof(AppHelper.Configuration.Global.EnableAutorun));
                flag = flag || result;
                result = UpdateValue(AppHelper.Configuration.Global.RunMinimized, MinimizedBox.Checked, AppHelper.Configuration.Global,
                    nameof(AppHelper.Configuration.Global.RunMinimized));
                flag = flag || result;
                result = UpdateValue(AppHelper.Configuration.Global.CheckUpdates, CheckUpdatesBox.Checked, AppHelper.Configuration.Global,
                    nameof(AppHelper.Configuration.Global.CheckUpdates));
                flag = flag || result;
                result = UpdateValue(AppHelper.Configuration.Global.UpdatesServerName, UpdatesBox.Text, AppHelper.Configuration.Global,
                    nameof(AppHelper.Configuration.Global.UpdatesServerName));
                flag = flag || result;

                if (flag) {
                    Save();
                }
            }
            catch (Exception error) {
                AppHelper.Log.Write("Ошибка изменения конфигурации: " + error.ToString(), Feodosiya.Lib.Logs.MessageType.Error);
                MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Событие нажатия чекбокса Проверять наличие обновлений
        private void CheckUpdatesBox_CheckedChanged(object sender, EventArgs e) {
            bool flag = CheckUpdatesBox.Checked;
            UpdatesBox.Enabled = flag;
            UpdatesLabel.Enabled = flag;
        }

        // Сохраняет параметры Подключения к БД
        private void FBButton_Click(object sender, EventArgs e) {
            try {
                bool flag = false;
                bool result = UpdateValue(AppHelper.Configuration.FBConnection.Datasource, FBDatasourceBox.Text, AppHelper.Configuration.FBConnection,
                    nameof(AppHelper.Configuration.FBConnection.Datasource));
                flag = flag || result;
                result = UpdateValue(AppHelper.Configuration.FBConnection.Database, FBDatabaseBox.Text, AppHelper.Configuration.FBConnection,
                    nameof(AppHelper.Configuration.FBConnection.Database));
                flag = flag || result;
                result = UpdateValue(AppHelper.Configuration.FBConnection.Charset, FBCharsetBox.Text, AppHelper.Configuration.FBConnection,
                    nameof(AppHelper.Configuration.FBConnection.Charset));
                flag = flag || result;
                result = UpdateValue(AppHelper.Configuration.FBConnection.ConnectionLifetime, (int)FBConnLifetimeBox.Value, AppHelper.Configuration.FBConnection,
                    nameof(AppHelper.Configuration.FBConnection.ConnectionLifetime));
                flag = flag || result;
                result = UpdateValue(AppHelper.Configuration.FBConnection.Pooling, FBPoolingBox.Checked, AppHelper.Configuration.FBConnection,
                    nameof(AppHelper.Configuration.FBConnection.Pooling));
                flag = flag || result;
                if (!string.IsNullOrWhiteSpace(FBUsernameBox.Text)) {
                    try {
                        string username = Pbkdf2Cryptography.Encrypt(Encoding.Default.GetBytes(FBUsernameBox.Text), AppHelper.GUID);
                        result = UpdateValue(AppHelper.Configuration.FBConnection.Username, username, AppHelper.Configuration.FBConnection,
                            nameof(AppHelper.Configuration.FBConnection.Username));
                        flag = flag || result;
                    }
                    catch (Exception error) {
                        AppHelper.Log.Write("Ошибка изменения конфигурации: " + error.ToString(), Feodosiya.Lib.Logs.MessageType.Error);
                        MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (!string.IsNullOrWhiteSpace(FBPasswordBox.Text)) {
                    try {
                        string password = Pbkdf2Cryptography.Encrypt(Encoding.Default.GetBytes(FBPasswordBox.Text), AppHelper.GUID);
                        result = UpdateValue(AppHelper.Configuration.FBConnection.Password, password, AppHelper.Configuration.FBConnection,
                            nameof(AppHelper.Configuration.FBConnection.Password));
                        flag = flag || result;
                    }
                    catch (Exception error) {
                        AppHelper.Log.Write("Ошибка изменения конфигурации: " + error.ToString(), Feodosiya.Lib.Logs.MessageType.Error);
                        MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (flag) {
                    Save();
                }
            }
            catch (Exception error) {
                AppHelper.Log.Write("Ошибка изменения конфигурации: " + error.ToString(), Feodosiya.Lib.Logs.MessageType.Error);
                MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Сохраняет параметры Подключения к Exchange
        private void ExchangeButton_Click(object sender, EventArgs e) {
            try {
                bool flag = false;
                bool result = UpdateValue(AppHelper.Configuration.Exchange.ServerName, ExServerNameBox.Text, AppHelper.Configuration.Exchange,
                    nameof(AppHelper.Configuration.Exchange.ServerName));
                flag = flag || result;
                result = UpdateValue(AppHelper.Configuration.Exchange.Domain, ExDomainBox.Text, AppHelper.Configuration.Exchange,
                    nameof(AppHelper.Configuration.Exchange.Domain));
                flag = flag || result;
                result = UpdateValue(AppHelper.Configuration.Exchange.SenderName, ExSenderBox.Text, AppHelper.Configuration.Exchange,
                    nameof(AppHelper.Configuration.Exchange.SenderName));
                flag = flag || result;
                result = UpdateValue(AppHelper.Configuration.Exchange.MessageRegex, ExRegexBox.Text, AppHelper.Configuration.Exchange,
                    nameof(AppHelper.Configuration.Exchange.MessageRegex));
                flag = flag || result;
                if (!string.IsNullOrWhiteSpace(ExUsernameBox.Text)) {
                    try {
                        string username = Pbkdf2Cryptography.Encrypt(Encoding.Default.GetBytes(ExUsernameBox.Text), AppHelper.GUID);

                        result = UpdateValue(AppHelper.Configuration.Exchange.Username, username, AppHelper.Configuration.Exchange,
                            nameof(AppHelper.Configuration.Exchange.Username));
                        flag = flag || result;
                    }
                    catch (Exception error) {
                        AppHelper.Log.Write("Ошибка изменения конфигурации: " + error.ToString(), Feodosiya.Lib.Logs.MessageType.Error);
                        MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (!string.IsNullOrWhiteSpace(ExPassBox.Text)) {
                    try {
                        string password = Pbkdf2Cryptography.Encrypt(Encoding.Default.GetBytes(ExPassBox.Text), AppHelper.GUID);

                        result = UpdateValue(AppHelper.Configuration.Exchange.Password, password, AppHelper.Configuration.Exchange,
                            nameof(AppHelper.Configuration.Exchange.Password));
                        flag = flag || result;
                    }
                    catch (Exception error) {
                        AppHelper.Log.Write("Ошибка изменения конфигурации: " + error.ToString(), Feodosiya.Lib.Logs.MessageType.Error);
                        MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (flag) {
                    Save();
                }
            }
            catch (Exception error) {
                AppHelper.Log.Write("Ошибка изменения конфигурации: " + error.ToString(), Feodosiya.Lib.Logs.MessageType.Error);
                MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Изменение админского логина/пароля
        private void RootCredentialsButton_Click(object sender, EventArgs e) {
            try {
                string rootName = RootNameBox.Text;
                string rootPass = RootPasswordBox.Text;
                bool flag = false;

                if (!string.IsNullOrWhiteSpace(rootName)) {
                    AppHelper.Configuration.Admin.RootName = Pbkdf2Cryptography.HashPassword(rootName);
                    flag = true;
                }
                if (!string.IsNullOrWhiteSpace(rootPass)) {
                    AppHelper.Configuration.Admin.RootPassword = Pbkdf2Cryptography.HashPassword(rootPass);
                    flag = true;
                }
                if (flag) {
                    Save();
                }
            }
            catch (Exception error) {
                AppHelper.Log.Write("Ошибка изменения конфигурации: " + error.ToString(), Feodosiya.Lib.Logs.MessageType.Error);
                MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обновление форматированого времени шедулера
        private void ShedulerBox_ValueChanged(object sender, EventArgs e) {
            MsTimespanLabel.Text = string.Format("мс ({0})", MillisecondsToHours((int)ShedulerBox.Value));
        }

        // Обновление форматированого времени шедулера
        private void ShedulerBox_KeyUp(object sender, KeyEventArgs e) {
            MsTimespanLabel.Text = string.Format("мс ({0})", MillisecondsToHours((int)ShedulerBox.Value));
        }

        // Тест подключения к БД Firebird
        private void FBTestButton_Click(object sender, EventArgs e) {
            string message;

            Configuration.FBConnection conn = new Configuration.FBConnection() {
                Datasource = FBDatasourceBox.Text,
                Database = FBDatabaseBox.Text,
                Username = FBUsernameBox.Text,
                Password = FBPasswordBox.Text,
                Charset = FBCharsetBox.Text,
                ConnectionLifetime = (int)FBConnLifetimeBox.Value,
                Pooling = FBPoolingBox.Checked
            };
            Cursor = Cursors.WaitCursor;
            if (SQLHelper.CheckConnection(conn, out message)) {
                MessageBox.Show("Подключение установлено", string.Format("Хост: {0}", AppHelper.Configuration.FBConnection.Datasource),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show(string.Format("Подключение не установлено. Текст ошибки:\r\n{0}", message), string.Format("Хост: {0}",
                    AppHelper.Configuration.FBConnection.Datasource), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Cursor = Cursors.Default;
        }

        // Тест подключения к Exchange серверу
        private void ExchangeTestButton_Click(object sender, EventArgs e) {
            string message;

            Configuration.Exchange ex = new Configuration.Exchange() {
                ServerName = ExServerNameBox.Text,
                Domain = ExDomainBox.Text,
                Username = ExUsernameBox.Text,
                Password = ExPassBox.Text,
                SenderName = ExSenderBox.Text,
                MessageRegex = ExRegexBox.Text
            };
            Cursor = Cursors.WaitCursor;
            if (ExchangeMailHelper.CheckConnection(ex, out message)) {
                MessageBox.Show("Подключение установлено", string.Format("Хост: {0}", AppHelper.Configuration.Exchange.ServerName),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show(string.Format("Подключение не установлено. Текст ошибки:\r\n{0}", message), string.Format("Хост: {0}",
                    AppHelper.Configuration.Exchange.ServerName), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Cursor = Cursors.Default;
        }
    }
}
