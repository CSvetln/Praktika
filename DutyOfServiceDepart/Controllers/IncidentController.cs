using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Data.Entity;
using DutyOfServiceDepart.Filters;
using LibraryModels;
using PagedList;

namespace DutyOfServiceDepart.Controllers
{
    public class IncidentController : Controller
    {
		DutyContext db = new DutyContext();

		[Authorize]
		public ActionResult Index(int? page)
        {
			var incs = db.Incidents.Include(x => x.Employee);
			incs = incs.OrderBy(s => s.DateIncident);
			int pageSize = 10;
			int pageNumber = (page ?? 1);
			return View("GetIncident", incs.ToPagedList(pageNumber, pageSize));		
		}

		[MyAuthorize]
		public ActionResult Delete(int id)
		{
			ExtremIncident incident = db.Incidents.Find(id);
			if (ModelState.IsValid)
			{
				db.Incidents.Remove(incident);
				db.SaveChanges();
			}
			return RedirectToAction("Index");
		}

		[MyAuthorize]
		[HttpGet]
		public ViewResult Create()
		{
			SelectList selectEmp = new SelectList(db.Employees, "EmployeId", "Name");
			Models.ExtremIncident extremIncident = new Models.ExtremIncident {
				Emps = selectEmp
		    };
			return View("CreateIncident", extremIncident);
		}

		[MyAuthorize]
		[HttpPost]		
		public ActionResult Create(DateTime DateIncident, int Employee, string DescIncident)
		{			
			Employee employee = db.Employees.Find(Employee);			
			ExtremIncident extremIncident = new ExtremIncident(DateIncident, employee, DescIncident);

			if (ModelState.IsValid)
			{
				db.Incidents.Add(extremIncident);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("CreateIncident");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}

