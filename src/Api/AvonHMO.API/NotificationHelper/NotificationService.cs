using AvonHMO.Common;
using AvonHMO.Communications.Sendgrid;
using AvonHMO.Domain.Interfaces;
using System.Threading.Tasks;

namespace AvonHMO.API.NotificationHelper
{
    public class NotificationService
    {
        private readonly IRepositoryManager _authRepo;

        public NotificationService(IRepositoryManager authRepo)
        {
            _authRepo = authRepo;
        }
        public async Task<bool> SendNotification(string subject,string toEmail,string templateResult)
        {

            var sendersEmail = _authRepo.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);

            var sendersName = _authRepo.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

            var apiKey = _authRepo.Settings.GetSetting(AvonConstants.Settings.SENDGRID_KEY);

            var emailSender = new SendGridNotification(sendersEmail, sendersName, apiKey);

            var emailResponse = await emailSender.SendEmailMailAsync(subject, toEmail, templateResult);

            return true;
        }


        //public async Task<bool> SendNotification(string subject, List<string> toEmails, string templateResult)
        //{

        //    var sendersEmail = _authRepo.Settings.GetSetting(AvonConstants.Settings.FROM_EMAIL);

        //    var sendersName = _authRepo.Settings.GetSetting(AvonConstants.Settings.FROM_DISPLAY_NAME);

        //    var apiKey = _authRepo.Settings.GetSetting(AvonConstants.Settings.SENDGRID_KEY);

        //    var emailSender = new SendGridNotification(sendersEmail, sendersName, apiKey);

        //    var emailResponse = await emailSender.SendEmailMailAsync(subject, toEmail, templateResult);

        //    return true;
        //}

    }
}
