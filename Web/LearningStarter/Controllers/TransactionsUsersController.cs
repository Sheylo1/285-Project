using LearningStarter.Common;
using LearningStarter.Data;
using LearningStarter.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LearningStarter.Controllers
{
    [ApiController]
    [Route("Api/transactionUsers")]
    public class TransactionUsersController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public TransactionUsersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new Response();

            var transactionUsers = _dataContext
                .TransactionsUsers
                .Select(transactionuser => new TransactionUserGetDto
                {
                    Id = transactionuser.Id,
                    TransactionsId = transactionuser.TransactionsId,
                    UserId = transactionuser.UserId,
                    Amount = transactionuser.Amount, 
                })
                .ToList();

            response.Data = transactionUsers;
            return Ok(response);
        }
        [HttpPost]
        public IActionResult Create([FromBody] TransactionUserCreateDto transactionUserCreateDto)
        {
            var response = new Response();

            var transactionUserToAdd = new TransactionsUser
            {
               Amount = transactionUserCreateDto.Amount,
               TransactionsId = transactionUserCreateDto.TransactionsId,
               UserId = transactionUserCreateDto.UserId,
            };

            _dataContext.TransactionsUsers.Add(transactionUserToAdd);
            _dataContext.SaveChanges();

            var transactionUserToReturn = new TransactionUserGetDto
            {
                Id = transactionUserToAdd.Id,
                TransactionsId= transactionUserToAdd.TransactionsId,
                UserId = transactionUserToAdd.UserId,
                Amount = transactionUserToAdd.Amount
            };

            response.Data = transactionUserToReturn;
            return Created("", response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var response = new Response();

            var transactionUserToReturn = _dataContext
                .TransactionsUsers
                .Select(transactionUsers => new TransactionUserGetDto
                {
                    Id = transactionUsers.Id,
                    TransactionsId = transactionUsers.TransactionsId,
                    UserId = transactionUsers.UserId,
                    Amount = transactionUsers.Amount,
                })
                .FirstOrDefault(transactionUser => transactionUser.Id == id);

            if (transactionUserToReturn == null)
            {
                response.AddError("id", "Transaction not found.");
                return BadRequest(response);
            }

            response.Data = transactionUserToReturn;
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] TransactionUsersUpdateDto transactionUserUpdateDto)
        {
            var response = new Response();

            var transactionUserToUpdate = _dataContext
                .TransactionsUsers
                .FirstOrDefault(transactionUser => transactionUser.Id == id);

            if (transactionUserToUpdate == null)
            {
                response.AddError("id", "Transaction not found.");
                return BadRequest(response);
            }

            transactionUserToUpdate.Amount = transactionUserUpdateDto.Amount;
            _dataContext.SaveChanges();

            var transactionUserToReturn = new TransactionUserGetDto
            {
                Id = transactionUserToUpdate.Id,
                TransactionsId = transactionUserToUpdate.TransactionsId,
                UserId = transactionUserToUpdate.UserId,
                Amount = transactionUserToUpdate.Amount
            };

            response.Data = transactionUserToReturn;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var response = new Response();

            var transactionUserToDelete = _dataContext
                .TransactionsUsers
                .FirstOrDefault(transactionUser => transactionUser.Id == id);

            if (transactionUserToDelete == null)
            {
                response.AddError("id", "Transaction not found.");
                return BadRequest(response);
            }

            _dataContext.Remove(transactionUserToDelete);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }

    }
}