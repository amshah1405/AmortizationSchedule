namespace API.Model
{
    public class MortgageRequest
    {
        public double loanAmount { get; set; }
        public float annualInterestRate { get; set; }
        public int loanTerm { get; set; }
        public DateTime startDate { get; set; }
    }
}
