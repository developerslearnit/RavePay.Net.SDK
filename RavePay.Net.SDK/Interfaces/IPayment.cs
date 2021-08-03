using RavePay.Net.SDK.Entities.Payment;
using System.Threading.Tasks;

namespace RavePay.Net.SDK.Interfaces
{
    /// <summary>
    /// Payment Interface
    /// </summary>
    public interface IPayment
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tx_ref"></param>
        /// <param name="amount"></param>
        /// <param name="customerEmail"></param>
        /// <param name="customerPhone"></param>
        /// <param name="customerName"></param>
        /// <param name="payment_options"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        Task<PaymentInitResponseModel> InitiatePaymentAsync(string tx_ref, string amount, string customerEmail, string customerPhone,
                                        string customerName, string payment_options = "card", string currency = "NGN");




        /// <summary>
        /// 
        /// </summary>
        /// <param name="tx_ref"></param>
        /// <param name="amount"></param>
        /// <param name="customerEmail"></param>
        /// <param name="customerPhone"></param>
        /// <param name="customerName"></param>
        /// <param name="payment_options"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        PaymentInitResponseModel InitiatePayment(string tx_ref, string amount, string customerEmail, string customerPhone,
                                        string customerName, string payment_options = "card", string currency = "NGN");


        /// <summary>
        /// Verifies transaction asyncronously
        /// </summary>
        /// <param name="transaction_id"></param>
        /// <returns></returns>
        Task<TransactionVerifyResponseModel> VerifyTransactionAsync(int transaction_id);

        /// <summary>
        /// Verifies transaction syncronously
        /// </summary>
        /// <param name="transaction_id"></param>
        /// <returns></returns>
        TransactionVerifyResponseModel VerifyTransaction(int transaction_id);


    }
}
