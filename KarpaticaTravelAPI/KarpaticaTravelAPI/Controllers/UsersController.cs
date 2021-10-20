using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KarpaticaTravelAPI.Models;
using KarpaticaTravelAPI.Models.Dbcontext;
using NotesAPI.Controllers;
using KarpaticaTravelAPI.Repositories;

namespace KarpaticaTravelAPI.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/Users1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            IEnumerable<User> result = await _userRepository.GetUsers().ConfigureAwait(false);

            if (result == null)
            {
                return NotFound("No users found.");
            }

            return Ok(result);
        }

        // GET: api/Users1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            User result = await _userRepository.GetUser(id).ConfigureAwait(false);

            if (result == null)
            {
                return NotFound("No user found.");
            }

            return Ok(result);
        }

        // PUT: api/Users1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (!await _userRepository.UpdateUser(id, user).ConfigureAwait(false))
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Users1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            User userCreated = await _userRepository.CreateUser(user).ConfigureAwait(false);

            if (userCreated == null)
                return BadRequest(userCreated);

            return Ok(userCreated);
        }

        // DELETE: api/Users1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            bool result = await _userRepository.DeleteUser(id).ConfigureAwait(false);

            if (!result)
                return NotFound();

            return Ok(result);
        }
    }
}
