using DBModels;
using PagedList;

namespace CalendarWebsite.Models
{
    public class EmployeeList
    {
        public string CurrentSort { get; set; }

        public string CurrentFilter { get; set; }

        public IPagedList<Employee> Employees { get; set; }
    }
}