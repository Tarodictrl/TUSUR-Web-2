using Microsoft.AspNetCore.Mvc;
using Lab1.Models;

namespace Lab1.Controllers
{
    public class OddController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Analyze(int number)
        {
            ViewBag.Result = OddModel.check(number);
            return View("Index");
        }
    }
}
