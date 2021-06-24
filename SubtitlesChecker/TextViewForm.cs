using System;
using System.Drawing;
using System.Windows.Forms;

namespace Harmonic.Subtitles
{
	public partial class TextViewForm : Form
	{
		public TextViewForm()
		{
			InitializeComponent();
		}

		public TextViewForm(Point location, String text = "") : this()
		{
			textBox1.Text = text;
			this.Location = PlaceOnScreen(location, this.Size);
		}

		public TextViewForm(String text = "") : this()
		{
			textBox1.Text = text;
		}

		private void TextViewForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				e.Handled = true;
				this.Close();
			}
		}

		/// <summary>
		/// Возвращает расположение (top,left) прямоугольника, так чтобы он не выходил за границы экрана.
		/// </summary>
		/// <param name="location">Предполагаемое размещение (top, left)</param>
		/// <param name="size">Размеры</param>
		/// <returns></returns>
		public Point PlaceOnScreen(Point location, Size size)
		{
			foreach (Screen scrn in Screen.AllScreens)
			{
				if (scrn.WorkingArea.Contains(location))
				{
					return new Point(
						Math.Max(Math.Min(location.X, scrn.WorkingArea.Left + scrn.WorkingArea.Width - size.Width), scrn.WorkingArea.Left),
						Math.Max(Math.Min(location.Y, scrn.WorkingArea.Top + scrn.WorkingArea.Height - size.Height), scrn.WorkingArea.Top)
						);
				}
			}
			return location;
		}
	}
}