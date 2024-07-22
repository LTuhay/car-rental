using Car_rental.Models.Data;
using Car_rental.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Car_rental.Models.Repository
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(CarRentalContext context) : base(context) { }

        public async Task<IEnumerable<Reservation>> GetReservationByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }

    }
}
