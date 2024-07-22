using Car_rental.Models.Data;
using Car_rental.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Car_rental.Models.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(CarRentalContext context) : base(context) { }

        public async Task<User> GetByEmailAndPasswordAsync(string email, string password)
        {
            return await _dbSet.SingleOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<bool> ExistsEmailAsync (string email)
        {
            return await _dbSet.AnyAsync(u => u.Email == email);
        }
    }
}
