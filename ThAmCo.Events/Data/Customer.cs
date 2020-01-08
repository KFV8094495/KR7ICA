using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Data
{
    public class Customer
    {
        internal object Nationality;
        internal object AttendDate;

        public int Id { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public DateTime Birthday { get; set; }

        [Display(Name = "Nationality")]
        [Required]
        public int NationalityId { get; set; }


        public List<GuestBooking> Bookings { get; set; }
    }
}