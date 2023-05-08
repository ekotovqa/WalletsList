using WalletsList.Models;
using WalletsList.Services.Interfeces;

namespace WalletsList.Services
{
    public class WalletsService : IWalletsService
    {
        protected readonly HttpClient _httpClient;
        public WalletsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Wallet>> GetAsync(string endPoint)
        {
            var response = await _httpClient.GetAsync(endPoint);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<Wallet>>();
            }
            return Enumerable.Empty<Wallet>();
        }
    }
}
