namespace FolderChecker
{
	partial class SettingForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
			this.label1 = new System.Windows.Forms.Label();
			this.hoursUpDown = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.EmlSendCheckBox = new System.Windows.Forms.CheckBox();
			this.mailSettingButton = new System.Windows.Forms.Button();
			this.LogFileTextBox = new System.Windows.Forms.TextBox();
			this.LogFileButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.minutesUpDown = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.FoldersListFileTextBox = new System.Windows.Forms.TextBox();
			this.FoldersListFileButton = new System.Windows.Forms.Button();
			this.ShowWindowCheckBox = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.fileSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.hoursUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.minutesUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fileSizeNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(13, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(145, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Интервал проверок";
			// 
			// hoursUpDown
			// 
			this.hoursUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.hoursUpDown.Location = new System.Drawing.Point(166, 15);
			this.hoursUpDown.Name = "hoursUpDown";
			this.hoursUpDown.Size = new System.Drawing.Size(57, 24);
			this.hoursUpDown.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(13, 108);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 18);
			this.label2.TabIndex = 0;
			this.label2.Text = "Журнал";
			// 
			// EmlSendCheckBox
			// 
			this.EmlSendCheckBox.AutoSize = true;
			this.EmlSendCheckBox.BackColor = System.Drawing.Color.Transparent;
			this.EmlSendCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.EmlSendCheckBox.Location = new System.Drawing.Point(24, 155);
			this.EmlSendCheckBox.Name = "EmlSendCheckBox";
			this.EmlSendCheckBox.Size = new System.Drawing.Size(277, 22);
			this.EmlSendCheckBox.TabIndex = 6;
			this.EmlSendCheckBox.Text = "Отсылать предупреждения по email";
			this.EmlSendCheckBox.UseVisualStyleBackColor = false;
			// 
			// mailSettingButton
			// 
			this.mailSettingButton.Location = new System.Drawing.Point(317, 153);
			this.mailSettingButton.Name = "mailSettingButton";
			this.mailSettingButton.Size = new System.Drawing.Size(32, 23);
			this.mailSettingButton.TabIndex = 7;
			this.mailSettingButton.Text = "...";
			this.mailSettingButton.UseVisualStyleBackColor = true;
			this.mailSettingButton.Click += new System.EventHandler(this.mailSettingButton_Click);
			// 
			// LogFileTextBox
			// 
			this.LogFileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LogFileTextBox.Location = new System.Drawing.Point(81, 105);
			this.LogFileTextBox.Name = "LogFileTextBox";
			this.LogFileTextBox.Size = new System.Drawing.Size(376, 24);
			this.LogFileTextBox.TabIndex = 4;
			// 
			// LogFileButton
			// 
			this.LogFileButton.Location = new System.Drawing.Point(476, 106);
			this.LogFileButton.Name = "LogFileButton";
			this.LogFileButton.Size = new System.Drawing.Size(32, 23);
			this.LogFileButton.TabIndex = 5;
			this.LogFileButton.Text = "...";
			this.LogFileButton.UseVisualStyleBackColor = true;
			this.LogFileButton.Click += new System.EventHandler(this.LogFileButton_Click);
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(106, 286);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 9;
			this.okButton.Text = "Принять";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(298, 286);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 10;
			this.cancelButton.Text = "Отменить";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// minutesUpDown
			// 
			this.minutesUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.minutesUpDown.Location = new System.Drawing.Point(281, 15);
			this.minutesUpDown.Name = "minutesUpDown";
			this.minutesUpDown.Size = new System.Drawing.Size(57, 24);
			this.minutesUpDown.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(13, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(129, 18);
			this.label3.TabIndex = 0;
			this.label3.Text = "Список проверки";
			// 
			// FoldersListFileTextBox
			// 
			this.FoldersListFileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FoldersListFileTextBox.Location = new System.Drawing.Point(148, 60);
			this.FoldersListFileTextBox.Name = "FoldersListFileTextBox";
			this.FoldersListFileTextBox.Size = new System.Drawing.Size(309, 24);
			this.FoldersListFileTextBox.TabIndex = 2;
			// 
			// FoldersListFileButton
			// 
			this.FoldersListFileButton.Location = new System.Drawing.Point(476, 61);
			this.FoldersListFileButton.Name = "FoldersListFileButton";
			this.FoldersListFileButton.Size = new System.Drawing.Size(32, 23);
			this.FoldersListFileButton.TabIndex = 3;
			this.FoldersListFileButton.Text = "...";
			this.FoldersListFileButton.UseVisualStyleBackColor = true;
			this.FoldersListFileButton.Click += new System.EventHandler(this.FoldersListFileButton_Click);
			// 
			// ShowWindowCheckBox
			// 
			this.ShowWindowCheckBox.AutoSize = true;
			this.ShowWindowCheckBox.BackColor = System.Drawing.Color.Transparent;
			this.ShowWindowCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ShowWindowCheckBox.Location = new System.Drawing.Point(24, 234);
			this.ShowWindowCheckBox.Name = "ShowWindowCheckBox";
			this.ShowWindowCheckBox.Size = new System.Drawing.Size(179, 22);
			this.ShowWindowCheckBox.TabIndex = 8;
			this.ShowWindowCheckBox.Text = "Запускать свернутым";
			this.ShowWindowCheckBox.UseVisualStyleBackColor = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(230, 18);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(32, 18);
			this.label4.TabIndex = 11;
			this.label4.Text = "час";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(345, 18);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(39, 18);
			this.label5.TabIndex = 12;
			this.label5.Text = "мин.";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.Location = new System.Drawing.Point(24, 196);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(186, 18);
			this.label6.TabIndex = 13;
			this.label6.Text = "Размер тестового файла";
			// 
			// fileSizeNumericUpDown
			// 
			this.fileSizeNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.fileSizeNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.fileSizeNumericUpDown.Location = new System.Drawing.Point(218, 194);
			this.fileSizeNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.fileSizeNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.fileSizeNumericUpDown.Name = "fileSizeNumericUpDown";
			this.fileSizeNumericUpDown.Size = new System.Drawing.Size(120, 24);
			this.fileSizeNumericUpDown.TabIndex = 14;
			this.fileSizeNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label7.Location = new System.Drawing.Point(345, 196);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 18);
			this.label7.TabIndex = 15;
			this.label7.Text = "байт";
			// 
			// SettingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(520, 321);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.fileSizeNumericUpDown);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.ShowWindowCheckBox);
			this.Controls.Add(this.minutesUpDown);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.FoldersListFileButton);
			this.Controls.Add(this.LogFileButton);
			this.Controls.Add(this.FoldersListFileTextBox);
			this.Controls.Add(this.LogFileTextBox);
			this.Controls.Add(this.mailSettingButton);
			this.Controls.Add(this.EmlSendCheckBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.hoursUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingForm";
			this.Text = "Настройки";
			this.Load += new System.EventHandler(this.SettingForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.hoursUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.minutesUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fileSizeNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown hoursUpDown;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox EmlSendCheckBox;
		private System.Windows.Forms.Button mailSettingButton;
		private System.Windows.Forms.TextBox LogFileTextBox;
		private System.Windows.Forms.Button LogFileButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.NumericUpDown minutesUpDown;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox FoldersListFileTextBox;
		private System.Windows.Forms.Button FoldersListFileButton;
		private System.Windows.Forms.CheckBox ShowWindowCheckBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown fileSizeNumericUpDown;
		private System.Windows.Forms.Label label7;
	}
}