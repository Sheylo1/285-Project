using System;
using System.Collections.Generic;

namespace LearningStarter.Entities
{
    public class EscrowSystems
    {
        public int Id  { get; set; }
        public string PaymentType { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public DateTimeOffset DispersalCompletionDate { get; set; }
        public decimal EscrowPayout { get; set; }
        public List<Bets> Bets { get; set; } = new List<Bets>();



    }

    public class EscrowSystemsGetDto
    {
        public int Id { get; set; }
        public string PaymentType { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public DateTimeOffset DispersalCompletionDate { get; set; }
    }

}
