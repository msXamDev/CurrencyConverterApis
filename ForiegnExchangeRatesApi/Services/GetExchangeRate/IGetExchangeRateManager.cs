using ForiegnExchangeRatesApi.Models;

namespace ForiegnExchangeRatesApi.Services.GetExchangeRate
{
    public interface IGetExchangeRateManager
    {
        public Task<Root> GetAllRates();
        public Task<double> UsdToInrConverter();
        public Task<double> EurToInrConverter();
    }
}
