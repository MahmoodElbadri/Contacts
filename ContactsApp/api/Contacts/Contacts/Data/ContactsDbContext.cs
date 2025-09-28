using Contacts.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data;

public class ContactsDbContext(DbContextOptions<ContactsDbContext> options) : DbContext(options)
{
    public DbSet<Contact> Contacts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Contact>()
            .HasData(
            new Contact
            {
                Id = 1,
                Name = "John Doe",
                Email = "0oD8X@example.com",
                Favourite = true,
                Phone = "123-456-7890"
            },
            new Contact
            {
                Id = 2,
                Name = "Alice Smith",
                Email = "K7E4w@example.com",
                Favourite = false,
                Phone = "987-654-3210"
            },
            new Contact
            {
                Id = 3,
                Name = "Nana play",
                Email = "0oD8X@example.com",
                Favourite = true,
                Phone = "123-456-7890"
            },
            new Contact
            {
                Id = 4,
                Name = "Alicia Miller",
                Email = "K7E4w@example.com",
                Favourite = false,
                Phone = "987-654-3210"
            }
            );
    }
}
