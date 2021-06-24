using System;

namespace Harmonic.Subtitles
{
    public enum ProgressState
    {
        None,
        ScanDest,
        ScanTarget,
        Check,
        Copy
    }
    
    public class ProgressReport
    {
        public String Message { get; set; }

        public ProgressState State { get; set; }

        /// <summary>
        /// Количество файлов в папке источнике
        /// </summary>
        public Int32 FilesDest { get; set; }

        /// <summary>
        /// Количество файлов в папке назначений 
        /// </summary>
        public Int32 FilesTarget { get; set; }

        /// <summary>
        /// Количество отсутствующих файлов
        /// </summary>
        public Int32 FilesAbsent { get; set; }

        /// <summary>
        /// Количество скопированных файлов
        /// </summary>
        public Int32 FilesCopied { get; set; }

		public override string ToString()
        {
            return $"{Message} {FilesDest}/{FilesTarget}/{FilesAbsent-FilesCopied}";
        }
    }
}