using LearningStarter.Common;
using LearningStarter.Data;
using LearningStarter.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LearningStarter.Controllers
{
    [ApiController]
    [Route("api/house-systems")]

    public class HouseSystemsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public HouseSystemsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new Response();

            var housesystem = _dataContext
                .HouseSystems
                .Select(housesystem => new HouseSystemGetDto
                {
                    Id = housesystem.Id,
                    Payout = housesystem.Payout,
                    BetPercentage = housesystem.BetPercentage,
                })
                .ToList();

            response.Data = housesystem;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var response = new Response();

            var houseSystemToReturn = _dataContext
                .HouseSystems
                .Select(housesystem => new HouseSystemGetDto
                {
                    Id = housesystem.Id,
                    Payout = housesystem.Payout,
                    BetPercentage = housesystem.BetPercentage,
                })
                .FirstOrDefault(employee => employee.Id == id);

            if (houseSystemToReturn == null)
            {
                response.AddError("id", "house system not found.");
                return BadRequest(response);
            }

            response.Data = houseSystemToReturn;
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create([FromBody] HouseSystemCreateDto housesystemCreateDto)
        {
            var response = new Response();

            if (housesystemCreateDto.Payout <= 0)
            {
                response.AddError("payout", "payout cannot be negative.");
            }
            if (housesystemCreateDto.BetPercentage <= 0)
            {
                response.AddError("BetPercentage", "BetPercentage there must be a postive number.");
            }


            if (response.HasErrors)
            {
                return BadRequest(response);
            }

            var houseSystemToAdd = new HouseSystem
            {
                Payout = housesystemCreateDto.Payout,
                BetPercentage = housesystemCreateDto.BetPercentage,
            };

            _dataContext.HouseSystems.Add(houseSystemToAdd);
            _dataContext.SaveChanges();

            var houseSystemToReturn = new HouseSystemGetDto
            {
                Id = houseSystemToAdd.Id,
                BetPercentage = houseSystemToAdd.BetPercentage,
                Payout = houseSystemToAdd.Payout,
                
            };

            response.Data = houseSystemToReturn;
            return Created("", response);
        }

        [HttpPut("{id}")]

        public IActionResult Update(
            [FromRoute] int id,
            [FromBody] HouseSystemUpdateDto houseSystemUpdateDto)
        {
            var response = new Response();

            var houseSystemToUpdate = _dataContext
                .HouseSystems
                .FirstOrDefault(houseSystem => houseSystem.Id == id);

            if (houseSystemToUpdate == null)
            {
                response.AddError("id", "House sysem not found");
            }

            if (houseSystemToUpdate.Payout <= 0)
            {
                response.AddError("Payout", "Payout cannot be negative.");
            }
            if (houseSystemToUpdate.BetPercentage <= 0)
            {
                response.AddError("BetPercentage", "BetPercentage cannot be negative.");
            }



            if (response.HasErrors)
            {
                return BadRequest(response);
            }

            houseSystemToUpdate.BetPercentage = houseSystemUpdateDto.BetPercentage;
            houseSystemToUpdate.Payout = houseSystemUpdateDto.Payout;
            
            //_dataContext.SaveChanges();

            var houseSystemToReturn = new HouseSystemGetDto
            {
                Id = houseSystemToUpdate.Id,
                BetPercentage = houseSystemToUpdate.BetPercentage,
                Payout = houseSystemToUpdate.Payout,
               

            };
            response.Data = houseSystemToReturn;
            _dataContext.SaveChanges();
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var response = new Response();
            var houseSystemToDelete = _dataContext.HouseSystems.FirstOrDefault(houseSystem => houseSystem.Id == id);
            if (houseSystemToDelete == null)
            {
                response.AddError("id", "houseSystem not found.");
                return NotFound(response);
            }
            _dataContext.HouseSystems.Remove(houseSystemToDelete);
            _dataContext.SaveChanges();
            response.Data = true;
            return Ok(response);
        }
    }
}

