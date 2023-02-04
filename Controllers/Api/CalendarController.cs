using Microsoft.AspNetCore;

using BarberApp.Models;
using BarberApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace BarberApp.Controllers.Api
{
    [ApiController]
    [Route("api/{controller}")]
    public class CalendarController : Controller
    {


        [HttpGet]
        [Route("monthIndex/{month}")]
        public int GetMonthIndex(string month)
        {
            if (month == "January")
                return 1;
            if (month == "February")
                return 2;
            if (month == "March")
                return 3;
            if (month == "April")
                return 4;
            if (month == "May")
                return 5;
            if (month == "June")
                return 6;
            if (month == "July")
                return 7;
            if (month == "August")
                return 8;
            if (month == "September")
                return 9;
            if (month == "October")
                return 10;
            if (month == "November")
                return 11;
            if (month == "December")
                return 12;

            return -1;
        }

        [HttpGet]
        public YearModel GetUpcommingDates()
        {
            YearModel yearModel = new YearModel();
            yearModel.Year = DateTime.Now.Year;
            yearModel.Months = new List<MonthModel>();

            MonthList monthList = new MonthList();

            DateTime dt = DateTime.Parse(DateTime.Now.ToShortDateString());
            for (var dt2 = dt; dt2 <= DateTime.Parse($"31/12/{dt.Year}"); dt2 = dt2.AddMonths(1))
            {
                var date = DateTime.Parse($"1/{dt2.Month}/{dt2.Year}");
                int month = date.Month;
                var date2 = date;
                MonthModel monthModel = new MonthModel();
                List<int> monthDays = new List<int>();

                while (date2.Month == month)
                {
                    monthDays.Add(date2.Day);
                    date2 = date2.AddDays(1);
                }

                monthModel.Days = monthDays;
                monthModel.Month = monthList.ListOfMonths[month - 1];
                yearModel.Months.Add(monthModel);
            }
            return yearModel;

        }

        [HttpGet]
        [Route("{year}")]
        public YearModel GetYear(int year)
        {
            MonthList monthList = new MonthList();

            YearModel model = new YearModel();
            model.Year = year;
            model.Months = new List<MonthModel>();

            DateTime dt = DateTime.Parse($"1/1/{year}");
            for (var dt2 = dt; dt2 <= DateTime.Parse($"31/12/{year}"); dt2 = dt2.AddMonths(1))
            {
                var date = DateTime.Parse($"1/{dt2.Month}/{dt2.Year}");
                int month = date.Month;
                var date2 = date;
                MonthModel monthModel = new MonthModel();
                List<int> monthDays = new List<int>();

                while (date2.Month == month)
                {
                    monthDays.Add(date2.Day);
                    date2 = date2.AddDays(1);
                }

                monthModel.Days = monthDays;
                monthModel.Month = monthList.ListOfMonths[month - 1];
                model.Months.Add(monthModel);
            }
            return model;
        }

        [HttpGet]
        [Route("{year}/{month}")]
        public List<int> GetUpcomingDaysOfMonth(int year, int month)
        {
            List<int> Days = new List<int>();
            DateTime dateStart = DateTime.Parse($"1/{month}/{year}");

            DateTime date = dateStart;
            while (date.Month == dateStart.Month)
            {
                if (date >= DateTime.Parse(DateTime.Now.ToShortDateString()))
                    Days.Add(date.Day);

                date = date.AddDays(1);
            }

            return Days;
        }
    }
}