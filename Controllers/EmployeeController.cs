using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using miniZeiterfassung.Data;
using miniZeiterfassung.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using miniZeiterfassung.Models.DTO;

public class EmployeeController : Controller
{
    private readonly TimeRecordingContext _context;

    public EmployeeController(TimeRecordingContext context)
    {
        _context = context;
    }
    // GET: Employee
    public async Task<IActionResult> Index()
    {
        var employees = await _context.Employees.Include(e => e.TimeModel).ToListAsync();
        return View(employees);
    }


    // GET: Employee/Create
    public IActionResult Create()
    {
        ViewData["TimeModelId"] = new SelectList(_context.TimeModels, "TimeModelId", "Name");
        return View();
    }

    // POST: Employee/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("EmployeeNumber,Name,Address,TimeModelId,StartingBalance")] EmployeeDTO employee)
    {
        if (ModelState.IsValid)
        {
            var entity = new Employee()
            {
                Address = employee.Address,
                EmployeeNumber = employee.EmployeeNumber,
                Name = employee.Name,
                StartingBalance = employee.StartingBalance,
                TimeModelId = employee.TimeModelId
            };
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["TimeModelId"] = new SelectList(_context.TimeModels, "TimeModelId", "Name", employee.TimeModelId);
        return View(employee);
    }

    // GET: Employee/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        ViewData["TimeModelId"] = new SelectList(_context.TimeModels, "TimeModelId", "Name", employee.TimeModelId);
        return View(employee);
    }

    // POST: Employee/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Name,Address,TimeModelId,StartingBalance")] Employee employee)
    {
        if (id != employee.EmployeeId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(employee);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(employee.EmployeeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["TimeModelId"] = new SelectList(_context.TimeModels, "TimeModelId", "Name", employee.TimeModelId);
        return View(employee);
    }

    private bool EmployeeExists(int id) => _context.Employees.Any(e => e.EmployeeId == id);
}
