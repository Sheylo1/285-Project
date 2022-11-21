using Microsoft.AspNetCore.Mvc;
using System.Linq;
using LearningStarter.Common;
using LearningStarter.Data;
using LearningStarter.Entities;
namespace LearningStarter.Controllers
{
    [ApiController]
    [Route("api/betdispute")]
    public class BetDisputesController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public BetDisputesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new Response();

            var BetDisputes = _dataContext
                .BetDisputes
                .Select(BetDispute => new BetDisputeGetDto
                {
                    BetId = BetDispute.BetId,
                    Issue = BetDispute.Issue,
                    CreatedDate = BetDispute.CreatedDate,
                    ClosedDate = BetDispute.ClosedDate,
                    EmployeeId = BetDispute.EmployeeId,
                    

                }).ToList();

            response.Data = BetDisputes;
            return Ok(response);
        }

        [HttpGet("{id}")]
        
        public IActionResult GetById([FromRoute] int id)
        {
            var response = new Response();

            var betDisputeToReturn = _dataContext
                .BetDisputes
                .Select(betDispute => new BetDisputeGetDto
                {
                    Id = betDispute.Id,
                    Issue = betDispute.Issue,
                    CreatedDate = betDispute.CreatedDate,
                    ClosedDate = betDispute.ClosedDate,
                    EmployeeId = betDispute.EmployeeId,
                })
                .FirstOrDefault(betDispute => betDispute.Id == id);

            if (betDisputeToReturn == null)
            {
                response.AddError("id", "Bet dispute not found.");
            }
            response.Data = betDisputeToReturn;
            return Ok(response);
        }

        [HttpPost]

        public IActionResult Create([FromBody] BetDisputeCreateDto betDisputeCreateDto)
        {
            var response = new Response();
            if (string.IsNullOrEmpty(betDisputeCreateDto.Issue))
            {
                response.AddError("issue", "Issue cannot be empty");
                return BadRequest(response);
            }
            if (response.HasErrors)
            {
                return BadRequest(response);

            }
            var betDisputeToAdd = new BetDispute
            {
                BetId = betDisputeCreateDto.BetId,
                Issue = betDisputeCreateDto.Issue,
                CreatedDate = betDisputeCreateDto.CreatedDate,
                ClosedDate= betDisputeCreateDto.ClosedDate,
                EmployeeId = betDisputeCreateDto.EmployeeId,
               

            };

            _dataContext.BetDisputes.Add(betDisputeToAdd);
            _dataContext.SaveChanges();

            var betDisputeToReturn = new BetDisputeGetDto
            {
                Id = betDisputeToAdd.Id,
                BetId = betDisputeToAdd.BetId,
                Issue = betDisputeToAdd.Issue,
                CreatedDate = betDisputeToAdd.CreatedDate,
                ClosedDate = betDisputeToAdd.ClosedDate,
                EmployeeId = betDisputeToAdd.EmployeeId,
               

            };
            response.Data = betDisputeToReturn;
            return Created("", response);

        }

        [HttpPut("{id}")]
        public IActionResult Update(
            [FromRoute] int id,
            [FromBody] BetDisputeUpdateDto betDisputeUpdateDto)
        {
            var response = new Response();

            var betDisputeToUpdate = _dataContext
                .BetDisputes
                .FirstOrDefault(betDispute => betDispute.Id == id);

            if(betDisputeToUpdate == null)
            {
                response.AddError("id", "Bet dispute was not found.");
                return BadRequest(response);
            }

    
            _dataContext.SaveChanges();

            var betDisputeToReturn = new BetDisputeGetDto
            {
                Id = betDisputeToUpdate.Id,
                BetId = betDisputeToUpdate.BetId,
                Issue = betDisputeToUpdate.Issue,
                CreatedDate = betDisputeToUpdate.CreatedDate,
                ClosedDate= betDisputeToUpdate.ClosedDate,
                EmployeeId = betDisputeToUpdate.EmployeeId,
            };

            response.Data = betDisputeToReturn;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        
        public IActionResult Delete([FromRoute] int id)
        {
            var response = new Response();

            var betDisputeToDelete = _dataContext
                .BetDisputes
                .FirstOrDefault(betDispute => betDispute.Id == id);

            if (betDisputeToDelete == null)
            {
                response.AddError("id", "Bet dispute cannot be found.");
                return BadRequest(response);
            }
            _dataContext.Remove(betDisputeToDelete);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
