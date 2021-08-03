using RavePay.Net.SDK.Interfaces;
using RavePay.Net.SDK.Services;

namespace RavePay.Net.SDK
{
    /// <summary>
    /// Base API class
    /// </summary>
    public class RavePayNetSDK : IApi
    {
        #region Fields
        private IPayment _paymentService;
        private ICharge _chargeService;
        private readonly string _secretKey;
        private readonly string _coytitle;
        private readonly string _coyDescription;
        private readonly string _coyLogoUrl;
        private readonly string _redirect_url;
        #endregion

        /// <summary>
        /// Instantiate RavePay.Net API - This exposes all operations that are possible withing Flutterwave Payment Gateway
        /// </summary>
        /// <param name="secretKey">The secret key gotten from dashboard</param>
        /// <param name="redirect_url">The url to redirec to for payment verification</param>
        /// <param name="coytitle">Your company name</param>
        /// <param name="coyDescription">Your company description</param>
        /// <param name="coyLogoUrl">Your company logo url</param>
        public RavePayNetSDK(string secretKey, string redirect_url, string coytitle, string coyDescription, string coyLogoUrl)
        {
            this._secretKey = secretKey;
            _coyDescription = coyDescription;
            _coyLogoUrl = coyLogoUrl;
            _coytitle = coytitle;
            _secretKey = secretKey;
            _redirect_url = redirect_url;
        }


        /// <summary>
        /// Instantiate RavePay.Net API - This exposes all operations that are possible withing Flutterwave Payment Gateway
        /// </summary>
        /// <param name="secretKey">The secret key gotten from dashboard</param>
        /// <param name="coytitle">Your company name</param>
        /// <param name="coyDescription">Your company description</param>
        /// <param name="coyLogoUrl">Your company logo url</param>
        public RavePayNetSDK(string secretKey, string coytitle, string coyDescription, string coyLogoUrl)
        {
            this._secretKey = secretKey;
            _coyDescription = coyDescription;
            _coyLogoUrl = coyLogoUrl;
            _coytitle = coytitle;
            _secretKey = secretKey;
        }

        /// <summary>
        /// Exposes all methods for payment
        /// </summary>
        public IPayment Payment
        {
            get
            {
                if (_paymentService == null)
                    _paymentService = new PaymentService(_secretKey, _redirect_url, _coytitle, _coyDescription, _coyLogoUrl);

                return _paymentService;

            }
        }

        public ICharge Charge
        {
            get
            {
                if (_chargeService == null)
                    _chargeService = new ChargeService(_secretKey, _redirect_url);

                return _chargeService;
            }
        }
    }
}
