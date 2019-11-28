using DutyOfServiceDepart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using DutyOfServiceDepart.Filters;
using DutyOfServiceDepart.Mail;

namespace DutyOfServiceDepart.Controllers
{
	public class HomeController : Controller
	{		
		DutyContext db = new DutyContext();
		List<String> posts = new List<string>() { "Smtp", "Exchange" };

		[Authorize]
		[HttpGet]
		public ActionResult Index(DateTime? start) //возвращает представление
		{
			Calendar calendar;
			DateTime target1 = start ?? DateTime.Now.Date; // Start дата начала месяца, в представлении можно перелистывать месяцы

			calendar = GetCalendar(target1);
			
			SelectList selectLogin = new SelectList(db.Employees, "EmployeId", "Name");// делаем выборку всех сотрудников в выпадающий список
			SelectList selectPost = new SelectList(posts);
			ViewBag.Emp = selectLogin;
			ViewBag.Posts = selectPost;
			return View(calendar);
		}

		private Calendar GetCalendar(DateTime target)
		{
			/*Метод создаёт экземепляр класса Calendar и записывает в него дату, от которой начинать строить 
			  календарь и дежурных сотрудников в этом месяце */
			using (DutyContext db = new DutyContext())
			{
				Calendar calendar = new Calendar
				{
					CurrentDate = target
				};

				foreach (DutyList s in db.DutyLists.Include(x => x.Employee).Where(x => x.DateDuty.Year == calendar.CurrentDate.Year && x.DateDuty.Month == calendar.CurrentDate.Month).ToList())
				{
					calendar.Duties.Add(s.DateDuty.Day, s.Employee); // Duties - массив пар значений - число месяца и сотрудник 
				}
				return calendar;
			}
		}
		[MyAuthorize]
		[HttpPost]
		public ActionResult Edit(int selectedEmpId, DateTime dateEdit)
		{
			using (DutyContext db = new DutyContext())
			{
				Employee newEmployee = db.Employees.Find(selectedEmpId);//находим выбранного на дату дежурства сотрудника 
				List<DutyList> dutyList = db.DutyLists.Where(x => x.DateDuty == dateEdit).ToList(); //находим дежурства с такой датой
				if (dutyList.Count != 0) // если такие записи дежурств есть, меняем дежурного
				{
					foreach (DutyList s in dutyList)
					{
						db.Entry(s).State = EntityState.Modified;
						s.Employee = newEmployee;
					}
				}
				else // если таких дежурств нет, создаём новую запись
				{
					DutyList newDutyList = new DutyList() { DateDuty = dateEdit, Employee = newEmployee, DecrDuty = String.Empty };
					db.DutyLists.Add(newDutyList);
				}
				db.SaveChanges();				
								
				return RedirectToAction("Index");
			}
		}


		[MyAuthorize]
		public ViewResult SendAll(string selectedPost, DateTime curDate)
		{
			SendSchedule sendSchedule = new SendSchedule(db.Employees.Select(x => x.Email).ToArray(), "График дежурств", "Изучите график дежурств на текущий месяц", curDate);
			switch (selectedPost)
			{
				case "Smtp":					
					sendSchedule.Send(new SendingSMTP());
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