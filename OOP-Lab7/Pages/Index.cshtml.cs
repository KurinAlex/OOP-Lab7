using System.Text.Json;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using OOP_Lab7.Data;

namespace OOP_Lab7.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Person> People { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.People != null)
            {
                People = await _context.People.Include(p => p.Taxes).ToListAsync();
            }
        }

        public async Task<IActionResult> OnGetDownloadAsync(int? id)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            await _context.Entry(person).Collection(b => b.Taxes).LoadAsync();

            string json = JsonSerializer.Serialize(
                person.Taxes.Select(t => new { t.Name, t.Amount }),
                new JsonSerializerOptions() { WriteIndented = true });

            var bytes = System.Text.Encoding.UTF8.GetBytes(json);
            return File(bytes, "application/json", $"{person.Name}Taxes.json");
        }
    }
}