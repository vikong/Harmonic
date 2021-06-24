namespace FolderObserver
{
	partial class PopUpForm
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
			this.openExternalButton = new System.Windows.Forms.Button();
			this.fileTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.messageTextBox = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// openExternalButton
			// 
			this.openExternalButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.openExternalButton.Location = new System.Drawing.Point(596, 5);
			this.openExternalButton.Name = "openExternalButton";
			this.openExternalButton.Size = new System.Drawing.Size(75, 23);
			this.openExternalButton.TabIndex = 1;
			this.openExternalButton.Text = "Open";
			this.openExternalButton.UseVisualStyleBackColor = true;
			this.openExternalButton.Click += new System.EventHandler(this.openExternalButton_Click);
			// 
			// fileTextBox
			// 
			this.fileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.fileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.fileTextBox.Location = new System.Drawing.Point(66, 7);
			this.fileTextBox.Name = "fileTextBox";
			this.fileTextBox.ReadOnly = true;
			this.fileTextBox.Size = new System.Drawing.Size(524, 21);
			this.fileTextBox.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Found in";
			// 
			// messageTextBox
			// 
			this.messageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.messageTextBox.Location = new System.Drawing.Point(0, 34);
			this.messageTextBox.Name = "messageTextBox";
			this.messageTextBox.ReadOnly = true;
			this.messageTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
			this.messageTextBox.Size = new System.Drawing.Size(683, 234);
			this.messageTextBox.TabIndex = 4;
			this.messageTextBox.Text = "";
			this.messageTextBox.WordWrap = false;
			// 
			// PopUpForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(683, 270);
			this.Controls.Add(this.messageTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.fileTextBox);
			this.Controls.Add(this.openExternalButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PopUpForm";
			this.ShowIcon = false;
			this.Text = "FolderObserver Message";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button openExternalButton;
		private System.Windows.Forms.TextBox fileTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox messageTextBox;
	}
}