using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;

namespace PhoneBook.Controllers;

internal class ContactController
{
    internal static void AddContact(Contact contact)
    {
        using var db = new ContactContext();
        db.Add(contact);
        db.SaveChanges();
    }

    internal static void UpdateContact(Contact contact)
    {
        using var db = new ContactContext();
        db.Update(contact);
        db.SaveChanges();
    }

    internal static void DeleteContact(Contact contact)
    {
        using var db = new ContactContext();
        db.Remove(contact);
        db.SaveChanges();
    }

    internal static List<Contact> GetContacts()
    {
        using var db = new ContactContext();
        var contacts = db.Contacts.Include(c => c.Category).ToList();
        return contacts;
    }

    internal static Contact GetContactById(int id)
    {
        using var db = new ContactContext();
        var contact = db.Contacts.Include(c => c.Category).SingleOrDefault(c => c.Id == id);
        return contact;
    }
}
