

using System.Diagnostics;

namespace DataLayer.Entity
{
    
    public class MortgageDetail
    {
     
      //  public int MortgageID { get; }
        public double loanAmount { get; }
        public double annualInterestRate { get; }
        public int loanTerm { get; }
        public DateTime startDate { get; }

        public MortgageDetail(  double loanAmount, double annualInterestRate, int loanTerm, DateTime startDate)
        {
            // MortgageID = mortgageID;
            this.loanAmount = loanAmount;
            this.annualInterestRate = annualInterestRate;
            this.loanTerm = loanTerm;
            this.startDate= startDate;
        }
          
    }
}
