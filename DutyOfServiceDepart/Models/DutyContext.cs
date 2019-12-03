using System.Data.Entity;

namespace DutyOfServiceDepart.Models
{
	public class DutyContext: DbContext
	{
		public DbSet<Employee> Employees { get; set; }

		public DbSet<ExtremIncident> Incidents { get; set; }

		public DbSet<DutyList> DutyLists { get; set; }
	
		public DbSet<Access> Accesses { get; set; }

	}
}