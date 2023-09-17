using API.Interface;
using API.Model;
using DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MortgageController : ControllerBase
    {
        private readonly IMortgageService _mortgageService;
        public MortgageController(IMortgageService mortgageService)
        {

            _mortgageService = mortgageService;
        }

        [HttpPost("calculate")]
        public IActionResult CalculateMonthlyPayment([FromBody] MortgageRequest request)
        {
            var mortgageDetail = new MortgageDetail(request.loanAmount, request.annualInterestRate, request.loanTerm, request.startDate);
            List<MonthlyPaymentDetail>  monthlyPaymentDetailsList = _mortgageService.CalculateMortgage(mortgageDetail); 
            return Ok(monthlyPaymentDetailsList); 
        }

        [HttpGet("retrieveHistory")]
        public IActionResult GetMortgageHistory()
        {
            throw new NotImplementedException();
        }

        [HttpGet("retrieveAmortizationHistory")]
        public IActionResult GetMortgageAmortizatoinHistory()
        {
            throw new NotImplementedException();
        }
    }
}

