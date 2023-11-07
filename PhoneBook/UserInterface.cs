using Spectre.Console;

namespace PhoneBook;

static internal class UserInterface
{
    internal static void ShowContact(Contact contact)
    {
        var panel = new Panel(
            $"Id: {contact.Id} " +
            $"\nName: {contact.Name} " +
            $"\nEmail: {contact.Email} " +
            $"\nPhone: {contact.Phone}")
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

        foreach (var contact in contacts)
            table.AddRow(contact.Id.ToString(), contact.Name, contact.Email, contact.Phone);

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to go back to the Main Menu.");
        Console.ReadKey();
        Console.Clear();
    }
}
