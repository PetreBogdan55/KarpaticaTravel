using KarpaticaTravelAPI.Models;
using KarpaticaTravelAPI.Models.UserModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        public KarpaticaTravelContext _context;


        public UserRepository(KarpaticaTravelContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            await _context.User.AddAsync(user).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return user;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return false;
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<User> GetUser(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            User user = await _context.User.FindAsync(id);

            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("email", "Email is null or empty.");
            }

            User user = await _context.User
                    .Where(b => b.Email == email).FirstOrDefaultAsync();

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<bool> UpdateUser(Guid id, User user)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

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