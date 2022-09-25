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
                    PayRate = employee.PayRate,
                    Salary = employee.Salary,
                    UserId = employee.UserId,
                    Positions = employee.Positions,
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
                    PayRate = employee.PayRate,
                    Salary = employee.Salary,
                    UserId = employee.UserId,
                    Positions = employee.Positions,
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

            if (employeeCreateDto.PayRate <= 0)
            {
                response.AddError("payrate", "PayRate cannot be negative.");
            }
            if (employeeCreateDto.Salary <= 0)
            {
                response.AddError("salary", "Salary cannot be negative.");
            }
            if (employeeCreateDto.UserId <= 0)
            {
                response.AddError("userid", "There must be a UserId.");
            }

            if (employeeCreateDto.Positions == null || employeeCreateDto.Positions == "")
            {
                response.AddError("positions", "Positions may not be empty.");
            }


            if (response.HasErrors)
            {
                return BadRequest(response);
            }

            var employeeToAdd = new Employee
            {
                PayRate = employeeCreateDto.PayRate,
                Salary = employeeCreateDto.Salary,
                UserId = employeeCreateDto.UserId,
                Positions = employeeCreateDto.Positions,
                Employed = employeeCreateDto.Employed
            };

            _dataContext.Employees.Add(employeeToAdd);
            _dataContext.SaveChanges();

            var employeeToReturn = new EmployeeGetDto
            {
                Id = employeeToAdd.Id,
                UserId = employeeToAdd.UserId,
                Positions = employeeToAdd.Positions,
                Salary = employeeToAdd.Salary,
                PayRate = employeeToAdd.PayRate,
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
            if (employeeToUpdate.PayRate <= 0)
            {
                response.AddError("payrate", "PayRate cannot be negative.");
            }
            if (employeeToUpdate.Salary <= 0)
            {
                response.AddError("salary", "Salary cannot be negative.");
            }
            if (employeeToUpdate.UserId <= 0)
            {
                response.AddError("userid", "There must be a UserId.");
            }

            if (employeeToUpdate.Positions == null || employeeToUpdate.Positions == "")
            {
                response.AddError("positions", "Positions may not be empty.");
            }

            if (response.HasErrors)
            {
                return BadRequest(response);
            }

            employeeToUpdate.PayRate = employeeUpdateDto.PayRate;
                employeeToUpdate.Salary = employeeUpdateDto.Salary;
                employeeToUpdate.UserId = employeeUpdateDto.UserId;
                employeeToUpdate.Positions = employeeUpdateDto.Positions;
                employeeToUpdate.Employed = employeeUpdateDto.Employed;

            _dataContext.SaveChanges();

            var employeeToReturn = new EmployeeGetDto
            {
                Id = employeeToUpdate.Id,
                PayRate = employeeToUpdate.PayRate,
                Salary = employeeToUpdate.Salary,
                UserId = employeeToUpdate.UserId,
                Positions = employeeToUpdate.Positions,
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
