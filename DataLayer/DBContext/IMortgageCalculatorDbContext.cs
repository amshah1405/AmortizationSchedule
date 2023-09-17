using DataLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DBContext
{
    public interface IMortgageCalculatorDBContext
    {
        DbSet<MortgageDetail> MortgageDetail { get; set; }
        DbSet<MonthlyPaymentDetail> MonthlyPaymentDetails { get; set; }
        int SaveChanges();
    }
}
