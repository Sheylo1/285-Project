using System;
using System.Security.Policy;

namespace LearningStarter.Entities
{
    public class Employee
    {
       public int Id { get; set; }
       public int UserId { get; set; }
       public int PositionsId { get; set; }

        public decimal Salary { get; set; }
        public bool Employed { get; set; }

        public User User { get; set; }
    }
    
    public class EmployeeGetDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PositionsId { get; set; }

        public decimal Salary { get; set; }
        public bool Employed { get; set; }

    }

    public class EmployeeCreateDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PositionsId { get; set; }

        public decimal Salary { get; set; }
        public bool Employed { get; set; }


    }

    public class EmployeeUpdateDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PositionsId { get; set; }

        public decimal Salary { get; set; }
        public bool Employed { get; set; }
    }
    public class EmployeeListingDto
    {
        public int UserId { get; set; }
        public int PositionsId { get; set; }

        public decimal Salary { get; set; }
        public bool Employed { get; set; }

    }
}
