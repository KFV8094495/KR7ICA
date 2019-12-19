using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Models
{
    public class CustomerEventViewModel
    {
        public int EventId { get; set; }

        [Required]
        public string Title { get; set; }

        public System.DateTime Date { get; set; }

        public System.TimeSpan? Duration { get; set; }

        [Required, MaxLength(3), MinLength(3)]
        public string TypeId { get; set; }





    }
}