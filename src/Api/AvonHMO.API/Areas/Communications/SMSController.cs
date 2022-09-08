using AvonHMO.API.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AvonHMO.API.Areas.Communications
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly IIPIntegratedSMS _smsService;

        public SMSController(IIPIntegratedSMS smsService)
        {
            _smsService = smsService;
        }

        [Route("communication/sms/test")]
        [HttpGet]
        public async Task<IActionResult> SendSMS()
        {
            var signUpMessage = $"Avon HMO provides best care, join the train for a heathier life." +
                $"Buy an Avon health plan today, click ";

            var formattedNumber = "2347085051295";

            var smsResponse = await _smsService.SendSMS("Referree", formattedNumber, signUpMessage);

            return Ok(smsResponse);

        }
    }
}
