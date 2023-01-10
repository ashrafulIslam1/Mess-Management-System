using Mess_Management_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mess_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MemberList> Members { get; set; }
        public DbSet<DailyMeal> DailyMeals { get; set; }
        public DbSet<Bazar> Bazars { get; set; }
        public DbSet<MonthlyBazar> MonthlyBazars { get; set; }
        public DbSet<MonthlyBazarSetup> MonthlyBazarSetups { get; set; }
    }
}