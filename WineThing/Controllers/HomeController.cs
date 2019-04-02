using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineThing.Models;

namespace WineThing.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int cost, int points)
        {
            return RedirectToAction("WineList", new { cost, points });
        }

        [HttpGet]
        public IActionResult WineList(int cost, int points)
        {
            var wineList = from wine in Wines.GetWineList()
                           where wine.Price < cost
                           where wine.Points > points
                           select wine;

            return View(wineList);
        }
    }
}
