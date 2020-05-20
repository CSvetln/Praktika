using System;
using System.Data.Entity;

namespace LibraryModels
{
	public class DutyDbInitializer : DropCreateDatabaseAlways<DutyContext>
	{
		protected override void Seed(DutyContext db)
		{
			//создание и добавление сущностей
	
			Employee e1 = new Employee("Дуров Андрей", "andreDyr@mail.ru", "Durov-ПК\\Durov");
			Employee e2 = new Employee("Одинцов Егор", "odintsov1986@mail.ru", "Odintsov-ПК\\Odintsov");
			Employee e3 = new Employee("Бойко Вячеслав", "slavab888@mail.ru", "Boyko-ПК\\Boyko");
			Employee e4 = new Employee("Борисов Антон", "borisov.av.75@mail.ru", "Borisov-ПК\\Borisov");
			Employee e5 = new Employee("Игнатович Сергей", "ignat55@mail.ru", "Ignatovich-ПК\\Ignatovich");
			Employee e6 = new Employee("Сорокина Света", "cveta2500@mail.ru", "Sveta-ПК\\Sveta");
			Employee e7 = new Employee("Васнецов Олег", "vasnetsov1998@mail.ru", "Vasnetsov-ПК\\Vasnetsov");
			Employee e8 = new Employee("Ерофеев Павел", "paveler@mail.ru", "Erofeev-ПК\\Erofeev");
			Employee e9 = new Employee("Никулин Вадим", "nicalek666@mail.ru", "Nikulin-ПК\\Nikulin");

			db.Employees.Add(e1);
			db.Employees.Add(e2);
			db.Employees.Add(e3);
			db.Employees.Add(e4);
			db.Employees.Add(e5);
			db.Employees.Add(e6);
			db.Employees.Add(e7);
			db.Employees.Add(e8);
			db.Employees.Add(e9);

			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 1), Employee = e1 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 2), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 3), Employee = e3 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 4), Employee = e4 });

			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 5), Employee = e5 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 6), Employee = e6 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 7), Employee = e7 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 8), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 9), Employee = e4 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 10), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 11), Employee = e1 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 12), Employee = e8 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 13), Employee = e9 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 14), Employee = e1 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 15), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 16), Employee = e3 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 17), Employee = e4 });

			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 18), Employee = e5 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 19), Employee = e6 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 20), Employee = e7 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 21), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 22), Employee = e4 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 23), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 24), Employee = e1 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 25), Employee = e8 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 26), Employee = e9 });

			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 27), Employee = e1 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 28), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 29), Employee = e3 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 30), Employee = e4 });

			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 31), Employee = e5 });

			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 1), Employee = e6 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 2), Employee = e7 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 5, 3), Employee = e2 });
			

			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 01), Employee = e1 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 02), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 03), Employee = e3 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 04), Employee = e4 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 05), Employee = e5 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 06), Employee = e6 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 07), Employee = e7 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 08), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 09), Employee = e4 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 10), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 11), Employee = e1 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 12), Employee = e8 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 13), Employee = e9 });

			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 14), Employee = e1 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 15), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 16), Employee = e3 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 17), Employee = e4 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 18), Employee = e5 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 19), Employee = e6 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 20), Employee = e7 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 21), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 22), Employee = e4 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 23), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 24), Employee = e1 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 25), Employee = e8 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 26), Employee = e9 });


			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 27), Employee = e1 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 28), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 29), Employee = e3 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 29), Employee = e4 });

			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 6, 30), Employee = e5 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 01), Employee = e6 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 02), Employee = e7 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 02), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 02), Employee = e4 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 03), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 04), Employee = e1 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 05), Employee = e8 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 05), Employee = e9 });

			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 06), Employee = e1 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 07), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 08), Employee = e3 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 09), Employee = e4 });

			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 10), Employee = e5 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 11), Employee = e6 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 12), Employee = e7 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 13), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 14), Employee = e4 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 15), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 16), Employee = e1 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 17), Employee = e8 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 18), Employee = e9 });

			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 19), Employee = e1 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 20), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 21), Employee = e3 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 22), Employee = e4 });

			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 23), Employee = e5 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 24), Employee = e6 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 25), Employee = e7 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 26), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 27), Employee = e4 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 28), Employee = e2 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 29), Employee = e1 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 30), Employee = e8 });
			db.DutyLists.Add(new DutyList() { DateDuty = new DateTime(2020, 7, 31), Employee = e9 });

			db.Vacations.Add(new Vacation(e1, new DateTime(2020, 1, 01), new DateTime(2020, 1, 30)));
			db.Vacations.Add(new Vacation(e2, new DateTime(2020, 2, 01), new DateTime(2020, 2, 20)));
			db.Vacations.Add(new Vacation(e3, new DateTime(2020, 3, 01), new DateTime(2020, 3, 25)));

			db.Vacations.Add(new Vacation(e4, new DateTime(2020, 1, 01), new DateTime(2020, 1, 30)));
			db.Vacations.Add(new Vacation(e5, new DateTime(2020, 2, 01), new DateTime(2020, 2, 20)));
			db.Vacations.Add(new Vacation(e6, new DateTime(2020, 3, 01), new DateTime(2020, 3, 25)));
			db.Vacations.Add(new Vacation(e7, new DateTime(2020, 4, 01), new DateTime(2020, 4, 30)));
	

			db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 01), e1, ""));
			db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 06), e2, ""));
			db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 13), e3, ""));
			db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 25), e4, ""));
			db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 14), e1, ""));
			db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 15), e2, ""));
			db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 18), e3, ""));
			db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 23), e4, ""));
			db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 2), e1, ""));
			db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 3), e2, ""));
			db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 4), e3, ""));
			db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 5), e4, ""));
			db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 7), e1, ""));
			db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 8), e2, ""));
			db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 9), e3, ""));
			db.Incidents.Add(new ExtremIncident(new DateTime(2019, 12, 10), e4, ""));

			db.Accesses.Add(new Access(e6.Login, true));

			base.Seed(db);
		}
	}
}