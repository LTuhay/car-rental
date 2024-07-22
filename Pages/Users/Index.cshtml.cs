using Car_rental.Models.Domain;
using Car_rental.Models.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Car_rental.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly ICarService _carService;

        public IndexModel(IUserService userService, ICarService carService)
        {
            _userService = userService;
            _carService = carService;
        }

        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return RedirectToPage("/Error");
            }

            User = await _userService.GetUserByIdAsync(userId);
            if (User == null)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }
    }
}
