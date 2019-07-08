using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DutyOfServiceDepart.Models
{
	public class Calendar
	{
		public Dictionary<int, Employee> Duties { get; set; } = new Dictionary<int, Employee>();
		[Key]
		public DateTime CurrentDate { get; set; }
	}
}