using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Tasks> tasks { get; set; }
    }
   
}
