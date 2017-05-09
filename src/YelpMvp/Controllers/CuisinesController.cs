using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YelpMvp.Models;

namespace YelpMvp.Controllers
{
    public class CuisinesController : Controller
    {

        private YelpMvpContext db = new YelpMvpContext();
        public IActionResult Index()
        {
            return View(db.Cuisines.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cuisine cuisine)
        {
            db.Cuisines.Add(cuisine);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
