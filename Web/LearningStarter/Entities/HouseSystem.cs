using System;
using System.Collections.Generic;

namespace LearningStarter.Entities
{
    public class HouseSystem
    {
        public int Id { get; set; }
        public decimal Payout { get; set; }
        public decimal BetPercentage { get; set; }

        public List<BetTransaction> BetTransactions { get; set; } = new List<BetTransaction>();
    }
    public class HouseSystemGetDto
    {
        public int Id { get; set; }
        public decimal Payout { get; set; }
        public decimal BetPercentage { get; set; }
    }
     public class HouseSystemCreateDto
    {
        public decimal Payout { get; set; }
        public decimal BetPercentage { get; set; }
    }

      public class HouseSystemUpdateDto
    {
        public decimal Payout { get; set; }
        public decimal BetPercentage { get; set; }
    }

       public class HouseSystemListingDto
    {
        public decimal Payout { get; set; }
        public decimal BetPercentage { get; set; }
    }



}
