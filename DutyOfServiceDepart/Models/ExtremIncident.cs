using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DutyOfServiceDepart.Models
{
	public class ExtremIncident:LibraryModels.ExtremIncident
	{
		public SelectList Emps { get; set; }
	}
}