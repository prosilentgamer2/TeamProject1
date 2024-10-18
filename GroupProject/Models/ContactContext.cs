using Microsoft.EntityFrameworkCore;

namespace GroupProject.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Family" },
                new Category { CategoryID = 2, Name = "Friend" },
                new Category { CategoryID = 3, Name = "Work" },
                new Category { CategoryID = 4, Name = "School" },
                new Category { CategoryID = 5, Name = "Social" },
                new Category { CategoryID = 6, Name = "Service Provider" },
                new Category { CategoryID = 7, Name = "Community" }
            );

            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactID = 1,
                    FirstName = "Huda",
                    LastName = "Judeh",
                    Phone = "605-555-1234",
                    Email = "huda.judeh@southeasttech.edu",
                    Organization = "Southeast Technial College",
                    CategoryID = 4
                },

                new Contact
                {
                    ContactID = 2,
                    FirstName = "Michael",
                    LastName = "Ducote",
                    Phone = "225-987-5555",
                    Email = "ducotemike@yahoo.com",
                    CategoryID = 2
                },

                new Contact
                {
                    ContactID = 3,
                    FirstName = "Thomas",
                    LastName = "Winker",
                    Phone = "605-555-6789",
                    Email = "tom.winker@winfieldcorp.com",
                    Organization = "Winfield Corporation",
                    CategoryID = 3
                },

                new Contact
                {
                    ContactID = 4,
                    FirstName = "Matt",
                    LastName = "Brandner",
                    Phone = "605-555-9876",
                    Email = "drmattb@siouxfallschiro.com",
                    Organization = "Sioux Falls Chiropractic",
                    CategoryID = 2
                },

                new Contact
                {
                    ContactID = 5,
                    FirstName = "Emma",
                    LastName = "Arends",
                    Phone = "320-456-7890",
                    Email = "arends.em@gmail.com",
                    CategoryID = 7
                }
            );
        }
    }
}
