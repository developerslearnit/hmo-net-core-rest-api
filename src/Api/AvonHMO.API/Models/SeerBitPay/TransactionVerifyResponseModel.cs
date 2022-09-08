namespace AvonHMO.API.Models.SeerBitPay
{
   

    public class TransactionVerifyResponseModel
    {
        public string status { get; set; }
        public TransVeryData data { get; set; }
    }

    public class TransVeryData
    {
        public string code { get; set; }
        public TransVeryPayments payments { get; set; }
        public Customers customers { get; set; }
        public string message { get; set; }
    }

    public class TransVeryPayments
    {
        public string redirectLink { get; set; }
        public float amount { get; set; }
        public string fee { get; set; }
        public string mobilenumber { get; set; }
        public string publicKey { get; set; }
        public string paymentType { get; set; }
        public string productId { get; set; }
        public string productDescription { get; set; }
        public string maskedPan { get; set; }
        public string gatewayMessage { get; set; }
        public string gatewayCode { get; set; }
        public string gatewayref { get; set; }
        public string businessName { get; set; }
        public string mode { get; set; }
        public string callbackurl { get; set; }
        public string redirecturl { get; set; }
        public string channelType { get; set; }
        public string sourceIP { get; set; }
        public string deviceType { get; set; }
        public string cardBin { get; set; }
        public string lastFourDigits { get; set; }
        public string country { get; set; }
        public string currency { get; set; }
        public string paymentReference { get; set; }
        public string transactionProcessTime { get; set; }
        public string processorCode { get; set; }
        public string processorMessage { get; set; }
        public string reason { get; set; }
    }

    public class Customers
    {
        public string customerName { get; set; }
        public string customerMobile { get; set; }
        public string customerEmail { get; set; }
        public string fee { get; set; }
    }

}
