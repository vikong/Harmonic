using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harmonic
{
	public partial class ConditionEditForm : Form
	{
		public ComplexLex Condition { get; private set; }
		private Boolean _canEdit;
		private Boolean CanEdit {
			get { return _canEdit; }
			set { _canEdit=value; LexemControl.Enabled=_canEdit; } 
		}
		
		private DataGridViewTextBoxColumn ExpressionTextBoxColumn;

		public ConditionEditForm(ComplexLex lex=null)
		{
			InitializeComponent();
			if (lex==null)
				Condition=new ComplexLex(LexType.And);
			else
				Condition=lex;
			TagTextBox.DataBindings.Add("Text", Condition, "Tag");
			NegationCheckBox.DataBindings.Add("Checked", Condition, "Negation");
			GridSetup();
			BindGrid();
			TypeComboBox.SelectedItem=Condition.Type;
			ConditionBindingSource.Position=0;
		}

		private void BindGrid()

		{
			ConditionBindingSource.DataSource=Condition.LexList;
			ConditionDataGridView.DataSource=ConditionBindingSource;
		}
		private void GridSetup()
		{
			this.ConditionDataGridView.AutoGenerateColumns=false;

			this.ExpressionTextBoxColumn = new DataGridViewTextBoxColumn();

			ConditionDataGridView.Columns.Add(ExpressionTextBoxColumn);
			// 
			// lex
			// 
			this.ExpressionTextBoxColumn.DataPropertyName = "Expression";
			this.ExpressionTextBoxColumn.Frozen = false;
			this.ExpressionTextBoxColumn.DisplayIndex=0;
			this.ExpressionTextBoxColumn.HeaderText = "Expression";
			this.ExpressionTextBoxColumn.Name = "Expression";
			this.ExpressionTextBoxColumn.FillWeight = 100;
			this.ExpressionTextBoxColumn.AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;
			this.ExpressionTextBoxColumn.ReadOnly = true;
			this.ExpressionTextBoxColumn.Visible = true;

		}
		private void EditCurrent()
		{
			Type condType=ConditionBindingSource.Current.GetType();
			if (condType==typeof(Lex))
				LexemControl.Focus();

			else
			{
				ComplexLex lex=ConditionBindingSource.Current as ComplexLex;
				if (label2!=null)
				{
					ConditionEditForm form=new ConditionEditForm(lex);
					if (form.ShowDialog()==DialogResult.Cancel)
						return;
				}
				else
					MessageBox.Show("Not editable");
			}
		}

		private void LexemAppend()
		{
			Condition.LexList.Add(new Lex());
			ConditionBindingSource.Position=Condition.LexList.Count;
			ConditionBindingSource.ResetBindings(false);
			LexemControl.Focus();
		}

		private void ConditionAppend()
		{
			ComplexLex l=new ComplexLex(new Lex());
			ConditionEditForm form=new ConditionEditForm(l);
			if (form.ShowDialog()==DialogResult.Cancel)
				return;
			Condition.LexList.Add(l);
			ConditionBindingSource.ResetBindings(false);
			ConditionBindingSource.Position=Condition.LexList.Count;
		}

		private void ConditionBindingSource_CurrentChanged(object sender, EventArgs e)
		{
			if (ConditionBindingSource.Current.GetType()==typeof(Lex))
			{
				LexemControl.Lexem=ConditionBindingSource.Current as Lex;
				CanEdit=true;
			}
			else
			{
				LexemControl.Lexem=null;
				CanEdit=false;
			}
		}

		private void appendButton_Click(object sender, EventArgs e)
		{
			LexemAppend();
		}

		private void LexemControl_Changed(object sender, EventArgs e)
		{
			ConditionBindingSource.ResetCurrentItem();
		}

		private void RemoveConditionButton_Click(object sender, EventArgs e)
		{
			Common.DeleteFromList(ConditionBindingSource, Condition.LexList, true);
		}

		private void AppendConditionButton_Click(object sender, EventArgs e)
		{
			ConditionAppend();
		}

		private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Condition.Type=TypeComboBox.SelectedItem as String;
		}

		private void ConditionDataGridView_DoubleClick(object sender, EventArgs e)
		{
			EditCurrent();
		}

		public void button1_Click(object sender, EventArgs e)
		{
			Condition.RemoveEmpty();
			ConditionBindingSource.ResetBindings(false);
		}

		private void ConditionShowButton_Click(object sender, EventArgs e)
		{
			new ViewConditionForm(Condition.Expression, Condition.Tag).ShowDialog();
		}
	}
}
