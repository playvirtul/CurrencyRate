using Newtonsoft.Json;

namespace CurrencyRate.Domain
{
    public class CurrencyInfo
    {
        [JsonProperty("Valute")]
        public Dictionary<string, Currency> CurrenciesList { get; set;  } = new Dictionary<string, Currency>();
    }
}
