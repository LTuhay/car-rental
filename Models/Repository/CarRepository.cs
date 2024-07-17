using Car_rental.Models.Data;
using Car_rental.Models.Domain;

namespace Car_rental.Models.Repository
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(CarRentalContext context) : base(context) { }
    }
}
