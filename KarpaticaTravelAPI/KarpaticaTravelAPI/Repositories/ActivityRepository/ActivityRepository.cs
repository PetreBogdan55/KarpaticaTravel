using KarpaticaTravelAPI.Models;
using KarpaticaTravelAPI.Models.ActivityModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Repositories.ActivityRepository
{
    public class ActivityRepository : IActivityRepository
    {
        private KarpaticaTravelContext _context;
        public ActivityRepository(KarpaticaTravelContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> CreateActivity(Activity activity)
        {
            try
            {
                await _context.Activity.AddAsync(activity).ConfigureAwait(false);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                return true;
            }
            catch (DbException dbException)
            {
                Console.WriteLine(dbException.Message);
                return false;
            }
        }

        public async Task<bool> DeleteActivity(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            try
            {
                var activity = await _context.Activity.FindAsync(id);

                if (activity is null)
                {
                    return false;
                }

                _context.Activity.Remove(activity);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                return true;
            }
            catch (DbException dbException)
            {
                Console.WriteLine(dbException.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Activity>> GetActivities()
        {
            return await _context.Activity.ToListAsync().ConfigureAwait(false);
        }

        public async Task<Activity> GetActivity(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            Activity activity = await _context.Activity.FindAsync(id).ConfigureAwait(false);
            return activity;
        }

        public async Task<bool> UpdateActivity(Guid id, Activity activity)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            if (id != activity.Id)
            {
                return false;
            }

            _context.Entry(activity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (DbUpdateConcurrencyException dbException)
            {
                if (!_context.Activity.Any(e => e.Id == id))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine(dbException.Message);
                    throw;
                }
            }
        }
    }
}
