using System;
using System.ComponentModel.DataAnnotations;

namespace LiveTracker.Backend.Data
{
    public class Trip
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}