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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentsController(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<Department> departments = await _repository.GetAllDepartmentsAsync();
            if (departments != null)
            {
                return Ok(departments);
            }

            return NotFound();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            Department department = await _repository.GetDepartmentByIdAsync(id);

            if (department != null)
            {
                return Ok(department);
            }

            return NotFound();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Patch(int id, JsonPatchDocument<Department> document)
        {
            Department department = await _repository.GetDepartmentByIdAsync(id);

            if (department != null)
            {
                document.ApplyTo(department);
                await _repository.UpdateDepartmentAsync(department);
                return Ok(department);
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Post(DepartmentTargetBinding target)
        {
            if (target != null)
            {
                Department department = target.ToDepartment();

                await _repository.AddDepartmentAsync(department);

                return Ok(department);
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            Department department = await _repository.DeleteDepartmentAsync(id);
            if (department != null)
            {
                return Ok(department);
            }

            return NotFound();
        }
    }
}
