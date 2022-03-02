using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web1.Data;
using Web1.Models;

namespace Web1.Pages.admin
{
    public class IndexModel : PageModel
    {
        private readonly Web1.Data.DataContext _context;

        public IndexModel(Web1.Data.DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPost(string username, string password, string ReturnUrl)
        {
            if (username == "admin")
            {
                List<Claim> claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };

                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.
                AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Redirect(ReturnUrl == null ? "/admin/Livres" : ReturnUrl);
            }
            return Page();
        }

        public IActionResult OnGet(string ReturnUrl)
        {

            if (User.Identity.IsAuthenticated == true)
            
            return Redirect(ReturnUrl == null ? "/admin/Livres" : ReturnUrl);
            else return Page();

          
    }
    }
    }

