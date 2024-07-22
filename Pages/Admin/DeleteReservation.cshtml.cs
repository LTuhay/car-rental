using Car_rental.Models.Domain;
using Car_rental.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Car_rental.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class DeleteReservationModel : PageModel
    {
        private readonly IReservationService _reservationService;

        public DeleteReservationModel(IReservationService reservationService)
        {
            _reservationService = reservationService;
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
            if (Reservation == null)
            {
                return NotFound();
            }

            await _reservationService.DeleteReservationAsync(Reservation.ReservationId);
            return RedirectToPage("/Admin/ManageReservations");
        }
    }
}
