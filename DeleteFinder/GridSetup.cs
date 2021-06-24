using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harmonic
{
	public partial class FinderForm
	{
		private DataGridViewTextBoxColumn TimeColumn;
		private DataGridViewTextBoxColumn infoTextBoxColumn;

		private DataGridViewTextBoxColumn ExpressionTextBoxColumn;

		private DataGridViewTextBoxColumn LexemColumn;
		private DataGridViewCheckBoxColumn NegateColumn;

		//
		// Flog
		//
		private DataGridViewTextBoxColumn FlogColumn;
		private DataGridViewCheckBoxColumn TreatedColumn;
		private DataGridViewTextBoxColumn MessageColumn;
	
		private void InitializeGrid()
		{
			//
			// Flog
			//
			FlogBindingSource.DataSource=FlogQueue;
			FlogDataGridView.AutoGenerateColumns=false;
			FlogDataGridView.DataSource=FlogBindingSource;
			FlogColumn=new DataGridViewTextBoxColumn();
			TreatedColumn=new DataGridViewCheckBoxColumn();
			MessageColumn=new DataGridViewTextBoxColumn();
			FlogDataGridView.Columns.AddRange(new DataGridViewColumn[] {
					this.FlogColumn,
					this.TreatedColumn,
					this.MessageColumn
			});
			FlogColumn.DataPropertyName="FileName";
			FlogColumn.DisplayIndex=0;
			FlogColumn.HeaderText = "File";
			FlogColumn.FillWeight = 40;
			FlogColumn.AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;
			FlogColumn.ReadOnly = true;


			TreatedColumn.DataPropertyName="Treated";
			TreatedColumn.DisplayIndex=1;
			TreatedColumn.HeaderText = "Finished";
			TreatedColumn.AutoSizeMode=DataGridViewAutoSizeColumnMode.None;
			TreatedColumn.Width=50;
			TreatedColumn.ReadOnly = true;

			MessageColumn.DataPropertyName="Message";
			MessageColumn.DisplayIndex=2;
			MessageColumn.HeaderText = "Message";
			MessageColumn.AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;
			MessageColumn.FillWeight = 60;
			MessageColumn.ReadOnly = true;

			//
			// Matches
			//
			MatchesDataGridView.AutoGenerateColumns=false;

			this.infoTextBoxColumn = new DataGridViewTextBoxColumn();
	
			MatchesDataGridView.Columns.AddRange(new DataGridViewColumn[] {
					this.infoTextBoxColumn
			});
			// 
			// strNo
			// 
			//this.TimeColumn.DataPropertyName = "Time";
			//this.TimeColumn.Frozen = false;
			//this.TimeColumn.DisplayIndex=0;
			//this.TimeColumn.HeaderText = "Time";
			//this.TimeColumn.Name = "Time";
			//this.TimeColumn.FillWeight = 30;
			//this.TimeColumn.AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;
			//this.TimeColumn.ReadOnly = true;
			//this.TimeColumn.Visible = true;
			
			// 
			// info
			// 
			this.infoTextBoxColumn.DataPropertyName = "Info";
			this.infoTextBoxColumn.Frozen = false;
			this.infoTextBoxColumn.HeaderText = "Info";
			this.infoTextBoxColumn.Name = "Info";
			this.infoTextBoxColumn.FillWeight = 100;
			this.infoTextBoxColumn.AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;
			this.infoTextBoxColumn.ReadOnly = true;
			this.infoTextBoxColumn.Visible = true;

		}
		private void InitializeLexGrid()
		{
			// **********************************************************
			// LexListDataGridView
			// **********************************************************
			this.ConditionDataGridView.AutoGenerateColumns=false;

			this.ExpressionTextBoxColumn = new DataGridViewTextBoxColumn();

			//ConditionDataGridView.RowsDefaultCellStyle.SelectionBackColor = Color.LightGray;
			ConditionDataGridView.Columns.Add(ExpressionTextBoxColumn);
			// 
			// lex
			// 
			this.ExpressionTextBoxColumn.DataPropertyName = "Expression";
			this.ExpressionTextBoxColumn.Frozen = false;
			this.ExpressionTextBoxColumn.DisplayIndex=0;
			this.ExpressionTextBoxColumn.HeaderText = "Lex";
			this.ExpressionTextBoxColumn.Name = "Lex";
			this.ExpressionTextBoxColumn.FillWeight = 100;
			this.ExpressionTextBoxColumn.AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;
			this.ExpressionTextBoxColumn.ReadOnly = true;
			this.ExpressionTextBoxColumn.Visible = true;

			// **********************************************************
			// LexEditDataGridView
			// **********************************************************
			this.LexemDataGridView.AutoGenerateColumns=false;

			this.LexemColumn = new DataGridViewTextBoxColumn();
			this.NegateColumn=new DataGridViewCheckBoxColumn();

			LexemDataGridView.Columns.AddRange(new DataGridViewColumn[] {
					this.LexemColumn,
					this.NegateColumn
			});
			//// 
			//// NegateColumn
			//// 
			this.NegateColumn.DataPropertyName = "Negation";
			this.NegateColumn.DisplayIndex=0;
			this.NegateColumn.HeaderText = "Not";
			this.NegateColumn.AutoSizeMode=DataGridViewAutoSizeColumnMode.None;
			this.NegateColumn.Width=35;
			//// 
			//// LexemColumn
			//// 
			this.LexemColumn.DataPropertyName = "Lexem";
			this.LexemColumn.DisplayIndex=1;
			this.LexemColumn.HeaderText = "Substring";
			this.LexemColumn.FillWeight = 100;
			this.LexemColumn.AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;


		}
	}

}
