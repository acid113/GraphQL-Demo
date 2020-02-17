using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    /// <summary>
    /// Custom model returned by uspGetAnalystNotesHistoryById SP
    /// </summary>
    public class AnalystNote
    {
        [Key]
        public int AnalystNotesHistoryID { get; set; }
        public int FileLogID { get; set; }
        public long FileTrackingID { get; set; }
        public int? ClientID { get; set; }
        public string ClientEligibilityFilename { get; set; }
        public string SystemAssignedFilename { get; set; }
        public DateTime? DateLastProcessed { get; set; }
        public int InvalidRecords { get; set; }
        public int ValidRecords { get; set; }
        public string BeingWorkedBy { get; set; }
        public bool? IsCompleted { get; set; }
        public string AnalystNotes { get; set; }
        public string Analyst { get; set; }
        public DateTime AnalystNotesTimestamp { get; set; }
    }
}
