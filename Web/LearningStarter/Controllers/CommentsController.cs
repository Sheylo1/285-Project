using System.Linq;
using LearningStarter.Common;
using LearningStarter.Data;
using LearningStarter.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace LearningStarter.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CommentsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new Response();

            var comments = _dataContext
                .Comments
                .Select(comment => new CommentGetDto
                {
                    Id = comment.Id,
                    CreatedAt = comment.CreatedAt,
                    CommentText = comment.CommentText,
                })
                .ToList();

            response.Data = comments;
            return Ok(response);
        }

        [HttpGet("{id:int}")]

        public IActionResult GetById([FromRoute] int id)
        {
            var response = new Response();

            var commentToReturn = _dataContext
                .Comments
                .Select(comment => new CommentGetDto
                {
                    Id = comment.Id,
                    CreatedAt = comment.CreatedAt,
                    CommentText = comment.CommentText,
                })
                .FirstOrDefault(comment => comment.Id == id);

            if (commentToReturn == null)
            {
                response.AddError("id", "Comment not found.");
                return BadRequest(response);
            }

            response.Data = commentToReturn;
            return Ok(response);
        }

        [HttpPost]

        public IActionResult Create([FromBody] CommentCreateDto commentCreateDto)
        {
            var response = new Response();

            var commentToAdd = new Comment
            {
                CreatedAt = System.DateTimeOffset.Now,
                CommentText = commentCreateDto.CommentText
            };

            _dataContext.Comments.Add(commentToAdd);
            _dataContext.SaveChanges();

            var CommentToReturn = new CommentGetDto
            {
                Id = commentToAdd.Id,
                CreatedAt = commentToAdd.CreatedAt,
                CommentText = commentToAdd.CommentText,
            };

            response.Data = CommentToReturn;
            return Created("", response);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(
            [FromRoute] int id,
            [FromBody] CommentUpdateDto commentUpdateDto)
        {
            var response = new Response();

            var commentToUpdate = _dataContext
                .Comments
                .FirstOrDefault(comment => comment.Id == id);

            if (commentToUpdate == null)
            {
                response.AddError("id", "Comment not found.");
            }


            if (response.HasErrors)
            {
                return BadRequest(response);
            }

            commentToUpdate.CreatedAt = commentUpdateDto.CreatedAt;
            commentToUpdate.CommentText = commentUpdateDto.CommentText;

            _dataContext.SaveChanges();

            var CommentToReturn = new CommentGetDto
            {
                Id = commentToUpdate.Id,
                CreatedAt = commentToUpdate.CreatedAt,
                CommentText = commentToUpdate.CommentText,
            };

            response.Data = CommentToReturn;
            return Ok(response);
        }

        [HttpDelete("{id:int}")]

        public IActionResult Delete([FromRoute] int id)
        {
            var response = new Response();

            var CommentToDelete = _dataContext
                .Comments
                .FirstOrDefault(comment => comment.Id == id);

            if (CommentToDelete == null)
            {
                response.AddError("id", "Comment not found.");
                return BadRequest();
            }

            _dataContext.Remove(CommentToDelete);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}