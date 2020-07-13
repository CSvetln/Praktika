using System.Data.Entity;

namespace DBModels
{
	public class DutyContext: DbContext
	{
		public DbSet<Employee> Employees { get; set; }

		public DbSet<AccidentWork> AccidentWorks { get; set; }

		public DbSet<Duty> Duties { get; set; }
	
		public DbSet<User> Users { get; set; }
		
		public DbSet<Holiday> Holidays { get; set; }

		public DbSet<Vacation> Vacations { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employee>()
				.HasMany(p => p.DutyLists)
				.WithRequired(c => c.Employee)
				.HasForeignKey(c => c.EmployeeId)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<Employee>()
				.HasMany(p => p.AccidentWorks)
				.WithRequired(c => c.Employee)
				.HasForeignKey(c => c.EmployeeId)
				.WillCascadeOnDelete(true);
		}
	}
}