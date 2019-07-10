using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DutyOfServiceDepart.Models;
using PagedList;

namespace DutyOfServiceDepart.Controllers
{
    public class EmployeeController : Controller
    {
		private DutyContext db = new DutyContext();
        // GET: Employee
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
			int pageSize = 3;
			int pageNumber = (page ?? 1);
			return View("GetEmployee", emps.ToPagedList(pageNumber, pageSize));

        }
		//[Authorize(Roles = "Admin")]
		[HttpGet]
		public ViewResult CreateEmployee()
		{
			return View("CreateEmployee");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Employee employee)
		{
			if (ModelState.IsValid)
			{
				db.Employees.Add(employee);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(employee);
		}
		[HttpGet]
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			
			Employee employee = db.Employees.Find(id);
			if (employee == null)
			{
				return HttpNotFound();
			}
			return View(employee);
		}

	}

	
}