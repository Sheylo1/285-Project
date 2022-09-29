using LearningStarter.Entities;
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
        public DbSet<Bet> Bets { get; set; }
        public DbSet<BetDispute> BetDisputes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<BetTransaction> BetTransactions { get; set; }
        public DbSet<TransactionsUser> TransactionsUsers { get; set; }
        public DbSet<BetCategory> BetCategories { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<HouseSystem> HouseSystems { get; set; }
        public DbSet<EscrowSystem> EscrowSystems { get; set; }
        public DbSet<Position> Positions { get; set; }
		public DbSet<Post> Posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BetDispute>()
            //.HasOne(property => property.Employee)
            //.WithMany(Employee => Employee.BetDisputes)
            //.HasForeignKey(emp => emp.EmployeeId)
            //.OnDelete(DeleteBehavior.NoAction);

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
