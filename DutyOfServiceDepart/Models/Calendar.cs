using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DutyOfServiceDepart.Models
{
	public class Calendar
	{
		public Dictionary<int, Employee> Duties { get; set; } = new Dictionary<int, Employee>();
		[Key]
		public DateTime CurrentDate { get; set; }
		public SelectList Emps { get; set; }
		public SelectList Posts { get; set; }
	}
}