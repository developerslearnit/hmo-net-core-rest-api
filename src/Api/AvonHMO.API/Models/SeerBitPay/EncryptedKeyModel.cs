namespace AvonHMO.API.Models.SeerBitPay
{

    public class EncryptedKeyModel
    {
        public string status { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string code { get; set; }
        public Encryptedseckey EncryptedSecKey { get; set; }
        public string message { get; set; }
    }

    public class Encryptedseckey
    {
        public string encryptedKey { get; set; }
    }

    public class EncryptionReqBody
    {
        public string key { get; set; }
    }

    

}
