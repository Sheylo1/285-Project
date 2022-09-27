using System;

namespace LearningStarter.Entities
{
    public class BetDisputes
    {
        public int Id { get; set; }
        public int BetId { get; set; }
        public string Dispute { get; set; }
        public string Issue { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }

        public int EmployeeId { get; set; }
        public string IssueSolvedDate { get; set; }

    }
    public class BetDisputesGetDto
    {
        public int Id { get; set; }
        public int BetId { get; set; }
        public string Dispute { get; set; }
        public string Issue { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int EmployeeId { get; set; }
        public string IssueSolvedDate { get; set; }
    }

    public class BetDisputesCreateDto
    {
        public int BetId { get; set; }
        public string Dispute { get; set; }
        public string Issue { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int EmployeeId { get; set; }
        public string IssueSolvedDate { get; set; }
    }

    public class BetDisputesUpdateDto
    {
        public int BetId { get; set; }
        public string Dispute { get; set; }
        public string Issue { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int EmployeeId { get; set; }
        public string IssueSolvedDate { get; set; }
    }
}