using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LearningStarter.Entities
{
    public class User
    {
        [JsonIgnore] 
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public decimal AccountBalance { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public int SocialId { get; set; }
        public Social Social { get; set; }


        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<TransactionsUser> TransactionsUsers { get; set; } = new List<TransactionsUser>();
        public List<BetTransaction> BetTransactions { get; set; } = new List<BetTransaction>();

    }

    public class UserCreateDto
    {
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public decimal AccountBalance { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public int SocialId { get; set; }
    }

    public class UserUpdateDto
    {        
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public decimal AccountBalance { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public int SocialId { get; set; }
    }

    public class UserGetDto
    {
        public int Id { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public decimal AccountBalance { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public int SocialId { get; set; }
    }

    public class UserListingDto
    {
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public decimal AccountBalance { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public int SocialId { get; set; }
    }
}
