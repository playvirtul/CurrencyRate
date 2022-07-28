using System.ComponentModel.DataAnnotations;

namespace CurrencyRate.API.Contracts
{
    public class SearchParameters
    {
        /// <summary>
        /// Номер страницы, которую нужно отобразить.
        /// </summary>
        [Required]
        public int PageNumber { get; set; }

        /// <summary>
        /// Размер страницы.
        /// </summary>
        [Required]
        public int PageSize { get; set; }
    }
}
