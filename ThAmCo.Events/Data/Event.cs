﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ThAmCo.Events.Controllers;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.Data
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan? Duration { get; set; }

        [Required, MaxLength(3), MinLength(3)]
        public string TypeId { get; set; }

        public List<GuestBooking> Bookings { get; set; }

        public string  VenueCode { get; set; }

        public string VenueReference { get; set; }

        public List<staffing> Staff { get; set; }

        public string Menu { get; set; }

        public decimal FoodCost { get; set; }

        public decimal VenueCost { get; set; }


    }
}
