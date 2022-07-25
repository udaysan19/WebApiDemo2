using Microsoft.EntityFrameworkCore;
using WebApiDemo2.Models;


namespace WebApiDemo2.Data
{
    public class PortDbContext : DbContext
    {
        public PortDbContext(DbContextOptions<PortDbContext> options) : base(options)
        { }

        public DbSet<Portslot> Portslots { get; set; }
        public DbSet<Portuser> Portusers { get; set; }
    }
}
