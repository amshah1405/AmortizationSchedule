using DataLayer.Entity;
using Microsoft.EntityFrameworkCore; 

namespace DataLayer
{
    public interface IMortgageCalculatorDBContext
    {
         DbSet<MortgageDetail> MortgageDetail { get; set; }
         DbSet<MonthlyPaymentDetail> MonthlyPaymentDetails { get;set; }
        int SaveChanges();
    }
}
