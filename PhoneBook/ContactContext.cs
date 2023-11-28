using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;

namespace PhoneBook;

internal class ContactContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("database=phonebook;trusted_connection=true;TrustServerCertificate=True;");
}
