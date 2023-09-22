using DataLayer.DBContext;
using DataLayer.Entity;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Moq;

namespace NUnitTests
{
    public class MortgageRepositoryTests
    {

        private Mock<IMortgageCalculatorDBContext> _mockDBContext;
        private MortgageRepository _mortgageRepository;

        [SetUp]
        public void Setup()
        {

            _mockDBContext = new Mock<IMortgageCalculatorDBContext>();
            _mortgageRepository = new MortgageRepository(_mockDBContext.Object);
        }

        [Test]
        public void SaveMortgageDetail_ValidInput()
        {
            var mortgageDetailDbSetMock = new Mock<DbSet<MortgageDetail>>();
            _mockDBContext.Setup(db => db.MortgageDetail).Returns(mortgageDetailDbSetMock.Object);

            var mortgageDetail = new MortgageDetail
            {
                loanAmount = 100000,
                annualInterestRate = 5.0,
                loanTerm = 30,
                startDate = DateTime.Now,
                mortagePaymentDetails = new List<MonthlyPaymentDetail>()
            };
            int result = _mortgageRepository.SaveMortgageDetail(mortgageDetail);


            Assert.That(result, Is.EqualTo(mortgageDetail.mortgageID));
        }

        [Test]
        public void RetrieveMortgageHistory_ReturnsListOfMortgageDetails()
        {
            var mortgageDetails = new List<MortgageDetail>
            {
                new MortgageDetail { mortgageID = 1, loanAmount = 100000, annualInterestRate = 4.5, loanTerm = 30, startDate = DateTime.Now },
                new MortgageDetail { mortgageID = 2, loanAmount = 150000, annualInterestRate = 4.0, loanTerm = 15, startDate = DateTime.Now }
            }.AsQueryable();

            // Mock DbSet<MortgageDetail>
            var mortgageDetailDbSetMock = new Mock<DbSet<MortgageDetail>>();
            mortgageDetailDbSetMock.As<IQueryable<MortgageDetail>>().Setup(m => m.Provider).Returns(mortgageDetails.Provider);
            mortgageDetailDbSetMock.As<IQueryable<MortgageDetail>>().Setup(m => m.Expression).Returns(mortgageDetails.Expression);
            mortgageDetailDbSetMock.As<IQueryable<MortgageDetail>>().Setup(m => m.ElementType).Returns(mortgageDetails.ElementType);
            mortgageDetailDbSetMock.As<IQueryable<MortgageDetail>>().Setup(m => m.GetEnumerator()).Returns(mortgageDetails.GetEnumerator());

            // Set up the mock for IMortgageCalculatorDBContext
            _mockDBContext.Setup(db => db.MortgageDetail).Returns(mortgageDetailDbSetMock.Object);

            var mortgageRepository = new MortgageRepository(_mockDBContext.Object);


            List<MortgageDetail> result = mortgageRepository.RetrieveMortgageHistory();

            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(2)); // Adjust this based on your actual data
        } 
        
    }


}

