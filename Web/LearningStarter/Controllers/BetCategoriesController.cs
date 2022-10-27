using LearningStarter.Common;
using LearningStarter.Data;
using LearningStarter.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LearningStarter.Controllers
{
    [ApiController]
    [Route("Api/betCategories")]
    public class BetCategoriesController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public BetCategoriesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new Response();

            var betCategories = _dataContext
                .BetCategories
                .Select(betCategory => new BetCategoryGetDto
                {
                    Id = betCategory.Id,
                    Name = betCategory.Name,
                })
                .ToList();

            response.Data = betCategories;
            return Ok(response);
        }
        [HttpPost]
        public IActionResult Create([FromBody] BetCategoryCreateDto betCategoryCreateDto)
        {
            var response = new Response();

            var betCategoryToAdd = new BetCategory
            {
                Name = betCategoryCreateDto.Name
            };

            _dataContext.BetCategories.Add(betCategoryToAdd);
            _dataContext.SaveChanges();

            var betCategoryToReturn = new BetCategoryGetDto
            {
                Id = betCategoryToAdd.Id,
                Name = betCategoryToAdd.Name
            };

            response.Data = betCategoryToReturn;
            return Created("", response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var response = new Response();

            var betCategoryToReturn = _dataContext
                .BetCategories
                .Select(betCategory => new BetCategoryGetDto
                {
                    Id = betCategory.Id,
                    Name = betCategory.Name
                })
                .FirstOrDefault(betCategory => betCategory.Id == id);

            if(betCategoryToReturn == null)
            {
                response.AddError("id", "Category not found.");
                return BadRequest(response);
            }

            response.Data = betCategoryToReturn;
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] BetCategoryUpdateDto betCategoryUpdateDto)
        {
            var response = new Response();

            var betCategoryToUpdate = _dataContext
                .BetCategories
                .FirstOrDefault(betCategory => betCategory.Id == id);

            if (betCategoryToUpdate == null)
            {
                response.AddError("id", "Category not found.");
                return BadRequest(response);
            }

            betCategoryToUpdate.Name = betCategoryUpdateDto.Name;
            _dataContext.SaveChanges();

            var betCategoryToReturn = new BetCategoryGetDto
            {
                Id = betCategoryToUpdate.Id,
                Name = betCategoryToUpdate.Name
            };

            response.Data = betCategoryToReturn;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var response = new Response();

            var betCategoryToDelete = _dataContext
                .BetCategories
                .FirstOrDefault(betCategory => betCategory.Id == id);

            if (betCategoryToDelete == null)
            {
                response.AddError("id", "Category not found.");
                return BadRequest(response);
            }

            _dataContext.Remove(betCategoryToDelete);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }

    }
}