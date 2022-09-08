namespace AvonHMO.API.Models.SeerBitPay
{
   
    public class TransactionInitResponseModel
    {
        public string status { get; set; }
        public TransInitData data { get; set; }
    }

    public class TransInitData
    {
        public string code { get; set; }
        public Payments payments { get; set; }
        public string message { get; set; }
    }

    public class Payments
    {
        public string redirectLink { get; set; }
        public string paymentStatus { get; set; }
    }

}
