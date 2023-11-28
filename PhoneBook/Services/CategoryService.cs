using PhoneBook.Controllers;
using PhoneBook.Models;
using Spectre.Console;

namespace PhoneBook.Services;

internal class CategoryService
{
    static internal void InsertCategory()
    {
        var category = new Category();
        category.Name = AnsiConsole.Ask<string>("Category's name:");

        CategoryController.AddCategory(category);
    }

    static internal void UpdateCategory()
    {
        var category = GetCategoryOptionInput();

        category.Name = AnsiConsole.Ask<string>("Category's new name:");

        CategoryController.UpdateCategory(category);
    }

    static internal void DeleteCategory()
    {
        var category = GetCategoryOptionInput();
        CategoryController.DeleteCategory(category);
    }

    static internal void GetCategories()
    {
        var categories = CategoryController.GetCategories();
        UserInterface.ShowCategoryTable(categories);
    }

    static internal Category GetCategoryOptionInput()
    {
        var categories = CategoryController.GetCategories();
        var categoriesArray = categories.Select(c => c.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose a Category")
            .AddChoices(categoriesArray));
        var category = categories.Single(c => c.Name == option);

        return category;
    }
}
