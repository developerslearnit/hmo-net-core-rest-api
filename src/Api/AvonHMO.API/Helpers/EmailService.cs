using AvonHMO.Communications;
using AvonHMO.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;

namespace AvonHMO.API.Helpers
{

    public class EmailSettings
    {
        public string smtpClient { get; set; }
        public string fromEmail { get; set; }
        public int serverPort { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool enableSSL { get; set; }
        public string fromDisplayName { get; set; }
    }

    public interface IEmailService
    {
        void Send(string subject, string to,  string body,
           Stream attachmentStream = null, string? attachment = null, string fromEmail=null, string? cc = null, string? bcc = null);
    }


    public class EmailService: IEmailService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IRepositoryManager _service;

        public EmailService(IMemoryCache memoryCache, IRepositoryManager service)
        {
            _memoryCache = memoryCache;
            _service = service;
        }


        private EmailSettings FetchSettings()
        {
            EmailSettings settings = null;

            if (_memoryCache.TryGetValue("EmailSettingKey", out settings))
            {
                return settings;
            }


            var smtpHost = _service.Settings.GetSetting("SMTP_HOST");
            var smtpUsername = _service.Settings.GetSetting("SMTP_USERNAME");
            var smtpPassword = _service.Settings.GetSetting("SMTP_PASSWORD");
            var smtpPort = int.Parse(_service.Settings.GetSetting("SMTP_PORT"));
            var enableSsl = bool.Parse(_service.Settings.GetSetting("SMTP_ENABLE_SSL"));
            var fromDisplayName = _service.Settings.GetSetting("FROM_DISPLAY_NAME");
            var fromEmail = _service.Settings.GetSetting("FROM_EMAIL");

            settings = new EmailSettings()
            {
                enableSSL = enableSsl,
                fromEmail = fromEmail,
                password = smtpPassword,
                serverPort = smtpPort,
                smtpClient = smtpHost,
                fromDisplayName = fromDisplayName,
                username = smtpUsername
            };

            // Set cache options
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromDays(1));

            // Set object in cache
            _memoryCache.Set("EmailSettingKey", settings, cacheOptions);

            return settings;
        }


        public void Send(string subject, string to,string body,
           Stream attachmentStream = null, string? attachment = null, string fromEmail = null, string? cc = null, string? bcc = null)
        {

            var settings = FetchSettings();

            string from = fromEmail ?? settings.fromEmail;

            var smtpMail = new SMTPMailService(settings.smtpClient,
              from, settings.serverPort, settings.username,
              settings.password, settings.enableSSL);

            try
            {
                smtpMail.Send(subject, to, body, settings.fromDisplayName, attachment, attachmentStream, cc, bcc);


            }
            catch (System.Exception ex)
            {

            }



        }
    }
}
