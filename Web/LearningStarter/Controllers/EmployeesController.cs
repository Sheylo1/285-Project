using LearningStarter.Common;
using LearningStarter.Data;
using LearningStarter.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LearningStarter.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public EmployeesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new Response();

            var employees = _dataContext
                .Employees
                .Select(employee => new EmployeeGetDto
                {
                    Id = employee.Id,
                    Salary = employee.Salary,
                    UserId = employee.UserId,
                    PositionsId = employee.PositionsId,
                    Employed = employee.Employed
                })
                .ToList();

            response.Data = employees;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var response = new Response();

            var employeeToReturn = _dataContext
                .Employees
                .Select(employee => new EmployeeGetDto
                {
                    Id = employee.Id,
                    Salary = employee.Salary,
                    UserId = employee.UserId,
                    PositionsId = employee.PositionsId,
                    Employed = employee.Employed
                })
                .FirstOrDefault(employee => employee.Id == id);

            if(employeeToReturn == null)
            {
                response.AddError("id", "Employee not found.");
                return BadRequest(response);
            }

            response.Data = employeeToReturn;
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create([FromBody] EmployeeCreateDto employeeCreateDto)
        {
            var response = new Response();

            if (employeeCreateDto.Salary <= 0)
            {
                response.AddError("salary", "Salary cannot be negative.");
            }
            if (employeeCreateDto.UserId <= 0)
            {
                response.AddError("userid", "There must be a UserId.");
            }
            if(employeeCreateDto.PositionsId <= 0)
            {
                response.AddError("positionsid", "There must be a PositionsId");
            }


            if (response.HasErrors)
            {
                return BadRequest(response);
            }

            var employeeToAdd = new Employee
            {
                Salary = employeeCreateDto.Salary,
                UserId = employeeCreateDto.UserId,
                PositionsId = employeeCreateDto.PositionsId,
                Employed = employeeCreateDto.Employed
            };

            _dataContext.Employees.Add(employeeToAdd);
            _dataContext.SaveChanges();

            var employeeToReturn = new EmployeeGetDto
            {
                Id = employeeToAdd.Id,
                UserId = employeeToAdd.UserId,
                PositionsId = employeeToAdd.PositionsId,
                Salary = employeeToAdd.Salary,
                Employed = employeeToAdd.Employed
            };

            response.Data = employeeToReturn;
            return Created("", response);
        }

        [HttpPut("{id}")]

        public IActionResult Update(
            [FromRoute] int id,
            [FromBody] EmployeeUpdateDto employeeUpdateDto)
        {
            var response = new Response();

            var employeeToUpdate = _dataContext
                .Employees
                .FirstOrDefault(employee => employee.Id == id);

            if (employeeToUpdate == null)
            {
                response.AddError("id", "Employee not found");
            }

            if (employeeToUpdate.Salary <= 0)
            {
                response.AddError("salary", "Salary cannot be negative.");
            }
            if (employeeToUpdate.UserId <= 0)
            {
                response.AddError("userid", "There must be a UserId.");
            }

            if(employeeToUpdate.PositionsId <= 0)
            {
                response.AddError("positionsid", "There must be a PositionsId");
            }


            if (response.HasErrors)
            {
                return BadRequest(response);
            }

                employeeToUpdate.Salary = employeeUpdateDto.Salary;
                employeeToUpdate.UserId = employeeUpdateDto.UserId;
                employeeToUpdate.Employed = employeeUpdateDto.Employed;
            employeeToUpdate.PositionsId = employeeToUpdate.PositionsId;

            _dataContext.SaveChanges();

            var employeeToReturn = new EmployeeGetDto
            {
                Id = employeeToUpdate.Id,
                Salary = employeeToUpdate.Salary,
                UserId = employeeToUpdate.UserId,
                PositionsId = employeeToUpdate.PositionsId,
                Employed = employeeToUpdate.Employed

            };
            response.Data = employeeToReturn;
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var response = new Response();
            var employeeToDelete = _dataContext.Employees.FirstOrDefault(employee => employee.Id == id);
            if(employeeToDelete == null)
            {
                response.AddError("id", "Employee not found.");
                return NotFound(response);
            }
            _dataContext.Employees.Remove(employeeToDelete);
            _dataContext.SaveChanges();
            response.Data = true;
            return Ok(response);
        }
    }
}
