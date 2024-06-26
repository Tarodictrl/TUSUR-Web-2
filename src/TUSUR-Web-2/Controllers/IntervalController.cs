﻿using Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public class IntervalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Analyze(string numbers)
        {
            int[] interval = numbers.Trim().Split(' ').Select(int.Parse).ToArray();
            var result = IntervalModel.InInterval(interval, -5, 6);
            ViewBag.Interval = string.Join(" ", result);
            return View("Index");
        }
    }

}
