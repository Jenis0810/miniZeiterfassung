using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace miniZeiterfassung.Models.DTO
{
    public class RecordDTO
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan FromTime { get; set; }

        [Required]
        public TimeSpan ToTime { get; set; }

        public int EmployeeId { get; set; }
    }
}
