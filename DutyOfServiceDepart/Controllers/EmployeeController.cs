using System;
using System.Linq;
using System.Web.Mvc;
using DutyOfServiceDepart.Filters;
using LibraryModels;
using PagedList;

namespace DutyOfServiceDepart.Controllers
{
    public class EmployeeController : Controller
    {
		[Authorize]
		public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
			using (DutyContext db = new DutyContext())
			{							
				if (searchString != null)
				{
					page = 1;
				}
				else
				{
					searchString = currentFilter;
				}

				var emps = from s in db.Employees select s;
				emps = emps.OrderByDescending(s => s.Name);

				if (!String.IsNullOrEmpty(searchString))
				{
					emps = emps.Where(s => s.Name.Contains(searchString));
				}

				int pageSize = 5;
				int pageNumber = (page ?? 1);

				Models.Sort sort = new Models.Sort();
				sort.CurrentSort = sortOrder;
				sort.CurrentFilter = searchString;
				sort.Emps = emps.ToPagedList(pageNumber, pageSize);

				return View("GetEmployee", sort);
			}
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
		public ActionResult Delete(int id)
		{
			using (DutyContext db = new DutyContext())
			{
				Employee employee = db.Employees.Find(id);
				if (ModelState.IsValid)
				{
					db.Employees.Remove(employee);
					db.SaveChanges();
				}
				return RedirectToAction("Index");
			}
		}
	}
}