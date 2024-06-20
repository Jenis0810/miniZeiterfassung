using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using miniZeiterfassung.Data;
using miniZeiterfassung.Models;
using miniZeiterfassung.Models.DTO;

namespace miniZeiterfassung.Controllers
{
    public class OutputController : Controller
    {
        private readonly TimeRecordingContext _context;

        public OutputController(TimeRecordingContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = new OutputResponseDTO()
            {
                Employees = await _context.Employees.Select(x => new Employee
                { 
                    EmployeeId =  x.EmployeeId, 
                    Name = x.Name
                })
                .ToListAsync(),
                Records = new List<Record>()
            };
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Index(OutputRequestDTO request)
        {
            if(ModelState.IsValid)
            {
                var records = await _context.Records
                    .Where(record => record.EmployeeId == request.EmployeeId 
                        && record.Date >= request.FromDate 
                        && record.Date <= request.ToDate)
                    .Include(record => record.Employee)
                    .ThenInclude(employee => employee.TimeModel)
                    .OrderBy(record => record.Date)
                    .ToListAsync();

                var employees = await _context.Employees.Select(x => new Employee
                { 
                    EmployeeId =  x.EmployeeId, 
                    Name = x.Name
                })
                .ToListAsync();

                var data = new OutputResponseDTO() { Records = records, Employees = employees };

                return View(data);
            }

            return View();
        }
    }
}
