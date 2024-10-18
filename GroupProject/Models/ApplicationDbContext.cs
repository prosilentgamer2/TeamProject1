using Microsoft.EntityFrameworkCore;

namespace GroupProject.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define your DbSets (tables) here, e.g.:
        public DbSet<Contact> Contacts { get; set; }
    }
}
