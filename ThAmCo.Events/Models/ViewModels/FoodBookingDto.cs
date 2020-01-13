using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models.ViewModels
{
    public class FoodBookingDto
    {

        [Key] 
        public int MenuId { get; set; }

        [Key]
        public int EventId { get; set; }

    }
}
