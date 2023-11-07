using Spectre.Console;

namespace PhoneBook;

internal class ContactService
{
    static internal void InsertContact()
    {
        var contact = new Contact();
        contact.Name = AnsiConsole.Ask<string>("Contact's name:");
        contact.Email = AnsiConsole.Ask<string>("Contact's email:");
        contact.Phone = AnsiConsole.Ask<string>("Contact's phone:");
        ContactController.AddContact(contact);
    }

    static internal void DeleteContact()
    {
        var contact = GetContactOptionInput();
        ContactController.DeleteContact(contact);
    }

    static internal void GetContacts()
    {
        var contacts = ContactController.GetContacts();
        UserInterface.ShowContactTable(contacts);
    }

    static internal void GetContact()
    {
        var contact = GetContactOptionInput();
        UserInterface.ShowContact(contact);
    }

    static internal void UpdateContact()
    {
        var contact = GetContactOptionInput();

        contact.Name = AnsiConsole.Confirm("Update name?")
            ? contact.Name = AnsiConsole.Ask<string>("Contact's new name:")
            : contact.Name;

        contact.Email = AnsiConsole.Confirm("Update email?")
            ? contact.Email = AnsiConsole.Ask<string>("Contact's new email:")
            : contact.Email;

        contact.Phone = AnsiConsole.Confirm("Update phone?")
            ? contact.Phone = AnsiConsole.Ask<string>("Contact's new phone:")
            : contact.Phone;

        ContactController.UpdateContact(contact);
    }

    static private Contact GetContactOptionInput()
    {
        var contacts = ContactController.GetContacts();
        var contactsArray = contacts.Select(c => c.Name + " - " + c.Email + " - " + c.Phone).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose a Contact")
            .AddChoices(contactsArray));
        var id = contacts.Single(c => c.Name + " - " + c.Email + " - " + c.Phone == option).Id;
        var contact = ContactController.GetContactById(id);

        return contact;
    }
}
