using ForiegnExchangeRatesApi.Models;
using Newtonsoft.Json;

namespace ForiegnExchangeRatesApi.Services.HttpAll
{
    public class HttpGet
    {
        //private static readonly List<Root>? root;
        private static Root? _root;
        public static string? json { get; set; }

        public async static Task<Root> HttpGetAllRates()
        {
            _root = new Root(); 
            const string endpoint = "latest";
            const string access_key = "9a8d6c7c917510f61be6857714870e16";
            using (var client = new HttpClient())
            {
                var url= "http://data.fixer.io/api/" + endpoint + "?access_key=" + access_key + "&format=1";
                var response = await client.GetAsync(url);
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }
                _root= JsonConvert.DeserializeObject<Root>(json)!;
                var fCurrency = _root.rates;
                
                return _root;
            }
        }

        public async static Task<double> GetUsdToInr()
        {
            _root = new Root();
            await HttpGetAllRates();
            _root = JsonConvert.DeserializeObject<Root>(json!);
            var USDToINR = _root.rates.INR / _root.rates.USD * 100;
            return USDToINR;
        }

        public async static Task<double> GetEurToInr()
        {
            _root = new Root();
            await HttpGetAllRates();
            _root = JsonConvert.DeserializeObject<Root>(json!);
            var EURToINR = _root.rates.INR/_root.rates.EUR * 100;
            return EURToINR;
        }
    }
}
