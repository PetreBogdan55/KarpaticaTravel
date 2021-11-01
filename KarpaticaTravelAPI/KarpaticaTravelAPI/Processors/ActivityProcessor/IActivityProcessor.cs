using KarpaticaTravelAPI.Models.ActivityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Processors.ActivityProcessor
{
    public interface IActivityProcessor
    {
        Task<bool> UpdateActivity(int id, ActivityUpdateDTO activityToUpdate);
        Task<bool> DeleteActivity(int id);
        Task<bool> CreateActivity(ActivityDTO activity);
        Task<IEnumerable<ActivityDTO>> GetActivities();
        Task<ActivityDTO> GetActivity(int id);

    }
}
