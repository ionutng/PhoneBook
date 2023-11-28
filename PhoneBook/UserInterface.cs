using PhoneBook.Models;
using PhoneBook.Services;
using Spectre.Console;
using static PhoneBook.Enums;

namespace PhoneBook;

static internal class UserInterface
{
    static internal void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptions>()
                .Title("What would you like to do?")
                .AddChoices(
                    MenuOptions.AddContact,
                    MenuOptions.UpdateContact,
                    MenuOptions.DeleteContact,
                    MenuOptions.ViewContacts,
                    MenuOptions.ViewContact,
                    MenuOptions.AddCategory,
                    MenuOptions.ViewCategories,
                    MenuOptions.DeleteCategory,
                    MenuOptions.UpdateCategory,
                    MenuOptions.Quit));

            switch (option)
            {
                case MenuOptions.AddContact:
                    ContactService.InsertContact();
                    break;
                case MenuOptions.UpdateContact:
                    ContactService.UpdateContact();
                    break;
                case MenuOptions.DeleteContact:
                    ContactService.DeleteContact();
                    break;
                case MenuOptions.ViewContacts:
                    ContactService.GetContacts();
                    break;
                case MenuOptions.ViewContact:
                    ContactService.GetContact();
                    break;
                case MenuOptions.AddCategory:
                    CategoryService.InsertCategory();
                    break;
                case MenuOptions.UpdateCategory: 
                    CategoryService.UpdateCategory();
                    break;
                case MenuOptions.DeleteCategory:
                    CategoryService.DeleteCategory();
                    break;
                case MenuOptions.ViewCategories:
                    CategoryService.GetCategories();
                    break;
                case MenuOptions.Quit:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    static internal void ShowContact(Contact contact)
    {
        var panel = new Panel(
            $"Id: {contact.Id} " +
            $"\nName: {contact.Name} " +
            $"\nEmail: {contact.Email} " +
            $"\nPhone: {contact.Phone}" +
            $"\nCategory: {contact.Category.Name}")
        {
            Header = new PanelHeader("Contact Info"),
            Padding = new Padding(2, 2, 2, 2)
        };

        AnsiConsole.Write(panel);

        Console.WriteLine("Press any key to go back to the Main Menu.");
        Console.ReadKey();
        Console.Clear();
    }

    static internal void ShowContactTable(List<Contact> contacts)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Email");
        table.AddColumn("Phone");
        table.AddColumn("Category");

        foreach (var contact in contacts)
            table.AddRow(contact.Id.ToString(), contact.Name, contact.Email, contact.Phone, contact.Category.Name);

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to go back to the Main Menu.");
        Console.ReadKey();
        Console.Clear();
    }

    static internal void ShowCategoryTable(List<Category> categories)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");

        foreach (var category in categories)
            table.AddRow(category.CategoryId.ToString(), category.Name);

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to go back to the Main Menu.");
        Console.ReadKey();
        Console.Clear();
    }
}
