using ForiegnExchangeRatesApi.Services.GetExchangeRate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ForiegnExchangeRatesApi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {
        IGetExchangeRateManager _getExchangeRateManager;
        public ExchangeRatesController(IGetExchangeRateManager getExchangeRateManager)
        {
            _getExchangeRateManager=getExchangeRateManager;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetExchangeRate()
        {
            var result = await _getExchangeRateManager.GetAllRates();
            return Ok(result);
        }
        [HttpGet]
        [Route("USD/100/INR")]
        public async Task<IActionResult> UsdToInr()
        {
            var result = await _getExchangeRateManager.UsdToInrConverter();
            if (result == null)
                return NotFound("Currency not found");

            return Ok(result);
        }
        [HttpGet]
        [Route("EUR/100/INR")]
        public async Task<IActionResult> EurToInr()
        {
            var result = await _getExchangeRateManager.EurToInrConverter();
            return Ok(result);
        }
    }
}
