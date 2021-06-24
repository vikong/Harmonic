namespace time
{
    partial class frmTimeInc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimeInc));
            this.FileDialogSource = new System.Windows.Forms.OpenFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.destFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDestFolderChoose = new System.Windows.Forms.Button();
            this.txtDestFile = new System.Windows.Forms.TextBox();
            this.btnFileSourceOpen = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.pgfMethod = new System.Windows.Forms.TabControl();
            this.pgTimeShift = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.chkSign = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.udnSeconds = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.udnMinutes = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.udnHours = new System.Windows.Forms.NumericUpDown();
            this.pgLex = new System.Windows.Forms.TabPage();
            this.btnClearCondition = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pgTime = new System.Windows.Forms.TabPage();
            this.chkBefore = new System.Windows.Forms.CheckBox();
            this.dtpBeforeTime = new System.Windows.Forms.DateTimePicker();
            this.dtpBeforeDate = new System.Windows.Forms.DateTimePicker();
            this.chkAfter = new System.Windows.Forms.CheckBox();
            this.dtpAfterTime = new System.Windows.Forms.DateTimePicker();
            this.dtpAfterDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnClearLog = new System.Windows.Forms.Button();
            this.chkOpen = new System.Windows.Forms.CheckBox();
            this.cmbSourceFile = new System.Windows.Forms.ComboBox();
            this.ctlLexem4 = new time.ctlLexem();
            this.ctlLexem3 = new time.ctlLexem();
            this.ctlLexem2 = new time.ctlLexem();
            this.ctlLexem1 = new time.ctlLexem();
            this.pgfMethod.SuspendLayout();
            this.pgTimeShift.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udnSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udnMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udnHours)).BeginInit();
            this.pgLex.SuspendLayout();
            this.pgTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileDialogSource
            // 
            this.FileDialogSource.DefaultExt = "log";
            this.FileDialogSource.Filter = "Logs|*.log|Text files|*.txt|All files|*.*";
            this.FileDialogSource.FileOk += new System.ComponentModel.CancelEventHandler(this.FileDialogSource_FileOk);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "down.png");
            this.imageList1.Images.SetKeyName(1, "up.png");
            this.imageList1.Images.SetKeyName(2, "clock.png");
            this.imageList1.Images.SetKeyName(3, "opera.png");
            this.imageList1.Images.SetKeyName(4, "clicknrun.png");
            this.imageList1.Images.SetKeyName(5, "clicknrungrey.png");
            this.imageList1.Images.SetKeyName(6, "clear.png");
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(4, 259);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(495, 141);
            this.txtLog.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Output";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Source";
            // 
            // btnDestFolderChoose
            // 
            this.btnDestFolderChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDestFolderChoose.Location = new System.Drawing.Point(532, 28);
            this.btnDestFolderChoose.Name = "btnDestFolderChoose";
            this.btnDestFolderChoose.Size = new System.Drawing.Size(22, 23);
            this.btnDestFolderChoose.TabIndex = 51;
            this.btnDestFolderChoose.Text = "...";
            this.toolTip1.SetToolTip(this.btnDestFolderChoose, "Choose file");
            this.btnDestFolderChoose.UseVisualStyleBackColor = true;
            this.btnDestFolderChoose.Click += new System.EventHandler(this.btnDestFolderChoose_Click);
            // 
            // txtDestFile
            // 
            this.txtDestFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestFile.Location = new System.Drawing.Point(56, 29);
            this.txtDestFile.Name = "txtDestFile";
            this.txtDestFile.Size = new System.Drawing.Size(468, 20);
            this.txtDestFile.TabIndex = 50;
            // 
            // btnFileSourceOpen
            // 
            this.btnFileSourceOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileSourceOpen.Location = new System.Drawing.Point(532, 3);
            this.btnFileSourceOpen.Name = "btnFileSourceOpen";
            this.btnFileSourceOpen.Size = new System.Drawing.Size(22, 23);
            this.btnFileSourceOpen.TabIndex = 49;
            this.btnFileSourceOpen.Text = "...";
            this.toolTip1.SetToolTip(this.btnFileSourceOpen, "Choose file");
            this.btnFileSourceOpen.UseVisualStyleBackColor = true;
            this.btnFileSourceOpen.Click += new System.EventHandler(this.btnFileSourceOpen_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnStart.ImageKey = "clicknrun.png";
            this.btnStart.ImageList = this.imageList1;
            this.btnStart.Location = new System.Drawing.Point(504, 306);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(48, 48);
            this.btnStart.TabIndex = 47;
            this.toolTip1.SetToolTip(this.btnStart, "Start processing");
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pgfMethod
            // 
            this.pgfMethod.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.pgfMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pgfMethod.Controls.Add(this.pgTimeShift);
            this.pgfMethod.Controls.Add(this.pgLex);
            this.pgfMethod.Controls.Add(this.pgTime);
            this.pgfMethod.ImageList = this.imageList1;
            this.pgfMethod.ItemSize = new System.Drawing.Size(34, 24);
            this.pgfMethod.Location = new System.Drawing.Point(3, 75);
            this.pgfMethod.Multiline = true;
            this.pgfMethod.Name = "pgfMethod";
            this.pgfMethod.Padding = new System.Drawing.Point(0, 0);
            this.pgfMethod.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pgfMethod.SelectedIndex = 0;
            this.pgfMethod.ShowToolTips = true;
            this.pgfMethod.Size = new System.Drawing.Size(554, 182);
            this.pgfMethod.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.pgfMethod.TabIndex = 62;
            // 
            // pgTimeShift
            // 
            this.pgTimeShift.Controls.Add(this.label7);
            this.pgTimeShift.Controls.Add(this.lblTime);
            this.pgTimeShift.Controls.Add(this.chkSign);
            this.pgTimeShift.Controls.Add(this.label5);
            this.pgTimeShift.Controls.Add(this.udnSeconds);
            this.pgTimeShift.Controls.Add(this.label4);
            this.pgTimeShift.Controls.Add(this.udnMinutes);
            this.pgTimeShift.Controls.Add(this.label3);
            this.pgTimeShift.Controls.Add(this.udnHours);
            this.pgTimeShift.ImageKey = "up.png";
            this.pgTimeShift.Location = new System.Drawing.Point(28, 4);
            this.pgTimeShift.Margin = new System.Windows.Forms.Padding(0);
            this.pgTimeShift.Name = "pgTimeShift";
            this.pgTimeShift.Size = new System.Drawing.Size(522, 174);
            this.pgTimeShift.TabIndex = 0;
            this.pgTimeShift.ToolTipText = "Time shift";
            this.pgTimeShift.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(298, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 76;
            this.label7.Text = "s";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(8, 11);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(152, 13);
            this.lblTime.TabIndex = 75;
            this.lblTime.Text = "Will shift the time at start of line";
            // 
            // chkSign
            // 
            this.chkSign.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSign.AutoSize = true;
            this.chkSign.Checked = true;
            this.chkSign.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkSign.ImageKey = "up.png";
            this.chkSign.ImageList = this.imageList1;
            this.chkSign.Location = new System.Drawing.Point(109, 33);
            this.chkSign.Name = "chkSign";
            this.chkSign.Size = new System.Drawing.Size(22, 22);
            this.chkSign.TabIndex = 68;
            this.toolTip1.SetToolTip(this.chkSign, "Down|up");
            this.chkSign.UseVisualStyleBackColor = false;
            this.chkSign.Click += new System.EventHandler(this.chkSign_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 74;
            this.label5.Text = "Time shift";
            // 
            // udnSeconds
            // 
            this.udnSeconds.Location = new System.Drawing.Point(256, 34);
            this.udnSeconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.udnSeconds.Name = "udnSeconds";
            this.udnSeconds.Size = new System.Drawing.Size(40, 20);
            this.udnSeconds.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(235, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "m:";
            // 
            // udnMinutes
            // 
            this.udnMinutes.Location = new System.Drawing.Point(193, 34);
            this.udnMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.udnMinutes.Name = "udnMinutes";
            this.udnMinutes.Size = new System.Drawing.Size(40, 20);
            this.udnMinutes.TabIndex = 70;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(175, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 72;
            this.label3.Text = "h:";
            // 
            // udnHours
            // 
            this.udnHours.Location = new System.Drawing.Point(136, 34);
            this.udnHours.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.udnHours.Name = "udnHours";
            this.udnHours.Size = new System.Drawing.Size(40, 20);
            this.udnHours.TabIndex = 69;
            // 
            // pgLex
            // 
            this.pgLex.Controls.Add(this.btnClearCondition);
            this.pgLex.Controls.Add(this.label10);
            this.pgLex.Controls.Add(this.label9);
            this.pgLex.Controls.Add(this.label8);
            this.pgLex.Controls.Add(this.label6);
            this.pgLex.Controls.Add(this.ctlLexem4);
            this.pgLex.Controls.Add(this.ctlLexem3);
            this.pgLex.Controls.Add(this.ctlLexem2);
            this.pgLex.Controls.Add(this.ctlLexem1);
            this.pgLex.ImageKey = "opera.png";
            this.pgLex.Location = new System.Drawing.Point(28, 4);
            this.pgLex.Margin = new System.Windows.Forms.Padding(0);
            this.pgLex.Name = "pgLex";
            this.pgLex.Size = new System.Drawing.Size(522, 174);
            this.pgLex.TabIndex = 1;
            this.pgLex.ToolTipText = "String remove";
            this.pgLex.UseVisualStyleBackColor = true;
            // 
            // btnClearCondition
            // 
            this.btnClearCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearCondition.FlatAppearance.BorderSize = 0;
            this.btnClearCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCondition.ImageKey = "clear.png";
            this.btnClearCondition.ImageList = this.imageList1;
            this.btnClearCondition.Location = new System.Drawing.Point(489, 4);
            this.btnClearCondition.Name = "btnClearCondition";
            this.btnClearCondition.Size = new System.Drawing.Size(23, 23);
            this.btnClearCondition.TabIndex = 103;
            this.toolTip1.SetToolTip(this.btnClearCondition, "Drop conditions");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(36, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 102;
            this.label10.Text = "OR";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(36, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 13);
            this.label9.TabIndex = 101;
            this.label9.Text = "OR";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(36, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 100;
            this.label8.Text = "OR";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 95;
            this.label6.Text = "Will remove lines that";
            // 
            // pgTime
            // 
            this.pgTime.Controls.Add(this.chkBefore);
            this.pgTime.Controls.Add(this.dtpBeforeTime);
            this.pgTime.Controls.Add(this.dtpBeforeDate);
            this.pgTime.Controls.Add(this.chkAfter);
            this.pgTime.Controls.Add(this.dtpAfterTime);
            this.pgTime.Controls.Add(this.dtpAfterDate);
            this.pgTime.Controls.Add(this.label11);
            this.pgTime.ImageKey = "clock.png";
            this.pgTime.Location = new System.Drawing.Point(28, 4);
            this.pgTime.Name = "pgTime";
            this.pgTime.Size = new System.Drawing.Size(522, 174);
            this.pgTime.TabIndex = 3;
            this.pgTime.UseVisualStyleBackColor = true;
            // 
            // chkBefore
            // 
            this.chkBefore.AutoSize = true;
            this.chkBefore.Checked = true;
            this.chkBefore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBefore.Location = new System.Drawing.Point(59, 55);
            this.chkBefore.Name = "chkBefore";
            this.chkBefore.Size = new System.Drawing.Size(56, 17);
            this.chkBefore.TabIndex = 96;
            this.chkBefore.Text = "before";
            this.chkBefore.UseVisualStyleBackColor = true;
            // 
            // dtpBeforeTime
            // 
            this.dtpBeforeTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpBeforeTime.Location = new System.Drawing.Point(214, 53);
            this.dtpBeforeTime.Name = "dtpBeforeTime";
            this.dtpBeforeTime.ShowUpDown = true;
            this.dtpBeforeTime.Size = new System.Drawing.Size(72, 20);
            this.dtpBeforeTime.TabIndex = 98;
            // 
            // dtpBeforeDate
            // 
            this.dtpBeforeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBeforeDate.Location = new System.Drawing.Point(117, 53);
            this.dtpBeforeDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpBeforeDate.Name = "dtpBeforeDate";
            this.dtpBeforeDate.Size = new System.Drawing.Size(91, 20);
            this.dtpBeforeDate.TabIndex = 97;
            // 
            // chkAfter
            // 
            this.chkAfter.AutoSize = true;
            this.chkAfter.Checked = true;
            this.chkAfter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAfter.Location = new System.Drawing.Point(59, 29);
            this.chkAfter.Name = "chkAfter";
            this.chkAfter.Size = new System.Drawing.Size(47, 17);
            this.chkAfter.TabIndex = 93;
            this.chkAfter.Text = "after";
            this.chkAfter.UseVisualStyleBackColor = true;
            // 
            // dtpAfterTime
            // 
            this.dtpAfterTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpAfterTime.Location = new System.Drawing.Point(214, 27);
            this.dtpAfterTime.Name = "dtpAfterTime";
            this.dtpAfterTime.ShowUpDown = true;
            this.dtpAfterTime.Size = new System.Drawing.Size(72, 20);
            this.dtpAfterTime.TabIndex = 95;
            // 
            // dtpAfterDate
            // 
            this.dtpAfterDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAfterDate.Location = new System.Drawing.Point(117, 27);
            this.dtpAfterDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpAfterDate.Name = "dtpAfterDate";
            this.dtpAfterDate.Size = new System.Drawing.Size(91, 20);
            this.dtpAfterDate.TabIndex = 94;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 13);
            this.label11.TabIndex = 92;
            this.label11.Text = "Leave lines with time";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.FlatAppearance.BorderSize = 0;
            this.btnClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLog.ImageKey = "clear.png";
            this.btnClearLog.ImageList = this.imageList1;
            this.btnClearLog.Location = new System.Drawing.Point(513, 260);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(23, 21);
            this.btnClearLog.TabIndex = 87;
            this.toolTip1.SetToolTip(this.btnClearLog, "Clear log");
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // chkOpen
            // 
            this.chkOpen.AutoSize = true;
            this.chkOpen.Checked = true;
            this.chkOpen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpen.Location = new System.Drawing.Point(11, 55);
            this.chkOpen.Name = "chkOpen";
            this.chkOpen.Size = new System.Drawing.Size(133, 17);
            this.chkOpen.TabIndex = 88;
            this.chkOpen.Text = "Open when processed";
            this.chkOpen.UseVisualStyleBackColor = true;
            // 
            // cmbSourceFile
            // 
            this.cmbSourceFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSourceFile.FormattingEnabled = true;
            this.cmbSourceFile.Location = new System.Drawing.Point(56, 4);
            this.cmbSourceFile.Name = "cmbSourceFile";
            this.cmbSourceFile.Size = new System.Drawing.Size(468, 21);
            this.cmbSourceFile.TabIndex = 89;
            // 
            // ctlLexem4
            // 
            this.ctlLexem4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlLexem4.Location = new System.Drawing.Point(44, 109);
            this.ctlLexem4.Name = "ctlLexem4";
            this.ctlLexem4.Size = new System.Drawing.Size(450, 25);
            this.ctlLexem4.TabIndex = 99;
            // 
            // ctlLexem3
            // 
            this.ctlLexem3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlLexem3.Location = new System.Drawing.Point(44, 78);
            this.ctlLexem3.Name = "ctlLexem3";
            this.ctlLexem3.Size = new System.Drawing.Size(450, 25);
            this.ctlLexem3.TabIndex = 98;
            // 
            // ctlLexem2
            // 
            this.ctlLexem2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlLexem2.Location = new System.Drawing.Point(44, 47);
            this.ctlLexem2.Name = "ctlLexem2";
            this.ctlLexem2.Size = new System.Drawing.Size(450, 25);
            this.ctlLexem2.TabIndex = 97;
            // 
            // ctlLexem1
            // 
            this.ctlLexem1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlLexem1.Location = new System.Drawing.Point(44, 20);
            this.ctlLexem1.Name = "ctlLexem1";
            this.ctlLexem1.Size = new System.Drawing.Size(450, 25);
            this.ctlLexem1.TabIndex = 96;
            // 
            // frmTimeInc
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 403);
            this.Controls.Add(this.cmbSourceFile);
            this.Controls.Add(this.chkOpen);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.pgfMethod);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDestFolderChoose);
            this.Controls.Add(this.txtDestFile);
            this.Controls.Add(this.btnFileSourceOpen);
            this.Controls.Add(this.btnStart);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 355);
            this.Name = "frmTimeInc";
            this.Text = "Harmonic Log Processor";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmTimeInc_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmTimeInc_DragEnter);
            this.pgfMethod.ResumeLayout(false);
            this.pgTimeShift.ResumeLayout(false);
            this.pgTimeShift.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udnSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udnMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udnHours)).EndInit();
            this.pgLex.ResumeLayout(false);
            this.pgLex.PerformLayout();
            this.pgTime.ResumeLayout(false);
            this.pgTime.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog FileDialogSource;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDestFolderChoose;
        private System.Windows.Forms.TextBox txtDestFile;
        private System.Windows.Forms.Button btnFileSourceOpen;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TabControl pgfMethod;
        private System.Windows.Forms.TabPage pgTimeShift;
        private System.Windows.Forms.TabPage pgLex;
        private System.Windows.Forms.CheckBox chkSign;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown udnSeconds;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown udnMinutes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown udnHours;
        private System.Windows.Forms.FolderBrowserDialog destFolder;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.CheckBox chkOpen;
        private System.Windows.Forms.ComboBox cmbSourceFile;
        private System.Windows.Forms.TabPage pgTime;
        private System.Windows.Forms.CheckBox chkBefore;
        private System.Windows.Forms.DateTimePicker dtpBeforeTime;
        private System.Windows.Forms.DateTimePicker dtpBeforeDate;
        private System.Windows.Forms.CheckBox chkAfter;
        private System.Windows.Forms.DateTimePicker dtpAfterTime;
        private System.Windows.Forms.DateTimePicker dtpAfterDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnClearCondition;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private ctlLexem ctlLexem4;
        private ctlLexem ctlLexem3;
        private ctlLexem ctlLexem2;
        private ctlLexem ctlLexem1;

    }
}

