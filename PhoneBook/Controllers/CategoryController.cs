using PhoneBook.Models;

namespace PhoneBook.Controllers;

internal class CategoryController
{
    static internal void AddCategory(Category category)
    {
        using var db = new ContactContext();
        db.Add(category);
        db.SaveChanges();
    }

    internal static void UpdateCategory(Category category)
    {
        using var db = new ContactContext();
        db.Update(category);
        db.SaveChanges();
    }

    static internal void DeleteCategory(Category category)
    {
        using var db = new ContactContext();
        db.Remove(category);
        db.SaveChanges();
    }

    static internal List<Category> GetCategories()
    {
        using var db = new ContactContext();
        var categories = db.Categories.ToList();
        return categories;
    }
}
