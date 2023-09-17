using API.Interface;
using DataLayer;
using DataLayer.Entity; 
namespace API
{
    public class MortgageService : IMortgageService
    {
        private readonly IMortgageRepository _mortgageRepository;
        public MortgageService(IMortgageRepository mortgageRepository) 
        {
            _mortgageRepository = mortgageRepository;
        }
        public MortgageService()
        {
        } 

        public List<MonthlyPaymentDetail> CalculateMortgage(MortgageDetail mortgageDetail)
        {  
            if(mortgageDetail.loanAmount == 0 || mortgageDetail.annualInterestRate == 0 || mortgageDetail.loanTerm == 0)
                return null;

            List<MonthlyPaymentDetail> monthlyPaymentList = new List<MonthlyPaymentDetail>();

            double monthlyInterestRate = mortgageDetail.annualInterestRate / 1200;
            int loanTermInMonths = mortgageDetail.loanTerm * 12;
            double mathPower = Math.Pow(1 + monthlyInterestRate, loanTermInMonths);
            double monthlyPayment = mortgageDetail.loanAmount * (monthlyInterestRate * mathPower / (mathPower - 1));

            double totalInterest = 0;
            double totalPayment = 0;
            double remainingBalance = mortgageDetail.loanAmount;

            for (int month = 0; month < loanTermInMonths; month++)
            { 
                double monthlyInterestPaid = remainingBalance * monthlyInterestRate;
                double principalAmt = monthlyPayment - monthlyInterestPaid;
                remainingBalance = remainingBalance - principalAmt;
                totalInterest += monthlyInterestPaid;
                totalPayment += monthlyPayment;

                monthlyPaymentList.Add(new MonthlyPaymentDetail(mortgageDetail.startDate.AddMonths(month).Date, Math.Round(remainingBalance,2), Math.Round(principalAmt,2), Math.Round(monthlyInterestPaid,2),
                     Math.Round(monthlyPayment,2), Math.Round(totalInterest,2), Math.Round(totalPayment,2)));

            }

      
            return monthlyPaymentList;
        }

        public List<MonthlyPaymentDetail> RetrieveMortgageHistory()
        {
            throw new NotImplementedException();
        }

        public void SaveMortgageDetails(MortgageDetail mortgageDetail ) {

            int mortgageId = _mortgageRepository.SaveMortgageDetail(mortgageDetail); 
        }

    }
}
