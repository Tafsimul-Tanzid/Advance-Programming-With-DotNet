using NGO.DB;
using System;
using System.Linq;
using System.Web.Mvc;

namespace NGO.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DeleteEmployee(int id)
        {
            var db = new ZeroHungerDBEntities1();
            var emp = (from em in db.Employees
                       where em.Id == id
                       select em).SingleOrDefault();
            return View(emp);
        }

        [HttpPost]
        public ActionResult DeleteEmployee(Employee employee)
        {
            try
            {
                var db = new ZeroHungerDBEntities1();
                var emp = (from em in db.Employees
                           where em.Id == employee.Id
                           select em).SingleOrDefault();
                db.Employees.Remove(emp);
                db.SaveChanges();
                return RedirectToAction("ViewEmployee");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            try
            {
                var db = new ZeroHungerDBEntities1();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("ViewEmployee");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            var db = new ZeroHungerDBEntities1();
            var emp = (from em in db.Employees
                       where em.Id == id
                       select em).SingleOrDefault();
            return View(emp);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(Employee emp)
        {
            var db = new ZeroHungerDBEntities1();
            var ext = (from em in db.Employees
                       where em.Id == emp.Id
                       select em).SingleOrDefault();
            db.Entry(ext).CurrentValues.SetValues(emp);
            db.SaveChanges();

            return RedirectToAction("ViewEmployee");
        }
        [HttpGet]
        public ActionResult ViewEmployee()
        {
            var db = new ZeroHungerDBEntities1();
            var emp = db.Employees.ToList();
            return View(emp);
        }

        public ActionResult ViewEmployeeDetails(int id)
        {
            var db = new ZeroHungerDBEntities1();
            var emp = (from em in db.Employees
                       where em.Id == id
                       select em).SingleOrDefault();
            return View(emp);
        }


        public ActionResult Donations()
        {
            return View();
        }

        public ActionResult AllDonations()
        {
            return View();
        }

        public ActionResult AssignEmployee()
        {

            return View();
        }
    }
}