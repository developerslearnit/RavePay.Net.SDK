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
    public class TransactionInitInputModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string tx_ref { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string redirect_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string payment_options { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Meta meta { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Customer customer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Customizations customizations { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// 
        /// </summary>
        public int consumer_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string consumer_mac { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// 
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string phonenumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>

    public class Customizations
    {
        /// <summary>
        /// 
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string logo { get; set; }
    }
}
