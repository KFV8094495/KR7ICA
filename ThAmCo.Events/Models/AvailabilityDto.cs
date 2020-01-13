using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{
    public class availabilityDto

    {
        [Required, DataType(DataType.Date)]
        public string code { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string capacity { get; set; }

        [Required, MinLength(5), MaxLength(5)]
        public DateTime date { get; set; }

        [Required]
        public int costPerHou { get; set; }

        public decimal VenueCost { get; set; }


    }
}
 
