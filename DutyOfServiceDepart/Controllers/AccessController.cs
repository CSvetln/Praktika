using DutyOfServiceDepart.Filters;
using LibraryModels;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace DutyOfServiceDepart.Controllers
{
    public class AccessController : Controller
    {
		DutyContext db = new DutyContext();

		[Authorize]
		public ActionResult Index(int? page)
        {			
			var incs = from s in db.Accesses select s;
			incs = incs.OrderBy(s => s.Login);
			int pageSize = 2;
			int pageNumber = (page ?? 1);
			return View("GetAccess", incs.ToPagedList(pageNumber, pageSize));
        }

		[MyAuthorize]
		[HttpGet]
		public ViewResult Create()
		{
			var loginQuery = (from e in db.Employees select e.Login).Except
				(from a in db.Accesses select a.Login);
			SelectList selectLogin = new SelectList(loginQuery);
			Models.Access access = new Models.Access
			{
				Logins = selectLogin
			};
			return View("CreateAccess", access);
		}
		
		[MyAuthorize]
		[HttpPost]
		public ActionResult Create([Bind(Include = "Login, AllowedEdit")]LibraryModels.Access access)
		{			
			if (ModelState.IsValid)
			{
				db.Accesses.Add(access);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("CreateAccess");
		}

		[MyAuthorize]
		[HttpPost]
		public ActionResult Delete(int id, int pageDelete)
		{
			LibraryModels.Access access = db.Accesses.Find(id);
			if (ModelState.IsValid)
			{
				db.Accesses.Remove(access);
				db.SaveChanges();
			}
			return RedirectToAction("Index", new { page = pageDelete });
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