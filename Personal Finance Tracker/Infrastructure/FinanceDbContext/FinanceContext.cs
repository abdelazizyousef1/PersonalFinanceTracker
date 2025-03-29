using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Personal_Finance_Tracker.Domin;
namespace Personal_Finance_Tracker.Infrastructure.FinanceDbContext
{
    public class FinanceContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public FinanceContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Transaction>().HasOne(t => t.User).WithMany(u => u.transactions).HasForeignKey(t=>t.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Transaction>().HasOne(t=>t.Receiver).WithMany().HasForeignKey(t=>t.ReceiverId).OnDelete(DeleteBehavior.Restrict);
        }
        

    }
}


