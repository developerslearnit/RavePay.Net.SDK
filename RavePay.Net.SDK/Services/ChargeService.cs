using Newtonsoft.Json;
using RavePay.Net.SDK.Entities;
using RavePay.Net.SDK.Entities.Charge;
using RavePay.Net.SDK.Helpers;
using RavePay.Net.SDK.Infrastructure;
using RavePay.Net.SDK.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RavePay.Net.SDK.Services
{
    public class ChargeService : ICharge
    {
        private readonly string _secretKey;
        private readonly string _redirect_url;

        public ChargeService(string secretKey, string redirect_url)
        {
            _secretKey = secretKey;
            _redirect_url = redirect_url;
        }

        public async Task<ChargCardResponse> ChargeCardAsync(string card_number, string cvv, string expiry_month, string expiry_year, string currency, string amount, string email, string fullname, string tx_ref, string redirect_url, string encryptionKey)
        {
            var _client = HttpFactory.InitHttpClient()
                          .WithBaseUri(RaveConstant.BASE_URL)
                          .AddAuthorizationHeader(RaveConstant.AUTHORIZATION_TYPE, _secretKey)
                          .AddMediaType(RaveConstant.REQUEST_MEDIA_TYPE)
                          .AddHeader("cache-control", "no-cache");

            var model = new ChargeCardModel()
            {
                amount = amount,
                card_number = card_number,
                currency = currency,
                cvv = cvv,
                email = email,
                expiry_month = expiry_month,
                expiry_year = expiry_year,
                redirect_url = redirect_url,
                tx_ref = tx_ref,
                type = "card"
            };

            var rawString = JsonConvert.SerializeObject(model);

            rawString = EncryptionUtil.Encrypt(rawString, encryptionKey);

            var rawBody = new
            {
                client = rawString
            };

            var jsonRequestBody = JsonConvert.SerializeObject(rawBody);

            var requestContent = new StringContent(jsonRequestBody, Encoding.UTF8, RaveConstant.REQUEST_MEDIA_TYPE);

            requestContent.Headers.ContentType = new MediaTypeHeaderValue(RaveConstant.REQUEST_MEDIA_TYPE);

            //send the request
            var response = await _client.PostAsync("charges?type=card", requestContent);

            var json = await response.Content.ReadAsStringAsync();

            //Deserialize and send the response
            return JsonConvert.DeserializeObject<ChargCardResponse>(json);
        }

        public ChargCardResponse ChargeCard(string card_number, string cvv, string expiry_month, string expiry_year, string currency, string amount, string email, string fullname, string tx_ref, string redirect_url, string encryptionKey)
        {
            var _client = HttpFactory.InitHttpClient()
                          .WithBaseUri(RaveConstant.BASE_URL)
                          .AddAuthorizationHeader(RaveConstant.AUTHORIZATION_TYPE, _secretKey)
                          .AddMediaType(RaveConstant.REQUEST_MEDIA_TYPE)
                          .AddHeader("cache-control", "no-cache");

            var model = new ChargeCardModel()
            {
                amount = amount,
                card_number = card_number,
                currency = currency,
                cvv = cvv,
                email = email,
                expiry_month = expiry_month,
                expiry_year = expiry_year,
                redirect_url = redirect_url,
                tx_ref = tx_ref,
                type = "card"
            };

            var rawString = JsonConvert.SerializeObject(model);

            rawString = EncryptionUtil.Encrypt(rawString, encryptionKey);

            var rawBody = new
            {
                client = rawString
            };

            var jsonRequestBody = JsonConvert.SerializeObject(rawBody);

            var requestContent = new StringContent(jsonRequestBody, Encoding.UTF8, RaveConstant.REQUEST_MEDIA_TYPE);

            requestContent.Headers.ContentType = new MediaTypeHeaderValue(RaveConstant.REQUEST_MEDIA_TYPE);

            //send the request
            var response = Task.Run(() => _client.PostAsync("charges?type=card", requestContent)).Result;

            var json = Task.Run(() => response.Content.ReadAsStringAsync()).Result;

            //Deserialize and send the response
            return JsonConvert.DeserializeObject<ChargCardResponse>(json);
        }

        public async Task<ChargCardResponse> ChargeCardAsync(string encryptedPayload)
        {
            var _client = HttpFactory.InitHttpClient()
                          .WithBaseUri(RaveConstant.BASE_URL)
                          .AddAuthorizationHeader(RaveConstant.AUTHORIZATION_TYPE, _secretKey)
                          .AddMediaType(RaveConstant.REQUEST_MEDIA_TYPE)
                          .AddHeader("cache-control", "no-cache");


            var rawBody = new
            {
                client = encryptedPayload
            };

            var jsonRequestBody = JsonConvert.SerializeObject(rawBody);

            var requestContent = new StringContent(jsonRequestBody, Encoding.UTF8, RaveConstant.REQUEST_MEDIA_TYPE);

            requestContent.Headers.ContentType = new MediaTypeHeaderValue(RaveConstant.REQUEST_MEDIA_TYPE);

            //send the request
            var response = await _client.PostAsync("charges?type=card", requestContent);

            var json = await response.Content.ReadAsStringAsync();

            //Deserialize and send the response
            return JsonConvert.DeserializeObject<ChargCardResponse>(json);
        }

        public ChargCardResponse ChargeCard(string encryptedPayload)
        {
            var _client = HttpFactory.InitHttpClient()
                         .WithBaseUri(RaveConstant.BASE_URL)
                         .AddAuthorizationHeader(RaveConstant.AUTHORIZATION_TYPE, _secretKey)
                         .AddMediaType(RaveConstant.REQUEST_MEDIA_TYPE)
                         .AddHeader("cache-control", "no-cache");


            var rawBody = new
            {
                client = encryptedPayload
            };

            var jsonRequestBody = JsonConvert.SerializeObject(rawBody);

            var requestContent = new StringContent(jsonRequestBody, Encoding.UTF8, RaveConstant.REQUEST_MEDIA_TYPE);

            requestContent.Headers.ContentType = new MediaTypeHeaderValue(RaveConstant.REQUEST_MEDIA_TYPE);

            //send the request
            var response = Task.Run(() => _client.PostAsync("charges?type=card", requestContent)).Result;

            var json = Task.Run(() => response.Content.ReadAsStringAsync()).Result;

            //Deserialize and send the response
            return JsonConvert.DeserializeObject<ChargCardResponse>(json);
        }




    }
}
