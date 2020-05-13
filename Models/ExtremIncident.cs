using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryModels
{
	public class ExtremIncident
	{
		[Key]
		public int IncidentId { get; set; }

		[Required]
		public DateTime DateIncident { get; set; } //дата чп

		public int EmployeeId { get; set; }

		public virtual Employee Employee { get; set; } //кого вызвали туда

		public string DecsIncident { get; set; } //описание чп

		public ExtremIncident(DateTime dateIncident, Employee employee, string decsIncident)
		{
			this.DateIncident = dateIncident;
			this.Employee = employee;
			this.DecsIncident = decsIncident;
			this.EmployeeId = employee.EmployeId;
		}

		public ExtremIncident()
		{
		}

	}
}