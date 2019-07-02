using DutyOfServiceDepart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DutyOfServiceDepart.Controllers
{
	public class HomeController : Controller
	{
		// создаем контекст данных
		DutyContext db = new DutyContext();

		public ActionResult Index()
		{
			// получаем из бд все объекты
			IEnumerable<Employee> employees = db.Employees;
			// передаем все объекты в динамическое свойство Employees в ViewBag
			ViewBag.Employees = employees;
			// возвращаем представление
			return View();
		}
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}