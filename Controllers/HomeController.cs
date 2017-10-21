using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HackOHIO2017.Models;

namespace HackOHIO2017.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Businesses()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Investors()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Locations()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Resources()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
