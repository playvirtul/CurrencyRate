using Newtonsoft.Json;

namespace CurrencyRate.Domain
{
    public class Currency
    {
        [JsonProperty("ID")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Value")]
        public decimal Value { get; set; }
    }
}
