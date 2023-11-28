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
                new SelectionPrompt<MainMenuOptions>()
                .Title("What would you like to do?")
                .AddChoices(
                    MainMenuOptions.ManageContacts,
                    MainMenuOptions.ManageCategories,
                    MainMenuOptions.Quit));

            switch (option)
            {
                case MainMenuOptions.ManageContacts:
                    ContactsMenu();
                    break;
                case MainMenuOptions.ManageCategories:
                    CategoriesMenu();
                    break;
                case MainMenuOptions.Quit:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    static internal void ContactsMenu()
    {
        bool isContactsMenuRunning = true;
        while (isContactsMenuRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<ContactMenu>()
                .Title("Contacts Menu")
                .AddChoices(
                    ContactMenu.AddContact,
                    ContactMenu.UpdateContact,
                    ContactMenu.DeleteContact,
                    ContactMenu.ViewContacts,
                    ContactMenu.ViewContact,
                    ContactMenu.Back));

            switch (option)
            {
                case ContactMenu.AddContact:
                    ContactService.InsertContact();
                    break;
                case ContactMenu.UpdateContact:
                    ContactService.UpdateContact();
                    break;
                case ContactMenu.DeleteContact:
                    ContactService.DeleteContact();
                    break;
                case ContactMenu.ViewContacts:
                    ContactService.GetContacts();
                    break;
                case ContactMenu.ViewContact:
                    ContactService.GetContact();
                    break;
                case ContactMenu.Back:
                    isContactsMenuRunning = false;
                    break;
            }
        }
    }

    static internal void CategoriesMenu()
    {
        bool isCategoriesMenuRunning = true;
        while (isCategoriesMenuRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<CategoryMenu>()
                .Title("Categories Menu")
                .AddChoices(
                    CategoryMenu.AddCategory,
                    CategoryMenu.UpdateCategory,
                    CategoryMenu.DeleteCategory,
                    CategoryMenu.ViewCategories,
                    CategoryMenu.ViewCategory,
                    CategoryMenu.Back));

            switch (option)
            {
                case CategoryMenu.AddCategory:
                    CategoryService.InsertCategory();
                    break;
                case CategoryMenu.UpdateCategory:
                    CategoryService.UpdateCategory();
                    break;
                case CategoryMenu.DeleteCategory:
                    CategoryService.DeleteCategory();
                    break;
                case CategoryMenu.ViewCategories:
                    CategoryService.GetCategories();
                    break;
                case CategoryMenu.ViewCategory:
                    CategoryService.GetCategory();
                    break;
                case CategoryMenu.Back:
                    isCategoriesMenuRunning = false;
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

    internal static void ShowCategory(Category category)
    {
        var panel = new Panel(
            $"Id: {category.CategoryId} " +
            $"\nName: {category.Name} " +
            $"\nContact Count: {category.Contacts.Count}")
        {
            Header = new PanelHeader("Category Info"),
            Padding = new Padding(2, 2, 2, 2)
        };

        AnsiConsole.Write(panel);

        ShowContactTable(category.Contacts);

        Console.WriteLine("Press any key to go back to the Main Menu.");
        Console.ReadKey();
        Console.Clear();
    }
}
