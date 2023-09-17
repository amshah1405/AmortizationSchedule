using DataLayer.Entity;

namespace DataLayer
{
    public class MortgageRepository : IMortgageRepository
    {

        private readonly IMortgageCalculatorDBContext _dbContext;
        public MortgageRepository(IMortgageCalculatorDBContext dbContext) { _dbContext = dbContext; }

        public int SaveMortgageDetail(MortgageDetail mortgageDetail)
        {
            _dbContext.MortgageDetail.Add(mortgageDetail);
            _dbContext.SaveChanges();

           return mortgageDetail.mortgageID;

        } 
      
    }
}
