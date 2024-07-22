using Car_rental.Models.Domain;
using Car_rental.Models.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Car_rental.Pages.Account
{
    public class SignUpModel : PageModel
    {
        private readonly IUserService _userService;

        public SignUpModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "There was an error processing your request. Please check the form and try again.");
                return Page();
            }

            if (await _userService.ExistsEmailAsync(User.Email))
            {
                ModelState.AddModelError(string.Empty, "Email is already registered.");
                return Page();
            }

            await _userService.RegisterAsync(User);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, User.Email),
                new Claim(ClaimTypes.Role, User.Role.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToPage("/Account/RegisterSuccess");
        }
    }
}
