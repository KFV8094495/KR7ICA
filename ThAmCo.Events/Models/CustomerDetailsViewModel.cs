using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{
    public class CustomerDetailsViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }



        IEnumerable<CustomerEventViewModel> CustomerEvents { get; set; }

        public DateTime Birthday { get; set; }

        [Display(Name = "Nationality")]
        [Required]
        public int NationalityId { get; set; }


    }
}


