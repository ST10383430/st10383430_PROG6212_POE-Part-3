using Microsoft.EntityFrameworkCore;
using st10383430_PROG6212_POE.Models;
using System.Security.Claims;

namespace st10383430_PROG6212_POE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Claim> Claims { get; set; }
    }
}
