using API.Interface;
using API.Model;
using DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
            mortgageDetail.mortagePaymentDetails = monthlyPaymentDetailsList;
            _mortgageService.SaveMortgageDetails(mortgageDetail);
            return StatusCode(StatusCodes.Status201Created, mortgageDetail);
        }

        [HttpGet("retrieveHistory")]
        public IActionResult GetMortgageHistory()
        {
            List<MonthlyPaymentDetail> monthlyPaymentDetailsList = new List<MonthlyPaymentDetail>();
            monthlyPaymentDetailsList.Add(new MonthlyPaymentDetail(DateTime.Today, 159322.65, 677.15, 466.67, 1143.81, 466.67, 1143.81));
            return StatusCode(StatusCodes.Status200OK,  monthlyPaymentDetailsList);
        }

        
    }
}

