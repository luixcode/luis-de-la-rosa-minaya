using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Form.API.Repository;
using Form.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Form.API.Models.TargetBinding;

namespace Form.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<User> users = await _repository.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            User user = await _repository.GetUserByIdAsync(id);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Patch(int id, JsonPatchDocument<User> document)
        {
            User user = await _repository.GetUserByIdAsync(id);

            if (user != null)
            {
                document.ApplyTo(user);
                await _repository.UpdateUserAsync(user);
                return Ok(user);
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(UserTargetBinding target)
        {            
            Department department = await _repository.GetDepartmentByIdAsync(target.DepartmentId);

            if (department != null)
            {
                User user = target.ToUser();

                await _repository.AddUserAsync(user);

                return Ok(user);
            }

            return BadRequest("Invalid department id.");
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            User user = await _repository.DeleteUserAsync(id);
            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }
    }
}
