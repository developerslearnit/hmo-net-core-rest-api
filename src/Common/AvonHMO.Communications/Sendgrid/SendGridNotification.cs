using AvonHMO.Communications.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace AvonHMO.Communications.Sendgrid
{
    /// <summary>
    /// 
    /// </summary>
    public class SendGridNotification : ISendGridNotification
    {
        private readonly string _fromEmail;
        private readonly string _displayName;
        private readonly string _apiKey;
        public SendGridNotification(string fromEmail, string displayName, string apiKey)
        {
            _fromEmail = fromEmail;
            _displayName = displayName;
            _apiKey = apiKey;
        }


        /// <summary>
        /// Send email with single TO, CC and BCC using sendgrid
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="to"></param>
        /// <param name="body"></param>
        /// <param name="attachmentName"></param>
        /// <param name="attachment"></param>
        /// <param name="cc"></param>
        /// <param name="bcc"></param>
        /// <returns>Sendgrid Response</returns>

        public async Task<Response> SendEmailMailAsync(string subject, string to, string body, 
            string? attachmentName = null,
            string? attachment = null, string? cc = null, string? bcc = null)
        {
            var mailClient = new SendGridClient(_apiKey);
            var message = new SendGridMessage()
            {
                From = new EmailAddress(_fromEmail, _displayName),
                Subject = subject,
                HtmlContent = body
            };

            if (!string.IsNullOrWhiteSpace(attachment))
            {

                

                message.AddAttachment(attachmentName, attachment);
            }

            message.AddTo(new EmailAddress(to));

            if (!string.IsNullOrWhiteSpace(cc)) { message.AddBcc(new EmailAddress(cc)); }

            if (!string.IsNullOrWhiteSpace(bcc)) { message.AddBcc(new EmailAddress(bcc)); }

            return await mailClient.SendEmailAsync(message);

        }

        /// <summary>
        /// Send email with mutiple TOs, CCs and BCCs using sendgrid
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="tos"></param>
        /// <param name="body"></param>
        /// <param name="attachmentName"></param>
        /// <param name="attachment"></param>
        /// <param name="cc"></param>
        /// <param name="bcc"></param>
        /// <returns>Sendgrid Response</returns>
        public async Task<Response> SendEmailMailAsync(string subject, List<string> tos, string body, 
            string? attachmentName = null, string attachment = null,
            List<string>? cc = null, List<string>? bcc = null)
        {
            var mailClient = new SendGridClient(_apiKey);
            var message = new SendGridMessage()
            {
                From = new EmailAddress(_fromEmail, _displayName),
                Subject = subject,
                HtmlContent = body
            };

            List<EmailAddress> toEmails = new List<EmailAddress>();

            foreach (var item in tos)
            {
                toEmails.Add(new EmailAddress(item));
            }
            message.AddTos(toEmails);

            if (!string.IsNullOrWhiteSpace(attachment))
            {
                message.AddAttachment(attachmentName, attachment);
            }

            List<EmailAddress> ccEmails = new List<EmailAddress>();

            List<EmailAddress> bccEmails = new List<EmailAddress>();

            if (cc != null)
            {
                if (cc.Count > 0)
                {
                    foreach (var item in cc)
                    {
                        ccEmails.Add(new EmailAddress(item));
                    }

                    message.AddCcs(ccEmails);
                }
            }


            if (bcc != null)
            {
                if (bcc.Count > 0)
                {
                    foreach (var item in bcc)
                    {
                        bccEmails.Add(new EmailAddress(item));
                    }

                    message.AddBccs(bccEmails);
                }
            }


            return await mailClient.SendEmailAsync(message);
        }
    }
}
