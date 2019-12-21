﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages.Html;
using System.Data.Entity;

namespace DutyOfServiceDepart.Models
{
	public class Calendar
	{
		public Dictionary<DateTime, Employee[]> Duties { get; set; } = new Dictionary<DateTime, Employee[]>();

		public DateTime CurrentDate { get; set; }

		public IEnumerable<SelectListItem> Emps { get; set; }
		
		public static Calendar GetCalendarDuty(DateTime? start)
		{
			/*Метод создаёт экземепляр класса Calendar и записывает в него текущую дату и дежурных сотрудников в этом месяце */

			DateTime target = start ?? DateTime.Now.Date;
			
			using (DutyContext db = new DutyContext())
			{
				Calendar calendar = new Calendar
				{
					CurrentDate = target
				};

				var dutyLists = db.DutyLists.Include(x => x.Employee).Where(x => x.DateDuty.Year == calendar.CurrentDate.Year
					&& x.DateDuty.Month == calendar.CurrentDate.Month).ToList();

				foreach (DutyList s in dutyLists)
				{
					Employee[] emps = { s.Employee };
					calendar.Duties.Add(s.DateDuty, emps); // Duties - массив пар значений - число месяца и сотрудник 
				}
				return calendar;
			}
		}
	
		public static Calendar GetCalendarVacation(DateTime? start)
		{
			DateTime target = start ?? DateTime.Now.Date;

			using (DutyContext db = new DutyContext())
			{
				Calendar calendar = new Calendar { CurrentDate = target };

				DateTime current = new DateTime(calendar.CurrentDate.Year, calendar.CurrentDate.Month, 1);
				int allDayMonth = DateTime.DaysInMonth(calendar.CurrentDate.Year, calendar.CurrentDate.Month);
				DateTime last = new DateTime(calendar.CurrentDate.Year, calendar.CurrentDate.Month, allDayMonth);

				var vacations = db.Vacations.Include(x => x.Employee).Where(x => x.Start >= current && x.Start <= last
					|| x.Start < current && x.Finish >= current).ToList();

				while (current <= last)
				{
					var emps = vacations.Where(x => x.Start <= current && x.Finish >= current).Select(x=> x.Employee).ToArray();

					if (emps.Length!=0)
						calendar.Duties.Add(current, emps);
					
					current = current.AddDays(1);
				}
				
				return calendar;
			}
		}
	}
}