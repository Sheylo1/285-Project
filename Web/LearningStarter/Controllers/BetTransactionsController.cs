using LearningStarter.Common;
using LearningStarter.Data;
using LearningStarter.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LearningStarter.Controllers
{
    [ApiController]
    [Route("Api/betTransactions")]
    public class BetTransactionsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public BetTransactionsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new Response();

            var betTransactions = _dataContext
                .BetTransactions
                .Select(bettransaction => new BetTransactionGetDto
                {
                    Id = bettransaction.Id,
                    BetId = bettransaction.BetId,
                    CreatedDate = bettransaction.CreatedDate,
                    FinishedAt = bettransaction.FinishedAt,
                    Amount = bettransaction.Amount,
                    Result = bettransaction.Result,
                    HouseSystemId = bettransaction.HouseSystemId,
                    UserId = bettransaction.UserId,
                    EmployeeId = bettransaction.EmployeeId,
                    TransactionId = bettransaction.TransactionId
                    
                })
                .ToList();

            response.Data = betTransactions;
            return Ok(response);
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] BetTransactionsCreateDto betTransactionCreateDto)
        {
            var response = new Response();

            var betTransactionToAdd = new BetTransaction
            {
                BetId = betTransactionCreateDto.BetId,
                CreatedDate = betTransactionCreateDto.CreatedDate,
                FinishedAt = betTransactionCreateDto.FinishedAt,
                Amount = betTransactionCreateDto.Amount,
                Result = betTransactionCreateDto.Result,
                HouseSystemId = betTransactionCreateDto.HouseSystemId,
                UserId = betTransactionCreateDto.UserId,
                EmployeeId = betTransactionCreateDto.EmployeeId,
                TransactionId = betTransactionCreateDto.TransactionId
            };

            _dataContext.BetTransactions.Add(betTransactionToAdd);
            _dataContext.SaveChanges();

            var betTransactionToReturn = new BetTransactionGetDto
            {
                Id = betTransactionToAdd.Id,
                BetId = betTransactionToAdd.BetId,
                CreatedDate = betTransactionToAdd.CreatedDate,
                FinishedAt = betTransactionToAdd.FinishedAt,
                Amount = betTransactionToAdd.Amount,
                Result = betTransactionToAdd.Result,
                HouseSystemId = betTransactionToAdd.HouseSystemId,
                UserId = betTransactionToAdd.UserId,
                EmployeeId = betTransactionToAdd.EmployeeId,
                TransactionId = betTransactionToAdd.TransactionId
            };

            response.Data = betTransactionToReturn;
            return Created("", response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var response = new Response();

            var betTransactionToReturn = _dataContext
                .BetTransactions
                .Select(betTransaction => new BetTransactionGetDto
                {
                    Id = betTransaction.Id,
                    BetId = betTransaction.BetId,
                    CreatedDate = betTransaction.CreatedDate,
                    FinishedAt = betTransaction.FinishedAt,
                    Amount = betTransaction.Amount,
                    Result = betTransaction.Result,
                    HouseSystemId = betTransaction.HouseSystemId,
                    UserId = betTransaction.UserId,
                    EmployeeId = betTransaction.EmployeeId,
                    TransactionId = betTransaction.TransactionId

                })
                .FirstOrDefault(betTransaction => betTransaction.Id == id);

            if (betTransactionToReturn == null)
            {
                response.AddError("id", "Bet Transaction not found.");
                return BadRequest(response);
            }

            response.Data = betTransactionToReturn;
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] BetTransactionUpdateDto betTransactionUpdateDto)
        {
            var response = new Response();

            var betTransactionToUpdate = _dataContext
                .BetTransactions
                .FirstOrDefault(betTransaction => betTransaction.Id == id);

            if (betTransactionToUpdate == null)
            {
                response.AddError("id", "Bet Transaction not found.");
                return BadRequest(response);
            }

            betTransactionToUpdate.Amount = betTransactionUpdateDto.Amount;
            _dataContext.SaveChanges();

            var betTransactionToReturn = new BetTransactionGetDto
            {
                Id = betTransactionToUpdate.Id,
                BetId = betTransactionToUpdate.BetId,
                CreatedDate = betTransactionToUpdate.CreatedDate,
                FinishedAt = betTransactionToUpdate.FinishedAt,
                Amount = betTransactionToUpdate.Amount,
                Result = betTransactionToUpdate.Result,
                HouseSystemId = betTransactionToUpdate.HouseSystemId,
                UserId = betTransactionToUpdate.UserId,
                EmployeeId = betTransactionToUpdate.EmployeeId,
                TransactionId = betTransactionToUpdate.TransactionId
            };

            response.Data = betTransactionToReturn;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var response = new Response();

            var betTransactionToDelete = _dataContext
                .BetTransactions
                .FirstOrDefault(betTransaction => betTransaction.Id == id);

            if (betTransactionToDelete == null)
            {
                response.AddError("id", "Bet Transaction not found.");
                return BadRequest(response);
            }

            _dataContext.Remove(betTransactionToDelete);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }

    }
}