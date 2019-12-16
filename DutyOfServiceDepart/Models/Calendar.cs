using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web.Mvc;
using System.Web.WebPages.Html;
using System.Data.Entity;

namespace DutyOfServiceDepart.Models
{
	public class Calendar
	{
		public Dictionary<int, Employee> Duties { get; set; } = new Dictionary<int, Employee>();

		public DateTime CurrentDate { get; set; }

		public List<Employee> Emps { get; set; }
		
		public static Calendar GetCalendar(DateTime? start)
		{
			/*Метод создаёт экземепляр класса Calendar и записывает в него дату, от которой начинать строить 
			  календарь и дежурных сотрудников в этом месяце */

			DateTime target = start ?? DateTime.Now.Date;
			
			using (DutyContext db = new DutyContext())
			{
				Calendar calendar = new Calendar
				{
					CurrentDate = target
				};

				var dutyLists = db.DutyLists.Include(x => x.Employee).Where(x => x.DateDuty.Year == calendar.CurrentDate.Year && x.DateDuty.Month == calendar.CurrentDate.Month).ToList();
				foreach (DutyList s in dutyLists)
				{
					calendar.Duties.Add(s.DateDuty.Day, s.Employee); // Duties - массив пар значений - число месяца и сотрудник 
				}
				return calendar;
			}
		}
	}
}