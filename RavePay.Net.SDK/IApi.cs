using RavePay.Net.SDK.Interfaces;

namespace RavePay.Net.SDK
{
    /// <summary>
    /// Base API Interface
    /// </summary>
    public interface IApi
    {
        /// <summary>
        /// Payment
        /// </summary>
        IPayment Payment { get; }

        ICharge Charge { get; }
    }
}
