using CurrencyRate.API.Contracts;
using CurrencyRate.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyRate.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        /// <summary>
        /// Инициализирует новый экземпляр класса CurrencyController.
        /// </summary>
        /// <param name="currencyService"></param>
        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        /// <summary>
        /// Запрос на получение курса валюту по id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Возвращает название валюты и курс.</returns>
        [HttpGet("currency")]
        public async Task<IActionResult> Get(string id)
        {
            var (currency, error) = await _currencyService.Get(id);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var currencyResponse = new CurrencyResponse
            {
                Name = currency.Name,
                Value = currency.Value
            };

            return Ok(currencyResponse);
        }

        /// <summary>
        /// Запрос на получение списка валюты с пагинацией.
        /// </summary>
        /// <param name="searchParameters"></param>
        /// <returns>Возвращает определённое количество валют.</returns>
        [HttpGet("currencies")]
        public async Task<IActionResult> Get([FromQuery] SearchParameters searchParameters)
        {
            var paginationParameters = new PaginationParameters
            {
                PageNumber = searchParameters.PageNumber,
                PageSize = searchParameters.PageSize
            };

            var (currencies, error) = await _currencyService.Get(paginationParameters);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var currenciesResponce = currencies
                .Select(x => new CurrencyResponse
                {
                    Name = x.Name,
                    Value = x.Value
                })
                .ToList();

            return Ok(currenciesResponce);
        }
    }
}
