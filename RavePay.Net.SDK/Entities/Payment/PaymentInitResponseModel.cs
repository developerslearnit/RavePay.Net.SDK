using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavePay.Net.SDK.Entities.Payment
{
    /// <summary>
    /// Payment initialization response model
    /// </summary>
    public class PaymentInitResponseModel : BaseEntity
    {
        /// <summary>
        /// Rave Checkout link
        /// </summary>
        public CheckOutProp data { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CheckOutProp
    {
        /// <summary>
        /// 
        /// </summary>
        public string link { get; set; }
    }
}
