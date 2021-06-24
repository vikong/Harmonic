namespace Harmonic
{
	partial class LexControl
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
			this.NegationCheckBox = new System.Windows.Forms.CheckBox();
			this.SubstringTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// NegationCheckBox
			// 
			this.NegationCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
			this.NegationCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.NegationCheckBox.Location = new System.Drawing.Point(5, 2);
			this.NegationCheckBox.Name = "NegationCheckBox";
			this.NegationCheckBox.Size = new System.Drawing.Size(79, 21);
			this.NegationCheckBox.TabIndex = 1;
			this.NegationCheckBox.TabStop = false;
			this.NegationCheckBox.Text = "contains";
			this.NegationCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.NegationCheckBox.UseVisualStyleBackColor = true;
			this.NegationCheckBox.CheckedChanged += new System.EventHandler(this.NegationCheckBox_CheckedChanged);
			this.NegationCheckBox.Click += new System.EventHandler(this.NegationCheckBox_Click);
			// 
			// SubstringTextBox
			// 
			this.SubstringTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SubstringTextBox.Location = new System.Drawing.Point(92, 3);
			this.SubstringTextBox.Name = "SubstringTextBox";
			this.SubstringTextBox.Size = new System.Drawing.Size(240, 20);
			this.SubstringTextBox.TabIndex = 0;
			this.SubstringTextBox.TextChanged += new System.EventHandler(this.SubstringTextBox_TextChanged);
			// 
			// LexControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.SubstringTextBox);
			this.Controls.Add(this.NegationCheckBox);
			this.Name = "LexControl";
			this.Size = new System.Drawing.Size(336, 27);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox NegationCheckBox;
		private System.Windows.Forms.TextBox SubstringTextBox;
	}
}
