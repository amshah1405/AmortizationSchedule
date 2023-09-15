namespace API.Model
{
    public class MortgageRequest
    {
        public decimal LoanAmount { get; }
        public decimal AnnualInterestRate { get; }
        public int LoanTermInMonths { get; }
        public DateTime StartDate { get; }
    }
}
