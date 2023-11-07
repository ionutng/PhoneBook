using Microsoft.EntityFrameworkCore;

namespace PhoneBook;

internal class ContactContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("database=phonebook;trusted_connection=true;TrustServerCertificate=True;");
}

class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}
