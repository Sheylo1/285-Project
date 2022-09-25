using System;

namespace LearningStarter.Entities
{
    public class BetDisputes
    {
        public int Id { get; set; }
        public int BetId { get; set; }
        public string Dispute { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ClosedAt { get; set; }
        public int EmployeeId { get; set; }
        public string DisputeSolved { get; set; }

    }
    public class BetDisputesGetDto
    {
        public int Id { get; set; }
        public int BetId { get; set; }
        public string Dispute { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ClosedAt { get; set; }
        public int EmployeeId { get; set; }
        public string DisputeSolved { get; set; }
    }

    public class BetDisputesCreateDto
    {
        public int BetId { get; set; }
        public string Dispute { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ClosedAt { get; set; }
        public int EmployeeId { get; set; }
        public string DisputeSolved { get; set; }
    }

    public class BetDisputesUpdateDto
    {
        public int BetId { get; set; }
        public string Dispute { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ClosedAt { get; set; }
        public int EmployeeId { get; set; }
        public string DisputeSolved { get; set; }
    }
}