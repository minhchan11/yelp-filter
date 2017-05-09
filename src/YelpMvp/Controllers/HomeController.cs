using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YelpMvp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace YelpMvp.Controllers
{
    public class HomeController : Controller
    {
        private YelpMvpContext db = new YelpMvpContext();
        public IActionResult Index()
        {
            ViewBag.Cuisine = db.Cuisines.Select(rr =>new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name });
            ViewBag.Location = new SelectList(db.Locations, "City", "State");
            return View();
        }

        public IActionResult GetRestaurants()
        {
            var allRestaurants = Restaurant.GetRestaurants();

            return View(allRestaurants);
        }

    }
}
