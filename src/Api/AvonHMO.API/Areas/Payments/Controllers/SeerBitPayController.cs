using AvonHMO.API.Areas.Setup.Controllers;
using AvonHMO.API.Contracts;
using AvonHMO.API.Filters;
using AvonHMO.API.Models.SeerBitPay;
using AvonHMO.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class SeerBitPayController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IRepositoryManager _repository;
        private readonly IHttpClientFactory _httpClientFactory;
        public SeerBitPayController(IConfiguration config, IRepositoryManager repository, IHttpClientFactory httpClientFactory)
        {
            _config = config;
            _repository = repository;
            _httpClientFactory = httpClientFactory;
        }


        /// <summary>
        /// This endpoint allows client initialize payment transaction
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Payments.SeerBitInitTrans)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(TransactionInitResponseModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> SeerBitInitializeTrans([FromBody] TransactionPublicModel model)
        {

            if (model == null) return BadRequest();

            var bearerToken = "";// await GetSeerBitEncryptionKey();
            if (string.IsNullOrWhiteSpace(bearerToken)) return BadRequest("Invalid bearer token");

            var callBackUrl = model.callbackUrl;
            var publicKey = _repository.Settings.GetSetting("SEERBIT_PUB_KEY");

            //callBackUrl = $"{callBackUrl}/{model.paymentReference}";

            var transactionModel = new TransactionModel
            {
                amount = model.amount,
                callbackUrl = callBackUrl,
                country = string.IsNullOrEmpty(model.country) ? "NGN" : model.country,
                currency = string.IsNullOrEmpty(model.currency) ? "NGN" : model.currency,
                email = model.email,
                paymentReference = model.paymentReference,
                productDescription = model.productDescription,
                productId = model.productId,
                publicKey = publicKey
            };

            var hash = await GenerateSeerBitRequestHash(transactionModel);


            if (string.IsNullOrWhiteSpace(hash)) return BadRequest("Invalid hash detected");

            var _client = _httpClientFactory.CreateClient("seerBitClient");

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);

            var payload = new InitTransactionModel
            {
                publicKey = publicKey,
                hash = hash,
                productId = model.productId,
                amount = model.amount,
                callbackUrl = callBackUrl,
                country = model.country,
                currency = model.currency,
                email = model.email,
                hashType = "sha256",
                paymentReference = model.paymentReference,
                productDescription = model.productDescription,
            };

            var reqBody = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8,
               System.Net.Mime.MediaTypeNames.Application.Json);

            using var response = await _client.PostAsync("payments", reqBody);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<TransactionInitResponseModel>();

                if (result.status == "SUCCESS")
                {
                   return Ok(result);
                }
            }
            else
            {
                var errResponse = await response.Content.ReadAsStringAsync();

                return Ok(errResponse);
            }

            return BadRequest();

        }


       
        /// <summary>
        /// This endpoint is called to verify payment transaction
        /// </summary>
        /// <param name="paymentReference"></param>
        /// <returns></returns>
        [HttpGet(ApiRoutes.Payments.SeerBitVerifyTrans)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(TransactionVerifyResponseModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> SeerBitVerifyTrans([FromRoute] string paymentReference)
        {
            if (string.IsNullOrWhiteSpace(paymentReference)) return BadRequest();

            var bearerToken = "";// await GetSeerBitEncryptionKey();
            if (string.IsNullOrWhiteSpace(bearerToken)) return BadRequest("Invalid bearer token");


            var _client = _httpClientFactory.CreateClient("seerBitClient");

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);



            var request = new HttpRequestMessage(HttpMethod.Get, $"payments/query/{paymentReference}");

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var resutl = await response.Content.ReadFromJsonAsync<TransactionVerifyResponseModel>();

                return Ok(resutl);
            }

            return BadRequest();
        }


        [HttpPost("payment/enc/keys")]
        public async Task<IActionResult> ComputeEncryptionKeys([FromBody] EncryptionReqBody model)
        {
            var encKeys = await GetSeerBitEncryptionKey(model);

            return Ok(encKeys);
        }

        #region SeerBitHelper


        async Task<string> GenerateSeerBitRequestHash(TransactionModel payload)
        {

            var generatedHashKey = string.Empty;

            var _client = _httpClientFactory.CreateClient("seerBitClient");

            //var secretKey = _repository.Settings.GetSetting("SEERBIT_SECRET_KEY");
            var publicKey = _repository.Settings.GetSetting("SEERBIT_PUB_KEY");

            if (string.IsNullOrWhiteSpace(publicKey)) return generatedHashKey;



            var reqBody = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8,
                System.Net.Mime.MediaTypeNames.Application.Json);

            using var response = await _client.PostAsync("encrypt/hashs", reqBody);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<HashGenetorModel>();

                if (result.status == "SUCCESS")
                {
                    generatedHashKey = result.data.hash.hash;
                }
            }

            return generatedHashKey;


        }

        async Task<string> GetSeerBitEncryptionKey(EncryptionReqBody inputBody)
        {


            var generatedKey = string.Empty;

            var _client = _httpClientFactory.CreateClient("seerBitClient");

            var secretKey = _repository.Settings.GetSetting("SEERBIT_SECRET_KEY");
            var publicKey = _repository.Settings.GetSetting("SEERBIT_PUB_KEY");

            if (string.IsNullOrWhiteSpace(secretKey) || string.IsNullOrWhiteSpace(publicKey)) return generatedKey;

            var key = $"{secretKey}.{publicKey}";

            var encKey = new EncryptionReqBody()
            {
                key = key,
            };

            var reqBody = new StringContent(JsonSerializer.Serialize(encKey), Encoding.UTF8,
                System.Net.Mime.MediaTypeNames.Application.Json);

            using var response = await _client.PostAsync("encrypt/keys", reqBody);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<EncryptedKeyModel>();

                if (result.status == "SUCCESS")
                {
                    generatedKey = result.data.EncryptedSecKey.encryptedKey;
                }
            }

            return generatedKey;


        }

        #endregion
    }
}
