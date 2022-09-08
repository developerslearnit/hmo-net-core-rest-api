namespace AvonHMO.API.Models.SeerBitPay
{
   
    public class HashGenetorModel
    {
        public string status { get; set; }
        public HashData data { get; set; }
    }

    public class HashData
    {
        public string code { get; set; }
        public string message { get; set; }
        public Hash hash { get; set; }
    }

    public class Hash
    {
        public string hash { get; set; }
    }

}
