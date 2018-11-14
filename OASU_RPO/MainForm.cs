#define DEBUG

using Feodosiya.Lib.Conf;
using Feodosiya.Lib.InteropServices;
using Feodosiya.Lib.IO;
using Feodosiya.Lib.Math;
using Feodosiya.Lib.Security;
using Feodosiya.Lib.Threading;
using OASU_RPO.Configuration;
using OASU_RPO.GUI;
using OASU_RPO.ru.crimeanpost;
using OASU_RPO.Updates;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Drawing = System.Drawing;


namespace OASU_RPO {
    public partial class MainForm : Form {

        private static bool Initialized = false;

        private static bool RunOnce = false;

        private volatile bool IsRunning = false;

        private static Assembly ExecutingAssembly = Assembly.GetExecutingAssembly();

        private static string CD = IOHelper.GetCurrentDir(ExecutingAssembly);

        private static NotificationWindow notifyWindow;


        // Проверка файлов
        private void CheckFiles() {
            try {
                IsRunning = true;
                DateTime begin = DateTime.Now.AddDays(AppHelper.Configuration.Global.SearchDaysCount.ToNegative());

                ShowMessage("Получение списка созданных файлов ОАСУ РПО...");
                List<FileInfo> files = SQLHelper.GetCreatedFiles(AppHelper.Configuration.Global.SearchDaysCount).ToList();
                List<string> msgFiles = new List<string>();
                ShowMessage("Получение списка отправленных файлов ОАСУ РПО...");
                ItemType[] messages = ExchangeMailHelper.GetMessages(begin);

                foreach (ItemType item in messages) {
                    Match match = new Regex(AppHelper.Configuration.Exchange.MessageRegex).Match(item.Subject);
                    if (match.Success) {
                        msgFiles.Add(match.Groups["FILE"].Value);
                    }
                }

                ShowMessage("Проверка успешно отправленных файлов ОАСУ РПО...");
                List<ListViewItem> items = new List<ListViewItem>();
                FilesBox.InvokeIfRequired(() => FilesBox.Items.Clear());
                string message = "";
                foreach (FileInfo file in files) {
                    if (string.IsNullOrEmpty(msgFiles.Find(x => x == file.FileName))) {
                        ListViewItem item = new ListViewItem(file.FileName);
                        item.SubItems.Add(file.TimeEnd.ToString());
                        items.Add(item);
                        message += string.Format("{0}\t{1}\r\n", file.FileName, file.TimeEnd);
                    }
                }

                int count = items.Count;
                FilesBox.InvokeIfRequired(() => FilesBox.Items.AddRange(items.ToArray()));

                if (count > 0) {
                    notifyWindow.InvokeIfRequired(() => notifyWindow.Message = message);
                    this.InvokeIfRequired(delegate {
                        Drawing.Rectangle workingArea = Screen.GetWorkingArea(this);
                        notifyWindow.Location = new Drawing.Point(workingArea.Right - notifyWindow.Size.Width, workingArea.Bottom - notifyWindow.Size.Height);
                        notifyWindow.Show(this);
                    });
                }
                else {
                    notifyWindow.InvokeIfRequired(delegate {
                        notifyWindow.Message = "";
                        notifyWindow.HideDialog();
                    });
                }
                
                ShowMessage(string.Format("Неотправленные файлы за период ({0} - {1}): {2} шт.", begin.ToString("dd.MM.yyyy"), DateTime.Now.ToString("dd.MM.yyyy"), count), (count > 0));
            }
            catch (Exception error) {
                ShowMessage("Ошибка", true);
                AppHelper.Log.Write("Ошибка во время операции проверки: " + error.ToString(), Feodosiya.Lib.Logs.MessageType.Error);
            }
            finally {
                IsRunning = false;

                ManualExecButton.InvokeIfRequired(() => ManualExecButton.Enabled = true);
                SettingsButton.InvokeIfRequired(() => SettingsButton.Enabled = true);
                FilesBox.InvokeIfRequired(() => FilesBox.Enabled = true);
                MainStrip.InvokeIfRequired(() => LastOperationLabel.Text = DateTime.Now.ToString());
            }
        }

        // Запуск проверки в потоке
        private void ExecCheck() {
            try {
                ManualExecButton.Enabled = false;
                SettingsButton.Enabled = false;

                Thread thread = new Thread(() => CheckFiles());
                thread.Start();
            }
            catch (Exception error) {
                ShowMessage("Ошибка", true);
                AppHelper.Log.Write("Ошибка во время операции проверки: " + error.ToString(), Feodosiya.Lib.Logs.MessageType.Error);
            }
        }

        // Инициализация
        private bool Init() {
            AppHelper.ConfHelper = new ConfHelper(Path.Combine(CD, "settings.conf"));
            AppHelper.Configuration = AppHelper.ConfHelper.LoadConfig<Config>();
            if (!AppHelper.ConfHelper.Success) {
                MessageBox.Show("Ошибка загрузки конфигурации:\r\n" + AppHelper.ConfHelper.LastError.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppHelper.Log.Write("Ошибка загрузки конфигурации: " + AppHelper.ConfHelper.LastError.ToString(), Feodosiya.Lib.Logs.MessageType.Error);
                if (AppHelper.ConfHelper.LastError is System.IO.FileNotFoundException ||
                    AppHelper.ConfHelper.LastError is System.Runtime.Serialization.SerializationException) {

                    if (MessageBox.Show("Создать файл конфигурации по умолчанию?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                        AppHelper.Configuration = new Config();
                        AppHelper.ConfHelper.SaveConfig(AppHelper.Configuration);
                    }
                    else {
                        Load += (s, e) => Application.Exit();
                        return false;
                    }
                }
                else {
                    Load += (s, e) => Application.Exit();
                    return false;
                }     
            }

            if (AppHelper.Configuration.Global.CheckUpdates) {
                try {
                    if (UpdatesHelper.CheckUpdates(FileVersionInfo.GetVersionInfo(ExecutingAssembly.Location).FileVersion)) {
                        UpdatesHelper.DownloadPackage();

                        Load += (s, e) => Application.Exit();
                        return false;
                    }
                }
                catch (Exception ex) {
                    AppHelper.Log.Write("Ошибка проверки обновлений: " + ex.ToString(), Feodosiya.Lib.Logs.MessageType.Error);
                }
            }

            AppHelper.Configuration.SingletonEvent.PropertyChangedEvent += new ChangeEventHandler(OnCofigurationChanged);

            StringHelper.Encoding = Encoding.UTF8;
            StringHelper.PassPhrase = AppHelper.GUID;

            try {
                string path = Assembly.GetExecutingAssembly().Location;

                if (AppHelper.Configuration.Global.EnableAutorun) {
                    Feodosiya.Lib.App.AppHelper.AddToAutorun(path);
                }
                else {
                    Feodosiya.Lib.App.AppHelper.RemoveFromAutorun(path);
                }
            }
            catch { }

            return true;
        }

        public MainForm() {
            try {
                InitializeComponent();

                Initialized = Init();
                if (!Initialized) {
                    return;
                }

                MainTimer.Interval = AppHelper.Configuration.Global.ShedulerInterval;

                notifyWindow = new NotificationWindow(this);
                notifyWindow.DialogType = NotificationWindow.DialogTypes.Error;
                notifyWindow.Text = "Неотправленные файлы ОАСУ РПО";
                notifyWindow.NoClose = true;
                notifyWindow.SoundNotifications = AppHelper.Configuration.Global.SoundNotifications;
                notifyWindow.Owner = null;
                notifyWindow.Opacity = ((double)AppHelper.Configuration.Global.NotifyWindowOpacity) / 100D;
            }
            catch (Exception error) {
                AppHelper.Log.Write("Ошибка: " + error.ToString(), Feodosiya.Lib.Logs.MessageType.Error);
                MessageBox.Show(error.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Отображение сообщений
        private void ShowMessage(string text, bool isError = false) {
            Drawing.Color color = (isError) ? Drawing.Color.Red : Drawing.Color.Green;

            MainStrip.InvokeIfRequired(delegate {
                StatusLabel.Text = text;
                StatusLabel.ForeColor = color;
            });
        }

        // Обработка события изменения конфигурации
        private void OnCofigurationChanged(object newValue, object oldValue, string propertyName) {
            switch (propertyName) {
                case "ShedulerInterval":
                    MainTimer.Interval = AppHelper.Configuration.Global.ShedulerInterval;
                    break;
                case "SoundNotifications":
                    notifyWindow.SoundNotifications = AppHelper.Configuration.Global.SoundNotifications;
                    break;
                case "NotifyWindowOpacity":
                    notifyWindow.Opacity = ((double)AppHelper.Configuration.Global.NotifyWindowOpacity) / 100D;
                    break;
            }
        }

        // Запрет на изменение ширины колонок ListView
        private void FilesBox_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e) {
            e.NewWidth = FilesBox.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        // Рисование
        private void MainForm_Paint(object sender, PaintEventArgs e) {
            Drawing.Graphics dc = e.Graphics;
            dc.DrawLine(Drawing.Pens.Gray, 0, 488, 585, 488);
        }

        // Обработка закрытия формы
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                if (MessageBox.Show("Выйти из программы?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    notifyWindow.Owner = null;
                    Application.Exit();
                }
                else {
                    e.Cancel = true;
                }
            }
        }

        // Выполнение проверки по требованию
        private void ManualExecButton_Click(object sender, EventArgs e) {
            ExecCheck();
        }

        // Выполнение проверки по расписанию
        private void MainTimer_Tick(object sender, EventArgs e) {
            ExecCheck();
        }

        // Обработка события двойного клика мыши по иконке в трее
        private void MainNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
            ShowInTaskbar = true;
            Show();
        }

        // Обработка события открытия контесктного меню
        private void NotifyMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            ShowItem.Enabled = !Visible;
            ManualExecItem.Enabled = !IsRunning;
        }

        // Обработка события нажатия кнопки контекстного меню Развернуть
        private void ShowItem_Click(object sender, EventArgs e) {
            ShowInTaskbar = true;
            Show();
        }

        // Обработка события нажатия кнопки проверки по требованию
        private void ManualExecItem_Click(object sender, EventArgs e) {
            ExecCheck();
        }

        // Обработка события нажатия кнопки контекстного меню Выйти
        private void ExitItem_Click(object sender, EventArgs e) {
            Close();
        }

        // Обработка события нажатия кнопки настроек
        private void SettingsButton_Click(object sender, EventArgs e) {
            AdminWindow window = new AdminWindow();
            if (window.ShowDialog() == DialogResult.OK) {
                SettingsWindow settingsWindow = new SettingsWindow();
                settingsWindow.ShowDialog();
            }
        }

        // Обработка события нажатия кнопки О программе
        private void AboutButton_Click(object sender, EventArgs e) {
            AboutWindow window = new AboutWindow();
            window.ShowDialog();
        }

        // Сворачивание и разворачивание в трее
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m) {
            if (m.Msg == winuser_h.WM_SYSCOMMAND && notifyWindow != null) {
                if (m.WParam.ToInt32() == winuser_h.SC_MINIMIZE) {
                    notifyWindow.Owner = null;

                    this.InvokeIfRequired(() => Win32ApiHelper.ShowWindow(Handle, winuser_h.SW_HIDE));
                    ShowInTaskbar = false;
                }
                if (m.WParam.ToInt32() == winuser_h.SC_RESTORE) {
                    notifyWindow.Owner = null;
                    notifyWindow.WindowState = FormWindowState.Normal;
                }
            }
            base.WndProc(ref m);
        }

        // Скрытие формы при запуске
        protected override void SetVisibleCore(bool value) {
            if (!RunOnce && Initialized) {
                value = !AppHelper.Configuration.Global.RunMinimized;
                RunOnce = true;
            }

            base.SetVisibleCore(value);
        }
    }
}
