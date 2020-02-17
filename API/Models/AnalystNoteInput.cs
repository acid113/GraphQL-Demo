using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class AnalystNoteInput
    {
        public long FileTrackingID { get; set; }
        public string Note { get; set; }
        public string Analyst { get; set; }
    }
}
