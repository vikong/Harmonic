using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harmonic
{
	public partial class AppendButton : Button
	{
		public AppendButton()
		{
			InitializeComponent();
		}

		public AppendButton(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}
	}
}
