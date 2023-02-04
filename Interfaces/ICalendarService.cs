using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using BarberApp.Models;
using BarberApp.Controllers;
using BarberApp.Data;

namespace BarberApp.Interfaces
{
    public interface ICalendarService
    {
        Task<YearModel> GetYear(int year);
        Task<YearModel> GetUpcomingDates();
    }

    public class CalendarService : ICalendarService
    {
        private readonly HttpClient _httpClient;
        public CalendarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<YearModel> GetUpcomingDates()
        {
            var response = await _httpClient.GetAsync("http://localhost:5019/api/calendar");
            var body = await response.Content.ReadAsStringAsync();

            YearModel year = JsonConvert.DeserializeObject<YearModel>(body);

            return year;
        }

        public async Task<YearModel> GetYear(int year)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5019/api/calendar/{year}");
            var body = await response.Content.ReadAsStringAsync();

            YearModel Year = JsonConvert.DeserializeObject<YearModel>(body);

            return Year;
        }
    }
}