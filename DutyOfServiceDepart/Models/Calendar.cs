using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DutyOfServiceDepart.Models
{
	public class Calendar
	{
		public Dictionary<int, Employee> Duties { get; set; }
		[Key]
		public DateTime CurrentDate { get; set; }
	}
}