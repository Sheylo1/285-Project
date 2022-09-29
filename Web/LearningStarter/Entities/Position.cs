using System.Collections.Generic;

namespace LearningStarter.Entities
{
    public class Position
    {
        public int Id { get; set; }
        public decimal Salary { get; set; }
        public string Name { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();

    }
    public class PositionGetDto
    {
        public int Id { get; set; }
        public decimal Salary { get; set; }
        public string Name { get; set; }

    }
    public class PositionCreateDto
    {
        public decimal Salary { get; set; }
        public string Name { get; set; }

    }
    public class PositionUpdateDto
    {
        public decimal Salary { get; set; }
        public string Name { get; set; }
    }
    public class PositionListingDto
    {
        public decimal Salary { get; set; }
        public string Name { get; set; }
    }
}