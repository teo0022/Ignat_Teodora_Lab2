using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignat_Teodora_Lab2.Models;

namespace Ignat_Teodora_Lab2.Pages.CategoryPages;

public class CreateModel : PageModel
{
    private readonly Ignat_Teodora_Lab2Context _context;

    public CreateModel(Ignat_Teodora_Lab2Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Category Category { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Set<Category>().Add(Category);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
