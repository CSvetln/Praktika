using DutyOfServiceDepart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using System.Data.Entity;
using DutyOfServiceDepart.Filters;
using System.Web.Configuration;
using Infrastructure.Mail;

namespace DutyOfServiceDepart.Controllers
{
	public class VacationController : Controller
	{
		DutyContext db = new DutyContext();

		public ActionResult Index(DateTime? start) // Start дата начала месяца, в представлении можно перелистывать месяцы
		{
			Calendar calendar = Calendar.GetCalendarVacation(start);
			calendar.Emps= from genre in db.Employees select new System.Web.WebPages.Html.SelectListItem
				{ Text = genre.Name, Value = genre.EmployeId.ToString() };
			//calendar.Emps = db.Employees.ToList();// делаем выборку всех сотрудников в выпадающий список
			ViewBag.Books = db.Employees.ToList();
			return View(calendar);
		}
	}
}