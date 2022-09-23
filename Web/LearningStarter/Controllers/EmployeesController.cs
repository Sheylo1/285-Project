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
            dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new Response();

            var employees = _dataContext
                .Employees
                .Select(employee => new EmployeeGetDto
                {
                    PayRate = employee.PayRate,

                    Salary = employee.Salary,

                    Id = employee.Id,
                    UserId = employee.UserId,
                    Positions = employee.Positions,
                    Employed = employee.Employed
                })
                .ToList();

            return Ok(response);
        }
    }
}
