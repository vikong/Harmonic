namespace FolderChecker
{
	partial class MainForm
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.FolderGridView = new System.Windows.Forms.DataGridView();
			this.gridContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.offToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.onToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.редактированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.appendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveTimer = new System.Windows.Forms.Timer(this.components);
			this.CheckButton = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.CheckAllButton = new System.Windows.Forms.Button();
			this.autoPictureBox = new System.Windows.Forms.PictureBox();
			this.SettingsButton = new System.Windows.Forms.Button();
			this.mainContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.SettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.eMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.paramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.проверкаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.allToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.currentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.FoldrCheckBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.checkTimer = new System.Windows.Forms.Timer(this.components);
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.FolderBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.helpProvider = new System.Windows.Forms.HelpProvider();
			((System.ComponentModel.ISupportInitialize)(this.FolderGridView)).BeginInit();
			this.gridContextMenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.autoPictureBox)).BeginInit();
			this.mainContextMenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.FolderBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// FolderGridView
			// 
			this.FolderGridView.AllowUserToAddRows = false;
			this.FolderGridView.AllowUserToDeleteRows = false;
			this.FolderGridView.AllowUserToOrderColumns = true;
			this.FolderGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FolderGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.FolderGridView.ContextMenuStrip = this.gridContextMenuStrip;
			this.helpProvider.SetHelpKeyword(this.FolderGridView, "folderGrid");
			this.helpProvider.SetHelpString(this.FolderGridView, "Список проверяемых папок");
			this.FolderGridView.Location = new System.Drawing.Point(0, 1);
			this.FolderGridView.Name = "FolderGridView";
			this.FolderGridView.ReadOnly = true;
			this.FolderGridView.RowHeadersVisible = false;
			this.helpProvider.SetShowHelp(this.FolderGridView, true);
			this.FolderGridView.Size = new System.Drawing.Size(735, 232);
			this.FolderGridView.TabIndex = 0;
			this.FolderGridView.VirtualMode = true;
			this.FolderGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.FolderGridView_CellMouseDown);
			this.FolderGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.FolderGridView_CellValueNeeded);
			this.FolderGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.FolderGridView_RowPrePaint);
			this.FolderGridView.DoubleClick += new System.EventHandler(this.FolderGridView_DoubleClick);
			// 
			// gridContextMenuStrip
			// 
			this.gridContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.offToolStripMenuItem,
            this.onToolStripMenuItem,
            this.редактированиеToolStripMenuItem});
			this.gridContextMenuStrip.Name = "gridContextMenuStrip";
			this.gridContextMenuStrip.Size = new System.Drawing.Size(164, 70);
			// 
			// offToolStripMenuItem
			// 
			this.offToolStripMenuItem.Name = "offToolStripMenuItem";
			this.offToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.offToolStripMenuItem.Text = "Отключить";
			this.offToolStripMenuItem.Click += new System.EventHandler(this.offToolStripMenuItem_Click);
			// 
			// onToolStripMenuItem
			// 
			this.onToolStripMenuItem.Name = "onToolStripMenuItem";
			this.onToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.onToolStripMenuItem.Text = "Включить";
			this.onToolStripMenuItem.Click += new System.EventHandler(this.onToolStripMenuItem_Click);
			// 
			// редактированиеToolStripMenuItem
			// 
			this.редактированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.appendToolStripMenuItem,
            this.editToolStripMenuItem});
			this.редактированиеToolStripMenuItem.Name = "редактированиеToolStripMenuItem";
			this.редактированиеToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.редактированиеToolStripMenuItem.Text = "Редактирование";
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
			this.deleteToolStripMenuItem.Text = "Удалить";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// appendToolStripMenuItem
			// 
			this.appendToolStripMenuItem.Name = "appendToolStripMenuItem";
			this.appendToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
			this.appendToolStripMenuItem.Text = "Добавить";
			this.appendToolStripMenuItem.Click += new System.EventHandler(this.appendToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
			this.editToolStripMenuItem.Text = "Изменить";
			this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
			// 
			// SaveTimer
			// 
			this.SaveTimer.Interval = 300000;
			this.SaveTimer.Tick += new System.EventHandler(this.SaveTimer_Tick);
			// 
			// CheckButton
			// 
			this.CheckButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CheckButton.Image = global::FolderChecker.Properties.Resources.check_one;
			this.CheckButton.Location = new System.Drawing.Point(741, 129);
			this.CheckButton.Name = "CheckButton";
			this.CheckButton.Size = new System.Drawing.Size(36, 36);
			this.CheckButton.TabIndex = 2;
			this.toolTip1.SetToolTip(this.CheckButton, "Проверить текущее расположение");
			this.CheckButton.UseVisualStyleBackColor = true;
			this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
			// 
			// CheckAllButton
			// 
			this.CheckAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CheckAllButton.Image = global::FolderChecker.Properties.Resources.Check_all_24;
			this.CheckAllButton.Location = new System.Drawing.Point(741, 190);
			this.CheckAllButton.Name = "CheckAllButton";
			this.CheckAllButton.Size = new System.Drawing.Size(36, 36);
			this.CheckAllButton.TabIndex = 3;
			this.toolTip1.SetToolTip(this.CheckAllButton, "Проверить все");
			this.CheckAllButton.UseVisualStyleBackColor = true;
			this.CheckAllButton.Click += new System.EventHandler(this.CheckAllButton_Click);
			// 
			// autoPictureBox
			// 
			this.autoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.autoPictureBox.Image = global::FolderChecker.Properties.Resources.pause_24;
			this.autoPictureBox.Location = new System.Drawing.Point(741, 7);
			this.autoPictureBox.Name = "autoPictureBox";
			this.autoPictureBox.Size = new System.Drawing.Size(36, 36);
			this.autoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.autoPictureBox.TabIndex = 5;
			this.autoPictureBox.TabStop = false;
			this.toolTip1.SetToolTip(this.autoPictureBox, "Проверка по таймеру");
			// 
			// SettingsButton
			// 
			this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SettingsButton.ContextMenuStrip = this.mainContextMenuStrip;
			this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SettingsButton.Image = global::FolderChecker.Properties.Resources.Settings_24;
			this.SettingsButton.Location = new System.Drawing.Point(741, 68);
			this.SettingsButton.Name = "SettingsButton";
			this.SettingsButton.Size = new System.Drawing.Size(36, 36);
			this.SettingsButton.TabIndex = 1;
			this.toolTip1.SetToolTip(this.SettingsButton, "Настройки");
			this.SettingsButton.UseVisualStyleBackColor = true;
			this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
			// 
			// mainContextMenuStrip
			// 
			this.mainContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingToolStripMenuItem,
            this.проверкаToolStripMenuItem1});
			this.mainContextMenuStrip.Name = "mainContextMenuStrip";
			this.mainContextMenuStrip.Size = new System.Drawing.Size(135, 48);
			// 
			// SettingToolStripMenuItem
			// 
			this.SettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eMailToolStripMenuItem,
            this.paramsToolStripMenuItem});
			this.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem";
			this.SettingToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.SettingToolStripMenuItem.Text = "Настройки";
			// 
			// eMailToolStripMenuItem
			// 
			this.eMailToolStripMenuItem.Name = "eMailToolStripMenuItem";
			this.eMailToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.eMailToolStripMenuItem.Text = "E-Mail";
			this.eMailToolStripMenuItem.Click += new System.EventHandler(this.eMailToolStripMenuItem_Click);
			// 
			// paramsToolStripMenuItem
			// 
			this.paramsToolStripMenuItem.Name = "paramsToolStripMenuItem";
			this.paramsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.paramsToolStripMenuItem.Text = "Параметры";
			this.paramsToolStripMenuItem.Click += new System.EventHandler(this.paramsToolStripMenuItem_Click);
			// 
			// проверкаToolStripMenuItem1
			// 
			this.проверкаToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoToolStripMenuItem,
            this.allToolStripMenuItem1,
            this.currentToolStripMenuItem1});
			this.проверкаToolStripMenuItem1.Name = "проверкаToolStripMenuItem1";
			this.проверкаToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.проверкаToolStripMenuItem1.Text = "Проверка";
			// 
			// autoToolStripMenuItem
			// 
			this.autoToolStripMenuItem.CheckOnClick = true;
			this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
			this.autoToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.autoToolStripMenuItem.Text = "Авто";
			this.autoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
			// 
			// allToolStripMenuItem1
			// 
			this.allToolStripMenuItem1.Name = "allToolStripMenuItem1";
			this.allToolStripMenuItem1.Size = new System.Drawing.Size(199, 22);
			this.allToolStripMenuItem1.Text = "Проверить все";
			this.allToolStripMenuItem1.Click += new System.EventHandler(this.allToolStripMenuItem1_Click);
			// 
			// currentToolStripMenuItem1
			// 
			this.currentToolStripMenuItem1.Name = "currentToolStripMenuItem1";
			this.currentToolStripMenuItem1.Size = new System.Drawing.Size(199, 22);
			this.currentToolStripMenuItem1.Text = "Проверить выбранное";
			this.currentToolStripMenuItem1.Click += new System.EventHandler(this.currentToolStripMenuItem1_Click);
			// 
			// FoldrCheckBackgroundWorker
			// 
			this.FoldrCheckBackgroundWorker.WorkerReportsProgress = true;
			this.FoldrCheckBackgroundWorker.WorkerSupportsCancellation = true;
			this.FoldrCheckBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FoldrCheckBackgroundWorker_DoWork);
			this.FoldrCheckBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.FoldrCheckBackgroundWorker_ProgressChanged);
			this.FoldrCheckBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FoldrCheckBackgroundWorker_RunWorkerCompleted);
			// 
			// checkTimer
			// 
			this.checkTimer.Interval = 60000;
			this.checkTimer.Tick += new System.EventHandler(this.checkTimer_Tick);
			// 
			// notifyIcon
			// 
			this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
			this.notifyIcon.BalloonTipText = "Возникли проблемы";
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "FolderChecker";
			this.notifyIcon.Visible = true;
			this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
			this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(781, 233);
			this.ContextMenuStrip = this.mainContextMenuStrip;
			this.Controls.Add(this.SettingsButton);
			this.Controls.Add(this.autoPictureBox);
			this.Controls.Add(this.CheckAllButton);
			this.Controls.Add(this.CheckButton);
			this.Controls.Add(this.FolderGridView);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(250, 200);
			this.Name = "MainForm";
			this.Text = "FolderChecker";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.FolderGridView)).EndInit();
			this.gridContextMenuStrip.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.autoPictureBox)).EndInit();
			this.mainContextMenuStrip.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.FolderBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView FolderGridView;
		private System.Windows.Forms.BindingSource FolderBindingSource;
		private System.Windows.Forms.Timer SaveTimer;
		private System.Windows.Forms.Button CheckButton;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button CheckAllButton;
		private System.ComponentModel.BackgroundWorker FoldrCheckBackgroundWorker;
		private System.Windows.Forms.Timer checkTimer;
		private System.Windows.Forms.ContextMenuStrip mainContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem SettingToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem eMailToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem paramsToolStripMenuItem;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.HelpProvider helpProvider;
		private System.Windows.Forms.ContextMenuStrip gridContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem offToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem onToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem редактированиеToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem appendToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem проверкаToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem currentToolStripMenuItem1;
		private System.Windows.Forms.PictureBox autoPictureBox;
		private System.Windows.Forms.Button SettingsButton;
	}
}

