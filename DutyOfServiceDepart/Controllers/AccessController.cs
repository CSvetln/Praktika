using System.Linq;
using System.Web.Mvc;
using PagedList;
using DBModels;
using CalendarWebsite.Models;
using CalendarWebsite.Filters;
using System;

namespace CalendarWebsite.Controllers
{
    public class AccessController : BaseControllerWithDB
    {
        const Int32 PAGE_SIZE = 15;

        [Authorize]
        public ActionResult Index(int page = 1)
        {
            var incs = from s in db.Users select s;

            incs = incs.OrderBy(s => s.DomainLogin);

            IPagedList<User> model = incs.ToPagedList(page, PAGE_SIZE);

            return View(model);
        }

        [MyAuthorize]
        [HttpGet]
        public ActionResult Create()
        {
            IQueryable<String> loginQuery = (from e in db.Employees select e.DomainLogin).Except(from a in db.Users select a.DomainLogin);
            UserAddForm model = new UserAddForm
            {
                Logins = loginQuery.ToArray(),
                User = new User()
            };

            return View(model);
        }

        [MyAuthorize]
        [HttpPost]
        public ActionResult Create(UserAddForm model)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(model.User);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [MyAuthorize]
        [HttpPost]
        public ActionResult Delete(int id, int pageDelete)
        {
            User user = db.Users.Find(id);

            db.Users.Remove(user);
            db.SaveChanges();

            return RedirectToAction("Index", new { page = pageDelete });
        }
    }
}