using Microsoft.AspNetCore.Mvc;
using System.Linq;
using LearningStarter.Common;
using LearningStarter.Data;
using LearningStarter.Entities;
namespace LearningStarter.Controllers
{

    [ApiController]
    [Route("api/escrowsystem")]
    public class EscrowSystemsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public EscrowSystemsController(DataContext dataContext)
        {
            _dataContext = dataContext;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new Response();

            var EscrowSystems = _dataContext
                .EscrowSystems
                .Select(EscrowSystem => new EscrowSystemGetDto
                {
                    PaymentType = EscrowSystem.PaymentType,
                    CreatedDate = EscrowSystem.CreatedDate,
                    ClosedDate = EscrowSystem.ClosedDate,
                    DispersalCompletionDate = EscrowSystem.DispersalCompletionDate,
                    EscrowPayout = EscrowSystem.EscrowPayout

                }).ToList();

            response.Data = EscrowSystems;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var response = new Response();
            
            var escrowSystemToReturn = _dataContext
                .EscrowSystems
                .Select(escrowSystem => new EscrowSystemGetDto
                {
                    Id = escrowSystem.Id,
                    PaymentType = escrowSystem.PaymentType,
                    CreatedDate = escrowSystem.CreatedDate,
                    ClosedDate = escrowSystem.ClosedDate,
                    DispersalCompletionDate = escrowSystem.DispersalCompletionDate,
                    EscrowPayout = escrowSystem.EscrowPayout

                })
                .FirstOrDefault(escrowSystem => escrowSystem.Id == id);

            if (escrowSystemToReturn == null)
            {
                response.AddError("id", "Escrow account not found.");
            }
            response.Data = escrowSystemToReturn;
            return Ok(response);

        }

        [HttpPost]
        public IActionResult Create([FromBody] EscrowSystemCreateDto escrowSystemCreateDto)
        {
            var response = new Response();
            if (string.IsNullOrEmpty(escrowSystemCreateDto.PaymentType))
            {
                response.AddError("payment type", "Payment type cannot be empty");
                return BadRequest(response);
            }
            if (response.HasErrors)
            {
                return BadRequest(response);
            }

            var escrowSystemToAdd = new EscrowSystem
            {
                PaymentType = escrowSystemCreateDto.PaymentType,
                CreatedDate = escrowSystemCreateDto.CreatedDate,
                DispersalCompletionDate = escrowSystemCreateDto.DispersalCompletionDate,
                EscrowPayout = escrowSystemCreateDto.EscrowPayout
            };

            _dataContext.EscrowSystems.Add(escrowSystemToAdd);
            _dataContext.SaveChanges();

            var escrowSystemToReturn = new EscrowSystemGetDto
            {
                Id = escrowSystemToAdd.Id,
                CreatedDate = escrowSystemToAdd.CreatedDate,
                DispersalCompletionDate= escrowSystemToAdd.DispersalCompletionDate,
                EscrowPayout = escrowSystemToAdd.EscrowPayout,
                PaymentType = escrowSystemToAdd.PaymentType
            };

            response.Data = escrowSystemToReturn;
            return Created("", response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            [FromRoute] int id, 
            [FromBody] EscrowSystemUpdateDto escrowSystemUpdateDto)
        {
            var response = new Response();

            var escrowSystemToUpdate = _dataContext
                .EscrowSystems
                .FirstOrDefault(escrowSystem => escrowSystem.Id == id);

            if (escrowSystemToUpdate == null)
            {
                response.AddError("id", "Escrow account was not found.");
                return BadRequest(response);
            }

            escrowSystemToUpdate.PaymentType = escrowSystemUpdateDto.PaymentType;
            _dataContext.SaveChanges();

            var escrowSystemToReturn = new EscrowSystemGetDto
            {
                PaymentType = escrowSystemToUpdate.PaymentType,
                Id = escrowSystemToUpdate.Id,
                CreatedDate = escrowSystemToUpdate.CreatedDate,
                DispersalCompletionDate = escrowSystemToUpdate.DispersalCompletionDate,
                EscrowPayout = escrowSystemToUpdate.EscrowPayout
            };
            response.Data = escrowSystemToReturn;
            return Ok(response);


        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var response = new Response();

            var escrowSystemToDelete = _dataContext
                .EscrowSystems
                .FirstOrDefault(escrowSystem => escrowSystem.Id == id);

            if (escrowSystemToDelete == null)
            {
                response.AddError("id", "Escrow account was not found.");
                return BadRequest(response);
            }

            _dataContext.Remove(escrowSystemToDelete);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}