namespace BarberApp.Models
{
    public class YearModel
    {
        public int Year { get; set; }
        public List<MonthModel>? Months { get; set; }
    }
}