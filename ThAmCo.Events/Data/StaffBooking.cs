using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Data
{
    public class StaffBookings
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }

        public Boolean Attended { get; set; }
    }
}
