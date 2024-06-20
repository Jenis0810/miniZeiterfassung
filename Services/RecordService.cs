using miniZeiterfassung.Data;
using miniZeiterfassung.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace miniZeiterfassung.Services
{
	public class RecordService
	{
		private readonly TimeRecordingContext _context;

		public RecordService(TimeRecordingContext context)
		{
			_context = context;
		}

		public async Task CalculateAndSaveHours(int recordId)
		{
			var record = await _context.Records.Include(r => r.Employee).ThenInclude(e => e.TimeModel).FirstOrDefaultAsync(r => r.RecordId == recordId);
			if (record != null)
			{
				// Example calculation: total work time minus breaks
				var totalWorkTime = (record.ToTime - record.FromTime).TotalHours;
				var breakTime = (record.Employee.TimeModel.ToBreak.HasValue && record.Employee.TimeModel.FromBreak.HasValue)
								? (record.Employee.TimeModel.ToBreak.Value - record.Employee.TimeModel.FromBreak.Value).TotalHours
								: 0;

				var netWorkTime = totalWorkTime - breakTime;
				// Additional business logic can be implemented here

				// Saving the changes
				_context.Update(record);
				await _context.SaveChangesAsync();
			}
		}
	}
}
