using AvonHMO.API.Areas.Payments.Models;
using AvonHMO.API.Areas.Setup.Controllers;
using AvonHMO.API.Contracts;
using AvonHMO.API.Filters;
using AvonHMO.API.Models.SeerBitPay;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Authentication;
using AvonHMO.Common;
using AvonHMO.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Paystack.Net.SDK;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AvonHMO.API.Areas.Payments.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    //[APIKeyAuth]
    public class PaymentController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IRepositoryManager _repository;
        private readonly IHttpClientFactory _httpClientFactory;
        public PaymentController(IConfiguration config, IRepositoryManager repository, IHttpClientFactory httpClientFactory)
        {
            _config = config;
            _repository = repository;
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// This endpoint is used to initialize paystack payment
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost(ApiRoutes.Payments.PaystackInitTrans)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(ApiResponse<PaystackInitResponseModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> PaystackInitTransaction([FromBody] PaystackInitModel model)
        {
            if (model == null) return BadRequest();

            var errorMessages = ExceptionHelper.ModelRequiredFieldValidation<PaystackInitModel>(model);

            if (errorMessages.Length > 0) return BadRequest(errorMessages);

            var paystackKey = _repository.Settings.GetSetting("PAYSTACK_SECRET_KEY");


            if (string.IsNullOrEmpty(paystackKey))
                return BadRequest();


            var payStackAPI = new PayStackApi(paystackKey);

            if (model.amount <= 0) return BadRequest("Amount must be greater than zero");

            var intAmount = (int)model.amount * 100;

            var response = await payStackAPI.Transactions.InitializeTransaction(model.email, intAmount, model.customer_name, null, model.callback_url);

            if (response.status == true)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    StatusCode = (int)StatusCodes.Status200OK,
                    Data =
                   new PaystackInitResponseModel
                   {
                       authorization_url = response.data.authorization_url,
                       reference = response.data.reference,
                       access_code = response.data.access_code,

                   }

                });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<object>
                {
                    Message = response.message,
                    hasError = true,
                    StatusCode = (int)StatusCodes.Status500InternalServerError,
                });
            }


        }



        /// <summary>
        /// This endpoint is called to verify paystack transaction status
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>

        [HttpPost(ApiRoutes.Payments.PaystackVerifyTrans)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(ApiResponse<Paystack.Net.SDK.Models.TransactionResponseModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> PaystackVerifyTransaction([FromQuery] string reference)
        {


            if (string.IsNullOrWhiteSpace(reference)) return BadRequest();


            var paystackKey = _repository.Settings.GetSetting("PAYSTACK_SECRET_KEY");


            if (string.IsNullOrEmpty(paystackKey))
                return BadRequest();


            var payStackAPI = new PayStackApi(paystackKey);



            var response = await payStackAPI.Transactions.VerifyTransaction(reference);

            if (response.status == true)
            {
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<object>
                {
                    StatusCode = (int)StatusCodes.Status200OK,
                    Data =
                   new Paystack.Net.SDK.Models.TransactionResponseModel
                   {
                       data = response.data,
                       message = response.message,
                       status = response.status
                   }

                });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


        }



        


    }
}
