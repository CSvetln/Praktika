using System;
using System.Data.Entity;

namespace DutyOfServiceDepart.Models
{
	public class DutyDbInitializer : DropCreateDatabaseAlways<DutyContext>
	{
		protected override void Seed(DutyContext db)
		{
			Employee e1 = new Employee("Сорокина Светлана", "cveta2500@mail.ru", "Sveta-ПК\\Sveta");
			Employee e2 = new Employee("Иванов Пупкин", "cveta2500@mail.ru", "Ivan");
			Employee e3 = new Employee("Елизавета", "cveta2500@mail.ru", "Liza");
			Employee e4 = new Employee("Петров Пётр", "cveta2500@mail.ru", "Petr4896");

			db.Employees.Add(e1);
			db.Employees.Add(e2);
			db.Employees.Add(e3);
			db.Employees.Add(e4);

			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2019, 12, 01), Employee = e1, DecrDuty = " " });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2019, 12, 02), Employee = e2, DecrDuty = " " });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2019, 12, 03), Employee = e3, DecrDuty = " " });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2019, 12, 04), Employee = e4, DecrDuty = " " });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2019, 12, 05), Employee = e1, DecrDuty = " " });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2019, 12, 06), Employee = e2, DecrDuty = " " });

			db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 01), e1, ""));
			db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 06), e2, ""));
			db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 13), e3, ""));
			db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 25), e4, ""));

			db.Accesses.Add(new Access(e1.Login, true));
			db.Accesses.Add(new Access(e2.Login, false));
			db.Accesses.Add(new Access(e3.Login, false));
			db.Accesses.Add(new Access(e4.Login, false));


			db.Vacations.Add(new Vacation(e1, new DateTime(2019, 12, 01), new DateTime(2019, 12, 08)));
			db.Vacations.Add(new Vacation(e2, new DateTime(2019, 12, 08), new DateTime(2020, 01, 15)));
			db.Vacations.Add(new Vacation(e3, new DateTime(2019, 11, 22), new DateTime(2019, 12, 15)));
			db.Vacations.Add(new Vacation(e4, new DateTime(2019, 11, 22), new DateTime(2020, 01, 15)));


			base.Seed(db);
		}
	}
}