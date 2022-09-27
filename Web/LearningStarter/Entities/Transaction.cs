using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace LearningStarter.Entities
{
    public class Transaction
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public decimal Amount { get; set; }
        public string PaymentType { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public List<TransactionsUser> TransactionsUsers { get; set; } = new List<TransactionsUser>();


    }
  public class TransactionGetDto{
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentType { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

    }
    public class TransactionCreateDto
{
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentType { get; set; }

        public DateTimeOffset CreatedAt { get; set; }


    }

    public class TransactionUpdateDto
{
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentType { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

    }
    public class TransactionListingDto
{
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentType { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

    }
}
