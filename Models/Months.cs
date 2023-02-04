namespace BarberApp.Models
{
    public enum Months
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

    public class MonthList
    {
        public List<Months> ListOfMonths = new List<Months>()
        {
            Months.January,
            Months.February,
            Months.March,
            Months.April,
            Months.May,
            Months.June,
            Months.July,
            Months.August,
            Months.September,
            Months.October,
            Months.November,
            Months.December
        };
    }
}