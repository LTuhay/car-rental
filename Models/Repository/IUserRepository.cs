using Car_rental.Models.Domain;

namespace Car_rental.Models.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAndPasswordAsync(string email, string password);

        Task<bool> ExistsEmailAsync(string email);

    }
}
