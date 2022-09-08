namespace AvonHMO.API.Models.EmailTemplateTokens
{
    public class QuoteRequestEmailToken
    {
        public string name { get; set; }
        public string companyName { get; set; }
        public string planName { get; set; }
        public string companyAddress { get; set; }
        public string emailAddress { get; set; }

        public string contactRole { get; set; }
        public int noToEnrollee { get; set; }
        public bool companyAndLargeAssociation { get; set; }
        public bool internationalHealthPlan { get; set; }
    }
    
    public class RequestAuthorizationEmailToken
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string hospitalName { get; set; }
        public string hcpName { get; set; }
        public string memberNumber { get; set; }
        public int memberNo { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
       
    }
    
    public class RequestRefundEmailToken
    {
        public string amount { get; set; } 
        public int memberNo { get; set; }
        public string reason { get; set; }
        public string firstName { get; set; }
        public string surName { get; set; }
        public string lastName { get; set; }
        public string paCode { get; set; }
        public string monthYear { get; set; }
        public string dateReceived { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string otherReason { get; set; }
       
    }

}
