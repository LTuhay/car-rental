using Car_rental.Models.Domain;

namespace Car_rental.Models.Repository
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        Task<IEnumerable<Reservation>> GetReservationByUserIdAsync(int userId);

    }
}
