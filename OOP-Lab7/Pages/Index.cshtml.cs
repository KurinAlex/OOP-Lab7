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
                People = await _context.People.ToListAsync();
            }
        }
    }
}