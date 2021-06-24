namespace Harmonic
{
	partial class FinderForm
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

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinderForm));
			this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
			this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
			this.label5 = new System.Windows.Forms.Label();
			this.ConditionEditButton = new System.Windows.Forms.Button();
			this.ConditionShowButton = new System.Windows.Forms.Button();
			this.ConditionOpenButton = new System.Windows.Forms.Button();
			this.ConditionDataGridView = new System.Windows.Forms.DataGridView();
			this.LexemTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.LexemDataGridView = new System.Windows.Forms.DataGridView();
			this.ImmediatelyCheckBox = new System.Windows.Forms.CheckBox();
			this.TreatAllButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.FlogMarkButton = new System.Windows.Forms.Button();
			this.FlogTreatCurrentButton = new System.Windows.Forms.Button();
			this.FlogDataGridView = new System.Windows.Forms.DataGridView();
			this.MatchesDataGridView = new System.Windows.Forms.DataGridView();
			this.MainTabControl = new System.Windows.Forms.TabControl();
			this.ConditionsTabPage = new System.Windows.Forms.TabPage();
			this.ResultTabPage = new System.Windows.Forms.TabPage();
			this.label6 = new System.Windows.Forms.Label();
			this.MatchStringTextBox = new System.Windows.Forms.TextBox();
			this.MatchFileTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.ClearResultButton = new System.Windows.Forms.Button();
			this.MatchTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SessionTextBox = new System.Windows.Forms.TextBox();
			this.CancelButton = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.TreatInfoStatusLabel = new System.Windows.Forms.Label();
			this.TreatProgressBar = new System.Windows.Forms.ProgressBar();
			this.MatchesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ConditionBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.LexemBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.FlogBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.MainToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.ConditionSaveButton = new Harmonic.SaveButton(this.components);
			this.ConditionDeleteButton = new Harmonic.RemoveButton(this.components);
			this.ConditionAppendButton = new Harmonic.AppendButton(this.components);
			this.LexemDeleteButton = new Harmonic.RemoveButton(this.components);
			this.LexemAppendButton = new Harmonic.AppendButton(this.components);
			this.FlogRemoveButton = new Harmonic.RemoveButton(this.components);
			this.FlogAppendButton = new Harmonic.AppendButton(this.components);
			this.ResultSaveButton = new Harmonic.SaveButton(this.components);
			((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
			this.SplitContainer1.Panel1.SuspendLayout();
			this.SplitContainer1.Panel2.SuspendLayout();
			this.SplitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).BeginInit();
			this.SplitContainer2.Panel1.SuspendLayout();
			this.SplitContainer2.Panel2.SuspendLayout();
			this.SplitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ConditionDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LexemDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.FlogDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MatchesDataGridView)).BeginInit();
			this.MainTabControl.SuspendLayout();
			this.ConditionsTabPage.SuspendLayout();
			this.ResultTabPage.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MatchesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ConditionBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LexemBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.FlogBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// SplitContainer1
			// 
			this.SplitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SplitContainer1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.SplitContainer1.Location = new System.Drawing.Point(0, 3);
			this.SplitContainer1.MinimumSize = new System.Drawing.Size(600, 260);
			this.SplitContainer1.Name = "SplitContainer1";
			this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// SplitContainer1.Panel1
			// 
			this.SplitContainer1.Panel1.Controls.Add(this.SplitContainer2);
			this.SplitContainer1.Panel1MinSize = 100;
			// 
			// SplitContainer1.Panel2
			// 
			this.SplitContainer1.Panel2.AllowDrop = true;
			this.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.SplitContainer1.Panel2.Controls.Add(this.ImmediatelyCheckBox);
			this.SplitContainer1.Panel2.Controls.Add(this.FlogRemoveButton);
			this.SplitContainer1.Panel2.Controls.Add(this.TreatAllButton);
			this.SplitContainer1.Panel2.Controls.Add(this.FlogAppendButton);
			this.SplitContainer1.Panel2.Controls.Add(this.label2);
			this.SplitContainer1.Panel2.Controls.Add(this.FlogMarkButton);
			this.SplitContainer1.Panel2.Controls.Add(this.FlogTreatCurrentButton);
			this.SplitContainer1.Panel2.Controls.Add(this.FlogDataGridView);
			this.SplitContainer1.Panel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.Flog_DragDrop);
			this.SplitContainer1.Panel2.DragEnter += new System.Windows.Forms.DragEventHandler(this.Flog_DragEnter);
			this.SplitContainer1.Panel2.Enter += new System.EventHandler(this.Panel_Enter);
			this.SplitContainer1.Panel2.Leave += new System.EventHandler(this.Panel_Leave);
			this.SplitContainer1.Panel2MinSize = 140;
			this.SplitContainer1.Size = new System.Drawing.Size(1088, 546);
			this.SplitContainer1.SplitterDistance = 279;
			this.SplitContainer1.SplitterWidth = 2;
			this.SplitContainer1.TabIndex = 31;
			// 
			// SplitContainer2
			// 
			this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
			this.SplitContainer2.Name = "SplitContainer2";
			// 
			// SplitContainer2.Panel1
			// 
			this.SplitContainer2.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.SplitContainer2.Panel1.Controls.Add(this.label5);
			this.SplitContainer2.Panel1.Controls.Add(this.ConditionEditButton);
			this.SplitContainer2.Panel1.Controls.Add(this.ConditionShowButton);
			this.SplitContainer2.Panel1.Controls.Add(this.ConditionOpenButton);
			this.SplitContainer2.Panel1.Controls.Add(this.ConditionSaveButton);
			this.SplitContainer2.Panel1.Controls.Add(this.ConditionDeleteButton);
			this.SplitContainer2.Panel1.Controls.Add(this.ConditionAppendButton);
			this.SplitContainer2.Panel1.Controls.Add(this.ConditionDataGridView);
			this.SplitContainer2.Panel1.Enter += new System.EventHandler(this.Panel_Enter);
			this.SplitContainer2.Panel1.Leave += new System.EventHandler(this.Panel_Leave);
			this.SplitContainer2.Panel1MinSize = 380;
			// 
			// SplitContainer2.Panel2
			// 
			this.SplitContainer2.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.SplitContainer2.Panel2.Controls.Add(this.LexemTextBox);
			this.SplitContainer2.Panel2.Controls.Add(this.LexemDeleteButton);
			this.SplitContainer2.Panel2.Controls.Add(this.LexemAppendButton);
			this.SplitContainer2.Panel2.Controls.Add(this.label3);
			this.SplitContainer2.Panel2.Controls.Add(this.LexemDataGridView);
			this.SplitContainer2.Panel2.Enter += new System.EventHandler(this.Panel_Enter);
			this.SplitContainer2.Panel2.Leave += new System.EventHandler(this.Panel_Leave);
			this.SplitContainer2.Panel2MinSize = 200;
			this.SplitContainer2.Size = new System.Drawing.Size(1088, 279);
			this.SplitContainer2.SplitterDistance = 739;
			this.SplitContainer2.SplitterWidth = 2;
			this.SplitContainer2.TabIndex = 0;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.label5.Location = new System.Drawing.Point(6, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(140, 18);
			this.label5.TabIndex = 0;
			this.label5.Text = "Select rows which...";
			// 
			// ConditionEditButton
			// 
			this.ConditionEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ConditionEditButton.Image = global::Harmonic.HarmonicResource.edit_24;
			this.ConditionEditButton.Location = new System.Drawing.Point(615, 6);
			this.ConditionEditButton.Name = "ConditionEditButton";
			this.ConditionEditButton.Size = new System.Drawing.Size(30, 26);
			this.ConditionEditButton.TabIndex = 4;
			this.MainToolTip.SetToolTip(this.ConditionEditButton, "Edti root condition");
			this.ConditionEditButton.UseVisualStyleBackColor = true;
			this.ConditionEditButton.Click += new System.EventHandler(this.ConditionEditButton_Click_1);
			// 
			// ConditionShowButton
			// 
			this.ConditionShowButton.Image = global::Harmonic.HarmonicResource.eye_16_bw;
			this.ConditionShowButton.Location = new System.Drawing.Point(145, 6);
			this.ConditionShowButton.Name = "ConditionShowButton";
			this.ConditionShowButton.Size = new System.Drawing.Size(30, 26);
			this.ConditionShowButton.TabIndex = 1;
			this.MainToolTip.SetToolTip(this.ConditionShowButton, "Show condition");
			this.ConditionShowButton.UseVisualStyleBackColor = true;
			this.ConditionShowButton.Click += new System.EventHandler(this.button2_Click);
			// 
			// ConditionOpenButton
			// 
			this.ConditionOpenButton.Image = global::Harmonic.HarmonicResource.open_greenbook_24;
			this.ConditionOpenButton.Location = new System.Drawing.Point(233, 6);
			this.ConditionOpenButton.Name = "ConditionOpenButton";
			this.ConditionOpenButton.Size = new System.Drawing.Size(30, 26);
			this.ConditionOpenButton.TabIndex = 3;
			this.MainToolTip.SetToolTip(this.ConditionOpenButton, "Load condition from file");
			this.ConditionOpenButton.UseVisualStyleBackColor = true;
			this.ConditionOpenButton.Click += new System.EventHandler(this.ConditionOpenButton_Click);
			// 
			// ConditionDataGridView
			// 
			this.ConditionDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
			this.ConditionDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ConditionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.ConditionDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
			this.ConditionDataGridView.Location = new System.Drawing.Point(6, 37);
			this.ConditionDataGridView.Name = "ConditionDataGridView";
			this.ConditionDataGridView.RowHeadersVisible = false;
			this.ConditionDataGridView.Size = new System.Drawing.Size(723, 232);
			this.ConditionDataGridView.TabIndex = 0;
			this.ConditionDataGridView.DoubleClick += new System.EventHandler(this.ConditionDataGridView_DoubleClick);
			this.ConditionDataGridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ConditionDataGridView_KeyUp);
			// 
			// LexemTextBox
			// 
			this.LexemTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
			this.LexemTextBox.Location = new System.Drawing.Point(7, 37);
			this.LexemTextBox.Multiline = true;
			this.LexemTextBox.Name = "LexemTextBox";
			this.LexemTextBox.ReadOnly = true;
			this.LexemTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.LexemTextBox.Size = new System.Drawing.Size(318, 209);
			this.LexemTextBox.TabIndex = 1;
			this.LexemTextBox.Visible = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label3.Location = new System.Drawing.Point(3, 11);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(116, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "Current condition";
			// 
			// LexemDataGridView
			// 
			this.LexemDataGridView.AllowUserToAddRows = false;
			this.LexemDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
			this.LexemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.LexemDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
			this.LexemDataGridView.Location = new System.Drawing.Point(6, 37);
			this.LexemDataGridView.Name = "LexemDataGridView";
			this.LexemDataGridView.RowHeadersVisible = false;
			this.LexemDataGridView.RowTemplate.Height = 26;
			this.LexemDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.LexemDataGridView.Size = new System.Drawing.Size(332, 229);
			this.LexemDataGridView.TabIndex = 0;
			this.LexemDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.LexemDataGridView_CellValueChanged);
			// 
			// ImmediatelyCheckBox
			// 
			this.ImmediatelyCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ImmediatelyCheckBox.AutoSize = true;
			this.ImmediatelyCheckBox.Checked = true;
			this.ImmediatelyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ImmediatelyCheckBox.Location = new System.Drawing.Point(836, 9);
			this.ImmediatelyCheckBox.Name = "ImmediatelyCheckBox";
			this.ImmediatelyCheckBox.Size = new System.Drawing.Size(121, 19);
			this.ImmediatelyCheckBox.TabIndex = 38;
			this.ImmediatelyCheckBox.Text = "Start immediately";
			this.ImmediatelyCheckBox.UseVisualStyleBackColor = true;
			// 
			// TreatAllButton
			// 
			this.TreatAllButton.Image = global::Harmonic.HarmonicResource.play_blue_24;
			this.TreatAllButton.Location = new System.Drawing.Point(75, 2);
			this.TreatAllButton.Name = "TreatAllButton";
			this.TreatAllButton.Size = new System.Drawing.Size(30, 30);
			this.TreatAllButton.TabIndex = 1;
			this.MainToolTip.SetToolTip(this.TreatAllButton, "Start processing all untreated logs");
			this.TreatAllButton.UseVisualStyleBackColor = true;
			this.TreatAllButton.Click += new System.EventHandler(this.TreatAllButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label2.Location = new System.Drawing.Point(6, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 17);
			this.label2.TabIndex = 32;
			this.label2.Text = "Log\'s list";
			// 
			// FlogMarkButton
			// 
			this.FlogMarkButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.FlogMarkButton.Image = global::Harmonic.HarmonicResource.redo_24;
			this.FlogMarkButton.Location = new System.Drawing.Point(1052, 181);
			this.FlogMarkButton.Name = "FlogMarkButton";
			this.FlogMarkButton.Size = new System.Drawing.Size(30, 26);
			this.FlogMarkButton.TabIndex = 5;
			this.MainToolTip.SetToolTip(this.FlogMarkButton, "Mark current log as untreated");
			this.FlogMarkButton.UseVisualStyleBackColor = true;
			this.FlogMarkButton.Click += new System.EventHandler(this.FlogMarkButton_Click);
			// 
			// FlogTreatCurrentButton
			// 
			this.FlogTreatCurrentButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.FlogTreatCurrentButton.Image = global::Harmonic.HarmonicResource.arrowRight_24;
			this.FlogTreatCurrentButton.Location = new System.Drawing.Point(1052, 116);
			this.FlogTreatCurrentButton.Name = "FlogTreatCurrentButton";
			this.FlogTreatCurrentButton.Size = new System.Drawing.Size(30, 26);
			this.FlogTreatCurrentButton.TabIndex = 4;
			this.MainToolTip.SetToolTip(this.FlogTreatCurrentButton, "Start processing current log or queue it, if busy");
			this.FlogTreatCurrentButton.UseVisualStyleBackColor = true;
			this.FlogTreatCurrentButton.Click += new System.EventHandler(this.FlogTreatCurrentButton_Click);
			// 
			// FlogDataGridView
			// 
			this.FlogDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
			this.FlogDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.FlogDataGridView.Location = new System.Drawing.Point(6, 33);
			this.FlogDataGridView.Name = "FlogDataGridView";
			this.FlogDataGridView.RowHeadersVisible = false;
			this.FlogDataGridView.Size = new System.Drawing.Size(1035, 220);
			this.FlogDataGridView.TabIndex = 0;
			// 
			// MatchesDataGridView
			// 
			this.MatchesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MatchesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.MatchesDataGridView.Location = new System.Drawing.Point(6, 33);
			this.MatchesDataGridView.Name = "MatchesDataGridView";
			this.MatchesDataGridView.ReadOnly = true;
			this.MatchesDataGridView.RowHeadersVisible = false;
			this.MatchesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.MatchesDataGridView.Size = new System.Drawing.Size(1081, 406);
			this.MatchesDataGridView.TabIndex = 3;
			// 
			// MainTabControl
			// 
			this.MainTabControl.Controls.Add(this.ConditionsTabPage);
			this.MainTabControl.Controls.Add(this.ResultTabPage);
			this.MainTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.MainTabControl.Location = new System.Drawing.Point(0, 0);
			this.MainTabControl.Name = "MainTabControl";
			this.MainTabControl.SelectedIndex = 0;
			this.MainTabControl.Size = new System.Drawing.Size(1101, 580);
			this.MainTabControl.TabIndex = 0;
			// 
			// ConditionsTabPage
			// 
			this.ConditionsTabPage.Controls.Add(this.SplitContainer1);
			this.ConditionsTabPage.Location = new System.Drawing.Point(4, 24);
			this.ConditionsTabPage.Name = "ConditionsTabPage";
			this.ConditionsTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.ConditionsTabPage.Size = new System.Drawing.Size(1093, 552);
			this.ConditionsTabPage.TabIndex = 0;
			this.ConditionsTabPage.Text = "Conditions";
			this.ConditionsTabPage.UseVisualStyleBackColor = true;
			// 
			// ResultTabPage
			// 
			this.ResultTabPage.Controls.Add(this.ResultSaveButton);
			this.ResultTabPage.Controls.Add(this.label6);
			this.ResultTabPage.Controls.Add(this.MatchStringTextBox);
			this.ResultTabPage.Controls.Add(this.MatchFileTextBox);
			this.ResultTabPage.Controls.Add(this.label4);
			this.ResultTabPage.Controls.Add(this.ClearResultButton);
			this.ResultTabPage.Controls.Add(this.MatchTextBox);
			this.ResultTabPage.Controls.Add(this.label1);
			this.ResultTabPage.Controls.Add(this.SessionTextBox);
			this.ResultTabPage.Controls.Add(this.MatchesDataGridView);
			this.ResultTabPage.Location = new System.Drawing.Point(4, 24);
			this.ResultTabPage.Name = "ResultTabPage";
			this.ResultTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.ResultTabPage.Size = new System.Drawing.Size(1093, 552);
			this.ResultTabPage.TabIndex = 1;
			this.ResultTabPage.Text = "Result";
			this.ResultTabPage.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(855, 449);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(39, 15);
			this.label6.TabIndex = 13;
			this.label6.Text = "String";
			// 
			// MatchStringTextBox
			// 
			this.MatchStringTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.MatchStringTextBox.Location = new System.Drawing.Point(895, 446);
			this.MatchStringTextBox.Name = "MatchStringTextBox";
			this.MatchStringTextBox.ReadOnly = true;
			this.MatchStringTextBox.Size = new System.Drawing.Size(134, 21);
			this.MatchStringTextBox.TabIndex = 12;
			// 
			// MatchFileTextBox
			// 
			this.MatchFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MatchFileTextBox.Location = new System.Drawing.Point(59, 447);
			this.MatchFileTextBox.Name = "MatchFileTextBox";
			this.MatchFileTextBox.ReadOnly = true;
			this.MatchFileTextBox.Size = new System.Drawing.Size(790, 21);
			this.MatchFileTextBox.TabIndex = 11;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 450);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(27, 15);
			this.label4.TabIndex = 10;
			this.label4.Text = "File";
			// 
			// ClearResultButton
			// 
			this.ClearResultButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ClearResultButton.Location = new System.Drawing.Point(1012, 6);
			this.ClearResultButton.Name = "ClearResultButton";
			this.ClearResultButton.Size = new System.Drawing.Size(75, 23);
			this.ClearResultButton.TabIndex = 9;
			this.ClearResultButton.Text = "Clear";
			this.ClearResultButton.UseVisualStyleBackColor = true;
			this.ClearResultButton.Click += new System.EventHandler(this.ClearResultButton_Click);
			// 
			// MatchTextBox
			// 
			this.MatchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MatchTextBox.Location = new System.Drawing.Point(8, 472);
			this.MatchTextBox.Multiline = true;
			this.MatchTextBox.Name = "MatchTextBox";
			this.MatchTextBox.ReadOnly = true;
			this.MatchTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.MatchTextBox.Size = new System.Drawing.Size(1076, 74);
			this.MatchTextBox.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 15);
			this.label1.TabIndex = 7;
			this.label1.Text = "Session:";
			// 
			// SessionTextBox
			// 
			this.SessionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SessionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.SessionTextBox.Location = new System.Drawing.Point(69, 6);
			this.SessionTextBox.Name = "SessionTextBox";
			this.SessionTextBox.ReadOnly = true;
			this.SessionTextBox.Size = new System.Drawing.Size(937, 23);
			this.SessionTextBox.TabIndex = 6;
			// 
			// CancelButton
			// 
			this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelButton.Enabled = false;
			this.CancelButton.Image = global::Harmonic.HarmonicResource.stop_16;
			this.CancelButton.Location = new System.Drawing.Point(1069, 2);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(25, 25);
			this.CancelButton.TabIndex = 0;
			this.MainToolTip.SetToolTip(this.CancelButton, "Stop processing");
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Visible = false;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.TreatInfoStatusLabel);
			this.panel1.Controls.Add(this.TreatProgressBar);
			this.panel1.Controls.Add(this.CancelButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 585);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1101, 30);
			this.panel1.TabIndex = 12;
			// 
			// TreatInfoStatusLabel
			// 
			this.TreatInfoStatusLabel.Location = new System.Drawing.Point(7, 6);
			this.TreatInfoStatusLabel.Name = "TreatInfoStatusLabel";
			this.TreatInfoStatusLabel.Size = new System.Drawing.Size(67, 17);
			this.TreatInfoStatusLabel.TabIndex = 9;
			this.TreatInfoStatusLabel.Text = "Process Info";
			// 
			// TreatProgressBar
			// 
			this.TreatProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TreatProgressBar.Location = new System.Drawing.Point(80, 9);
			this.TreatProgressBar.Name = "TreatProgressBar";
			this.TreatProgressBar.Size = new System.Drawing.Size(972, 10);
			this.TreatProgressBar.TabIndex = 0;
			this.TreatProgressBar.Visible = false;
			// 
			// MatchesBindingSource
			// 
			this.MatchesBindingSource.AllowNew = false;
			this.MatchesBindingSource.CurrentChanged += new System.EventHandler(this.MatchesBindingSource_CurrentChanged);
			// 
			// ConditionBindingSource
			// 
			this.ConditionBindingSource.CurrentChanged += new System.EventHandler(this.ConditionBindingSource_CurrentChanged);
			// 
			// ConditionSaveButton
			// 
			this.ConditionSaveButton.DefaultExt = "xml";
			this.ConditionSaveButton.Filter = "condition files (*.xml)|*.xml|All files|*.*";
			this.ConditionSaveButton.Image = ((System.Drawing.Image)(resources.GetObject("ConditionSaveButton.Image")));
			this.ConditionSaveButton.Location = new System.Drawing.Point(196, 6);
			this.ConditionSaveButton.Name = "ConditionSaveButton";
			this.ConditionSaveButton.Size = new System.Drawing.Size(30, 26);
			this.ConditionSaveButton.TabIndex = 2;
			this.MainToolTip.SetToolTip(this.ConditionSaveButton, "Save condition to config file");
			this.ConditionSaveButton.UseVisualStyleBackColor = true;
			this.ConditionSaveButton.Save += new System.EventHandler<Harmonic.SaveButton.FileArgs>(this.ConditionSaveButton_Save);
			// 
			// ConditionDeleteButton
			// 
			this.ConditionDeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ConditionDeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("ConditionDeleteButton.Image")));
			this.ConditionDeleteButton.Location = new System.Drawing.Point(698, 6);
			this.ConditionDeleteButton.Name = "ConditionDeleteButton";
			this.ConditionDeleteButton.Size = new System.Drawing.Size(30, 26);
			this.ConditionDeleteButton.TabIndex = 6;
			this.MainToolTip.SetToolTip(this.ConditionDeleteButton, "Remove current row from conditions");
			this.ConditionDeleteButton.UseVisualStyleBackColor = true;
			this.ConditionDeleteButton.Click += new System.EventHandler(this.ConditionDeleteButton_Click);
			// 
			// ConditionAppendButton
			// 
			this.ConditionAppendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ConditionAppendButton.Image = ((System.Drawing.Image)(resources.GetObject("ConditionAppendButton.Image")));
			this.ConditionAppendButton.Location = new System.Drawing.Point(659, 6);
			this.ConditionAppendButton.Name = "ConditionAppendButton";
			this.ConditionAppendButton.Size = new System.Drawing.Size(30, 26);
			this.ConditionAppendButton.TabIndex = 5;
			this.MainToolTip.SetToolTip(this.ConditionAppendButton, "Add new row to conditions");
			this.ConditionAppendButton.UseVisualStyleBackColor = true;
			this.ConditionAppendButton.Click += new System.EventHandler(this.ConditionAppendButton_Click);
			// 
			// LexemDeleteButton
			// 
			this.LexemDeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LexemDeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("LexemDeleteButton.Image")));
			this.LexemDeleteButton.Location = new System.Drawing.Point(307, 6);
			this.LexemDeleteButton.Name = "LexemDeleteButton";
			this.LexemDeleteButton.Size = new System.Drawing.Size(30, 26);
			this.LexemDeleteButton.TabIndex = 3;
			this.MainToolTip.SetToolTip(this.LexemDeleteButton, "Remove current clause from condition");
			this.LexemDeleteButton.UseVisualStyleBackColor = true;
			this.LexemDeleteButton.Click += new System.EventHandler(this.LexemDeleteButton_Click);
			// 
			// LexemAppendButton
			// 
			this.LexemAppendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LexemAppendButton.Image = ((System.Drawing.Image)(resources.GetObject("LexemAppendButton.Image")));
			this.LexemAppendButton.Location = new System.Drawing.Point(268, 6);
			this.LexemAppendButton.Name = "LexemAppendButton";
			this.LexemAppendButton.Size = new System.Drawing.Size(30, 26);
			this.LexemAppendButton.TabIndex = 2;
			this.MainToolTip.SetToolTip(this.LexemAppendButton, "Add new clause to current condition");
			this.LexemAppendButton.UseVisualStyleBackColor = true;
			this.LexemAppendButton.Click += new System.EventHandler(this.LexemAppendButton_Click);
			// 
			// FlogRemoveButton
			// 
			this.FlogRemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.FlogRemoveButton.Image = ((System.Drawing.Image)(resources.GetObject("FlogRemoveButton.Image")));
			this.FlogRemoveButton.Location = new System.Drawing.Point(1019, 6);
			this.FlogRemoveButton.Name = "FlogRemoveButton";
			this.FlogRemoveButton.Size = new System.Drawing.Size(30, 26);
			this.FlogRemoveButton.TabIndex = 3;
			this.MainToolTip.SetToolTip(this.FlogRemoveButton, "Remove current log from list");
			this.FlogRemoveButton.UseVisualStyleBackColor = true;
			this.FlogRemoveButton.Click += new System.EventHandler(this.RemoveFlogButton_Click);
			// 
			// FlogAppendButton
			// 
			this.FlogAppendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.FlogAppendButton.Image = ((System.Drawing.Image)(resources.GetObject("FlogAppendButton.Image")));
			this.FlogAppendButton.Location = new System.Drawing.Point(977, 6);
			this.FlogAppendButton.Name = "FlogAppendButton";
			this.FlogAppendButton.Size = new System.Drawing.Size(30, 26);
			this.FlogAppendButton.TabIndex = 2;
			this.MainToolTip.SetToolTip(this.FlogAppendButton, "Add log|logs for processing");
			this.FlogAppendButton.UseVisualStyleBackColor = true;
			this.FlogAppendButton.Click += new System.EventHandler(this.FlogAppendButton_Click);
			// 
			// ResultSaveButton
			// 
			this.ResultSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ResultSaveButton.DefaultExt = "txt";
			this.ResultSaveButton.Filter = "text files (*.txt)|*.txt|log files (*.log)|*.log|All files|*.*";
			this.ResultSaveButton.Image = ((System.Drawing.Image)(resources.GetObject("ResultSaveButton.Image")));
			this.ResultSaveButton.Location = new System.Drawing.Point(1053, 443);
			this.ResultSaveButton.Name = "ResultSaveButton";
			this.ResultSaveButton.Size = new System.Drawing.Size(30, 26);
			this.ResultSaveButton.TabIndex = 14;
			this.ResultSaveButton.UseVisualStyleBackColor = true;
			this.ResultSaveButton.BeforeSave += new System.EventHandler<Harmonic.SaveButton.ConfirmArgs>(this.ResultSaveButton_BeforeSave);
			this.ResultSaveButton.Save += new System.EventHandler<Harmonic.SaveButton.FileArgs>(this.ResultSaveButton_Save);
			// 
			// FinderForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1101, 615);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.MainTabControl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(620, 420);
			this.Name = "FinderForm";
			this.Text = "Harmonic Log Processor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FinderForm_FormClosing);
			this.Shown += new System.EventHandler(this.FinderForm_Shown);
			this.SplitContainer1.Panel1.ResumeLayout(false);
			this.SplitContainer1.Panel2.ResumeLayout(false);
			this.SplitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
			this.SplitContainer1.ResumeLayout(false);
			this.SplitContainer2.Panel1.ResumeLayout(false);
			this.SplitContainer2.Panel1.PerformLayout();
			this.SplitContainer2.Panel2.ResumeLayout(false);
			this.SplitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).EndInit();
			this.SplitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ConditionDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LexemDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.FlogDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MatchesDataGridView)).EndInit();
			this.MainTabControl.ResumeLayout(false);
			this.ConditionsTabPage.ResumeLayout(false);
			this.ResultTabPage.ResumeLayout(false);
			this.ResultTabPage.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MatchesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ConditionBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LexemBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.FlogBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.BindingSource MatchesBindingSource;
		private System.Windows.Forms.DataGridView MatchesDataGridView;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.BindingSource ConditionBindingSource;
		private System.Windows.Forms.TabControl MainTabControl;
		private System.Windows.Forms.TabPage ConditionsTabPage;
		private System.Windows.Forms.TabPage ResultTabPage;
		private System.Windows.Forms.BindingSource LexemBindingSource;
		private System.Windows.Forms.TextBox MatchTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox SessionTextBox;
		private System.Windows.Forms.Button ClearResultButton;
		private System.Windows.Forms.TextBox MatchFileTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ProgressBar TreatProgressBar;
		private System.Windows.Forms.Label TreatInfoStatusLabel;
		private System.Windows.Forms.BindingSource FlogBindingSource;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox MatchStringTextBox;
		private System.Windows.Forms.SplitContainer SplitContainer1;
		private System.Windows.Forms.SplitContainer SplitContainer2;
		private System.Windows.Forms.DataGridView ConditionDataGridView;
		private System.Windows.Forms.DataGridView LexemDataGridView;
		private System.Windows.Forms.Button FlogMarkButton;
		private System.Windows.Forms.Button FlogTreatCurrentButton;
		private System.Windows.Forms.DataGridView FlogDataGridView;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private AppendButton FlogAppendButton;
		private AppendButton ConditionAppendButton;
		private AppendButton LexemAppendButton;
		private RemoveButton ConditionDeleteButton;
		private RemoveButton LexemDeleteButton;
		private RemoveButton FlogRemoveButton;
		private System.Windows.Forms.Button TreatAllButton;
		private System.Windows.Forms.CheckBox ImmediatelyCheckBox;
		private System.Windows.Forms.ToolTip MainToolTip;
		private SaveButton ConditionSaveButton;
		private SaveButton ResultSaveButton;
		private System.Windows.Forms.Button ConditionOpenButton;
		private System.Windows.Forms.Button ConditionShowButton;
		private System.Windows.Forms.TextBox LexemTextBox;
		private System.Windows.Forms.Button ConditionEditButton;
		private System.Windows.Forms.Label label5;
	}
}

