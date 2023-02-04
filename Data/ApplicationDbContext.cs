using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BarberApp.Models;

namespace BarberApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Programare> Programari { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
