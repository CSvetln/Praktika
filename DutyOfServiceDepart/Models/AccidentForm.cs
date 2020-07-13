using System.Web.Mvc;
using DBModels;

namespace CalendarWebsite.Models
{
    public class AccidentForm
    {
        public AccidentWork Work { get; set; }

        public SelectList Employees { get; set; }
    }
}