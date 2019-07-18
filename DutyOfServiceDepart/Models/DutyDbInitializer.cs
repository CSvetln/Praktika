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
			db.Employees.Add(new Employee() { Name = "Иванов Иван", Email = "ivan@mail.ru", Login = "Ivan4896" });
			db.Employees.Add(new Employee() { Name = "Петров Пётр", Email = "petr@mail.ru", Login = "Petr4896" });
			db.Employees.Add(new Employee() { Name = "Татьяна", Email = "tanya@mail.ru", Login = "Tanya4896" });

			Employee e = new Employee() { Name = "Сорокина Светлана", Email = "cveta2500@mail.ru", Login = "Sveta" };

			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2019, 07, 01), Employee = e, DecrDuty = " " });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2019, 07, 02), Employee = e, DecrDuty = " " });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2019, 07, 03), Employee = e, DecrDuty = " " });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2019, 07, 05), Employee = e, DecrDuty = " " });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2019, 07, 07), Employee = e, DecrDuty = " " });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2019, 08, 07), Employee = e, DecrDuty = " " });

			db.Incidents.Add(new ExtremIncident() { DateIncident = new DateTime(2019, 01, 01), Employee = e, DecsIncident = "", EmployeeId=e.EmployeId});
			db.Incidents.Add(new ExtremIncident() { DateIncident = new DateTime(2019, 01, 02), Employee = e, DecsIncident = "", EmployeeId = e.EmployeId });
			db.Incidents.Add(new ExtremIncident() { DateIncident = new DateTime(2019, 01, 03), Employee = e, DecsIncident = "", EmployeeId = e.EmployeId });

			db.Accesses.Add(new Access() { Login = "Petr4896", AllowedEdit = false });
			db.Accesses.Add(new Access() { Login = "Ivan4896", AllowedEdit = true });
			
			db.Accesses.Add(new Access() { Login = "Sveta-ПК\\Sveta", AllowedEdit = true });
			base.Seed(db);
		}
	}
}