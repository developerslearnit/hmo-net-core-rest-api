using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AvonHMO.API.Helpers
{

    public class SMSResponse
    {
        public bool posted { get; set; } = false;

        public string message { get; set; } = "There was an error sending sms";
    }

    public interface IIPIntegratedSMS
    {
        Task<SMSResponse> SendSMS(string toName, string toNumber, string message);
    }

    public class IPIntegratedSMS : IIPIntegratedSMS
    {
        //public string url = "http://websms.ipintegrated.com/HTTPIntegrator_SendSMS_1";

        private readonly IHttpClientFactory _httpClientFactory;
        public IPIntegratedSMS(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<SMSResponse> SendSMS(string toName, string toNumber, string message)
        {
            var _client = _httpClientFactory.CreateClient("SMSClient");

            toName = Uri.EscapeDataString(toName);

            message = Uri.EscapeDataString(message);

           // var username = Uri.EscapeDataString("AVON HMO");

            var username = "AVON HMO";

            var requestUri = $"?u=avon&p=avon123&s={username}&r=t&n={toName}&d={toNumber}&t={message}";

            bool posted = false;
            string resmessage = string.Empty;

            var responseObj = new SMSResponse();

            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();

                var responseContent = res.Split(new string[] { "\n" }, StringSplitOptions.None);

                posted = responseContent[0].Split(":")[1] == "TRUE" ? true : false;
                resmessage = responseContent[1].Split(":")[1].ToString();


                responseObj.message = resmessage;
                responseObj.posted = posted;


                return responseObj;
            }

            return responseObj;
        }
    }
}
