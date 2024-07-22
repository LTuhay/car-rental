using Car_rental.Models.Domain;
using Car_rental.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Car_rental.Pages.Reservations
{
    [Authorize(Roles = "User")]
    public class ReserveModel : PageModel
    {
        private readonly ICarService _carService;
        private readonly IReservationService _reservationService;

        public ReserveModel(ICarService carService, IReservationService reservationService)
        {
            _carService = carService;
            _reservationService = reservationService;
        }

        [BindProperty(SupportsGet = true)]
        public int CarId { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Car = await _carService.GetCarByIdAsync(CarId);
            if (Car == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return BadRequest("User not found");
            }

            var car = await _carService.GetCarByIdAsync(CarId);
            if (car == null)
            {
                return NotFound();
            }

            var reservation = new Reservation
            {
                UserId = userId,
                CarId = CarId,
                StartDate = StartDate,
                EndDate = EndDate
            };

            if (ModelState.IsValid)
            {
                await _reservationService.AddReservationAsync(reservation);

                return RedirectToPage("Confirmation", new { reservationId = reservation.ReservationId });
            }

            return Page();
        }
    }
}
