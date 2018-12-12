using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace TechnicalScreening
{
    public class ProcessedFileInfo
    {
        public BlockingCollection<string> LinesFound { get; set; }

        public int SearchStringOccurrences { get; set; }
    }
}
