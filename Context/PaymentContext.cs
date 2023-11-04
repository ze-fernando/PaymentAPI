using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

namespace PaymentAPI.Context
{
    public class PaymentContext : DbContext
    {
        public DbSet<Transactions> transactions { get; set; }
        public DbSet<Payble> payble { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=dbPayment.db");
        }
    }
}