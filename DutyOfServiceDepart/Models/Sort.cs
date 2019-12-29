using LibraryModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DutyOfServiceDepart.Models
{
	public class Sort
	{
		public string CurrentSort { get; set; }

		public string CurrentFilter { get; set; }

		public IPagedList<Employee> Emps { get; set; }

	}
}