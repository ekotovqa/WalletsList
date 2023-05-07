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
            return await _httpClient.GetFromJsonAsync<IEnumerable<Wallet>>(endPoint);
        }
    }
}
