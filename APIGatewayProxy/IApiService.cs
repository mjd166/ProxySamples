using Microsoft.VisualBasic;

namespace APIGatewayProxy
{

    /// <summary>
    /// Main subject interface
    /// </summary>
    public interface IApiService
    {
        Task<string> GetDataAsync(string url);
    }


    /// <summary>
    /// Real Subject -Actual api service
    /// </summary>
    public class RealApiService : IApiService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public async Task<string> GetDataAsync(string url)
        {
            Console.WriteLine("Fetching data from the real API...");
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }
    }


    /// <summary>
    /// Proxy
    /// </summary>
    public class ApiServiceProxy : IApiService
    {
        private readonly RealApiService _realApiService = new RealApiService();
        private readonly Dictionary<string, string> _cache = new Dictionary<string, string>();
        private readonly Dictionary<string, DateTime> _requestTimestamps = new Dictionary<string, DateTime>();
        private readonly TimeSpan _rateLimit = TimeSpan.FromSeconds(5);

        public async Task<string> GetDataAsync(string url)
        {
            if (_requestTimestamps.ContainsKey(url) && DateTime.Now - _requestTimestamps[url] < _rateLimit)
            {
                Console.WriteLine("Rate limit exceeded. Please wait before making another request.");
                return "Rate limit exceeded. Try again later.";
            }
            if (_cache.ContainsKey(url))
            {
                Console.WriteLine("Retruning  cached data...");
                return _cache[url];
            }



            var data = await _realApiService.GetDataAsync(url);
            _cache[url] = data;
            _requestTimestamps[url] = DateTime.Now;
            return data;
        }
    }
}
