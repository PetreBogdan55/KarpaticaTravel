using KarpaticaTravelAPI.Models;
using KarpaticaTravelAPI.Models.Dbcontext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        public KarpaticaDbContext _context;


        public UserRepository(KarpaticaDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            await _context.User.AddAsync(user).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return false;
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<User> GetUser(int id)
        {
            User user = await _context.User.FindAsync(id);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<bool> UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return false;
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.User.Any(e => e.Id == id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }
    }
}