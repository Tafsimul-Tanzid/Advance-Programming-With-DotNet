using NGO.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NGO.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index(int id = 4)
        {
            var db = new ZeroHungerDBEntities1();
            var result = (from details in db.DonationDetails
                          where details.EmpId == id
                          select details).ToList();
            var dates = (from details in db.DonationDetails
                         join donations in db.Donations
                         on details.DonationId equals donations.Id
                         select donations.Validity).ToList();
            ViewBag.Date = dates;
            //ViewBag.RestName = 
            //ViewBag.Location = 
            return View(result);
        }

        public ActionResult CollectedDonation()
        {
            return View();
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
