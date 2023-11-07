using PhoneBook;
using Spectre.Console;

bool endApp = false;

while (!endApp)
{
    var option = AnsiConsole.Prompt(
        new SelectionPrompt<MenuOptions>()
        .Title("What would you like to do?")
        .AddChoices(
            MenuOptions.AddContact,
            MenuOptions.UpdateContact,
            MenuOptions.DeleteContact,
            MenuOptions.ViewContacts,
            MenuOptions.ViewContact,
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
        case MenuOptions.Quit:
            Environment.Exit(0);
            break;
    }
}


enum MenuOptions {
    AddContact,
    UpdateContact,
    DeleteContact,
    ViewContacts,
    ViewContact,
    Quit
}