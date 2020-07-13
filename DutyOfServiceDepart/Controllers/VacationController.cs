using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using DBModels;
using CalendarWebsite.Filters;
using CalendarWebsite.Models;

namespace CalendarWebsite.Controllers
{
    public class VacationController : BaseControllerWithDB
    {
        [Authorize]
        public ActionResult Index(DateTime? start) // Start дата начала месяца, в представлении можно перелистывать месяцы
        {
            Calendar calendar = Calendar.GetCalendarVacation(start);
            calendar.Vacation = null;

            return View(calendar);
        }

        [MyAuthorize]
        [HttpPost]
        public ActionResult Index(int selectedEmpId, DateTime start, DateTime finish)
        {
            Employee newEmployee = db.Employees.Find(selectedEmpId);

            var vacations = db.Vacations.Include(x => x.Employee).Where(x => x.Employee.Id == selectedEmpId && (x.BeginDate >= start && x.BeginDate <= finish
                      || x.BeginDate < start && x.EndDate >= start)).ToList();

            if (vacations.Any())
            {
                foreach (Vacation vac in vacations)
                {
                    db.Entry(vac).State = EntityState.Modified;
                    vac.BeginDate = start;
                    vac.EndDate = finish;
                }
            }
            else
            {
                Vacation newVacation = new Vacation() { BeginDate = start, EndDate = finish, EmployeeId = selectedEmpId };
                db.Vacations.Add(newVacation);
            }

            db.SaveChanges();

            return RedirectToAction("Index", new { start = start });
        }
    }
}