using System;

namespace LearningStarter.Entities
{
    public class BetDispute
    {
        public int Id { get; set; }
        public int BetId { get; set; }
        public Bet Bet { get; set; }
        public string Issue { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } 
        public string IssueSolvedDate { get; set; }

    }
    public class BetDisputeGetDto
    {
        public int Id { get; set; }
        public int BetId { get; set; }
        public string Issue { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int EmployeeId { get; set; }
        public string IssueSolvedDate { get; set; }
    }

    public class BetDisputeCreateDto
    {
        public int BetId { get; set; }
        public string Issue { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int EmployeeId { get; set; }
        public string IssueSolvedDate { get; set; }
    }

    public class BetDisputeUpdateDto
    {
        public int BetId { get; set; }
        public string Issue { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int EmployeeId { get; set; }
        public string IssueSolvedDate { get; set; }
    }
    public class BetDisputeListingDto
    {
        public int BetId { get; set; }
        public string Issue { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int EmployeeId { get; set; }
        public string IssueSolvedDate { get; set; }
    }
}