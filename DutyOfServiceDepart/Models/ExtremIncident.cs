using System.Web.Mvc;

namespace DutyOfServiceDepart.Models
{
	public class ExtremIncident:LibraryModels.ExtremIncident
	{
		public SelectList Emps { get; set; }
	}
}