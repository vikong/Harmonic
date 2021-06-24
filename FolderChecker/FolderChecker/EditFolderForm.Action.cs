using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderChecker
{
	partial class EditFolderForm
	{
		private Boolean AppendMode { get; set; }
		
		/// <summary>
		/// data-объект для передачи данных
		/// </summary>
		public class EditArgs : EventArgs
		{
			public String Name { get; set; }
			public String Path { get; set; }
			
			/// <summary>
			/// сохранение подтверждено
			/// </summary>
			public Boolean Confirm { get; set; }
			/// <summary>
			/// сообщение об ошибке
			/// </summary>
			public String Message { get; set; }

		}
		/// <summary>
		/// редактирование завершено
		/// </summary>
		public event EventHandler<EditArgs> EditConfirm;
		private void onLoginConfirm(EditArgs arg)
		{
			if (EditConfirm!=null)
			{
				EditConfirm(this, arg);
				if (arg.Confirm)
					if (AppendMode)
					{
						NameTextBox.Text=folderSelectControl.folderTextBox.Text=String.Empty;
						folderSelectControl.Focus();
					}
					else
						this.Close();
				else
					MessageBox.Show(arg.Message);
			}
		}



	}
}
