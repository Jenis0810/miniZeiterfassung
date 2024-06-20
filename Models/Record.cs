namespace miniZeiterfassung.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Record
{
	[Key]
	public int RecordId { get; set; }

	[Required]
	[Column(TypeName = "date")]
	public DateTime Date { get; set; }

	[Required]
	public TimeSpan FromTime { get; set; }

	[Required]
	public TimeSpan ToTime { get; set; }

	[ForeignKey("Employee")]
	public int EmployeeId { get; set; }
	public Employee Employee { get; set; }
}
