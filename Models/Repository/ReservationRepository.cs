using Car_rental.Models.Data;
using Car_rental.Models.Domain;

namespace Car_rental.Models.Repository
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(CarRentalContext context) : base(context) { }
    }
}
