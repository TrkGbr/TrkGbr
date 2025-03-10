using Academy_2025.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy_2025.Respositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<User>> GetAllAsync()
        {
            return _context.Users.ToListAsync();
        }

        /*public async Task<List<User>> GetUsersOver18Async()
        {
            var nameQuery = await _context.Users.Where(user => user.Age > 18);

            return nameQuery.ToList();
        }*/

        public Task<User?> GetByIdAsync(int id)
        {
            return _context.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task CreateAsync(User data)
        {
            await _context.Users.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> UpdateAsync(int id, User data)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (user != null)
            {
                user.Name = data.Name;    //<---------Változás!
                user.Age = data.Age;
                user.Role = data.Role;    //<---------Role hozzáadás
                await _context.SaveChangesAsync();

                return user;
            }

            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
