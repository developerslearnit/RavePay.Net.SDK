using RavePay.Net.SDK.Entities;
using RavePay.Net.SDK.Entities.VirtualCard;
using RavePay.Net.SDK.Infrastructure;
using RavePay.Net.SDK.Interfaces;
using System.Threading.Tasks;

namespace RavePay.Net.SDK.Services
{
    public class VirtualCardService : IVirtualCard
    {

        private readonly string _secretKey;
        private readonly string _redirect_url;

        public VirtualCardService(string secretKey, string redirect_url)
        {
            _secretKey = secretKey;
            _redirect_url = redirect_url;
        }



        public VCardResponse CreateVirtualCard(string currency, int amount, string billing_name, string billing_address = null, string billing_city = null, string billing_state = null, string billing_postal_code = null, string billing_country = null, string callback_url = null)
        {
            var _client = HttpFactory.InitHttpClient()
                         .WithBaseUri(RaveConstant.BASE_URL)
                         .AddAuthorizationHeader(RaveConstant.AUTHORIZATION_TYPE, _secretKey)
                         .AddMediaType(RaveConstant.REQUEST_MEDIA_TYPE)
                         .AddHeader("cache-control", "no-cache");
        }

        public Task<VCardResponse> CreateVirtualCardAsync(string currency, int amount, string billing_name, string billing_address = null, string billing_city = null, string billing_state = null, string billing_postal_code = null, string billing_country = null, string callback_url = null)
        {
            var _client = HttpFactory.InitHttpClient()
                         .WithBaseUri(RaveConstant.BASE_URL)
                         .AddAuthorizationHeader(RaveConstant.AUTHORIZATION_TYPE, _secretKey)
                         .AddMediaType(RaveConstant.REQUEST_MEDIA_TYPE)
                         .AddHeader("cache-control", "no-cache");
        }

        public VCardList GetAllVirtualCards()
        {
            throw new System.NotImplementedException();
        }

        public Task<VCardList> GetAllVirtualCardsAsync()
        {
            throw new System.NotImplementedException();
        }

        public VCardSingle GetSingleVirtualCard(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<VCardSingle> GetSingleVirtualCardAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
