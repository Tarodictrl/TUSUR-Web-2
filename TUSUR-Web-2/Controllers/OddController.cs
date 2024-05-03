using Microsoft.AspNetCore.Mvc;
using TUSUR_Web_2.Models;

namespace TUSUR_Web_2.Controllers
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
