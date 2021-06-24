using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;
namespace Harmonic
{
	public partial class FinderForm
	{
		/// <summary>
		/// Обрабатывать все логи в списке?
		/// </summary>
		private Boolean TreatAll { get; set; }
		
		/// <summary>
		/// Запос списка найденных соответствий и вывод в грид
		/// </summary>
		private void ResetMatches()
		{
			int curIndex=MatchesBindingSource.Position;
			MatchesBindingSource.SuspendBinding();
			MatchesBindingSource.DataSource=null;
			var matches=LogProcessor.MatchLines.OrderBy(m => m.Time).ToList();
			MatchesBindingSource.DataSource=matches;
			MatchesBindingSource.ResumeBinding();
			MatchesBindingSource.ResetBindings(false);
			MatchesBindingSource.Position=Math.Min(curIndex, matches.Count);
		}
		
		/// <summary>
		/// Запускает обработку лога(логов) 
		/// </summary>
		/// <param name="fl">лог на обработку</param>
		/// <param name="treatAll">обрабатывать все необработанные</param>
		private void StartTreat(Flog fl, Boolean treatAll=true)
		{
			// Если заняты или есть требование на остановку, выходим
			if (Cancellation||LogProcessor.Busy)
				return;
			Busy=true;
			TreatAll=treatAll;
			TreatProgressBar.Value=0;
			TreatProgressBar.Visible=true;
			fl.Treated=false;
			fl.Message=String.Format("Processing has been started at {0}", DateTime.Now.ToShortTimeString());
			// новый поток
			Thread logTreatProcess = new Thread(this.TreatLog);
			logTreatProcess.Name = "LogTreatProcess";
			logTreatProcess.Start(fl.FileInf);
			CurrentThread=logTreatProcess;
		}
		/// <summary>
		/// Используется в StartTreat для создания потока
		/// </summary>
		/// <param name="fi">FileInfo файла, запускаемого на обработку</param>
		private void TreatLog(Object fi)
		{
			LogProcessor.ParseFile((FileInfo)fi);
		}
		
		/// <summary>
		/// Обрабатывает событие процессора "обработка завершена"
		/// </summary>
		/// <param name="result">аргументы события</param>
		private void TreatCompleted(LogProcessor.ResultEventArgs result)
		{
			CurrentThread=null;
			TreatProgressBar.Value=TreatProgressBar.Maximum;
			// обновим список соответствий
			ResetMatches();
			// запишем результаты
			Flog fl=FlogFind(result.File);
			if (fl!=null)
			{
				fl.Result=result.Result; fl.Message=result.Message; fl.Treated=true;
				FlogBindingSource.ResetBindings(false);
			}
			// Если есть запрос на прерывание или обрабатывался один лог, выходим
			if (Cancellation||!TreatAll)
			{
				TreatProgressBar.Visible=false;
				TreatProgressBar.Value=0;
				Busy=false;
				Cancellation=false;
				return;
			}
			// Запускаем на обработку следующий необработанный
			Flog next=GetNextUntreated();
			if (next!=null)
			{
				StartTreat(next);
			}
			else // обработали все. Отдыхаем.
			{
				TreatProgressBar.Visible=false;
				Busy=false;
			}
		}

		/// <summary>
		/// запуск списка на обработку
		/// </summary>
		private void StartTreatList()
		{
			if (Cancellation)
				return;
			Flog fl=GetNextUntreated();
			if (fl!=null)
			{
				StartTreat(fl);
			}
		}

		/// <summary>
		/// Следующий не обработанный лог
		/// </summary>
		/// <returns>лог</returns>
		private Flog GetNextUntreated()
		{
			return FlogQueue.Where(f => f.Treated==false).FirstOrDefault();
		}

		/// <summary>
		/// Обработчик события изменения прогресса
		/// </summary>
		/// <param name="sender">отправитель события</param>
		/// <param name="e">аргументы</param>
		private void ProgressUpdated(object sender, LogProcessor.ProgressEventArgs e)
		{
			if (this.InvokeRequired)
				BeginInvoke(new Action<LogProcessor.ProgressEventArgs>(this.SetProgress), e);
			else
				SetProgress(e);
		}

		/// <summary>
		/// Отображает прогресс на прогресс-баре
		/// </summary>
		/// <param name="e"></param>
		private void SetProgress(LogProcessor.ProgressEventArgs e)
		{
			TreatProgressBar.Value=(Int32)(((float)e.Position/e.Length)*100);
		}

		/// <summary>
		/// возвращает лог по информации о файле
		/// </summary>
		/// <param name="fi">данные файла</param>
		/// <returns>лог</returns>
		private Flog FlogFind(FileInfo fi)
		{
			return FlogQueue.Where(f => f.FileInf.FullName==fi.FullName).SingleOrDefault();
		}
		
		/// <summary>
		/// Добавляет файл в список логов. Если файл существует, то выдается сообщение
		/// </summary>
		/// <param name="file"></param>
		private void FlogAppend(String file=null)
		{
			Flog fl=FlogFind(new FileInfo(file));
			if (fl==null)
			{
				fl=new Flog(file);
				FlogQueue.Add(fl);
			}
			else
			{
				MessageBox.Show("Log "+fl.FileInf.Name+" already in list.");
			}

			FlogBindingSource.ResetBindings(false);
		}

		/// <summary>
		/// Добавляет лексему в список лексем текущего условия
		/// </summary>
		private void LexemAppend()
		{
			if (LexCanEdit==false)
			{
				MessageBox.Show("Sorry, the condition is too complex to edit.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			Lex l=new Lex("sought_substring");
			LexEdit.Add(l);
			CurrentCondition.LexList.Add(l);
			LexemBindingSource.ResetBindings(false);
			ConditionBindingSource.ResetBindings(false);
			LexemBindingSource.Position=CurrentCondition.LexList.Count;
			LexemDataGridView.Focus();
		}
		
		/// <summary>
		/// Удаляет лексему из списка
		/// </summary>
		private void LexemDelete()
		{
			if (LexCanEdit==false)
			{
				MessageBox.Show("Sorry, the condition is too complex to edit.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			int result=Common.DeleteFromList(LexemBindingSource, LexEdit);
			if (result>=0)
			{
				CurrentCondition.LexList.RemoveAt(result);
				LexemBindingSource.ResetBindings(false);
				ConditionBindingSource.ResetBindings(false);
			}
		}

		/// <summary>
		/// Добавляет простое условие с AND-конкатенацией в список условий
		/// </summary>
		private void ConditionAppendLex()
		{
			LexAnd l=new LexAnd(new Lex("sought_substring"));
			Conditions.LexList.Add(l);
			ConditionBindingSource.ResetBindings(false);
			ConditionBindingSource.Position=Conditions.LexList.Count;
			LexemDataGridView.Focus();
		}

		/// <summary>
		/// Добавляет сложное условие в список и открывает окно редактирования для этого условия
		/// </summary>
		private void ConditionAppend()
		{
			ComplexLex l=new ComplexLex(LexType.And);
			ConditionEditForm frm=new ConditionEditForm(l);
			if (frm.ShowDialog()==DialogResult.Cancel)
				return;
			Conditions.LexList.Add(l);
			ConditionBindingSource.ResetBindings(false);
			ConditionBindingSource.Position=Conditions.LexList.Count;
		}

		/// <summary>
		/// Удаляет текущее условие
		/// </summary>
		private void ConditionDelete()
		{
			Common.DeleteFromList(ConditionBindingSource, Conditions.LexList);
		}

		/// <summary>
		/// Отображает текущее условие на форме. Если простое, то разрешает редактирование.
		/// </summary>
		private void ConditionShowEdit()
		{
			LexEdit.Clear();
			ComplexLex lex=ConditionBindingSource.Current as ComplexLex;
			// если составное условие
			if (CurrentCondition!=null)
			{
				// так как имеем список интерфейсов, то необходимо конвертировать его в список лексем Lex, 
				// чтобы дать возможность редактирования в гриде. Если хотя бы один интерфейс не конвертируется, редактировать не можем.
				foreach (ILex l in CurrentCondition.LexList)
				{
					// если все условия в списке - простые лексемы,
					// то редактировать можем. Если хоть одно условие сложное, то редактировать запрещаем
					if (l.GetType()!=typeof(Lex))
					{
						LexCanEdit=false;
						LexEdit.Clear();
						LexemTextBox.Visible=true;
						LexemDataGridView.Visible=false;
						LexemBindingSource.ResetBindings(false);
						return;
					}
					LexEdit.Add(l as Lex); // добавим в список для редактирования
				}
				LexCanEdit=true;
				LexemBindingSource.ResetBindings(false);
				LexemDataGridView.Visible=true;
				LexemTextBox.Visible=false;
			}
			else // неизвестный тип, можем только показать выражение
			{
				ILex ilex=ConditionBindingSource.Current as ILex;
				LexemTextBox.Text = ilex!=null? ilex.Expression : "";
				LexCanEdit=false; LexemTextBox.Visible=true;
				LexemDataGridView.Visible=false;
				LexemBindingSource.ResetBindings(false);
			}
		}
		
		/// <summary>
		/// Открывает на редактирование текущее условие
		/// </summary>
		private void ConditionEditCurrent()
		{
			if (ConditionBindingSource.Current==null) return;
			ComplexLex lex=ConditionBindingSource.Current as ComplexLex;
			if (lex==null) return;
			ConditionEdit(lex);
			ConditionBindingSource.ResetBindings(false);
		}

		/// <summary>
		/// Открывает на редактирование условие
		/// </summary>
		/// <param name="lex">условие</param>
		/// <returns>результат</returns>
		private DialogResult ConditionEdit(ComplexLex lex)
		{
			ConditionEditForm frm=new ConditionEditForm(lex);
			return frm.ShowDialog();
		}

		/// <summary>
		/// Сохраняет условия в файл
		/// </summary>
		private void ConditionSave(FileInfo fi)
		{
			Boolean result=false;
			String message;
			try
			{
				Object obj=Conditions;
				XmlSerializer ser = new XmlSerializer(obj.GetType());
				fi.Delete();
				using (FileStream fs=fi.OpenWrite())
					ser.Serialize(fs, obj);
				message=null; result=true;

			}
			catch (Exception ex)
			{
#if DEBUG
				MessageBox.Show(String.Format("Ошибка {0}:\r\n{1}", ex.Message, ex.InnerException));
#endif
				message=ex.Message;
				result=false;
			}
			if (result==false)
				MessageBox.Show(String.Format("Can't save the condition.\r\n{0}", message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);

		}

		/// <summary>
		/// Загружает условия из файла
		/// </summary>
		private void ConditionLoad()
		{
			OpenFileDialog fd = new OpenFileDialog();
			fd.DefaultExt=ConditionSaveButton.DefaultExt;
			fd.Filter=ConditionSaveButton.Filter;
			fd.RestoreDirectory=true;
			fd.Multiselect=false;
			if (fd.ShowDialog()==DialogResult.Cancel)
				return;
			FileInfo fi=new FileInfo(fd.FileName);
			Boolean result=false;
			String message;
			try
			{
				XmlSerializer ser = new XmlSerializer(typeof(ComplexLex));
				using (FileStream fs=fi.OpenRead())
				{
					ComplexLex res=ser.Deserialize(fs) as ComplexLex;
					if (MessageBox.Show(text: "Do you want to set the condition to that expression?\r\n\r\n"+res.Expression, buttons: MessageBoxButtons.OKCancel, icon: MessageBoxIcon.Question, caption: Application.ProductName)
						==DialogResult.Cancel) return;
					LexEdit.Clear();
					ConditionBindingSource.DataSource=null;
					Conditions=res;
					LogProcessor.Checker=res;
					BindLexGrid();
					ConditionBindingSource.Position=0;
					message=null; result=true;
				}
			}
			catch (Exception ex)
			{
#if DEBUG
				MessageBox.Show(String.Format("Ошибка {0}:\r\n{1}", ex.Message, ex.InnerException));
#endif
				message=ex.Message;
				result=false;
			}
			if (result==false)
				MessageBox.Show(String.Format("Can't open the condition.\r\n{0}", message),Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Warning);

		}

		/// <summary>
		/// Помечает лог как не обработанный
		/// </summary>
		/// <param name="fl"></param>
		private void FlogMark(Flog fl)
		{
			if (!fl.Treated)
				return;

			fl.Treated=false;
			FlogBindingSource.ResetBindings(false);
		}

		/// <summary>
		/// Сохраняет результаты
		/// </summary>
		/// <param name="fileInfo">файл для сохранения</param>
		private void ResultSave(FileInfo fileInfo=null)
		{
			Boolean saveAll=false;
			if (MatchesDataGridView.SelectedRows.Count<=1)
			{
				DialogResult dr=MessageBox.Show("There are no selected lines.\n\t-Yes for save all.\n\t-No for save current line.", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
				if (dr==DialogResult.Cancel)
					return;
				saveAll=(dr==DialogResult.Yes);
			}

			List<MdMatch> mList=new List<MdMatch>(MatchesDataGridView.SelectedRows.Count>0? MatchesDataGridView.SelectedRows.Count : LogProcessor.MatchLines.Count);
			
			if (saveAll)
			{
				mList.AddRange(LogProcessor.MatchLines);
			}
			else
			{
				MdMatch match;
				foreach (DataGridViewRow vr in MatchesDataGridView.SelectedRows)
				{
					match = (MdMatch)vr.DataBoundItem;
					mList.Add(match);
				}
			}

			using (StreamWriter file = new StreamWriter(fileInfo.OpenWrite(), Encoding.UTF8)) 
			{
				foreach (MdMatch m in mList.OrderBy(m => m.Time).ToList())
				{
					file.WriteLine(m.ToString());
				}
			}
			if (MessageBox.Show("Do you want to open saved file?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK)
			{
				Process.Start(fileInfo.FullName);
			}

		}

	}
}
