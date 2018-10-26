namespace OASU_RPO.GUI {
    partial class SettingsWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.GlobalPage = new System.Windows.Forms.TabPage();
            this.RunAndUpdatesBox = new System.Windows.Forms.GroupBox();
            this.UpdatesBox = new System.Windows.Forms.TextBox();
            this.UpdatesLabel = new System.Windows.Forms.Label();
            this.CheckUpdatesBox = new System.Windows.Forms.CheckBox();
            this.AutorunBox = new System.Windows.Forms.CheckBox();
            this.RunAndUpdatesButton = new System.Windows.Forms.Button();
            this.MinimizedBox = new System.Windows.Forms.CheckBox();
            this.InterfaceBox = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.OpacityBox = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.SoundNotificationsBox = new System.Windows.Forms.CheckBox();
            this.InterfaceButton = new System.Windows.Forms.Button();
            this.ShedulerGroupBox = new System.Windows.Forms.GroupBox();
            this.MsTimespanLabel = new System.Windows.Forms.Label();
            this.ShedulerBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.ShedulerButton = new System.Windows.Forms.Button();
            this.FbConnectionPage = new System.Windows.Forms.TabPage();
            this.FBGroupBox = new System.Windows.Forms.GroupBox();
            this.FBTestButton = new System.Windows.Forms.Button();
            this.FBButton = new System.Windows.Forms.Button();
            this.FBPoolingBox = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.FBConnLifetimeBox = new System.Windows.Forms.NumericUpDown();
            this.FBCharsetBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.FBPasswordBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.FBUsernameBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.FBDatabaseBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FBDatasourceBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ExchangePage = new System.Windows.Forms.TabPage();
            this.ExchangeGroupBox = new System.Windows.Forms.GroupBox();
            this.ExchangeTestButton = new System.Windows.Forms.Button();
            this.ExRegexBox = new System.Windows.Forms.TextBox();
            this.ExchangeButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.ExSenderBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ExPassBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ExUsernameBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ExDomainBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ExServerNameBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.AdminPage = new System.Windows.Forms.TabPage();
            this.RootCredentialsGroupBox = new System.Windows.Forms.GroupBox();
            this.RootCredentialsButton = new System.Windows.Forms.Button();
            this.RootPasswordBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RootNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchDaysCountBox = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.MainTabControl.SuspendLayout();
            this.GlobalPage.SuspendLayout();
            this.RunAndUpdatesBox.SuspendLayout();
            this.InterfaceBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OpacityBox)).BeginInit();
            this.ShedulerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShedulerBox)).BeginInit();
            this.FbConnectionPage.SuspendLayout();
            this.FBGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FBConnLifetimeBox)).BeginInit();
            this.ExchangePage.SuspendLayout();
            this.ExchangeGroupBox.SuspendLayout();
            this.AdminPage.SuspendLayout();
            this.RootCredentialsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchDaysCountBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.GlobalPage);
            this.MainTabControl.Controls.Add(this.FbConnectionPage);
            this.MainTabControl.Controls.Add(this.ExchangePage);
            this.MainTabControl.Controls.Add(this.AdminPage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(534, 462);
            this.MainTabControl.TabIndex = 0;
            // 
            // GlobalPage
            // 
            this.GlobalPage.Controls.Add(this.RunAndUpdatesBox);
            this.GlobalPage.Controls.Add(this.InterfaceBox);
            this.GlobalPage.Controls.Add(this.ShedulerGroupBox);
            this.GlobalPage.Location = new System.Drawing.Point(4, 22);
            this.GlobalPage.Name = "GlobalPage";
            this.GlobalPage.Padding = new System.Windows.Forms.Padding(3);
            this.GlobalPage.Size = new System.Drawing.Size(526, 436);
            this.GlobalPage.TabIndex = 0;
            this.GlobalPage.Text = "Общие";
            this.GlobalPage.UseVisualStyleBackColor = true;
            // 
            // RunAndUpdatesBox
            // 
            this.RunAndUpdatesBox.Controls.Add(this.UpdatesBox);
            this.RunAndUpdatesBox.Controls.Add(this.UpdatesLabel);
            this.RunAndUpdatesBox.Controls.Add(this.CheckUpdatesBox);
            this.RunAndUpdatesBox.Controls.Add(this.AutorunBox);
            this.RunAndUpdatesBox.Controls.Add(this.RunAndUpdatesButton);
            this.RunAndUpdatesBox.Controls.Add(this.MinimizedBox);
            this.RunAndUpdatesBox.Location = new System.Drawing.Point(8, 270);
            this.RunAndUpdatesBox.Name = "RunAndUpdatesBox";
            this.RunAndUpdatesBox.Size = new System.Drawing.Size(510, 158);
            this.RunAndUpdatesBox.TabIndex = 2;
            this.RunAndUpdatesBox.TabStop = false;
            this.RunAndUpdatesBox.Text = "Запуск и обновления";
            // 
            // UpdatesBox
            // 
            this.UpdatesBox.BackColor = System.Drawing.Color.AliceBlue;
            this.UpdatesBox.Enabled = false;
            this.UpdatesBox.Location = new System.Drawing.Point(293, 75);
            this.UpdatesBox.MaxLength = 40;
            this.UpdatesBox.Name = "UpdatesBox";
            this.UpdatesBox.Size = new System.Drawing.Size(206, 20);
            this.UpdatesBox.TabIndex = 3;
            // 
            // UpdatesLabel
            // 
            this.UpdatesLabel.AutoSize = true;
            this.UpdatesLabel.Enabled = false;
            this.UpdatesLabel.Location = new System.Drawing.Point(295, 59);
            this.UpdatesLabel.Name = "UpdatesLabel";
            this.UpdatesLabel.Size = new System.Drawing.Size(107, 13);
            this.UpdatesLabel.TabIndex = 8;
            this.UpdatesLabel.Text = "Сервер обновлений";
            // 
            // CheckUpdatesBox
            // 
            this.CheckUpdatesBox.AutoSize = true;
            this.CheckUpdatesBox.Location = new System.Drawing.Point(293, 35);
            this.CheckUpdatesBox.Name = "CheckUpdatesBox";
            this.CheckUpdatesBox.Size = new System.Drawing.Size(188, 17);
            this.CheckUpdatesBox.TabIndex = 2;
            this.CheckUpdatesBox.Text = "Проверять наличие обновлений";
            this.CheckUpdatesBox.UseVisualStyleBackColor = true;
            this.CheckUpdatesBox.CheckedChanged += new System.EventHandler(this.CheckUpdatesBox_CheckedChanged);
            // 
            // AutorunBox
            // 
            this.AutorunBox.AutoSize = true;
            this.AutorunBox.Location = new System.Drawing.Point(10, 35);
            this.AutorunBox.Name = "AutorunBox";
            this.AutorunBox.Size = new System.Drawing.Size(185, 17);
            this.AutorunBox.TabIndex = 0;
            this.AutorunBox.Text = "Запускать при старте системы";
            this.AutorunBox.UseVisualStyleBackColor = true;
            // 
            // RunAndUpdatesButton
            // 
            this.RunAndUpdatesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RunAndUpdatesButton.Location = new System.Drawing.Point(398, 125);
            this.RunAndUpdatesButton.Name = "RunAndUpdatesButton";
            this.RunAndUpdatesButton.Size = new System.Drawing.Size(102, 23);
            this.RunAndUpdatesButton.TabIndex = 4;
            this.RunAndUpdatesButton.Text = "Изменить";
            this.RunAndUpdatesButton.UseVisualStyleBackColor = true;
            this.RunAndUpdatesButton.Click += new System.EventHandler(this.RunAndUpdatesButton_Click);
            // 
            // MinimizedBox
            // 
            this.MinimizedBox.AutoSize = true;
            this.MinimizedBox.Location = new System.Drawing.Point(10, 58);
            this.MinimizedBox.Name = "MinimizedBox";
            this.MinimizedBox.Size = new System.Drawing.Size(180, 17);
            this.MinimizedBox.TabIndex = 1;
            this.MinimizedBox.Text = "Запускать в фоновом режиме";
            this.MinimizedBox.UseVisualStyleBackColor = true;
            // 
            // InterfaceBox
            // 
            this.InterfaceBox.Controls.Add(this.label16);
            this.InterfaceBox.Controls.Add(this.OpacityBox);
            this.InterfaceBox.Controls.Add(this.label17);
            this.InterfaceBox.Controls.Add(this.SoundNotificationsBox);
            this.InterfaceBox.Controls.Add(this.InterfaceButton);
            this.InterfaceBox.Location = new System.Drawing.Point(8, 139);
            this.InterfaceBox.Name = "InterfaceBox";
            this.InterfaceBox.Size = new System.Drawing.Size(510, 125);
            this.InterfaceBox.TabIndex = 1;
            this.InterfaceBox.TabStop = false;
            this.InterfaceBox.Text = "Интерфейс";
            // 
            // label16
            // 
            this.label16.AutoEllipsis = true;
            this.label16.Location = new System.Drawing.Point(189, 83);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "%";
            // 
            // OpacityBox
            // 
            this.OpacityBox.BackColor = System.Drawing.Color.AliceBlue;
            this.OpacityBox.Location = new System.Drawing.Point(10, 80);
            this.OpacityBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.OpacityBox.Name = "OpacityBox";
            this.OpacityBox.Size = new System.Drawing.Size(173, 20);
            this.OpacityBox.TabIndex = 2;
            this.OpacityBox.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(176, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "Прозрачность окна уведомлений";
            // 
            // SoundNotificationsBox
            // 
            this.SoundNotificationsBox.AutoSize = true;
            this.SoundNotificationsBox.Location = new System.Drawing.Point(10, 35);
            this.SoundNotificationsBox.Name = "SoundNotificationsBox";
            this.SoundNotificationsBox.Size = new System.Drawing.Size(193, 17);
            this.SoundNotificationsBox.TabIndex = 0;
            this.SoundNotificationsBox.Text = "Включить звуковые оповещения";
            this.SoundNotificationsBox.UseVisualStyleBackColor = true;
            // 
            // InterfaceButton
            // 
            this.InterfaceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.InterfaceButton.Location = new System.Drawing.Point(398, 92);
            this.InterfaceButton.Name = "InterfaceButton";
            this.InterfaceButton.Size = new System.Drawing.Size(102, 23);
            this.InterfaceButton.TabIndex = 3;
            this.InterfaceButton.Text = "Изменить";
            this.InterfaceButton.UseVisualStyleBackColor = true;
            this.InterfaceButton.Click += new System.EventHandler(this.InterfaceButton_Click);
            // 
            // ShedulerGroupBox
            // 
            this.ShedulerGroupBox.Controls.Add(this.label19);
            this.ShedulerGroupBox.Controls.Add(this.SearchDaysCountBox);
            this.ShedulerGroupBox.Controls.Add(this.label18);
            this.ShedulerGroupBox.Controls.Add(this.MsTimespanLabel);
            this.ShedulerGroupBox.Controls.Add(this.ShedulerBox);
            this.ShedulerGroupBox.Controls.Add(this.label3);
            this.ShedulerGroupBox.Controls.Add(this.ShedulerButton);
            this.ShedulerGroupBox.Location = new System.Drawing.Point(8, 13);
            this.ShedulerGroupBox.Name = "ShedulerGroupBox";
            this.ShedulerGroupBox.Size = new System.Drawing.Size(510, 120);
            this.ShedulerGroupBox.TabIndex = 0;
            this.ShedulerGroupBox.TabStop = false;
            this.ShedulerGroupBox.Text = "Планировщик";
            // 
            // MsTimespanLabel
            // 
            this.MsTimespanLabel.AutoEllipsis = true;
            this.MsTimespanLabel.Location = new System.Drawing.Point(189, 47);
            this.MsTimespanLabel.Name = "MsTimespanLabel";
            this.MsTimespanLabel.Size = new System.Drawing.Size(98, 13);
            this.MsTimespanLabel.TabIndex = 2;
            this.MsTimespanLabel.Text = "мс";
            // 
            // ShedulerBox
            // 
            this.ShedulerBox.BackColor = System.Drawing.Color.AliceBlue;
            this.ShedulerBox.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ShedulerBox.Location = new System.Drawing.Point(10, 44);
            this.ShedulerBox.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.ShedulerBox.Minimum = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            this.ShedulerBox.Name = "ShedulerBox";
            this.ShedulerBox.Size = new System.Drawing.Size(173, 20);
            this.ShedulerBox.TabIndex = 0;
            this.ShedulerBox.Value = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            this.ShedulerBox.ValueChanged += new System.EventHandler(this.ShedulerBox_ValueChanged);
            this.ShedulerBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ShedulerBox_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Интервал";
            // 
            // ShedulerButton
            // 
            this.ShedulerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ShedulerButton.Location = new System.Drawing.Point(398, 87);
            this.ShedulerButton.Name = "ShedulerButton";
            this.ShedulerButton.Size = new System.Drawing.Size(102, 23);
            this.ShedulerButton.TabIndex = 2;
            this.ShedulerButton.Text = "Изменить";
            this.ShedulerButton.UseVisualStyleBackColor = true;
            this.ShedulerButton.Click += new System.EventHandler(this.ShedulerButton_Click);
            // 
            // FbConnectionPage
            // 
            this.FbConnectionPage.Controls.Add(this.FBGroupBox);
            this.FbConnectionPage.Location = new System.Drawing.Point(4, 22);
            this.FbConnectionPage.Name = "FbConnectionPage";
            this.FbConnectionPage.Padding = new System.Windows.Forms.Padding(3);
            this.FbConnectionPage.Size = new System.Drawing.Size(526, 436);
            this.FbConnectionPage.TabIndex = 1;
            this.FbConnectionPage.Text = "Подключение к БД";
            this.FbConnectionPage.UseVisualStyleBackColor = true;
            // 
            // FBGroupBox
            // 
            this.FBGroupBox.Controls.Add(this.FBTestButton);
            this.FBGroupBox.Controls.Add(this.FBButton);
            this.FBGroupBox.Controls.Add(this.FBPoolingBox);
            this.FBGroupBox.Controls.Add(this.label9);
            this.FBGroupBox.Controls.Add(this.FBConnLifetimeBox);
            this.FBGroupBox.Controls.Add(this.FBCharsetBox);
            this.FBGroupBox.Controls.Add(this.label8);
            this.FBGroupBox.Controls.Add(this.FBPasswordBox);
            this.FBGroupBox.Controls.Add(this.label6);
            this.FBGroupBox.Controls.Add(this.FBUsernameBox);
            this.FBGroupBox.Controls.Add(this.label7);
            this.FBGroupBox.Controls.Add(this.FBDatabaseBox);
            this.FBGroupBox.Controls.Add(this.label4);
            this.FBGroupBox.Controls.Add(this.FBDatasourceBox);
            this.FBGroupBox.Controls.Add(this.label5);
            this.FBGroupBox.Location = new System.Drawing.Point(8, 6);
            this.FBGroupBox.Name = "FBGroupBox";
            this.FBGroupBox.Size = new System.Drawing.Size(510, 244);
            this.FBGroupBox.TabIndex = 0;
            this.FBGroupBox.TabStop = false;
            this.FBGroupBox.Text = "Настройки подключения к БД";
            // 
            // FBTestButton
            // 
            this.FBTestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FBTestButton.Location = new System.Drawing.Point(10, 211);
            this.FBTestButton.Name = "FBTestButton";
            this.FBTestButton.Size = new System.Drawing.Size(149, 23);
            this.FBTestButton.TabIndex = 8;
            this.FBTestButton.Text = "Тест подключения";
            this.FBTestButton.UseVisualStyleBackColor = true;
            this.FBTestButton.Click += new System.EventHandler(this.FBTestButton_Click);
            // 
            // FBButton
            // 
            this.FBButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FBButton.Location = new System.Drawing.Point(398, 211);
            this.FBButton.Name = "FBButton";
            this.FBButton.Size = new System.Drawing.Size(102, 23);
            this.FBButton.TabIndex = 7;
            this.FBButton.Text = "Изменить";
            this.FBButton.UseVisualStyleBackColor = true;
            this.FBButton.Click += new System.EventHandler(this.FBButton_Click);
            // 
            // FBPoolingBox
            // 
            this.FBPoolingBox.AutoSize = true;
            this.FBPoolingBox.Location = new System.Drawing.Point(10, 175);
            this.FBPoolingBox.Name = "FBPoolingBox";
            this.FBPoolingBox.Size = new System.Drawing.Size(189, 17);
            this.FBPoolingBox.TabIndex = 6;
            this.FBPoolingBox.Text = "Использовать пул подключений";
            this.FBPoolingBox.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(262, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Таймаут (сек)";
            // 
            // FBConnLifetimeBox
            // 
            this.FBConnLifetimeBox.BackColor = System.Drawing.Color.AliceBlue;
            this.FBConnLifetimeBox.Location = new System.Drawing.Point(260, 134);
            this.FBConnLifetimeBox.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.FBConnLifetimeBox.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.FBConnLifetimeBox.Name = "FBConnLifetimeBox";
            this.FBConnLifetimeBox.Size = new System.Drawing.Size(240, 20);
            this.FBConnLifetimeBox.TabIndex = 5;
            this.FBConnLifetimeBox.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // FBCharsetBox
            // 
            this.FBCharsetBox.BackColor = System.Drawing.Color.AliceBlue;
            this.FBCharsetBox.Location = new System.Drawing.Point(10, 134);
            this.FBCharsetBox.MaxLength = 40;
            this.FBCharsetBox.Name = "FBCharsetBox";
            this.FBCharsetBox.Size = new System.Drawing.Size(240, 20);
            this.FBCharsetBox.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Кодировка";
            // 
            // FBPasswordBox
            // 
            this.FBPasswordBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FBPasswordBox.BackColor = System.Drawing.Color.AliceBlue;
            this.FBPasswordBox.Location = new System.Drawing.Point(260, 90);
            this.FBPasswordBox.MaxLength = 38;
            this.FBPasswordBox.Name = "FBPasswordBox";
            this.FBPasswordBox.Size = new System.Drawing.Size(240, 20);
            this.FBPasswordBox.TabIndex = 3;
            this.FBPasswordBox.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Пароль";
            // 
            // FBUsernameBox
            // 
            this.FBUsernameBox.BackColor = System.Drawing.Color.AliceBlue;
            this.FBUsernameBox.Location = new System.Drawing.Point(10, 90);
            this.FBUsernameBox.MaxLength = 38;
            this.FBUsernameBox.Name = "FBUsernameBox";
            this.FBUsernameBox.Size = new System.Drawing.Size(240, 20);
            this.FBUsernameBox.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Пользователь";
            // 
            // FBDatabaseBox
            // 
            this.FBDatabaseBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FBDatabaseBox.BackColor = System.Drawing.Color.AliceBlue;
            this.FBDatabaseBox.Location = new System.Drawing.Point(260, 46);
            this.FBDatabaseBox.MaxLength = 256;
            this.FBDatabaseBox.Name = "FBDatabaseBox";
            this.FBDatabaseBox.Size = new System.Drawing.Size(240, 20);
            this.FBDatabaseBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Путь к файлу БД (POSTDATA.IB)";
            // 
            // FBDatasourceBox
            // 
            this.FBDatasourceBox.BackColor = System.Drawing.Color.AliceBlue;
            this.FBDatasourceBox.Location = new System.Drawing.Point(10, 46);
            this.FBDatasourceBox.MaxLength = 40;
            this.FBDatasourceBox.Name = "FBDatasourceBox";
            this.FBDatasourceBox.Size = new System.Drawing.Size(240, 20);
            this.FBDatasourceBox.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Имя сервера";
            // 
            // ExchangePage
            // 
            this.ExchangePage.Controls.Add(this.ExchangeGroupBox);
            this.ExchangePage.Location = new System.Drawing.Point(4, 22);
            this.ExchangePage.Name = "ExchangePage";
            this.ExchangePage.Size = new System.Drawing.Size(526, 436);
            this.ExchangePage.TabIndex = 2;
            this.ExchangePage.Text = "Настройки почты";
            this.ExchangePage.UseVisualStyleBackColor = true;
            // 
            // ExchangeGroupBox
            // 
            this.ExchangeGroupBox.Controls.Add(this.ExchangeTestButton);
            this.ExchangeGroupBox.Controls.Add(this.ExRegexBox);
            this.ExchangeGroupBox.Controls.Add(this.ExchangeButton);
            this.ExchangeGroupBox.Controls.Add(this.label10);
            this.ExchangeGroupBox.Controls.Add(this.ExSenderBox);
            this.ExchangeGroupBox.Controls.Add(this.label11);
            this.ExchangeGroupBox.Controls.Add(this.ExPassBox);
            this.ExchangeGroupBox.Controls.Add(this.label12);
            this.ExchangeGroupBox.Controls.Add(this.ExUsernameBox);
            this.ExchangeGroupBox.Controls.Add(this.label13);
            this.ExchangeGroupBox.Controls.Add(this.ExDomainBox);
            this.ExchangeGroupBox.Controls.Add(this.label14);
            this.ExchangeGroupBox.Controls.Add(this.ExServerNameBox);
            this.ExchangeGroupBox.Controls.Add(this.label15);
            this.ExchangeGroupBox.Location = new System.Drawing.Point(8, 3);
            this.ExchangeGroupBox.Name = "ExchangeGroupBox";
            this.ExchangeGroupBox.Size = new System.Drawing.Size(510, 207);
            this.ExchangeGroupBox.TabIndex = 1;
            this.ExchangeGroupBox.TabStop = false;
            this.ExchangeGroupBox.Text = "Настройки почтового сервера Exchange";
            // 
            // ExchangeTestButton
            // 
            this.ExchangeTestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExchangeTestButton.Location = new System.Drawing.Point(10, 174);
            this.ExchangeTestButton.Name = "ExchangeTestButton";
            this.ExchangeTestButton.Size = new System.Drawing.Size(149, 23);
            this.ExchangeTestButton.TabIndex = 7;
            this.ExchangeTestButton.Text = "Тест подключения";
            this.ExchangeTestButton.UseVisualStyleBackColor = true;
            this.ExchangeTestButton.Click += new System.EventHandler(this.ExchangeTestButton_Click);
            // 
            // ExRegexBox
            // 
            this.ExRegexBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExRegexBox.BackColor = System.Drawing.Color.AliceBlue;
            this.ExRegexBox.Location = new System.Drawing.Point(260, 134);
            this.ExRegexBox.MaxLength = 256;
            this.ExRegexBox.Name = "ExRegexBox";
            this.ExRegexBox.Size = new System.Drawing.Size(240, 20);
            this.ExRegexBox.TabIndex = 5;
            // 
            // ExchangeButton
            // 
            this.ExchangeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExchangeButton.Location = new System.Drawing.Point(398, 174);
            this.ExchangeButton.Name = "ExchangeButton";
            this.ExchangeButton.Size = new System.Drawing.Size(102, 23);
            this.ExchangeButton.TabIndex = 6;
            this.ExchangeButton.Text = "Изменить";
            this.ExchangeButton.UseVisualStyleBackColor = true;
            this.ExchangeButton.Click += new System.EventHandler(this.ExchangeButton_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(262, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Регулярное выражение";
            // 
            // ExSenderBox
            // 
            this.ExSenderBox.BackColor = System.Drawing.Color.AliceBlue;
            this.ExSenderBox.Location = new System.Drawing.Point(10, 134);
            this.ExSenderBox.MaxLength = 40;
            this.ExSenderBox.Name = "ExSenderBox";
            this.ExSenderBox.Size = new System.Drawing.Size(240, 20);
            this.ExSenderBox.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Отправитель";
            // 
            // ExPassBox
            // 
            this.ExPassBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExPassBox.BackColor = System.Drawing.Color.AliceBlue;
            this.ExPassBox.Location = new System.Drawing.Point(260, 90);
            this.ExPassBox.MaxLength = 38;
            this.ExPassBox.Name = "ExPassBox";
            this.ExPassBox.Size = new System.Drawing.Size(240, 20);
            this.ExPassBox.TabIndex = 3;
            this.ExPassBox.UseSystemPasswordChar = true;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(262, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Пароль";
            // 
            // ExUsernameBox
            // 
            this.ExUsernameBox.BackColor = System.Drawing.Color.AliceBlue;
            this.ExUsernameBox.Location = new System.Drawing.Point(10, 90);
            this.ExUsernameBox.MaxLength = 38;
            this.ExUsernameBox.Name = "ExUsernameBox";
            this.ExUsernameBox.Size = new System.Drawing.Size(240, 20);
            this.ExUsernameBox.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Пользователь";
            // 
            // ExDomainBox
            // 
            this.ExDomainBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExDomainBox.BackColor = System.Drawing.Color.AliceBlue;
            this.ExDomainBox.Location = new System.Drawing.Point(260, 46);
            this.ExDomainBox.MaxLength = 256;
            this.ExDomainBox.Name = "ExDomainBox";
            this.ExDomainBox.Size = new System.Drawing.Size(240, 20);
            this.ExDomainBox.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(262, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Домен";
            // 
            // ExServerNameBox
            // 
            this.ExServerNameBox.BackColor = System.Drawing.Color.AliceBlue;
            this.ExServerNameBox.Location = new System.Drawing.Point(10, 46);
            this.ExServerNameBox.MaxLength = 40;
            this.ExServerNameBox.Name = "ExServerNameBox";
            this.ExServerNameBox.Size = new System.Drawing.Size(240, 20);
            this.ExServerNameBox.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "Имя сервера";
            // 
            // AdminPage
            // 
            this.AdminPage.Controls.Add(this.RootCredentialsGroupBox);
            this.AdminPage.Location = new System.Drawing.Point(4, 22);
            this.AdminPage.Name = "AdminPage";
            this.AdminPage.Size = new System.Drawing.Size(526, 436);
            this.AdminPage.TabIndex = 3;
            this.AdminPage.Text = "Администрирование";
            this.AdminPage.UseVisualStyleBackColor = true;
            // 
            // RootCredentialsGroupBox
            // 
            this.RootCredentialsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RootCredentialsGroupBox.Controls.Add(this.RootCredentialsButton);
            this.RootCredentialsGroupBox.Controls.Add(this.RootPasswordBox);
            this.RootCredentialsGroupBox.Controls.Add(this.label2);
            this.RootCredentialsGroupBox.Controls.Add(this.RootNameBox);
            this.RootCredentialsGroupBox.Controls.Add(this.label1);
            this.RootCredentialsGroupBox.Location = new System.Drawing.Point(8, 13);
            this.RootCredentialsGroupBox.Name = "RootCredentialsGroupBox";
            this.RootCredentialsGroupBox.Size = new System.Drawing.Size(510, 109);
            this.RootCredentialsGroupBox.TabIndex = 0;
            this.RootCredentialsGroupBox.TabStop = false;
            this.RootCredentialsGroupBox.Text = "Авторизационные данные";
            // 
            // RootCredentialsButton
            // 
            this.RootCredentialsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RootCredentialsButton.Location = new System.Drawing.Point(398, 76);
            this.RootCredentialsButton.Name = "RootCredentialsButton";
            this.RootCredentialsButton.Size = new System.Drawing.Size(102, 23);
            this.RootCredentialsButton.TabIndex = 2;
            this.RootCredentialsButton.Text = "Изменить";
            this.RootCredentialsButton.UseVisualStyleBackColor = true;
            this.RootCredentialsButton.Click += new System.EventHandler(this.RootCredentialsButton_Click);
            // 
            // RootPasswordBox
            // 
            this.RootPasswordBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RootPasswordBox.BackColor = System.Drawing.Color.AliceBlue;
            this.RootPasswordBox.Location = new System.Drawing.Point(260, 44);
            this.RootPasswordBox.MaxLength = 38;
            this.RootPasswordBox.Name = "RootPasswordBox";
            this.RootPasswordBox.Size = new System.Drawing.Size(240, 20);
            this.RootPasswordBox.TabIndex = 1;
            this.RootPasswordBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пароль";
            // 
            // RootNameBox
            // 
            this.RootNameBox.BackColor = System.Drawing.Color.AliceBlue;
            this.RootNameBox.Location = new System.Drawing.Point(10, 44);
            this.RootNameBox.MaxLength = 38;
            this.RootNameBox.Name = "RootNameBox";
            this.RootNameBox.Size = new System.Drawing.Size(240, 20);
            this.RootNameBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // SearchDaysCountBox
            // 
            this.SearchDaysCountBox.BackColor = System.Drawing.Color.AliceBlue;
            this.SearchDaysCountBox.Location = new System.Drawing.Point(293, 44);
            this.SearchDaysCountBox.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.SearchDaysCountBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SearchDaysCountBox.Name = "SearchDaysCountBox";
            this.SearchDaysCountBox.Size = new System.Drawing.Size(91, 20);
            this.SearchDaysCountBox.TabIndex = 1;
            this.SearchDaysCountBox.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(295, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 13);
            this.label18.TabIndex = 4;
            this.label18.Text = "Искать файлы за:";
            // 
            // label19
            // 
            this.label19.AutoEllipsis = true;
            this.label19.Location = new System.Drawing.Point(390, 47);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 13);
            this.label19.TabIndex = 5;
            this.label19.Text = "дней";
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(534, 462);
            this.Controls.Add(this.MainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.MainTabControl.ResumeLayout(false);
            this.GlobalPage.ResumeLayout(false);
            this.RunAndUpdatesBox.ResumeLayout(false);
            this.RunAndUpdatesBox.PerformLayout();
            this.InterfaceBox.ResumeLayout(false);
            this.InterfaceBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OpacityBox)).EndInit();
            this.ShedulerGroupBox.ResumeLayout(false);
            this.ShedulerGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShedulerBox)).EndInit();
            this.FbConnectionPage.ResumeLayout(false);
            this.FBGroupBox.ResumeLayout(false);
            this.FBGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FBConnLifetimeBox)).EndInit();
            this.ExchangePage.ResumeLayout(false);
            this.ExchangeGroupBox.ResumeLayout(false);
            this.ExchangeGroupBox.PerformLayout();
            this.AdminPage.ResumeLayout(false);
            this.RootCredentialsGroupBox.ResumeLayout(false);
            this.RootCredentialsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchDaysCountBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage GlobalPage;
        private System.Windows.Forms.TabPage FbConnectionPage;
        private System.Windows.Forms.TabPage ExchangePage;
        private System.Windows.Forms.TabPage AdminPage;
        private System.Windows.Forms.GroupBox RootCredentialsGroupBox;
        private System.Windows.Forms.TextBox RootPasswordBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RootNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RootCredentialsButton;
        private System.Windows.Forms.GroupBox ShedulerGroupBox;
        private System.Windows.Forms.Button ShedulerButton;
        private System.Windows.Forms.NumericUpDown ShedulerBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox FBGroupBox;
        private System.Windows.Forms.TextBox FBDatabaseBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FBDatasourceBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FBPasswordBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox FBUsernameBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox FBCharsetBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown FBConnLifetimeBox;
        private System.Windows.Forms.CheckBox FBPoolingBox;
        private System.Windows.Forms.Button FBButton;
        private System.Windows.Forms.GroupBox ExchangeGroupBox;
        private System.Windows.Forms.Button ExchangeButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ExSenderBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ExPassBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox ExUsernameBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox ExDomainBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox ExServerNameBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox ExRegexBox;
        private System.Windows.Forms.Label MsTimespanLabel;
        private System.Windows.Forms.GroupBox InterfaceBox;
        private System.Windows.Forms.Button InterfaceButton;
        private System.Windows.Forms.CheckBox SoundNotificationsBox;
        private System.Windows.Forms.CheckBox MinimizedBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown OpacityBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox RunAndUpdatesBox;
        private System.Windows.Forms.Button RunAndUpdatesButton;
        private System.Windows.Forms.CheckBox AutorunBox;
        private System.Windows.Forms.CheckBox CheckUpdatesBox;
        private System.Windows.Forms.TextBox UpdatesBox;
        private System.Windows.Forms.Label UpdatesLabel;
        private System.Windows.Forms.Button FBTestButton;
        private System.Windows.Forms.Button ExchangeTestButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown SearchDaysCountBox;
        private System.Windows.Forms.Label label18;
    }
}