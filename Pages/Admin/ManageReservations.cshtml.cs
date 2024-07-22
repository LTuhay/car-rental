using Car_rental.Models.Domain;
using Car_rental.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Car_rental.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class ManageReservationsModel : PageModel
    {
        private readonly IReservationService _reservationService;

        public ManageReservationsModel(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public IEnumerable<Reservation> Reservations { get; set; }

        public async Task OnGetAsync()
        {
            Reservations = await _reservationService.GetAllReservationsAsync();
        }
    }
}
