using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DutyOfServiceDepart.Models
{
	public class ExtremIncident
	{
		[Key]
		public int IncidentId { get; set; }
		[Required]
		public DateTime StartIncident { get; set; } //начало чп
		[Required]
		public DateTime FinishIncident { get; set; } //конец чп
		[Required]
		public Employee Employee { get; set; } //кого вызвали туда
				
		public string DecsIncident { get; set; }//описание чп
		
	}
}