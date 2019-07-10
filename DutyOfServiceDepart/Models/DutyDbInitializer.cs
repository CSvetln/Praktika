using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DutyOfServiceDepart.Models
{
	public class DutyDbInitializer : DropCreateDatabaseAlways<DutyContext>
	{
		protected override void Seed(DutyContext db)
		{
			
			Employee e = new Employee(){ Name="Сорокина Светлана", Email = "cveta2500@mail.ru", Login = "ffffff" };
			for (int i = 1; i < 10; i++)
			{
				db.Employees.Add(new Employee() { EmployeId = i,  Name = "Сорокина Светлана",  Email = "cveta2500@mail.ru", Login = "ffffff" });
			}
			db.Employees.Add(new Employee() { EmployeId = 11,  Name = "Иванов Иван",  Email = "cveta2500@mail.ru", Login = "ffffff" });
			
		    db.DutyLists.Add(new DutyList() { DutyId = 1, DateDuty = new DateTime(2019,07,01), Employee = e, DecrDuty = "55" });
			db.DutyLists.Add(new DutyList() { DutyId = 2, DateDuty = new DateTime(2019, 07, 02), Employee = e, DecrDuty = "55" });
			db.DutyLists.Add(new DutyList() { DutyId = 3, DateDuty = new DateTime(2019, 07, 03), Employee = e, DecrDuty = "55" });
			db.DutyLists.Add(new DutyList() { DutyId = 4, DateDuty = new DateTime(2019, 07, 05), Employee = e, DecrDuty = "55" });
			db.DutyLists.Add(new DutyList() { DutyId = 5, DateDuty = new DateTime(2019, 07, 07), Employee = e, DecrDuty = "55" });
			db.DutyLists.Add(new DutyList() { DutyId = 5, DateDuty = new DateTime(2019, 08, 07), Employee = e, DecrDuty = "55" });
			for (int i = 0; i < 10; i++)
			{
				db.Incidents.Add(new ExtremIncident() { StartIncident = DateTime.Now, FinishIncident = DateTime.Now.AddDays(1), Employee = e, DecsIncident = "", IncidentId = i });
			}
			db.Incidents.Add(new ExtremIncident() { StartIncident = new DateTime(2019,01,01), FinishIncident = DateTime.Now.AddDays(1), Employee = e, DecsIncident = "", IncidentId = 15 });
			db.Employees.Add(new Employee() { EmployeId = 21, Name = "Иванов Иван1", Email = "cveta2500@mail.ru", Login = "ffffff" });
			db.Employees.Add(new Employee() { EmployeId = 22, Name = "Иванов Иван2", Email = "cveta2500@mail.ru", Login = "ffffff" });
			db.Employees.Add(new Employee() { EmployeId = 23, Name = "Иванов Иван3", Email = "cveta2500@mail.ru", Login = "ffffff" });
			base.Seed(db);
		}
	}
}