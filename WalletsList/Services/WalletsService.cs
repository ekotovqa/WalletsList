using Microsoft.Extensions.Options;
using WalletsList.Models;
using WalletsList.Services.Interfeces;

namespace WalletsList.Services
{
    public class WalletsService : IWalletsService
    {
        protected readonly HttpClient _httpClient;
        public WalletsService(IOptions<AppSettings> options)
        {
            _httpClient = new HttpClient() { BaseAddress = options.Value.ApiBaseUrl };
        }

        public async Task<IEnumerable<Wallet>> GetAsync(string endPoint)
        {
            try
            {
                var response = await _httpClient.GetAsync(endPoint);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<Wallet>>();
                }
                return Enumerable.Empty<Wallet>();
            }
            catch (Exception)
            {
                return Enumerable.Empty<Wallet>();
                throw;
            }
            
        }
    }
}
