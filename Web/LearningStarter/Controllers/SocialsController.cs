using System.Linq;
using LearningStarter.Common;
using LearningStarter.Data;
using LearningStarter.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LearningStarter.Controllers
{
    [ApiController]
    [Route("api/socials")]
    public class SocialsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public SocialsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new Response();

            var socials = _dataContext
                .Socials
                .Select(social => new SocialGetDto
                {
                    Id = social.Id,
                    PostId = social.PostId,
                    Notifications = social.Notifications,
                    Reminders = social.Reminders,
                })
                .ToList();

            response.Data = socials;
            return Ok(response);
        }

        [HttpGet("{id:int}")]

        public IActionResult GetById([FromRoute] int id)
        {
            var response = new Response();

            var socialToReturn = _dataContext
                .Socials
                .Select(social => new SocialGetDto
                {
                    Id = social.Id,
                    PostId = social.PostId,
                    Notifications = social.Notifications,
                    Reminders = social.Reminders,
                })
                .FirstOrDefault(social => social.Id == id);

            if(socialToReturn == null)
            {
                response.AddError("id", "Social not found.");
                return BadRequest(response);
            }

            response.Data = socialToReturn;
            return Ok(response);
        }

        [HttpPost]

        public IActionResult Create([FromBody] SocialCreateDto socialCreateDto)
        {
            var response = new Response();

            var socialToAdd = new Social
            {
                PostId = socialCreateDto.PostId,
                Notifications = socialCreateDto.Notifications,
                Reminders = socialCreateDto.Reminders
            };

            _dataContext.Socials.Add(socialToAdd);
            _dataContext.SaveChanges();

            var SocialToReturn = new SocialGetDto
            {
                Id = socialToAdd.Id,
                PostId=socialToAdd.PostId,
                Notifications=socialToAdd.Notifications,
                Reminders=socialToAdd.Reminders
            };

            response.Data = SocialToReturn;
            return Created("", response);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(
            [FromRoute] int id,
            [FromBody] SocialUpdateDto socialUpdateDto)
        {
            var response = new Response();

            var socialToUpdate = _dataContext
                .Socials
                .FirstOrDefault(social => social.Id == id);

            if (socialToUpdate == null)
            {
                response.AddError("id", "Social not found.");
            }

            if (socialToUpdate.PostId <= 0)
            {
                response.AddError("postid", "Post not found.");
            }

            if (socialToUpdate.Notifications <= 0)
            {
                response.AddError("Notifications", "Notifications not found.");
            }

            if (socialToUpdate.Reminders <= 0)
            {
                response.AddError("Reminders", "Reminders not found.");
            }
            
            if (response.HasErrors)
            {
                return BadRequest(response);
            }

            socialToUpdate.PostId = socialUpdateDto.PostId;
            socialToUpdate.Notifications = socialUpdateDto.Notifications;
            socialToUpdate.Reminders = socialUpdateDto.Reminders;

            _dataContext.SaveChanges();

            var SocialToReturn = new SocialGetDto
            {
                Id = socialToUpdate.Id,
                PostId = socialToUpdate.PostId,
                Notifications = socialToUpdate.Notifications,
                Reminders = socialToUpdate.Reminders
            };

            response.Data = SocialToReturn;
            return Ok(response);
        }

        [HttpDelete("{id:int}")]

        public IActionResult Delete([FromRoute] int id)
        {
            var response = new Response();

            var SocialToDelete = _dataContext
                .Socials
                .FirstOrDefault(social => social.Id == id);

            if (SocialToDelete == null)
            {
                response.AddError("id", "Social not found.");
                return BadRequest();
            }

            _dataContext.Remove(SocialToDelete);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}