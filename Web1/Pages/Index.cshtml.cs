using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web1.Data;
using Web1.Models;

namespace Web1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Web1.Data.DataContext _context;

        public IndexModel(Web1.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Livre> Livre { get;set; }

        public async Task OnGetAsync()
        {
            Livre = await _context.Livres.ToListAsync();
        }
    }
}
