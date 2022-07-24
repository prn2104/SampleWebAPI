    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Models;
using SampleWebAPI.Repository;

namespace SampleWebAPI.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository<Employee> _employeeRepository;

        public EmployeeController(IEmployeeRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: api/Employee/
        // GET: api/Employee?OrderbyDesc=true
        [HttpGet]
        public IActionResult Get(bool OrderbyDesc = false)
        {
            //************interceptor example ***********************
            IEnumerable<Employee> employees = _employeeRepository.GetAll(OrderbyDesc);
            return Ok(employees);
        }

        // GET: api/Employee/1
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Employee employee = _employeeRepository.Get(id);

            if (employee == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null.");
            }

            _employeeRepository.Add(employee);
            return CreatedAtRoute(
                  "Get",
                  new { Id = employee.EmployeeId },
                  employee);
        }

        // PUT: api/Employee/2
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null.");
            }

            Employee employeeToUpdate = _employeeRepository.Get(id);
            if (employeeToUpdate == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            _employeeRepository.Update(employeeToUpdate, employee);
            return NoContent();
        }

        // DELETE: api/Employee/2
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Employee employee = _employeeRepository.Get(id);
            if (employee == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            _employeeRepository.Delete(employee);
            return NoContent();
        }
    }
}
