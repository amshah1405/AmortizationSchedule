using DataLayer.DBContext;
using DataLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository
{
    public class MortgageRepository : IMortgageRepository
    {

        private readonly IMortgageCalculatorDBContext _dbContext;
        public MortgageRepository(IMortgageCalculatorDBContext dbContext) { _dbContext = dbContext; }

        public List<MortgageDetail> RetrieveMortgageHistory()
        {
            var retrieveMortgageHistory = _dbContext.MortgageDetail.Include(x => x.mortagePaymentDetails).ToList<MortgageDetail>();
            return retrieveMortgageHistory;

        }

        public int SaveMortgageDetail(MortgageDetail mortgageDetail)
        {
            _dbContext.MortgageDetail.Add(mortgageDetail);
            _dbContext.SaveChanges();

            return mortgageDetail.mortgageID;

        }

    }
}
