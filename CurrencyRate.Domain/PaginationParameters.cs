namespace CurrencyRate.Domain
{
    public class PaginationParameters
    {
        private const int MAX_PAGE_SIZE = 5;

        private int _pageSize;

        public int PageSize
        {
            get { return _pageSize; }

            set
            {
                _pageSize = (value > MAX_PAGE_SIZE) ? MAX_PAGE_SIZE : value;
            }
        }

        public int PageNumber { get; set; } = 1;
    }
}