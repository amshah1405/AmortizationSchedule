using DataLayer.Entity;

namespace DataLayer
{
    public interface IMortgageRepository
    {
        int SaveMortgageDetail(MortgageDetail mortgageDetail);
                
    }
}