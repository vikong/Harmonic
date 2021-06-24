namespace Harmonic
{
	partial class ViewConditionForm
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
			this.ConditonTextBox = new System.Windows.Forms.TextBox();
			this.CloseButton = new System.Windows.Forms.Button();
			this.TagLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ConditonTextBox
			// 
			this.ConditonTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ConditonTextBox.Location = new System.Drawing.Point(13, 34);
			this.ConditonTextBox.Multiline = true;
			this.ConditonTextBox.Name = "ConditonTextBox";
			this.ConditonTextBox.ReadOnly = true;
			this.ConditonTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.ConditonTextBox.Size = new System.Drawing.Size(498, 310);
			this.ConditonTextBox.TabIndex = 0;
			// 
			// CloseButton
			// 
			this.CloseButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CloseButton.Location = new System.Drawing.Point(223, 350);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(75, 23);
			this.CloseButton.TabIndex = 1;
			this.CloseButton.Text = "Close";
			this.CloseButton.UseVisualStyleBackColor = true;
			// 
			// TagLabel
			// 
			this.TagLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TagLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.TagLabel.Location = new System.Drawing.Point(13, 7);
			this.TagLabel.Name = "TagLabel";
			this.TagLabel.Size = new System.Drawing.Size(498, 23);
			this.TagLabel.TabIndex = 2;
			this.TagLabel.Text = "label1";
			// 
			// ViewConditionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CloseButton;
			this.ClientSize = new System.Drawing.Size(523, 385);
			this.Controls.Add(this.TagLabel);
			this.Controls.Add(this.CloseButton);
			this.Controls.Add(this.ConditonTextBox);
			this.Name = "ViewConditionForm";
			this.Text = "Harmonic Log Processor View Condition";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox ConditonTextBox;
		private System.Windows.Forms.Button CloseButton;
		private System.Windows.Forms.Label TagLabel;
	}
}