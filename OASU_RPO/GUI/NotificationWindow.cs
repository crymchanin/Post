using Feodosiya.Lib.InteropServices;
using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;


namespace OASU_RPO.GUI {
    public partial class NotificationWindow : Form {

        private DialogTypes _dialogType = DialogTypes.Information;
        private int _lifeTime = 10;
        private int _time = 0;
        private bool _noClose = false;
        private bool _beep = false;

        /// <summary>
        /// Задает константы, определяющие отображаемые сведения
        /// </summary>
        public enum DialogTypes {
            /// <summary>
            /// Информационное окно
            /// </summary>
            Information,
            /// <summary>
            /// Окно с предупреждением
            /// </summary>
            Warning,
            /// <summary>
            /// Окно об ошибке
            /// </summary>
            Error
        }

        /// <summary>
        /// Инициализирует новый объект класса NotificationWindow
        /// </summary>
        public NotificationWindow() {
            InitializeComponent();
        }

        /// <summary>
        /// Инициализирует новый объект класса NotificationWindow и задает время его существования
        /// </summary>
        /// <param name="lifeTime">Время существования</param>
        public NotificationWindow(int lifeTime) : this() {
            _lifeTime = Math.Max(lifeTime, 1);
            TimerLabel.Text = string.Format("Закрытие через {0} сек.", _lifeTime);
            MainTimer.Enabled = true;
        }

        /// <summary>
        /// Инициализирует новый объект класса NotificationWindow и назначает ему родительское окно
        /// </summary>
        /// <param name="owner">Родительская форма</param>
        public NotificationWindow(Form owner) : this() {
            Owner = owner;
        }

        /// <summary>
        /// Инициализирует новый объект класса NotificationWindow, назначает ему родительское окно и задает время его существования
        /// </summary>
        /// <param name="owner">Родительская форма</param>
        /// <param name="lifeTime">Время существования</param>
        public NotificationWindow(Form owner, int lifeTime) : this(owner) {
            _lifeTime = Math.Max(lifeTime, 1);
            TimerLabel.Text = string.Format("Закрытие через {0} сек.", _lifeTime);
            MainTimer.Enabled = true;
        }

        /// <summary>
        /// Показывает форму с указанным владельцем пользователю
        /// </summary>
        /// <param name="owner">Любой объект, который реализует System.Windows.Forms.IWin32Window, представляющий окно верхнего уровня, которое станет владельцем этой формы.</param>
        public new void Show(IWin32Window owner) {
            if (!Visible) {
                base.Show(owner);
            }

            if (SoundNotifications) {
                if (DialogType == DialogTypes.Error) {
                    SoundPlayer player;
                    if (File.Exists(Path.Combine(Program.CurrentDirectory, "error.wav"))) {
                        player = new SoundPlayer(Path.Combine(Program.CurrentDirectory, "error.wav"));
                    }
                    else {
                        player = new SoundPlayer(Properties.Resources.error);
                    }
                    player.Play();
                }
                else if (DialogType == DialogTypes.Warning) {
                    SoundPlayer player;
                    if (File.Exists(Path.Combine(Program.CurrentDirectory, "warning.wav"))) {
                        player = new SoundPlayer(Path.Combine(Program.CurrentDirectory, "warning.wav"));
                    }
                    else {
                        player = new SoundPlayer(Properties.Resources.warning);
                    }
                    player.Play();
                }
            }
        }

        /// <summary>
        /// Задает или возвращает текст данного окна
        /// </summary>
        public new string Text {
            get {
                return TextLabel.Text;
            }
            set {
                TextLabel.Text = value;
            }
        }

        /// <summary>
        /// Задает или возвращает текст сообщения данного окна
        /// </summary>
        public string Message {
            get {
                return InformationBox.Text;
            }
            set {
                InformationBox.Text = value;
            }
        }

        /// <summary>
        /// Задает или возвращает тип данного окна
        /// </summary>
        public DialogTypes DialogType {
            get {
                return _dialogType;
            }
            set {
                _dialogType = value;
                switch (_dialogType) {
                    case DialogTypes.Information:
                        HeaderPanel.BackColor = Color.SkyBlue;
                        InformationBox.ForeColor = Color.Black;
                        break;
                    case DialogTypes.Warning:
                        HeaderPanel.BackColor = Color.Orange;
                        InformationBox.ForeColor = Color.Black;
                        break;
                    case DialogTypes.Error:
                        HeaderPanel.BackColor = Color.Salmon;
                        InformationBox.ForeColor = Color.Red;
                        break;
                }
            }
        }

        /// <summary>
        /// Определяет какое действие выполнять при закрытии окна: закрывать окончательно или скрывать
        /// </summary>
        public bool NoClose {
            get {
                return _noClose;
            }
            set {
                _noClose = value;
            }
        }

        /// <summary>
        /// Если установлено в true, то при появлении окна будет воспроизведен звук соответствующий типу отображаемого окна
        /// </summary>
        public bool SoundNotifications {
            get {
                return _beep;
            }
            set {
                _beep = value;
            }
        }

        /// <summary>
        /// Скрывает либо закрывает окно
        /// </summary>
        public void HideDialog() {
            if (NoClose) {
                Hide();
            }
            else {
                Close();
            }
        }

        /// <summary>
        /// Обработчик события закрытия окна
        /// </summary>
        private void CloseBox_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                HideDialog();
            }
        }

        /// <summary>
        /// Обработчик события перемещения окна
        /// </summary>
        private void HeaderPanel_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                Win32ApiHelper.ReleaseCapture();
                Win32ApiHelper.SendMessage(Handle, Win32ApiHelper.WM_NCLBUTTONDOWN, Win32ApiHelper.HT_CAPTION, 0);
            }
        }

        /// <summary>
        /// Обработчик события тика таймера
        /// </summary>
        private void MainTimer_Tick(object sender, EventArgs e) {
            _time++;
            TimerLabel.Text = string.Format("Закрытие через {0} сек.", _lifeTime - _time);

            if (_time >= _lifeTime) {
                HideDialog();
            }
        }

    }
}
