using API.Interface;
using API.Model; 
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
            throw new NotImplementedException();

        }

        [HttpGet("retrieveHistory")]
        public IActionResult GetMortgageHistory()
        {
            throw new NotImplementedException();
        }
    }
}

