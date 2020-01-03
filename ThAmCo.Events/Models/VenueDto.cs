using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ThAmCo.Events.Models
{
    public class VenueDto
    {
        [Key, MinLength(6), MaxLength(6)]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public int Capacity { get; set; }
        public DateTime Date { get; set; }
        public double HourCost { get; set; }

    }
}
    
