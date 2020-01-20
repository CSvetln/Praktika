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

		[Required]
		public Employee Employeer { get; set; }   //дежурный

		public string DecrDuty { get; set; } //описание дежурства 

	}
}