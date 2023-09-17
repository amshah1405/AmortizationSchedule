using DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DataLayer.DBContext
{
    public class MortgageCalculatorDBContext : DbContext, IMortgageCalculatorDBContext
    {
        public MortgageCalculatorDBContext() { }
        public MortgageCalculatorDBContext(DbContextOptions<MortgageCalculatorDBContext> options) : base(options)
        {
        }

        public DbSet<MortgageDetail> MortgageDetail { get; set; }
        public DbSet<MonthlyPaymentDetail> MonthlyPaymentDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=Amotization;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MortgageDetail>()
       .HasMany(e => e.mortagePaymentDetails)
       .WithOne(e => e.mortgageDetail)
       .HasForeignKey(e => e.mortageId);
            base.OnModelCreating(modelBuilder);
        }


    }
}