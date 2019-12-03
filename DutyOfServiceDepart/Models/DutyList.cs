using System;
using System.ComponentModel.DataAnnotations;

namespace DutyOfServiceDepart.Models
{
	public class DutyList
	{
		[Key]
		public int DutyId { get; set; }

		[Required]
		public DateTime DateDuty { get; set; } //дата дежурства
	
		[Required]
		public Employee Employee { get; set; }   //дежурный

		public string DecrDuty { get; set; } //описание дежурства 

	}
}