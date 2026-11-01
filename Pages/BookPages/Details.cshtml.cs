using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignat_Teodora_Lab2.Models;

namespace Ignat_Teodora_Lab2.Pages.BookPages;

public class DetailsModel : PageModel
{
    private readonly Ignat_Teodora_Lab2Context _context;
    public DetailsModel(Ignat_Teodora_Lab2Context context)
    {
        _context = context;
    }

    public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var book = await _context.Book
            .Include(b => b.Author)
            .Include(b => b.Publisher)
            .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
            .FirstOrDefaultAsync(m => m.ID == id);
        if (book is null)
        {
            return NotFound();
        }
        else
        {
            Book = book;
        }

        return Page();
    }
}