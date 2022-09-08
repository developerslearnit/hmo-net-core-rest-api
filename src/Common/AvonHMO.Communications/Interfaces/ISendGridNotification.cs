using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid;

namespace AvonHMO.Communications.Interfaces
{
    public interface ISendGridNotification
    {
        Task<Response> SendEmailMailAsync(string subject, string to, string body,
            string? attachmentName = null,
            string? attachment = null, string? cc = null, string? bcc = null);


        Task<Response> SendEmailMailAsync(string subject, List<string> tos, string body, 
            string? attachmentName = null, string attachment = null, 
            List<string>? cc = null, List<string>? bcc = null);
    }
}
