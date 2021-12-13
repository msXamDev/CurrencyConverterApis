using ForiegnExchangeRatesApi.Models;
using ForiegnExchangeRatesApi.Services.HttpAll;

namespace ForiegnExchangeRatesApi.Services.GetExchangeRate
{
    public class GetExchangeRateManager : IGetExchangeRateManager
    {
        public async Task<Root> GetAllRates()
        {
            return await HttpGet.HttpGetAllRates();
        }
        public async Task<double> UsdToInrConverter()
        {
            return await HttpGet.GetUsdToInr();
        }
        public async Task<double> EurToInrConverter()
        {
            return await HttpGet.GetEurToInr();
        }
    }
}
