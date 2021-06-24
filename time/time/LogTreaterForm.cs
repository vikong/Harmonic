using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Text;



namespace time
{
    public partial class frmTimeInc : Form
    {
        TimeFileTreater tft = new TimeFileTreater();

        const int MaxHist = 10;
        int _numOfTreated=0;

        public frmTimeInc()
        {
            InitializeComponent();
        }

        public int AddToTreated(string file)
        {
            if (!cmbSourceFile.Items.Contains(file))
            {
                if (_numOfTreated < MaxHist) { cmbSourceFile.Items.Add(file); _numOfTreated++; }
                else { cmbSourceFile.Items.RemoveAt(0); cmbSourceFile.Items.Add(file); }
                cmbSourceFile.SelectedIndex = (_numOfTreated - 1);
            }
            else
            { }
            return _numOfTreated;
        }

        /// <summary>
        /// возвращает суффикс для имени результирующего файла
        /// </summary>
        /// <returns></returns>
        private string postfix()
        {
            return " OUT" + DateTime.Now.ToString("HHmm");
        }

        private string formatDestName(string fName)
        {
            int pos = fName.IndexOf(" OUT");
            return (pos == -1 ? Path.GetFileNameWithoutExtension(fName) : Path.GetFileNameWithoutExtension(fName).Remove(pos)) + postfix() +
                Path.GetExtension(fName);
        }

        public string getDestination(string sourceFile)
        {
            if (txtDestFile.Text.Length == 0) //результат не указан. Пишем в ту же папку, где источник
            {
                if (File.Exists(sourceFile))
                {
                    return Path.GetDirectoryName(sourceFile) + @"\" + formatDestName(Path.GetFileName(sourceFile));
                }
                else return "";
            }
           
            else // Указан результат
            {
                if (!Path.HasExtension(txtDestFile.Text)) // указан путь. Пишем по указанному пути, но используем модифицированное имя источника
                {
                    if (txtDestFile.Text.Substring(txtDestFile.Text.Length-1) != @"\")
                        txtDestFile.Text += @"\";

                    return Path.GetDirectoryName(txtDestFile.Text) + @"\" + formatDestName(Path.GetFileName(sourceFile));
                }
                else // Указан файл
                {
                    if (Path.GetDirectoryName(txtDestFile.Text).Length > 0) // указан файл с путём. Пишем по указанному пути, используя имя файла
                    {
                        return Path.GetDirectoryName(txtDestFile.Text) + @"\" +
                            Path.GetFileNameWithoutExtension(sourceFile) +
                            " " + Path.GetFileNameWithoutExtension(txtDestFile.Text) +
                            (Path.HasExtension(txtDestFile.Text) ? Path.GetExtension(txtDestFile.Text) : Path.GetExtension(sourceFile));
                    }
                    else // указано имя файла
                    {
                        return Path.GetDirectoryName(sourceFile) + @"\" +
                            Path.GetFileNameWithoutExtension(sourceFile) +
                            " " + Path.GetFileNameWithoutExtension(txtDestFile.Text) + Path.GetExtension(sourceFile);
                    }
                }
            }
        }

        private TimeSpan getDeltaTime()
        {
            TimeSpan dTime;
            dTime = new TimeSpan((int)udnHours.Value, (int)udnMinutes.Value, (int)udnSeconds.Value);
            return dTime;
        }

        private int getSign()
        {
            int sign;
            if (chkSign.Checked) sign = 1;
            else sign = -1;
            return sign;
        }

        /// <summary>
        /// возвращает сформированный из данных формы список лексем
        /// </summary>
        /// <returns></returns>
        private List<LexAnd> getLexList()
        {
            List<LexAnd> result = new List<LexAnd>();
            LexAnd la;
            la = ctlLexem1.getLex();
            if (!la.empty()) result.Add(la);
            
            la = ctlLexem2.getLex();
            if (!la.empty()) result.Add(la);

            la = ctlLexem3.getLex();
            if (!la.empty()) result.Add(la);

            la = ctlLexem4.getLex();
            if (!la.empty()) result.Add(la);
            
            return result;
        }

        private DateTime getStartTime()
        {
            DateTime result;
            if (chkAfter.Checked)
                result = dtpAfterDate.Value.Date+dtpAfterTime.Value.TimeOfDay;
            else result = DateTime.MinValue;
            return result;
        }
        private DateTime getFinishTime()
        {
            DateTime result;
            if (chkBefore.Checked)
                result = dtpBeforeDate.Value.Date + dtpBeforeTime.Value.TimeOfDay;
            else result = DateTime.MaxValue;
            return result;
        }

        

        public void StartTransform(string sourceFile)
        {
            StartTransform(sourceFile, getDestination(sourceFile));
        }

        public void StartTransform(string sourceFile, string destFile)
        {
            txtLog.AppendText("\r\n---Transform " + Path.GetFileName(sourceFile) + "\r\n" +
                sourceFile);
            switch (pgfMethod.SelectedIndex)
            {
                case 0: { txtLog.AppendText("\r\n-Shifting time..."); tft.RedefineTime(sourceFile, destFile, getDeltaTime(), getSign()); break; }
                case 1: { txtLog.AppendText("\r\n-Removing lines by conditions..."); tft.RemoveString(sourceFile, destFile, getLexList()); break; }
                case 2: { txtLog.AppendText("\r\n-Removing line by time..."); tft.RemoveString(sourceFile, destFile, getStartTime(), getFinishTime()); break; }
            }


            txtLog.AppendText("\r\n" + tft.resultMessage);
            txtLog.AppendText("\r\n---Finished\r\n");

            if (tft.Result == true)
            {
                AddToTreated(sourceFile);
                AddToTreated(destFile);
                AfterTransform(destFile);
            }
        }

        public void AfterTransform(string destFile)
        {
            if (chkOpen.Checked)
            {
                string err;
                err = tft.OutOpen(destFile);
                if (err.Length > 0) MessageBox.Show(err);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartTransform(cmbSourceFile.Text, getDestination(cmbSourceFile.Text));
        }

         private void btnFileSourceOpen_Click(object sender, EventArgs e)
        {
            FileDialogSource.ShowDialog();
        }

        private void FileDialogSource_FileOk(object sender, CancelEventArgs e)
        {
            //txtSourceFile.Text = FileDialogSource.FileName;
            cmbSourceFile.Text=FileDialogSource.FileName;
        }

        private void btnDestFolderChoose_Click(object sender, EventArgs e)
        {
            destFolder.ShowDialog();
            txtDestFile.Text = destFolder.SelectedPath;
        }

        private void frmTimeInc_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void frmTimeInc_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (s.Length > 1)
                txtLog.AppendText("\r\nStarted at " + DateTime.Now.ToString() + "\r\n");
            for (int i = 0; i < s.Length; i++)
            {
                StartTransform(s[i], getDestination(s[i]));
            }
            if (s.Length > 1)
                txtLog.AppendText("\r\n" + "Finished at " + DateTime.Now.ToString());
            
        }

        private void chkSign_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkSign.Checked)
            {
                chkSign.ImageKey = "down.png";
                lblTime.Text = "Will decrease the time at start of line";
            }
            else
            {
                chkSign.ImageKey = "up.png";
                lblTime.Text = "Will increase the time at start of line";
            }
        }


        /// <summary>
        /// проверка обработки лексем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
 
         private void btnClearCondition_Click(object sender, EventArgs e)
         {
             ctlLexem1.Clear();
             ctlLexem2.Clear();
             ctlLexem3.Clear();
             ctlLexem4.Clear();
         }

         private void btnClearLog_Click(object sender, EventArgs e)
         {
             txtLog.Text = "";
         }

         private void button1_Click_1(object sender, EventArgs e)
         {
             
               //txtLog.Text=log;
             

             // regex 
             
             //Regex rg = new Regex(@"^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$");
             //Regex rg = new Regex(@"^([0-1]?[0-9]|[2][0-3]):([0-5][0-9])$");
             /*
             foreach (Group gr in mt.Groups) { log += gr.Value+'\r'+'\n'; }
             txtLog.Text=log;
             if (mt.Success)
                 MessageBox.Show(mt.Value);
             else MessageBox.Show("Not found");
             
             */
             
             //parse date 
             /*
             DateTimeFormatInfo dtFormatInfo = new DateTimeFormatInfo();
             //dtFormatInfo.TimeSeparator = ":";
             //dtFormatInfo.DateSeparator = "-";
             DateTime dt = new DateTime();
             bool res;
             //res=DateTime.TryParse(txtTs.Text, out dt);
             //res = DateTime.TryParse(txtTs.Text, dtFormatInfo, DateTimeStyles.None, out dt);
             res = DateTime.TryParseExact(txtTs.Text, txtEx.Text , dtFormatInfo, DateTimeStyles.None, out dt);
             if (res)
                     MessageBox.Show(dt.ToString());
             else
                 MessageBox.Show("Не удалось преобразовать");
               */
             
         }

  

    }
}
