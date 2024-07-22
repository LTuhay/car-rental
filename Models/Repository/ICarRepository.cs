using Car_rental.Models.Domain;

namespace Car_rental.Models.Repository
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<IEnumerable<Car>> GetAvailableCarsAsync(DateTime startDate, DateTime endDate);

    }
}
