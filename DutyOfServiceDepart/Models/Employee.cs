using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DutyOfServiceDepart.Models
{
	public class Employee
	{
		[Key]
		public int EmployeId { get; set; }
		[Required]
		public string FamName { get; set; }
		[Required]
		public string Name { get; set; }

		public string SecName { get; set; }
		[MinLength(6)]
		[MaxLength(100)]
		[Required]
		public string Email { get; set; }
		[MinLength(4)]
		[MaxLength(30)]
		[Required]
		public string login { get; set; }
	}
}