using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using BarberApp.Data;
using BarberApp.Models;

namespace BarberApp.Controllers.Api
{
    [ApiController]
    [Route("api/{controller}")]
    public class ProgramariController : Controller
    {  
        private readonly ApplicationDbContext _context;
        public ProgramariController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Programare> GetProgramari()
        {
            return _context.Programari.ToList();
        }
        [HttpGet]
        [Route("test")]
        public string Test()
        {
            return "test";
        }

        [HttpGet]
        [Route("{id}")]
        public Programare GetProgramare(int id)
        {
            var programareInDb = _context.Programari.SingleOrDefault(m=>m.Id == id);
            if ( programareInDb != null )
            {
                return programareInDb;
            }

            return null;
        }

        [HttpGet]
        [Route("{Day}/{Month}/{Year}/{Hour}/{Minute}")]
        public bool CheckIfDateAvailable(int Day, int Month, int Year, int Hour, int Minute)
        {
            DateTime date = DateTime.Parse($"{Day}/{Month}/{Year} {Hour}:{Minute}");
            var programareInDb = _context.Programari.SingleOrDefault(m=>m.Date == date);
            if ( programareInDb == null )
                return true;

            return false;
        }

        
        [HttpDelete]
        [Route("{id}")]
        public void DeleteProgramare(int id)
        {
            var programareInDb = _context.Programari.SingleOrDefault(m=>m.Id == id);
            if ( programareInDb != null )
            {
                _context.Programari.Remove(programareInDb);
                _context.SaveChanges();
            }
        }


        [HttpPost]
        [Route("{Day}/{Month}/{Year}/{Hour}/{Minute}/{name}")]
        public void MakeAppointment(int Day, int Month, int Year, int Hour, int Minute, string name)
        {
            var programare = new Programare()
            {
                Name = name,
                Date = DateTime.Parse($"{Day}/{Month}/{Year} {Hour}:{Minute}")
            };

            _context.Programari.Add(programare);
            _context.SaveChanges();
        }
    }
}