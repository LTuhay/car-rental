using Car_rental.Models.Domain;
using System.Diagnostics.Eventing.Reader;

namespace Car_rental.Models.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<User> AuthenticateAsync(string email, string password);

        Task RegisterAsync(User user);

        Task<bool> ExistsEmailAsync(string email);
    }
}
