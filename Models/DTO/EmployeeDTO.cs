using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace miniZeiterfassung.Models.DTO
{
    public class EmployeeDTO
    {
        [Required]
        public int EmployeeNumber { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public int TimeModelId { get; set; }
        public decimal StartingBalance { get; set; }
    }
}
