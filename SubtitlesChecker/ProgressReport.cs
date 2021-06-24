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
        public String Message;

        public ProgressState State;

        public Int32 FilesDest;

        public Int32 FilesTarget;

        public Int32 FilesAbsent;

        public override string ToString()
        {
            return $"{Message} {FilesDest}/{FilesTarget}/{FilesAbsent}";
        }
    }
}