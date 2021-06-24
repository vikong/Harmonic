using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Harmonic;

namespace FolderObserver
{
	public partial class ConditionEditForm : Form
	{
		private static readonly String defaultExpr="Sought String";
		private readonly ComplexLex _conditions;
		public ConditionEditForm(ComplexLex condition)
		{
			InitializeComponent();
			_conditions=condition;
			if (!_conditions.Empty)
				condTextBox.Text=_conditions.ToString().Replace("\'", String.Empty);
			else
				condTextBox.Text=defaultExpr;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			_conditions.LexList.Clear();
			_conditions.LexList.Add(new LexAnd(new Lex(condTextBox.Text.Trim())));
		}

		private void ConditionEditForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_conditions.Empty && (e.CloseReason==CloseReason.UserClosing || e.CloseReason==CloseReason.None))
			{
				MessageBox.Show("Condition can't be empty.", Application.ProductName, MessageBoxButtons.OK);
				e.Cancel=true;
				return;
			}
		}

		private void ConditionEditForm_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawRectangle(new Pen(System.Drawing.SystemColors.ActiveBorder, 3),
							this.DisplayRectangle);     
		}
	}
}
