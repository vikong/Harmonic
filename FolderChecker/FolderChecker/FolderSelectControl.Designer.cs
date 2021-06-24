namespace FolderChecker
{
	partial class FolderSelectControl
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

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Обязательный метод для поддержки конструктора - не изменяйте 
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.folderTextBox = new System.Windows.Forms.TextBox();
			this.dialogButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// folderTextBox
			// 
			this.folderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.folderTextBox.Location = new System.Drawing.Point(6, 3);
			this.folderTextBox.Name = "folderTextBox";
			this.folderTextBox.Size = new System.Drawing.Size(375, 20);
			this.folderTextBox.TabIndex = 0;
			// 
			// dialogButton
			// 
			this.dialogButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.dialogButton.Location = new System.Drawing.Point(387, 2);
			this.dialogButton.Name = "dialogButton";
			this.dialogButton.Size = new System.Drawing.Size(28, 23);
			this.dialogButton.TabIndex = 1;
			this.dialogButton.Text = "...";
			this.dialogButton.UseVisualStyleBackColor = true;
			this.dialogButton.Click += new System.EventHandler(this.dialogButton_Click);
			// 
			// FolderSelectControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dialogButton);
			this.Controls.Add(this.folderTextBox);
			this.Name = "FolderSelectControl";
			this.Size = new System.Drawing.Size(421, 26);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button dialogButton;
		public System.Windows.Forms.TextBox folderTextBox;
	}
}
