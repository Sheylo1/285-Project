using System;
using System.Security.Policy;

namespace LearningStarter.Entities
{
    public class Employee
    {
       public int Id { get; set; }
       public int UserId { get; set; }
       public int Positions { get; set; }

        public int Salary { get; set; }
        public int PayRate { get; set; }
        public Boolean Employed { get; set; }
    }

    public class EmployeeGetDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Positions { get; set; }

        public int Salary { get; set; }
        public int PayRate { get; set; }
        public Boolean Employed { get; set; }
    }

    public class EmployeeCreateDto
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int Positions { get; set; }

        public int Salary { get; set; }
        public int PayRate { get; set; }
        public Boolean Employed { get; set; }
    }

    public class EmployeeUpdateDto
    {
        public int UserId{get; set;}
        public int Positions{ get; set; }       
        public int Salary{get; set; }
        public int PayRate{get; set;}
        public Boolean Employed { get; set;}

        
   }
    public class EmployeeListingDto
    {
            public int Id { get; set; }
            public int UserId { get; set; }
            public int Positions { get; set; }
            public Boolean Employed { get; set; }
    }
}
