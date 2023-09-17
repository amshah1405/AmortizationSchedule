
using DataLayer.Entity;
namespace API.Interface
{
    public interface IMortgageService
    {
        List<MonthlyPaymentDetail> RetrieveMortgageHistory();

        List<MonthlyPaymentDetail> CalculateMortgage(MortgageDetail mortgageDetail);

        void SaveMortgageHistory(MortgageDetail mortgageDetail, List<MonthlyPaymentDetail> monthlyPaymentDetails);
    }
}
