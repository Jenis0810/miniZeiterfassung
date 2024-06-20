using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using miniZeiterfassung.Data;
using miniZeiterfassung.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using miniZeiterfassung.Models.DTO;

public class RecordController : Controller
{
    private readonly TimeRecordingContext _context;

    public RecordController(TimeRecordingContext context)
    {
        _context = context;
    }

    // GET: Record
    public async Task<IActionResult> Index()
    {
        var records = await _context.Records.Include(r => r.Employee)
            .OrderBy(r => r.Date).ToListAsync();
        return View(records);
    }


    // GET: Record/Create
    public IActionResult Create()
    {
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Name");
        return View();
    }

    // POST: Record/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("RecordId,Date,FromTime,ToTime,EmployeeId")] RecordDTO record)
    {
        if (ModelState.IsValid)
        {
            var entity = new Record()
            {
                Date = record.Date,
                EmployeeId = record.EmployeeId,
                FromTime = record.FromTime,
                ToTime = record.ToTime
            };

            _context.Add(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Name", record.EmployeeId);
        return View(record);
    }

    // GET: Record/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var record = await _context.Records.FindAsync(id);
        if (record == null)
        {
            return NotFound();
        }
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Name", record.EmployeeId);
        return View(record);
    }

    // POST: Record/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("RecordId,Date,FromTime,ToTime,EmployeeId")] Record record)
    {
        if (id != record.RecordId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(record);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordExists(record.RecordId))
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
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Name", record.EmployeeId);
        return View(record);
    }

    private bool RecordExists(int id) => _context.Records.Any(e => e.RecordId == id);
}
