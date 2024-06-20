namespace miniZeiterfassung.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class TimeModel
{
	[Key]
	public int TimeModelId { get; set; }
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

	// Navigation property
	public ICollection<Employee> Employees { get; set; }
}
