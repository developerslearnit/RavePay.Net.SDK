using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavePay.Net.SDK.Entities.Payment
{
    /// <summary>
    /// 
    /// </summary>
    public class TransactionVerifyResponseModel:BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public VerifyData data { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Card
    {
        /// <summary>
        /// 
        /// </summary>
        public string first_6digits { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string last_4digits { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string issuer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string expiry { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class VerifyCustomer
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string phone_number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime created_at { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class VerifyData
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tx_ref { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string flw_ref { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string device_fingerprint { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal charged_amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal app_fee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal merchant_fee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string processor_response { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string auth_model { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string narration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string payment_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime created_at { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int account_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal amount_settled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Card card { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public VerifyCustomer customer { get; set; }
    }
}
