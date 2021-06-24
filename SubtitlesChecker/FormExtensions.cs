using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Harmonic.Subtitles
{
	public static class FormExtensions
	{
        public static IEnumerable<Control> AllControls(this Control control)
        {
            foreach (Control ctrl in control.Controls)
            {
                yield return ctrl;
                foreach (Control child in ctrl.Controls)
                    yield return child;
            }
        }

        public static IEnumerable<ToolStripItem> AllItems(this ToolStrip toolStrip)
        {
            return toolStrip.Items.Flatten();
        }

        public static IEnumerable<ToolStripItem> Flatten(this ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripDropDownItem)
                    foreach (ToolStripItem subitem in
                        ((ToolStripDropDownItem)item).DropDownItems.Flatten())
                        yield return subitem;
                yield return item;
            }
        }

        public static void ChangeLanguage(this Control control, CultureInfo cultureInfo)
        {
            var rm = new ComponentResourceManager(control.GetType());
            Application.CurrentCulture
                = Thread.CurrentThread.CurrentCulture 
                = Thread.CurrentThread.CurrentUICulture 
                = cultureInfo;
            foreach (Control ctrl in control.AllControls())
            {
                if (ctrl is ToolStrip)
                {
                    var items = ((ToolStrip)ctrl).AllItems().ToList();
                    foreach (var item in items)
                        rm.ApplyResources(item, item.Name);
                }
                rm.ApplyResources(ctrl, ctrl.Name);
            }
        }
        public static void ChangeLanguage(this Form form, CultureInfo cultureInfo) 
            => ((Control)form).ChangeLanguage(cultureInfo);
    }
}
