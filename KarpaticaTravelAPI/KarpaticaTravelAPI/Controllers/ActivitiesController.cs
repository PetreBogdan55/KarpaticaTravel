
using KarpaticaTravelAPI.Models.ActivityModel;
using KarpaticaTravelAPI.Processors.ActivityProcessor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Controllers
{
    public class ActivitiesController : BaseController
    {
        private readonly IActivityProcessor _activityProcessor;

        public ActivitiesController(IActivityProcessor processor)
        {
            _activityProcessor = processor;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetActivitiesAsync()
        {
            var actList = await _activityProcessor.GetActivities().ConfigureAwait(false);

            if (!actList.Any())
            {
                return NotFound("There were no activities in the database");
            }

            return Ok(actList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetActivityAsync(Guid id)
        {
           /* if (id < 0)
            {
                return BadRequest("Invalid id");
            }*/

            var activity = await _activityProcessor.GetActivity(id).ConfigureAwait(false);

            if (activity is null)
            {
                return NotFound("Activity could not be found");
            }

            return Ok(activity);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PostActivityAsync([FromBody] ActivityDTO activityToPost)
        {
           /* if (string.IsNullOrWhiteSpace(activityToPost.Name) || activityToPost.Id < 0)
            {
                return BadRequest("Invalid parameters for activity creation");
            }*/

            bool res = await _activityProcessor.CreateActivity(activityToPost).ConfigureAwait(false);

            if (!res)
            {
                return NotFound("Activity could not be created");
            }

            return Ok("Activity created successfully");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutActivityAsync(Guid id, [FromBody] ActivityUpdateDTO updateActivity)
        {
            if (string.IsNullOrWhiteSpace(updateActivity.Name))
            {
                return BadRequest("Invalid parameters for activty update");
            }

            bool res = await _activityProcessor.UpdateActivity(id, updateActivity).ConfigureAwait(false);

            if (!res)
            {
                return NotFound("Unable to update activity");
            }

            return Ok($"Activity with id {id} updated successfully");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteActivityAsync(Guid id)
        {
            /*if (id < 0)
            {
                return BadRequest("Invalid parameter for activity deletion");
            }*/

            bool res = await _activityProcessor.DeleteActivity(id).ConfigureAwait(false);

            if (!res)
            {
                return NotFound("Unable to delete activity");
            }

            return Ok($"Activity {id} deleted successfully");
        }
    }
}
