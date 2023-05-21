using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using OOP_Lab7.Data;

namespace OOP_Lab7.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Person Person { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.People == null || Person == null)
            {
                return Page();
            }

            var taxes = new List<Tax>()
            {
                new AbroadTransfersTax()
                {
                    Person = Person,
                },
                new GiftsTax()
                {
                    Person = Person,
                },
                new GoodsTax()
                {
                    Person = Person,
                },
                new JobTax()
                {
                    Person = Person,
                },
                new MilitaryTax()
                {
                    Person = Person,
                },
            };
            Person.Taxes = taxes;

            foreach (var tax in taxes)
            {
                tax.UpdateAmount();
            }

            _context.People.Add(Person);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
