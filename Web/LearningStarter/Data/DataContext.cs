﻿using LearningStarter.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningStarter.Data
{
    public sealed class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bets> Bet { get; set; }
        public DbSet<BetDisputes> BetDisputes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<BetTransaction> BetTransactions { get; set; }
        public DbSet<TransactionsUser> TransactionssUsers { get; set; }
        public DbSet<BetCategory> BetCategories { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<HouseSystem> HouseSystems { get; set; }
        public DbSet<EscrowSystems> EscrowSystems { get; set; }
        public DbSet<Position> Positions { get; set; }
		public DbSet<Post> Posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.FirstName)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.LastName)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Username)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Password)
                .IsRequired();
        }
    }
}
