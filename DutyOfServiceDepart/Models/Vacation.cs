using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DutyOfServiceDepart.Models
{
	public class Vacation
	{
		[Key]
		public int IdVacation { get; set; }

		[Required]
		public Employee Employee { get; set; }

		[Required]
		public DateTime Start { get; set; }

		[Required]
		public DateTime Finish { get; set; }

		public Vacation(Employee employee, DateTime start, DateTime finish)
		{
			this.Employee = employee;
			this.Start = start;
			this.Finish = finish;
		}
		public Vacation()
		{
		}
	}
}