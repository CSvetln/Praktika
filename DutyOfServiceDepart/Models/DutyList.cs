using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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