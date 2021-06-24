using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Drawing;

namespace Harmonic
{

	public partial class FinderForm : Form
	{
		private Object _lockObj;

		private readonly List<Flog> _flogQueue;
		private List<Flog> FlogQueue { get { return _flogQueue; } }
		
		
		private readonly LogProcessor _lp;
		private LogProcessor LogProcessor { get { return _lp; } }

		private Thread CurrentThread { get; set; }
		
		private Boolean _cancellation;
		/// <summary>
		/// требование остановить обработку.
		/// </summary>
		private Boolean Cancellation
		{
			get { return _cancellation; }
			set { _cancellation=value; if (value) LogProcessor.Cancellation=true; }
		}
		
		private Boolean _busy;
		private Boolean Busy { 
			get { return _busy; } 
			set 
			{
				CancelButton.Visible=
				CancelButton.Enabled=value;

				ConditionEditButton.Enabled=
				ConditionOpenButton.Enabled=
				ConditionAppendButton.Enabled=
				ConditionDeleteButton.Enabled=
				ConditionOpenButton.Enabled=
				LexemAppendButton.Enabled=
				LexemDeleteButton.Enabled=
				ClearResultButton.Enabled=
				TreatAllButton.Enabled=
				!value;

				_busy=value; 
			} 
		}
		
		private ComplexLex _conditions;
		private ComplexLex Conditions { get { return _conditions; } set { _conditions=value; } }
		
		private ComplexLex _currentCondition;
		private ComplexLex CurrentCondition { 
			get { return _currentCondition; }
			set { _currentCondition=value; ConditionShowEdit(); } 
		}
		
		/// <summary>
		/// Список для редактирования простых лексем на этой форме
		/// </summary>
		private List<Lex> LexEdit { get; set; } 
		/// <summary>
		/// Признак простой лексемы
		/// </summary>
		private Boolean LexCanEdit { get; set; }
		private MdMatch CurrentMatch { get; set; }
		public FinderForm()
		{
			_flogQueue=new List<Flog>();
			_conditions=new LexOr();
			//_conditions=new ComplexLex();
			_lp=new LogProcessor(Conditions);
			_lockObj=new Object();

			LexEdit=new List<Lex>();

			LogProcessor.ProgressUp+=this.ProgressUpdated;
			LogProcessor.Comleted+=this.OnCompleted;
			InitializeComponent();
			InitializeGrid();
			BindMatchesGrid();

			Lex cmd=new Lex("sought_substring");

			Conditions.LexList.Add(new LexAnd(cmd));

			InitializeLexGrid();
			BindLexGrid();

		}
		private void BindLexGrid()
		{
			ConditionBindingSource.DataSource=Conditions.LexList;
			ConditionDataGridView.DataSource=ConditionBindingSource;

			LexemBindingSource.DataSource=LexEdit;
			LexemDataGridView.DataSource=LexemBindingSource;
		}
		private void BindMatchesGrid()
		{
			MatchesBindingSource.DataSource=LogProcessor.MatchLines.OrderBy(m => m.Time).ToList();
			MatchesDataGridView.DataSource=MatchesBindingSource;
		}

		private void OnCompleted(object sender, LogProcessor.ResultEventArgs result)
		{
			if (this.InvokeRequired)
				BeginInvoke(new Action<LogProcessor.ResultEventArgs>(TreatCompleted), result);
			else
				TreatCompleted(result);
		}

		private void ArrangeControls()
		{
			AnchorStyles fullAnchored=AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Bottom|AnchorStyles.Right;

			MainTabControl.Anchor=AnchorStyles.None;
			SplitContainer1.Anchor=AnchorStyles.None;
			ConditionDataGridView.Anchor=AnchorStyles.None;
			LexemDataGridView.Anchor=AnchorStyles.None;
			FlogDataGridView.Anchor=AnchorStyles.None;
			
			SplitContainer1.Left=0; SplitContainer1.Width=MainTabControl.Width-7;
			SplitContainer1.Anchor=fullAnchored;

			ConditionDataGridView.Left=0;
			ConditionDataGridView.Width=SplitContainer2.Panel1.Width;
			ConditionDataGridView.Height=SplitContainer2.Panel1.Height-ConditionDataGridView.Top;
			ConditionDataGridView.Anchor=fullAnchored;

			LexemDataGridView.Left=0;
			LexemDataGridView.Width=SplitContainer2.Panel2.Width;
			LexemDataGridView.Height=SplitContainer2.Panel2.Height-LexemDataGridView.Top;
			LexemDataGridView.Anchor=fullAnchored;
			
			//LexemTextBox
			LexemTextBox.Anchor=AnchorStyles.None;
			LexemTextBox.Left=0;
			LexemTextBox.Width=SplitContainer2.Panel2.Width;
			LexemTextBox.Height=SplitContainer2.Panel2.Height-LexemTextBox.Top;
			LexemTextBox.Anchor=fullAnchored;

			//FlogDataGridView
			FlogDataGridView.Width=SplitContainer1.Panel2.Width-FlogDataGridView.Left-FlogTreatCurrentButton.Width-8;
			FlogDataGridView.Height=SplitContainer1.Panel2.Height-FlogDataGridView.Top-2;
			FlogDataGridView.Anchor=fullAnchored;

			MainTabControl.Anchor=fullAnchored;

		}
		private void Flog_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
		}
		private void Flog_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			foreach (String f in files)
			{
				FlogAppend(f);
			}
			if (ImmediatelyCheckBox.Checked && !Busy) StartTreatList();
		}

		private void MatchesBindingSource_CurrentChanged(object sender, EventArgs e)
		{
			BindingSource bs = sender as BindingSource;
			MdMatch match = bs.Current as MdMatch;
			MdMatch sess;
			if (LogProcessor.Sessions.TryGetValue(match.SessionId, out sess))
			{
				SessionTextBox.Text=sess.Info;
			}
			else SessionTextBox.Text="not found";
			MatchTextBox.Text=match.Info;
			MatchFileTextBox.Text=match.Source;
			MatchStringTextBox.Text=match.StrNo.ToString();
		}

		private void clearToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Clear logs?", "Harmonic", MessageBoxButtons.OKCancel)==DialogResult.Cancel)
				return;
			MatchesBindingSource.DataSource=null;
			LogProcessor.Drop();
			ResetMatches();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			Cancellation=true;
		}

		private void ConditionBindingSource_CurrentChanged(object sender, EventArgs e)
		{
			CurrentCondition=ConditionBindingSource.Current as ComplexLex;
		}

		private void ConditionDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			ConditionBindingSource.ResetBindings(false);
		}

		private void ClearResultButton_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Clear all result?", "Harmonic Log Processor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.Cancel)
				return;
			MatchesBindingSource.DataSource=null;
			LogProcessor.Drop();
			ResetMatches();
		}

		private void LexemAppendButton_Click(object sender, EventArgs e)
		{
			LexemAppend();
		}

		private void LexemDeleteButton_Click(object sender, EventArgs e)
		{
			LexemDelete();
		}

		private void ConditionDeleteButton_Click(object sender, EventArgs e)
		{
			ConditionDelete();
		}

		private void ConditionAppendButton_Click(object sender, EventArgs e)
		{
			ConditionAppendLex();
		}

		private void FlogAppendButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog fd=new OpenFileDialog();
			fd.Multiselect=true;
			fd.RestoreDirectory=true;
			fd.Filter = "log files (mdscore*.*)|mdscore*.*|gz files (*.gz)|*.gz|All files|*.*";
			if (fd.ShowDialog()==DialogResult.OK)
				foreach (String file in fd.FileNames)
					FlogAppend(file);
			if (ImmediatelyCheckBox.Checked && !Busy) StartTreatList();
		}

		private void TreatAllButton_Click(object sender, EventArgs e)
		{
			if (!Busy) StartTreatList();
		}

		private void RemoveFlogButton_Click(object sender, EventArgs e)
		{
			Common.DeleteFromList(FlogBindingSource, FlogQueue, true);
		}


		private void FlogMarkButton_Click(object sender, EventArgs e)
		{
			Flog fl=FlogBindingSource.Current as Flog;
			if (fl==null) return;
			FlogMark(fl);
			if (!Busy && ImmediatelyCheckBox.Checked) StartTreatList();
		}

		private void FlogTreatCurrentButton_Click(object sender, EventArgs e)
		{
			Flog fl=FlogBindingSource.Current as Flog;
			if (fl==null) return;
			if ( fl.Treated 
				&& MessageBox.Show(String.Format("{0} has been already processed. Do you want to process it once again?", fl.FileName), "Harmonic Log Processor", MessageBoxButtons.OKCancel)
					==DialogResult.Cancel
				)
				return;
			
			if (Busy)
				FlogMark(fl);
			else
			{
				StartTreat(fl, false);
				FlogBindingSource.ResetBindings(false);
			}
		}
		private void ResultSaveButton_Click(object sender, EventArgs e)
		{
			ResultSave();
		}

		private void FinderForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!this.Busy)
				return;
			if (e.CloseReason==CloseReason.UserClosing 
				&& MessageBox.Show("Abort current processing and finish work?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.Cancel)
			{
				e.Cancel=true;
				return;
			}
			LogProcessor.Comleted-=this.OnCompleted;
			Cancellation=true;
			CurrentThread.Join();
		}

		private void saveButton1_Save(object sender, SaveButton.FileArgs e)
		{
			MessageBox.Show(e.FileInfo.FullName);
		}

		private void ConditionSaveButton_Check(object sender, SaveButton.ConfirmArgs e)
		{
			e.Confirm=(MessageBox.Show("Save?","", MessageBoxButtons.OKCancel)==DialogResult.OK);
		}

		private void ResultSaveButton_Save(object sender, SaveButton.FileArgs e)
		{
			ResultSave(e.FileInfo);
		}

		private void ResultSaveButton_BeforeSave(object sender, SaveButton.ConfirmArgs e)
		{
			if (LogProcessor.MatchLines.Count<=0)
			{
				MessageBox.Show("There are no lines for saving.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				e.Confirm=false;
				return;
			}
		}

		private void LexemDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			ConditionBindingSource.ResetCurrentItem();
		}

		private void ConditionSaveButton_Save(object sender, SaveButton.FileArgs e)
		{
			ConditionSave(e.FileInfo);
		}

		private void ConditionOpenButton_Click(object sender, EventArgs e)
		{
			ConditionLoad();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			new ViewConditionForm(Conditions.Expression, Conditions.Tag).ShowDialog();
		}

		private void ConditionEditButton_Click(object sender, EventArgs e)
		{
			ConditionShowEdit();
		}

		private void FinderForm_Shown(object sender, EventArgs e)
		{
			ArrangeControls();
			ConditionDataGridView.Focus();
		}

		private void ConditionEditButton_Click_1(object sender, EventArgs e)
		{
			ConditionEditForm frm=new ConditionEditForm(this.Conditions);
			frm.ShowDialog();
			ConditionBindingSource.ResetBindings(false);
		}

		private void ConditionDataGridView_DoubleClick(object sender, EventArgs e)
		{
			ConditionEditCurrent();
		}

		private void ConditionDataGridView_KeyUp(object sender, KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if (LexCanEdit)
					LexemDataGridView.Focus();
				else
					ConditionEditCurrent();
			}
		}

		private void Panel_Enter(object sender, EventArgs e)
		{
			((Panel)sender).BackColor=Color.FromKnownColor(KnownColor.GradientActiveCaption);
		}

		private void Panel_Leave(object sender, EventArgs e)
		{
			((Panel)sender).BackColor=Color.FromKnownColor(KnownColor.ControlLightLight);
		}

	}
}
