namespace CurrencyRate.Domain
{
    public class FileData
    {
        public Uri Uri { get; }

        public FileData(string uri)
        {
            if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            {
                throw new ArgumentException("Ссылка неверного формата");
            }

            Uri = new Uri(uri);
        }

        public async Task<string> DownloadWebFile()
        {
            using var client = new HttpClient();

            using var result = await client.GetAsync(Uri);

            if (!result.IsSuccessStatusCode)
            {
                return string.Empty;
            }

            return await result.Content.ReadAsStringAsync();
        }
    }
}
