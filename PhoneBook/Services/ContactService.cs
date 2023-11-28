using PhoneBook.Controllers;
using PhoneBook.Models;
using Spectre.Console;
using System.Net.Http.Headers;

namespace PhoneBook.Services;

internal class ContactService
{
    static internal void InsertContact()
    {
        var contact = new Contact();

        contact.Name = AnsiConsole.Ask<string>("Contact's name:");

        do
        {
            contact.Email = AnsiConsole.Ask<string>("Contact's email:");
        } while (!Validation.IsValidEmail(contact.Email));

        do
        {
            contact.Phone = AnsiConsole.Ask<string>("Contact's phone:");
        } while (!Validation.IsValidPhone(contact.Phone));

        contact.CategoryId = CategoryService.GetCategoryOptionInput().CategoryId;

        ContactController.AddContact(contact);
    }

    static internal void UpdateContact()
    {
        var contact = GetContactOptionInput();

        contact.Name = AnsiConsole.Confirm("Update name?")
            ? contact.Name = AnsiConsole.Ask<string>("Contact's new name:")
            : contact.Name;

        if (AnsiConsole.Confirm("Update email?"))
        {
            do
            {
                contact.Email = AnsiConsole.Ask<string>("Contact's new email:");
            } while (!Validation.IsValidEmail(contact.Email));
        }

        if (AnsiConsole.Confirm("Update phone?"))
        {
            do
            {
                contact.Phone = AnsiConsole.Ask<string>("Contact's new phone:");
            } while (!Validation.IsValidPhone(contact.Phone));
        }

        contact.Category = AnsiConsole.Confirm("Update category?")
            ? CategoryService.GetCategoryOptionInput()
            : contact.Category;

        ContactController.UpdateContact(contact);
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
