using Car_rental.Models.Domain;
using Car_rental.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Car_rental.Pages.Reservations
{
    [Authorize(Roles = "User")]
    public class ConfirmationModel : PageModel
    {
        private readonly IReservationService _reservationService;

        public ConfirmationModel(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public Reservation Reservation { get; set; }

        public async Task<IActionResult> OnGetAsync(int reservationId)
        {
            Reservation = await _reservationService.GetReservationByIdAsync(reservationId);

            if (Reservation == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
