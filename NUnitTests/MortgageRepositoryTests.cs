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
            var mortgageDetail = new MortgageDetail
            { 
                loanAmount = 100000,
                annualInterestRate = 5.0,
                loanTerm = 30,
                startDate = DateTime.Now,
                mortagePaymentDetails = new List<MonthlyPaymentDetail>()
            };

            _mockDBContext.Setup(db => db.MortgageDetail.Add(It.IsAny<MortgageDetail>())).Verifiable();
            _mockDBContext.Setup(db => db.SaveChanges()).Returns(1);

          
            int mortgageId = _mortgageRepository.SaveMortgageDetail(mortgageDetail); 
            _mockDBContext.Verify(db => db.MortgageDetail.Add(mortgageDetail), Times.Once);
            _mockDBContext.Verify(db => db.SaveChanges(), Times.Once);
        }

 
    }

}
