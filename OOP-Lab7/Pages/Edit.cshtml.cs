using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using OOP_Lab7.Data;

namespace OOP_Lab7.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Person Person { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            Person = person;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Person person)
        {
            _context.People.Attach(person).State = EntityState.Modified;
            await _context.Entry(person).Collection(p => p.Taxes).LoadAsync();
            foreach (var tax in person.Taxes)
            {
                tax.UpdateAmount();
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
