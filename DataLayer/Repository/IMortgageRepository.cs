using DataLayer.Entity;

namespace DataLayer.Repository
{
    public interface IMortgageRepository
    {
        List<MortgageDetail> RetrieveMortgageHistory();
        int SaveMortgageDetail(MortgageDetail mortgageDetail);

    }
}