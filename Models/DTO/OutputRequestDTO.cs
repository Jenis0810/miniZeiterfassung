using System.ComponentModel.DataAnnotations;

namespace miniZeiterfassung.Models.DTO
{
    public class OutputRequestDTO
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
    }
}
