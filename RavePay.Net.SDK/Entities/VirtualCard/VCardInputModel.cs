using System;
using System.Collections.Generic;

namespace RavePay.Net.SDK.Entities.VirtualCard
{
    public class VCardInputModel
    {
        public string currency { get; set; }
        public int amount { get; set; }
        public string billing_name { get; set; }
        public string billing_address { get; set; }
        public string billing_city { get; set; }
        public string billing_state { get; set; }
        public string billing_postal_code { get; set; }
        public string billing_country { get; set; }
        public string callback_url { get; set; }
    }

    public class VCardData
    {
        public string id { get; set; }
        public int account_id { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public string card_hash { get; set; }
        public string card_pan { get; set; }
        public string masked_pan { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string address_1 { get; set; }
        public object address_2 { get; set; }
        public string zip_code { get; set; }
        public string cvv { get; set; }
        public string expiration { get; set; }
        public object send_to { get; set; }
        public object bin_check_name { get; set; }
        public string card_type { get; set; }
        public string name_on_card { get; set; }
        public DateTime created_at { get; set; }
        public bool is_active { get; set; }
        public object callback_url { get; set; }
    }

    public class VCardResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public VCardData data { get; set; }
    }



    public class VCardDatum
    {
        public string id { get; set; }
        public int account_id { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public string card_hash { get; set; }
        public string card_pan { get; set; }
        public string masked_pan { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string address_1 { get; set; }
        public object address_2 { get; set; }
        public string zip_code { get; set; }
        public string cvv { get; set; }
        public string expiration { get; set; }
        public object send_to { get; set; }
        public object bin_check_name { get; set; }
        public string card_type { get; set; }
        public string name_on_card { get; set; }
        public DateTime created_at { get; set; }
        public bool is_active { get; set; }
        public string callback_url { get; set; }
    }

    public class VCardList
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<VCardDatum> data { get; set; }
    }


    public class VCardSingle
    {
        public string status { get; set; }
        public string message { get; set; }
        public VCardDatum data { get; set; }
    }

}
