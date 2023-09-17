using DataLayer.Entity;

namespace DataLayer.Repository
{
    public interface IMortgageRepository
    {
        int SaveMortgageDetail(MortgageDetail mortgageDetail);

    }
}