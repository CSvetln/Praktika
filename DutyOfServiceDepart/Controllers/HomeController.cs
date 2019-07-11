using DutyOfServiceDepart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DutyOfServiceDepart.Controllers
{
	public class HomeController : Controller
	{
		// создаем контекст данных
		DutyContext db = new DutyContext();
		DateTime d = new DateTime(2019, 02, 02);
		
	    [HttpGet]
		public ActionResult Index(DateTime? Start)
		{
			Calendar calendar;
			DateTime Target1 = Start.HasValue ? Start.Value : DateTime.Now.Date;
			
			calendar = GetCalendar(Target1);
			return View(calendar);
		}
		[HttpPost]
		public string Index(int selectedEmpId)
		{			
			return  selectedEmpId.ToString();			
		}
		private Calendar GetCalendar(DateTime Target)
		{
			Calendar calendar = new Calendar();		
			calendar.CurrentDate = Target;


			foreach (DutyList s in db.DutyLists.Include(x => x.Employee).Where(x => x.DateDuty.Year == calendar.CurrentDate.Year && x.DateDuty.Month == calendar.CurrentDate.Month).ToList())
			{
				calendar.Duties.Add(s.DateDuty.Day, s.Employee);
				
			}
			return calendar;
		}
		[HttpPost]
		public string Edit(int selectedEmpId)
		{
			return selectedEmpId.ToString();
		}
	}
}