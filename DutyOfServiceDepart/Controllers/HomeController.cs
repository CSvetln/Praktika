﻿using DutyOfServiceDepart.Models;
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
			
			 // Start дата начала месяца, в представлении можно перелистывать месяцы

			Calendar calendar = Calendar.GetCalendar(start);

			calendar.Emps = new SelectList(db.Employees, "EmployeId", "Name");// делаем выборку всех сотрудников в выпадающий список
			calendar.Posts = new SelectList(posts);
			
			return View(calendar);
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