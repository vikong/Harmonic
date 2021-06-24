
namespace Harmonic.Subtitles
{
	partial class TestForm
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
			this.FolderGridView = new System.Windows.Forms.DataGridView();
			this.FolderBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.cancel = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.filesCountTextBox = new System.Windows.Forms.TextBox();
			this.timeTextBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.FolderGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.FolderBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// FolderGridView
			// 
			this.FolderGridView.AllowUserToAddRows = false;
			this.FolderGridView.AllowUserToDeleteRows = false;
			this.FolderGridView.AllowUserToOrderColumns = true;
			this.FolderGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FolderGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.FolderGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.FolderGridView.Location = new System.Drawing.Point(1, 3);
			this.FolderGridView.Name = "FolderGridView";
			this.FolderGridView.ReadOnly = true;
			this.FolderGridView.RowHeadersVisible = false;
			this.FolderGridView.Size = new System.Drawing.Size(718, 188);
			this.FolderGridView.TabIndex = 1;
			this.FolderGridView.VirtualMode = true;
			this.FolderGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FolderGridView_CellFormatting);
			this.FolderGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.FolderGridView_CellValueNeeded);
			// 
			// FolderBindingSource
			// 
			this.FolderBindingSource.AllowNew = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(7, 197);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(146, 229);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(426, 20);
			this.textBox1.TabIndex = 3;
			// 
			// cancel
			// 
			this.cancel.Location = new System.Drawing.Point(38, 226);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 5;
			this.cancel.Text = "button2";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(338, 195);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 6;
			this.button3.Text = "Enumerate";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// filesCountTextBox
			// 
			this.filesCountTextBox.Location = new System.Drawing.Point(419, 195);
			this.filesCountTextBox.Name = "filesCountTextBox";
			this.filesCountTextBox.Size = new System.Drawing.Size(100, 20);
			this.filesCountTextBox.TabIndex = 7;
			// 
			// timeTextBox
			// 
			this.timeTextBox.Location = new System.Drawing.Point(552, 198);
			this.timeTextBox.Name = "timeTextBox";
			this.timeTextBox.Size = new System.Drawing.Size(100, 20);
			this.timeTextBox.TabIndex = 8;
			// 
			// TestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(741, 279);
			this.Controls.Add(this.timeTextBox);
			this.Controls.Add(this.filesCountTextBox);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.FolderGridView);
			this.Name = "TestForm";
			this.Text = "TestForm";
			((System.ComponentModel.ISupportInitialize)(this.FolderGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.FolderBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView FolderGridView;
		private System.Windows.Forms.BindingSource FolderBindingSource;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox filesCountTextBox;
		private System.Windows.Forms.TextBox timeTextBox;
	}
}