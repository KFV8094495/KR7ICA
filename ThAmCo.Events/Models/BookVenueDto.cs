using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{
    public class BookVenuedto
    {
        [Required,DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        [Required,MinLength(6), MaxLength(6)]
        public string VenueCode{ get; set; }

        public int  Id { get; set; }

    }
}
