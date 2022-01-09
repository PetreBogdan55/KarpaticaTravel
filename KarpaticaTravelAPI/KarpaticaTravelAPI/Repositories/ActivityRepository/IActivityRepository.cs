using KarpaticaTravelAPI.Models.ActivityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Repositories.ActivityRepository
{
    public interface IActivityRepository
    {
        Task<bool> CreateActivity(Activity activity);
        Task<bool> UpdateActivity(Guid id, Activity activity);
        Task<bool> DeleteActivity(Guid id);
        Task<Activity> GetActivity(Guid id);
        Task<IEnumerable<Activity>> GetActivities();
    }
}
