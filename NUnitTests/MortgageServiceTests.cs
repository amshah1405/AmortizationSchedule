using API;
using API.Interface;
using DataLayer.Entity;

namespace NUnitTests
{
    public class MortgageServiceTests
    {
        private IMortgageService mortgageService;

        [SetUp]
        public void Setup()
        {
            mortgageService = new MortgageService();
        }

        [Test]
        public void CalculateMortgage_ReturnsNullForZeroLoanAmount()
        {
            MortgageDetail mortgageDetail = new MortgageDetail(0, 5.0, 10, DateTime.Now);
            List<MonthlyPaymentDetail> monthlyPayments = mortgageService.CalculateMortgage(mortgageDetail);
            Assert.IsNull(monthlyPayments);
        }

        [Test]
        public void CalculateMortgage_ReturnsNullForZeroInterestRate()
        {

            MortgageDetail mortgageDetail = new MortgageDetail(10000, 0, 10, DateTime.Now);
            List<MonthlyPaymentDetail> monthlyPayments = mortgageService.CalculateMortgage(mortgageDetail);
            Assert.IsNull(monthlyPayments);
        }

        [Test]
        public void CalculateMortgage_ReturnsNullForZeroLoanTerm()
        {

            MortgageDetail mortgageDetail = new MortgageDetail(10000, 5.0, 0, DateTime.Now);
            List<MonthlyPaymentDetail> monthlyPayments = mortgageService.CalculateMortgage(mortgageDetail);
            Assert.IsNull(monthlyPayments);
        }

        [Test]
        public void CalculateMortgage_ReturnsCorrectNumberOfMonthlyPayments()
        {

            MortgageDetail mortgageDetail = new MortgageDetail(100000, 5.0, 30, DateTime.Now);
            List<MonthlyPaymentDetail> monthlyPayments = mortgageService.CalculateMortgage(mortgageDetail);
            Assert.That(monthlyPayments.Count, Is.EqualTo(360));
        } 
    }
}