using KarpaticaTravelAPI.Models.ActivityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Processors.ActivityProcessor
{
    public interface IActivityProcessor
    {
        Task<bool> UpdateActivity(Guid id, ActivityUpdateDTO activityToUpdate);
        Task<bool> DeleteActivity(Guid id);
        Task<bool> CreateActivity(ActivityDTO activity);
        Task<IEnumerable<ActivityDTO>> GetActivities();
        Task<ActivityDTO> GetActivity(Guid id);

    }
}
