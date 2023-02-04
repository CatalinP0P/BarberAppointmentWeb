using System.ComponentModel.DataAnnotations;

namespace BarberApp.Models
{
    public class Programare
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Name { get; set; }
    }
}