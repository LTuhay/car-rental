using Car_rental.Models.Domain;
using Car_rental.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Car_rental.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class EditCarModel : PageModel
    {
        private readonly ICarService _carService;

        public EditCarModel(ICarService carService)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Car.CarId <= 0)
            {
                ModelState.AddModelError(string.Empty, "Invalid car ID");
                return Page();
            }

            await _carService.UpdateCarAsync(Car);
            return RedirectToPage("/Admin/ManageCars");
        }
    }
}
