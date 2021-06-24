namespace FolderObserver
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
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.ShowWindowCheckBox = new System.Windows.Forms.CheckBox();
			this.minutesUpDown = new System.Windows.Forms.NumericUpDown();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.LogFileTextBox = new System.Windows.Forms.TextBox();
			this.mailSettingButton = new System.Windows.Forms.Button();
			this.EmlSendCheckBox = new System.Windows.Forms.CheckBox();
			this.hoursUpDown = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.ConditionOpenButton = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.conditionTextBox = new System.Windows.Forms.TextBox();
			this.conditionButton = new System.Windows.Forms.Button();
			this.stringUpDown = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.folderSelectControl = new FolderObserver.FolderSelectControl();
			((System.ComponentModel.ISupportInitialize)(this.minutesUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.hoursUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stringUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(344, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 18);
			this.label5.TabIndex = 6;
			this.label5.Text = "mins";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(229, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 18);
			this.label4.TabIndex = 4;
			this.label4.Text = "hrs";
			// 
			// ShowWindowCheckBox
			// 
			this.ShowWindowCheckBox.AutoSize = true;
			this.ShowWindowCheckBox.BackColor = System.Drawing.Color.Transparent;
			this.ShowWindowCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ShowWindowCheckBox.Location = new System.Drawing.Point(15, 214);
			this.ShowWindowCheckBox.Name = "ShowWindowCheckBox";
			this.ShowWindowCheckBox.Size = new System.Drawing.Size(129, 22);
			this.ShowWindowCheckBox.TabIndex = 17;
			this.ShowWindowCheckBox.Text = "Start minimized";
			this.ShowWindowCheckBox.UseVisualStyleBackColor = false;
			// 
			// minutesUpDown
			// 
			this.minutesUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.minutesUpDown.Location = new System.Drawing.Point(280, 45);
			this.minutesUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.minutesUpDown.Name = "minutesUpDown";
			this.minutesUpDown.Size = new System.Drawing.Size(57, 24);
			this.minutesUpDown.TabIndex = 5;
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Image = global::FolderObserver.Properties.Resources.delete_24;
			this.cancelButton.Location = new System.Drawing.Point(504, 243);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 40);
			this.cancelButton.TabIndex = 19;
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Image = ((System.Drawing.Image)(resources.GetObject("okButton.Image")));
			this.okButton.Location = new System.Drawing.Point(386, 243);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 40);
			this.okButton.TabIndex = 18;
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// LogFileTextBox
			// 
			this.LogFileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LogFileTextBox.Location = new System.Drawing.Point(80, 142);
			this.LogFileTextBox.Name = "LogFileTextBox";
			this.LogFileTextBox.Size = new System.Drawing.Size(461, 24);
			this.LogFileTextBox.TabIndex = 13;
			// 
			// mailSettingButton
			// 
			this.mailSettingButton.Location = new System.Drawing.Point(203, 251);
			this.mailSettingButton.Name = "mailSettingButton";
			this.mailSettingButton.Size = new System.Drawing.Size(32, 32);
			this.mailSettingButton.TabIndex = 16;
			this.mailSettingButton.Text = "...";
			this.mailSettingButton.UseVisualStyleBackColor = true;
			this.mailSettingButton.Visible = false;
			// 
			// EmlSendCheckBox
			// 
			this.EmlSendCheckBox.AutoSize = true;
			this.EmlSendCheckBox.BackColor = System.Drawing.Color.Transparent;
			this.EmlSendCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.EmlSendCheckBox.Location = new System.Drawing.Point(15, 256);
			this.EmlSendCheckBox.Name = "EmlSendCheckBox";
			this.EmlSendCheckBox.Size = new System.Drawing.Size(182, 22);
			this.EmlSendCheckBox.TabIndex = 15;
			this.EmlSendCheckBox.Text = "Send warnings by email";
			this.EmlSendCheckBox.UseVisualStyleBackColor = false;
			this.EmlSendCheckBox.Visible = false;
			// 
			// hoursUpDown
			// 
			this.hoursUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.hoursUpDown.Location = new System.Drawing.Point(165, 45);
			this.hoursUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.hoursUpDown.Name = "hoursUpDown";
			this.hoursUpDown.Size = new System.Drawing.Size(57, 24);
			this.hoursUpDown.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(12, 145);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 18);
			this.label2.TabIndex = 12;
			this.label2.Text = "Log file";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(12, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 18);
			this.label1.TabIndex = 2;
			this.label1.Text = "Check interval";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(12, 14);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(113, 18);
			this.label3.TabIndex = 0;
			this.label3.Text = "Observed folder";
			// 
			// ConditionOpenButton
			// 
			this.ConditionOpenButton.Location = new System.Drawing.Point(547, 139);
			this.ConditionOpenButton.Name = "ConditionOpenButton";
			this.ConditionOpenButton.Size = new System.Drawing.Size(32, 32);
			this.ConditionOpenButton.TabIndex = 14;
			this.ConditionOpenButton.Text = "...";
			this.ConditionOpenButton.UseVisualStyleBackColor = true;
			this.ConditionOpenButton.Click += new System.EventHandler(this.ConditionOpenButton_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.Location = new System.Drawing.Point(12, 85);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(177, 18);
			this.label6.TabIndex = 7;
			this.label6.Text = "File with check conditions";
			this.label6.Visible = false;
			// 
			// conditionTextBox
			// 
			this.conditionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.conditionTextBox.Location = new System.Drawing.Point(195, 79);
			this.conditionTextBox.Name = "conditionTextBox";
			this.conditionTextBox.Size = new System.Drawing.Size(346, 24);
			this.conditionTextBox.TabIndex = 8;
			this.conditionTextBox.Visible = false;
			// 
			// conditionButton
			// 
			this.conditionButton.Location = new System.Drawing.Point(547, 79);
			this.conditionButton.Name = "conditionButton";
			this.conditionButton.Size = new System.Drawing.Size(32, 32);
			this.conditionButton.TabIndex = 9;
			this.conditionButton.Text = "...";
			this.conditionButton.UseVisualStyleBackColor = true;
			this.conditionButton.Visible = false;
			this.conditionButton.Click += new System.EventHandler(this.ConditionOpenButton_Click);
			// 
			// stringUpDown
			// 
			this.stringUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.stringUpDown.Location = new System.Drawing.Point(372, 173);
			this.stringUpDown.Name = "stringUpDown";
			this.stringUpDown.Size = new System.Drawing.Size(57, 24);
			this.stringUpDown.TabIndex = 11;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label8.Location = new System.Drawing.Point(12, 175);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(354, 18);
			this.label8.TabIndex = 10;
			this.label8.Text = "Number of displayed rows in the log of main window.";
			// 
			// folderSelectControl
			// 
			this.folderSelectControl.Location = new System.Drawing.Point(131, 12);
			this.folderSelectControl.Name = "folderSelectControl";
			this.folderSelectControl.Size = new System.Drawing.Size(458, 26);
			this.folderSelectControl.TabIndex = 1;
			// 
			// SettingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(591, 289);
			this.Controls.Add(this.stringUpDown);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.conditionButton);
			this.Controls.Add(this.ConditionOpenButton);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.ShowWindowCheckBox);
			this.Controls.Add(this.minutesUpDown);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.conditionTextBox);
			this.Controls.Add(this.LogFileTextBox);
			this.Controls.Add(this.mailSettingButton);
			this.Controls.Add(this.EmlSendCheckBox);
			this.Controls.Add(this.hoursUpDown);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.folderSelectControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingForm";
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.SettingForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.minutesUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.hoursUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stringUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private FolderSelectControl folderSelectControl;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox ShowWindowCheckBox;
		private System.Windows.Forms.NumericUpDown minutesUpDown;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.TextBox LogFileTextBox;
		private System.Windows.Forms.Button mailSettingButton;
		private System.Windows.Forms.CheckBox EmlSendCheckBox;
		private System.Windows.Forms.NumericUpDown hoursUpDown;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button ConditionOpenButton;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox conditionTextBox;
		private System.Windows.Forms.Button conditionButton;
		private System.Windows.Forms.NumericUpDown stringUpDown;
		private System.Windows.Forms.Label label8;
	}
}