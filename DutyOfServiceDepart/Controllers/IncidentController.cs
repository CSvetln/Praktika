using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DutyOfServiceDepart.Models;
using PagedList;

namespace DutyOfServiceDepart.Controllers
{
    public class IncidentController : Controller
    {
		DutyContext db = new DutyContext();
        // GET: Incident
        public ActionResult Index(string sortOrder, string currentFilter, DateTime? searchString, int? page)
        {
			var incs = from s in db.Incidents
					   select s;
			incs = incs.OrderBy(s => s.StartIncident);

			int pageSize = 5;
			int pageNumber = (page ?? 1);
			return View("GetIncident", incs.ToPagedList(pageNumber, pageSize));
		}

		public ViewResult CreateIncident()
		{
			return View(db.Employees);
		}

    }
}