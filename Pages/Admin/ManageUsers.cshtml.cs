using Car_rental.Models.Domain;
using Car_rental.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Car_rental.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class ManageUsersModel : PageModel
    {
        private readonly IUserService _userService;

        public ManageUsersModel(IUserService userService)
        {
            _userService = userService;
        }

        public IEnumerable<User> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _userService.GetAllUsersAsync();
        }
    }
}
