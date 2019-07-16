using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DutyOfServiceDepart.Filters;
using DutyOfServiceDepart.Models;
using PagedList;

namespace DutyOfServiceDepart.Controllers
{
    public class IncidentController : Controller
    {
		DutyContext db = new DutyContext();
        // GET: Incident
        public ActionResult Index(int? page)
        {
			var incs = from s in db.Incidents
					   select s;
			incs = incs.OrderBy(s => s.DateIncident);

			int pageSize = 5;
			int pageNumber = (page ?? 1);
			return View("GetIncident", incs.ToPagedList(pageNumber, pageSize));
		}
		[MyAuthorize]
		public ActionResult Delete(int id)
		{
			ExtremIncident incident = db.Incidents.Find(id);
			if (incident != null)
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

			return View("CreateIncident", db.Employees);
		}
		[MyAuthorize]
		[HttpPost]		
		public ActionResult Create(ExtremIncident extremIncident, int EmployeId)
		{		
			Employee employee = db.Employees.Find(EmployeId);
			extremIncident.Employee = employee;
			if (ModelState.IsValid)
			{
				db.Incidents.Add(extremIncident);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("CreateIncident", db.Employees);
		}
	}
}