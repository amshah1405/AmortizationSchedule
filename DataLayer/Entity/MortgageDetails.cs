 

namespace DataLayer.Entity
{
    public class MortgageDetail
    {
        public int MortgageID { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal AnnualInterestRate { get; set; }
        public int LoanTermInMonths { get; set; }
        public DateTime StartDate { get; set; }
    }
}
