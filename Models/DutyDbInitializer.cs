using System;
using System.Data.Entity;

namespace LibraryModels
{
	public class DutyDbInitializer : DropCreateDatabaseAlways<DutyContext>
	{	
		//protected override void Seed(DutyContext db)
		//{
		//	Employee e1 = new Employee("Сорокина Светлана", "cveta2500@mail.ru", "Sveta-ПК\\Sveta");
		//	Employee e2 = new Employee("Иванов Пупкин", "cveta2500@mail.ru", "Ivan");
		//	Employee e3 = new Employee("Елизавета", "cveta2500@mail.ru", "Liza");
		//	Employee e4 = new Employee("Петров Пётр", "cveta2500@mail.ru", "Petr4896");

		//	db.Employees.Add(e1);
		//	db.Employees.Add(e2);
		//	db.Employees.Add(e3);
		//	db.Employees.Add(e4);

		//	db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2019, 12, 01), Employee = e1, DecrDuty = " " });
		//	db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2019, 12, 02), Employee = e2, DecrDuty = " " });
		//	db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2019, 12, 03), Employee = e3, DecrDuty = " " });
		//	db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2019, 12, 04), Employee = e4, DecrDuty = " " });
		//	db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2019, 12, 05), Employee = e1, DecrDuty = " " });
		//	db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2019, 12, 06), Employee = e2, DecrDuty = " " });

		//	db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 01), e1, ""));
		//	db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 06), e2, ""));
		//	db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 13), e3, ""));
		//	db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 25), e4, ""));
		//	db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 14), e1, ""));
		//	db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 15), e2, ""));
		//	db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 18), e3, ""));
		//	db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 23), e4, ""));
		//	db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 2), e1, ""));
		//	db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 3), e2, ""));
		//	db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 4), e3, ""));
		//	db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 5), e4, ""));
		//	db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 7), e1, ""));
		//	db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 8), e2, ""));
		//	db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 9), e3, ""));
		//	db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 10), e4, ""));

		//	db.Accesses.Add(new Access(e1.Login, true));
		//	db.Accesses.Add(new Access(e2.Login, false));

		//	db.Holidays.Add(new Holidays(new DateTime(2019, 12, 01)));
		//	db.Holidays.Add(new Holidays(new DateTime(2019, 12, 07)));
		//	db.Holidays.Add(new Holidays(new DateTime(2019, 12, 08)));
		//	db.Holidays.Add(new Holidays(new DateTime(2019, 12, 14)));
		//	db.Holidays.Add(new Holidays(new DateTime(2019, 12, 15)));

		//	db.Vacations.Add(new Vacation(e1, new DateTime(2019, 12, 01), new DateTime(2019, 12, 08)));

		//	base.Seed(db);
		//}
	}
}