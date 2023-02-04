using System.ComponentModel.DataAnnotations;

namespace BarberApp.Models
{
    public class MonthModel
    {
        public Months Month { get; set; }
        public List<int>? Days { get; set; }
    }
}