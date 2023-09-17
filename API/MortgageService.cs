using API.Interface;
using DataLayer;
using DataLayer.Entity; 
namespace API
{
    public class MortgageService : IMortgageService
    {
        private readonly MortgageCalculatorDBContext _dbContext;

        public MortgageService()
        {
        }

        public MortgageService(MortgageCalculatorDBContext dbContext) { _dbContext = dbContext; }

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

            SaveMortgageHistory(mortgageDetail, monthlyPaymentList);

            return monthlyPaymentList;
        }

        public List<MonthlyPaymentDetail> RetrieveMortgageHistory()
        {
            throw new NotImplementedException();
        }

        public void SaveMortgageHistory(MortgageDetail mortgageDetail, List<MonthlyPaymentDetail> monthlyPaymentDetails)
        {
           
            _dbContext.MortgageDetail.Add(mortgageDetail);
            _dbContext.SaveChanges();

            int mortgageId = mortgageDetail.mortgageID;

            foreach(MonthlyPaymentDetail monthlyPaymentDetail in monthlyPaymentDetails) {
                monthlyPaymentDetail.mortageId = mortgageId;
                _dbContext.MonthlyPaymentDetails.Add(monthlyPaymentDetail);
            }
          
            _dbContext.SaveChanges();
        }
    }
}
