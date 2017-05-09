using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YelpMvp.Models;

namespace YelpMvp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetRestaurants()
        {
            var allRestaurants = Restaurant.GetRestaurants();

            return View(allRestaurants);
        }
    }
}
