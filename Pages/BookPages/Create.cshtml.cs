using Ignat_Teodora_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ignat_Teodora_Lab2.Pages.BookPages;

public class CreateModel : BookCategoriesPageModel
{
    private readonly Ignat_Teodora_Lab2Context _context;

    public CreateModel(Ignat_Teodora_Lab2Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
        ViewData["AuthorID"] = new SelectList(_context.Set<Authors>().Select(a => new { a.ID, FullName = a.FirstName + " " + a.LastName }), "ID", "FullName");

        var book = new Book();
        book.BookCategories = new List<BookCategory>();
        PopulateAssignedCategoryData(_context, book);

        return Page();
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
    {
        var newBook = new Book();
        newBook.BookCategories = new List<BookCategory>();

        if (selectedCategories != null)
        {
            foreach (var cat in selectedCategories)
            {
                newBook.BookCategories.Add(new BookCategory
                {
                    CategoryID = int.Parse(cat)
                });
            }
        }

        Book.BookCategories = newBook.BookCategories;

        _context.Book.Add(Book);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}