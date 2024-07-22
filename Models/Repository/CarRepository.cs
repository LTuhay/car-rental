using Car_rental.Models.Data;
using Car_rental.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Car_rental.Models.Repository
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(CarRentalContext context) : base(context) { }

        public async Task<IEnumerable<Car>> GetAvailableCarsAsync(DateTime startDate, DateTime endDate)
        {
            var reservedCarIds = await _context.Reservations
                .Where(r => (r.StartDate < endDate && r.EndDate > startDate))
                .Select(r => r.CarId)
                .ToListAsync();

            return await _context.Cars
                .Where(car => !reservedCarIds.Contains(car.CarId))
                .ToListAsync();
        }
    }
}
