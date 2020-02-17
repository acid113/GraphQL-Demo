using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class FileLog
    {
        public FileLog()
        {
            FileTracking = new HashSet<FileTracking>();
        }

        public int FileLogId { get; set; }
        public int? ClientId { get; set; }
        public string OriginalFileName { get; set; }
        public DateTime? DateLastProcessed { get; set; }

        public virtual ICollection<FileTracking> FileTracking { get; set; }
    }
}
