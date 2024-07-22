using Car_rental.Models.Domain;
using Car_rental.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Car_rental.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class DeleteCarModel : PageModel
    {
        private readonly ICarService _carService;

        public DeleteCarModel(ICarService carService)
        {
            _carService = carService;
        }

        [BindProperty]
        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Car = await _carService.GetCarByIdAsync(id);
            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _carService.DeleteCarAsync(Car.CarId);
            return RedirectToPage("/Admin/ManageCars");
        }
    }
}
