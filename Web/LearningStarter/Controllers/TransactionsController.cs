using LearningStarter.Common;
using LearningStarter.Data;
using LearningStarter.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace LearningStarter.Controllers
{
        [ApiController]
        [Route("api/transactions")]
        public class TransactionsController : ControllerBase
        {
            private readonly DataContext _dataContext;
            public TransactionsController(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            [HttpGet]
            public IActionResult GetAll()
            {
                var response = new Response();

                var transactions = _dataContext
                    .Transactions
                    .Select(transactions => new TransactionGetDto
                    {
                        Id = transactions.Id,
                        Amount = transactions.Amount,   
                        CreatedAt = transactions.CreatedAt, 
                        PaymentType = transactions.PaymentType,
                    })
                    .ToList();

                response.Data = transactions;
                return Ok(response);
            }

            [HttpGet("{id}")]
            public IActionResult GetById([FromRoute] int id)
            {
                var response = new Response();

                var transactionToReturn = _dataContext
                    .Transactions
                    .Select(transactions => new TransactionGetDto
                    {
                        Id = transactions.Id,
                        Amount = transactions.Amount,
                        CreatedAt = transactions.CreatedAt,
                        PaymentType = transactions.PaymentType,
                    })
                    .FirstOrDefault(Transaction => Transaction.Id == id);

                if (transactionToReturn == null)
                {
                    response.AddError("id", "Transaction not found.");
                    return BadRequest(response);
                }

                response.Data = transactionToReturn;
                return Ok(response);
            }

            [HttpPost]
            public IActionResult Create([FromBody] TransactionCreateDto transactionCreateDto)
            {
                var response = new Response();

                if (transactionCreateDto.Amount <= 0)
                {
                    response.AddError("salary", "Amount cannot be negative.");
                }
     
                if (response.HasErrors)
                {
                    return BadRequest(response);
                }

                var transactionToAdd = new Transaction
                {
                    Amount = transactionCreateDto.Amount,
                    CreatedAt = transactionCreateDto.CreatedAt,
                    PaymentType = transactionCreateDto.PaymentType,
                };

                _dataContext.Transactions.Add(transactionToAdd);
                _dataContext.SaveChanges();

                var transactionToReturn = new TransactionGetDto
                {
                    Id = transactionToAdd.Id,
                    Amount = transactionToAdd.Amount,
                    CreatedAt = transactionToAdd.CreatedAt,
                    PaymentType = transactionToAdd.PaymentType,

                };

                response.Data = transactionToReturn;
                return Created("", response);
            }

            [HttpPut("{id}")]

            public IActionResult Update(
                [FromRoute] int id,
                [FromBody] TransactionUpdateDto transactionUpdateDto)
            {
                var response = new Response();

                var transactionToUpdate = _dataContext
                    .Transactions
                    .FirstOrDefault(Transaction => Transaction.Id == id);

                if (transactionToUpdate == null)
                {
                    response.AddError("id", "Employee not found");
                }

                if (transactionToUpdate.Amount <= 0)
                {
                    response.AddError("Amount", "Amount cannot be negative.");
                }


                if (response.HasErrors)
                {
                    return BadRequest(response);
                }

            transactionToUpdate.Amount = transactionUpdateDto.Amount;
            transactionToUpdate.CreatedAt = transactionUpdateDto.CreatedAt;

                _dataContext.SaveChanges();

                var transactionToReturn = new TransactionGetDto
                {
                    Id = transactionToUpdate.Id,
                    Amount = transactionToUpdate.Amount,
                    CreatedAt = transactionToUpdate.CreatedAt,
                    PaymentType = transactionToUpdate.PaymentType,
                 

                };
                response.Data = transactionToReturn;
                return Ok(response);

            }

            [HttpDelete("{id}")]
            public IActionResult Delete([FromRoute] int id)
            {
                var response = new Response();
                var transactionToDelete = _dataContext.Transactions.FirstOrDefault(Transaction => Transaction.Id == id);
                if (transactionToDelete == null)
                {
                    response.AddError("id", "Transactions not found.");
                    return NotFound(response);
                }
                _dataContext.Transactions.Remove(transactionToDelete);
                _dataContext.SaveChanges();
                response.Data = true;
                return Ok(response);
            }
        }
    }