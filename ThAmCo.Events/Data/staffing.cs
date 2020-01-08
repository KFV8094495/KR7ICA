using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Data
{
    public class staffing
    {
        public int StaffingId { get; set; }

        public Staffs staff { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }

        public bool Attended { get; set; }
    }
}
