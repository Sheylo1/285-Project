using LearningStarter.Common;
using LearningStarter.Data;
using LearningStarter.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LearningStarter.Controllers
{
    [ApiController]
    [Route("api/positions")]
    public class PositionsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public PositionsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new Response();

            var positions = _dataContext
                .Positions
                .Select(position => new PositionGetDto
                {
                    Id = position.Id,
                     Name= position.Name,
                     Salary= position.Salary,
                  
                })
                .ToList();

            response.Data = positions;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var response = new Response();

            var positionToReturn = _dataContext
                .Positions
                .Select(position => new PositionGetDto
                {
                    Id = position.Id,
                    Salary = position.Salary,
                    Name = position.Name,
              
                })
                .FirstOrDefault(employee => employee.Id == id);

            if (positionToReturn == null)
            {
                response.AddError("id", "position not found.");
                return BadRequest(response);
            }

            response.Data = positionToReturn;
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PositionCreateDto positionCreateDto)
        {
            var response = new Response();

            if (positionCreateDto.Salary <= 0)
            {
                response.AddError("salary", "Salary cannot be negative.");
            }


            if (response.HasErrors)
            {
                return BadRequest(response);
            }

            var positonToAdd = new Position
            {
                Salary = positionCreateDto.Salary,
                Name = positionCreateDto.Name,
                
            };

            _dataContext.Positions.Add(positonToAdd);
            _dataContext.SaveChanges();

            var positionToReturn = new PositionGetDto
            {
                Id = positonToAdd.Id,
                Name = positonToAdd.Name,
                Salary = positonToAdd.Salary,
              
            };

            response.Data = positionToReturn;
            return Created("", response);
        }

        [HttpPut("{id}")]

        public IActionResult Update(
            [FromRoute] int id,
            [FromBody] PositionUpdateDto positionUpdateDto)
        {
            var response = new Response();

            var positionToUpdate = _dataContext
                .Positions
                .FirstOrDefault(position => position.Id == id);

            if (positionToUpdate == null)
            {
                response.AddError("id", "Employee not found");
            }

            if (positionToUpdate.Salary <= 0)
            {
                response.AddError("salary", "Salary cannot be negative.");
            }
           


            if (response.HasErrors)
            {
                return BadRequest(response);
            }

            positionToUpdate.Salary = positionUpdateDto.Salary;
            positionToUpdate.Name = positionUpdateDto.Name;
           

            _dataContext.SaveChanges();

            var positonToReturn = new PositionGetDto
            {
                Id = positionToUpdate.Id,
                Salary = positionToUpdate.Salary,
                Name = positionToUpdate.Name,
               

            };
            response.Data = positonToReturn;
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var response = new Response();
            var positionToDelete = _dataContext.Positions.FirstOrDefault(position => position.Id == id);
            if (positionToDelete == null)
            {
                response.AddError("id", "Position not found.");
                return NotFound(response);
            }
            _dataContext.Positions.Remove(positionToDelete);
            _dataContext.SaveChanges();
            response.Data = true;
            return Ok(response);
        }

    }
}
