using Microsoft.EntityFrameworkCore;
using PeripheralStore.Models;  // <-- Make sure this matches your namespace

namespace PeripheralStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Peripheral> Peripherals { get; set; }
    }
}
