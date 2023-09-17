

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations; 

namespace DataLayer.Entity
{
    
    public class MortgageDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int mortgageID { get; set; }
        public double loanAmount { get; set; }
        public double annualInterestRate { get; set; }
        public int loanTerm { get; set; }
        public DateTime startDate { get; set; }
        public ICollection<MonthlyPaymentDetail> mortagePaymentDetails { get; } = new List<MonthlyPaymentDetail>();

        public MortgageDetail() { }
        public MortgageDetail(  double loanAmount, double annualInterestRate, int loanTerm, DateTime startDate)
        {  
            this.loanAmount = loanAmount;
            this.annualInterestRate = annualInterestRate;
            this.loanTerm = loanTerm;
            this.startDate= startDate;
        }
          
    }
}
