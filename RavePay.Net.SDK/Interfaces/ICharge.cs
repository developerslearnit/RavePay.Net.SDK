using RavePay.Net.SDK.Entities.Charge;
using System.Threading.Tasks;

namespace RavePay.Net.SDK.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICharge
    {
        Task<ChargCardResponse> ChargeCardAsync(string card_number, string cvv, string expiry_month,
            string expiry_year, string currency, string amount, string email, string fullname, string tx_ref, string redirect_url, string encryptionKey);

        ChargCardResponse ChargeCard(string card_number, string cvv, string expiry_month,
           string expiry_year, string currency, string amount, string email, string fullname, string tx_ref, string redirect_url, string encryptionKey);

        Task<ChargCardResponse> ChargeCardAsync(string encryptedPayload);

        ChargCardResponse ChargeCard(string encryptedPayload);

    }
}
