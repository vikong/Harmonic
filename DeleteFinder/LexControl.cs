using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harmonic
{
	public partial class LexControl : UserControl
	{
		private Lex _lexem;
		public Lex Lexem
		{
			get { return _lexem; }
			set 
			{

				if (value!=null)
				{
					_lexem=value;
					NegationCheckBox.Checked=_lexem.Negation;
					SubstringTextBox.Text=_lexem.Lexem;
					NegationCheckBox.Enabled=SubstringTextBox.Enabled=true;
				}
				else
				{
					_lexem=value;
					NegationCheckBox.Checked=false;
					SubstringTextBox.Text="";
					NegationCheckBox.Enabled=SubstringTextBox.Enabled=false;
				}
			}
		}
		public LexControl()
		{
			InitializeComponent();
		}

		public event EventHandler Changed;

		private void OnChanged()
		{
			if(Changed!=null) Changed(this,new EventArgs());
		}

		private void NegationCheckBox_Click(object sender, EventArgs e)
		{
			if (Lexem==null)
				return;
			Lexem.Negation=NegationCheckBox.Checked;
			OnChanged();
		}

		private void NegationCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			NegationCheckBox.Text=NegationCheckBox.Checked? "not contains":"contains";
		}

		private void SubstringTextBox_TextChanged(object sender, EventArgs e)
		{
			if (Lexem==null)
				return;
			Lexem.Lexem=SubstringTextBox.Text;
			OnChanged();
		}
	}
}
