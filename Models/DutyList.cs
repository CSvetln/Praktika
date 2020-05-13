using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryModels
{
	public class DutyList
	{
		[Key]
		public int DutyId { get; set; }

		[Required]
		public DateTime DateDuty { get; set; } //дата дежурства

		public int? EmployeeId { get; set; }
		
		public virtual Employee Employee { get; set; }   //дежурный
	}
}