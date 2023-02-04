using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BarberApp.Models;
using BarberApp.Interfaces;
using BarberApp.Data;

namespace BarberApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICalendarService _calendarService;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ICalendarService calendarService, ApplicationDbContext context)
    {
        _logger = logger;
        _calendarService = calendarService;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // SEEDING
        
        // var programare = new Programare()
        // {
        //     Name = "John",
        //     Date = DateTime.Parse("5/2/2023 8:30"),
        // };

        // var programare1 = new Programare()
        // {
        //     Name = "Andrew",
        //     Date = DateTime.Parse("5/2/2023 9:30"),
        // };
        
        // var programare2 = new Programare()
        // {
        //     Name = "Max",
        //     Date = DateTime.Parse("5/2/2023 10:00"),
        // };

        // _context.Programari.Add(programare);
        // _context.Programari.Add(programare1);
        // _context.Programari.Add(programare2);
        // _context.SaveChanges();

        TimeSpanService timeSpanService = new TimeSpanService();
        var timeSpan = timeSpanService.GetTimeSpan(8,18, 30);

        YearModel Year = await _calendarService.GetYear(DateTime.Now.Year);

        HomeIndexViewModel viewModel = new HomeIndexViewModel();
        viewModel.Year = Year;
        viewModel.TimeSpans = timeSpan;

        for ( int i = DateTime.Now.Month - 2; i>=0; i-- )  
        {
            viewModel.MonthList.RemoveAt(i);
        }

        return View("Index", viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
