using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

namespace PaymentAPI.Context
{
    public class PaymentContext : DbContext
    {
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Payble> Payble { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=dbPayment.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<Payble>()
            .HasOne(p => p.Transaction)
            .WithMany(t => t.Payble)
            .HasForeignKey(p => p.TransactionId);
        }
    }
}