using System.Linq;
using LearningStarter.Common;
using LearningStarter.Data;
using LearningStarter.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace LearningStarter.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public PostsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new Response();

            var posts = _dataContext
                .Posts
                .Select(post => new PostGetDto
                {
                    Id = post.Id,
                    CreatedAt = post.CreatedAt,
                    CommentId = post.CommentId,
                })
                .ToList();

            response.Data = posts;
            return Ok(response);
        }

        [HttpGet("{id:int}")]

        public IActionResult GetById([FromRoute] int id)
        {
            var response = new Response();

            var postToReturn = _dataContext
                .Posts
                .Select(post => new PostGetDto
                {
                    Id = post.Id,
                    CreatedAt = post.CreatedAt,
                    CommentId = post.CommentId,
                })
                .FirstOrDefault(post => post.Id == id);

            if (postToReturn == null)
            {
                response.AddError("id", "Post not found.");
                return BadRequest(response);
            }

            response.Data = postToReturn;
            return Ok(response);
        }

        [HttpPost]

        public IActionResult Create([FromBody] PostCreateDto postCreateDto)
        {
            var response = new Response();

            var postToAdd = new Post
            {
                CreatedAt = System.DateTimeOffset.Now,
                CommentId = postCreateDto.CommentId
            };

            _dataContext.Posts.Add(postToAdd);
            _dataContext.SaveChanges();

            var PostToReturn = new PostGetDto
            {
                Id = postToAdd.Id,
                CreatedAt = postToAdd.CreatedAt,
                CommentId = postToAdd.CommentId,
            };

            response.Data = PostToReturn;
            return Created("", response);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(
            [FromRoute] int id,
            [FromBody] PostUpdateDto postUpdateDto)
        {
            var response = new Response();

            var postToUpdate = _dataContext
                .Posts
                .FirstOrDefault(post => post.Id == id);

            if (postToUpdate == null)
            {
                response.AddError("id", "Post not found.");
            }

            if (postToUpdate.CommentId <= 0)
            {
                response.AddError("commentid", "Comment not found.");
            }

            if (response.HasErrors)
            {
                return BadRequest(response);
            }

            postToUpdate.CommentId = postUpdateDto.CommentId;
            _dataContext.SaveChanges();

            var PostToReturn = new PostGetDto
            {
                Id = postToUpdate.Id,
                CreatedAt = postToUpdate.CreatedAt,
                CommentId = postToUpdate.CommentId,
            };

            response.Data = PostToReturn;
            return Ok(response);
        }

        [HttpDelete("{id:int}")]

        public IActionResult Delete([FromRoute] int id)
        {
            var response = new Response();

            var PostToDelete = _dataContext
                .Posts
                .FirstOrDefault(post => post.Id == id);

            if (PostToDelete == null)
            {
                response.AddError("id", "Post not found.");
                return BadRequest();
            }

            _dataContext.Remove(PostToDelete);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}