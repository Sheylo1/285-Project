using LearningStarter.Common;
using LearningStarter.Data;
using LearningStarter.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LearningStarter.Controllers
{
    [ApiController]
    [Route("api/BetDisputes")]
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
                .Select(BetDisputes => new BetDisputesGetDto
                {
                    Id = BetDisputes.Id,
                    BetId = BetDisputes.BetId,
                    Dispute = BetDisputes.Dispute,
                    CreatedAt = BetDisputes.CreatedAt,
                    ClosedAt = BetDisputes.ClosedAt,
                    EmployeeId = BetDisputes.EmployeeId,
                    DisputeSolved = BetDisputes.DisputeSolved,

                })
                .ToList();

            response.Data = BetDisputes;
            return Ok(response);
        }
    }
}