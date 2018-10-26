namespace OASU_RPO {
    partial class MainForm {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ManualExecButton = new System.Windows.Forms.Button();
            this.FilesBox = new System.Windows.Forms.ListView();
            this.FileColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.MainStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.LastOperationLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManualExecItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.AboutButton = new System.Windows.Forms.Button();
            this.MainStrip.SuspendLayout();
            this.NotifyMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ManualExecButton
            // 
            this.ManualExecButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ManualExecButton.Location = new System.Drawing.Point(438, 456);
            this.ManualExecButton.Margin = new System.Windows.Forms.Padding(4);
            this.ManualExecButton.Name = "ManualExecButton";
            this.ManualExecButton.Size = new System.Drawing.Size(140, 26);
            this.ManualExecButton.TabIndex = 0;
            this.ManualExecButton.Text = "Проверить сейчас";
            this.ManualExecButton.UseVisualStyleBackColor = true;
            this.ManualExecButton.Click += new System.EventHandler(this.ManualExecButton_Click);
            // 
            // FilesBox
            // 
            this.FilesBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilesBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileColumn,
            this.DateColumn});
            this.FilesBox.ForeColor = System.Drawing.Color.Red;
            this.FilesBox.FullRowSelect = true;
            this.FilesBox.GridLines = true;
            this.FilesBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.FilesBox.Location = new System.Drawing.Point(5, 5);
            this.FilesBox.Margin = new System.Windows.Forms.Padding(4);
            this.FilesBox.MultiSelect = false;
            this.FilesBox.Name = "FilesBox";
            this.FilesBox.Size = new System.Drawing.Size(573, 445);
            this.FilesBox.TabIndex = 3;
            this.FilesBox.UseCompatibleStateImageBehavior = false;
            this.FilesBox.View = System.Windows.Forms.View.Details;
            this.FilesBox.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.FilesBox_ColumnWidthChanging);
            // 
            // FileColumn
            // 
            this.FileColumn.Tag = "";
            this.FileColumn.Text = "Файл";
            this.FileColumn.Width = 406;
            // 
            // DateColumn
            // 
            this.DateColumn.Tag = "";
            this.DateColumn.Text = "Дата создания";
            this.DateColumn.Width = 138;
            // 
            // MainTimer
            // 
            this.MainTimer.Enabled = true;
            this.MainTimer.Interval = 3600000;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // MainStrip
            // 
            this.MainStrip.BackColor = System.Drawing.Color.White;
            this.MainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.LastOperationLabel});
            this.MainStrip.Location = new System.Drawing.Point(0, 490);
            this.MainStrip.Name = "MainStrip";
            this.MainStrip.Size = new System.Drawing.Size(584, 22);
            this.MainStrip.SizingGrip = false;
            this.MainStrip.TabIndex = 4;
            // 
            // StatusLabel
            // 
            this.StatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StatusLabel.ForeColor = System.Drawing.Color.Green;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(569, 17);
            this.StatusLabel.Spring = true;
            this.StatusLabel.Text = "Готово";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StatusLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // LastOperationLabel
            // 
            this.LastOperationLabel.Name = "LastOperationLabel";
            this.LastOperationLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // MainNotifyIcon
            // 
            this.MainNotifyIcon.ContextMenuStrip = this.NotifyMenuStrip;
            this.MainNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("MainNotifyIcon.Icon")));
            this.MainNotifyIcon.Text = "Проверка файлов ОАСУ РПО";
            this.MainNotifyIcon.Visible = true;
            this.MainNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainNotifyIcon_MouseDoubleClick);
            // 
            // NotifyMenuStrip
            // 
            this.NotifyMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowItem,
            this.ManualExecItem,
            this.toolStripSeparator1,
            this.ExitItem});
            this.NotifyMenuStrip.Name = "NotifyMenuStrip";
            this.NotifyMenuStrip.Size = new System.Drawing.Size(176, 76);
            this.NotifyMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.NotifyMenuStrip_Opening);
            // 
            // ShowItem
            // 
            this.ShowItem.Name = "ShowItem";
            this.ShowItem.Size = new System.Drawing.Size(175, 22);
            this.ShowItem.Text = "Развернуть";
            this.ShowItem.Click += new System.EventHandler(this.ShowItem_Click);
            // 
            // ManualExecItem
            // 
            this.ManualExecItem.Name = "ManualExecItem";
            this.ManualExecItem.Size = new System.Drawing.Size(175, 22);
            this.ManualExecItem.Text = "Проверить сейчас";
            this.ManualExecItem.Click += new System.EventHandler(this.ManualExecItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // ExitItem
            // 
            this.ExitItem.Name = "ExitItem";
            this.ExitItem.Size = new System.Drawing.Size(175, 22);
            this.ExitItem.Text = "Выход";
            this.ExitItem.Click += new System.EventHandler(this.ExitItem_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SettingsButton.Location = new System.Drawing.Point(5, 456);
            this.SettingsButton.Margin = new System.Windows.Forms.Padding(4);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(103, 26);
            this.SettingsButton.TabIndex = 1;
            this.SettingsButton.Text = "Настройки";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AboutButton.Location = new System.Drawing.Point(116, 456);
            this.AboutButton.Margin = new System.Windows.Forms.Padding(4);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(112, 26);
            this.AboutButton.TabIndex = 2;
            this.AboutButton.Text = "О программе";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 512);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.MainStrip);
            this.Controls.Add(this.FilesBox);
            this.Controls.Add(this.ManualExecButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Проверка отправки файлов ОАСУ РПО (DEBUG)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.MainStrip.ResumeLayout(false);
            this.MainStrip.PerformLayout();
            this.NotifyMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ManualExecButton;
        private System.Windows.Forms.ListView FilesBox;
        private System.Windows.Forms.ColumnHeader FileColumn;
        private System.Windows.Forms.ColumnHeader DateColumn;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.StatusStrip MainStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.NotifyIcon MainNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip NotifyMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ShowItem;
        private System.Windows.Forms.ToolStripMenuItem ExitItem;
        private System.Windows.Forms.ToolStripMenuItem ManualExecItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.ToolStripStatusLabel LastOperationLabel;
    }
}

