using CurrencyRate.Domain;
using Newtonsoft.Json;

namespace CurrencyRate.BusinessLogic
{
    public class CurrencyService : ICurrencyService
    {
        public async Task<(Currency? Result, string Errors)> Get(string id)
        {
            var fileData = new FileData("https://www.cbr-xml-daily.ru/daily_json.js");

            var jsonString = await fileData.DownloadWebFile();

            if (string.IsNullOrEmpty(jsonString))
            {
                return (null, new string("Не удалось получить данные."));
            }

            var currencyInfo = JsonConvert.DeserializeObject<CurrencyInfo>(jsonString);

            if (currencyInfo == null)
            {
                return (null, new string("Не удалось получить данные."));
            }

            var currency = currencyInfo.CurrenciesList.Values.SingleOrDefault(x => x.Id == id);

            if (currency == null)
            {
                return (null, new string("Не удалось найти валюту с таким Id"));
            }

            return (currency, string.Empty);
        }

        public async Task<(List<Currency> Result, string Errors)> Get(PaginationParameters paginationParameters)
        {
            var fileData = new FileData("https://www.cbr-xml-daily.ru/daily_json.js");

            var jsonString = await fileData.DownloadWebFile();

            if (string.IsNullOrEmpty(jsonString))
            {
                return (Array.Empty<Currency>().ToList(), new string("Не удалось получить данные."));
            }

            var currencyInfo = JsonConvert.DeserializeObject<CurrencyInfo>(jsonString);

            if (currencyInfo == null)
            {
                return (Array.Empty<Currency>().ToList(), new string("Не удалось получить данные."));
            }

            var currencies = currencyInfo.CurrenciesList.Values
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToList();

            if (currencies == null)
            {
                return (Array.Empty<Currency>().ToList(), new string("Не удалось получить данные."));
            }

            return (currencies, string.Empty);
        }
    }
}