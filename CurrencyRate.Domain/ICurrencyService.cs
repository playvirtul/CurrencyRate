namespace CurrencyRate.Domain
{
    public interface ICurrencyService
    {
        Task<(Currency? Result, string Errors)> Get(string id);

        Task<(List<Currency> Result, string Errors)> Get(PaginationParameters paginationParameters);
    }
}