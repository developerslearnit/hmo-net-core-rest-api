using AvonHMO.API.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Linq;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Authentication;
using AvonHMO.API.Filters;
using AvonHMO.Application.ViewModels.Toshfa;
using AvonHMO.Domain.Interfaces;

namespace AvonHMO.API.Areas.Setup.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiversion}")]
    [ApiController]
    [APIKeyAuth]
    public class ConstantsController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IRepositoryManager _service;
        public ConstantsController(IHttpClientFactory httpClientFactory, IRepositoryManager service)
        {
            _httpClientFactory = httpClientFactory;
            _service = service;
        }


        /// <summary>
        /// Returns list of countries
        /// </summary>
        /// <returns>Returns list of countries</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<LookUpViewModel>>), StatusCodes.Status200OK)]
        [HttpGet(ApiRoutes.Setup.Countries)]
        public async Task<IActionResult> Countries()
        {

            var _client = _httpClientFactory.CreateClient("toshfaClient");

            var request = new HttpRequestMessage(HttpMethod.Get, "providers/getcountry");

            var response = await _client.SendAsync(request);

            List<CountryViewModel> countries = null;
            List<LookUpViewModel> lookUp = new();

            if (response.IsSuccessStatusCode)
            {
                countries = await response.Content.ReadFromJsonAsync<List<CountryViewModel>>();
            }



            if (countries.Any())
            {

                foreach (var item in countries)
                {



                    var countryId = item.CountryName.Split('-')[1].Trim();
                    var countryName = item.CountryName.Split('-')[0].Trim();
                    lookUp.Add(new LookUpViewModel
                    {

                        code = countryId,
                        name = countryName,

                    });
                }
            }

            return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<List<LookUpViewModel>>
                   { Data = lookUp, hasError = false, });



        }


        /// <summary>
        /// Returns List of state by accepting country code
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<LookUpViewModel>>), StatusCodes.Status200OK)]

        [HttpGet(ApiRoutes.Setup.StateByCountry)]
        public async Task<IActionResult> FetchStates([FromRoute] string countryCode)
        {
            var _client = _httpClientFactory.CreateClient("toshfaClient");

            var request = new HttpRequestMessage(HttpMethod.Get, $"providers/getstate/{countryCode}");

            var response = await _client.SendAsync(request);

            List<StateViewModel> states = null;
            List<LookUpViewModel> lookUp = new();

            if (response.IsSuccessStatusCode)
            {
                states = await response.Content.ReadFromJsonAsync<List<StateViewModel>>();
            }


            if (states.Any())
            {

                foreach (var item in states)
                {

                    if (!string.IsNullOrWhiteSpace(item.StateName))
                    {
                        var stateId = item.StateName.Split('-')[1].Trim();
                        var stateName = item.StateName.Split('-')[0].Trim();
                        lookUp.Add(new LookUpViewModel
                        {

                            code = stateId,
                            name = stateName,

                        });
                    }


                }
            }

            return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<List<LookUpViewModel>>
                   { Data = lookUp, hasError = false, });
        }


        /// <summary>
        /// Returns list of local government by state code
        /// </summary>
        /// <param name="stateCode"></param>
        /// <returns></returns>

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<LookUpViewModel>>), StatusCodes.Status200OK)]

        [HttpGet(ApiRoutes.Setup.LocalGovtByState)]
        public async Task<IActionResult> FetchLocalGovts([FromRoute] string stateCode)
        {
            var _client = _httpClientFactory.CreateClient("toshfaClient");

            var request = new HttpRequestMessage(HttpMethod.Get, $"providers/GetLocalGovts/{stateCode}");

            var response = await _client.SendAsync(request);

            List<LocalGovtViewModel> states = null;
            List<LookUpViewModel> lookUp = new();

            if (response.IsSuccessStatusCode)
            {
                states = await response.Content.ReadFromJsonAsync<List<LocalGovtViewModel>>();
            }


            if (states.Any())
            {

                foreach (var item in states)
                {

                    if (!string.IsNullOrWhiteSpace(item.LocalGovtArea))
                    {
                        var stateId = item.LocalGovtArea.Split('-')[1].Trim();
                        var stateName = item.LocalGovtArea.Split('-')[0].Trim();
                        lookUp.Add(new LookUpViewModel
                        {

                            code = stateId,
                            name = stateName,

                        });
                    }


                }
            }

            return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<List<LookUpViewModel>>
                   { Data = lookUp, hasError = false, });
        }



        /// <summary>
        /// Returns list of cities by state code
        /// </summary>
        /// <param name="stateCode"></param>
        /// <returns></returns>

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<LookUpViewModel>>), StatusCodes.Status200OK)]

        [HttpGet(ApiRoutes.Setup.CityByState)]
        public async Task<IActionResult> FetchCities([FromRoute] string stateCode)
        {
            var _client = _httpClientFactory.CreateClient("toshfaClient");

            var request = new HttpRequestMessage(HttpMethod.Get, $"providers/GetCity/{stateCode}");

            var response = await _client.SendAsync(request);

            List<CityViewModel> states = null;
            List<LookUpViewModel> lookUp = new();

            if (response.IsSuccessStatusCode)
            {
                states = await response.Content.ReadFromJsonAsync<List<CityViewModel>>();
            }


            if (states.Any())
            {

                foreach (var item in states)
                {

                    if (!string.IsNullOrWhiteSpace(item.CityName))
                    {
                        var stateId = item.CityName.Split('-')[1].Trim();
                        var stateName = item.CityName.Split('-')[0].Trim();
                        lookUp.Add(new LookUpViewModel
                        {

                            code = stateId,
                            name = stateName,

                        });
                    }


                }
            }

            return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<List<LookUpViewModel>>
                   { Data = lookUp, hasError = false, });
        }



        /// <summary>
        /// Returns list of currencies
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse<List<CurrencyViewModel>>), StatusCodes.Status200OK)]

        [HttpGet(ApiRoutes.Setup.Currencies)]
        public async Task<IActionResult> FetchCurrencies()
        {

            var currencies = await _service.Toshfa.FecthCurrencies();


            return StatusCode(StatusCodes.Status200OK,
                   new ApiResponse<List<CurrencyViewModel>>
                   { Data = currencies, hasError = false, });

        }

    }





    public class CountryViewModel
    {
        public string CountryName { get; set; }
    }

    public class StateViewModel
    {
        public string StateName { get; set; }
    }

    public class LocalGovtViewModel
    {
        public string LocalGovtArea { get; set; }
    }

    public class CityViewModel
    {
        public string CityName { get; set; }
    }

    
    public class LookUpViewModel
    {
        public string code { get; set; }

        public string name { get; set; }
    }


    
}
