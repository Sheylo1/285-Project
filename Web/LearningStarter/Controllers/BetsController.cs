using LearningStarter.Common;
using LearningStarter.Data;
using LearningStarter.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LearningStarter.Controllers
{
    [ApiController]
    [Route("api/Bet")]

    public class BetsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public BetsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new Response();

            var Bets = _dataContext
                .Bets
                .Select(Bet => new BetGetDto
                {
                    Id = Bet.Id,
                    Name = Bet.Name,
                    BetCategoryId = Bet.BetCategoryId,
                    CreatedDate = Bet.CreatedDate,
                    ClosedDate = Bet.ClosedDate,
                    CommentId = Bet.CommentId,
                    BetDisputeCall = Bet.BetDisputeCall,
                    EscrowSystemId = Bet.EscrowSystemId

                }).ToList();

            response.Data = Bets;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var response = new Response();

            var betToReturn = _dataContext
                .Bets
                .Select(bet => new BetGetDto
                {
                    Id = bet.Id,
                    Name = bet.Name,
                    BetCategoryId = bet.BetCategoryId,
                    CreatedDate = bet.CreatedDate,
                    ClosedDate = bet.ClosedDate,
                    CommentId = bet.CommentId,
                    BetDisputeCall = bet.BetDisputeCall,
                    EscrowSystemId = bet.EscrowSystemId

                })
                .FirstOrDefault(bet => bet.Id == id);

            if (betToReturn == null)
            {
                response.AddError("id", "Bet was not found");
            }
            response.Data = betToReturn;
            return Ok(response);
            }
                
        

        [HttpPost]
        public IActionResult Create([FromBody] BetCreateDto betCreateDto)
        {
            var response = new Response();

            if (string.IsNullOrEmpty(betCreateDto.Name))
            {
                response.AddError("name", "Bet Name cannot be empty");
                return BadRequest(response);
            }
            if (response.HasErrors)
            {
                return BadRequest(response);
            }

            var betToAdd = new Bet
            {
                Name = betCreateDto.Name,
                BetCategoryId = betCreateDto.BetCategoryId,
                CreatedDate = betCreateDto.CreatedDate,
                ClosedDate = betCreateDto.ClosedDate,
                CommentId = betCreateDto.CommentId,
                BetDisputeCall = betCreateDto.BetDisputeCall,
                EscrowSystemId = betCreateDto.EscrowSystemId
            };

            _dataContext.Bets.Add(betToAdd);
            _dataContext.SaveChanges();

            var betToReturn = new BetGetDto
            {
                Id = betToAdd.Id,
                Name = betToAdd.Name,
                BetCategoryId = betToAdd.BetCategoryId,
                CreatedDate = betToAdd.CreatedDate,
                ClosedDate = betToAdd.ClosedDate,
                CommentId = betToAdd.CommentId,
                BetDisputeCall = betToAdd.BetDisputeCall,
                EscrowSystemId = betToAdd.EscrowSystemId

            };

            response.Data = betToReturn;
            return Created("", response);
        }

        [HttpPut("{id}")]
        
        public IActionResult Update(
            [FromRoute] int id,
            [FromBody] BetUpdateDto betUpdateDto)
        {
            var response = new Response();

            var betToUpdate = _dataContext
                .Bets
                .FirstOrDefault(bet => bet.Id == id);

            if (betToUpdate == null)
            {
                response.AddError("id", "Bet was not found.");
                return BadRequest(response);
            }

            betToUpdate.Name = betUpdateDto.Name;
            _dataContext.SaveChanges();

            var betToReturn = new BetGetDto
            {
                BetCategoryId = betToUpdate.BetCategoryId,
                CreatedDate = betToUpdate.CreatedDate,
                ClosedDate = betToUpdate.ClosedDate,
                CommentId = betToUpdate.CommentId,
                BetDisputeCall = betToUpdate.BetDisputeCall,
                EscrowSystemId = betToUpdate.EscrowSystemId
            };

            response.Data = betToReturn;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var response = new Response();

            var betToDelete = _dataContext
                .Bets.FirstOrDefault(bet => bet.Id == id);

            if (betToDelete == null)
            {
                response.AddError("id", "Bet was not found");
                return BadRequest(response);
            }

            _dataContext.Remove(betToDelete);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
