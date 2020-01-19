using LibraryModels;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using DutyOfServiceDepart.Filters;
using DutyOfServiceDepart.Models;

namespace DutyOfServiceDepart.Controllers
{
	public class VacationController : Controller
	{
		DutyContext db = new DutyContext();

		[Authorize]
		public ActionResult Index(DateTime? start) // Start дата начала месяца, в представлении можно перелистывать месяцы
		{
			Calendar calendar = Calendar.GetCalendarVacation(start);
			calendar.Vacation = null;
			return View(calendar);
		}

		[MyAuthorize]
		[HttpPost]
		public ActionResult CreateVacation(int selectedEmpId, DateTime Start, DateTime Finish)
		{		
			Employee newEmployee = db.Employees.Find(selectedEmpId);

			var vacations = db.Vacations.Where(x => x.Employee.EmployeId == selectedEmpId && (x.Start >= Start && x.Start <= Finish
					|| x.Start < Start && x.Finish >= Start)).ToList();

			if (vacations.Any())
			{
				foreach (Vacation vac in vacations)
				{
					db.Entry(vac).State = EntityState.Modified;
					vac.Start = Start;
					vac.Finish = Finish;
				}
			}
			else
			{
				Vacation newVacation = new Vacation(newEmployee, Start, Finish);
				db.Vacations.Add(newVacation);
			}
			db.SaveChanges();
			return RedirectToAction("Index", new { start = Start });
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