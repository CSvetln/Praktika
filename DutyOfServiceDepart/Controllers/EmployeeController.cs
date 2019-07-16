using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DutyOfServiceDepart.Filters;
using DutyOfServiceDepart.Models;
using PagedList;

namespace DutyOfServiceDepart.Controllers
{
    public class EmployeeController : Controller
    {
		private DutyContext db = new DutyContext();

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {			
			ViewBag.CurrentSort = sortOrder;
			if (searchString != null)
			{
				page = 1;
			}
			else
			{
				searchString = currentFilter;
			}
			ViewBag.CurrentFilter = searchString;
			var emps = from s in db.Employees
					   select s;
			emps = emps.OrderByDescending(s => s.Name);
			if (!String.IsNullOrEmpty(searchString))
			{
				emps = emps.Where(s => s.Name.Contains(searchString));
			}
			int pageSize = 5;
			int pageNumber = (page ?? 1);
			return View("GetEmployee", emps.ToPagedList(pageNumber, pageSize));
        }

		[MyAuthorize]
		[HttpGet]
		public ViewResult Create()
		{
			return View("CreateEmployee");
		}
		[MyAuthorize]
		[HttpPost]
		public ActionResult Create([Bind(Include = "Name, Email, Login")]Employee employee)
		{
			if (ModelState.IsValid)
			{
				db.Employees.Add(employee);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("CreateEmployee");
		}
		[MyAuthorize]
		public ActionResult Delete(int id)
		{
			Employee employee = db.Employees.Find(id);
			if (employee != null)
			{
				db.Employees.Remove(employee);
				db.SaveChanges();
			}
			return RedirectToAction("Index");
		}
		
	}

	
}