using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignat_Teodora_Lab2.Models;

namespace Ignat_Teodora_Lab2.Pages.CategoryPages;

public class DeleteModel : PageModel
{
    private readonly Ignat_Teodora_Lab2Context _context;

    public DeleteModel(Ignat_Teodora_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Category Category { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var category = await _context.Set<Category>().FirstOrDefaultAsync(m => m.ID == id);
        if (category is null)
        {
            return NotFound();
        }
        else
        {
            Category = category;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var category = await _context.Set<Category>().FindAsync(id);
        if (category != null)
        {
            Category = category;
            _context.Set<Category>().Remove(Category);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
