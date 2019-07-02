using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DutyOfServiceDepart.Models
{
	public class DutyContext : DbContext
	{
		public DbSet<Employee> Employees { get; set; }
		public DbSet<ExtremIncident> Incedents { get; set; }
		public DbSet<DutyList> DutyLists { get; set; }
	}
}