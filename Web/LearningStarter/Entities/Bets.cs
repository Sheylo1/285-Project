using System;
using System.Collections.Generic;

namespace LearningStarter.Entities
{
    public class Bets
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BetCatagoriesId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int CommentId { get; set; }
        public Boolean BetDisputeCall { get; set; }
        public int EscrowId { get; set; }
        public List<BetTransactions> BetTransactions { get; set; } = new List<BetTransactions>();
        public List<BetDisputes> BetDisputes { get; set; } = new List<BetDisputes>();
        public List<EscrowSystems> EscrowSystems { get; set; } = new List<EscrowSystems>();


    }
    
    public class BetsGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BetCatagoriesId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int CommentId { get; set; }
        public Boolean BetDisputeCall { get; set; }
        public int EscrowId { get; set; }
        public List<BetTransactions> BetTransactions { get; set; } = new List<BetTransactions>();
        public List<BetDisputes> BetDisputes { get; set; } = new List<BetDisputes>();
        public List<EscrowSystems> EscrowSystems { get; set; } = new List<EscrowSystems>();
    }

    public class BetsCreateDto
    {
        public string Name { get; set; }
        public int BetCatagoriesId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int CommentId { get; set; }
        public Boolean BetDisputeCall { get; set; }
        public int EscrowId { get; set; }
        public List<BetTransactions> BetTransactions { get; set; } = new List<BetTransactions>();
        public List<BetDisputes> BetDisputes { get; set; } = new List<BetDisputes>();
        public List<EscrowSystems> EscrowSystems { get; set; } = new List<EscrowSystems>();
    }

    public class BetsUpdateDto
    {
        public string Name { get; set; }
        public int BetCatagoriesId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int CommentId { get; set; }
        public Boolean BetDisputeCall { get; set; }
        public int EscrowId { get; set; }
        public List<BetTransactions> BetTransactions { get; set; } = new List<BetTransactions>();
        public List<BetDisputes> BetDisputes { get; set; } = new List<BetDisputes>();
        public List<EscrowSystems> EscrowSystems { get; set; } = new List<EscrowSystems>();
    }
}
