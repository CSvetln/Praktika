using LibraryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using DutyOfServiceDepart.Filters;
using DutyOfServiceDepart.Models;
using System.Web.Configuration;
using Infrastructure.Mail;

namespace DutyOfServiceDepart.Controllers
{
	public class HomeController : Controller
	{
		DutyContext db = new DutyContext();

		[Authorize]
		[HttpGet]
		public ActionResult Index(DateTime? start) // Start дата начала месяца, в представлении можно перелистывать месяцы
		{
			Calendar calendar = Calendar.GetCalendarDuty(start);
			calendar.Vacation = Calendar.GetCalendarVacation(start);
			return View(calendar);
		}

		[MyAuthorize]
		[HttpPost]
		public ActionResult Edit(int[] selectedEmpId, DateTime dateEdit)
		{
			var duties = db.DutyLists.Where(x => x.DateDuty == dateEdit).ToList(); // все дежурства с такой датой
			foreach(DutyList s  in duties)//очищаем все на эту дату
			{
				db.Entry(s).State = EntityState.Deleted;
				db.DutyLists.Remove(s);
			}
			for (int i = 0; i < selectedEmpId.Length; i++)   // содаем новые
			{
				Employee newEmployee = db.Employees.Find(selectedEmpId[i]);
				DutyList newDutyList = new DutyList() { DateDuty = dateEdit, Employee = newEmployee };
				db.Entry(newDutyList).State = EntityState.Added;
				db.DutyLists.Add(newDutyList);
			}

			db.SaveChanges();
			return RedirectToAction("Index", new { start = dateEdit });
		}

		[MyAuthorize]
		public ViewResult SendAll(DateTime curDate)
		{
			string login = WebConfigurationManager.AppSettings["login"];
			string pass = WebConfigurationManager.AppSettings["pass"];

			Dictionary<int, Employee[]> duties = new Dictionary<int, Employee[]>();

			var dutyLists = db.DutyLists.Include(x => x.Employee).Where(x => x.DateDuty.Year == curDate.Year
					&& x.DateDuty.Month == curDate.Month).OrderBy(x => x.DateDuty).ToList();

			var dates = dutyLists.Select(x => x.DateDuty).Distinct();

			foreach (DateTime s in dates)
			{
				Employee[] emps = dutyLists.Where(x => x.DateDuty == s).Select(x => x.Employee).ToArray();
				duties.Add(s.Day, emps);
			}

			SendSchedule sendSchedule = new SendSchedule(db.Employees.Select(x => x.Email).ToArray(),
				"График дежурств", "Изучите график дежурств на текущий месяц", curDate, duties);

			string selectedPost = WebConfigurationManager.AppSettings["Post"];

			switch (selectedPost)
			{
				case "SMTP":
					sendSchedule.Send(new SendingSMTP(login, pass));
					break;
				case "Exchange":
					sendSchedule.Send(new SendingExchange());
					break;
			}
			return View();
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