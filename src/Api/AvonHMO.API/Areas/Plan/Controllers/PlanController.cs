using AvonHMO.API.Filters;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Plan;
using AvonHMO.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AvonHMO.API.Areas.Plan.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    [APIKeyAuth]
    public class PlanController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IRepositoryManager _service;
        public PlanController(IHttpClientFactory httpClientFactory, IRepositoryManager service)
        {
            _httpClientFactory = httpClientFactory;
            _service = service;
        }

        /// <summary>
        /// This endpoint returns list of plan benefits
        /// </summary>
        /// <returns></returns>

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<Lstistofplanbyproviderdetail>>), StatusCodes.Status200OK)]
        [HttpGet("plan/benefits")]
        public async Task<IActionResult> PlanBenefits([FromQuery] string policyNo,string planCode)
        {


            if (string.IsNullOrWhiteSpace(policyNo)) return BadRequest("Policy Number is not set");

            if (string.IsNullOrWhiteSpace(planCode)) return BadRequest("Plan code should be set");





            //var enrollee = (await _service.Enrollee.FetchMemberInformationByNumber(memberNumber)).FirstOrDefault();

            var _client = _httpClientFactory.CreateClient("toshfaClient");

            var request = new HttpRequestMessage(HttpMethod.Get, "planbenefitdetail");

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<PlanBenefitDetailsModel>();

                if (result.lstistofplanbyproviderDetails.Any())
                {
                    var data = result.lstistofplanbyproviderDetails.ToList();

                    var finalResult = data.Where(x=>x.PolicyNo==policyNo.ToString() && x.PlanCode==planCode.ToString()).ToList();

                    return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<List<Lstistofplanbyproviderdetail>>
                    {
                        Data = data,
                        hasError = false,                        
                        StatusCode =StatusCodes.Status200OK
                    });
                }
            }


            return NotFound();



        }


        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<Lstistofplanbyproviderdetail>>), StatusCodes.Status200OK)]
        [HttpGet("plan/benefits/{memberNo}")]
        public async Task<IActionResult> PlanBenefitLists([FromRoute] int memberNo)
        {


            if (memberNo <= 0) return BadRequest("Member Number is not set");



            var enrollee = (await _service.Enrollee.FetchMemberInformationByNumber(memberNo)).FirstOrDefault();


            if (enrollee == null) return BadRequest("Enrollee not found");



            var _client = _httpClientFactory.CreateClient("toshfaClient");

            var request = new HttpRequestMessage(HttpMethod.Get, $"planbenefitdetail?policyno={enrollee.PolicyNo}&plancode={enrollee.planCode}");

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<PlanBenefitDetailsModel>();

                if (result.lstistofplanbyproviderDetails.Any())
                {
                    var data = result.lstistofplanbyproviderDetails.ToList();

                    var finalResult = data.ToList();

                    return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<List<Lstistofplanbyproviderdetail>>
                    {
                        Data = finalResult,
                        hasError = false,
                        StatusCode = StatusCodes.Status200OK
                    });
                }
            }


            return NotFound();



        }


    }
}
