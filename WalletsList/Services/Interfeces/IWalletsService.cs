using WalletsList.Models;

namespace WalletsList.Services.Interfeces
{
    public interface IWalletsService
    {
        Task<IEnumerable<Wallet>> GetAsync(string endPoint);
    }
}
