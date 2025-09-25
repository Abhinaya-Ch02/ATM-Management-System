using Microsoft.EntityFrameworkCore;
using ATMProject.Models;

namespace ATMProject.Data
{
    public class ATMDbContext : DbContext
    {
        public ATMDbContext(DbContextOptions<ATMDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<ATMMachine> ATMMachines { get; set; }
        public DbSet<ATMCard> ATMCards { get; set; }
    }
}
