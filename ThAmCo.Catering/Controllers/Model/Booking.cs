using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThAmCo.Catering.Models.ViewModels;

namespace ThAmCo.Catering.Controllers.Model
{
    public class Booking
    {

        public int MenuId { get; set; }

        public Menu FoodMenu { get; set; }

        public int EventId { get; set; }
    }

}
