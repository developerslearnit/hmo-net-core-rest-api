namespace AvonHMO.API.Models.EmailTemplateTokens
{
    public class NewAccountEmailToken
    {
        public string firstName { get; set; }

        public string email { get; set; }

        public string password { get; set; }
    }

    public class ContactUsEmailToken
    {
        public string senderName { get; set; }

        public string message { get; set; }

        public string email { get; set; }

    }
    
    public class FeedbackEmailToken
    {
        public string senderName { get; set; }

        public string subject { get; set; }
        public string message { get; set; }

        public string email { get; set; }

    }
    
    public class AdminResponseToComplaintEmailToken
    {
        public string firstName { get; set; }

        public string message { get; set; }

    }
    
    public class RecommendationEmailToken
    {
        public string senderName { get; set; }

        public string provider { get; set; }
        public string recommendation { get; set; }

        public string email { get; set; }

    }

    public class ForgotPasswordEmailToken
    {
        public string firstName { get; set; }

        public string token { get; set; }
    }
    public class PlanSubscriptionEmailModel
    {
        public string PlanName { get; set; }

       // public string Premium { get; set; }
    }
    public class PlanPaymentEmailModel
    {
        public string PlanName { get; set; }
        public string FullName { get { return $"{LastName} {FirstName}"; } }
        public decimal _Premium { get; set; }
        public decimal _nhis { get; set; }
        public string Premium { get { return _Premium == 0 ? "0.00" : _Premium.ToString("#,##0.00;(#,##0.00)"); } }
        public string Nhis { get { return _nhis == 0 ? "0.00" : _nhis.ToString("#,##0.00;(#,##0.00)"); } }
        public string Total { get { return (_nhis + _Premium) == 0 ? "0.00" : (_nhis + _Premium).ToString("#,##0.00;(#,##0.00)"); } }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Hospital { get; set; }
    }
}
