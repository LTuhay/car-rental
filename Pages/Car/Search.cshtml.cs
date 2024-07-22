using Car_rental.Models.Domain;
using Car_rental.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Car_rental.Pages.Cars
{
    public class SearchModel : PageModel
    {
        private readonly ICarService _carService;

        public SearchModel(ICarService carService)
        {
            _carService = carService;
        }

        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; }
        public IEnumerable<Car> Cars { get; set; }

        public async Task OnGetAsync()
        {
            if (StartDate != default(DateTime) && EndDate != default(DateTime))
            {
                Cars = await _carService.GetAvailableCarsAsync(StartDate, EndDate);
            }
        }
    }
}
