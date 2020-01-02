using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ThAmCo.Events.Models
{
    public class VenueDto
    {
        [key,Minlenght(6),MaxLenght(6)]
        public string code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public int Capacity { get; set; }
        public DateTime Date { get; set; }

        public double HourCost { get; set; }

    }
}
    
