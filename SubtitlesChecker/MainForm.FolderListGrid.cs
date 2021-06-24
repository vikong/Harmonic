using System;
using System.Drawing;
using System.Windows.Forms;
using Harmonic.Subtitles.Properties;

namespace Harmonic.Subtitles
{
	partial class MainForm
	{
		private DataGridViewTextBoxColumn FolderNameColumn;
		private DataGridViewTextBoxColumn FolderPathColumn;
		private DataGridViewImageColumn SwitchColumn;
		private DataGridViewImageColumn StateColumn;
		private DataGridViewTextBoxColumn _stateColumn;
		private DataGridViewTextBoxColumn _messageColumn;
		private DataGridViewCheckBoxColumn _offColumn;
		private DataGridViewImageColumn ClearingColumn;
		private DataGridViewTextBoxColumn _clearingColumn;
		private DataGridViewTextBoxColumn ProgressColumn;

		private void InitFolderGrid()
		{
			FolderBindingSource.DataSource = FolderList;
			FolderGridView.AutoGenerateColumns = false;
			FolderGridView.DataSource = FolderBindingSource;

			SwitchColumn = new DataGridViewImageColumn
			{
				Name = "Switch",
				DisplayIndex = 0,
				HeaderText = "",
				AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
				Width = 24
			};

			FolderNameColumn = new DataGridViewTextBoxColumn
			{
				DataPropertyName = "Folder.Name",
				Name = "FolderName",
				DisplayIndex = 1,
				HeaderText = Messages.ColHost,
				FillWeight = 15,
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
			};

			FolderPathColumn = new DataGridViewTextBoxColumn
			{
				DataPropertyName = "Folder.Path",
				Name="FolderPath",
				DisplayIndex = 2,
				HeaderText = Messages.ColPath,
				FillWeight = 18,
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
			};


			StateColumn = new DataGridViewImageColumn
			{
				Name = "State",
				DisplayIndex = 3,
				HeaderText = "",
				//FillWeight = 5,
				Image = Resources.empty_16,
				AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
				Width = 24
			};

			ProgressColumn = new DataGridViewTextBoxColumn
			{
				DataPropertyName = "Progress",
				Name = "ProgressColumn",
				DisplayIndex = 4,
				HeaderText = Messages.ColProgress,
				FillWeight = 22,
				AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
			};

			_stateColumn = new DataGridViewTextBoxColumn
			{
				Name = "Status",
				DataPropertyName = "Status",
				ReadOnly = true,
				Visible = false
			};

			ClearingColumn = new DataGridViewImageColumn
			{
				Name = "ClearingColumn",
				DisplayIndex = 5,
				HeaderText = "",
				FillWeight = 5,
				Image = Resources.empty_16,
				AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
				Width = 24
			};

			_clearingColumn = new DataGridViewTextBoxColumn
			{
				DataPropertyName = "NowClearing",
				Name = "Clearing",
				ReadOnly = true,
				Visible = false
			};

			_messageColumn = new DataGridViewTextBoxColumn
			{
				Name = "Message",
				DataPropertyName = "Message",
				ReadOnly = true,
				Visible = false
			};

			_offColumn = new DataGridViewCheckBoxColumn
			{
				Name = "Off",
				DataPropertyName = "Off",
				ReadOnly = true,
				Visible = false
			};

			FolderGridView.Columns.AddRange(new DataGridViewColumn[] {
				SwitchColumn,
				FolderNameColumn,
				FolderPathColumn,
				ProgressColumn,
				StateColumn,
				ClearingColumn,
				_stateColumn,
				_clearingColumn,
				_messageColumn,
				_offColumn
			});
		}

		private void FolderGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
		{
			if ((FolderGridView.Rows[e.RowIndex].DataBoundItem != null))
			{
				FolderGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor =
					!((FolderGridInfo)FolderGridView.Rows[e.RowIndex].DataBoundItem).FolderInfo.Off ?
					SystemColors.WindowText:
					SystemColors.GrayText;
			}
		}

		private void FolderGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			switch (FolderGridView.Columns[e.ColumnIndex].Name)
			{
				case "Switch":
					if (!(bool)FolderGridView.Rows[e.RowIndex].Cells["Off"].Value)
						e.Value = Resources.empty_16;
					else
						e.Value = Resources.pause_16;
					break;

				case "ClearingColumn":
					if (!(bool)FolderGridView.Rows[e.RowIndex].Cells["Clearing"].Value)
						e.Value = Resources.empty_16;
					else
						e.Value = Resources.file_zip_16;

					break;

			}
		}

		private void FolderGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			switch (FolderGridView.Columns[e.ColumnIndex].Name)
			{
				case "FolderName":
					e.Value = ((FolderGridInfo)FolderGridView.Rows[e.RowIndex].DataBoundItem).FolderInfo.Name; 
					break;
					

				case "FolderPath":
					e.Value = ((FolderGridInfo)FolderGridView.Rows[e.RowIndex].DataBoundItem).FolderInfo.SourceFolder;
					break;

				case "State":
					String msg = (String)FolderGridView.Rows[e.RowIndex].Cells["Message"].Value;
					FolderGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = msg;

					switch ((FolderGridInfo.State)FolderGridView.Rows[e.RowIndex].Cells["Status"].Value)
					{
						case FolderGridInfo.State.Ok:
							e.Value = Resources.check_green_16;
							break;

						case FolderGridInfo.State.Checking:
							e.Value = Resources.timer_16;
							break;

						case FolderGridInfo.State.Error:
							e.Value = Resources.error_16;
							break;

						case FolderGridInfo.State.Warning:
							e.Value = Resources.warning_16;
							break;

						default:
							e.Value = Resources.empty_16;
							break;

					}
					break;
			}

		}


		private void FolderGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // исключаем клик на Header
				{
					FolderGridView.CurrentCell = FolderGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
					FolderGridView.Rows[e.RowIndex].Selected = true;
					FolderGridView.Focus();
				}
			}
		}

		private void FolderGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0) // исключаем клик на Header
				return;
			if (FolderGridView.Columns[e.ColumnIndex].Name == StateColumn.Name)
			{
				using (var frm = new TextViewForm(Cursor.Position, (String)FolderGridView.Rows[e.RowIndex].Cells[_messageColumn.Name].Value))
				{
					frm.ShowDialog();
				}
			}
		}

		private void FolderGridView_DoubleClick(object sender, EventArgs e)
		{
			EditCurrent();
		}


	}
}