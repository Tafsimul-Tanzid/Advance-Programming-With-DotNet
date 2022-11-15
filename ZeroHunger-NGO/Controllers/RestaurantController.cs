using System.Web.Mvc;

\using NGO.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NGO.Controllers
{
    public class RestaurantController : Controller
    {
        public ActionResult Index(int id = 1)
        {
            var db = new ZeroHungerDBEntities1();
            var result = (from don in db.Donations
                          where don.ResId == id
                          select don).ToList();
            return View(result);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Donation don)
        {
            var db = new ZeroHungerDBEntities1();
            db.Donations.Add(don);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var db = new ZeroHungerDBEntities1();
            var result = (from don in db.Donations
                          where don.Id == id
                          select don).SingleOrDefault();
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Donation donation)
        {
            var db = new ZeroHungerDBEntities1();
            var ext = (from don in db.Employees
                       where don.Id == donation.Id
                       select don).SingleOrDefault();
            db.Entry(ext).CurrentValues.SetValues(donation);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}