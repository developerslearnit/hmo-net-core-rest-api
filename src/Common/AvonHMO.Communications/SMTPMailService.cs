using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Communications
{
    public class SMTPMailService
    {

        private string smtpClient;
        private string fromEmail;
        private int serverPort;
        private string username;
        private string password;
        private bool enableSSL;
        public SMTPMailService(string _smtpClient, string _fromEmail, int _serverPort,
                         string _username, string _password, bool _enableSSL)
        {
            smtpClient = _smtpClient;
            fromEmail = _fromEmail;
            serverPort = _serverPort;
            username = _username;
            password = _password;
            enableSSL = _enableSSL;
        }

        bool IsValidEmail(string email)
        {
            if (email.Trim().EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

      



        public bool Send(string subject, string to,string body, string? displayName = null,
            string? attachment = null, Stream attachmentStream = null, string? cc = null, string? bcc = null)
        {
            bool IsSent = false;
            try
            {
                var mail = new MailMessage();
                var smtpServer = new SmtpClient(smtpClient);


                //smtpServer.ClientCertificates.
                
                //smtpServer.ServerCertificateValidate +=
                //new ServerCertificateValidateEventHandler(Validate);

                if (!string.IsNullOrEmpty(displayName))
                {
                    mail.From = new MailAddress(fromEmail, displayName);
                }
                else
                {
                    mail.From = new MailAddress(fromEmail);
                }


                string[] toEmail;

                if (to.Contains(";"))
                {
                    toEmail = to.Split(';');

                    foreach (var item in toEmail)
                    {
                        if (IsValidEmail(item))
                            mail.To.Add(new MailAddress(item));
                    }
                }
                else if (to.Contains(","))
                {
                    toEmail = to.Split(',');

                    foreach (var item in toEmail)
                    {
                        if (IsValidEmail(item))
                            mail.To.Add(new MailAddress(item));
                    }
                }
                else
                {
                    if (IsValidEmail(to))
                        mail.To.Add(new MailAddress(to));
                }

                if (!string.IsNullOrEmpty(cc))
                {
                    if (cc.Contains(";"))
                    {

                        var splittedCC = cc.Split(';');

                        foreach (var ccItem in splittedCC)
                        {
                            if (IsValidEmail(ccItem))
                                mail.Bcc.Add(new MailAddress(ccItem));
                        }

                    }
                    else if (cc.Contains(","))
                    {
                        var splittedCCM = cc.Split(',');

                        foreach (var ccItm in splittedCCM)
                        {
                            if (IsValidEmail(ccItm))
                                mail.Bcc.Add(new MailAddress(ccItm));
                        }

                    }
                    else
                    {
                        if (IsValidEmail(cc))
                            mail.Bcc.Add(new MailAddress(cc));
                    }


                }                                
                

                if (!string.IsNullOrEmpty(attachment) && attachmentStream != Stream.Null)
                {
                    mail.Attachments.Add(new Attachment(attachmentStream, attachment));
                }

                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                smtpServer.Port = serverPort;
                smtpServer.Credentials = new System.Net.NetworkCredential(username, password);
                if (enableSSL)
                {
                    smtpServer.EnableSsl = true;
                }

                if (mail.To.Count() > 0)
                {
                    smtpServer.Send(mail);
                    IsSent = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsSent;
        }


    }
}
