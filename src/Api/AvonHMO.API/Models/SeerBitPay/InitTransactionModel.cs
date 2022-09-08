namespace AvonHMO.API.Models.SeerBitPay
{
    public class InitTransactionModel : TransactionModel
    {
        public string hash { get; set; }

        public string hashType { get; set; }
    }


    public class TransactionPublicModel
    {
        public string amount { get; set; }
        public string currency { get; set; } = "NGN";
        public string country { get; set; } = "NGN";
        public string callbackUrl { get; set; }
        public string paymentReference { get; set; }
        public string email { get; set; }
        public string productId { get; set; }
        public string productDescription { get; set; }
    }


    public class TransactionModel
    {
        public string publicKey { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public string country { get; set; }
        public string paymentReference { get; set; }
        public string email { get; set; }
        public string productId { get; set; }
        public string productDescription { get; set; }
        public string callbackUrl { get; set; }
    }

}
