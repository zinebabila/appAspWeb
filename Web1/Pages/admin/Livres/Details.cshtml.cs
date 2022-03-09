using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web1.Data;
using Web1.Models;
using Microsoft.AspNetCore.Authorization;

namespace Web1.Pages.admin.Livres
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly Web1.Data.DataContext _context;

        public DetailsModel(Web1.Data.DataContext context)
        {
            _context = context;
        }

        public Livre Livre { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Livre = await _context.Livres.FirstOrDefaultAsync(m => m.LivreID == id);

            if (Livre == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
