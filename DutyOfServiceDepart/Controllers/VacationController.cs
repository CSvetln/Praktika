using System;
using System.Collections.Generic;
using System.Linq;
using DutyOfServiceDepart.Models;
using System.Web.Mvc;

namespace DutyOfServiceDepart.Controllers
{
	public class VacationController : Controller
	{
		DutyContext db = new DutyContext();

		public ActionResult Index(DateTime? start) // Start дата начала месяца, в представлении можно перелистывать месяцы
		{
			Calendar calendar = Calendar.GetCalendar(start);

			calendar.Emps = db.Employees.ToList();// делаем выборку всех сотрудников в выпадающий список

			return View(calendar);
		}
	}
}