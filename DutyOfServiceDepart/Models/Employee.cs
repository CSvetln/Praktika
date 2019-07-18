using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DutyOfServiceDepart.Models
{
	public class Employee
	{
	
		[Key]
		public int EmployeId { get; set; }
		[Required]
		public string Name { get; set; }

		[StringLength(100, MinimumLength = 6)]
		[MinLength(6)]
		[MaxLength(100)]
		[Required]
		public string Email { get; set; }
		[StringLength(100, MinimumLength =4)]
		[MinLength(4)]
		[MaxLength(100)]
		[Required]
		public string Login { get; set; }

		
	}
}