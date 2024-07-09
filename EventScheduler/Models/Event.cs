using System;
using System.ComponentModel.DataAnnotations;

namespace EventScheduler.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Event Title is required")]
        public string EventTitle { get; set; }

        [Required(ErrorMessage = "Event Start Date is required")]
        public DateTime EventStartDate { get; set; }

        [Required(ErrorMessage = "Event End Date is required")]
        public DateTime EventEndDate { get; set; }

        [Required(ErrorMessage = "Event Description is required")]
        public string EventDescription { get; set; }

        [Required(ErrorMessage = "Event Priority is required")]
        public int EventPriority { get; set; }
    }
}
