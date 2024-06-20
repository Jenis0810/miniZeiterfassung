namespace miniZeiterfassung.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee
{
	[Key]
	public int EmployeeId { get; set; }
	public int EmployeeNumber { get; set; }

	[Required]
	[StringLength(200)]
	public string Name { get; set; }

	[StringLength(500)]
	public string Address { get; set; }

	[ForeignKey("TimeModel")]
	public int TimeModelId { get; set; }
	public TimeModel TimeModel { get; set; }

	[Column(TypeName = "decimal(10, 2)")]
	public decimal StartingBalance { get; set; }

	// Navigation property
	public ICollection<Record> Records { get; set; }
}
