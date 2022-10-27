using System;
using System.Collections.Generic;

namespace LearningStarter.Entities
{
    public class EscrowSystem
    {
        public int Id { get; set; }
        public string PaymentType { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public DateTimeOffset DispersalCompletionDate { get; set; }
        public decimal EscrowPayout { get; set; }
        public List<Bet> Bets { get; set; } = new List<Bet>();
    }

    public class EscrowSystemGetDto
    {
        public int Id { get; set; }
        public string PaymentType { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public DateTimeOffset DispersalCompletionDate { get; set; }
        public decimal EscrowPayout { get; set; }
    }

    public class EscrowSystemCreateDto
    {
        public string PaymentType { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public DateTimeOffset DispersalCompletionDate { get; set; }
        public decimal EscrowPayout { get; set; }
    }
    public class EscrowSystemUpdateDto
    {
        public string PaymentType { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public DateTimeOffset DispersalCompletionDate { get; set; }
        public decimal EscrowPayout { get; set; }
    }

    public class EscrowSystemsListingDto
    {
        public string PaymentType { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public DateTimeOffset DispersalCompletionDate { get; set; }
        public decimal EscrowPayout { get; set; }
    }
}
