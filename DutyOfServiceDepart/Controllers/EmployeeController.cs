using System;
using System.Linq;
using System.Web.Mvc;
using DBModels;
using PagedList;
using CalendarWebsite.Filters;
using CalendarWebsite.Models;

namespace CalendarWebsite.Controllers
{
    public class EmployeeController : BaseControllerWithDB
    {
        const Int32 FIXED_PAGESIZE = 15;

        [Authorize]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int page = 1)
        {
            var emps = from s in db.Employees select s;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            emps = emps.OrderByDescending(s => s.LastName).ThenByDescending(x => x.FirstName);

            if (!String.IsNullOrEmpty(searchString))
            {
                emps = emps.Where(s => s.FirstName.Contains(searchString) || s.MidlleName.Contains(searchString) || s.LastName.Contains(searchString));
            }

            EmployeeList model = new EmployeeList() { CurrentFilter = searchString, CurrentSort = sortOrder, Employees = emps.ToPagedList(page, FIXED_PAGESIZE) };

            return View(model);
        }

        [MyAuthorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [MyAuthorize]
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name, Email, Login")]Employee employee)
        {
            using (DutyContext db = new DutyContext())
            {
                if (ModelState.IsValid)
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View("CreateEmployee");
            }
        }

        [MyAuthorize]
        [HttpPost]
        public ActionResult Delete(int id, int pageDelete)
        {
            Employee employee = db.Employees.Find(id);

            db.Employees.Remove(employee);
            db.SaveChanges();

            return RedirectToAction("Index", new { page = pageDelete });
        }
    }
}