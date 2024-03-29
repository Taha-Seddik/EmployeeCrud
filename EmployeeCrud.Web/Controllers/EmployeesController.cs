﻿using EmployeeCrud.Domain;
using EmployeeCrud.Web.Models.DTO;
using EmployeeCrud.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCrud.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public IEmployeeService _employeeService { get; }

        public EmployeesController(IEmployeeService employeeService) : base()
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var foundList = await _employeeService.GetAll(cancellationToken);
            return Ok(foundList);
        }

        [HttpGet, Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var emp = await _employeeService.Get(id, cancellationToken);
            if (emp == null) return BadRequest("Employee not found");
            return Ok(emp);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] EmployeeDTO newEmp, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Employee creation failed");
            }
            var emp = await _employeeService.Create(newEmp, cancellationToken);
            if (emp == null) return BadRequest("Employee creation failed");
            return Ok(emp);
        }

        [HttpPut, Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Employee updatedEmp,  CancellationToken cancellationToken = default)
        {
            var isOk = await _employeeService.Update(id, updatedEmp , cancellationToken);
            return isOk ? Ok(id) : BadRequest("Employee update failed");
        }

        [HttpDelete, Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var isOk = await _employeeService.Delete(id,cancellationToken);
            return isOk ? Ok(id) : BadRequest("Employee deletion failed");
        }
    }
}
