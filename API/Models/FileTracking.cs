using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class FileTracking
    {
        public FileTracking()
        {
            Person = new HashSet<Person>();
        }

        public long FileTrackingId { get; set; }
        public int? FileLogId { get; set; }
        public long? ProcessLogId { get; set; }
        public string PreLoaderStatus { get; set; }
        public string PreLoaderFileNameDirectory { get; set; }
        public DateTime PreLoaderProcessedDatetime { get; set; }
        public string DataProfileStatus { get; set; }
        public DateTime DataProfileProcessedDatetime { get; set; }
        public string DataProfileFileNameDirectory { get; set; }
        public string LoaderStatus { get; set; }
        public string LoaderFileNameDirectory { get; set; }
        public DateTime? LoaderProcessedDatetime { get; set; }
        public int InvalidRecordCount { get; set; }
        public int ValidRecordCount { get; set; }
        public string AnalystNotes { get; set; }
        public string AnalystNotesUserName { get; set; }
        public DateTime? AnalystNotesTimestamp { get; set; }
        public bool IsCompleted { get; set; }
        public string AssignedTo { get; set; }

        public virtual FileLog FileLog { get; set; }
        public virtual ICollection<Person> Person { get; set; }
    }
}
