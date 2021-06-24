namespace Harmonic.Subtitles
{
	partial class EditFolderForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditFolderForm));
			this.label1 = new System.Windows.Forms.Label();
			this.NameTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.confirmButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.suffixesTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SubtitlesFileButton = new System.Windows.Forms.Button();
			this.SubtitlesFileTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.helpLabel = new System.Windows.Forms.Label();
			this.targetFolderSelectControl = new Harmonic.Subtitles.FolderSelectControl();
			this.sourceFolderSelectControl = new Harmonic.Subtitles.FolderSelectControl();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// NameTextBox
			// 
			resources.ApplyResources(this.NameTextBox, "NameTextBox");
			this.NameTextBox.Name = "NameTextBox";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// confirmButton
			// 
			resources.ApplyResources(this.confirmButton, "confirmButton");
			this.confirmButton.Name = "confirmButton";
			this.confirmButton.UseVisualStyleBackColor = true;
			this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(this.cancelButton, "cancelButton");
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// suffixesTextBox
			// 
			resources.ApplyResources(this.suffixesTextBox, "suffixesTextBox");
			this.suffixesTextBox.Name = "suffixesTextBox";
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// SubtitlesFileButton
			// 
			resources.ApplyResources(this.SubtitlesFileButton, "SubtitlesFileButton");
			this.SubtitlesFileButton.Name = "SubtitlesFileButton";
			this.SubtitlesFileButton.UseVisualStyleBackColor = true;
			this.SubtitlesFileButton.Click += new System.EventHandler(this.SubtitlesFileButton_Click);
			// 
			// SubtitlesFileTextBox
			// 
			resources.ApplyResources(this.SubtitlesFileTextBox, "SubtitlesFileTextBox");
			this.SubtitlesFileTextBox.Name = "SubtitlesFileTextBox";
			// 
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Name = "label5";
			// 
			// helpLabel
			// 
			resources.ApplyResources(this.helpLabel, "helpLabel");
			this.helpLabel.Name = "helpLabel";
			// 
			// targetFolderSelectControl
			// 
			resources.ApplyResources(this.targetFolderSelectControl, "targetFolderSelectControl");
			this.targetFolderSelectControl.Name = "targetFolderSelectControl";
			this.targetFolderSelectControl.Validating += new System.ComponentModel.CancelEventHandler(this.targetFolderSelectControl_Validating);
			// 
			// sourceFolderSelectControl
			// 
			resources.ApplyResources(this.sourceFolderSelectControl, "sourceFolderSelectControl");
			this.sourceFolderSelectControl.Name = "sourceFolderSelectControl";
			this.sourceFolderSelectControl.Validating += new System.ComponentModel.CancelEventHandler(this.folderSelectControl_Validating);
			// 
			// EditFolderForm
			// 
			this.AcceptButton = this.confirmButton;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.Controls.Add(this.helpLabel);
			this.Controls.Add(this.SubtitlesFileButton);
			this.Controls.Add(this.SubtitlesFileTextBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.suffixesTextBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.targetFolderSelectControl);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.confirmButton);
			this.Controls.Add(this.sourceFolderSelectControl);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.NameTextBox);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditFolderForm";
			this.ShowIcon = false;
			this.Load += new System.EventHandler(this.EditFolderForm_Load);
			this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.EditFolderForm_HelpRequested);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox NameTextBox;
		private System.Windows.Forms.Label label2;
		private FolderSelectControl sourceFolderSelectControl;
		private System.Windows.Forms.Button confirmButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private FolderSelectControl targetFolderSelectControl;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox suffixesTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button SubtitlesFileButton;
		private System.Windows.Forms.TextBox SubtitlesFileTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label helpLabel;
	}
}