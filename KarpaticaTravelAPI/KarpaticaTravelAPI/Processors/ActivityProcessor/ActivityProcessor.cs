﻿using AutoMapper;
using KarpaticaTravelAPI.Models.ActivityModel;
using KarpaticaTravelAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Processors.ActivityProcessor
{
    public class ActivityProcessor : IActivityProcessor
    {
        private IMapper _mapper;
        private IActivityRepository _activityRepository;

        public ActivityProcessor(IActivityRepository repository, IMapper mapper)
        {
            _activityRepository = repository;
            _mapper = mapper;
        }

        public async Task<bool> CreateActivity(ActivityDTO activity)
        {
            try
            {
                Activity newAct = _mapper.Map<ActivityDTO, Activity>(activity);
                await _activityRepository.CreateActivity(newAct).ConfigureAwait(false);

                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public async Task<bool> DeleteActivity(int id)
        {
            try
            {
                return await _activityRepository.DeleteActivity(id).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public async Task<IEnumerable<ActivityDTO>> GetActivities()
        {
            IEnumerable<Activity> resList = await _activityRepository.GetActivities().ConfigureAwait(false);
            return new List<ActivityDTO>(_mapper.Map<IEnumerable<ActivityDTO>>(resList));
        }

        public async Task<ActivityDTO> GetActivity(int id)
        {
            Activity res = await _activityRepository.GetActivity(id).ConfigureAwait(false);
            return (_mapper.Map<Activity, ActivityDTO>(res));
        }

        public async Task<bool> UpdateActivity(int id, ActivityUpdateDTO activityToUpdate)
        {
            try
            {
                Activity newActivity = _mapper.Map<ActivityUpdateDTO, Activity>(activityToUpdate);
                newActivity.ActivityId = id;

                return await _activityRepository.UpdateActivity(id, newActivity).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }
    }
}
