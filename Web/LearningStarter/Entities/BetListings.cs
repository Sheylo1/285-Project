using System;

namespace LearningStarter.Entities
{
    public class BetListings
    {
        public int Id { get; set; }
        public string NameOfBet { get; set; }
        public string NameCategory { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset EndedAt { get; set; }
        public string Comments { get; set; }
        public string BetDisputeCall { get; set; }


    }

    public class BetListingsGetDto
    {
        public int Id { get; set; }
        public string NameOfBet { get; set; }
        public string NameCategory { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset EndedAt { get; set; }
        public string Comments { get; set; }
        public string BetDisputeCall { get; set; }


    }

    public class BestListingsCreateDto
    {
        public string NameOfBet { get; set; }
        public string NameCategory { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset EndedAt { get; set; }
        public string Comments { get; set; }
        public string BetDisputeCall { get; set; }
    }

    public class BetListingsUpdateDto
    {
        public string NameOfBet { get; set; }
        public string NameCategory { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset EndedAt { get; set; }
        public string Comments { get; set; }
        public string BetDisputeCall { get; set; }
    }

}
