using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;
using DBModels;
using CalendarWebsite.Filters;
using CalendarWebsite.Models;

namespace CalendarWebsite.Controllers
{
    public class IncidentController : BaseControllerWithDB
    {
        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var incs = db.AccidentWorks.Include(x => x.Employee);
            incs = incs.OrderBy(s => s.AccidentDate);
            int pageSize = 10;
            int pageNumber = (page);
            var model = incs.ToPagedList(pageNumber, pageSize);

            return View(model);
        }

        [MyAuthorize]
        [HttpPost]
        public ActionResult Delete(int id, int pageDelete)
        {
            AccidentWork incident = db.AccidentWorks.Find(id);

            db.AccidentWorks.Remove(incident);
            db.SaveChanges();

            return RedirectToAction("Index", new { page = pageDelete });
        }

        [MyAuthorize]
        [HttpGet]
        public ViewResult Create()
        {
            SelectList selectEmp = new SelectList(db.Employees, "EmployeeId", "Name");
            AccidentForm model = new AccidentForm
            {
                Employees = selectEmp,
                Work = new AccidentWork()
            };

            return View(model);
        }

        [MyAuthorize]
        [HttpPost]
        public ActionResult Create(AccidentForm model)
        {
            if (ModelState.IsValid)
            {
                db.AccidentWorks.Add(model.Work);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}

