
using System.Text.Json.Serialization;

namespace WalletsList.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public decimal? Balance { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
