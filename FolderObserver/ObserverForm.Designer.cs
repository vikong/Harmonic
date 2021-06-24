namespace FolderObserver
{
	partial class ObserverForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObserverForm));
			this.logTextBox = new System.Windows.Forms.TextBox();
			this.folderTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.conditionTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.checkBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.checkTimer = new System.Windows.Forms.Timer(this.components);
			this.editContButton = new System.Windows.Forms.Button();
			this.autoPictureBox = new System.Windows.Forms.PictureBox();
			this.SettingsButton = new System.Windows.Forms.Button();
			this.mainContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.checkNowButton = new System.Windows.Forms.Button();
			this.checkContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.checkAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetForFutureCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.stopButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.autoPictureBox)).BeginInit();
			this.mainContextMenuStrip.SuspendLayout();
			this.checkContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// logTextBox
			// 
			this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.logTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.logTextBox.Location = new System.Drawing.Point(0, 148);
			this.logTextBox.Multiline = true;
			this.logTextBox.Name = "logTextBox";
			this.logTextBox.ReadOnly = true;
			this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.logTextBox.Size = new System.Drawing.Size(637, 251);
			this.logTextBox.TabIndex = 7;
			this.logTextBox.WordWrap = false;
			// 
			// folderTextBox
			// 
			this.folderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.folderTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.folderTextBox.Location = new System.Drawing.Point(131, 10);
			this.folderTextBox.Name = "folderTextBox";
			this.folderTextBox.ReadOnly = true;
			this.folderTextBox.Size = new System.Drawing.Size(458, 21);
			this.folderTextBox.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(12, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(113, 18);
			this.label3.TabIndex = 26;
			this.label3.Text = "Observed folder";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(12, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 18);
			this.label1.TabIndex = 28;
			this.label1.Text = "Condition";
			// 
			// conditionTextBox
			// 
			this.conditionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.conditionTextBox.Location = new System.Drawing.Point(86, 43);
			this.conditionTextBox.Multiline = true;
			this.conditionTextBox.Name = "conditionTextBox";
			this.conditionTextBox.ReadOnly = true;
			this.conditionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.conditionTextBox.Size = new System.Drawing.Size(503, 56);
			this.conditionTextBox.TabIndex = 27;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(12, 127);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 18);
			this.label2.TabIndex = 29;
			this.label2.Text = "Messages";
			// 
			// checkBackgroundWorker
			// 
			this.checkBackgroundWorker.WorkerReportsProgress = true;
			this.checkBackgroundWorker.WorkerSupportsCancellation = true;
			this.checkBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.checkBackgroundWorker_DoWork);
			this.checkBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.checkBackgroundWorker_ProgressChanged);
			this.checkBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.checkBackgroundWorker_RunWorkerCompleted);
			// 
			// notifyIcon
			// 
			this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.notifyIcon.BalloonTipText = "Обнаружено вхождение";
			this.notifyIcon.Text = "Folder Observer";
			this.notifyIcon.Visible = true;
			this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
			this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
			// 
			// checkTimer
			// 
			this.checkTimer.Tick += new System.EventHandler(this.checkTimer_Tick);
			// 
			// editContButton
			// 
			this.editContButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.editContButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.editContButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
			this.editContButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.editContButton.Image = global::FolderObserver.Properties.Resources.edit_24;
			this.editContButton.Location = new System.Drawing.Point(37, 63);
			this.editContButton.Name = "editContButton";
			this.editContButton.Size = new System.Drawing.Size(36, 36);
			this.editContButton.TabIndex = 31;
			this.toolTip1.SetToolTip(this.editContButton, "Edit lookup condition");
			this.editContButton.UseVisualStyleBackColor = true;
			this.editContButton.Click += new System.EventHandler(this.editContButton_Click);
			// 
			// autoPictureBox
			// 
			this.autoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.autoPictureBox.Image = global::FolderObserver.Properties.Resources.pause_24;
			this.autoPictureBox.Location = new System.Drawing.Point(597, 6);
			this.autoPictureBox.Name = "autoPictureBox";
			this.autoPictureBox.Size = new System.Drawing.Size(36, 36);
			this.autoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.autoPictureBox.TabIndex = 30;
			this.autoPictureBox.TabStop = false;
			this.toolTip1.SetToolTip(this.autoPictureBox, "Switch on or off automatic check ");
			this.autoPictureBox.Click += new System.EventHandler(this.autoPictureBox_Click);
			// 
			// SettingsButton
			// 
			this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.SettingsButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.SettingsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
			this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SettingsButton.Image = global::FolderObserver.Properties.Resources.Settings_24;
			this.SettingsButton.Location = new System.Drawing.Point(597, 56);
			this.SettingsButton.Name = "SettingsButton";
			this.SettingsButton.Size = new System.Drawing.Size(36, 36);
			this.SettingsButton.TabIndex = 9;
			this.toolTip1.SetToolTip(this.SettingsButton, "Settings");
			this.SettingsButton.UseVisualStyleBackColor = true;
			this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
			// 
			// mainContextMenuStrip
			// 
			this.mainContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoToolStripMenuItem});
			this.mainContextMenuStrip.Name = "mainContextMenuStrip";
			this.mainContextMenuStrip.Size = new System.Drawing.Size(137, 26);
			// 
			// autoToolStripMenuItem
			// 
			this.autoToolStripMenuItem.CheckOnClick = true;
			this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
			this.autoToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.autoToolStripMenuItem.Text = "Auto Check";
			this.autoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
			// 
			// checkNowButton
			// 
			this.checkNowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkNowButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.checkNowButton.ContextMenuStrip = this.checkContextMenu;
			this.checkNowButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.checkNowButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
			this.checkNowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkNowButton.Image = global::FolderObserver.Properties.Resources.check_one;
			this.checkNowButton.Location = new System.Drawing.Point(597, 106);
			this.checkNowButton.Name = "checkNowButton";
			this.checkNowButton.Size = new System.Drawing.Size(36, 36);
			this.checkNowButton.TabIndex = 33;
			this.toolTip1.SetToolTip(this.checkNowButton, "Check now");
			this.checkNowButton.UseVisualStyleBackColor = true;
			this.checkNowButton.Click += new System.EventHandler(this.checkNowButton_Click);
			// 
			// checkContextMenu
			// 
			this.checkContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkAllToolStripMenuItem,
            this.resetForFutureCheckToolStripMenuItem});
			this.checkContextMenu.Name = "checkContextMenu";
			this.checkContextMenu.Size = new System.Drawing.Size(190, 48);
			// 
			// checkAllToolStripMenuItem
			// 
			this.checkAllToolStripMenuItem.Name = "checkAllToolStripMenuItem";
			this.checkAllToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.checkAllToolStripMenuItem.Text = "Check all now";
			this.checkAllToolStripMenuItem.Click += new System.EventHandler(this.checkAllToolStripMenuItem_Click);
			// 
			// resetForFutureCheckToolStripMenuItem
			// 
			this.resetForFutureCheckToolStripMenuItem.Name = "resetForFutureCheckToolStripMenuItem";
			this.resetForFutureCheckToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.resetForFutureCheckToolStripMenuItem.Text = "Reset for future check";
			this.resetForFutureCheckToolStripMenuItem.Click += new System.EventHandler(this.resetForFutureCheckToolStripMenuItem_Click);
			// 
			// progressBar
			// 
			this.progressBar.ForeColor = System.Drawing.Color.ForestGreen;
			this.progressBar.Location = new System.Drawing.Point(95, 127);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(494, 18);
			this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.progressBar.TabIndex = 34;
			this.progressBar.Visible = false;
			// 
			// stopButton
			// 
			this.stopButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.stopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.stopButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.stopButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
			this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.stopButton.Image = global::FolderObserver.Properties.Resources.stop_24;
			this.stopButton.Location = new System.Drawing.Point(555, 105);
			this.stopButton.Name = "stopButton";
			this.stopButton.Size = new System.Drawing.Size(36, 36);
			this.stopButton.TabIndex = 35;
			this.toolTip1.SetToolTip(this.stopButton, "Stop current checking");
			this.stopButton.UseVisualStyleBackColor = true;
			this.stopButton.Visible = false;
			this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
			// 
			// ObserverForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(639, 399);
			this.ContextMenuStrip = this.mainContextMenuStrip;
			this.Controls.Add(this.stopButton);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.checkNowButton);
			this.Controls.Add(this.editContButton);
			this.Controls.Add(this.autoPictureBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.conditionTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.SettingsButton);
			this.Controls.Add(this.folderTextBox);
			this.Controls.Add(this.logTextBox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 300);
			this.Name = "ObserverForm";
			this.Text = "Folder Observer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ObserverForm_FormClosing);
			this.Load += new System.EventHandler(this.ObserverForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.autoPictureBox)).EndInit();
			this.mainContextMenuStrip.ResumeLayout(false);
			this.checkContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox logTextBox;
		private System.Windows.Forms.TextBox folderTextBox;
		private System.Windows.Forms.Button SettingsButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox conditionTextBox;
		private System.Windows.Forms.Label label2;
		private System.ComponentModel.BackgroundWorker checkBackgroundWorker;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.Timer checkTimer;
		private System.Windows.Forms.PictureBox autoPictureBox;
		private System.Windows.Forms.Button editContButton;
		private System.Windows.Forms.ContextMenuStrip mainContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
		private System.Windows.Forms.Button checkNowButton;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ContextMenuStrip checkContextMenu;
		private System.Windows.Forms.ToolStripMenuItem checkAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resetForFutureCheckToolStripMenuItem;
		private System.Windows.Forms.Button stopButton;
	}
}

