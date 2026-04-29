using Microsoft.EntityFrameworkCore;
using PhoneBookAPI.Models;

namespace PhoneBookAPI.Data
{
    public class FirstAPIContex: DbContext
    {
        public FirstAPIContex(DbContextOptions<FirstAPIContex> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contact>().HasData(

                new Contact
                {
                    Id = 1,
                    Name = "Sarah",
                    Phone = "0763549335",
                    Email = "sarah@gmail.com"
                },
        new Contact
        {
            Id = 2,
            Name = "Mona",
            Phone = "0836594123",
            Email = "mona@gmail.com"
        },
        new Contact
        {
            Id = 3,
            Name = "Earl",
            Phone = "0725698756",
            Email = "earl@gmail.com"
        });
        }
        public DbSet<Contact> contacts { get; set; }
    }
}
