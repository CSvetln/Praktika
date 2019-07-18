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
		public DateTime DateIncident { get; set; } //дата чп

		public int EmployeeId { get; set; }

		public virtual Employee Employee { get; set; }
		//кого вызвали туда

		public string DecsIncident { get; set; }//описание чп

		
	}
}