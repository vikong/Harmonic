using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderChecker
{
	partial class MainForm
	{
		private DataGridViewTextBoxColumn FolderNameColumn;
		private DataGridViewTextBoxColumn FolderPathColumn;
		private DataGridViewImageColumn StateColumn;
		private DataGridViewTextBoxColumn _stateColumn;
		private DataGridViewTextBoxColumn _messageColumn;
		private DataGridViewCheckBoxColumn _offColumn;

		private void InitFolderGrid()
		{
			FolderBindingSource.DataSource=FolderList;
			FolderGridView.AutoGenerateColumns=false;
			FolderGridView.DataSource=FolderBindingSource;

			FolderNameColumn=new DataGridViewTextBoxColumn();
			FolderNameColumn.DataPropertyName="Name";
			FolderNameColumn.DisplayIndex=0;
			FolderNameColumn.HeaderText = "Имя";
			FolderNameColumn.FillWeight = 15;
			FolderNameColumn.AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;

			FolderPathColumn=new DataGridViewTextBoxColumn();
			FolderPathColumn.DataPropertyName="Path";
			FolderPathColumn.DisplayIndex=1;
			FolderPathColumn.HeaderText = "Расположение";
			FolderPathColumn.FillWeight = 80;
			FolderPathColumn.AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;

			StateColumn=new DataGridViewImageColumn();
			StateColumn.Name="State";
			StateColumn.DisplayIndex=2;
			StateColumn.HeaderText = "";
			StateColumn.FillWeight = 5;
			StateColumn.Image=FolderChecker.Properties.Resources.empty_16;
			StateColumn.AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;

			_stateColumn=new DataGridViewTextBoxColumn();
			_stateColumn.DataPropertyName = "Status";
			_stateColumn.HeaderText = "Состояние";
			_stateColumn.Name = "Status";
			_stateColumn.ReadOnly = true;
			_stateColumn.Visible = false;


			_messageColumn=new DataGridViewTextBoxColumn();
			_messageColumn.DataPropertyName = "Message";
			_messageColumn.HeaderText = "Сообщение";
			_messageColumn.Name = "Message";
			_messageColumn.ReadOnly = true;
			_messageColumn.Visible = false;


			_offColumn=new DataGridViewCheckBoxColumn();
			_offColumn.DataPropertyName = "Off";
			_offColumn.HeaderText = "Off";
			_offColumn.Name = "Off";
			_offColumn.ReadOnly = true;
			_offColumn.Visible = false;


			FolderGridView.Columns.AddRange(new DataGridViewColumn[] { FolderNameColumn, FolderPathColumn, StateColumn, _stateColumn, _messageColumn, _offColumn});

		}

	}
}
