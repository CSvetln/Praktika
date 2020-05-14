using System.Data.Entity;

namespace LibraryModels
{
	public class DutyContext: DbContext
	{
		public DbSet<Employee> Employees { get; set; }

		public DbSet<ExtremIncident> Incidents { get; set; }

		public DbSet<DutyList> DutyLists { get; set; }
	
		public DbSet<Access> Accesses { get; set; }
		
		public DbSet<Holidays> Holidays { get; set; }

		public DbSet<Vacation> Vacations { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employee>()
				.HasMany(p => p.DutyLists)
				.WithRequired(c => c.Employee)
				.HasForeignKey(c => c.EmployeeId)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<Employee>()
				.HasMany(p => p.Incidents)
				.WithRequired(c => c.Employee)
				.HasForeignKey(c => c.EmployeeEmployeId)
				.WillCascadeOnDelete(true);
		}
	}
}