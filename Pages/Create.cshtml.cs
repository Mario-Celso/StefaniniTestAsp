using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StefaniniTestAsp.Data;
using StefaniniTestAsp.Models;
using System;

namespace StefaniniTestAsp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Athlete Athlete { get; set; }

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Athletes.Add(Athlete);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
