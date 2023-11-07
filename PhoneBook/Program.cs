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
            MenuOptions.ViewContactById,
            MenuOptions.Quit));

    switch (option)
    {
        case MenuOptions.AddContact:
            ContactController.AddContact();
            break;
        case MenuOptions.UpdateContact:
            ContactController.UpdateContact();
            break;
        case MenuOptions.DeleteContact:
            ContactController.DeleteContact();
            break;
        case MenuOptions.ViewContacts:
            ContactController.GetContacts();
            break;
        case MenuOptions.ViewContactById:
            ContactController.GetContactById();
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
    ViewContactById,
    Quit
}