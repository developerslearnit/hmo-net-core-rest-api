using AvonHMO.API.Contracts;
using AvonHMO.API.Controllers;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Toshfa;
using AvonHMO.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AvonHMO.API.Areas.Setup.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    public class SetupController : BaseController
    {
        private readonly IRepositoryManager _service;

        public SetupController(IRepositoryManager service)
        {
            _service = service;
        }

        /// <summary>
        /// This enpoint returns list of providers
        /// </summary>
        /// <returns>List of HMO providers</returns>
        [HttpGet(ApiRoutes.Setup.AllProviders)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoProvidersViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> HmoProviders([FromQuery] PagingParam model)
        {
            var providers = await _service.Toshfa.FetchAllProviders(model);
            return StatusCode(StatusCodes.Status200OK, providers);
        }

        /// <summary>
        /// This enpoint returns  provider by provider code
        /// </summary>
        /// <param name="code">Provider Code</param>
        /// <param name="model">Paging Model Prameter</param>
        /// <returns>List of HMO providers</returns>
        [HttpGet(ApiRoutes.Setup.ProviderByCode)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoProvidersViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> HmoProvidersByCity([FromQuery] PagingParam model, [FromRoute] string code)
        {
            var providers = await _service.Toshfa.FetchProviderByProviderCode(model, code);
            return StatusCode(StatusCodes.Status200OK, providers);
        }
        
        /// <summary>
        /// This enpoint returns  providers by filtering parameters code
        /// </summary>
        /// <param name="model">Paging and filter Model Prameter</param>
        /// <returns>List of HMO providers</returns>
        [HttpGet(ApiRoutes.Setup.ProviderByfilter)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoProvidersViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> HmoProvidersByCity([FromQuery] ProviderFilterParam model)
        {
            var providers = await _service.Toshfa.FetchProviderByFilter(model);
            return StatusCode(StatusCodes.Status200OK, providers);
        }



        /// <summary>
        /// This enpoint returns a list of member approval details
        /// </summary>
        /// <returns>List of HMO member approval details</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberApprovalDetails)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberApprovalDetailsViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> HmoMemberApprovalDetails([FromQuery] PagingParam objModel)
        {

            var memberApprovalDetails = await _service.Toshfa.FetchAllMemberApprovalDetails(objModel);
            return StatusCode(StatusCodes.Status200OK, memberApprovalDetails);


        }


        /// <summary>
        /// This enpoint returns list of benefit names
        /// </summary>
        /// <returns>List of benefit names</returns>
        [HttpGet(ApiRoutes.Setup.AllBenefitNames)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<BenefitNameViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> BenefitNames([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK, await _service.Toshfa.FetchAllBenefitNames(model));
        }

        /// <summary>
        /// This enpoint returns a single benefit name
        /// </summary>
        /// <param name="code">Benefit Code from request route</param>
        /// <returns>Single benefit name</returns>
        [HttpGet(ApiRoutes.Setup.BenefitNamesByCode)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<BenefitNameViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> BenefitNameByCode([FromRoute] string code)
        {

            var benefitName = await _service.Toshfa.FetchSingleBenefitNameByCode(code);

            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<BenefitNameViewModel> { Data = benefitName.FirstOrDefault(), hasError = false });
        }

        /// <summary>
        /// This enpoint returns list of agent/broker information
        /// </summary>
        /// <returns>List of agent/broker</returns>
        [HttpGet(ApiRoutes.Setup.AllAgentInfo)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<AgentOrBrokerInfomationViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AgentInformation([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK, await _service.Toshfa.FetchAllAgentOrBrokerInfo(model));
        }

        /// <summary>
        /// This enpoint returns a single agent/broker information
        /// </summary>
        /// <param name="code">STKH_CODE, unique agent/broker info Code from request route</param>
        /// <returns>Single agent/broker information</returns>
        [HttpGet(ApiRoutes.Setup.AgentInfoByCode)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<AgentOrBrokerInfomationViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AgentInformationByCode([FromRoute] string code)
        {


            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<AgentOrBrokerInfomationViewModel> { Data = (await _service.Toshfa.FetchAgentOrBrokerInfoByCode(code)).FirstOrDefault() });

        }


        /// <summary>
        /// This enpoint returns a list of member approval details by request number
        /// </summary>
        /// <param name="request_no">Request Number</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>HMO member approval details by request-no</returns>
        [HttpGet(ApiRoutes.Setup.MemberApprovalDetailsByRequestNo)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberApprovalDetailsViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> HmoMemberApprovalDetailsByRequestNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int request_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var memberApprovalDetails = await _service.Toshfa.FetchAllMemberApprovalDetailsByRequestNo(objModel, request_no);
            return StatusCode(StatusCodes.Status200OK, memberApprovalDetails);

        }





        /// <summary>
        /// This enpoint returns a list of member approval details by member number
        /// </summary>
        /// <param name="member_no">Member Number</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>HMO member approval details by member-no</returns>
        [HttpGet(ApiRoutes.Setup.MemberApprovalDetailsByMemberNo)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberApprovalDetailsViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> HmoMemberApprovalDetailsByMemberNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int member_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var memberApprovalDetails = await _service.Toshfa.FetchAllMemberApprovalDetailsByMemberNo(objModel, member_no);
            return StatusCode(StatusCodes.Status200OK, memberApprovalDetails);

        }






        /// <summary>
        /// This enpoint returns a list of member approval details By Avon Pa Code
        /// </summary>
        /// <param name="avon_pa_code">Avon Pa Code</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>HMO member approval details By Avon Pa Code</returns>
        [HttpGet(ApiRoutes.Setup.MemberApprovalDetailsByAvonPaCode)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberApprovalDetailsViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> HmoMemberApprovalDetailsByAvonPaCode([FromQuery] int PageNumber, int PageSize, [FromRoute] string avon_pa_code)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            avon_pa_code = avon_pa_code.Replace("%2F", "/");

            var memberApprovalDetails = await _service.Toshfa.FetchAllMemberApprovalDetailsByAvonPaCode(objModel, avon_pa_code);
            return StatusCode(StatusCodes.Status200OK, memberApprovalDetails);

        }






        /// <summary>
        /// This enpoint returns a list of member approved providers
        /// </summary>
        /// <returns>List of HMO member approved providers</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberApprovedProviders)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<MemberApprovedProvidersViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> MemberApprovedProviders([FromQuery] PagingParam objModel)
        {
            var memberApprovedProviders = await _service.Toshfa.FetchAllMemberApprovedProviders(objModel);
            return StatusCode(StatusCodes.Status200OK, memberApprovedProviders);
        }




        /// <summary>
        /// This enpoint returns a list of member approved providers by hospital number
        /// </summary>
        /// <param name="hospital_no">Hospital Number</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO member approved providers by hospital number</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberApprovedProversByHospital)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<MemberApprovedProvidersViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> MemberApprovedProvidersByHospitalNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int hospital_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var memberApprovedProviders = await _service.Toshfa.FetchAllMemberApprovedProvidersByHospitalNo(objModel, hospital_no);
            return StatusCode(StatusCodes.Status200OK, memberApprovedProviders);
        }

        /// <summary>
        /// This enpoint returns list of Provider approval counts
        /// </summary>
        /// <returns>List of Provider approval counts</returns>
        [HttpGet(ApiRoutes.Setup.AllProviderApprovalCounts)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<ProviderApprovalCountViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AllProviderApprovalCounts([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK, await _service.Toshfa.FetchAllProviderApprovalCount(model));
        }

        /// <summary>
        /// This enpoint returns List Provider approval count By Provider Number
        /// </summary>
        /// <param name="provider_no">Unique Provider No</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>List Provider approval count</returns>
        [HttpGet(ApiRoutes.Setup.ProviderApprovalCountByProviderNo)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<ProviderApprovalCountViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ProviderApprovalCountByProviderNo([FromRoute] int provider_no, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK, await _service.Toshfa.FetchProviderApprovalCountByProviderNo(provider_no, model));
        }

        /// <summary>
        /// This enpoint returns list of Approval Request Details
        /// </summary>
        /// <returns>List of Approval Request Details</returns>
        [HttpGet(ApiRoutes.Setup.AllApprovalRequestDetails)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<ApprovalRequestDetailedViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AllApprovalRequestDetails([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllApprovalRequestDetails(model));
        }

        /// <summary>
        /// This enpoint returns an Approval Request Details by request number
        /// </summary>
        /// <param name="request_no">Request No</param>
        /// <returns>List of Approval Request Details</returns>
        [HttpGet(ApiRoutes.Setup.ApprovalRequestDetailsByRequestNo)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<ApprovalRequestServiceWiseDetailedViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ApprovalRequestDetailsByRequestNo([FromRoute] int request_no)
        {

            return StatusCode(StatusCodes.Status200OK,
  
                new ApiResponse<ApprovalRequestServiceWiseDetailedViewModel> { Data = (await _service.Toshfa.FetchApprovalRequestDetailByRequestNo(request_no)).FirstOrDefault() });
        }



        /// <summary>
        /// This enpoint returns a list of member approved providers by policy number
        /// </summary>
        /// <param name="policy_no">Policy Number</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO member approved providers by Policy No</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberApprovedProversByPolicyNo)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<MemberApprovedProvidersViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> MemberApprovedProvidersByPolicyNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int policy_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var memberApprovedProviders = await _service.Toshfa.FetchAllMemberApprovedProvidersByPolicyNo(objModel, policy_no);
            return StatusCode(StatusCodes.Status200OK, memberApprovedProviders);

        }


        /// <summary>
        /// This enpoint returns a list of member claim details
        /// </summary>
        /// <returns>List of HMO member claim details</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberClaimsDetails)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberClaimsDetailsViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> MemberClaimDetails([FromQuery] PagingParam objModel)
        {
            var memberClaimDetails = await _service.Toshfa.FetchAllMemberClaimsDetails(objModel);
            return StatusCode(StatusCodes.Status200OK, memberClaimDetails);

        }





        /// <summary>
        /// This enpoint returns a list of member claim details by claim number
        /// </summary>
        /// <param name="claim_no">Claim Number</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO member claim details by claim number</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberClaimsDetailsByClaimNo)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberClaimsDetailsViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> MemberClaimDetailsByClaimNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int claim_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var memberClaimDetails = await _service.Toshfa.FetchAllMemberClaimsDetailsByClaimNo(objModel, claim_no);
            return StatusCode(StatusCodes.Status200OK, memberClaimDetails);

        }






        /// <summary>
        /// This enpoint returns a list of member dependent approval details
        /// </summary>
        /// <returns>List of HMO member dependent approval details</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberDependentApprovalDetails)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberDependentApprovalDetailsViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> MemberDependentApprovalDetails([FromQuery] PagingParam objModel)
        {
            var memberdependentApprovalDetails = await _service.Toshfa.FetchAllMemberDependentApprovalDetails(objModel);
            return StatusCode(StatusCodes.Status200OK, memberdependentApprovalDetails);
        }




        /// <summary>
        /// This enpoint returns a list of member dependent approval details by request no
        /// </summary>
        /// <param name="request_no">Request Number</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO member dependent approval details by request no</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberDependentApprovalDetailsByRequestNo)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberDependentApprovalDetailsViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> MemberDependentApprovalDetailsByRequestNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int request_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var memberdependentApprovalDetails = await _service.Toshfa.FetchAllMemberDependentApprovalDetailsByRequestNo(objModel, request_no);
            return StatusCode(StatusCodes.Status200OK, memberdependentApprovalDetails);

        }



        /// <summary>
        /// This enpoint returns a list of member dependent approval details by member no
        /// </summary>
        /// <param name="member_no">Member Number</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO member dependent approval details by member no</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberDependentApprovalDetailsByMemberNo)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberDependentApprovalDetailsViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> MemberDependentApprovalDetailsByMemberNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int member_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var memberdependentApprovalDetails = await _service.Toshfa.FetchAllMemberDependentApprovalDetailsByMemberNo(objModel, member_no);
            return StatusCode(StatusCodes.Status200OK, memberdependentApprovalDetails);

        }




        /// <summary>
        /// This enpoint returns a list of member dependent approval details by Avon Pa Code
        /// </summary>
        /// <param name="avon_pa_code">Avon Pa Code</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO member dependent approval details by member no</returns>
        [HttpGet(ApiRoutes.Setup.MemberDependentApprovalDetailsByAvonPaCode)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberDependentApprovalDetailsViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> MemberDependentApprovalDetailsAvonPaCode([FromQuery] int PageNumber, int PageSize, [FromRoute] string avon_pa_code)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };
            avon_pa_code = avon_pa_code.Replace("%2F", "/");

            var memberdependentApprovalDetails = await _service.Toshfa.FetchAllMemberDependentApprovalDetailsByAvonPaCode(objModel, avon_pa_code);
            return StatusCode(StatusCodes.Status200OK, memberdependentApprovalDetails);
        }





        /// <summary>
        /// This enpoint returns a list of member dependent claim details
        /// </summary>
        /// <returns>List of HMO member dependent claim details</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberDependentClaimsDetails)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberDependentClaimsDetailsViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> MemberDependentClaimDetails([FromQuery] PagingParam objModel)
        {
            var memberDependentApprovalDetails = await _service.Toshfa.FetchAllMemberDependentClaimsDetails(objModel);
            return StatusCode(StatusCodes.Status200OK, memberDependentApprovalDetails);
        }

        /// <summary>
        /// This enpoint returns List  Approval Request Details by policy number
        /// </summary>
        /// <param name="policy_no">Policy Number</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>List of Approval Request Details</returns>
        [HttpGet(ApiRoutes.Setup.ApprovalRequestDetailsByPolicyNo)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<ApprovalRequestDetailedViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ApprovalRequestDetailsByPolicyNo([FromRoute] int policy_no, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchApprovalRequestDetailByPolicyNo(policy_no, model));
        }

        /// <summary>
        /// This enpoint returns List Approval Request Details by Member number
        /// </summary>
        /// <param name="member_no">Member Number</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>List of Approval Request Details</returns>
        [HttpGet(ApiRoutes.Setup.ApprovalRequestDetailsByMemberNo)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<ApprovalRequestDetailedViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ApprovalRequestDetailsByMemberNo([FromRoute] int member_no, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
               await _service.Toshfa.FetchApprovalRequestDetailByMemberNo(member_no, model));
        }

        /// <summary>
        /// This enpoint returns List Approval Request Details by provider number
        /// </summary>
        /// <param name="provider_no">Member Number</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>List of Approval Request Details</returns>
        [HttpGet(ApiRoutes.Setup.ApprovalRequestDetailsByProviderNo)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<ApprovalRequestDetailedViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ApprovalRequestDetailsByProviderNo([FromRoute] string provider_no, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
              await _service.Toshfa.FetchApprovalRequestDetailByProvider(provider_no, model));

        }


        /// <summary>
        /// This enpoint returns  List Approval Request Details by Avon PA Code number
        /// </summary>
        /// <param name="pacode">Avon PA Code. Replace '/' in the Code with '-'  </param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>List of Approval Request Details</returns>
        [HttpGet(ApiRoutes.Setup.ApprovalRequestDetailsByPaCode)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<ApprovalRequestDetailedViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ApprovalRequestDetailsByPACode([FromRoute] string pacode, [FromQuery] PagingParam model)
        {

            pacode = string.IsNullOrEmpty(pacode) ? "" : pacode.Replace("-", "/");
            return StatusCode(StatusCodes.Status200OK,
             await _service.Toshfa.FetchApprovalRequestDetailByPacode(pacode, model));
        }




        /// <summary>
        /// This enpoint returns a list of member dependent claim details by claim no
        /// </summary>
        /// <param name="claim_no">Claim No</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO member dependent claim details by claim no</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberDependentClaimsDetailsByClaimNo)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberDependentClaimsDetailsViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> MemberDependentClaimDetailsByClaimNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int claim_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var memberDependentApprovalDetails = await _service.Toshfa.FetchAllMemberDependentClaimsDetailsByClaimNo(objModel, claim_no);
            return StatusCode(StatusCodes.Status200OK, memberDependentApprovalDetails);

        }




        /// <summary>
        /// This enpoint returns a list of member dependent claim details by member no
        /// </summary>
        /// <param name="member_no">Member No</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO member dependent claim details by member no</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberDependentClaimsDetailsByMemberNo)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberDependentClaimsDetailsViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> MemberDependentClaimDetailsByMemberNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int member_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var memberDependentApprovalDetails = await _service.Toshfa.FetchAllMemberDependentClaimsDetailsByMemberNo(objModel, member_no);
            return StatusCode(StatusCodes.Status200OK, memberDependentApprovalDetails);

        }



        /// <summary>
        /// This enpoint returns a list of member dependent details
        /// </summary>
        /// <returns>List of HMO member dependent details</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberDependentDetails)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberDependentDetailsViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> MemberDependentDetails([FromQuery] PagingParam objModel)
        {
            var memberDependentDetails = await _service.Toshfa.FetchAllMemberDependentDetails(objModel);
            return StatusCode(StatusCodes.Status200OK, memberDependentDetails);

        }




        /// <summary>
        /// This enpoint returns a list of member dependent details by Member No
        /// </summary>
        /// <param name="member_no">Member No</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO member dependent details by Member No</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberDependentDetailsByMemberNo)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberDependentDetailsViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> MemberDependentDetails([FromQuery] int PageNumber, int PageSize, [FromRoute] int member_no) //-----
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var memberDependentDetails = await _service.Toshfa.FetchAllMemberDependentDetailsByMemberNo(objModel, member_no);
            return StatusCode(StatusCodes.Status200OK, memberDependentDetails);

        }



        /// <summary>
        /// This enpoint returns a list of all member details
        /// </summary>
        /// <returns>List of HMO member details</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberDetails)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberDetailsViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> MemberDetails([FromQuery] PagingParam objModel)
        {
            var memberDetails = await _service.Toshfa.FetchAllMemberDetails(objModel);
            return StatusCode(StatusCodes.Status200OK, memberDetails);

        }




        /// <summary>
        /// This enpoint returns a list of all member details by member no
        /// </summary>
        /// <param name="member_no">Member No</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO member details by member no</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberDetailsByMemberNo)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberDetailsViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> MemberDetailsByMemberNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int member_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var memberDetails = await _service.Toshfa.FetchAllMemberDetailsByMemberNo(objModel, member_no);
            return StatusCode(StatusCodes.Status200OK, memberDetails);

        }





        /// <summary>
        /// This enpoint returns a list of all member details with Toshfa UID
        /// </summary>
        /// <returns>List of HMO member details with Toshfa UID</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberDetailsWithToshfaUID)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(PagedResponse<HmoMemberDetailsWithToshfaUIDViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> MemberDetailsWithToshfaUID([FromQuery] PagingParam objModel)
        {
            var memberDetailsWithTosfaUid = await _service.Toshfa.FetchAllMemberDetailsWithToshfaUID(objModel);
            return StatusCode(StatusCodes.Status200OK, memberDetailsWithTosfaUid);

        }

        /// <summary>
        /// This enpoint returns list of Approval Request Service wise Details
        /// </summary>
        /// <returns>List of Approval Request Service wise Details</returns>
        [HttpGet(ApiRoutes.Setup.AllApprovalRequestServiceDetails)]
        public async Task<IActionResult> AllApprovalRequestServiceDetails([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllApprovalRequestServiceDetails(model));
        }

        /// <summary>
        /// This enpoint returns List of Approval Request Service wise Details by Avon PA Code number
        /// </summary>
        /// <param name="pacode">Avon PA Code. Replace '/' in the Code with '-'  </param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>List of Approval Request Service wise Details</returns>
        [HttpGet(ApiRoutes.Setup.ApprovalRequestServiceDetailsByPaCode)]
        public async Task<IActionResult> ApprovalRequestServiceDetailsByPACode([FromRoute] string pacode, [FromQuery] PagingParam model)
        {
            pacode = string.IsNullOrEmpty(pacode) ? "" : pacode.Replace("-", "/");
            return StatusCode(StatusCodes.Status200OK,
               await _service.Toshfa.FetchAllApprovalRequestServiceByPacode(pacode, model));

        }


        /// <summary>
        /// This enpoint returns  List of Approval Request Service wise Details by Member number
        /// </summary>
        /// <param name="member_no">Member Number</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>List of Approval Request Service wise Details</returns>
        [HttpGet(ApiRoutes.Setup.ApprovalRequestServiceDetailsByMemberNo)]
        public async Task<IActionResult> ApprovalRequestServiceDetailsByMemberNo([FromRoute] int member_no, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
              await _service.Toshfa.FetchApprovalRequestServiceByMemberNo(member_no, model));

        }

        /// <summary>
        /// This enpoint returns  List of Approval Request Service wise Details by AVON Member number
        /// </summary>
        /// <param name="avon_member_no">Avon Member Number. Replace '/' in the Avon Member Number with '-' </param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>List of Approval Request Service wise Details</returns>
        [HttpGet(ApiRoutes.Setup.ApprovalRequestServiceDetailsByAvonMemberNo)]
        public async Task<IActionResult> ApprovalRequestServiceDetailsByAvonMemberNo([FromRoute] string avon_member_no, [FromQuery] PagingParam model)
        {
            avon_member_no = string.IsNullOrEmpty(avon_member_no) ? "" : avon_member_no.Replace("-", "/");
            return StatusCode(StatusCodes.Status200OK,
              await _service.Toshfa.FetchApprovalRequestServiceByAvonMemberNo(avon_member_no, model));

        }

        /// <summary>
        /// This enpoint returns  List Approval Request Service wise Details by policy number
        /// </summary>
        /// <param name="policy_no">Policy Number</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>List of Approval Service wise Request Details</returns>
        [HttpGet(ApiRoutes.Setup.ApprovalRequestServiceDetailsByPolicyNo)]
        public async Task<IActionResult> ApprovalRequestServiceDetailsByPolicyNo([FromRoute] int policy_no, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
              await _service.Toshfa.FetchApprovalRequestServiceByPolicyNo(policy_no, model));
        }

        /// <summary>
        /// This enpoint returns  Approval Request Service wise Details by Provider
        /// </summary>
        /// <param name="provider_no">provider Number</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>List of Approval Service wise Request Details</returns>
        [HttpGet(ApiRoutes.Setup.ApprovalRequestServiceDetailsByprovider)]
        public async Task<IActionResult> ApprovalRequestServiceDetailsByProviderNo([FromRoute] int provider_no, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
              await _service.Toshfa.FetchAllApprovalRequestServiceByProvider(provider_no, model));
        }

        /// <summary>
        /// This enpoint returns an Approval Request Details Service wise by request number
        /// </summary>
        /// <param name="request_no">Request No</param>
        /// <returns>List of Approval Request Service wise Details</returns>
        [HttpGet(ApiRoutes.Setup.ApprovalRequestServiceDetailsByRequestNo)]
        public async Task<IActionResult> ApprovalRequestServiceDetailsByRequestNo([FromRoute] int request_no)
        {

            return StatusCode(StatusCodes.Status200OK,
                    new ApiResponse<ApprovalRequestServiceWiseDetailedViewModel> { Data = (await _service.Toshfa.FetchApprovalRequestServiceByRequestNo(request_no)).FirstOrDefault() });

        }





        /// <summary>
        /// This enpoint returns a list of all member details with Toshfa UID 
        /// </summary>
        /// <param name="toshfa_uid">Toshfa UID</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO member details with Toshfa UID</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberDetailsWithToshfaUIDByToshfaUID)]
        public async Task<IActionResult> MemberDetailsWithToshfaUID([FromQuery] int PageNumber, int PageSize, [FromRoute] string toshfa_uid)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var memberDetailsWithTosfaUid = await _service.Toshfa.FetchAllMemberDetailsWithToshfaUIDByToshfaUID(objModel, toshfa_uid);
            return StatusCode(StatusCodes.Status200OK, memberDetailsWithTosfaUid);

        }







        /// <summary>
        /// This enpoint returns a list of all member information
        /// </summary>
        /// <returns>List of HMO member information</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberInformation)]
        public async Task<IActionResult> MemberInformation([FromQuery] PagingParam objModel)
        {
            var memberInformation = await _service.Toshfa.FetchAllMemberInformation(objModel);
            return StatusCode(StatusCodes.Status200OK, memberInformation);

        }




        /// <summary>
        /// This enpoint returns a list of all member information by member no
        /// </summary>
        /// <param name="member_no">member No</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO member information by member no</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberInformationByMemberNo)]
        public async Task<IActionResult> MemberInformationByMemberNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int member_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var memberInformation = await _service.Toshfa.FetchAllMemberInformationByMemberNo(objModel, member_no);
            return StatusCode(StatusCodes.Status200OK, memberInformation);

        }





        /// <summary>
        /// This enpoint returns a list of all member master 
        /// </summary>
        /// <returns>List of HMO member master</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberMaster)]
        public async Task<IActionResult> MemberMaster([FromQuery] PagingParam objModel)
        {
            var memberMaster = await _service.Toshfa.FetchAllMemberMaster(objModel);
            return StatusCode(StatusCodes.Status200OK, memberMaster);

        }





        /// <summary>
        /// This enpoint returns a list of all member master by primary provider no
        /// </summary>
        /// <param name="primary_provider_no">Primary Provider No</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO member master by Primary Provider No</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberMasterByPrimaryProviderNo)]
        public async Task<IActionResult> MemberMasterByPrimaryProviderNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int primary_provider_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };


            var memberMaster = await _service.Toshfa.FetchAllMemberMasterByPrimaryProviderNo(objModel, primary_provider_no);
            return StatusCode(StatusCodes.Status200OK, memberMaster);

        }



        /// <summary>
        /// This enpoint returns a list of all Member Policy Limits Exhausted And Available
        /// </summary>
        /// <returns>List of HMO Member Policy Limits Exhausted And Available </returns>
        [HttpGet(ApiRoutes.Setup.AllMemberPolicyLimitsExhaustedAndAvailable)]
        public async Task<IActionResult> MemberPolicyLimitsExhaustedAndAvailable([FromQuery] PagingParam objModel)
        {
            var memberPolLmtExMaster = await _service.Toshfa.FetchAllMemberPolicyLimitsExhaustedAndAvailable(objModel);
            return StatusCode(StatusCodes.Status200OK, memberPolLmtExMaster);

        }

        /// <summary>
        /// This enpoint returns an Approval Utilization Request Details  by request number
        /// </summary>
        /// <param name="request_no">Request No</param>
        /// <returns>List of Approval Request Utilization Details</returns>
        [HttpGet(ApiRoutes.Setup.ApprovalRequestutilizationDetailsByRequestNo)]
        public async Task<IActionResult> ApprovalRequestutilizationDetailsByRequestNo([FromRoute] int request_no)
        {
            return StatusCode(StatusCodes.Status200OK,

                   new ApiResponse<ApprovalReqUtilizationDetailsViewModel>
                   {
                       Data = (await _service.Toshfa.FetchApprovalRequestUtilizationRequestNo(request_no)).FirstOrDefault()
                   });

        }

        /// <summary>
        /// This enpoint returns List of  Approval Request Utilization Details by Avon PA Code number
        /// </summary>
        /// <param name="pacode">Avon PA Code. Replace '/' in the Code with '-'  </param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>List of Approval Request Utilization Details</returns>
        [HttpGet(ApiRoutes.Setup.ApprovalRequestutilizationDetailsByPaCode)]
        public async Task<IActionResult> ApprovalRequestUtilizationDetailsByPACode([FromRoute] string pacode, [FromQuery] PagingParam model)
        {
            pacode = string.IsNullOrEmpty(pacode) ? "" : pacode.Replace("-", "/");
            return StatusCode(StatusCodes.Status200OK,
               await _service.Toshfa.FetchApprovalRequestUtilizationByPacode(pacode, model));
        }

        /// <summary>
        /// This enpoint returns list of Approval Request Utilization Details
        /// </summary>
        /// <returns>List of Approval Request Utilization Details</returns>
        [HttpGet(ApiRoutes.Setup.AllApprovalRequestutilizationDetails)]
        public async Task<IActionResult> AllApprovalRequestUtilizationDetails([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllApprovalRequestUtilizationDetail(model));
        }





        /// <summary>
        /// This enpoint returns list of Pending Approval Request Utilization Details
        /// </summary>
        /// <returns>List of Approval Request Utilization Details</returns>
        [HttpGet(ApiRoutes.Setup.AllPendingApprovalRequestutilizationDetails)]
        public async Task<IActionResult> AllPendingApprovalRequestUtilizationDetails([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllPendingApprovalRequestUtilizationDetail(model));
        }

        /// <summary>
        /// This enpoint returns List Pending Approval Request Utilization Details by Avon PA Code number
        /// </summary>
        /// <param name="pacode">Avon PA Code. Replace '/' in the Code with '-'  </param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>List of Pending Approval Request Utilization Details</returns>
        [HttpGet(ApiRoutes.Setup.PendingApprovalRequestutilizationDetailsByPaCode)]
        public async Task<IActionResult> PenignApprovalRequestUtilizationDetailsByPACode([FromRoute] string pacode, [FromQuery] PagingParam model)
        {
            pacode = string.IsNullOrEmpty(pacode) ? "" : pacode.Replace("-", "/");
            return StatusCode(StatusCodes.Status200OK,
               await _service.Toshfa.FetchPendingApprovalRequestUtilizationByPacode(pacode, model));
        }


        /// <summary>
        /// This enpoint returns Pending Approval Utilization Request Details  by request number
        /// </summary>
        /// <param name="request_no">Request No</param>
        /// <returns>Pending Approval Request Utilization Details</returns>
        [HttpGet(ApiRoutes.Setup.PendingApprovalRequestutilizationDetailsByRequestNo)]
        public async Task<IActionResult> PendingApprovalRequestutilizationDetailsByRequestNo([FromRoute] int request_no)
        {
            return StatusCode(StatusCodes.Status200OK,

                   new ApiResponse<ApprovalReqUtilizationPendingDetailsViewModel>
                   {
                       Data = (await _service.Toshfa.FetchPendingApprovalRequestUtilizationRequestNo(request_no)).FirstOrDefault(),
                       hasError = false,
                   });
            
        }




        /// <summary>
        /// This enpoint returns a list of all Member Policy Limits Exhausted And Available  By Member No
        /// </summary>
        /// <param name="member_no">Member No</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Member Policy Limits Exhausted And Available By Member No </returns>
        [HttpGet(ApiRoutes.Setup.AllMemberPolicyLimitsExhaustedAndAvailableByMemberNo)]
        public async Task<IActionResult> MemberPolicyLimitsExhaustedAndAvailable([FromQuery] int PageNumber, int PageSize, [FromRoute] int member_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var memberPolLmtExMaster = await _service.Toshfa.FetchAllMemberPolicyLimitsExhaustedAndAvailableByMemberNo(objModel, member_no);
            return StatusCode(StatusCodes.Status200OK, memberPolLmtExMaster);

        }




        /// <summary>
        /// This enpoint returns a list of all Member Policy Status 
        /// </summary>
        /// <returns>List of HMO Member Policy Status </returns>
        [HttpGet(ApiRoutes.Setup.AllMemberPolicyStatus)]
        public async Task<IActionResult> MemberPolicyStatus([FromQuery] PagingParam objModel)
        {
            var memberPolicyStatus = await _service.Toshfa.FetchAllMemberPolicyStatus(objModel);
            return StatusCode(StatusCodes.Status200OK, memberPolicyStatus);
        }



        /// <summary>
        /// This enpoint returns a list of all Members 
        /// </summary>
        /// <returns>List of HMO Members </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoMembersList)]
        public async Task<IActionResult> MemberList([FromQuery] PagingParam objModel)
        {
            var membersList = await _service.Toshfa.FetchAllMembersList(objModel);

            return StatusCode(StatusCodes.Status200OK, membersList);

        }






        /// <summary>
        /// This enpoint returns a list of all Members By Member No
        /// </summary>
        /// <param name="member_no">Member No</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Members By Member No </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoMembersListByMemberNo)]
        public async Task<IActionResult> MemberListByMemberNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int member_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var membersList = await _service.Toshfa.FetchAllMembersListByMemberNo(objModel, member_no);


            return StatusCode(StatusCodes.Status200OK, membersList);

        }







        /// <summary>
        /// This enpoint returns a list of all Members Status
        /// </summary>
        /// <returns>List of HMO Members Status </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoMemberStatus)]
        public async Task<IActionResult> MemberStatus([FromQuery] PagingParam objModel)
        {
            var memberStatus = await _service.Toshfa.FetchAllMemberStatus(objModel);

            return StatusCode(StatusCodes.Status200OK, memberStatus);

        }



        /// <summary>
        /// This enpoint returns a list of all Member Wise Premium Details
        /// </summary>
        /// <returns>List of HMO Members Wise Premium Details </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoMemberWisePremiumDtls)]
        public async Task<IActionResult> MemberWisePremiumDtls([FromQuery] PagingParam objModel)
        {

            var memberWisePremDtls = await _service.Toshfa.FetchAllMemberWisePremiumDtls(objModel);

            return StatusCode(StatusCodes.Status200OK, memberWisePremDtls);

        }

        /// <summary>
        /// This enpoint returns list of Average Claims Per Enrollee
        /// </summary>
        /// <returns>List of Average Claims Per Enrollee</returns>
        [HttpGet(ApiRoutes.Setup.AllAverageClaimsPerEnrollee)]
        public async Task<IActionResult> AllAverageClaimsPerEnrollee([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllAverageClaimsPaidPerEnrollee(model));
        }
        /// <summary>
        /// This enpoint returns list of Average Premium Per Enrollee
        /// </summary>
        /// <returns>List of Average Premium Per Enrollee</returns>
        [HttpGet(ApiRoutes.Setup.AllAveragePremiumPerEnrollee)]
        public async Task<IActionResult> AllAveragePremiumPerEnrollee([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllAveragePremiumPaidPerEnrollee(model));
        }

        /// <summary>
        /// This enpoint returns list of Average Premium Per Plan
        /// </summary>
        /// <returns>List of Average Premium Per Plan</returns>
        [HttpGet(ApiRoutes.Setup.AllAveragePremiumPerPlan)]
        public async Task<IActionResult> AllAveragePremiumPerPlan([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllAveragePremiumPerPlan(model));
        }

        /// <summary>
        /// This enpoint returns list of Enrollee Capitation/Policy and Plan Detail Report
        /// </summary>
        /// <returns>List of Enrollee Capitation/Policy and Plan Detail Report</returns>
        [HttpGet(ApiRoutes.Setup.AllEnrolleeCapitationPlanDetailReport)]
        public async Task<IActionResult> AllEnrolleeCapitationPolicyAndPlanDetailReport([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllEnrolleeCapitationDetailReport(model));
        }


        /// <summary>
        /// This enpoint returns list of Enrollee Capitation/Policy and Plan Detail Reportpolicy number
        /// </summary>
        /// <param name="policy_no">Policy Number</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>List of Enrollee Capitation/Policy and Plan Detail Report</returns>
        [HttpGet(ApiRoutes.Setup.AllEnrolleeCapitationPlanDetailReportByPolicyNo)]
        public async Task<IActionResult> EnrolleeCapitationPolicyAndPlanDetailReportByPolicyNo([FromRoute] int policy_no, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
               await _service.Toshfa.FetchEnrolleeCapitationDetailReportByPolicyNo(policy_no, model));
        }


        /// <summary>
        /// This enpoint returns list of Claims Actuarial Analysis
        /// </summary>
        /// <returns>List of Claims Actuarial Analysis</returns>
        [HttpGet(ApiRoutes.Setup.AllClaimsActuarialAnalysis)]
        public async Task<IActionResult> AllClaimsActuarialAnalysis([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchClaimsActuarialAnalysis5(model));
        }
        /// <summary>
        /// This enpoint returns list of Claims Information
        /// </summary>
        /// <returns>List of Claims Information</returns>
        [HttpGet(ApiRoutes.Setup.AllClaimsInfo)]
        public async Task<IActionResult> AllClaimsInfo([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllClaimsInformation(model));
        }

        /// <summary>
        /// This enpoint returns list of Client Posted Premium Detail
        /// </summary>
        /// <returns>List of Client Posted Premium Detail</returns>
        [HttpGet(ApiRoutes.Setup.AllClientPostedPremium)]
        public async Task<IActionResult> ClientPostedPremium([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllClientPostedPremium(model));
        }

        /// <summary>
        /// This enpoint returns list of Consultation Prices
        /// </summary>
        /// <returns>List of Consultation Prices</returns>
        [HttpGet(ApiRoutes.Setup.ConsultationPrices)]
        public async Task<IActionResult> AllConsultationPrices([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllConsultationPrices(model));
        }

        /// <summary>
        /// This enpoint returns  Consultation Prices for A Provider
        /// </summary>
        /// <param name="provider_no">provider Number</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>List of  Consultation Prices</returns>
        [HttpGet(ApiRoutes.Setup.ConsultationPricesByproviderno)]
        public async Task<IActionResult> ConsultationPricesByProviderNo([FromRoute] int provider_no, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
              await _service.Toshfa.FetchAllConsultationPricesByProvider(provider_no, model));
        }

        /// <summary>
        /// This enpoint returns  List Enroller Information for a member
        /// </summary>
        /// <param name="member_no">Member Number</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>Enroller Information </returns>
        [HttpGet(ApiRoutes.Setup.EnrolleeInformationByMemberNo)]
        public async Task<IActionResult> Enrollee_InformationByMemberNo([FromRoute] int member_no, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
               await _service.Toshfa.FetchEnrollee_InformationByMemberNo(member_no, model));
        }

        /// <summary>
        /// This enpoint returns list of  Enroller Information
        /// </summary>
        /// <returns>List of  Enroller Information</returns>
        [HttpGet(ApiRoutes.Setup.EnrolleeInformation)]
        public async Task<IActionResult> AllEnrollee_Information([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchEnrollee_Information(model));
        }

        /// <summary>
        /// This enpoint returns list of  Enroller Member
        /// </summary>
        /// <returns>List of Enroller Member</returns>
        [HttpGet(ApiRoutes.Setup.EnrolleeMembers)]
        public async Task<IActionResult> AllEnrolleeEnrollerMember([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllEnrolleeMember(model));
        }

        /// <summary>
        /// This enpoint returns  Enroller Member for a member
        /// </summary>
        /// <param name="member_no">Member Number</param>
        ///  <param name="model">Paging Parameter Model  </param>
        /// <returns>Enroller Member </returns>
        [HttpGet(ApiRoutes.Setup.EnrolleeMemberByMemberNo)]
        public async Task<IActionResult> EnrolleeMemberByMemberNo([FromRoute] int member_no, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
              await _service.Toshfa.FetchEnrolleeMemberByMemberNo(member_no, model));
        }


        /// <summary>
        /// This enpoint returns list ERX Diagnosis Details
        /// </summary>
        /// <returns>List of ERX Diagnosis Details</returns>
        [HttpGet(ApiRoutes.Setup.ERXDiagnosis)]
        public async Task<IActionResult> AllERXDiagnosisDetails([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllERXDiagnosisDetails(model));
        }


        /// <summary>
        /// This enpoint returns list of ERX Diagnosis Detail for a code
        /// </summary>
        /// <param name="code">ERX Diagnosis Code, Replace '/' in the Code with '-'</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>ERX Diagnosis </returns>
        [HttpGet(ApiRoutes.Setup.ERXDiagnosisByCode)]
        public async Task<IActionResult> ERXDiagnosisByMemberNo([FromRoute] string code, [FromQuery] PagingParam model)
        {
            code = string.IsNullOrEmpty(code) ? "" : code.Replace("-", "/");
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchERXDiagnosisDetailByCodes(code, model));

        }



        /// <summary>
        /// This enpoint returns a list of all Member Wise Premium Details By PolicyNo
        /// </summary>
        /// <param name="policy_no">Policy No</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Members Wise Premium Details  By PolicyNo </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoMemberWisePremiumDtlsByPolicyNo)]
        public async Task<IActionResult> MemberWisePremiumDtlsByPolicyNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int policy_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var memberWisePremDtls = await _service.Toshfa.FetchAllMemberWisePremiumDtlsByPolicyNo(objModel, policy_no);

            return StatusCode(StatusCodes.Status200OK, memberWisePremDtls);

        }


        /// <summary>
        /// This enpoint returns list Specialities
        /// </summary>
        /// <returns>List of Specialities</returns>
        [HttpGet(ApiRoutes.Setup.specialities)]
        public async Task<IActionResult> AllSpecialities([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchASepcialities(model));
        }

        /// <summary>
        /// This enpoint returns  Specialities for a code
        /// </summary>
        /// <param name="code">Speciality Code,Replace '/' in the Code with '-'</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>Speciality </returns>
        [HttpGet(ApiRoutes.Setup.specialityByCode)]
        public async Task<IActionResult> SpecialityByCode([FromRoute] string code, [FromQuery] PagingParam model)
        {
            code = string.IsNullOrEmpty(code) ? "" : code.Replace("-", "/");
            return StatusCode(StatusCodes.Status200OK,
               await _service.Toshfa.FetchSepcialityByCodes(code, model));
        }


        /// <summary>
        /// This enpoint returns List of ICD Codes
        /// </summary>
        /// <returns>List of ICD Codes</returns>
        [HttpGet(ApiRoutes.Setup.IcdCodes)]
        public async Task<IActionResult> AllICDCodes([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllICDCodes(model));
        }

        /// <summary>
        /// This enpoint returns  ICD Code By acode
        /// </summary>
        /// <param name="code">Icd Code, Replace '/' in the Code with '-'</param>
        /// <returns>Speciality </returns>
        [HttpGet(ApiRoutes.Setup.IcdCodesByCode)]
        public async Task<IActionResult> ICDCodeByCode([FromRoute] string code)
        {
            code = string.IsNullOrEmpty(code) ? "" : code.Replace("-", "/");

            var results = await _service.Toshfa.FetchICDCodeByCodes(code);

            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<List<SpecialityMasterViewModel>> { Data = results, hasError = false });
        }


        /// <summary>
        /// This enpoint returns List of ICD Dentals
        /// </summary>
        /// <returns>List of ICD Dentals</returns>
        [HttpGet(ApiRoutes.Setup.IcdDentals)]
        public async Task<IActionResult> AllICDDentals([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllICDDentals(model));
        }


        /// <summary>
        /// This enpoint returns List of ICD Dentals By acode
        /// </summary>
        /// <param name="code">Icd Code, Replace '/' in the Code with '-'</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>Speciality </returns>
        [HttpGet(ApiRoutes.Setup.IcdDentalsByCode)]
        public async Task<IActionResult> ICDDentalByCode([FromRoute] string code, PagingParam model)
        {
            code = string.IsNullOrEmpty(code) ? "" : code.Replace("-", "/");
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchICDDentalsByCodes(code, model));
        }



        /// <summary>
        /// This enpoint returns List of Loss Ratio Per Plan
        /// </summary>
        /// <returns>List of Loss Ratio Per Plan</returns>
        [HttpGet(ApiRoutes.Setup.LostRatioPerPlan)]
        public async Task<IActionResult> AllLossRatioPerPlan([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllLossRatioPerPlan(model));
        }

        /// <summary>
        /// This enpoint returns List of Member Approvals
        /// </summary>
        /// <returns>List of Member Approvals</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberApproval)]
        public async Task<IActionResult> AllMemberApproval([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllMemberApproval(model));
        }

        /// <summary>
        /// This enpoint returns   Member Approval By Request Number
        /// </summary>
        /// <param name="request_no">Request Number</param>
        /// <returns>Member Approval </returns>
        [HttpGet(ApiRoutes.Setup.MemberApprovalByReqNo)]
        public async Task<IActionResult> MemberApprovalByRequestNo([FromRoute] string request_no)
        {
            var membersApprovals = await _service.Toshfa.FetchMemberApprovalByRequestNo(request_no);

            return StatusCode(StatusCodes.Status200OK,
                new ApiResponse<List<MemberApprovalViewModel>> { Data = membersApprovals, hasError = false });
        }

        /// <summary>
        /// This enpoint returns List of Member Approval By pa code
        /// </summary>
        /// <param name="pacode">Avon Pa Code, Replace '/' in the Code with '-'</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>Member Approval </returns>
        [HttpGet(ApiRoutes.Setup.MemberApprovalByCode)]
        public async Task<IActionResult> MemberApprovalByPaCode([FromRoute] string pacode, [FromQuery] PagingParam model)
        {
            pacode = string.IsNullOrEmpty(pacode) ? "" : pacode.Replace("-", "/");
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchMemberApprovalByPaCode(pacode, model));

        }

        /// <summary>
        /// This enpoint  returns List of Member Approval By Policy No
        /// </summary>
        /// <param name="policy_no">Policy No</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>Member Approval </returns>
        [HttpGet(ApiRoutes.Setup.MemberApprovalByPolicyNo)]
        public async Task<IActionResult> MemberApprovalBypolicyno([FromRoute] int policy_no, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
               await _service.Toshfa.FetchMemberApprovalByPolicyNo(policy_no, model));

        }




        /// <summary>
        /// This enpoint returns a list of all Missing Services Details Approval
        /// </summary>
        /// <returns>List of HMO Members Wise Premium Details </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoMissingServicesDetailsApproval)]
        public async Task<IActionResult> MissingServicesDetailsApproval([FromQuery] PagingParam objModel)
        {
            var missingSrvcApproval = await _service.Toshfa.FetchAllMissingServicesDetailsApproval(objModel);

            return StatusCode(StatusCodes.Status200OK, missingSrvcApproval);
        }


        /// <summary>
        /// This enpoint returns Member Approval By Member No
        /// </summary>
        /// <param name="member_no">Member No</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>Member Approval </returns>
        [HttpGet(ApiRoutes.Setup.MemberApprovalByMemberNo)]
        public async Task<IActionResult> MemberApprovalByMemberNo([FromRoute] int member_no, [FromQuery] PagingParam model)
        {

            return StatusCode(StatusCodes.Status200OK,
               await _service.Toshfa.FetchMemberApprovalByMemberNo(member_no, model));

        }





        /// <summary>
        /// This enpoint returns a list of all Missing Services Details Approval By RequestNo
        /// </summary>
        /// /// <param name="request_no">Request No</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Members Wise Premium Details By RequestNo </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoMissingServicesDetailsApprovalByRequestNo)]
        public async Task<IActionResult> MissingServicesDetailsApproval([FromQuery] int PageNumber, int PageSize, [FromRoute] int request_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };


            var missingSrvcApproval = await _service.Toshfa.FetchAllMissingServicesDetailsApprovalByRequestNo(objModel, request_no);

            return StatusCode(StatusCodes.Status200OK, missingSrvcApproval);

        }


        /// <summary>
        /// This enpoint returns List of  Member Details with ToshfaUID
        /// </summary>
        /// <returns>List of  Member Details with ToshfaUID</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberDetailWithToshfaUid)]
        public async Task<IActionResult> AllMemberDetailsWithToshfaUID([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllMemberDetailswithToshfaUID(model));

        }





        /// <summary>
        /// This enpoint returns a list of all Missing Services Details Approval By ProviderNo
        /// </summary>
        /// /// <param name="provider_no">Request No</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Members Wise Premium Details By ProviderNo </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoMissingServicesDetailsApprovalByProviderNo)]
        public async Task<IActionResult> MissingServicesDetailsApprovalByProviderNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int provider_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var missingSrvcApproval = await _service.Toshfa.FetchAllMissingServicesDetailsApprovalByProviderNo(objModel, provider_no);

            return StatusCode(StatusCodes.Status200OK, missingSrvcApproval);

        }





        /// <summary>
        /// This enpoint returns a list of all Missing Services Details Approval By ProviderNo
        /// </summary>
        /// /// <param name="policy_no">Request No</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Members Wise Premium Details By ProviderNo </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoMissingServicesDetailsApprovalByPolicyNo)]
        public async Task<IActionResult> MissingServicesDetailsApprovalByPolicyNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int policy_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };


            var missingSrvcApproval = await _service.Toshfa.FetchAllMissingServicesDetailsApprovalByPolicyNo(objModel, policy_no);

            return StatusCode(StatusCodes.Status200OK, missingSrvcApproval);

        }




        /// <summary>
        /// This enpoint returns a list of all Missing Services Details Approval By AvonPaCode
        /// </summary>
        /// <param name="avon_pa_code">AvonPaCode</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Members Wise Premium Details By AvonPaCode </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoMissingServicesDetailsApprovalByAvonPaCode)]
        public async Task<IActionResult> MissingServicesDetailsApprovalByPolicyNo([FromQuery] int PageNumber, int PageSize, [FromRoute] string avon_pa_code)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            avon_pa_code = avon_pa_code.Replace("%2F", "/");

            var missingSrvcApproval = await _service.Toshfa.FetchAllMissingServicesDetailsApprovalByAvonPaCode(objModel, avon_pa_code);

            return StatusCode(StatusCodes.Status200OK, missingSrvcApproval);


        }



        /// <summary>
        /// This enpoint returns all Package Price List
        /// </summary>
        /// <returns>List of HMO Package Price List </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPackagePriceList)]
        public async Task<IActionResult> PackagePriceList([FromQuery] PagingParam objModel)
        {
            var pckagePriceLst = await _service.Toshfa.FetchAllPackagePriceList(objModel);
            return StatusCode(StatusCodes.Status200OK, pckagePriceLst);

            #region
            //return StatusCode(StatusCodes.Status200OK,
            //    new PagedResponse<HmoPackagePriceListViewModel>
            //    (pckagePriceLst));
            #endregion
        }





        /// <summary>
        /// This enpoint returns all Package Price Lit By Provider No
        /// </summary>
        /// <param name="provider_no">Provider No</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Members Wise Premium Details </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPackagePriceListByProviderNo)]
        public async Task<IActionResult> PackagePriceListByProviderNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int provider_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var pckagePriceLst = await _service.Toshfa.FetchAllPackagePriceListByProviderNo(objModel, provider_no);
            return StatusCode(StatusCodes.Status200OK, pckagePriceLst);

        }




        /// <summary>
        /// This enpoint returns a list of all Plan Master Details Dental Exclusions
        /// </summary>
        /// <returns>List of HMO Plan Master Details Dental Exclusions </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsDentalExclusions)]
        public async Task<IActionResult> PlanMasterDetailsDentalExclusions([FromQuery] PagingParam objModel)
        {
            var pckagePriceLst = await _service.Toshfa.FetchAllPlanMasterDetailsDentalExclusions(objModel);
            return StatusCode(StatusCodes.Status200OK, pckagePriceLst);

        }





        /// <summary>
        /// This enpoint returns a list of all Plan Master Details Dental Exclusions By Policy No
        /// </summary>
        /// <param name="policy_no">Policy No</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Plan Master Details Dental Exclusions By Policy No </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsDentalExclusionsByPolicyNo)]
        public async Task<IActionResult> PlanMasterDetailsDentalExclusionsByPolicyNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int policy_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var pckagePriceLst = await _service.Toshfa.FetchAllPlanMasterDetailsDentalExclusionsByPolicyNo(objModel, policy_no);
            return StatusCode(StatusCodes.Status200OK, pckagePriceLst);
        }




        /// <summary>
        /// This enpoint returns a list of all Plan Master Details Dental Inclusions
        /// </summary>
        /// <returns>List of HMO Plan Master Details Dental Inclusions </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsDentalInclusions)]
        public async Task<IActionResult> PlanMasterDetailsDentalInclusions([FromQuery] PagingParam objModel)
        {
            var planMasterDtInclusion = await _service.Toshfa.FetchAllPlanMasterDetailsDentalInclusions(objModel);
            return StatusCode(StatusCodes.Status200OK, planMasterDtInclusion);

        }





        /// <summary>
        /// This enpoint returns a list of all Plan Master Details Dental Inclusions By Policy No
        /// </summary>
        /// <param name="policy_no">Policy No</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Plan Master Details Dental Inclusions By Policy No </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsDentalInclusionsByPolicyNo)]
        public async Task<IActionResult> PlanMasterDetailsDentalInclusionsByPolicyNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int policy_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var planMasterDtInclusion = await _service.Toshfa.FetchAllPlanMasterDetailsDentalInclusionsByPolicyNo(objModel, policy_no);
            return StatusCode(StatusCodes.Status200OK, planMasterDtInclusion);

        }




        /// <summary>
        /// This enpoint returns a list of all Plan Master Details Dental SubLimit
        /// </summary>
        /// <returns>List of HMO Plan Master Details Dental SubLimit </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsDentalSubLimit)]
        public async Task<IActionResult> PlanMasterDetailsDentalSubLimit([FromQuery] PagingParam objModel)
        {

            var planMasterDtlsSubLimit = await _service.Toshfa.FetchAllPlanMasterDetailsDentalSubLimit(objModel);
            return StatusCode(StatusCodes.Status200OK, planMasterDtlsSubLimit);

        }





        /// <summary>
        /// This enpoint returns a list of all Plan Master Details Dental SubLimit By Policy No
        /// </summary>
        /// <param name="policy_no">Policy No</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Plan Master Details Dental SubLimit By PolicyNo </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsDentalSubLimitByPolicyNo)]
        public async Task<IActionResult> PlanMasterDetailsDentalSubLimitByPolicyNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int policy_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var planMasterDtlsSubLimit = await _service.Toshfa.FetchAllPlanMasterDetailsDentalSubLimitByPolicyNo(objModel, policy_no);
            return StatusCode(StatusCodes.Status200OK, planMasterDtlsSubLimit);
        }




        /// <summary>
        /// This enpoint returns a list of all Plan Master Details Dental SubLimit By Code
        /// </summary>
        /// <param name="code">Code</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Plan Master Details Dental SubLimit By Code </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsDentalSubLimitByCode)]
        public async Task<IActionResult> PlanMasterDetailsDentalSubLimitByCode([FromQuery] int PageNumber, int PageSize, [FromRoute] string code)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var planMasterDtlsSubLimit = await _service.Toshfa.FetchAllPlanMasterDetailsDentalSubLimitByCode(objModel, code);
            return StatusCode(StatusCodes.Status200OK, planMasterDtlsSubLimit);
        }






        /// <summary>
        /// This enpoint returns a list of all Plan Master Details ICD Exclusions
        /// </summary>
        /// <returns>List of HMO Plan Master Details ICD Exclusions </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsICDExclusions)]
        public async Task<IActionResult> PlanMasterDetailsICDExclusions([FromQuery] PagingParam objModel)
        {
            var planMasterDtlsICDEx = await _service.Toshfa.FetchAllHmoPlanMasterDetailsICDExclusions(objModel);
            return StatusCode(StatusCodes.Status200OK, planMasterDtlsICDEx);

        }





        /// <summary>
        /// This enpoint returns a list of all Plan Master Details ICD Exclusions By Policy No
        /// </summary>
        /// <param name="policy_no">Policy No</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Plan Master Details ICD Exclusions By Policy No </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsICDExclusionsByPolicyNo)]
        public async Task<IActionResult> PlanMasterDetailsICDExclusions([FromQuery] int PageNumber, int PageSize, [FromRoute] int policy_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var planMasterDtlsICDEx = await _service.Toshfa.FetchAllHmoPlanMasterDetailsICDExclusionsByPolicyNo(objModel, policy_no);
            return StatusCode(StatusCodes.Status200OK, planMasterDtlsICDEx);

        }





        /// <summary>
        /// This enpoint returns a list of all Plan Master Details ICD Exclusions By Code
        /// </summary>
        /// <param name="code">Code</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Plan Master Details ICD Exclusions By Code </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsICDExclusionsByCode)]
        public async Task<IActionResult> PlanMasterDetailsICDExclusionsByCode([FromQuery] int PageNumber, int PageSize, [FromRoute] string code)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var planMasterDtlsICDEx = await _service.Toshfa.FetchAllHmoPlanMasterDetailsICDExclusionsByCode(objModel, code);
            return StatusCode(StatusCodes.Status200OK, planMasterDtlsICDEx);

        }






        /// <summary>
        /// This enpoint returns a list of all Plan Master Details ICD Inclusions
        /// </summary>
        /// <returns>List of HMO Plan Master Details ICD Inclusions </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsICDInclusions)]
        public async Task<IActionResult> PlanMasterDetailsICDInclusions([FromQuery] PagingParam objModel)
        {

            var planMasterDtlsICDIncl = await _service.Toshfa.FetchAllHmoPlanMasterDetailsICDInclusions(objModel);
            return StatusCode(StatusCodes.Status200OK, planMasterDtlsICDIncl);

        }





        /// <summary>
        /// This enpoint returns a list of all Plan Master Details ICD Inclusions
        /// </summary>
        /// <param name="policy_no">PolicyNo</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Plan Master Details ICD Inclusions </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsICDInclusionsByPolicyNo)]
        public async Task<IActionResult> PlanMasterDetailsICDInclusionsByPolicyNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int policy_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var planMasterDtlsICDIncl = await _service.Toshfa.FetchAllHmoPlanMasterDetailsICDInclusionsByPolicyNo(objModel, policy_no);
            return StatusCode(StatusCodes.Status200OK, planMasterDtlsICDIncl);

        }





        /// <summary>
        /// This enpoint returns a list of all Plan Master Details ICD Inclusions By Code
        /// </summary>
        /// <param name="code">Code</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Plan Master Details ICD Inclusions By Code </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsICDInclusionsByCode)]
        public async Task<IActionResult> PlanMasterDetailsICDInclusionsByCode([FromQuery] int PageNumber, int PageSize, [FromRoute] string code)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var planMasterDtlsICDIncl = await _service.Toshfa.FetchAllHmoPlanMasterDetailsICDInclusionsByCode(objModel, code);
            return StatusCode(StatusCodes.Status200OK, planMasterDtlsICDIncl);

        }





        /// <summary>
        /// This enpoint returns a list of all Plan Master Details Information
        /// </summary>
        /// <returns>List of HMO Plan Master Details Information </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsInformation)]
        public async Task<IActionResult> PlanMasterDetailsInformation([FromQuery] PagingParam objModel)
        {
            var planMasterDtlsInfo = await _service.Toshfa.FetchAllHmoPlanMasterDetailsInformation(objModel);
            return StatusCode(StatusCodes.Status200OK, planMasterDtlsInfo);

        }




        /// <summary>
        /// This enpoint returns a list of all Plan Master Details Information By Policy No
        /// </summary>
        /// <param name="policy_no">Policy No</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Plan Master Details Information By Policy No </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsInformationByPolicyNo)]
        public async Task<IActionResult> PlanMasterDetailsInformation([FromQuery] int PageNumber, int PageSize, [FromRoute] int policy_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var planMasterDtlsInfo = await _service.Toshfa.FetchAllHmoPlanMasterDetailsInformationByPolicyNo(objModel, policy_no);
            return StatusCode(StatusCodes.Status200OK, planMasterDtlsInfo);

        }





        /// <summary>
        /// This enpoint returns a list of all Plan Master Details Information By Template Code
        /// </summary>
        /// <param name="temp_code">Template Code</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Plan Master Details Information By Policy No </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsInformationByTemplateCode)]
        public async Task<IActionResult> PlanMasterDetailsInformationByTemplateCode([FromQuery] int PageNumber, int PageSize, [FromRoute] int temp_code)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var planMasterDtlsInfo = await _service.Toshfa.FetchAllHmoPlanMasterDetailsInformationByTemplateCode(objModel, temp_code);
            return StatusCode(StatusCodes.Status200OK, planMasterDtlsInfo);

        }






        /// <summary>
        /// This enpoint returns a list of all Plan Master Details Maternity SubLimit
        /// </summary>
        /// <returns>List of HMO Plan Master Details Maternity SubLimit </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsMaternitySubLimit)]
        public async Task<IActionResult> PlanMasterDetailsMaternitySubLimit([FromQuery] PagingParam objModel)
        {
            var planMasterDtlsMatSubLmt = await _service.Toshfa.FetchAllHmoPlanMasterDetailsMaternitySubLimit(objModel);
            return StatusCode(StatusCodes.Status200OK, planMasterDtlsMatSubLmt);

        }




        /// <summary>
        /// This enpoint returns a list of all Plan Master Details Maternity SubLimit By Policy No
        /// </summary>
        /// <param name="policy_no">Policy No</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Plan Master Details Maternity SubLimit By Policy No </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsMaternitySubLimitByPolicyNo)]
        public async Task<IActionResult> PlanMasterDetailsMaternitySubLimitByPolicyNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int policy_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var planMasterDtlsMatSubLmt = await _service.Toshfa.FetchAllHmoPlanMasterDetailsMaternitySubLimitByPolicyNo(objModel, policy_no);
            return StatusCode(StatusCodes.Status200OK, planMasterDtlsMatSubLmt);

        }





        /// <summary>
        /// This enpoint returns a list of all Plan Master Details Maternity SubLimit By Code
        /// </summary>
        /// <param name="code">code</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Plan Master Details Maternity SubLimit By Code </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsMaternitySubLimitByCode)]
        public async Task<IActionResult> PlanMasterDetailsMaternitySubLimitByCode([FromQuery] int PageNumber, int PageSize, [FromRoute] string code)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };


            var planMasterDtlsMatSubLmt = await _service.Toshfa.FetchAllHmoPlanMasterDetailsMaternitySubLimitByCode(objModel, code);
            return StatusCode(StatusCodes.Status200OK, planMasterDtlsMatSubLmt);

        }

        /// <summary>
        /// This enpoint returns List Member Details with ToshfaUID By Member No
        /// </summary>
        /// <param name="member_no">Member No</param>
        ///  <param name="model">Paging Parameter Model  </param>
        /// <returns>Member Details with ToshfaUID </returns>
        [HttpGet(ApiRoutes.Setup.MemberDetailWithToshfaUidByMemberNo)]
        public async Task<IActionResult> AllMemberDetailsWithToshfaUIDByMemberNo([FromRoute] int member_no, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
              await _service.Toshfa.FetchMemberDetailswithToshfaUIDByMemberNo(member_no, model));
        }

        /// <summary>
        /// This enpoint returns List Member Details with ToshfaUID By Toshfauid
        /// </summary>
        /// <param name="toshfa_uid">Toshfa UID, Replace every '/' with '-'</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns> List Member Details with ToshfaUID </returns>
        [HttpGet(ApiRoutes.Setup.MemberDetailWithToshfaUidBytoshfauid)]
        public async Task<IActionResult> AllMemberDetailsWithToshfaUIDByUID([FromRoute] string toshfa_uid, [FromQuery] PagingParam model)
        {
            toshfa_uid = string.IsNullOrEmpty(toshfa_uid) ? "" : toshfa_uid.Replace("-", "/");
            return StatusCode(StatusCodes.Status200OK,
              await _service.Toshfa.FetchMemberDetailswithByToshfaUID(toshfa_uid, model));
        }


        /// <summary>
        /// This enpoint returns List of  Supply Prices
        /// </summary>
        /// <returns>List of  Supply Prices</returns>
        [HttpGet(ApiRoutes.Setup.AllSupplyPrices)]
        public async Task<IActionResult> AllSupplyPrices([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllSupplyPrices(model));
        }


        /// <summary>
        /// This enpoint returns List of Supply Prices By Provider No
        /// </summary>
        /// <param name="provider_no">Provider No</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>List of Supply Prices </returns>
        [HttpGet(ApiRoutes.Setup.AllSupplyPricesByProviderNo)]
        public async Task<IActionResult> SupplyPriceByProviderNo([FromRoute] int provider_no, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
               await _service.Toshfa.FetchAllSupplyPriceByProviderNo(provider_no, model));
        }


        /// <summary>
        /// This enpoint returns List of  Member Policies
        /// </summary>
        /// <returns>List of  Member Policies</returns>
        [HttpGet(ApiRoutes.Setup.AllMemberPolicies)]
        public async Task<IActionResult> AllMemberPolicies([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllMemberPolicies(model));
        }


        /// <summary>
        /// This enpoint returns  List of Member Policies By policy No
        /// </summary>
        /// <param name="policy_no">policy No</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>List of Member Policies </returns>
        [HttpGet(ApiRoutes.Setup.AllMemberPoliciesBypolicyno)]
        public async Task<IActionResult> AllMemberPoliciesByPolicyNo([FromRoute] int policy_no, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
              await _service.Toshfa.FetchMemberPoliciesByPolicyNo(policy_no, model));


        }



        /// <summary>
        /// This enpoint returns a list of all Plan Master Details Optical SubLimit
        /// </summary>
        /// <returns>List of HMO Plan Master Details Optical SubLimit </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsOpticalSubLimit)]
        public async Task<IActionResult> PlanMasterDetailsOpticalSubLimit([FromQuery] PagingParam objModel)
        {

            var planMasterDtlsOpticalSubLmt = await _service.Toshfa.FetchAllHmoPlanMasterDetailsOpticalSubLimit(objModel);
            return StatusCode(StatusCodes.Status200OK, planMasterDtlsOpticalSubLmt);

        }




        /// <summary>
        /// This enpoint returns a list of all Plan Master Details Optical SubLimit By Policy no
        /// </summary>
        /// <param name="policy_no">Policy No</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Plan Master Details Optical SubLimit By Policy No </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsOpticalSubLimitByPolicyNo)]
        public async Task<IActionResult> PlanMasterDetailsOpticalSubLimitByPolicyNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int policy_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var planMasterDtlsOpticalSubLmt = await _service.Toshfa.FetchAllHmoPlanMasterDetailsOpticalSubLimitByPolicyNo(objModel, policy_no);
            return StatusCode(StatusCodes.Status200OK, planMasterDtlsOpticalSubLmt);

        }





        /// <summary>
        /// This enpoint returns a list of all Plan Master Details Optical SubLimit By Policy no
        /// </summary>
        /// <param name="code">Code</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Plan Master Details Optical SubLimit By Code </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoPlanMasterDetailsOpticalSubLimitByCode)]
        public async Task<IActionResult> PlanMasterDetailsOpticalSubLimitByCode([FromQuery] int PageNumber, int PageSize, [FromRoute] string code)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };

            var planMasterDtlsOpticalSubLmt = await _service.Toshfa.FetchAllHmoPlanMasterDetailsOpticalSubLimitByCode(objModel, code);
            return StatusCode(StatusCodes.Status200OK, planMasterDtlsOpticalSubLmt);

        }






        /// <summary>
        /// This enpoint returns a list of all Total Claims Per Health Plan
        /// </summary>
        /// <returns>List of HMO Total Claims Per Health Plan </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoTotalClaimsPerHealthPlan)]
        public async Task<IActionResult> TotalClaimsPerHealthPlan([FromQuery] PagingParam objModel)
        {

            var totlClaimsPerHealthPlan = await _service.Toshfa.FetchAllHmoTotalClaimsPerHealthPlan(objModel);
            return StatusCode(StatusCodes.Status200OK, totlClaimsPerHealthPlan);
        }




        /// <summary>
        /// This enpoint returns a list of all Total Health Premium By Agent
        /// </summary>
        /// <returns>List of HMO Total Health Premium By Agent </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoTotalHealthPremiumByAgentPlan)]
        public async Task<IActionResult> TotalHealthPremiumByAgent([FromQuery] PagingParam objModel)
        {

            var totlHealthPremiumByAgent = await _service.Toshfa.FetchAllHmoTotalHealthPremiumByAgent(objModel);
            return StatusCode(StatusCodes.Status200OK, totlHealthPremiumByAgent);

        }




        /// <summary>
        /// This enpoint returns a list of all Total Health Premium By Agent By Policy No
        /// </summary>
        /// /// <param name="policy_no">Policy Number</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Total Health Premium By Agent By Policy No </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoTotalHealthPremiumByAgentPlanByPolicyNo)]
        public async Task<IActionResult> TotalHealthPremiumByAgentByPolicyNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int policy_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };


            var totlHealthPremiumByAgent = await _service.Toshfa.FetchAllHmoTotalHealthPremiumByAgentByPolicyNo(objModel, policy_no);
            return StatusCode(StatusCodes.Status200OK, totlHealthPremiumByAgent);

        }




        /// <summary>
        /// This enpoint returns a list of all Total Health Premium By Agent By Member No
        /// </summary>
        /// /// <param name="member_no">Member Number</param>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>List of HMO Total Health Premium By Agent By Member No </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoTotalHealthPremiumByAgentPlanByMemberNo)]
        public async Task<IActionResult> TotalHealthPremiumByAgentByMemberNo([FromQuery] int PageNumber, int PageSize, [FromRoute] int member_no)
        {
            var objModel = new PagingParam
            {
                PageNumber = PageNumber,
                PageSize = PageSize
            };


            var totlHealthPremiumByAgent = await _service.Toshfa.FetchAllHmoTotalHealthPremiumByAgentByMemberNo(objModel, member_no);
            return StatusCode(StatusCodes.Status200OK, totlHealthPremiumByAgent);

        }





        /// <summary>
        /// This enpoint returns a list of all Total Premium
        /// </summary>
        /// <returns>List of HMO Total Premium </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoTotalPremium)]
        public async Task<IActionResult> TotalPremium([FromQuery] PagingParam objModel)
        {

            var totlPremium = await _service.Toshfa.FetchAllHmoTotalPremium(objModel);
            return StatusCode(StatusCodes.Status200OK, totlPremium);

        }




        /// <summary>
        /// This enpoint returns a list of all Total Premium Per Health Plan
        /// </summary>
        /// <returns>List of HMO Total Premium Per Health Plan </returns>
        [HttpGet(ApiRoutes.Setup.AllHmoTotalPremiumPerHealthPlan)]
        public async Task<IActionResult> TotalPremiumPerHealthPlan([FromQuery] PagingParam objModel)
        {
            var totlPremiumPerHP = await _service.Toshfa.FetchAllHmoTotalPremiumPerHealthPlan(objModel);
            return StatusCode(StatusCodes.Status200OK, totlPremiumPerHP);
        }

        /// <summary>
        /// This enpoint returns List of Toshfa Unique Numbers
        /// </summary>
        /// <returns>List of  Toshfa Unique Numbers</returns>
        [HttpGet(ApiRoutes.Setup.ToshfaUniquesno)]
        public async Task<IActionResult> AllToshfaUniqueNo([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllToshfaUniqueNo(model));
        }


        /// <summary>
        /// This enpoint returns List of Toshfa Unique Numbers By member No
        /// </summary>
        /// <param name="member_no">member No</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>Toshfa Unique Numbers </returns>
        [HttpGet(ApiRoutes.Setup.ToshfaUniquesnoByMemberno)]
        public async Task<IActionResult> AllToshfaUniqueNoByMemberNo([FromRoute] int member_no, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
             await _service.Toshfa.FetchToshfaUniqueNoByMemberNo(member_no, model));
        }

        /// <summary>
        /// This enpoint returns  Toshfa Unique Numbers By unique_id
        /// </summary>
        /// <param name="unique_id">Toshfa Unique Id</param>
        /// <param name="model">Paging Parameter Model  </param>
        /// <returns>Toshfa Unique Numbers </returns>
        [HttpGet(ApiRoutes.Setup.ToshfaUniquesnoById)]
        public async Task<IActionResult> AllToshfaUniqueNoByUniqueId([FromRoute] string unique_id, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
            await _service.Toshfa.FetchToshfaUniqueNoByUniqueId(unique_id, model));
        }


        /// <summary>
        /// This enpoint returns List of Total Premium Per Client And Retail
        /// </summary>
        /// <returns>List of  Total Premium Per Client And Retail</returns>
        [HttpGet(ApiRoutes.Setup.ClientRetailTotalPremiums)]
        public async Task<IActionResult> AllTotalPremiumPerClientAndRetail([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllTotalPremiumPerClientAndRetail(model));
        }

        /// <summary>
        /// This enpoint returns  Total Premium Per Client And RetailBy member No
        /// </summary>
        /// <param name="member_no">member No</param>
        ///  <param name="model">Paging Parameter Model  </param>
        /// <returns>Total Premium Per Client And Retail </returns>
        [HttpGet(ApiRoutes.Setup.ClientRetailTotalPremiumsByMemberno)]
        public async Task<IActionResult> TotalPremiumPerClientAndRetailByMemberNo([FromRoute] int member_no, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
               await _service.Toshfa.FetchTotalPremiumPerClientAndRetailByMemberNo(member_no, model));
        }
        /// <summary>
        /// This enpoint returns   Total Premium Per Client And RetailBy policy No
        /// </summary>
        /// <param name="policy_no">policy No</param>
        ///  <param name="model">Paging Parameter Model  </param>
        /// <returns> Total Premium Per Client And Retail </returns>
        [HttpGet(ApiRoutes.Setup.ClientRetailTotalPremiumsByPolicyNo)]
        public async Task<IActionResult> TotalPremiumPerClientAndRetailByPolicyNo([FromRoute] int policy_no, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
              await _service.Toshfa.FetchTotalPremiumPerClientAndRetailByPolicyNo(policy_no, model));

        }



        /// <summary>
        /// This enpoint returns List of CCA
        /// </summary>
        /// <returns>List of  CCA</returns>
        [HttpGet(ApiRoutes.Setup.AllCCA)]
        public async Task<IActionResult> AllCCA([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchAllCCA(model));
        }

        /// <summary>
        /// This enpoint returns  CCA By member No
        /// </summary>
        /// <param name="member_no">member No</param>
        ///  <param name="model">Paging Parameter Model  </param>
        /// <returns>CCA </returns>
        [HttpGet(ApiRoutes.Setup.CCAByMemberno)]
        public async Task<IActionResult> AllCCAByMemberNo([FromRoute] int member_no, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
               await _service.Toshfa.FetchCCAByMemberNo(member_no, model));

        }
        /// <summary>
        /// This enpoint returns   CCA By policy No
        /// </summary>
        /// <param name="policy_no">policy No</param>
        ///  <param name="model">Paging Parameter Model  </param>
        /// <returns> CCA </returns>
        [HttpGet(ApiRoutes.Setup.CCAByPolicyNo)]
        public async Task<IActionResult> AllCCAByPolicyNo([FromRoute] int policy_no, [FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
               await _service.Toshfa.FetchCCAByPolicyNo(policy_no, model));
        }

        /// <summary>
        /// This enpoint returns List of Supply Lists
        /// </summary>
        /// <returns>Supply Lists</returns>
        [HttpGet(ApiRoutes.Setup.AllSupplyLists)]
        public async Task<IActionResult> AllSupplyLists([FromQuery] PagingParam model)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _service.Toshfa.FetchSupplyLists(model));
        }

    }
}
