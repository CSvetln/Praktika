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
		public Employee Employee { get; set; }   //дежурный

	}
}