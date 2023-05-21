using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using OOP_Lab7.Data;

namespace OOP_Lab7.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Person Person { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var person = await _context.People.FindAsync(id);
            if(person == null)
            {
                return NotFound();
            }

            await _context.Entry(person).Collection(p => p.Taxes).LoadAsync();

            Person = person;
            return Page();
        }
    }
}
