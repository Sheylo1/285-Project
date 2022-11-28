using System;
using System.Linq;
using LearningStarter.Common;
using LearningStarter.Data;
using LearningStarter.Entities;
using LearningStarter.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace LearningStarter.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IAuthenticationService _authenticationService;

        public CommentsController(DataContext dataContext, IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
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
                    CreatedByUserId = comment.CreatedByUserId,
                    CreatedByUserName = comment.CreatedByUser.Username,
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
                    CreatedByUserId = comment.CreatedByUserId,
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
            var currentUser = _authenticationService.GetLoggedInUser();

            if(currentUser == null)
            {
                response.AddError("userId", "must be logged in >:(");
                return BadRequest(response);
            }

            if(string.IsNullOrEmpty(commentCreateDto.CommentText))
            {
                response.AddError("comment", "Must enter a comment");
                return BadRequest(response);
            }

            if ((commentCreateDto.CommentText.Length) <= 2)
            {
                response.AddError("CommentText", "Must enter at least 3 characters");
                return BadRequest(response);
            }

            if ((commentCreateDto.CommentText.Length) >= 65)
            {
                response.AddError("CommentText", "Must enter less than 65 characters");
                return BadRequest(response);
            }

            if (response.HasErrors)
            {
                return BadRequest(response);
            }

            var commentToAdd = new Comment
            {
                CreatedAt = DateTimeOffset.Now,
                CommentText = commentCreateDto.CommentText,
                CreatedByUser = currentUser,
            };

            _dataContext.Comments.Add(commentToAdd);
            _dataContext.SaveChanges();

            var CommentToReturn = new CommentGetDto
            {
                Id = commentToAdd.Id,
                CreatedAt = commentToAdd.CreatedAt,
                CommentText = commentToAdd.CommentText,
                CreatedByUserId = currentUser.Id,
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

            if (string.IsNullOrEmpty(commentUpdateDto.CommentText))
            {
                response.AddError("comment", "Must enter a comment");
                return BadRequest(response);
            }

            if ((commentUpdateDto.CommentText.Length) <= 2)
            {
                response.AddError("CommentText", "Must enter at least 3 characters");
                return BadRequest(response);
            }

            if ((commentUpdateDto.CommentText.Length) >= 65)
            {
                response.AddError("CommentText", "Must enter less than 65 characters");
                return BadRequest(response);
            }


            if (response.HasErrors)
            {
                return BadRequest(response);
            }

            commentToUpdate.CreatedAt = DateTimeOffset.Now;
            commentToUpdate.CommentText = commentUpdateDto.CommentText;

            _dataContext.SaveChanges();

            var CommentToReturn = new CommentGetDto
            {
                Id = commentToUpdate.Id,
                CreatedAt = commentToUpdate.CreatedAt,
                CommentText = commentToUpdate.CommentText,
                CreatedByUserId= commentToUpdate.CreatedByUserId,
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