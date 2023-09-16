namespace API.Model
{
    public class MortgageRequest
    {
        public double LoanAmount { get; }
        public float AnnualInterestRate { get; }
        public int LoanTerm { get; }
        public DateTime StartDate { get; }
    }
}
