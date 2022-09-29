using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace LearningStarter.Entities
{
    public class BetTransaction
    {
        public int Id { get; set; }

        public int BetId { get; set; } 
        public Bet Bet { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset FinishedAt { get; set; }

        public decimal Amount { get; set; }

        public string Result { get; set; }

        public int HouseSystemId { get; set; }
        public HouseSystem HouseSystem { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }


    }

    public class BetTransactionsGetDto 
    {
        public int Id { get; set; }

        public int BetId { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset FinishedAt { get; set; }

        public decimal Amount { get; set; }

        public string Result { get; set; }

        public int HouseSystemId { get; set; }

        public int UserId { get; set; }

        public int EmployeeId { get; set; }

        public int TransactionId { get; set; }

    }

    public class BetTransactionsCreateDto
    {
        public int BetId { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset FinishedAt { get; set; }

        public decimal Amount { get; set; }

        public string Result { get; set; }

        public int HouseSystemId { get; set; }

        public int UserId { get; set; }

        public int EmployeeId { get; set; }

        public int TransactionId { get; set; }
    }

    public class BetTransactionUpdateDto
    {
        public int BetId { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset FinishedAt { get; set; }

        public decimal Amount { get; set; }

        public string Result { get; set; }

        public int HouseSystemId { get; set; }

        public int UserId { get; set; }

        public int EmployeeId { get; set; }

        public int TransactionId { get; set; }
    }

    public class BetTransactionListingDto
    {
        public int BetId { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset FinishedAt { get; set; }

        public decimal Amount { get; set; }

        public string Result { get; set; }

        public int HouseSystemId { get; set; }

        public int UserId { get; set; }

        public int EmployeeId { get; set; }

        public int TransactionId { get; set; }
    }
}
