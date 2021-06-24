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
	public partial class ViewConditionForm : Form
	{
		public ViewConditionForm(String text, String caption)
		{
			InitializeComponent();
			ConditonTextBox.Text=text;
			TagLabel.Text=caption;
		}
	}
}
