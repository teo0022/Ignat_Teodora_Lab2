using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignat_Teodora_Lab2.Models;

namespace Ignat_Teodora_Lab2.Pages.BookPages;

public class IndexModel : PageModel
{
    private readonly Ignat_Teodora_Lab2Context _context;

    public IndexModel(Ignat_Teodora_Lab2Context context)
    {
        _context = context;
    }

    public IList<Book> Book { get; set; } = default!;
    public BookData BookD { get; set; }
    public int BookID { get; set; }
    public int CategoryID { get; set; }

<<<<<<< HEAD
    public string TitleSort { get; set; }
    public string AuthorSort { get; set; }
    public string CurrentFilter { get; set; }

    public async Task OnGetAsync(string sortOrder, string searchString)
    {
        TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
        AuthorSort = sortOrder == "author" ? "author_desc" : "author";
        CurrentFilter = searchString;

        Book = await _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.Author)
=======
    public async Task OnGetAsync(int? id, int? categoryID)
    {
        BookD = new BookData();

        BookD.Books = await _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.Author)
            .Include(b => b.BookCategories)
                .ThenInclude(b => b.Category)
>>>>>>> Laborator3
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();

<<<<<<< HEAD
        if (!String.IsNullOrEmpty(searchString))
        {
            Book = Book.Where(s => s.Author.FirstName.Contains(searchString)
                                || s.Author.LastName.Contains(searchString)
                                || s.Title.Contains(searchString)).ToList();
        }

        switch (sortOrder)
        {
            case "title_desc":
                Book = Book.OrderByDescending(s => s.Title).ToList();
                break;
            case "author_desc":
                Book = Book.OrderByDescending(s => s.Author.FullName).ToList();
                break;
            case "author":
                Book = Book.OrderBy(s => s.Author.FullName).ToList();
                break;
            default:
                Book = Book.OrderBy(s => s.Title).ToList();
                break;
=======
        if (id != null)
        {
            BookID = id.Value;
            Book book = BookD.Books
                .Where(i => i.ID == id.Value).Single();
            BookD.Categories = book.BookCategories.Select(s => s.Category);
>>>>>>> Laborator3
        }
    }
}