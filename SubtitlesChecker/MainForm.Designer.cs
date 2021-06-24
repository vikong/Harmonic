namespace Harmonic.Subtitles
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
			this.FolderMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.modifyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.appendToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.checkToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.switchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.checkCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.checkAllNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearSutitlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.cancelCurrentOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CheckButton = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.CheckAllButton = new System.Windows.Forms.Button();
			this.autoPictureBox = new System.Windows.Forms.PictureBox();
			this.TimerMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.byTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.manuallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SettingsButton = new System.Windows.Forms.Button();
			this.zipButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.helpLabel = new System.Windows.Forms.Label();
			this.checkTimer = new System.Windows.Forms.Timer(this.components);
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.FolderBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.FolderGridView)).BeginInit();
			this.FolderMenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.autoPictureBox)).BeginInit();
			this.TimerMenuStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.FolderBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// FolderGridView
			// 
			this.FolderGridView.AllowUserToAddRows = false;
			this.FolderGridView.AllowUserToDeleteRows = false;
			this.FolderGridView.AllowUserToOrderColumns = true;
			resources.ApplyResources(this.FolderGridView, "FolderGridView");
			this.FolderGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.FolderGridView.ContextMenuStrip = this.FolderMenuStrip;
			this.FolderGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.FolderGridView.Name = "FolderGridView";
			this.FolderGridView.ReadOnly = true;
			this.FolderGridView.RowHeadersVisible = false;
			this.FolderGridView.VirtualMode = true;
			this.FolderGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FolderGridView_CellFormatting);
			this.FolderGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.FolderGridView_CellMouseClick);
			this.FolderGridView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.FolderGridView_CellMouseDown);
			this.FolderGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.FolderGridView_CellValueNeeded);
			this.FolderGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.FolderGridView_RowPrePaint);
			this.FolderGridView.DoubleClick += new System.EventHandler(this.FolderGridView_DoubleClick);
			// 
			// FolderMenuStrip
			// 
			this.FolderMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem1,
            this.checkToolStripMenuItem1,
            this.settingsToolStripMenuItem1,
            this.logToolStripMenuItem});
			this.FolderMenuStrip.Name = "FolderMenuStrip";
			resources.ApplyResources(this.FolderMenuStrip, "FolderMenuStrip");
			this.FolderMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.FolderMenuStrip_Opening);
			// 
			// editToolStripMenuItem1
			// 
			this.editToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifyToolStripMenuItem1,
            this.appendToolStripMenuItem1,
            this.deleteToolStripMenuItem1});
			this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
			resources.ApplyResources(this.editToolStripMenuItem1, "editToolStripMenuItem1");
			// 
			// modifyToolStripMenuItem1
			// 
			this.modifyToolStripMenuItem1.Name = "modifyToolStripMenuItem1";
			resources.ApplyResources(this.modifyToolStripMenuItem1, "modifyToolStripMenuItem1");
			this.modifyToolStripMenuItem1.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
			// 
			// appendToolStripMenuItem1
			// 
			this.appendToolStripMenuItem1.Name = "appendToolStripMenuItem1";
			resources.ApplyResources(this.appendToolStripMenuItem1, "appendToolStripMenuItem1");
			this.appendToolStripMenuItem1.Click += new System.EventHandler(this.appendToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem1
			// 
			this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
			resources.ApplyResources(this.deleteToolStripMenuItem1, "deleteToolStripMenuItem1");
			this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// checkToolStripMenuItem1
			// 
			this.checkToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchToolStripMenuItem,
            this.AutoToolStripMenuItem,
            this.checkCurrentToolStripMenuItem,
            this.checkAllNowToolStripMenuItem,
            this.clearSutitlesToolStripMenuItem,
            this.toolStripSeparator1,
            this.cancelCurrentOperationToolStripMenuItem});
			this.checkToolStripMenuItem1.Name = "checkToolStripMenuItem1";
			resources.ApplyResources(this.checkToolStripMenuItem1, "checkToolStripMenuItem1");
			// 
			// switchToolStripMenuItem
			// 
			this.switchToolStripMenuItem.Name = "switchToolStripMenuItem";
			resources.ApplyResources(this.switchToolStripMenuItem, "switchToolStripMenuItem");
			this.switchToolStripMenuItem.Click += new System.EventHandler(this.switchToolStripMenuItem_Click);
			// 
			// AutoToolStripMenuItem
			// 
			this.AutoToolStripMenuItem.CheckOnClick = true;
			this.AutoToolStripMenuItem.Name = "AutoToolStripMenuItem";
			resources.ApplyResources(this.AutoToolStripMenuItem, "AutoToolStripMenuItem");
			this.AutoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
			// 
			// checkCurrentToolStripMenuItem
			// 
			this.checkCurrentToolStripMenuItem.Name = "checkCurrentToolStripMenuItem";
			resources.ApplyResources(this.checkCurrentToolStripMenuItem, "checkCurrentToolStripMenuItem");
			this.checkCurrentToolStripMenuItem.Click += new System.EventHandler(this.currentToolStripMenuItem1_Click);
			// 
			// checkAllNowToolStripMenuItem
			// 
			this.checkAllNowToolStripMenuItem.Name = "checkAllNowToolStripMenuItem";
			resources.ApplyResources(this.checkAllNowToolStripMenuItem, "checkAllNowToolStripMenuItem");
			this.checkAllNowToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem1_Click);
			// 
			// clearSutitlesToolStripMenuItem
			// 
			this.clearSutitlesToolStripMenuItem.Name = "clearSutitlesToolStripMenuItem";
			resources.ApplyResources(this.clearSutitlesToolStripMenuItem, "clearSutitlesToolStripMenuItem");
			this.clearSutitlesToolStripMenuItem.Click += new System.EventHandler(this.ClearSubtitles_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
			// 
			// cancelCurrentOperationToolStripMenuItem
			// 
			this.cancelCurrentOperationToolStripMenuItem.Name = "cancelCurrentOperationToolStripMenuItem";
			resources.ApplyResources(this.cancelCurrentOperationToolStripMenuItem, "cancelCurrentOperationToolStripMenuItem");
			this.cancelCurrentOperationToolStripMenuItem.Click += new System.EventHandler(this.cancelCurrentOperationToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem1
			// 
			this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
			resources.ApplyResources(this.settingsToolStripMenuItem1, "settingsToolStripMenuItem1");
			this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.paramsToolStripMenuItem_Click);
			// 
			// logToolStripMenuItem
			// 
			this.logToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addedToolStripMenuItem,
            this.clearedToolStripMenuItem});
			this.logToolStripMenuItem.Name = "logToolStripMenuItem";
			resources.ApplyResources(this.logToolStripMenuItem, "logToolStripMenuItem");
			// 
			// addedToolStripMenuItem
			// 
			this.addedToolStripMenuItem.Name = "addedToolStripMenuItem";
			resources.ApplyResources(this.addedToolStripMenuItem, "addedToolStripMenuItem");
			this.addedToolStripMenuItem.Click += new System.EventHandler(this.addedToolStripMenuItem_Click);
			// 
			// clearedToolStripMenuItem
			// 
			this.clearedToolStripMenuItem.Name = "clearedToolStripMenuItem";
			resources.ApplyResources(this.clearedToolStripMenuItem, "clearedToolStripMenuItem");
			this.clearedToolStripMenuItem.Click += new System.EventHandler(this.clearedToolStripMenuItem_Click);
			// 
			// CheckButton
			// 
			resources.ApplyResources(this.CheckButton, "CheckButton");
			this.CheckButton.Image = global::Harmonic.Subtitles.Properties.Resources.check_one;
			this.CheckButton.Name = "CheckButton";
			this.toolTip1.SetToolTip(this.CheckButton, resources.GetString("CheckButton.ToolTip"));
			this.CheckButton.UseVisualStyleBackColor = true;
			this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
			// 
			// CheckAllButton
			// 
			resources.ApplyResources(this.CheckAllButton, "CheckAllButton");
			this.CheckAllButton.Image = global::Harmonic.Subtitles.Properties.Resources.Check_all_24;
			this.CheckAllButton.Name = "CheckAllButton";
			this.toolTip1.SetToolTip(this.CheckAllButton, resources.GetString("CheckAllButton.ToolTip"));
			this.CheckAllButton.UseVisualStyleBackColor = true;
			this.CheckAllButton.Click += new System.EventHandler(this.CheckAllButton_Click);
			// 
			// autoPictureBox
			// 
			resources.ApplyResources(this.autoPictureBox, "autoPictureBox");
			this.autoPictureBox.ContextMenuStrip = this.TimerMenuStrip;
			this.autoPictureBox.Image = global::Harmonic.Subtitles.Properties.Resources.pause_24;
			this.autoPictureBox.Name = "autoPictureBox";
			this.autoPictureBox.TabStop = false;
			this.toolTip1.SetToolTip(this.autoPictureBox, resources.GetString("autoPictureBox.ToolTip"));
			// 
			// TimerMenuStrip
			// 
			this.TimerMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byTimerToolStripMenuItem,
            this.manuallyToolStripMenuItem});
			this.TimerMenuStrip.Name = "TimerMenuStrip";
			resources.ApplyResources(this.TimerMenuStrip, "TimerMenuStrip");
			this.TimerMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.TimerMenuStrip_Opening);
			this.TimerMenuStrip.Click += new System.EventHandler(this.TimerMenuStrip_Click);
			// 
			// byTimerToolStripMenuItem
			// 
			this.byTimerToolStripMenuItem.Name = "byTimerToolStripMenuItem";
			resources.ApplyResources(this.byTimerToolStripMenuItem, "byTimerToolStripMenuItem");
			// 
			// manuallyToolStripMenuItem
			// 
			this.manuallyToolStripMenuItem.Name = "manuallyToolStripMenuItem";
			resources.ApplyResources(this.manuallyToolStripMenuItem, "manuallyToolStripMenuItem");
			this.manuallyToolStripMenuItem.Click += new System.EventHandler(this.manuallyToolStripMenuItem_Click);
			// 
			// SettingsButton
			// 
			resources.ApplyResources(this.SettingsButton, "SettingsButton");
			this.SettingsButton.Image = global::Harmonic.Subtitles.Properties.Resources.Settings_24;
			this.SettingsButton.Name = "SettingsButton";
			this.toolTip1.SetToolTip(this.SettingsButton, resources.GetString("SettingsButton.ToolTip"));
			this.SettingsButton.UseVisualStyleBackColor = true;
			this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
			// 
			// zipButton
			// 
			resources.ApplyResources(this.zipButton, "zipButton");
			this.zipButton.Image = global::Harmonic.Subtitles.Properties.Resources.file_zip_16;
			this.zipButton.Name = "zipButton";
			this.toolTip1.SetToolTip(this.zipButton, resources.GetString("zipButton.ToolTip"));
			this.zipButton.UseVisualStyleBackColor = true;
			this.zipButton.Click += new System.EventHandler(this.ClearSubtitles_Click);
			// 
			// CancelButton
			// 
			resources.ApplyResources(this.CancelButton, "CancelButton");
			this.CancelButton.Image = global::Harmonic.Subtitles.Properties.Resources.stopsign_24;
			this.CancelButton.Name = "CancelButton";
			this.toolTip1.SetToolTip(this.CancelButton, resources.GetString("CancelButton.ToolTip"));
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			resources.ApplyResources(this.statusStrip, "statusStrip");
			this.statusStrip.Name = "statusStrip";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
			// 
			// helpLabel
			// 
			resources.ApplyResources(this.helpLabel, "helpLabel");
			this.helpLabel.Name = "helpLabel";
			// 
			// checkTimer
			// 
			this.checkTimer.Interval = 60000;
			this.checkTimer.Tick += new System.EventHandler(this.checkTimer_Tick);
			// 
			// notifyIcon
			// 
			this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
			resources.ApplyResources(this.notifyIcon, "notifyIcon");
			this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
			this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
			// 
			// FolderBindingSource
			// 
			this.FolderBindingSource.AllowNew = false;
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.helpLabel);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.zipButton);
			this.Controls.Add(this.SettingsButton);
			this.Controls.Add(this.autoPictureBox);
			this.Controls.Add(this.CheckAllButton);
			this.Controls.Add(this.CheckButton);
			this.Controls.Add(this.FolderGridView);
			this.Controls.Add(this.statusStrip);
			this.HelpButton = true;
			this.KeyPreview = true;
			this.Name = "MainForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.MainForm_HelpRequested);
			((System.ComponentModel.ISupportInitialize)(this.FolderGridView)).EndInit();
			this.FolderMenuStrip.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.autoPictureBox)).EndInit();
			this.TimerMenuStrip.ResumeLayout(false);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.FolderBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView FolderGridView;
		private System.Windows.Forms.BindingSource FolderBindingSource;
		private System.Windows.Forms.Button CheckButton;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button CheckAllButton;
		private System.Windows.Forms.Timer checkTimer;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.PictureBox autoPictureBox;
		private System.Windows.Forms.Button SettingsButton;
		private System.Windows.Forms.Button zipButton;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ContextMenuStrip FolderMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem appendToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem checkToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem AutoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem checkCurrentToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem checkAllNowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem switchToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip TimerMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem byTimerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem manuallyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearSutitlesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearedToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.Label helpLabel;
		private System.Windows.Forms.ToolStripMenuItem cancelCurrentOperationToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.Button CancelButton;
	}
}

