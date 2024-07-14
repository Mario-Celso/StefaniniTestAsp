using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StefaniniTestAsp.Data;
using StefaniniTestAsp.Models;

namespace StefaniniTestAsp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly ApplicationDbContext _context;

        public IList<Athlete> Athletes { get; set; }
        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync(int numberFilter, string nicknameFilter, string imcFilter)
        {
            IQueryable<Athlete> athletesQuery = _context.Athletes.AsQueryable();

            if (numberFilter > 0)
            {
                athletesQuery = athletesQuery.Where(a => a.ShirtNumber == numberFilter);
            }

            if (!string.IsNullOrEmpty(nicknameFilter))
            {
                athletesQuery = athletesQuery.Where(a => a.Nickname.Contains(nicknameFilter));
            }

            if (!string.IsNullOrEmpty(imcFilter))
            {
                var filteredAthletes = await athletesQuery.ToListAsync();

                Athletes = filteredAthletes.Where(a => a.IMCClassification == imcFilter).ToList();
            }
            else
            {
                Athletes = await athletesQuery.ToListAsync(); // Atribui apenas se imcFilter estiver vazio
            }
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            var athlete = await _context.Athletes.FindAsync(id);

            if (athlete == null)
            {
                return NotFound();
            }

            _context.Athletes.Remove(athlete);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
