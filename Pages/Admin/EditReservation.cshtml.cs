using Car_rental.Models.Domain;
using Car_rental.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Car_rental.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class EditReservationModel : PageModel
    {
        private readonly IReservationService _reservationService;
        private readonly ICarService _carService;
        private readonly IUserService _userService;

        public EditReservationModel(IReservationService reservationService, ICarService carService, IUserService userService)
        {
            _reservationService = reservationService;
            _carService = carService;
            _userService = userService;
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Reservation = await _reservationService.GetReservationByIdAsync(id);

            if (Reservation == null)
            {
                return NotFound();
            }


            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Reservation.Car = await _carService.GetCarByIdAsync(Reservation.CarId);
            Reservation.User = await _userService.GetUserByIdAsync(Reservation.UserId);

            if (Reservation.Car == null || Reservation.User == null)
            {
                return NotFound();
            }

            await _reservationService.UpdateReservationAsync(Reservation);
            return RedirectToPage("/Admin/ManageReservations");
        }
    }
}
