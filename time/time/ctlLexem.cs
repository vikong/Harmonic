using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace time
{
    public partial class ctlLexem : UserControl
    {
        public ctlLexem()
        {
            InitializeComponent();
        }

        public LexAnd getLex()
        {
            LexAnd result;
            Lex l1, l2;
            l1 = new Lex(txtLex1.Text, chkLex1.Checked);
            l2 = new Lex(txtLex2.Text, chkLex2.Checked);
                
            result = new LexAnd(l1,l2);

            return result;
        }

        private void chkLex1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLex1.Checked)
            {
                txtLex1.ForeColor = System.Drawing.Color.Red;
                chkLex1.Text = "not contains";
            }
            else
            {
                txtLex1.ForeColor = System.Drawing.Color.Green;
                chkLex1.Text = "contains";
            }

        }

        private void chkLex2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLex2.Checked)
            {
                txtLex2.ForeColor = System.Drawing.Color.Red;
                chkLex2.Text = "not contains";
            }
            else
            {
                txtLex2.ForeColor = System.Drawing.Color.Green;
                chkLex2.Text = "contains";
            }
        }

        public void Clear()
        {
            txtLex1.Text = "";
            chkLex1.Checked = false;
            txtLex2.Text = "";
            chkLex2.Checked = false;
        }

    }
}
