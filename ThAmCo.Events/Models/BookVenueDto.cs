using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{
    public class BookVenuedto
    {
        [Required ,(DataType.data)]
        public DateTime EventDate { get; set; }

        [Required,MinLengh(6),MaxLenght(6)]
        public string VenueCode{ get; set; }

    }
}
