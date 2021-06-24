using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Harmonic.Subtitles
{
	public class DataGridViewProgressCell : DataGridViewImageCell
	{
		// Используется для соответствия типу DataGridViewImageCell
		private static Image emptyImage;

		// Используется для хранения цвета заливки прогресс-бара
		private static Color _ProgressBarColor;

		public Color ProgressBarColor
		{
			get { return _ProgressBarColor; }
			set { _ProgressBarColor = value; }
		}

		static DataGridViewProgressCell()
		{
			emptyImage = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
		}

		public DataGridViewProgressCell()
		{
			this.ValueType = typeof(int);
		}

		// Метод требуется для соответствия Progress Cell типу ячейки по умолчанию Image Cell.
		// Ячейка по умолчанию Image Cell обрабатывает изображение как значение, а в нашей ячейке это значением является целое число.
		protected override object GetFormattedValue(object value,
			int rowIndex, ref DataGridViewCellStyle cellStyle,
			TypeConverter valueTypeConverter,
			TypeConverter formattedValueTypeConverter,
			DataGridViewDataErrorContexts context)
		{
			return emptyImage;
		}

        protected override void Paint(System.Drawing.Graphics g,
                   System.Drawing.Rectangle clipBounds,
                   System.Drawing.Rectangle cellBounds,
                   int rowIndex,
                   DataGridViewElementStates cellState,
                   object value, object formattedValue,
                   string errorText,
                   DataGridViewCellStyle cellStyle,
                   DataGridViewAdvancedBorderStyle advancedBorderStyle,
                   DataGridViewPaintParts paintParts)
        {
            if (value == null || Convert.ToInt16(value) == 0 )
            {
                value = 0;
            }

            int progressVal = Convert.ToInt32(value);

            Brush foreColorBrush = new SolidBrush(Color.OrangeRed);
            String msg;
            // Рисование рамки ячейки
            base.Paint(g, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.ContentForeground));

            // Рисование ProgressBar
            float percentage = ((float)progressVal / 100.0f);
            if (percentage == 0.0)
			{
                msg = "Не запускалось";

            } else if (percentage > 0.0)
            {
                var brush = new SolidBrush(_ProgressBarColor);
                g.FillRectangle(brush, cellBounds.X + 2, cellBounds.Y + 2, Convert.ToInt32((Math.Min(percentage,1) * cellBounds.Width - 4)), cellBounds.Height - 4);
                msg = $"{progressVal}%";
            }
			else
			{
                msg = $"{progressVal}%";
            }

            // Надпись

            float posX = cellBounds.X;
            float posY = cellBounds.Y;

            float textWidth = TextRenderer.MeasureText(progressVal.ToString() + "%", cellStyle.Font).Width;
            float textHeight = TextRenderer.MeasureText(progressVal.ToString() + "%", cellStyle.Font).Height;

            // Положение текста в зависимости от выравнивания в ячейке
            switch (cellStyle.Alignment)
            {
                case DataGridViewContentAlignment.BottomCenter:
                    posX = cellBounds.X + (cellBounds.Width / 2) - textWidth / 2;
                    posY = cellBounds.Y + cellBounds.Height - textHeight;
                    break;
                case DataGridViewContentAlignment.BottomLeft:
                    posX = cellBounds.X;
                    posY = cellBounds.Y + cellBounds.Height - textHeight;
                    break;
                case DataGridViewContentAlignment.BottomRight:
                    posX = cellBounds.X + cellBounds.Width - textWidth;
                    posY = cellBounds.Y + cellBounds.Height - textHeight;
                    break;
                case DataGridViewContentAlignment.MiddleCenter:
                    posX = cellBounds.X + (cellBounds.Width / 2) - textWidth / 2;
                    posY = cellBounds.Y + (cellBounds.Height / 2) - textHeight / 2;
                    break;
                case DataGridViewContentAlignment.MiddleLeft:
                    posX = cellBounds.X;
                    posY = cellBounds.Y + (cellBounds.Height / 2) - textHeight / 2;
                    break;
                case DataGridViewContentAlignment.MiddleRight:
                    posX = cellBounds.X + cellBounds.Width - textWidth;
                    posY = cellBounds.Y + (cellBounds.Height / 2) - textHeight / 2;
                    break;
                case DataGridViewContentAlignment.TopCenter:
                    posX = cellBounds.X + (cellBounds.Width / 2) - textWidth / 2;
                    posY = cellBounds.Y;
                    break;
                case DataGridViewContentAlignment.TopLeft:
                    posX = cellBounds.X;
                    posY = cellBounds.Y;
                    break;

                case DataGridViewContentAlignment.TopRight:
                    posX = cellBounds.X + cellBounds.Width - textWidth;
                    posY = cellBounds.Y;
                    break;

			}
			//if (this.DataGridView.CurrentRow.Index != rowIndex)
			//	foreColorBrush = new SolidBrush(cellStyle.ForeColor);
			//else
			//	foreColorBrush = new SolidBrush(cellStyle.SelectionForeColor);


			g.DrawString(msg, cellStyle.Font, foreColorBrush, posX, posY);

		}

		public override object Clone()
		{
			DataGridViewProgressCell dataGridViewCell = base.Clone() as DataGridViewProgressCell;
			if (dataGridViewCell != null)
			{
				dataGridViewCell.ProgressBarColor = this.ProgressBarColor;
			}
			return dataGridViewCell;
		}

		internal void SetProgressBarColor(int rowIndex, Color value)
		{
			this.ProgressBarColor = value;
		}
	}

	public class DataGridViewProgressColumn : DataGridViewImageColumn
	{
		public static Color _ProgressBarColor;

		public DataGridViewProgressColumn()
		{
			CellTemplate = new DataGridViewProgressCell(); ;
		}

		public override DataGridViewCell CellTemplate
		{
			get
			{
				return base.CellTemplate;
			}

			set
			{
				if (value != null &&
					!value.GetType().IsAssignableFrom(typeof(DataGridViewProgressCell)))
				{
					throw new InvalidCastException("Ячейка должна иметь тип DataGridViewProgressCell");
				}
				base.CellTemplate = value;
			}
		}

		[Browsable(true)]
		public Color ProgressBarColor
		{
			get
			{
				if (this.ProgressBarCellTemplate == null)
				{
					throw new InvalidOperationException("Операция не может быть завершена, т.к. для данного столбца не задан CellTemplate.");
				}
				return this.ProgressBarCellTemplate.ProgressBarColor;
			}
			set
			{
				if (this.ProgressBarCellTemplate == null)
				{
					throw new InvalidOperationException("Операция не может быть завершена, т.к. для данного столбца не задан CellTemplate.");
				}
				this.ProgressBarCellTemplate.ProgressBarColor = value;
				if (this.DataGridView != null)
				{
					DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
					int rowCount = dataGridViewRows.Count;
					for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
					{
						DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
						DataGridViewProgressCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as DataGridViewProgressCell;
						if (dataGridViewCell != null)
						{
							dataGridViewCell.SetProgressBarColor(rowIndex, value);
						}
					}
					this.DataGridView.InvalidateColumn(this.Index);
				}
			}
		}

		private DataGridViewProgressCell ProgressBarCellTemplate
		{
			get
			{
				return (DataGridViewProgressCell)this.CellTemplate;
			}
		}
	}
}