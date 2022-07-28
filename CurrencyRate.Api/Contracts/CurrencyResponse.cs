namespace CurrencyRate.API.Contracts
{
    public class CurrencyResponse
    {
        /// <summary>
        /// Название валюты.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Курс валюты.
        /// </summary>
        public decimal Value { get; set; }
    }
}
