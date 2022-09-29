using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace LearningStarter.Entities
{
    public class Employee
    {
       public int Id { get; set; }
       public int UserId { get; set; }
       public User User { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public decimal Salary { get; set; }
        public bool Employed { get; set; }
        public List<BetTransaction> BetTransactions { get; set; } = new List<BetTransaction>();
        public List<BetDispute> BetDisputes { get; set; } = new List<BetDispute>();

    }
    
    public class EmployeeGetDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PositionId { get; set; }

        public decimal Salary { get; set; }
        public bool Employed { get; set; }

    }

    public class EmployeeCreateDto
    {
        public int UserId { get; set; }
        public int PositionId { get; set; }

        public decimal Salary { get; set; }
        public bool Employed { get; set; }


    }

    public class EmployeeUpdateDto
    {
        public int UserId { get; set; }
        public int PositionId { get; set; }

        public decimal Salary { get; set; }
        public bool Employed { get; set; }
    }
    public class EmployeeListingDto
    {
        public int UserId { get; set; }
        public int PositionId { get; set; }

        public decimal Salary { get; set; }
        public bool Employed { get; set; }

    }
}
