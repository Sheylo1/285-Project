using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace LearningStarter.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string PaymentType { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public User CreatedByUser { get; set; }
        public int? CreatedByUserId { get; set; }

        public List<TransactionsUser> TransactionsUsers { get; set; } = new List<TransactionsUser>();
        public List<BetTransaction> BetTransactions { get; set; } = new List<BetTransaction>(); 


    }
  public class TransactionGetDto{
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string PaymentType { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public int? CreatedByUserId { get; set; }

    }
    public class TransactionCreateDto
{
        public decimal Amount { get; set; }
        public string PaymentType { get; set; }

        public DateTimeOffset CreatedAt { get; set; }


    }

    public class TransactionUpdateDto
{
        public decimal Amount { get; set; }
        public string PaymentType { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

    }
    public class TransactionListingDto
{
        public decimal Amount { get; set; }
        public string PaymentType { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

    }
}
