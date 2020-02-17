using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Person
    {
        public int PersonId { get; set; }
        public int? PrimaryPersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; }
        public int? ClientId { get; set; }
        public string ClientMemberId { get; set; }
        public long? FileTrackingId { get; set; }
        public DateTime SysStartTime { get; set; }
        public DateTime SysEndTime { get; set; }

        public virtual FileTracking FileTracking { get; set; }
    }
}
