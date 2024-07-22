using Car_rental.Models.Domain;
using Car_rental.Models.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Car_rental.Pages.Users
{
    public class ReservationHistoryModel : PageModel
    {
        private readonly IReservationService _reservationService;

        public ReservationHistoryModel(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public IEnumerable<Reservation> Reservations { get; set; }

        public async Task OnGetAsync()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                Reservations = new List<Reservation>();
                return;
            }

            Reservations = await _reservationService.GetReservationsByUserIdAsync(userId);

        }
    }
}
