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
			db.Employees.Add(new Employee {FamName= "Сорокина", Name = "Светлана", SecName = "Вадимовна", Email = "cveta2500@mail.ru", Login="ffffff" });
			
			

			base.Seed(db);
		}
	}
}