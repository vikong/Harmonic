namespace Harmonic
{
	partial class SaveButton
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// SaveButton
			// 
			this.Image = global::Harmonic.HarmonicResource.save_16;
			this.Size = new System.Drawing.Size(30, 26);
			this.Click += new System.EventHandler(this.SaveButton_Click);
			this.ResumeLayout(false);

		}

		#endregion
	}
}
