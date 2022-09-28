using System;
using System.Collections.Generic;

namespace LearningStarter.Entities
{
    public class Bets
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BetCatagoriesId { get; set; }
        public BetCategory BetCatagories { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        public Boolean BetDisputeCall { get; set; }
        public int EscrowId { get; set; }
        public EscrowSystems Escrow { get; set; }
        public List<BetTransaction> BetTransactions { get; set; } = new List<BetTransaction>();
        public List<BetDisputes> BetDisputes { get; set; } = new List<BetDisputes>();
    }
    
    public class BetsGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BetCatagoriesId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int CommentId { get; set; }
        public bool BetDisputeCall { get; set; }
        public int EscrowId { get; set; }
        
    }

    public class BetsCreateDto
    {
        public string Name { get; set; }
        public int BetCatagoriesId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int CommentId { get; set; }
        public bool BetDisputeCall { get; set; }
        public int EscrowId { get; set; }
        
    }

    public class BetsUpdateDto
    {
        public string Name { get; set; }
        public int BetCatagoriesId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int CommentId { get; set; }
        public bool BetDisputeCall { get; set; }
        public int EscrowId { get; set; }
        
    }

    public class BetsListingDto
    {
        public string Name { get; set; }
        public int BetCatagoriesId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int CommentId { get; set; }
        public bool BetDisputeCall { get; set; }
        public int EscrowId { get; set; }
    }
}
