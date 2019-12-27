using System.Linq;
using System.Web.Mvc;
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
			var incs = from s in db.Incidents
						   select s;
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
			ViewBag.Emp = selectEmp;
			return View("CreateIncident");
		}

		[MyAuthorize]
		[HttpPost]		
		public ActionResult Create([Bind(Include = "DateIncident,EmployeeId,DescIncident")]ExtremIncident extremIncident)
		{
			Employee employee = db.Employees.Find(extremIncident.EmployeeId);
			extremIncident.Employee = employee;
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

