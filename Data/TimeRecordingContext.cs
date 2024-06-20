namespace miniZeiterfassung.Data;
using Microsoft.EntityFrameworkCore;
using miniZeiterfassung.Models;

public class TimeRecordingContext : DbContext
{
    public TimeRecordingContext(DbContextOptions<TimeRecordingContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<TimeModel> TimeModels { get; set; }
    public DbSet<Record> Records { get; set; }
}
