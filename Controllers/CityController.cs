using System.Collections.Generic;
using System.Linq;
using HackOHIO2017.Data;
using HackOHIO2017.Models;
using Microsoft.AspNetCore.Mvc;

namespace HackOHIO2017.Controllers
{
    public class CityController : Controller
    {
        private BusinessDbContext context;
        public CityController(BusinessDbContext context)
        {
            this.context = context;

        }
        public IEnumerable<City> GetCities()
        {
            return context.Cities;
        }

        public IActionResult Index(){
            var city = context.Cities.FirstOrDefault();
            return View(context);
        }
    }
}