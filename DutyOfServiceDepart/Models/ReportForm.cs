using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBModels;

namespace CalendarWebsite.Models
{
    public class ReportForm
    {
        public IEnumerable<Employee> Employees { get; set; }

        public Int32 EmployeeId { get; set; }

        public DateTime ReportMonth { get; set; }
    }
}