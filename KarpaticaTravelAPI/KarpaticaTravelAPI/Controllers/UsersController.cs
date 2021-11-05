using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotesAPI.Controllers;
using KarpaticaTravelAPI.Models.UserModel;
using KarpaticaTravelAPI.Processors.UserProcessor;
using System.Net;
using KarpaticaTravelAPI.Models.Requests.User;
using FluentValidation;

namespace KarpaticaTravelAPI.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserProcessor _userProcessor;

        public UsersController(IUserProcessor userRepository)
        {
            _userProcessor = userRepository;
        }


        [ProducesResponseType(typeof(IEnumerable<UserDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            IEnumerable<UserDTO> result = await _userProcessor.GetUsers().ConfigureAwait(false);

            if (result == null)
            {
                return NotFound("No users found.");
            }

            return Ok(result);
        }

        [ProducesResponseType(typeof(UserDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAsync(GetUserRequest request)
        {
            try
            {
                GetUserRequestValidator rules = new GetUserRequestValidator();
                await rules.ValidateAndThrowAsync(request).ConfigureAwait(false);

                UserDTO result = await _userProcessor.GetUser(request.Id).ConfigureAwait(false);

                if (result == null)
                {
                    return NotFound("No user found.");
                }

                return Ok(result);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAsync(UpdateUserRequest request)
        {
            try
            {
                UpdateUserRequestValidator rules = new UpdateUserRequestValidator();
                await rules.ValidateAndThrowAsync(request).ConfigureAwait(false);

                if (!await _userProcessor.UpdateUser(request.Id, request.UserUpdateDTO).ConfigureAwait(false))
                {
                    return BadRequest();
                }

                return NoContent();
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> PostUserAsync(CreateUserRequest request)
        {
            try
            {
                CreateUserRequestValidator rules = new CreateUserRequestValidator();
                await rules.ValidateAndThrowAsync(request).ConfigureAwait(false);

                bool isCreated = await _userProcessor.CreateUser(request.UserDTO).ConfigureAwait(false);

                if (!isCreated)
                    return BadRequest(isCreated);

                return Ok(isCreated);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(DeleteUserRequest request)
        {
            try
            {
                DeleteUserRequestValidator rules = new DeleteUserRequestValidator();
                await rules.ValidateAndThrowAsync(request).ConfigureAwait(false);

                bool result = await _userProcessor.DeleteUser(request.Id).ConfigureAwait(false);

                if (!result)
                    return NotFound();

                return Ok(result);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}