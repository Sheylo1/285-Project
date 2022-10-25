using System;
using System.Collections.Generic;

namespace LearningStarter.Entities
{
    public class Bet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BetCategoryId { get; set; }
        public BetCategory BetCategory { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        public Boolean BetDisputeCall { get; set; }
        public int EscrowSystemId { get; set; }
        public EscrowSystem EscrowSystem { get; set; }
        public List<BetTransaction> BetTransactions { get; set; } = new List<BetTransaction>();
        public List<BetDispute> BetDisputes { get; set; } = new List<BetDispute>();
    }
    
    public class BetGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BetCategoryId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int CommentId { get; set; }
        public bool BetDisputeCall { get; set; }
        public int EscrowSystemId { get; set; }
        
    }

    public class BetCreateDto
    {
        public string Name { get; set; }
        public int BetCategoryId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int CommentId { get; set; }
        public bool BetDisputeCall { get; set; }
        public int EscrowSystemId { get; set; }
        
    }

    public class BetUpdateDto
    {
        public string Name { get; set; }
        public int BetCategoryId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int CommentId { get; set; }
        public bool BetDisputeCall { get; set; }
        public int EscrowId { get; set; }
        
    }

    public class BetListingDto
    {
        public string Name { get; set; }
        public int BetCategoryId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ClosedDate { get; set; }
        public int CommentId { get; set; }
        public bool BetDisputeCall { get; set; }
        public int EscrowId { get; set; }
    }
}
