using KarpaticaTravelAPI.Models.ActivityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Repositories
{
    public interface IActivityRepository
    {
        Task<bool> CreateActivity(Activity activity);
        Task<bool> UpdateActivity(int id, Activity activity);
        Task<bool> DeleteActivity(int id);
        Task<Activity> GetActivity(int id);
        Task<IEnumerable<Activity>> GetActivities();
    }
}
