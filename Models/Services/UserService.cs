using Car_rental.Models.Domain;
using Car_rental.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace Car_rental.Models.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _userRepository.GetByEmailAndPasswordAsync(email, password);
        }

        public async Task AddUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAndPasswordAsync(email, password);
            return user;
        }

        public async Task RegisterAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task<bool> ExistsEmailAsync(string email)
        {
            return await _userRepository.ExistsEmailAsync(email);
        }

    }

}
