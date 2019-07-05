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
		foreach(DutyList s in db.DutyLists)
			{
		Dictionary<DateTime, Employee> ex = new Dictionary<DateTime, Employee>();
	}
		foreach(KeyValuePair<DateTime, Employee> s in ex)


		[HttpGet]
		public ActionResult Index()
		{
			
			return View(db.Calendars);

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