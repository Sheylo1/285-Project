using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LearningStarter.Entities
{
    public class User
    {
        [JsonIgnore] 
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset DeletedDate { get; set; }
        public int AccountBalance { get; set; }
        public int PaymentsToEscrow { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string BetHistory { get; set; }
        public string Transactions { get; set; }
        public string Socials { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }

    public class UserCreateDto
    {
        public DateTimeOffset CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset DeletedDate { get; set; }
        public int AccountBalance { get; set; }
        public int PaymentsToEscrow { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string BetHistory { get; set; }
        public string Transactions { get; set; }
        public string Socials { get; set; }
    }

    public class UserUpdateDto
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset DeletedDate { get; set; }
        public int AccountBalance { get; set; }
        public int PaymentsToEscrow { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string BetHistory { get; set; }
        public string Transactions { get; set; }
        public string Socials { get; set; }
    }

    public class UserGetDto
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public int AccountBalance { get; set; }
        public int PaymentsToEscrow { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string BetHistory { get; set; }
        public string Transactions { get; set; }
        public string Socials { get; set; }
    }
}
