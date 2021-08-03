using RavePay.Net.SDK.Entities.VirtualCard;
using System.Threading.Tasks;

namespace RavePay.Net.SDK.Interfaces
{
    public interface IVirtualCard
    {


        Task<VCardResponse> CreateVirtualCardAsync(string currency, int amount, string billing_name,
             string billing_address = null, string billing_city = null, string billing_state = null,
              string billing_postal_code = null, string billing_country = null, string callback_url = null);

        VCardResponse CreateVirtualCard(string currency, int amount, string billing_name,
            string billing_address = null, string billing_city = null, string billing_state = null,
             string billing_postal_code = null, string billing_country = null, string callback_url = null);

        Task<VCardList> GetAllVirtualCardsAsync();

        VCardList GetAllVirtualCards();

        Task<VCardSingle> GetSingleVirtualCardAsync(string id);

        VCardSingle GetSingleVirtualCard(string id);
    }
}
