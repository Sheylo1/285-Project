using System;
using System.Security.Policy;

namespace LearningStarter.Entities
{
    public class Employee
    {
       public int Id { get; set; }
       public int UserId { get; set; }
       public string Positions { get; set; }

        public decimal Salary { get; set; }
        public decimal PayRate { get; set; }
        public bool Employed { get; set; }

        public User User { get; set; }
    }
    
    public class EmployeeGetDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Positions { get; set; }

        public decimal Salary { get; set; }
        public decimal PayRate { get; set; }
        public bool Employed { get; set; }

    }

    public class EmployeeCreateDto
    {
        public int UserId { get; set; }
        public string Positions { get; set; }

        public decimal Salary { get; set; }
       public decimal PayRate { get; set; }
        public bool Employed { get; set; }

    }

    public class EmployeeUpdateDto
    {
        public int UserId{get; set;}
        public string Positions{ get; set; }       
        public decimal Salary{get; set; }
        public decimal PayRate{get; set;}
        public bool Employed { get; set;}



    }
    public class EmployeeListingDto
    {
            public int Id { get; set; }
            public int UserId { get; set; }
            public string Positions { get; set; }

        public decimal Salary { get; set; }
        public decimal PayRate { get; set; }
            public bool Employed { get; set; }
    }
}
