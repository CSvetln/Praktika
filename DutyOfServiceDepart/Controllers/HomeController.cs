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
		public ActionResult Edit(int selectedEmpId, DateTime dateEdit)
		{
			Employee newEmployee = db.Employees.Find(selectedEmpId);//находим выбранного на дату дежурства сотрудника 
			DutyList duty = db.DutyLists.Include(x=>x.Employeer).FirstOrDefault(x => x.DateDuty == dateEdit); //находим дежурство с такой датой

			if (duty != null) // если такие записи дежурств есть, меняем дежурного
			{
				db.Entry(duty).State = EntityState.Modified;
				duty.Employeer = newEmployee;
			}
			else // если таких дежурств нет, создаём новую запись
			{
				DutyList newDutyList = new DutyList() { DateDuty = dateEdit, Employeer = newEmployee, DecrDuty = String.Empty };
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

			Dictionary<int, string> duties = new Dictionary<int, string>();

			foreach (DutyList s in db.DutyLists.Include(x => x.Employeer).Where(x => x.DateDuty.Year == curDate.Year && x.DateDuty.Month == curDate.Month).ToList())
			{
				duties.Add(s.DateDuty.Day, s.Employeer.Name);
			}

			SendSchedule sendSchedule = new SendSchedule(db.Employees.Select(x => x.Email).ToArray(), "График дежурств", "Изучите график дежурств на текущий месяц", curDate, duties);
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