using Car_rental.Models.Domain;
using Car_rental.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Car_rental.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class ManageCarsModel : PageModel
    {
        private readonly ICarService _carService;

        public ManageCarsModel(ICarService carService)
        {
            _carService = carService;
        }

        public IEnumerable<Car> Cars { get; set; }

        public async Task OnGetAsync()
        {
            Cars = await _carService.GetAllCarsAsync();
        }
    }
}
