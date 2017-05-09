using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YelpMvp.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace YelpMvp.Controllers
{
    public class LocationsController : Controller
    {
        private YelpMvpContext db = new YelpMvpContext();
        public IActionResult Index()
        {
            return View(db.Locations.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string city, string state)
        {
            Location newLocation = new Location();
            newLocation.City = city;
            newLocation.State = state;
            db.Locations.Add(newLocation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
