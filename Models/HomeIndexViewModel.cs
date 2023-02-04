using BarberApp.Models;
using BarberApp.Controllers;

namespace BarberApp.Models
{
    public class HomeIndexViewModel
    {

        public YearModel Year { get; set; }

        public List<string> MonthList = new List<string>()
        {
            Months.January.ToString(),
            Months.February.ToString(),
            Months.March.ToString(),
            Months.April.ToString(),
            Months.May.ToString(),
            Months.June.ToString(),
            Months.July.ToString(),
            Months.August.ToString(),
            Months.September.ToString(),
            Months.October.ToString(),
            Months.November.ToString(),
            Months.December.ToString(),
        };

        public List<string> TimeSpans { get; set; }
    }
}