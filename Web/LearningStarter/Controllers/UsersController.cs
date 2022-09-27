using System.Linq;
using LearningStarter.Common;
using LearningStarter.Data;
using LearningStarter.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LearningStarter.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new Response();

            response.Data = _context
                .Users
                .Select(x => new UserGetDto
                {
                    CreatedDate = x.CreatedDate,
                    ClosedDate = x.ClosedDate,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Username = x.Username,
                    AccountBalance = x.AccountBalance,
                    Email = x.Email,
                    Password = x.Password,
                    PhoneNumber = x.PhoneNumber,
                    DateOfBirth = x.DateOfBirth,
                })
                .ToList();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(
            [FromRoute] int id)
        {
            var response = new Response();

            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                response.AddError("id", "There was a problem finding the user.");
                return NotFound(response);
            }

            var userGetDto = new UserGetDto
            {
                CreatedDate = user.CreatedDate,
                ClosedDate = user.ClosedDate,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                AccountBalance = user.AccountBalance,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth,
            };

            response.Data = userGetDto;

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create(
            [FromBody] UserCreateDto userCreateDto)
        {
            var response = new Response();

            if (userCreateDto.FirstName == null || userCreateDto.FirstName == "")
            {
                response.AddError("firstName", "First name cannot be empty.");
            }

            if (userCreateDto.LastName == null || userCreateDto.LastName == "")
            {
                response.AddError("lastName", "Last name cannot be empty.");
            }

            if (userCreateDto.Username == null || userCreateDto.Username == "")
            {
                response.AddError("userName", "User name cannot be empty.");
            }

            if (userCreateDto.Password == null || userCreateDto.Password == "")
            {
                response.AddError("password", "Password cannot be empty.");
            }

            if (userCreateDto.Email == null || userCreateDto.Email == "")
            {
                response.AddError("email", "Email cannot be empty.");
            }

            if (response.HasErrors)
            {
                return BadRequest(response);
            }

            var userToCreate = new User
            {
                CreatedDate = userCreateDto.CreatedDate,
                ClosedDate = userCreateDto.ClosedDate,
                FirstName = userCreateDto.FirstName,
                LastName = userCreateDto.LastName,
                Username = userCreateDto.Username,
                AccountBalance = userCreateDto.AccountBalance,
                Email = userCreateDto.Email,
                Password = userCreateDto.Password,
                PhoneNumber = userCreateDto.PhoneNumber,
                DateOfBirth = userCreateDto.DateOfBirth,
            };

            _context.Users.Add(userToCreate);
            _context.SaveChanges();

            var userGetDto = new UserGetDto
            {
                CreatedDate = userToCreate.CreatedDate,
                ClosedDate = userToCreate.ClosedDate,
                FirstName = userToCreate.FirstName,
                LastName = userToCreate.LastName,
                Username = userToCreate.Username,
                AccountBalance = userToCreate.AccountBalance,
                Email = userToCreate.Email,
                Password = userToCreate.Password,
                PhoneNumber = userToCreate.PhoneNumber,
                DateOfBirth = userToCreate.DateOfBirth
            };

            response.Data = userGetDto;

            return Created("", response);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(
            [FromRoute] int id, 
            [FromBody] UserUpdateDto user)
        {
            var response = new Response();

            if (user == null)
            {
                response.AddError("id", "There was a problem editing the user.");
                return NotFound(response);
            }
            
            var userToEdit = _context.Users.FirstOrDefault(x => x.Id == id);

            if (userToEdit == null)
            {
                response.AddError("id", "Could not find user to edit.");
                return NotFound(response);
            }

            if (userToEdit.FirstName == null || userToEdit.FirstName == "")
            {
                response.AddError("firstName", "First name cannot be empty.");
            }

            if (userToEdit.LastName == null || userToEdit.LastName == "")
            {
                response.AddError("lastName", "Last name cannot be empty.");
            }

            if (userToEdit.Username == null || userToEdit.Username == "")
            {
                response.AddError("userName", "User name cannot be empty.");
            }

            if (userToEdit.Password == null || userToEdit.Password == "")
            {
                response.AddError("password", "Password cannot be empty.");
            }

            if (userToEdit.Email == null || userToEdit.Email == "")
            {
                response.AddError("email", "Email cannot be empty.");
            }

            if (response.HasErrors)
            {
                return BadRequest(response);
            }
            userToEdit.CreatedDate = user.CreatedDate;
            userToEdit.ClosedDate = user.ClosedDate;
            userToEdit.FirstName = user.FirstName;
            userToEdit.LastName = user.LastName;
            userToEdit.Username = user.Username;
            userToEdit.AccountBalance = user.AccountBalance;
            userToEdit.Password = user.Password;
            userToEdit.Email = user.Email;
            userToEdit.DateOfBirth = user.DateOfBirth;

            _context.SaveChanges();

            var userGetDto = new UserGetDto
            {
                CreatedDate = userToEdit.CreatedDate,
                ClosedDate = userToEdit.ClosedDate,
                FirstName = userToEdit.FirstName,
                LastName = userToEdit.LastName,
                Username = userToEdit.Username,
                AccountBalance = userToEdit.AccountBalance,
                Password = userToEdit.Password,
                Email = userToEdit.Email,
                DateOfBirth = userToEdit.DateOfBirth,

            };

            response.Data = userGetDto;

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = new Response();

            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                response.AddError("id", "There was a problem deleting the user.");
                return NotFound(response);
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return Ok(response);
        }
    }
}
