using Car_rental.Models.Domain;
using Car_rental.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Car_rental.Pages
{
    public class IndexModel : PageModel
    {

        public async Task<IActionResult> OnGetAsync()
        {
            if (User.Identity.IsAuthenticated)
            {

                var roleClaim = User.FindFirst(ClaimTypes.Role)?.Value;

                if (roleClaim == "Admin")
                {
                    return RedirectToPage("/Admin/Index");
                }
                else if (roleClaim == "User")
                {
                    return RedirectToPage("/Users/Index");
                }
            }

            return Page();
        }

        public IActionResult OnPost(string action)
        {
            if (action == "SignIn")
            {
                return RedirectToPage("/Account/SignIn");
            }
            else if (action == "SignUp")
            {
                return RedirectToPage("/Account/SignUp");
            }

            return Page();
        }

    }
}
