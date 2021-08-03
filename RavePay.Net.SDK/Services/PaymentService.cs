using Newtonsoft.Json;
using RavePay.Net.SDK.Entities;
using RavePay.Net.SDK.Entities.Payment;
using RavePay.Net.SDK.Infrastructure;
using RavePay.Net.SDK.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RavePay.Net.SDK.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class PaymentService : IPayment
    {
        #region Fields
        private readonly string _secretKey;
        private readonly string _coytitle;
        private readonly string _coyDescription;
        private readonly string _coyLogoUrl;
        private readonly string _redirect_url;
        #endregion

        #region Ctor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="secretKey"></param>
        /// <param name="redirect_url"></param>
        /// <param name="coytitle"></param>
        /// <param name="coyDescription"></param>
        /// <param name="coyLogoUrl"></param>
        public PaymentService(string secretKey, string redirect_url, string coytitle, string coyDescription, string coyLogoUrl)
        {
            this._secretKey = secretKey;
            _coyDescription = coyDescription;
            _coyLogoUrl = coyLogoUrl;
            _coytitle = coytitle;
            _secretKey = secretKey;
            _redirect_url = redirect_url;
        }
        #endregion

        /// <summary>
        /// Initiate the payment by calling Flutterwave internal API with the collected payment details
        /// </summary>
        /// <param name="tx_ref">Your transaction reference. This MUST be unique for every transaction</param>
        /// <param name="amount">Amount to charge the customer.</param>
        /// <param name="customerEmail">Customer's email address</param>
        /// <param name="customerPhone">Customer's phone number</param>
        /// <param name="customerName">Customer's name</param>
        /// <param name="payment_options">This specifies the payment options to be displayed e.g - card, mobilemoney, ussd and so on.</param>
        /// <param name="currency">Currency to charge in. Defaults to NGN</param>
        /// <returns>A <see cref="PaymentInitResponseModel"/>.</returns>
        public async Task<PaymentInitResponseModel> InitiatePaymentAsync(string tx_ref, string amount, string customerEmail, string customerPhone, string customerName, string payment_options = "card", string currency = "NGN")
        {
            var _client = HttpFactory.InitHttpClient()
                            .WithBaseUri(RaveConstant.BASE_URL)
                            .AddAuthorizationHeader(RaveConstant.AUTHORIZATION_TYPE, _secretKey)
                            .AddMediaType(RaveConstant.REQUEST_MEDIA_TYPE)
                            .AddHeader("cache-control", "no-cache");

            var model = new TransactionInitInputModel()
            {
                amount = amount,
                currency = currency,
                tx_ref = tx_ref,
                customer = new Customer()
                {
                    email = customerEmail,
                    name = customerName,
                    phonenumber = customerPhone
                },
                redirect_url = _redirect_url,
                payment_options = payment_options,
                customizations = new Customizations()
                {
                    title = _coytitle,
                    description = _coyDescription,
                    logo = _coyLogoUrl
                }
            };

            var jsonRequestBody = JsonConvert.SerializeObject(model);

            var requestContent = new StringContent(jsonRequestBody, Encoding.UTF8, RaveConstant.REQUEST_MEDIA_TYPE);

            requestContent.Headers.ContentType = new MediaTypeHeaderValue(RaveConstant.REQUEST_MEDIA_TYPE);

            //send the request
            var response = await _client.PostAsync("payments", requestContent);

            var json = await response.Content.ReadAsStringAsync();

            //Deserialize and send the response
            return JsonConvert.DeserializeObject<PaymentInitResponseModel>(json);


        }


        /// <summary>
        /// Use to verify payment transaction
        /// </summary>
        /// <param name="transaction_id">The Id of the transaction to verify</param>
        /// <returns>A <see cref="TransactionVerifyResponseModel"/>.</returns>
        public async Task<TransactionVerifyResponseModel> VerifyTransactionAsync(int transaction_id)
        {
            var _client = HttpFactory.InitHttpClient()
                           .WithBaseUri(RaveConstant.BASE_URL)
                           .AddAuthorizationHeader(RaveConstant.AUTHORIZATION_TYPE, _secretKey)
                           .AddMediaType(RaveConstant.REQUEST_MEDIA_TYPE)
                           .AddHeader("cache-control", "no-cache");

            var response = await _client.GetAsync($"transactions/{transaction_id}/verify");

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TransactionVerifyResponseModel>(json);
        }


        /// <summary>
        /// Initiate the payment by calling Flutterwave internal API with the collected payment details
        /// </summary>
        /// <param name="tx_ref">Your transaction reference. This MUST be unique for every transaction</param>
        /// <param name="amount">Amount to charge the customer.</param>
        /// <param name="customerEmail">Customer's email address</param>
        /// <param name="customerPhone">Customer's phone number</param>
        /// <param name="customerName">Customer's name</param>
        /// <param name="payment_options">This specifies the payment options to be displayed e.g - card, mobilemoney, ussd and so on.</param>
        /// <param name="currency">Currency to charge in. Defaults to NGN</param>
        /// <returns>A <see cref="PaymentInitResponseModel"/>.</returns>
        public PaymentInitResponseModel InitiatePayment(string tx_ref, string amount, string customerEmail, string customerPhone, string customerName, string payment_options = "card", string currency = "NGN")
        {
            var _client = HttpFactory.InitHttpClient()
                            .WithBaseUri(RaveConstant.BASE_URL)
                            .AddAuthorizationHeader(RaveConstant.AUTHORIZATION_TYPE, _secretKey)
                            .AddMediaType(RaveConstant.REQUEST_MEDIA_TYPE)
                            .AddHeader("cache-control", "no-cache");

            var model = new TransactionInitInputModel()
            {
                amount = amount,
                currency = currency,
                tx_ref = tx_ref,
                customer = new Customer()
                {
                    email = customerEmail,
                    name = customerName,
                    phonenumber = customerPhone
                },
                redirect_url = _redirect_url,
                payment_options = payment_options,
                customizations = new Customizations()
                {
                    title = _coytitle,
                    description = _coyDescription,
                    logo = _coyLogoUrl
                }
            };

            var jsonRequestBody = JsonConvert.SerializeObject(model);

            var requestContent = new StringContent(jsonRequestBody, Encoding.UTF8, RaveConstant.REQUEST_MEDIA_TYPE);

            requestContent.Headers.ContentType = new MediaTypeHeaderValue(RaveConstant.REQUEST_MEDIA_TYPE);

            //send the request
            var response = Task.Run(() => _client.PostAsync("payments", requestContent)).Result; //.GetAwaiter().;


            var json = Task.Run(() => response.Content.ReadAsStringAsync()).Result;

            //Deserialize and send the response
            return JsonConvert.DeserializeObject<PaymentInitResponseModel>(json);


        }
        /// <summary>
        /// Use to verify payment transaction
        /// </summary>
        /// <param name="transaction_id">The Id of the transaction to verify</param>
        /// <returns>A <see cref="TransactionVerifyResponseModel"/>.</returns>
        public TransactionVerifyResponseModel VerifyTransaction(int transaction_id)
        {
            var _client = HttpFactory.InitHttpClient()
                           .WithBaseUri(RaveConstant.BASE_URL)
                           .AddAuthorizationHeader(RaveConstant.AUTHORIZATION_TYPE, _secretKey)
                           .AddMediaType(RaveConstant.REQUEST_MEDIA_TYPE)
                           .AddHeader("cache-control", "no-cache");

            var response = Task.Run(() => _client.GetAsync($"transactions/{transaction_id}/verify")).Result;

            var json = Task.Run(() => response.Content.ReadAsStringAsync()).Result;

            return JsonConvert.DeserializeObject<TransactionVerifyResponseModel>(json);
        }


    }
}
