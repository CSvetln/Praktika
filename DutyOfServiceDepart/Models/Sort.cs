using LibraryModels;
using PagedList;

namespace DutyOfServiceDepart.Models
{
	public class Sort
	{
		public string CurrentSort { get; set; }

		public string CurrentFilter { get; set; }

		public IPagedList<Employee> Emps { get; set; }
	}
}