namespace Harmonic
{
	partial class ConditionEditForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConditionEditForm));
			this.ConditionDataGridView = new System.Windows.Forms.DataGridView();
			this.TypeComboBox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.ConditionBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.AppendConditionButton = new System.Windows.Forms.Button();
			this.ConditionEditToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.AppendLexemButton = new Harmonic.AppendButton(this.components);
			this.RemoveConditionButton = new Harmonic.RemoveButton(this.components);
			this.NegationCheckBox = new System.Windows.Forms.CheckBox();
			this.ConditionShowButton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.LexemControl = new Harmonic.LexControl();
			this.label1 = new System.Windows.Forms.Label();
			this.TagTextBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.ConditionDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ConditionBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// ConditionDataGridView
			// 
			this.ConditionDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ConditionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ConditionDataGridView.Location = new System.Drawing.Point(7, 55);
			this.ConditionDataGridView.Name = "ConditionDataGridView";
			this.ConditionDataGridView.ReadOnly = true;
			this.ConditionDataGridView.RowHeadersVisible = false;
			this.ConditionDataGridView.Size = new System.Drawing.Size(562, 152);
			this.ConditionDataGridView.TabIndex = 0;
			this.ConditionDataGridView.DoubleClick += new System.EventHandler(this.ConditionDataGridView_DoubleClick);
			// 
			// TypeComboBox
			// 
			this.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TypeComboBox.FormattingEnabled = true;
			this.TypeComboBox.Items.AddRange(new object[] {
            "AND",
            "OR"});
			this.TypeComboBox.Location = new System.Drawing.Point(90, 28);
			this.TypeComboBox.Name = "TypeComboBox";
			this.TypeComboBox.Size = new System.Drawing.Size(140, 21);
			this.TypeComboBox.TabIndex = 8;
			this.TypeComboBox.SelectedIndexChanged += new System.EventHandler(this.TypeComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(76, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Concatenation";
			// 
			// ConditionBindingSource
			// 
			this.ConditionBindingSource.CurrentChanged += new System.EventHandler(this.ConditionBindingSource_CurrentChanged);
			// 
			// AppendConditionButton
			// 
			this.AppendConditionButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.AppendConditionButton.Image = global::Harmonic.HarmonicResource.multi_24;
			this.AppendConditionButton.Location = new System.Drawing.Point(575, 104);
			this.AppendConditionButton.Name = "AppendConditionButton";
			this.AppendConditionButton.Size = new System.Drawing.Size(30, 26);
			this.AppendConditionButton.TabIndex = 11;
			this.ConditionEditToolTip.SetToolTip(this.AppendConditionButton, "Add complex condition");
			this.AppendConditionButton.UseVisualStyleBackColor = true;
			this.AppendConditionButton.Click += new System.EventHandler(this.AppendConditionButton_Click);
			// 
			// AppendLexemButton
			// 
			this.AppendLexemButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.AppendLexemButton.Image = ((System.Drawing.Image)(resources.GetObject("AppendLexemButton.Image")));
			this.AppendLexemButton.Location = new System.Drawing.Point(575, 64);
			this.AppendLexemButton.Name = "AppendLexemButton";
			this.AppendLexemButton.Size = new System.Drawing.Size(30, 26);
			this.AppendLexemButton.TabIndex = 3;
			this.ConditionEditToolTip.SetToolTip(this.AppendLexemButton, "Add simple condition");
			this.AppendLexemButton.UseVisualStyleBackColor = true;
			this.AppendLexemButton.Click += new System.EventHandler(this.appendButton_Click);
			// 
			// RemoveConditionButton
			// 
			this.RemoveConditionButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.RemoveConditionButton.Image = ((System.Drawing.Image)(resources.GetObject("RemoveConditionButton.Image")));
			this.RemoveConditionButton.Location = new System.Drawing.Point(575, 174);
			this.RemoveConditionButton.Name = "RemoveConditionButton";
			this.RemoveConditionButton.Size = new System.Drawing.Size(30, 26);
			this.RemoveConditionButton.TabIndex = 4;
			this.ConditionEditToolTip.SetToolTip(this.RemoveConditionButton, "Remove condition");
			this.RemoveConditionButton.UseVisualStyleBackColor = true;
			this.RemoveConditionButton.Click += new System.EventHandler(this.RemoveConditionButton_Click);
			// 
			// NegationCheckBox
			// 
			this.NegationCheckBox.AutoSize = true;
			this.NegationCheckBox.Location = new System.Drawing.Point(242, 31);
			this.NegationCheckBox.Name = "NegationCheckBox";
			this.NegationCheckBox.Size = new System.Drawing.Size(69, 17);
			this.NegationCheckBox.TabIndex = 17;
			this.NegationCheckBox.Text = "Negation";
			this.ConditionEditToolTip.SetToolTip(this.NegationCheckBox, "Negates the condition if checked");
			this.NegationCheckBox.UseVisualStyleBackColor = true;
			// 
			// ConditionShowButton
			// 
			this.ConditionShowButton.Image = global::Harmonic.HarmonicResource.eye_16_bw;
			this.ConditionShowButton.Location = new System.Drawing.Point(321, 26);
			this.ConditionShowButton.Name = "ConditionShowButton";
			this.ConditionShowButton.Size = new System.Drawing.Size(30, 26);
			this.ConditionShowButton.TabIndex = 18;
			this.ConditionEditToolTip.SetToolTip(this.ConditionShowButton, "See");
			this.ConditionShowButton.UseVisualStyleBackColor = true;
			this.ConditionShowButton.Click += new System.EventHandler(this.ConditionShowButton_Click);
			// 
			// OkButton
			// 
			this.OkButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkButton.Location = new System.Drawing.Point(181, 249);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 12;
			this.OkButton.Text = "Ok";
			this.OkButton.UseVisualStyleBackColor = true;
			// 
			// CancelButton
			// 
			this.CancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelButton.Location = new System.Drawing.Point(352, 249);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(75, 23);
			this.CancelButton.TabIndex = 14;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			// 
			// LexemControl
			// 
			this.LexemControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LexemControl.Lexem = null;
			this.LexemControl.Location = new System.Drawing.Point(12, 216);
			this.LexemControl.Name = "LexemControl";
			this.LexemControl.Size = new System.Drawing.Size(558, 27);
			this.LexemControl.TabIndex = 10;
			this.LexemControl.Changed += new System.EventHandler(this.LexemControl_Changed);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "Comment";
			// 
			// TagTextBox
			// 
			this.TagTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TagTextBox.Location = new System.Drawing.Point(63, 2);
			this.TagTextBox.Name = "TagTextBox";
			this.TagTextBox.Size = new System.Drawing.Size(542, 20);
			this.TagTextBox.TabIndex = 16;
			// 
			// ConditionEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(612, 281);
			this.Controls.Add(this.ConditionShowButton);
			this.Controls.Add(this.NegationCheckBox);
			this.Controls.Add(this.TagTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.AppendConditionButton);
			this.Controls.Add(this.LexemControl);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TypeComboBox);
			this.Controls.Add(this.RemoveConditionButton);
			this.Controls.Add(this.AppendLexemButton);
			this.Controls.Add(this.ConditionDataGridView);
			this.MinimumSize = new System.Drawing.Size(400, 300);
			this.Name = "ConditionEditForm";
			this.Text = "ConditionEditForm";
			((System.ComponentModel.ISupportInitialize)(this.ConditionDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ConditionBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView ConditionDataGridView;
		private AppendButton AppendLexemButton;
		private RemoveButton RemoveConditionButton;
		private System.Windows.Forms.ComboBox TypeComboBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.BindingSource ConditionBindingSource;
		private LexControl LexemControl;
		private System.Windows.Forms.Button AppendConditionButton;
		private System.Windows.Forms.ToolTip ConditionEditToolTip;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TagTextBox;
		private System.Windows.Forms.CheckBox NegationCheckBox;
		private System.Windows.Forms.Button ConditionShowButton;
	}
}