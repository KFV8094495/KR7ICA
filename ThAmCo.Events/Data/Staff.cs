using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Data
{
    public class Staffs
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string  Address { get; set; }
        public string  Contact { get; set; }
        public string Email { get; set; }

        public List<staffing> Bookings { get; set; }
    }

}
