namespace miniZeiterfassung.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using miniZeiterfassung.Data;
using miniZeiterfassung.Models;
using miniZeiterfassung.Models.DTO;

public class TimeModelController : Controller
{
	private readonly TimeRecordingContext _context;

	public TimeModelController(TimeRecordingContext context)
	{
		_context = context;
	}

	// GET: TimeModel
	public async Task<IActionResult> Index()
	{
		var data = await _context.TimeModels.ToListAsync();
        return View(data);
	}


	// GET: TimeModel/Details/5
	public async Task<IActionResult> Details(int? id)
	{
		if (id == null)
		{
			return NotFound();
		}

		var timeModel = await _context.TimeModels
			.FirstOrDefaultAsync(m => m.TimeModelNumber == id);
		if (timeModel == null)
		{
			return NotFound();
		}

		return View(timeModel);
	}

	// GET: TimeModel/Create
	public IActionResult Create()
	{
		return View();
	}

	// POST: TimeModel/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind("TimeModelNumber,Name,FromTime,ToTime,TargetHours,FromBreak,ToBreak")] TimeModelDTO timeModel)
	{
		if (ModelState.IsValid)
		{
			var entity = new TimeModel()
			{
                TimeModelNumber = timeModel.TimeModelNumber,
				FromBreak = timeModel.FromBreak,	
				ToBreak = timeModel.ToBreak,
				FromTime = timeModel.FromTime,
				Name = timeModel.Name,
				TargetHours = timeModel.TargetHours,
				ToTime = timeModel.ToTime,
			};

			_context.Add(entity);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		return View(timeModel);
	}

	// GET: TimeModel/Edit/5
	public async Task<IActionResult> Edit(int? id)
	{
		if (id == null)
		{
			return NotFound();
		}

		var timeModel = await _context.TimeModels.FindAsync(id);
		if (timeModel == null)
		{
			return NotFound();
		}
		return View(timeModel);
	}

	// POST: TimeModel/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(int id, [Bind("TimeModelId,Name,FromTime,ToTime,TargetHours,FromBreak,ToBreak")] TimeModel timeModel)
	{
		if (id != timeModel.TimeModelId)
		{
			return NotFound();
		}

		if (ModelState.IsValid)
		{
			try
			{
				_context.Update(timeModel);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!TimeModelExists(timeModel.TimeModelId))
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
		return View(timeModel);
	}

	// GET: TimeModel/Delete/5
	public async Task<IActionResult> Delete(int? id)
	{
		if (id == null)
		{
			return NotFound();
		}

		var timeModel = await _context.TimeModels
			.FirstOrDefaultAsync(m => m.TimeModelId == id);
		if (timeModel == null)
		{
			return NotFound();
		}

		return View(timeModel);
	}

	// POST: TimeModel/Delete/5
	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		var timeModel = await _context.TimeModels.FindAsync(id);
		_context.TimeModels.Remove(timeModel);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}

	private bool TimeModelExists(int id)
	{
		return _context.TimeModels.Any(e => e.TimeModelId == id);
	}
}
