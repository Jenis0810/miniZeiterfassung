using System.ComponentModel.DataAnnotations;

namespace miniZeiterfassung.Models.DTO
{
    public class TimeModelDTO
    {
        public int TimeModelNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public TimeSpan FromTime { get; set; }

        [Required]
        public TimeSpan ToTime { get; set; }

        [Required]
        public double TargetHours { get; set; }

        public TimeSpan? FromBreak { get; set; }
        public TimeSpan? ToBreak { get; set; }
    }
}
