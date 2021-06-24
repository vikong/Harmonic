namespace FolderChecker
{
	partial class EMailSettingForm
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
			this.components = new System.ComponentModel.Container();
			this.testButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.senderTextBox = new System.Windows.Forms.TextBox();
			this.ReciverTextBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label6 = new System.Windows.Forms.Label();
			this.passTextBox = new System.Windows.Forms.TextBox();
			this.portTextBox = new System.Windows.Forms.TextBox();
			this.hostTextBox = new System.Windows.Forms.TextBox();
			this.loginTextBox = new System.Windows.Forms.TextBox();
			this.sslCheckBox = new System.Windows.Forms.CheckBox();
			this.currentUserCheckBox = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// testButton
			// 
			this.testButton.Location = new System.Drawing.Point(84, 267);
			this.testButton.Name = "testButton";
			this.testButton.Size = new System.Drawing.Size(75, 23);
			this.testButton.TabIndex = 0;
			this.testButton.Text = "Тест";
			this.testButton.UseVisualStyleBackColor = true;
			this.testButton.Click += new System.EventHandler(this.testButton_Click);
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(219, 267);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 13;
			this.okButton.Text = "Принять";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(354, 267);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 14;
			this.cancelButton.Text = "Отмена";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(1, 2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(533, 256);
			this.tabControl1.TabIndex = 16;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.label9);
			this.tabPage1.Controls.Add(this.senderTextBox);
			this.tabPage1.Controls.Add(this.ReciverTextBox);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(525, 230);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Сообщение";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox1.Location = new System.Drawing.Point(112, 33);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(387, 24);
			this.textBox1.TabIndex = 18;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label9.Location = new System.Drawing.Point(6, 36);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(44, 18);
			this.label9.TabIndex = 17;
			this.label9.Text = "Тема";
			// 
			// senderTextBox
			// 
			this.senderTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.senderTextBox.Location = new System.Drawing.Point(112, 75);
			this.senderTextBox.Name = "senderTextBox";
			this.senderTextBox.Size = new System.Drawing.Size(384, 24);
			this.senderTextBox.TabIndex = 15;
			// 
			// ReciverTextBox
			// 
			this.ReciverTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ReciverTextBox.Location = new System.Drawing.Point(112, 3);
			this.ReciverTextBox.Name = "ReciverTextBox";
			this.ReciverTextBox.Size = new System.Drawing.Size(387, 24);
			this.ReciverTextBox.TabIndex = 16;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label8.Location = new System.Drawing.Point(6, 78);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(99, 18);
			this.label8.TabIndex = 13;
			this.label8.Text = "Отправитель";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(6, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 18);
			this.label1.TabIndex = 14;
			this.label1.Text = "Получатели";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.passTextBox);
			this.tabPage2.Controls.Add(this.portTextBox);
			this.tabPage2.Controls.Add(this.hostTextBox);
			this.tabPage2.Controls.Add(this.loginTextBox);
			this.tabPage2.Controls.Add(this.sslCheckBox);
			this.tabPage2.Controls.Add(this.currentUserCheckBox);
			this.tabPage2.Controls.Add(this.label5);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(525, 230);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Настройки соединения";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.Location = new System.Drawing.Point(6, 86);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(117, 18);
			this.label6.TabIndex = 26;
			this.label6.Text = "Учетная запись";
			// 
			// passTextBox
			// 
			this.passTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.passTextBox.Location = new System.Drawing.Point(91, 189);
			this.passTextBox.Name = "passTextBox";
			this.passTextBox.Size = new System.Drawing.Size(348, 24);
			this.passTextBox.TabIndex = 22;
			// 
			// portTextBox
			// 
			this.portTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.portTextBox.Location = new System.Drawing.Point(447, 5);
			this.portTextBox.MaxLength = 4;
			this.portTextBox.Name = "portTextBox";
			this.portTextBox.Size = new System.Drawing.Size(52, 24);
			this.portTextBox.TabIndex = 23;
			this.portTextBox.Text = "25";
			this.portTextBox.WordWrap = false;
			// 
			// hostTextBox
			// 
			this.hostTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.hostTextBox.Location = new System.Drawing.Point(72, 5);
			this.hostTextBox.Name = "hostTextBox";
			this.hostTextBox.Size = new System.Drawing.Size(306, 24);
			this.hostTextBox.TabIndex = 24;
			// 
			// loginTextBox
			// 
			this.loginTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.loginTextBox.Location = new System.Drawing.Point(91, 154);
			this.loginTextBox.Name = "loginTextBox";
			this.loginTextBox.Size = new System.Drawing.Size(348, 24);
			this.loginTextBox.TabIndex = 25;
			// 
			// sslCheckBox
			// 
			this.sslCheckBox.AutoSize = true;
			this.sslCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.sslCheckBox.Location = new System.Drawing.Point(12, 46);
			this.sslCheckBox.Name = "sslCheckBox";
			this.sslCheckBox.Size = new System.Drawing.Size(160, 22);
			this.sslCheckBox.TabIndex = 21;
			this.sslCheckBox.Text = "Использовать SSL";
			this.sslCheckBox.UseVisualStyleBackColor = true;
			// 
			// currentUserCheckBox
			// 
			this.currentUserCheckBox.AutoSize = true;
			this.currentUserCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.currentUserCheckBox.Location = new System.Drawing.Point(9, 113);
			this.currentUserCheckBox.Name = "currentUserCheckBox";
			this.currentUserCheckBox.Size = new System.Drawing.Size(303, 22);
			this.currentUserCheckBox.TabIndex = 20;
			this.currentUserCheckBox.Text = "Использовать текущую учётную запись";
			this.currentUserCheckBox.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(400, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 18);
			this.label5.TabIndex = 19;
			this.label5.Text = "порт";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(9, 189);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 18);
			this.label4.TabIndex = 18;
			this.label4.Text = "Пароль";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(9, 157);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 18);
			this.label3.TabIndex = 17;
			this.label3.Text = "Логин";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(6, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 18);
			this.label2.TabIndex = 16;
			this.label2.Text = "Сервер";
			// 
			// errorProvider
			// 
			this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
			this.errorProvider.ContainerControl = this;
			// 
			// EMailSettingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(539, 299);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.testButton);
			this.Name = "EMailSettingForm";
			this.Text = "Настройка почты";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button testButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox senderTextBox;
		private System.Windows.Forms.TextBox ReciverTextBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox passTextBox;
		private System.Windows.Forms.TextBox portTextBox;
		private System.Windows.Forms.TextBox hostTextBox;
		private System.Windows.Forms.TextBox loginTextBox;
		private System.Windows.Forms.CheckBox sslCheckBox;
		private System.Windows.Forms.CheckBox currentUserCheckBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ErrorProvider errorProvider;
	}
}