using Microsoft.AspNetCore.Mvc;

namespace miniZeiterfassung.Controllers
{
    public class OutputController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
