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
			ViewBag.CurrentSort = sortOrder;
			//if (searchString != null)
			//{
			//	page = 1;
			//}
			//else
			//{
			//	searchString = currentFilter;
			//}
			ViewBag.CurrentFilter = searchString;
			var incs = from s in db.Incidents
					   select s;
			incs = incs.OrderBy(s => s.StartIncident);

			//if (!String.IsNullOrEmpty(searchString))
			//{
			//	emps = emps.Where(s => s.Name.Contains(searchString));
			//}
			List<ExtremIncident> find = new List<ExtremIncident>();
			if (searchString != null)
			{
				foreach (ExtremIncident c in incs)
				{
					if (searchString == c.StartIncident)
						find.Add(c);
				}
			}
			int pageSize = 3;
			int pageNumber = (page ?? 1);
			return View("GetIncident", incs.ToPagedList(pageNumber, pageSize));
		}

    }
}