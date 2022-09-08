namespace AvonHMO.API.Models.EmailTemplateTokens
{
    public class ProviderNetworkEmailToken
    {
        public string title { get; set; }
        public string firstName { get; set; }
        public string surName { get; set; }

        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string companyName { get; set; }
        public string message { get; set; }
        public string requestType { get; set; }
    }
    
    public class PDependantRequestEmailToken
    {
        public string title { get; set; }
        public string firstName { get; set; }
        public string dependantFirstName { get; set; }
        public string surName { get; set; }
        public string memberNo { get; set; }
        public string dateOfBirth { get; set; }
        public string phoneNumber { get; set; }
        public string gender { get; set; }
        public string relationship { get; set; }
    }

}
