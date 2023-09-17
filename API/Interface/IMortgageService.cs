
using DataLayer.Entity;
namespace API.Interface
{
    public interface IMortgageService
    {
        List<MonthlyPaymentDetail> RetrieveMortgageHistory();

        List<MonthlyPaymentDetail> CalculateMortgage(MortgageDetail mortgageDetail);

        void SaveMortgageDetails(MortgageDetail mortgageDetail );


    }
}
