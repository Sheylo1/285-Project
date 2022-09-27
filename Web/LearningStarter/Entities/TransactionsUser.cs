﻿namespace LearningStarter.Entities
{
    public class TransactionsUser
    {
        public int Id { get; set; }

        public int TransactionsId { get; set; }
        public Transaction Transaction { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public decimal Amount { get; set; }

    }

    public class TransactionUserGetDto
    {
        public int Id { get; set; }

        public int TransactionsId { get; set; }

        public int UserId { get; set; }

        public decimal Amount { get; set; }
    }

    public class TransactionUserCreateDto
    {

        public int TransactionsId { get; set; }

        public int UserId { get; set; }

        public decimal Amount { get; set; }
    }

    public class TransactionUpdateDto
    {
        public int TransactionsId { get; set; }

        public int UserId { get; set; }

        public decimal Amount { get; set; }
    }

    public class TransactionListingDto
    {
        public int TransactionsId { get; set; }

        public int UserId { get; set; }

        public decimal Amount { get; set; }
    }
}
