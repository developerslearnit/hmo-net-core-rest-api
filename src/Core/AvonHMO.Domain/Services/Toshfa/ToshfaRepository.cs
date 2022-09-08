using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Toshfa;
using AvonHMO.Domain.Interfaces.Toshfa;
using AvonHMO.Entities;
using AvonHMO.Domain.Extensions;
using AvonHMO.Persistence.StorageContexts.Toshfa;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Drawing.Printing;
using System.Xml;

namespace AvonHMO.Domain.Services.Toshfa
{

    public class ProviderClassesMap
    {
        public int classCode { get; set; }

        public string className { get; set; }
    }


    public class ToshfaRepository : IToshfaRepository
    {
        private readonly ToshfaDbContext _context;
        private readonly IDbConnection _connection;
        public ToshfaRepository(ToshfaDbContext context, IDbConnection connection)
        {
            _context = context;
            _connection = connection;
        }

        /// <summary>
        ///  Provider List filter by category, name, address, service type
        /// </summary>
        /// <returns>Filter Provider List</returns>
        /// <remarks>
        /// Author :: Toba
        /// </remarks>

        public async Task<PagedResponse<HmoProvidersViewModel>> FetchProviderFilterByCategoryAndSearchKey(ProviderSearchFilterParam param)
        {
            string filterQuery = string.Empty;

            if (param.PageNumber <= 0) param.PageNumber = 1;

            if (param.PageSize <= 0) param.PageSize = 10;

            var filterStr = new List<string>();
            if (!string.IsNullOrWhiteSpace(param.searchKey))
                filterStr.Add($" (Name like '%{param.searchKey}%' or ShortName like '%{param.searchKey}%' or Address like '%{param.searchKey}%' or City like '%{param.searchKey}%' or ProviderServiceType like '%{param.searchKey}%' )");

            if (!string.IsNullOrWhiteSpace(param.category))
                filterStr.Add($" ProviderCategory like '%{param.category}%'");

            if (filterStr.Count > 0)
                filterQuery = $" Where {string.Join(" and ", filterStr)}";

            var cmdText = $"SELECT count( * ) FROM VW_ProviderList {filterQuery}; SELECT * FROM VW_ProviderList {filterQuery} ORDER BY Code OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<HmoProvidersViewModel>();

            List<HmoProvidersViewModel> result = new List<HmoProvidersViewModel>();

            if (pageResult.Any())
            {
                result = pageResult.ToList();
            }

            return new PagedResponse<HmoProvidersViewModel>
            {
                Data = result.DistinctBy(x => x.Code),
                hasError = false,
                Totalrecords = totalrecord,
                Message = string.Empty,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200
            };
        }

        /// <summary>
        ///  Provider Categories
        /// </summary>
        /// <returns> Provider Categories</returns>
        /// <remarks>
        /// Author :: Toba
        /// </remarks>

        public async Task<PagedResponse<string>> FetchProviderCategory(PagingParam param)
        {

            var cmdText = "SELECT count( distinct([ProviderCategory]) ) FROM VW_ProviderList;SELECT distinct([ProviderCategory]) FROM VW_ProviderList ORDER BY ProviderCategory OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<string>();

            return new PagedResponse<string>
            {
                Data = pageResult,
                hasError = false,
                Totalrecords = totalrecord,
                Message = string.Empty,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200
            };
        }

        /// <summary>
        /// Returns all HMO Providers
        /// </summary>
        /// <returns>HMO Providers</returns>
        /// <remarks>
        /// Author :: Adesina Mark
        /// Created :: Mark Adesina 26-10-2021 9:00PM
        /// Updated :: Mark Adesina 27-10-2021 1:00PM
        /// </remarks>

        public async Task<PagedResponse<HmoProvidersViewModel>> FetchAllProviders(PagingParam param)
        {

            var cmdText = "SELECT COUNT(*) FROM VW_ProviderList;SELECT * FROM VW_ProviderList ORDER BY Code OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoProvidersViewModel>();

            return new PagedResponse<HmoProvidersViewModel>
            {
                Data = pageResult.DistinctBy(x => x.Code),
                hasError = false,
                Totalrecords = totalrecord,
                Message = string.Empty,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200
            };
            //(pageResult.ToList(), param.PageNumber, param.PageSize, totalrecord);
        }

        /// <summary>
        /// Returns  HMO Provider by Provider Code Singlr
        /// </summary>
        /// <returns>HMO Providers</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 13-12-2021 9:00PM
        /// Updated :: Akintunde Toba 13-12-2021 1:00PM
        /// </remarks>

        public async Task<HmoProvidersViewModel> FetchProviderByProviderCode(int code)
        {
            var cmdText = $"SELECT top 1 * FROM VW_ProviderList Where Code='{code}'";
            var query = await _connection.QueryMultipleAsync(cmdText);
            var pageResult = query.Read<HmoProvidersViewModel>().FirstOrDefault();
            return pageResult;
        }


        /// <summary>
        /// Returns  HMO Provider by Provider Code
        /// </summary>
        /// <returns>HMO Providers</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 13-12-2021 9:00PM
        /// Updated :: Akintunde Toba 13-12-2021 1:00PM
        /// </remarks>

        public async Task<PagedResponse<HmoProvidersViewModel>> FetchProviderByProviderCode(PagingParam param, string code)
        {

            var cmdText = $"SELECT COUNT(*) FROM VW_ProviderList Where Code='{code}';SELECT * FROM VW_ProviderList Where Code='{code}' ORDER BY Code OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoProvidersViewModel>();

            return new PagedResponse<HmoProvidersViewModel>
            {
                Data = pageResult.DistinctBy(x => x.Code),
                hasError = false,
                Totalrecords = totalrecord,
                Message = string.Empty,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200
            };
            //(pageResult.ToList(), param.PageNumber, param.PageSize, totalrecord);
        }





        private List<ProviderClassesMap> FetchProviderMaps()
        {
            return new List<ProviderClassesMap>
            {
                new ProviderClassesMap{ classCode =1, className="INTERNATIONAL"},
                new ProviderClassesMap{ classCode =2, className="PRESTIGE"},
                new ProviderClassesMap{ classCode =3, className="PREMIUM"},
                new ProviderClassesMap{ classCode =4, className="PLUS"},
                new ProviderClassesMap{ classCode =5, className="NHIS"},
                new ProviderClassesMap{ classCode =6, className="BASIC"}
            };
        }



        /// <summary>
        /// Returns  HMO Provider by filter parameters
        /// </summary>
        /// <returns>HMO Providers</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 13-12-2021 9:00PM
        /// Updated :: Mark Adesina 31-03-2022 1:00PM
        /// </remarks>

        public async Task<PagedResponse<HmoProvidersViewModel>> FetchProviderByFilter(ProviderFilterParam param)
        {

            //var connection = _context.Database.GetDbConnection();



            string filterQuery = string.Empty;
            var filterStr = new List<string>();

            filterStr.Add(" Name NOT LIKE '%Inactive%'");

            filterStr.Add(" ProviderCategory <> 'NHIS'");

            if (!string.IsNullOrWhiteSpace(param.searchKey))
            {

                filterStr.Add($" (Name LIKE '%{param.searchKey}%' or ShortName LIKE '%{param.searchKey}%' or Address LIKE '%{param.searchKey}%' or City LIKE '%{param.searchKey}%' or ProviderServiceType LIKE '%{param.searchKey}%' )");

            }
            else if (string.IsNullOrWhiteSpace(param.searchKey))
            {

                if (!string.IsNullOrWhiteSpace(param.City))
                    filterStr.Add($" State = '{param.City}'");


                if (!string.IsNullOrWhiteSpace(param.planClass))
                {

                    var providerCatCode = FetchProviderMaps()
                        .Where(x => x.className == param.planClass).Select(x => x.classCode).FirstOrDefault();

                    var providerCats = FetchProviderMaps()
                        .Where(x => x.classCode >= providerCatCode && x.className != "NHIS").Select(x => x.className).ToList();


                    var sb = new StringBuilder();
                    providerCats.ForEach(x => sb.Append($"'{x}',"));


                    filterStr.Add($" ProviderClass IN ({sb.ToString().TrimEnd(',')})");
                }

                if (!string.IsNullOrWhiteSpace(param.ServiceType))

                    filterStr.Add($" ProviderServiceType LIKE '%{param.ServiceType}%'");


            }





            if (filterStr.Count > 0)
                filterQuery = $" WHERE {string.Join(" AND ", filterStr)}";

            var cmdText = $"SELECT COUNT(*) FROM VW_ProviderList {filterQuery};SELECT * FROM VW_ProviderList {filterQuery} ORDER BY Code OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoProvidersViewModel>();

            pageResult = pageResult.Distinct().ToList(); ;




            return new PagedResponse<HmoProvidersViewModel>
            {
                Data = pageResult.DistinctBy(x => x.Code).OrderBy(x => x.Name),
                hasError = false,
                Totalrecords = totalrecord,
                Message = string.Empty,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200
            };
        }



        /// <summary>
        /// Returns all HMO Member Approval Details
        /// </summary>
        /// <returns>HMO Member Approval Details</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 03-11-2021 09:55AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberApprovalDetailsViewModel>> FetchAllMemberApprovalDetails(PagingParam param)
        {


            var cmdText = "SELECT COUNT(*) FROM vw_MemberApprovalDetails;SELECT * FROM vw_MemberApprovalDetails ORDER BY RequestNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";


            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMemberApprovalDetailsViewModel>();

            return new PagedResponse<HmoMemberApprovalDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "Select RequestNo,AvonPaCode,RequestType,Name,MemberNo,Client,Hospital,approvalType," +
            //               "Receiveddate, ReceivedTime, DecisionDate, ApprovalStatus, BasicDiagnosis, OpdIpd, TotalAmount," +
            //               "NegotiatedAmt, SBU, CaseManager, Speciality, ProviderManager, ApproveRejectCloseNotes," +
            //               "TAT, servicetype, ProviderManagerRemarks, ServiceDescription, Amount, Diagnosis, DecisionBy, FName," +
            //               "Notes, DecmodifiedAmount, ServiceNotFoundAmount, ApprovedAmt, RefHospName," +
            //               "ServiceNotFoundDescription, Policyno, fromdate" +
            //              " FROM dbo.vw_MemberApprovalDetails";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberApprovalDetailsViewModel>();
            #endregion
        }



        /// <summary>
        /// Returns all HMO Member Approval Details By Request No
        /// </summary>
        /// <returns>HMO Member Approval Details By Request No</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 07-11-2021 3:00PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberApprovalDetailsViewModel>> FetchAllMemberApprovalDetailsByRequestNo(PagingParam param, int request_no)
        {

            var cmdText = $"SELECT COUNT(*) FROM vw_MemberApprovalDetails where RequestNo = {request_no};SELECT * FROM vw_MemberApprovalDetails" +
                          $" where RequestNo = {request_no} ORDER BY RequestNo OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMemberApprovalDetailsViewModel>();

            return new PagedResponse<HmoMemberApprovalDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "Select RequestNo,AvonPaCode,RequestType,Name,MemberNo,Client,Hospital,approvalType," +
            //               "Receiveddate, ReceivedTime, DecisionDate, ApprovalStatus, BasicDiagnosis, OpdIpd, TotalAmount," +
            //               "NegotiatedAmt, SBU, CaseManager, Speciality, ProviderManager, ApproveRejectCloseNotes," +
            //               "TAT, servicetype, ProviderManagerRemarks, ServiceDescription, Amount, Diagnosis, DecisionBy, FName," +
            //               "Notes, DecmodifiedAmount, ServiceNotFoundAmount, ApprovedAmt, RefHospName," +
            //               "ServiceNotFoundDescription, Policyno, fromdate" +
            //              " FROM dbo.vw_MemberApprovalDetails" +
            //              $" where RequestNo = {request_no}";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberApprovalDetailsViewModel>();
            #endregion
        }




        /// <summary>
        /// Returns all HMO Member Approval Details Member No
        /// </summary>
        /// <returns>HMO Member Approval Details By Member No</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 07-11-2021 4:38PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberApprovalDetailsViewModel>> FetchAllMemberApprovalDetailsByMemberNo(PagingParam param, int member_no)
        {

            var cmdText = $"SELECT COUNT(*) FROM vw_MemberApprovalDetails where MemberNo = {member_no};SELECT * FROM vw_MemberApprovalDetails" +
                          $" where MemberNo = {member_no} ORDER BY RequestNo OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMemberApprovalDetailsViewModel>();

            return new PagedResponse<HmoMemberApprovalDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "Select RequestNo,AvonPaCode,RequestType,Name,MemberNo,Client,Hospital,approvalType," +
            //               "Receiveddate, ReceivedTime, DecisionDate, ApprovalStatus, BasicDiagnosis, OpdIpd, TotalAmount," +
            //               "NegotiatedAmt, SBU, CaseManager, Speciality, ProviderManager, ApproveRejectCloseNotes," +
            //               "TAT, servicetype, ProviderManagerRemarks, ServiceDescription, Amount, Diagnosis, DecisionBy, FName," +
            //               "Notes, DecmodifiedAmount, ServiceNotFoundAmount, ApprovedAmt, RefHospName," +
            //               "ServiceNotFoundDescription, Policyno, fromdate" +
            //              " FROM dbo.vw_MemberApprovalDetails" +
            //              $" where RequestNo = {request_no}";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberApprovalDetailsViewModel>();
            #endregion
        }



        /// <summary>
        /// Returns all HMO Member Approval Details By Avon Pa Code
        /// </summary>
        /// <returns>HMO Member Approval Details By Avon Pa Code</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 07-11-2021 3:59PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberApprovalDetailsViewModel>> FetchAllMemberApprovalDetailsByAvonPaCode(PagingParam param, string avon_pa_code)
        {

            var cmdText = $"SELECT COUNT(*) FROM vw_MemberApprovalDetails where AvonPaCode = '{avon_pa_code}'; SELECT * FROM vw_MemberApprovalDetails" +
                          $" where AvonPaCode = '{avon_pa_code}' ORDER BY RequestNo OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMemberApprovalDetailsViewModel>();

            return new PagedResponse<HmoMemberApprovalDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "Select RequestNo,AvonPaCode,RequestType,Name,MemberNo,Client,Hospital,approvalType," +
            //               "Receiveddate, ReceivedTime, DecisionDate, ApprovalStatus, BasicDiagnosis, OpdIpd, TotalAmount," +
            //               "NegotiatedAmt, SBU, CaseManager, Speciality, ProviderManager, ApproveRejectCloseNotes," +
            //               "TAT, servicetype, ProviderManagerRemarks, ServiceDescription, Amount, Diagnosis, DecisionBy, FName," +
            //               "Notes, DecmodifiedAmount, ServiceNotFoundAmount, ApprovedAmt, RefHospName," +
            //               "ServiceNotFoundDescription, Policyno, fromdate" +
            //              " FROM dbo.vw_MemberApprovalDetails" +
            //              $" where RequestNo = {request_no}";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberApprovalDetailsViewModel>();
            #endregion
        }


        /// <summary>
        /// Returns all HMO Member Approved Providers
        /// </summary>
        /// <returns>HMO Member Approved  Providers</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 03-11-2021 11:23AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<MemberApprovedProvidersViewModel>> FetchAllMemberApprovedProviders(PagingParam param)
        {
            var cmdText = "SELECT COUNT(*) FROM vw_MemberApprovedProviders;SELECT * FROM vw_MemberApprovedProviders ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<MemberApprovedProvidersViewModel>();

            return new PagedResponse<MemberApprovedProvidersViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "Select PolicyNo,FromDate,ClassCode,HospNo,Name,ContNo,IPDAllowed,OPDAllowed,MaternityAllowed," +
            //             "DentalAllowed,OpticalAllowed,AvgClaim,Avg_Amount,Capitation" +
            //             " FROM dbo.vw_MemberApprovedProviders";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<MemberApprovedProvidersViewModel>();
            #endregion
        }


        /// <summary>
        /// Returns all HMO Member Approved Providers
        /// </summary>
        /// <returns>HMO Member Approved  Providers</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 07-11-2021 4:57PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<MemberApprovedProvidersViewModel>> FetchAllMemberApprovedProvidersByHospitalNo(PagingParam param, int hospital_no)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_MemberApprovedProviders where HospNo = {hospital_no} ;" +
                          $"SELECT * FROM vw_MemberApprovedProviders where HospNo = {hospital_no} ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<MemberApprovedProvidersViewModel>();

            return new PagedResponse<MemberApprovedProvidersViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "Select PolicyNo,FromDate,ClassCode,HospNo,Name,ContNo,IPDAllowed,OPDAllowed,MaternityAllowed," +
            //             "DentalAllowed,OpticalAllowed,AvgClaim,Avg_Amount,Capitation" +
            //             " FROM dbo.vw_MemberApprovedProviders";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<MemberApprovedProvidersViewModel>();
            #endregion

            //return new PagedResponse<HmoProvidersViewModel>(pageResult.ToList(), param.PageNumber,param.PageSize, totalrecord);
        }


        /// <summary>
        /// Returns all Benefit Names
        /// </summary>
        /// <returns>Benefit Names</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 10:00PM
        /// </remarks>

        public async Task<PagedResponse<BenefitNameViewModel>> FetchAllBenefitNames(PagingParam param)
        {
            var cmdText = "SELECT COUNT(*) FROM VM_BenefitNames;SELECT * FROM VM_BenefitNames ORDER BY BenefitNameCode OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<BenefitNameViewModel>();
            return new PagedResponse<BenefitNameViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Returns a Benefit Name
        /// </summary>
        /// <returns>Benefit Name</returns>
        ///<param name="code">Benefit code</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 10:00PM
        /// </remarks>

        public async Task<List<BenefitNameViewModel>> FetchSingleBenefitNameByCode(string code)
        {
            var sqlQuery = $"SELECT Benefitnames,BenefitNameCode FROM VM_BenefitNames where BenefitNameCode='{code}'";

            var spContext = _context.LoadSqlQuery(sqlQuery);

            return await spContext.ExecuteStoreProcedure<BenefitNameViewModel>();
        }

        /// <summary>
        /// Returns all Agent/Broker infomation
        /// </summary>
        /// <returns>Agent/Broker infomation</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 10:00PM
        /// </remarks>
        public async Task<PagedResponse<AgentOrBrokerInfomationViewModel>> FetchAllAgentOrBrokerInfo(PagingParam param)
        {
            var cmdText = "SELECT COUNT(STKH_CODE) [dbo].[vw_AgentOrBrokerInformation;SELECT * FROM [dbo].[vw_AgentOrBrokerInformation ORDER BY STKH_CODE OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<AgentOrBrokerInfomationViewModel>();
            return new PagedResponse<AgentOrBrokerInfomationViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Returns an Agent/Broker infomation
        /// </summary>
        /// <returns>Agent/Broker infomation</returns>
        ///<param name="code">'STKH_CODE', code: agent/broker infomation unique code</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 10:00PM
        /// </remarks>
        public async Task<List<AgentOrBrokerInfomationViewModel>> FetchAgentOrBrokerInfoByCode(string code)
        {
            var sqlQuery = $"SELECT * FROM [dbo].[vw_AgentOrBrokerInformation] where STKH_CODE='{code}'";

            var spContext = _context.LoadSqlQuery(sqlQuery);

            return await spContext.ExecuteStoreProcedure<AgentOrBrokerInfomationViewModel>();
        }

        /// <summary>
        /// Returns List of all Provider Approval counts
        /// </summary>
        /// <returns>Provider Approval Count</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 10:00PM
        /// </remarks>
        public async Task<PagedResponse<ProviderApprovalCountViewModel>> FetchAllProviderApprovalCount(PagingParam param)
        {
            var cmdText = "SELECT COUNT(ProviderNo) FROM [dbo].[VM_ProvidewiseApprovalCount];SELECT * FROM [dbo].[VM_ProvidewiseApprovalCount] ORDER BY ProviderNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<ProviderApprovalCountViewModel>();
            return new PagedResponse<ProviderApprovalCountViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Returns  List of Provider Approval Count by provider number
        /// </summary>
        /// <returns>Provider Approval Count</returns>
        ///<param name="provider_no">provider unique number</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 10:00PM
        /// </remarks>
        public async Task<PagedResponse<ProviderApprovalCountViewModel>> FetchProviderApprovalCountByProviderNo(int provider_no, PagingParam param)
        {

            var cmdText = $"SELECT COUNT(ProviderNo) FROM [dbo].[VM_ProvidewiseApprovalCount] where ProviderNo='{provider_no}';" +
                         $"SELECT * FROM [dbo].[VM_ProvidewiseApprovalCount] Where ProviderNo='{provider_no}' " +
                         $"ORDER  BY ProviderNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<ProviderApprovalCountViewModel>();
            return new PagedResponse<ProviderApprovalCountViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

        }



        /// <summary>
        /// Returns all HMO Member Approved Providers
        /// </summary>
        /// <returns>HMO Member Approved  Providers</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 07-11-2021 03:23AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<MemberApprovedProvidersViewModel>> FetchAllMemberApprovedProvidersByPolicyNo(PagingParam param, int policy_no)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_MemberApprovedProviders where PolicyNo = {policy_no}; SELECT * FROM vw_MemberApprovedProviders " +
                      $" where PolicyNo = {policy_no}  ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<MemberApprovedProvidersViewModel>();

            return new PagedResponse<MemberApprovedProvidersViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "Select PolicyNo,FromDate,ClassCode,HospNo,Name,ContNo,IPDAllowed,OPDAllowed,MaternityAllowed," +
            //             "DentalAllowed,OpticalAllowed,AvgClaim,Avg_Amount,Capitation" +
            //             " FROM dbo.vw_MemberApprovedProviders" +
            //              $" where PolicyNo = {policy_no}"; 

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<MemberApprovedProvidersViewModel>();
            #endregion

        }

        /// Returns List of all Approval Request Detials
        /// </summary>
        /// <returns>Approval Request Detials</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 1:00PM
        /// </remarks>
        public async Task<PagedResponse<ApprovalRequestDetailedViewModel>> FetchAllApprovalRequestDetails(PagingParam param)
        {
            var cmdText = $"SELECT COUNT(RequestNo) [dbo].[vw_ApprovalRequestDetailedView];SELECT [RequestNo],[AvonPaCode],[ApprovalDate],[Provider],[OPD/IPD] as OPDIPD,[ClaimStatus]," +
                           $"[PolicyNo],[MemberNo],[FromDate],[TotalToshfaAmount]" +
                           $",[NegotiatedAmount],[Modified Amount] as ModifiedAmount,[ServiceNotFoundAmount]," +
                           $"[PA Approval Amount] as PAApprovalAmount,[ServiceNotFoundDescription]" +
                           $",[State],[City],[Local Government Area(LGA)] LocalGovernmentArea,[ClientName]," +
                           $"[PA Issued By] as PAIssuedBy,[DecisionBy],[Notes] FROM [dbo].[vw_ApprovalRequestDetailedView] ORDER BY RequestNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<ApprovalRequestDetailedViewModel>();
            return new PagedResponse<ApprovalRequestDetailedViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

        }

        /// <summary>
        /// Returns  List of Approval Request Detial by Avon PA Code
        /// </summary>
        /// <returns>Approval Request Detial</returns>
        ///<param name="pacode">unique Avon PACode</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 1:15PM
        /// </remarks>
        public async Task<PagedResponse<ApprovalRequestDetailedViewModel>> FetchApprovalRequestDetailByPacode(string pacode, PagingParam param)
        {
            var cmdText = $"SELECT COUNT(RequestNo) [dbo].[vw_ApprovalRequestDetailedView] where AvonPaCode='{pacode}';SELECT [RequestNo],[AvonPaCode],[ApprovalDate],[Provider],[OPD/IPD] as OPDIPD,[ClaimStatus]," +
                        $"[PolicyNo],[MemberNo],[FromDate],[TotalToshfaAmount]" +
                        $",[NegotiatedAmount],[Modified Amount] as ModifiedAmount,[ServiceNotFoundAmount]," +
                        $"[PA Approval Amount] as PAApprovalAmount,[ServiceNotFoundDescription]" +
                        $",[State],[City],[Local Government Area(LGA)] LocalGovernmentArea,[ClientName]," +
                        $"[PA Issued By] as PAIssuedBy,[DecisionBy],[Notes] FROM [dbo].[vw_ApprovalRequestDetailedView] where AvonPaCode='{pacode}' ORDER BY RequestNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<ApprovalRequestDetailedViewModel>();
            return new PagedResponse<ApprovalRequestDetailedViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

        }


        /// <summary>
        /// Returns List of Approval Request Detial by Provider
        /// </summary>
        /// <returns>Approval Request Detial</returns>
        ///<param name="provider">HMO Provider</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 1:15PM
        /// </remarks>
        public async Task<PagedResponse<ApprovalRequestDetailedViewModel>> FetchApprovalRequestDetailByProvider(string provider, PagingParam param)
        {
            var cmdText = $"SELECT COUNT(RequestNo) [dbo].[vw_ApprovalRequestDetailedView] where Provider='{provider}';SELECT [RequestNo],[AvonPaCode],[ApprovalDate],[Provider],[OPD/IPD] as OPDIPD,[ClaimStatus]," +
                          $"[PolicyNo],[MemberNo],[FromDate],[TotalToshfaAmount]" +
                          $",[NegotiatedAmount],[Modified Amount] as ModifiedAmount,[ServiceNotFoundAmount]," +
                          $"[PA Approval Amount] as PAApprovalAmount,[ServiceNotFoundDescription]" +
                          $",[State],[City],[Local Government Area(LGA)] LocalGovernmentArea,[ClientName]," +
                          $"[PA Issued By] as PAIssuedBy,[DecisionBy],[Notes] FROM [dbo].[vw_ApprovalRequestDetailedView]" +
                          $" where Provider='{provider}' ORDER BY RequestNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<ApprovalRequestDetailedViewModel>();
            return new PagedResponse<ApprovalRequestDetailedViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }


        /// <summary>
        /// Returns  Approval Request Detial by Request No
        /// </summary>
        /// <returns>Approval Request Detial</returns>
        ///<param name="request_no">Unique Request No</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 1:15PM
        /// </remarks>
        public async Task<List<ApprovalRequestServiceWiseDetailedViewModel>> FetchApprovalRequestDetailByRequestNo(int request_no)
        {
            var sqlQuery = $"SELECT [RequestNo],[AvonPaCode],[ApprovalDate],[Provider],[OPD/IPD] as OPDIPD,[ClaimStatus]," +
                        $"[PolicyNo],[MemberNo],[FromDate],[TotalToshfaAmount]" +
                        $",[NegotiatedAmount],[Modified Amount] as ModifiedAmount,[ServiceNotFoundAmount]," +
                        $"[PA Approval Amount] as PAApprovalAmount,[ServiceNotFoundDescription]" +
                        $",[State],[City],[Local Government Area(LGA)] LocalGovernmentArea,[ClientName]," +
                        $"[PA Issued By] as PAIssuedBy,[DecisionBy],[Notes] FROM [dbo].[vw_ApprovalRequestDetailedView]" +
                        $" where RequestNo='{request_no}'";

            var spContext = _context.LoadSqlQuery(sqlQuery);

            return await spContext.ExecuteStoreProcedure<ApprovalRequestServiceWiseDetailedViewModel>();

        }


        /// <summary>
        /// Returns Approval Request Detial by Policy No
        /// </summary>
        /// <returns>Approval Request Detial</returns>
        ///<param name="policy_no">Unique Policy No</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 1:15PM
        /// </remarks>
        public async Task<PagedResponse<ApprovalRequestDetailedViewModel>> FetchApprovalRequestDetailByPolicyNo(int policy_no, PagingParam param)
        {

            var cmdText = $"SELECT COUNT(RequestNo) [dbo].[vw_ApprovalRequestDetailedView] where PolicyNo='{policy_no}';SELECT [RequestNo],[AvonPaCode],[ApprovalDate],[Provider],[OPD/IPD] as OPDIPD,[ClaimStatus]," +
                        $"[PolicyNo],[MemberNo],[FromDate],[TotalToshfaAmount]" +
                        $",[NegotiatedAmount],[Modified Amount] as ModifiedAmount,[ServiceNotFoundAmount]," +
                        $"[PA Approval Amount] as PAApprovalAmount,[ServiceNotFoundDescription]" +
                        $",[State],[City],[Local Government Area(LGA)] LocalGovernmentArea,[ClientName]," +
                        $"[PA Issued By] as PAIssuedBy,[DecisionBy],[Notes] FROM [dbo].[vw_ApprovalRequestDetailedView]" +
                        $" where PolicyNo='{policy_no}' ORDER BY RequestNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<ApprovalRequestDetailedViewModel>();
            return new PagedResponse<ApprovalRequestDetailedViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

        }

        /// <summary>
        /// Returns Approval Request Detial by Member No
        /// </summary>
        /// <returns>Approval Request Detial</returns>
        ///<param name="member_no">Memeber No</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 1:15PM
        /// </remarks>
        public async Task<PagedResponse<ApprovalRequestDetailedViewModel>> FetchApprovalRequestDetailByMemberNo(int member_no, PagingParam param)
        {

            var cmdText = $"SELECT COUNT(RequestNo) [dbo].[vw_ApprovalRequestDetailedView] where MemberNo='{member_no}';SELECT [RequestNo],[AvonPaCode],[ApprovalDate],[Provider],[OPD/IPD] as OPDIPD,[ClaimStatus]," +
                       $"[PolicyNo],[MemberNo],[FromDate],[TotalToshfaAmount]" +
                       $",[NegotiatedAmount],[Modified Amount] as ModifiedAmount,[ServiceNotFoundAmount]," +
                       $"[PA Approval Amount] as PAApprovalAmount,[ServiceNotFoundDescription]" +
                       $",[State],[City],[Local Government Area(LGA)] LocalGovernmentArea,[ClientName]," +
                       $"[PA Issued By] as PAIssuedBy,[DecisionBy],[Notes] FROM [dbo].[vw_ApprovalRequestDetailedView]" +
                       $" where MemberNo='{member_no}' ORDER BY RequestNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<ApprovalRequestDetailedViewModel>();
            return new PagedResponse<ApprovalRequestDetailedViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

        }



        /// <summary>
        /// Returns List of all Approval Request Service wise Detials
        /// </summary>
        /// <returns>Approval Request Service wise Detials</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<ApprovalRequestServiceWiseDetailedViewModel>> FetchAllApprovalRequestServiceDetails(PagingParam param)
        {
            var cmdText = $"SELECT COUNT(RequestNo) FROM [dbo].[vw_ApprovalRequestServiceWiseDetailedView];SELECT [RequestNo],[AvonPaCode],[RequestType],[MemberName],[MemberNo],[FirstName],[MiddleName],[SurName],[AVONMemberNo],[DOB],[Sex],[MobileNo]" +
                         $",[MemberType],[Relation],[PolicyNo],[Client],[Fromdate],[PlanCode],[PlanName],[PremiumType],[Hospital],[City],[State]                                                                                    " +
                         $",[LGA],[ProviderNo],[Address],[ApprovalType],[Receiveddate],[ReceivedTime],[DecisionDate],[ModifiedDate],[ApprovalStatus]                                                                                " +
                         $",[Benefits],[OpdIpd],[SBU],[CaseManager],[Speciality],[ProviderManager],[ApproveRejectCloseNotes],[TAT],[servicetype],[ProviderManagerRemarks],[ServiceDescription]                                      " +
                         $",[NoOfUnits],[UnitCost],[ToshfaAmount],[NegotiatedAmt],[ModifiedAmount],[Diagnosis],[DecisionBy],[PAIssuedBy],[Notes],[MissingServiceRemarks]                                                            " +
                         $",[PrimaryCareProvider],[PARequired],[Case/Utilization Manager] as CaseUtilizationManager,[Reason For Pending] as ReasonForPending,[New Approval Status]as NewApprovalStatus,[FinalPAAmount]            " +
                         $" FROM [dbo].[vw_ApprovalRequestServiceWiseDetailedView] ORDER BY RequestNo OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<ApprovalRequestServiceWiseDetailedViewModel>();
            return new PagedResponse<ApprovalRequestServiceWiseDetailedViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Returns  Approval Request Service wise Detial by PACode
        /// </summary>
        /// <returns>Approval Request Service wise Detial</returns>
        ///<param name="pacode">unique Avon PACode</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 1:15PM
        /// </remarks>
        public async Task<PagedResponse<ApprovalRequestServiceWiseDetailedViewModel>> FetchAllApprovalRequestServiceByPacode(string pacode, PagingParam param)
        {

            var cmdText = $"SELECT COUNT(RequestNo) FROM [dbo].[vw_ApprovalRequestServiceWiseDetailedView] where AvonPaCode='{pacode}';SELECT [RequestNo],[AvonPaCode],[RequestType],[MemberName],[MemberNo],[FirstName],[MiddleName],[SurName],[AVONMemberNo],[DOB],[Sex],[MobileNo]" +
                        $",[MemberType],[Relation],[PolicyNo],[Client],[Fromdate],[PlanCode],[PlanName],[PremiumType],[Hospital],[City],[State]                                                                                    " +
                        $",[LGA],[ProviderNo],[Address],[ApprovalType],[Receiveddate],[ReceivedTime],[DecisionDate],[ModifiedDate],[ApprovalStatus]                                                                                " +
                        $",[Benefits],[OpdIpd],[SBU],[CaseManager],[Speciality],[ProviderManager],[ApproveRejectCloseNotes],[TAT],[servicetype],[ProviderManagerRemarks],[ServiceDescription]                                      " +
                        $",[NoOfUnits],[UnitCost],[ToshfaAmount],[NegotiatedAmt],[ModifiedAmount],[Diagnosis],[DecisionBy],[PAIssuedBy],[Notes],[MissingServiceRemarks]                                                            " +
                        $",[PrimaryCareProvider],[PARequired],[Case/Utilization Manager] as CaseUtilizationManager,[Reason For Pending] as ReasonForPending,[New Approval Status]as NewApprovalStatus,[FinalPAAmount]            " +
                        $" FROM [dbo].[vw_ApprovalRequestServiceWiseDetailedView] where AvonPaCode='{pacode}' ORDER BY RequestNo OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<ApprovalRequestServiceWiseDetailedViewModel>();
            return new PagedResponse<ApprovalRequestServiceWiseDetailedViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

        }


        /// <summary>
        /// Returns all HMO Member Claims Details
        /// </summary>
        /// <returns>HMO Member Claims Details</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 03-11-2021 11:40AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberClaimsDetailsViewModel>> FetchAllMemberClaimsDetails(PagingParam param)
        {
            var cmdText = "SELECT COUNT(*) FROM vw_MemberClaimsDetails;SELECT * FROM vw_MemberClaimsDetails ORDER BY ClaimNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<HmoMemberClaimsDetailsViewModel>();

            return new PagedResponse<HmoMemberClaimsDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT ClaimNo,ClaimIncurredDate,Provider,[OPD/IPD] OPD_IPD,Capitation,ClaimStatus,HNetAmt," +
            //             "PolicyNo,MemberNo,FromDate" +
            //              " FROM AVONHMO_Replica.dbo.vw_MemberClaimsDetails";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberClaimsDetailsViewModel>();
            #endregion
        }
        /// Returns  Approval Request Service wise Detial by Provider
        /// </summary>
        /// <returns>Approval Request Service wise Detial</returns>
        ///<param name="provider">HMO Provider</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 1:15PM
        /// </remarks>
        public async Task<PagedResponse<ApprovalRequestServiceWiseDetailedViewModel>> FetchAllApprovalRequestServiceByProvider(int provider, PagingParam param)
        {
            var cmdText = $"SELECT COUNT(RequestNo) FROM [dbo].[vw_ApprovalRequestServiceWiseDetailedView] where ProviderNo='{provider}';SELECT [RequestNo],[AvonPaCode],[RequestType],[MemberName],[MemberNo],[FirstName],[MiddleName],[SurName],[AVONMemberNo],[DOB],[Sex],[MobileNo]" +
                         $",[MemberType],[Relation],[PolicyNo],[Client],[Fromdate],[PlanCode],[PlanName],[PremiumType],[Hospital],[City],[State]                                                                                    " +
                         $",[LGA],[ProviderNo],[Address],[ApprovalType],[Receiveddate],[ReceivedTime],[DecisionDate],[ModifiedDate],[ApprovalStatus]                                                                                " +
                         $",[Benefits],[OpdIpd],[SBU],[CaseManager],[Speciality],[ProviderManager],[ApproveRejectCloseNotes],[TAT],[servicetype],[ProviderManagerRemarks],[ServiceDescription]                                      " +
                         $",[NoOfUnits],[UnitCost],[ToshfaAmount],[NegotiatedAmt],[ModifiedAmount],[Diagnosis],[DecisionBy],[PAIssuedBy],[Notes],[MissingServiceRemarks]                                                            " +
                         $",[PrimaryCareProvider],[PARequired],[Case/Utilization Manager] as CaseUtilizationManager,[Reason For Pending] as ReasonForPending,[New Approval Status]as NewApprovalStatus,[FinalPAAmount]            " +
                         $" FROM [dbo].[vw_ApprovalRequestServiceWiseDetailedView] where ProviderNo='{provider}' ORDER BY RequestNo OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<ApprovalRequestServiceWiseDetailedViewModel>();
            return new PagedResponse<ApprovalRequestServiceWiseDetailedViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

        }




        /// <summary>
        /// Returns all HMO Member Claims Details
        /// </summary>
        /// <returns>HMO Member Claims Details</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 07-11-2021 5:58PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberClaimsDetailsViewModel>> FetchAllMemberClaimsDetailsByClaimNo(PagingParam param, int claim_no)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_MemberClaimsDetails where ClaimNo = {claim_no} ;SELECT * FROM vw_MemberClaimsDetails where ClaimNo = {claim_no} ORDER BY ClaimNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<HmoMemberClaimsDetailsViewModel>();

            return new PagedResponse<HmoMemberClaimsDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT ClaimNo,ClaimIncurredDate,Provider,[OPD/IPD] OPD_IPD,Capitation,ClaimStatus,HNetAmt," +
            //             "PolicyNo,MemberNo,FromDate" +
            //              " FROM AVONHMO_Replica.dbo.vw_MemberClaimsDetails";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberClaimsDetailsViewModel>();
            #endregion
        }



        /// <summary>
        /// Returns all HMO Member Claims Details
        /// </summary>
        /// <returns>HMO Member Claims Details</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 03-11-2021 11:55AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberDependentApprovalDetailsViewModel>> FetchAllMemberDependentApprovalDetails(PagingParam param)
        {
            var cmdText = "SELECT COUNT(*) FROM vw_MemberDependentApprovalDetails;SELECT * FROM vw_MemberDependentApprovalDetails ORDER BY RequestNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<HmoMemberDependentApprovalDetailsViewModel>();

            return new PagedResponse<HmoMemberDependentApprovalDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT RequestNo,AvonPaCode,RequestType,Name,MemberNo,Client,Hospital," +
            //              "approvalType,Receiveddate,ReceivedTime,DecisionDate,ApprovalStatus," +
            //              "BasicDiagnosis,OpdIpd ,TotalAmount,NegotiatedAmt,SBU,CaseManager," +
            //              "Speciality,ProviderManager,ApproveRejectCloseNotes,TAT," +
            //              "servicetype,ProviderManagerRemarks,ServiceDescription,Amount,Diagnosis," +
            //              "DecisionBy,FName,Notes,DecmodifiedAmount,ServiceNotFoundAmount,ApprovedAmt," +
            //              "RefHospName,ServiceNotFoundDescription,Policyno,fromdate,MemberHeadNo" +
            //          " FROM dbo.vw_MemberDependentApprovalDetails";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberDependentApprovalDetailsViewModel>();
            #endregion
        }




        /// <summary>
        /// Returns all HMO Member Claims Details
        /// </summary>
        /// <returns>HMO Member Claims Details</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 03-11-2021 6:37PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberDependentApprovalDetailsViewModel>> FetchAllMemberDependentApprovalDetailsByRequestNo(PagingParam param, int request_no)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_MemberDependentApprovalDetails where RequestNo = {request_no} ;SELECT * FROM vw_MemberDependentApprovalDetails where RequestNo = {request_no} ORDER BY RequestNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<HmoMemberDependentApprovalDetailsViewModel>();

            return new PagedResponse<HmoMemberDependentApprovalDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT RequestNo,AvonPaCode,RequestType,Name,MemberNo,Client,Hospital," +
            //              "approvalType,Receiveddate,ReceivedTime,DecisionDate,ApprovalStatus," +
            //              "BasicDiagnosis,OpdIpd ,TotalAmount,NegotiatedAmt,SBU,CaseManager," +
            //              "Speciality,ProviderManager,ApproveRejectCloseNotes,TAT," +
            //              "servicetype,ProviderManagerRemarks,ServiceDescription,Amount,Diagnosis," +
            //              "DecisionBy,FName,Notes,DecmodifiedAmount,ServiceNotFoundAmount,ApprovedAmt," +
            //              "RefHospName,ServiceNotFoundDescription,Policyno,fromdate,MemberHeadNo" +
            //          " FROM dbo.vw_MemberDependentApprovalDetails";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberDependentApprovalDetailsViewModel>();
            #endregion
        }
        /// <summary>
        /// Returns An Approval Request Service wise Detial by Request No
        /// </summary>
        /// <returns>Approval Request Service wise Detial</returns>
        ///<param name="request_no">Unique Request No</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 1:15PM
        /// </remarks>
        public async Task<List<ApprovalRequestServiceWiseDetailedViewModel>> FetchApprovalRequestServiceByRequestNo(int request_no)
        {
            var sqlQuery = $"SELECT [RequestNo],[AvonPaCode],[RequestType],[MemberName],[MemberNo],[FirstName],[MiddleName],[SurName],[AVONMemberNo],[DOB],[Sex],[MobileNo]" +
                           $",[MemberType],[Relation],[PolicyNo],[Client],[Fromdate],[PlanCode],[PlanName],[PremiumType],[Hospital],[City],[State]                                                                                    " +
                           $",[LGA],[ProviderNo],[Address],[ApprovalType],[Receiveddate],[ReceivedTime],[DecisionDate],[ModifiedDate],[ApprovalStatus]                                                                                " +
                           $",[Benefits],[OpdIpd],[SBU],[CaseManager],[Speciality],[ProviderManager],[ApproveRejectCloseNotes],[TAT],[servicetype],[ProviderManagerRemarks],[ServiceDescription]                                      " +
                           $",[NoOfUnits],[UnitCost],[ToshfaAmount],[NegotiatedAmt],[ModifiedAmount],[Diagnosis],[DecisionBy],[PAIssuedBy],[Notes],[MissingServiceRemarks]                                                            " +
                           $",[PrimaryCareProvider],[PARequired],[Case/Utilization Manager] as CaseUtilizationManager,[Reason For Pending] as ReasonForPending,[New Approval Status]as NewApprovalStatus,[FinalPAAmount]            " +
                           $" FROM [dbo].[vw_ApprovalRequestServiceWiseDetailedView] " +
                           $"where RequestNo='{request_no}'";

            var spContext = _context.LoadSqlQuery(sqlQuery);

            return await spContext.ExecuteStoreProcedure<ApprovalRequestServiceWiseDetailedViewModel>();


        }

        /// <summary>
        /// Returns Approval Request Service wise Detial by Policy No
        /// </summary>
        /// <returns>Approval Request Service wise Detial</returns>
        ///<param name="policy_no">Unique Policy No</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 1:15PM
        /// </remarks>
        public async Task<PagedResponse<ApprovalRequestServiceWiseDetailedViewModel>> FetchApprovalRequestServiceByPolicyNo(int policy_no, PagingParam param)
        {
            var cmdText = $"SELECT COUNT(RequestNo) FROM [dbo].[vw_ApprovalRequestServiceWiseDetailedView] where PolicyNo='{policy_no}';SELECT [RequestNo],[AvonPaCode],[RequestType],[MemberName],[MemberNo],[FirstName],[MiddleName],[SurName],[AVONMemberNo],[DOB],[Sex],[MobileNo]" +
                         $",[MemberType],[Relation],[PolicyNo],[Client],[Fromdate],[PlanCode],[PlanName],[PremiumType],[Hospital],[City],[State]                                                                                    " +
                         $",[LGA],[ProviderNo],[Address],[ApprovalType],[Receiveddate],[ReceivedTime],[DecisionDate],[ModifiedDate],[ApprovalStatus]                                                                                " +
                         $",[Benefits],[OpdIpd],[SBU],[CaseManager],[Speciality],[ProviderManager],[ApproveRejectCloseNotes],[TAT],[servicetype],[ProviderManagerRemarks],[ServiceDescription]                                      " +
                         $",[NoOfUnits],[UnitCost],[ToshfaAmount],[NegotiatedAmt],[ModifiedAmount],[Diagnosis],[DecisionBy],[PAIssuedBy],[Notes],[MissingServiceRemarks]                                                            " +
                         $",[PrimaryCareProvider],[PARequired],[Case/Utilization Manager] as CaseUtilizationManager,[Reason For Pending] as ReasonForPending,[New Approval Status]as NewApprovalStatus,[FinalPAAmount]            " +
                         $" FROM [dbo].[vw_ApprovalRequestServiceWiseDetailedView] where PolicyNo='{policy_no}' ORDER BY RequestNo OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<ApprovalRequestServiceWiseDetailedViewModel>();
            return new PagedResponse<ApprovalRequestServiceWiseDetailedViewModel>
            {

                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty

            };

        }

        /// <summary>
        /// Returns Approval Request Detial by Member No
        /// </summary>
        /// <returns>Approval Request Detial</returns>
        ///<param name="member_no">Memeber No</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 1:15PM
        /// </remarks>
        public async Task<PagedResponse<ApprovalRequestServiceWiseDetailedViewModel>> FetchApprovalRequestServiceByMemberNo(int member_no, PagingParam param)
        {
            var cmdText = $"SELECT COUNT(RequestNo) FROM [dbo].[vw_ApprovalRequestServiceWiseDetailedView] where MemberNo='{member_no}';SELECT [RequestNo],[AvonPaCode],[RequestType],[MemberName],[MemberNo],[FirstName],[MiddleName],[SurName],[AVONMemberNo],[DOB],[Sex],[MobileNo]" +
                          $",[MemberType],[Relation],[PolicyNo],[Client],[Fromdate],[PlanCode],[PlanName],[PremiumType],[Hospital],[City],[State]                                                                                    " +
                          $",[LGA],[ProviderNo],[Address],[ApprovalType],[Receiveddate],[ReceivedTime],[DecisionDate],[ModifiedDate],[ApprovalStatus]                                                                                " +
                          $",[Benefits],[OpdIpd],[SBU],[CaseManager],[Speciality],[ProviderManager],[ApproveRejectCloseNotes],[TAT],[servicetype],[ProviderManagerRemarks],[ServiceDescription]                                      " +
                          $",[NoOfUnits],[UnitCost],[ToshfaAmount],[NegotiatedAmt],[ModifiedAmount],[Diagnosis],[DecisionBy],[PAIssuedBy],[Notes],[MissingServiceRemarks]                                                            " +
                          $",[PrimaryCareProvider],[PARequired],[Case/Utilization Manager] as CaseUtilizationManager,[Reason For Pending] as ReasonForPending,[New Approval Status]as NewApprovalStatus,[FinalPAAmount]            " +
                          $" FROM [dbo].[vw_ApprovalRequestServiceWiseDetailedView] where MemberNo='{member_no}' ORDER BY RequestNo OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<ApprovalRequestServiceWiseDetailedViewModel>();
            return new PagedResponse<ApprovalRequestServiceWiseDetailedViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }


        /// <summary>
        /// Returns Approval Request Detial by Avon Member No
        /// </summary>
        /// <returns>Approval Request Detial</returns>
        ///<param name="avon_member_no">Avon Memeber No</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 1:15PM
        /// </remarks>
        public async Task<PagedResponse<ApprovalRequestServiceWiseDetailedViewModel>> FetchApprovalRequestServiceByAvonMemberNo(string avon_member_no, PagingParam param)
        {
            var cmdText = $"SELECT COUNT(RequestNo) FROM [dbo].[vw_ApprovalRequestServiceWiseDetailedView] where avonmemberno='{avon_member_no}';SELECT [RequestNo],[AvonPaCode],[RequestType],[MemberName],[MemberNo],[FirstName],[MiddleName],[SurName],[AVONMemberNo],[DOB],[Sex],[MobileNo]" +
                          $",[MemberType],[Relation],[PolicyNo],[Client],[Fromdate],[PlanCode],[PlanName],[PremiumType],[Hospital],[City],[State]                                                                                    " +
                          $",[LGA],[ProviderNo],[Address],[ApprovalType],[Receiveddate],[ReceivedTime],[DecisionDate],[ModifiedDate],[ApprovalStatus]                                                                                " +
                          $",[Benefits],[OpdIpd],[SBU],[CaseManager],[Speciality],[ProviderManager],[ApproveRejectCloseNotes],[TAT],[servicetype],[ProviderManagerRemarks],[ServiceDescription]                                      " +
                          $",[NoOfUnits],[UnitCost],[ToshfaAmount],[NegotiatedAmt],[ModifiedAmount],[Diagnosis],[DecisionBy],[PAIssuedBy],[Notes],[MissingServiceRemarks]                                                            " +
                          $",[PrimaryCareProvider],[PARequired],[Case/Utilization Manager] as CaseUtilizationManager,[Reason For Pending] as ReasonForPending,[New Approval Status]as NewApprovalStatus,[FinalPAAmount]            " +
                          $" FROM [dbo].[vw_ApprovalRequestServiceWiseDetailedView] where avonmemberno='{avon_member_no}' ORDER BY RequestNo OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<ApprovalRequestServiceWiseDetailedViewModel>();
            return new PagedResponse<ApprovalRequestServiceWiseDetailedViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

        }


        /// <summary>
        /// Returns List of all Approval Request Utilization Detials
        /// </summary>
        /// <returns>Approval Request Utilization Detials</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<ApprovalReqUtilizationDetailsViewModel>> FetchAllApprovalRequestUtilizationDetail(PagingParam param)
        {
            var cmdText = $"SELECT COUNT(RequestNo) FROM [dbo].[Vw_ApprovalReqUtilizationDetails];SELECT * FROM [dbo].[Vw_ApprovalReqUtilizationDetails] ORDER BY RequestNo OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<ApprovalReqUtilizationDetailsViewModel>();
            return new PagedResponse<ApprovalReqUtilizationDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }



        /// <summary>
        /// Returns An Approval Request Service Utilization by Request No
        /// </summary>
        /// <returns>Approval Request Utilization Detial</returns>
        ///<param name="request_no">Unique Request No</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 1:15PM
        /// </remarks>
        public async Task<List<ApprovalReqUtilizationDetailsViewModel>> FetchApprovalRequestUtilizationRequestNo(int request_no)
        {
            var sqlQuery = $"SELECT * FROM [dbo].[Vw_ApprovalReqUtilizationDetails] " +
                           $"where RequestNo='{request_no}'";

            var spContext = _context.LoadSqlQuery(sqlQuery);

            return await spContext.ExecuteStoreProcedure<ApprovalReqUtilizationDetailsViewModel>();
        }


        /// <summary>
        /// Returns  Approval Request Service wise Detial by PACode
        /// </summary>
        /// <returns>Approval Request Service wise Detial</returns>
        ///<param name="pacode">unique Avon PACode</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 1:15PM
        /// </remarks>
        public async Task<PagedResponse<ApprovalReqUtilizationDetailsViewModel>> FetchApprovalRequestUtilizationByPacode(string pacode, PagingParam param)
        {

            var cmdText = $"SELECT COUNT(RequestNo) FROM [dbo].[Vw_ApprovalReqUtilizationDetails] where AvonPaCode='{pacode}';SELECT * FROM [dbo].[Vw_ApprovalReqUtilizationDetails] where AvonPaCode='{pacode}' ORDER BY RequestNo OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<ApprovalReqUtilizationDetailsViewModel>();
            return new PagedResponse<ApprovalReqUtilizationDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };


        }


        /// <summary>
        /// Returns all HMO Member Claims Details
        /// </summary>
        /// <returns>HMO Member Claims Details</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 03-11-2021 6:37PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberDependentApprovalDetailsViewModel>> FetchAllMemberDependentApprovalDetailsByMemberNo(PagingParam param, int member_no)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_MemberDependentApprovalDetails where MemberNo = {member_no} ;" +
                          $"SELECT RequestNo,AvonPaCode,RequestType,Name,MemberNo,Client,Hospital," +
                          $"approvalType,Receiveddate,ReceivedTime,DecisionDate,ApprovalStatus," +
                          $"BasicDiagnosis,OpdIpd ,TotalAmount,NegotiatedAmt,SBU,CaseManager," +
                          $"Speciality,ProviderManager,ApproveRejectCloseNotes,TAT," +
                          $"servicetype,ProviderManagerRemarks,ServiceDescription,Amount,Diagnosis," +
                          $"DecisionBy,FName,Notes,DecmodifiedAmount,ServiceNotFoundAmount,ApprovedAmt," +
                          $"RefHospName,ServiceNotFoundDescription,Policyno,fromdate,MemberHeadNo" +
                          $" FROM dbo.vw_MemberDependentApprovalDetails" +
                          $" where MemberNo = {member_no} ORDER BY MemberNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<HmoMemberDependentApprovalDetailsViewModel>();

            return new PagedResponse<HmoMemberDependentApprovalDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            // var query = "SELECT RequestNo,AvonPaCode,RequestType,Name,MemberNo,Client,Hospital," +
            //    "approvalType,Receiveddate,ReceivedTime,DecisionDate,ApprovalStatus," +
            //    "BasicDiagnosis,OpdIpd ,TotalAmount,NegotiatedAmt,SBU,CaseManager," +
            //    "Speciality,ProviderManager,ApproveRejectCloseNotes,TAT," +
            //    "servicetype,ProviderManagerRemarks,ServiceDescription,Amount,Diagnosis," +
            //    "DecisionBy,FName,Notes,DecmodifiedAmount,ServiceNotFoundAmount,ApprovedAmt," +
            //    "RefHospName,ServiceNotFoundDescription,Policyno,fromdate,MemberHeadNo" +
            //" FROM dbo.vw_MemberDependentApprovalDetails";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberDependentApprovalDetailsViewModel>();
            #endregion
        }



        /// <summary>
        /// Returns all HMO Member Claims Details
        /// </summary>
        /// <returns>HMO Member Claims Details</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 03-11-2021 6:37PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberDependentApprovalDetailsViewModel>> FetchAllMemberDependentApprovalDetailsByAvonPaCode(PagingParam param, string avon_pa_code)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_MemberDependentApprovalDetails where AvonPaCode = '{avon_pa_code}' ;SELECT * FROM vw_MemberDependentApprovalDetails" +
            $" where AvonPaCode = '{avon_pa_code}' ORDER BY MemberNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<HmoMemberDependentApprovalDetailsViewModel>();

            return new PagedResponse<HmoMemberDependentApprovalDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT RequestNo,AvonPaCode,RequestType,Name,MemberNo,Client,Hospital," +
            //              "approvalType,Receiveddate,ReceivedTime,DecisionDate,ApprovalStatus," +
            //              "BasicDiagnosis,OpdIpd ,TotalAmount,NegotiatedAmt,SBU,CaseManager," +
            //              "Speciality,ProviderManager,ApproveRejectCloseNotes,TAT," +
            //              "servicetype,ProviderManagerRemarks,ServiceDescription,Amount,Diagnosis," +
            //              "DecisionBy,FName,Notes,DecmodifiedAmount,ServiceNotFoundAmount,ApprovedAmt," +
            //              "RefHospName,ServiceNotFoundDescription,Policyno,fromdate,MemberHeadNo" +
            //          " FROM dbo.vw_MemberDependentApprovalDetails";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberDependentApprovalDetailsViewModel>();
            #endregion
        }





        /// <summary>
        /// Returns all HMO Member Dependent Claims Details
        /// </summary>
        /// <returns>HMO Member Dependent Claims Details</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 03-11-2021 1:32PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberDependentClaimsDetailsViewModel>> FetchAllMemberDependentClaimsDetails(PagingParam param)
        {

            var cmdText = "SELECT COUNT(*) FROM vw_MemberDependentClaimsDetails;SELECT * FROM vw_MemberDependentClaimsDetails ORDER BY ClaimNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<HmoMemberDependentClaimsDetailsViewModel>();

            return new PagedResponse<HmoMemberDependentClaimsDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "Select ClaimNo,ClaimIncurredDate,Provider,[OPD/IPD] OPD_IPD,Capitation,ClaimStatus," +
            //            "HNetAmt,PolicyNo,MemberNo,FromDate,MemberHeadNo" +
            //            " FROM dbo.vw_MemberDependentClaimsDetails";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberDependentClaimsDetailsViewModel>();
            #endregion
        }




        /// <summary>
        /// Returns all HMO Member Dependent Claims Details By Claim No
        /// </summary>
        /// <returns>HMO Member Dependent Claims Details By Claim No</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 08-11-2021 7:40AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberDependentClaimsDetailsViewModel>> FetchAllMemberDependentClaimsDetailsByClaimNo(PagingParam param, int claim_no)
        {

            var cmdText = $"SELECT COUNT(*) FROM vw_MemberDependentClaimsDetails where ClaimNo = {claim_no} ;" +
                          $" SELECT ClaimNo,ClaimIncurredDate,Provider,[OPD/IPD] OPD_IPD,Capitation,ClaimStatus," +
                          $"HNetAmt,PolicyNo,MemberNo,FromDate,MemberHeadNo" +
                          $" FROM vw_MemberDependentClaimsDetails where ClaimNo = {claim_no} ORDER BY ClaimNo" +
                          $" OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<HmoMemberDependentClaimsDetailsViewModel>();

            return new PagedResponse<HmoMemberDependentClaimsDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "Select ClaimNo,ClaimIncurredDate,Provider,[OPD/IPD] OPD_IPD,Capitation,ClaimStatus," +
            //            "HNetAmt,PolicyNo,MemberNo,FromDate,MemberHeadNo" +
            //            " FROM dbo.vw_MemberDependentClaimsDetails";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberDependentClaimsDetailsViewModel>();
            #endregion
        }





        /// <summary>
        /// Returns all HMO Member Dependent Claims Details By Member No
        /// </summary>
        /// <returns>HMO Member Dependent Claims Details By Member No</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 08-11-2021 7:50AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberDependentClaimsDetailsViewModel>> FetchAllMemberDependentClaimsDetailsByMemberNo(PagingParam param, int member_no)
        {

            var cmdText = $"SELECT COUNT(*) FROM vw_MemberDependentClaimsDetails where MemberNo = {member_no} ;" +
                          $" SELECT ClaimNo,ClaimIncurredDate,Provider,[OPD/IPD] OPD_IPD,Capitation,ClaimStatus," +
                          $"HNetAmt,PolicyNo,MemberNo,FromDate,MemberHeadNo" +
                          $" FROM vw_MemberDependentClaimsDetails where MemberNo = {member_no} ORDER BY ClaimNo" +
                          $" OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<HmoMemberDependentClaimsDetailsViewModel>();

            return new PagedResponse<HmoMemberDependentClaimsDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "Select ClaimNo,ClaimIncurredDate,Provider,[OPD/IPD] OPD_IPD,Capitation,ClaimStatus," +
            //            "HNetAmt,PolicyNo,MemberNo,FromDate,MemberHeadNo" +
            //            " FROM dbo.vw_MemberDependentClaimsDetails";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberDependentClaimsDetailsViewModel>();
            #endregion
        }





        /// <summary>
        /// Returns all HMO Member Dependent Details
        /// </summary>
        /// <returns>HMO Member Dependent Details</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 03-11-2021 1:40pM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberDependentDetailsViewModel>> FetchAllMemberDependentDetails(PagingParam param)
        {
            var cmdText = "SELECT COUNT(*) FROM vw_MemberDependentDetails;SELECT * FROM vw_MemberDependentDetails ORDER BY [DEP.MemberNo] OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<HmoMemberDependentDetailsViewModel>();

            return new PagedResponse<HmoMemberDependentDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT [DEP.MemberNo] MemberNo,[DEP.Member Name] MemberName,[DEP.Gender] Gender,[DEP.RELATION] Relation," +
            //            "[DEP.EnrollmentDate] EnrollmentDate,[DEP.AxaMemberNo] AxaMemberNo,[DEP.Status] Status,[POLICYNO] POLICYNO," +
            //            "[FROMDATE],[MemberHeadNo]" +
            //            " FROM[dbo].[vw_MemberDependentDetails]";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberDependentDetailsViewModel>();
            #endregion
        }




        /// <summary>
        /// Returns all HMO Member Dependent Details By Member No
        /// </summary>
        /// <returns>HMO Member Dependent Details  By Member No</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 09-11-2021 11:40AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberDependentDetailsViewModel>> FetchAllMemberDependentDetailsByMemberNo(PagingParam param, int member_no)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_MemberDependentDetails where [DEP.MemberNo] = {member_no};" +
                          $"SELECT [DEP.MemberNo] MemberNo,[DEP.Member Name] MemberName,[DEP.Gender] Gender,[DEP.RELATION] Relation," +
                          $"[DEP.EnrollmentDate] EnrollmentDate,[DEP.AxaMemberNo] AxaMemberNo,[DEP.Status] Status,[POLICYNO] POLICYNO,[FROMDATE],[MemberHeadNo]" +
                          $" FROM vw_MemberDependentDetails where [DEP.MemberNo] = {member_no} ORDER BY [DEP.MemberNo] OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<HmoMemberDependentDetailsViewModel>();

            return new PagedResponse<HmoMemberDependentDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT [DEP.MemberNo] MemberNo,[DEP.Member Name] MemberName,[DEP.Gender] Gender,[DEP.RELATION] Relation," +
            //            "[DEP.EnrollmentDate] EnrollmentDate,[DEP.AxaMemberNo] AxaMemberNo,[DEP.Status] Status,[POLICYNO] POLICYNO," +
            //            "[FROMDATE],[MemberHeadNo]" +
            //            " FROM[dbo].[vw_MemberDependentDetails]";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberDependentDetailsViewModel>();
            #endregion
        }



        /// <summary>
        /// Returns List of all Pending Approval Request Utilization Detials
        /// </summary>
        /// <returns>Pending Approval Request Utilization Detials</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<ApprovalReqUtilizationPendingDetailsViewModel>> FetchAllPendingApprovalRequestUtilizationDetail(PagingParam param)
        {
            var cmdText = $"SELECT COUNT(RequestNo) FROM [dbo].[Vw_ApprovalReqUtilizationDetails];SELECT " +
                $"[RequestNo],[AvonPaCode],[RequestType],[Name],[Client],[Hospital],[RefHospName],[Type]," +
                $"[OpdIpd],[RequestDate],[DecisionDate],[Notes],[Provider/Utilization Manager] as ProviderUtilizationManager," +
                $"[Remarks],[ApprovalStatus],[Utilizationmanager],[caseManager],[Emanagertype]" +
                $" FROM [dbo].[Vw_ApprovalReqUtilizationDetails_Pending] ORDER BY RequestNo OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<ApprovalReqUtilizationPendingDetailsViewModel>();
            return new PagedResponse<ApprovalReqUtilizationPendingDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Returns Pending Approval Request Service Utilization by Request No
        /// </summary>
        /// <returns>Pending Approval Request Utilization Detial</returns>
        ///<param name="request_no">Unique Request No</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 1:15PM
        /// </remarks>
        public async Task<List<ApprovalReqUtilizationPendingDetailsViewModel>> FetchPendingApprovalRequestUtilizationRequestNo(int request_no)
        {
            var sqlQuery = $"SELECT  FROM " +
                           $"[RequestNo],[AvonPaCode],[RequestType],[Name],[Client],[Hospital],[RefHospName],[Type]," +
                           $"[OpdIpd],[RequestDate],[DecisionDate],[Notes],[Provider/Utilization Manager] as ProviderUtilizationManager," +
                           $"[Remarks],[ApprovalStatus],[Utilizationmanager],[caseManager],[Emanagertype] " +
                           $" FROM [dbo].[Vw_ApprovalReqUtilizationDetails_Pending] where RequestNo='{request_no}'";

            var spContext = _context.LoadSqlQuery(sqlQuery);

            return await spContext.ExecuteStoreProcedure<ApprovalReqUtilizationPendingDetailsViewModel>();
        }


        /// <summary>
        /// Returns  Pending Approval Request Service wise Detial by PACode
        /// </summary>
        /// <returns>Pending Approval Request Service wise Detial</returns>
        ///<param name="pacode">unique Avon PACode</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 1:15PM
        /// </remarks>
        public async Task<PagedResponse<ApprovalReqUtilizationPendingDetailsViewModel>> FetchPendingApprovalRequestUtilizationByPacode(string pacode, PagingParam param)
        {
            var cmdText = $"SELECT COUNT(RequestNo) FROM [dbo].[Vw_ApprovalReqUtilizationDetails] where AvonPaCode='{pacode}';SELECT " +
              $"[RequestNo],[AvonPaCode],[RequestType],[Name],[Client],[Hospital],[RefHospName],[Type]," +
              $"[OpdIpd],[RequestDate],[DecisionDate],[Notes],[Provider/Utilization Manager] as ProviderUtilizationManager," +
              $"[Remarks],[ApprovalStatus],[Utilizationmanager],[caseManager],[Emanagertype]" +
              $" FROM [dbo].[Vw_ApprovalReqUtilizationDetails_Pending] where AvonPaCode='{pacode}' ORDER BY RequestNo OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<ApprovalReqUtilizationPendingDetailsViewModel>();
            return new PagedResponse<ApprovalReqUtilizationPendingDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }



        /// <summary>
        /// Returns List of all Average Claims Per Enrollee
        /// </summary>
        /// <returns>Average Claims Per Enrollee</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<AverageClaimsPaidPerEnrolleeViewModel>> FetchAllAverageClaimsPaidPerEnrollee(PagingParam param)
        {
            var cmdText = $"SELECT COUNT(PolicyNo) FROM [dbo].[vw_AverageClaimsPaidPerEnrollee];SELECT " +
                $"[ClientName],[PolicyNo],[Policy Inception],[MemberNo],[MemberHeadNo],[EnrollmentDate],[Name],[Fromdate],[PlanType],[Plan Type Category] As PlanTypeCategory," +
                $"[PAIDAMOUNT],[ClaimNo],[ClaimIncurredDate],[ClaimReceivedDate],[HOSPNO],[HospitalName],[SBU]" +
                $" FROM [dbo].[vw_AverageClaimsPaidPerEnrollee] ORDER BY [PolicyNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<AverageClaimsPaidPerEnrolleeViewModel>();
            return new PagedResponse<AverageClaimsPaidPerEnrolleeViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Returns List of all Average Premium Per Enrollee
        /// </summary>
        /// <returns>Average Premium Per Enrollee</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<AveragePremiumPerEnrolleeViewModel>> FetchAllAveragePremiumPaidPerEnrollee(PagingParam param)
        {
            var cmdText = $"SELECT COUNT(PolicyNo) FROM [dbo].[vw_AveragePremiumPerEnrollee]; SELECT  [ClientName],[PolicyNo],[FromDate],[MemberNo],[MemberHeadNo],[EnrollmentDate],[Name],[PlanType]" +
                $",[Plan Type Category],[PaidDate],[SBU],[AgentId],[AgentName]" +
                $" FROM [dbo].[vw_AveragePremiumPerEnrollee] ORDER BY [PolicyNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<AveragePremiumPerEnrolleeViewModel>();
            return new PagedResponse<AveragePremiumPerEnrolleeViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Returns List of all Average Premium Per Plan
        /// </summary>
        /// <returns>Average Premium Per Plan</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<AveragePremiumPerPlanViewModel>> FetchAllAveragePremiumPerPlan(PagingParam param)
        {
            var cmdText = $"SELECT COUNT(PolicyNo) FROM [dbo].[vw_AveragePremiumPerPlan]; SELECT  [ClientName],[PolicyNo],[FromDate],[MemberNo],[MemberHeadNo],[EnrollmentDate],[Name],[PlanType]" +
                $",[Plan Type Category],[PaidDate],[SBU],[AgentId],[AgentName]" +
                $" FROM [dbo].[vw_AveragePremiumPerPlan] ORDER BY [PolicyNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<AveragePremiumPerPlanViewModel>();
            return new PagedResponse<AveragePremiumPerPlanViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Returns List of all Enrollee Capitation/Policy and Plan Detail Report
        /// </summary>
        /// <returns>Enrollee Capitation/Policy and Plan Detail Report</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<CapitationEnrolleePolicyandPlanWiseDetailsReportViewModel>> FetchAllEnrolleeCapitationDetailReport(PagingParam param)
        {
            var cmdText = $"SELECT COUNT(PolicyNo) FROM [dbo].[vw_CapitationEnrolleePolicyandPlanWiseDetailsReport]; SELECT  * FROM [dbo].[vw_CapitationEnrolleePolicyandPlanWiseDetailsReport] " +
                $"ORDER BY [PolicyNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<CapitationEnrolleePolicyandPlanWiseDetailsReportViewModel>();
            return new PagedResponse<CapitationEnrolleePolicyandPlanWiseDetailsReportViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Returns Enrollee Capitation/Policy and Plan Detail Report by Policy No
        /// </summary>
        /// <returns>Enrollee Capitation/Policy and Plan Detail Report</returns>
        ///<param name="policy_no">Unique Request No</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 03-11-2021 1:15PM
        /// </remarks>
        public async Task<PagedResponse<CapitationEnrolleePolicyandPlanWiseDetailsReportViewModel>> FetchEnrolleeCapitationDetailReportByPolicyNo(int policy_no, PagingParam param)
        {
            var cmdText = $"SELECT COUNT(PolicyNo) FROM [dbo].[vw_CapitationEnrolleePolicyandPlanWiseDetailsReport] where PolicyNo='{policy_no}'; " +
                $"SELECT  * FROM [dbo].[vw_CapitationEnrolleePolicyandPlanWiseDetailsReport] " +
                          $" where PolicyNo='{policy_no}' ORDER BY [PolicyNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<CapitationEnrolleePolicyandPlanWiseDetailsReportViewModel>();
            return new PagedResponse<CapitationEnrolleePolicyandPlanWiseDetailsReportViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }


        /// <summary>
        /// Returns List of all Claims Actuarial Analysis5
        /// </summary>
        /// <returns>Claims Actuarial Analysis5</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<ClaimsActuarialAnalysis5ViewModel>> FetchClaimsActuarialAnalysis5(PagingParam param)
        {
            var cmdText = $"SELECT COUNT(ClaimNo) FROM [dbo].[VW_ClaimsActuarialAnalysis5]; SELECT  * FROM [dbo].[VW_ClaimsActuarialAnalysis5] " +
                $"ORDER BY [ClaimNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<ClaimsActuarialAnalysis5ViewModel>();
            return new PagedResponse<ClaimsActuarialAnalysis5ViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }


        /// <summary>
        /// Returns List of all Claims Information
        /// </summary>
        /// <returns>Claims Information</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<ClaimsInformationViewModel>> FetchAllClaimsInformation(PagingParam param)
        {
            var cmdText = $"SELECT COUNT(ClaimNo) FROM [dbo].[vw_ClaimsInformation]; SELECT [ClientName],[PolicyNo],[Policy Inception] As PolicyInception," +
                          $"[MemberNo],[MemberHeadNo],[EnrollmentDate]," +
                          $"[Name],[Fromdate],[PlanType],[Plan Type Category] as PlanTypeCategory,[StateOfClaimsOrigin],[Gender],[Age]," +
                          $"[DOB],[PAIDAMOUNT],[ClaimNo],[Policy StartDate] as PolicyStartDate,[Policy EndDate]," +
                          $"[ClaimIncurredDate],[ClaimReceivedDate],[TotalAmount],[DateOfClaimsPayment]," +
                          $"[HOSPNO],[HospitalName],[SBU],[Policy Year] As PolicyYear,[PaymentYear],[AccidentYear],[ReasonForVisitToTheHospital],[DiagnosedAilment]" +
                          $"FROM [dbo].[vw_ClaimsInformation] " +
                          $"ORDER BY [ClaimNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<ClaimsInformationViewModel>();
            return new PagedResponse<ClaimsInformationViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Returns List of all Client Posted Premium Detail
        /// </summary>
        /// <returns>Client Posted Premium</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<ClientPremiumPostDtlsViewModel>> FetchAllClientPostedPremium(PagingParam param)
        {
            var cmdText = $"SELECT COUNT(Policyno) FROM [dbo].[vw_ClientPremiumPostDtls]; SELECT * FROM [dbo].[vw_ClientPremiumPostDtls] " +
                          $"ORDER BY [Policyno] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<ClientPremiumPostDtlsViewModel>();
            return new PagedResponse<ClientPremiumPostDtlsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Returns List of Consultation Prices
        /// </summary>
        /// <returns>Consultation Prices</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<ConsultationPriceListViewModel>> FetchAllConsultationPrices(PagingParam param)
        {
            var cmdText = $"SELECT COUNT(ProviderNo) FROM [dbo].[vw_ConsultationPriceList]; SELECT * FROM [dbo].[vw_ConsultationPriceList] " +
                          $"ORDER BY [ProviderNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<ConsultationPriceListViewModel>();
            return new PagedResponse<ConsultationPriceListViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Returns List of Consultation Prices by provider number
        /// </summary>
        /// <param name="provider_no">provider number</param>
        /// <returns>Consultation Prices For A provider</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<ConsultationPriceListViewModel>> FetchAllConsultationPricesByProvider(int provider_no, PagingParam param)
        {
            var cmdText = $"SELECT COUNT(ProviderNo) FROM [dbo].[vw_ConsultationPriceList] where ProviderNo='{provider_no}'; SELECT * FROM [dbo].[vw_ConsultationPriceList] " +
                         $" where ProviderNo='{provider_no}'ORDER BY [ProviderNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<ConsultationPriceListViewModel>();
            return new PagedResponse<ConsultationPriceListViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

        }


        /// <summary>
        /// Returns List of Enroller Information
        /// </summary>
        /// <returns>Enroller Information</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<Enrollee_InformationViewModel>> FetchEnrollee_Information(PagingParam param)
        {
            var cmdText = $"SELECT COUNT(MemberNo) FROM [dbo].[VW_Enrollee_Information]; SELECT   [MemberNo]," +
                          $"[First Name] as FirstName,[Last Name] as LastName,[Company],[Plan_Type],[Policy_Start_Date],[Policy_End_Date]," +
                          $"[Phone Number] as PhoneNumber,[EMAIL],[Amount]," +
                          $"[Contact Address] as ContactAddress,[Policy_no],[Disease Condition] as DiseaseCondition," +
                          $"[Date Diagnosed] as DateDiagnosed,[ClaimNo] FROM [VW_Enrollee_Information] " +
                          $"ORDER BY [MemberNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<Enrollee_InformationViewModel>();
            return new PagedResponse<Enrollee_InformationViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }


        /// <summary>
        /// Returns List of Enroller Information by member number
        /// </summary>
        /// <returns>Enroller Information</returns>
        /// <param name="member_no">member number</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<Enrollee_InformationViewModel>> FetchEnrollee_InformationByMemberNo(int member_no, PagingParam param)
        {

            var cmdText = $"SELECT COUNT(MemberNo) FROM [dbo].[VW_Enrollee_Information] where MemberNo='{member_no}'; SELECT   [MemberNo]," +
                         $"[First Name] as FirstName,[Last Name] as LastName,[Company],[Plan_Type],[Policy_Start_Date],[Policy_End_Date]," +
                         $"[Phone Number] as PhoneNumber,[EMAIL],[Amount]," +
                         $"[Contact Address] as ContactAddress,[Policy_no],[Disease Condition] as DiseaseCondition," +
                         $"[Date Diagnosed] as DateDiagnosed,[ClaimNo] FROM [VW_Enrollee_Information] " +
                         $"where MemberNo='{member_no}' ORDER BY [MemberNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<Enrollee_InformationViewModel>();
            return new PagedResponse<Enrollee_InformationViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

        }



        /// <summary>
        /// Returns List of Enroller Members
        /// </summary>
        /// <returns>Enroller Members</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<EnrolleMemberViewModel>> FetchAllEnrolleeMember(PagingParam param)
        {
            var cmdText = $"SELECT COUNT(MemberNo) FROM [dbo].[vw_EnrolleMember]; SELECT   * FROM [dbo].[vw_EnrolleMember] " +
                          $"ORDER BY [MemberNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<EnrolleMemberViewModel>();
            return new PagedResponse<EnrolleMemberViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }


        /// <summary>
        /// Returns Enroller Member by member number
        /// </summary>
        /// <returns>Enroller Member</returns>
        /// <param name="member_no">member number</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<EnrolleMemberViewModel>> FetchEnrolleeMemberByMemberNo(int member_no, PagingParam param)
        {

            var cmdText = $"SELECT COUNT(MemberNo) FROM [dbo].[vw_EnrolleMember] where MemberNo='{member_no}'; SELECT   * FROM [dbo].[vw_EnrolleMember] " +
                         $"  where MemberNo='{member_no}' ORDER BY [MemberNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<EnrolleMemberViewModel>();
            return new PagedResponse<EnrolleMemberViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };


        }


        /// <summary>
        /// Returns List of ERX Diagnosis Details
        /// </summary>
        /// <returns>ERX Diagnosis Details</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<ERXDiagnosisDetailsViewModel>> FetchAllERXDiagnosisDetails(PagingParam param)
        {
            var cmdText = $"SELECT COUNT(Code) FROM [dbo].[vw_ERXDiagnosisDetails]; SELECT   * FROM [dbo].[vw_ERXDiagnosisDetails] " +
                          $"ORDER BY [Code] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<ERXDiagnosisDetailsViewModel>();
            return new PagedResponse<ERXDiagnosisDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Returns List of ERX Diagnosis Details By code
        /// </summary>
        /// <returns>ERX Diagnosis Details</returns>
        /// /// <param name="code">ERX Diagnosis Code</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<ERXDiagnosisDetailsViewModel>> FetchERXDiagnosisDetailByCodes(string code, PagingParam param)
        {
            var cmdText = $"SELECT COUNT(Code) FROM [dbo].[vw_ERXDiagnosisDetails] where code='{code}'; SELECT   * FROM [dbo].[vw_ERXDiagnosisDetails] " +
                            $"where code='{code}' ORDER BY [Code] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<ERXDiagnosisDetailsViewModel>();
            return new PagedResponse<ERXDiagnosisDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };


        }


        /// <summary>
        /// Returns List of Sepcialities
        /// </summary>
        /// <returns>Sepcialities Master</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<SpecialityMasterViewModel>> FetchASepcialities(PagingParam param)
        {
            var cmdText = $"SELECT COUNT(Code) FROM [dbo].[vw_getallSpecialityMaster]; SELECT   * FROM [dbo].[vw_getallSpecialityMaster] " +
                          $"ORDER BY [Code] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<SpecialityMasterViewModel>();
            return new PagedResponse<SpecialityMasterViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }


        /// <summary>
        /// Returns List of Sepciality  By code
        /// </summary>
        /// <returns>Sepciality</returns>
        /// /// <param name="code">Sepciality Code</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<SpecialityMasterViewModel>> FetchSepcialityByCodes(string code, PagingParam param)
        {
            var cmdText = $"SELECT COUNT(Code) FROM [dbo].[vw_getallSpecialityMaster] where code='{code}'; SELECT   * FROM [dbo].[vw_getallSpecialityMaster] " +
                        $"where code='{code}' ORDER BY [Code] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<SpecialityMasterViewModel>();
            return new PagedResponse<SpecialityMasterViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }







        /// <summary>
        /// Returns List of ICD Codes
        /// </summary>
        /// <returns>ICD Codes</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<ICDCODESViewModel>> FetchAllICDCodes(PagingParam param)
        {
            var cmdText = $"SELECT COUNT([ICD CODES]) FROM [dbo].[vw_ICDCODES]; SELECT [ICD CODES] as ICDCODES,[DESCRIPTION],[ICD TYPE] as ICDTYPE,[CATEGORY] FROM [dbo].[vw_ICDCODES] " +
                          $"ORDER BY [ICD CODES] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<ICDCODESViewModel>();
            return new PagedResponse<ICDCODESViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }


        /// <summary>
        /// Returns  Sepciality  ICD Codes By Code
        /// </summary>
        /// <returns>ICD Codes </returns>
        /// /// <param name="code">Sepciality Code</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<List<SpecialityMasterViewModel>> FetchICDCodeByCodes(string code)
        {
            var sqlQuery = $"SELECT [ICD CODES] as ICDCODES,[DESCRIPTION],[ICD TYPE] as ICDTYPE,[CATEGORY] FROM [dbo].[vw_ICDCODES]" +
                            $"where [ICD CODES]='{code}'";

            var spContext = _context.LoadSqlQuery(sqlQuery);

            return await spContext.ExecuteStoreProcedure<SpecialityMasterViewModel>();
        }



        /// <summary>
        /// Returns List of ICD Dentals
        /// </summary>
        /// <returns>ICD Dentals</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<ICDDENTALViewModel>> FetchAllICDDentals(PagingParam param)
        {
            var cmdText = $"SELECT COUNT([CODE]) FROM [dbo].[vw_ICDDENTAL]; SELECT * FROM [dbo].[vw_ICDDENTAL] " +
                          $"ORDER BY [CODE] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<ICDDENTALViewModel>();
            return new PagedResponse<ICDDENTALViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }


        /// <summary>
        /// Returns List of Sepciality  ICD Dental By Code
        /// </summary>
        /// <returns>ICD Dentals </returns>
        /// /// <param name="code"> ICD Dental Code</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<ICDDENTALViewModel>> FetchICDDentalsByCodes(string code, PagingParam param)
        {

            var cmdText = $"SELECT COUNT([CODE]) FROM [dbo].[vw_ICDDENTAL] where code='{code}'; SELECT * FROM [dbo].[vw_ICDDENTAL] " +
                          $" where code='{code}' ORDER BY [CODE] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<ICDDENTALViewModel>();
            return new PagedResponse<ICDDENTALViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }


        /// <summary>
        /// Returns List of Loss Ratio Per Plan
        /// </summary>
        /// <returns>Loss Ratio Per Plan</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<LossRatioPerPlanViewModel>> FetchAllLossRatioPerPlan(PagingParam param)
        {
            var cmdText = $"SELECT COUNT([PolicyNo]) FROM [dbo].[vw_ICDDENTAL]; SELECT [ClientName],[PolicyNo],[Policy Inception] as PolicyInception," +
                          $"[MemberNo],[MemberHeadNo],[Name],[Fromdate],[PolicyEndDate],[Enrollmentdate],[PlanType],[Plan Type Category] as PlanTypeCategory," +
                          $"[DateOfPremiumPaid],[SBU],[AgentId],[AgentName],[State],[City],[Address],[Gender],[DOB],[ClaimsPaidDate],[ClaimsTotalAmount],[ClaimsPAIDAMOUNT],[ClaimNo]," +
                          $"[ClaimIncurredDate],[ClaimReceivedDate],[HOSPNO],[HospitalName],[ClaimStatus] FROM [dbo].[vw_ICDDENTAL] " +
                          $"ORDER BY [PolicyNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<LossRatioPerPlanViewModel>();
            return new PagedResponse<LossRatioPerPlanViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Returns List of Member Approvals
        /// </summary>
        /// <returns>Member Approvals</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<MemberApprovalViewModel>> FetchAllMemberApproval(PagingParam param)
        {
            var cmdText = $"SELECT COUNT([RequestNo]) FROM [dbo].[vw_MemberApproval]; SELECT [RequestNo],[AvonPaCode],[ApprovalDate],[Provider]," +
                $"[OPD/IPD] as OPDIPD,[ClaimStatus],[PolicyNo],[MemberNo],[FromDate],[TotalToshfaAmount]," +
                $"[NegotiatedAmount],[Modified Amount] as ModifiedAmount,[Service not found Amount] as ServicenotfoundAmount," +
                $"[PA Approval Amount] as PAApprovalAmount FROM [dbo].[vw_MemberApproval] " +
                $"ORDER BY [RequestNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<MemberApprovalViewModel>();
            return new PagedResponse<MemberApprovalViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Returns  Member Approval By Request Number
        /// </summary>
        /// <returns> Member Approval </returns>
        /// <param name="request_no">request no</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<List<MemberApprovalViewModel>> FetchMemberApprovalByRequestNo(string request_no)
        {
            var sqlQuery = $"SELECT [RequestNo],[AvonPaCode],[ApprovalDate],[Provider]," +
                           $"[OPD/IPD] as OPDIPD,[ClaimStatus],[PolicyNo],[MemberNo],[FromDate],[TotalToshfaAmount]," +
                           $"[NegotiatedAmount],[Modified Amount] as ModifiedAmount,[Service not found Amount] as ServicenotfoundAmount," +
                           $"[PA Approval Amount] as PAApprovalAmount FROM [dbo].[vw_MemberApproval] " +
                           $"Where [RequestNo]='{request_no}'";

            var spContext = _context.LoadSqlQuery(sqlQuery);

            return await spContext.ExecuteStoreProcedure<MemberApprovalViewModel>();
        }

        /// <summary>
        /// Returns List of Member Approval By Avon Pa Code
        /// </summary>
        /// <returns> Member Approval </returns>
        ///  <param name="pacode">Avon Pa Code</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<MemberApprovalViewModel>> FetchMemberApprovalByPaCode(string pacode, PagingParam param)
        {

            var cmdText = $"SELECT COUNT([RequestNo]) FROM [dbo].[vw_MemberApproval] Where [AvonPaCode]='{pacode}'; SELECT [RequestNo],[AvonPaCode],[ApprovalDate],[Provider]," +
               $"[OPD/IPD] as OPDIPD,[ClaimStatus],[PolicyNo],[MemberNo],[FromDate],[TotalToshfaAmount]," +
               $"[NegotiatedAmount],[Modified Amount] as ModifiedAmount,[Service not found Amount] as ServicenotfoundAmount," +
               $"[PA Approval Amount] as PAApprovalAmount FROM [dbo].[vw_MemberApproval] " +
               $" Where [AvonPaCode]='{pacode}' ORDER BY [RequestNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<MemberApprovalViewModel>();
            return new PagedResponse<MemberApprovalViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

        }
        /// <summary>
        /// Returns List of Member Approval By Policy No
        /// </summary>
        /// <returns> Member Approval </returns>
        ///  <param name="policy_no">Avon Pa Code</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<MemberApprovalViewModel>> FetchMemberApprovalByPolicyNo(int policy_no, PagingParam param)
        {
            var cmdText = $"SELECT COUNT([RequestNo]) FROM [dbo].[vw_MemberApproval] Where [PolicyNo]='{policy_no}'; SELECT [RequestNo],[AvonPaCode],[ApprovalDate],[Provider]," +
               $"[OPD/IPD] as OPDIPD,[ClaimStatus],[PolicyNo],[MemberNo],[FromDate],[TotalToshfaAmount]," +
               $"[NegotiatedAmount],[Modified Amount] as ModifiedAmount,[Service not found Amount] as ServicenotfoundAmount," +
               $"[PA Approval Amount] as PAApprovalAmount FROM [dbo].[vw_MemberApproval] " +
               $" Where [PolicyNo]='{policy_no}' ORDER BY [RequestNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<MemberApprovalViewModel>();
            return new PagedResponse<MemberApprovalViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

        }

        /// <summary>
        /// Returns List of Member Approval By Member No
        /// </summary>
        /// <returns> Member Approval </returns>
        ///  <param name="member_no">Avon Pa Code</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<MemberApprovalViewModel>> FetchMemberApprovalByMemberNo(int member_no, PagingParam param)
        {
            var cmdText = $"SELECT COUNT([RequestNo]) FROM [dbo].[vw_MemberApproval] Where [MemberNo]='{member_no}'; SELECT [RequestNo],[AvonPaCode],[ApprovalDate],[Provider]," +
              $"[OPD/IPD] as OPDIPD,[ClaimStatus],[PolicyNo],[MemberNo],[FromDate],[TotalToshfaAmount]," +
              $"[NegotiatedAmount],[Modified Amount] as ModifiedAmount,[Service not found Amount] as ServicenotfoundAmount," +
              $"[PA Approval Amount] as PAApprovalAmount FROM [dbo].[vw_MemberApproval] " +
              $"Where [MemberNo]='{member_no}' ORDER BY [RequestNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<MemberApprovalViewModel>();
            return new PagedResponse<MemberApprovalViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }


        /// <summary>
        /// Returns List of Member Details with ToshfaUID
        /// </summary>
        /// <returns>Member Details with ToshfaUID</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<MemberDetailswithToshfaUIDViewModel>> FetchAllMemberDetailswithToshfaUID(PagingParam param)
        {
            var cmdText = $"SELECT COUNT([ToshfaUID]) FROM [dbo].[VW_MemberDetailswithToshfaUID]; SELECT * FROM [dbo].[VW_MemberDetailswithToshfaUID] " +
                $"ORDER BY [ToshfaUID] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<MemberDetailswithToshfaUIDViewModel>();
            return new PagedResponse<MemberDetailswithToshfaUIDViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Returns List of Member Details with ToshfaUID By Member No
        /// </summary>
        /// <returns> Member Details with ToshfaUID </returns>
        ///  <param name="member_no">Member No</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<MemberDetailswithToshfaUIDViewModel>> FetchMemberDetailswithToshfaUIDByMemberNo(int member_no, PagingParam param)
        {
            var cmdText = $"SELECT COUNT([ToshfaUID]) FROM [dbo].[VW_MemberDetailswithToshfaUID] Where [MemberNo]='{member_no}'; SELECT * FROM [dbo].[VW_MemberDetailswithToshfaUID] " +
                $"Where [MemberNo]='{member_no}' ORDER BY [ToshfaUID] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<MemberDetailswithToshfaUIDViewModel>();
            return new PagedResponse<MemberDetailswithToshfaUIDViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

        }

        /// <summary>
        /// Returns List of Member Details with ToshfaUID By Member No
        /// </summary>
        /// <returns> Member Details with ToshfaUID </returns>
        ///  <param name="toshfa_uid">Avon Pa Code</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<MemberDetailswithToshfaUIDViewModel>> FetchMemberDetailswithByToshfaUID(string toshfa_uid, PagingParam param)
        {
            var cmdText = $"SELECT COUNT([ToshfaUID]) FROM [dbo].[VW_MemberDetailswithToshfaUID] Where [ToshfaUID]='{toshfa_uid}'; SELECT * FROM [dbo].[VW_MemberDetailswithToshfaUID] " +
                 $"Where [ToshfaUID]='{toshfa_uid}' ORDER BY [ToshfaUID] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<MemberDetailswithToshfaUIDViewModel>();
            return new PagedResponse<MemberDetailswithToshfaUIDViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

        }



        /// <summary>
        /// Returns List of Supply Prices
        /// </summary>
        /// <returns>Supply Prices</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<SupplyPriceListViewModel>> FetchAllSupplyPrices(PagingParam param)
        {
            var cmdText = $"SELECT COUNT([ProviderNo]) FROM [dbo].[vw_SupplyPriceList]; SELECT * FROM [dbo].[vw_SupplyPriceList] " +
                $"ORDER BY [ProviderNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<SupplyPriceListViewModel>();
            return new PagedResponse<SupplyPriceListViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }


        /// <summary>
        /// Returns List of Supply Price By Provider No
        /// </summary>
        /// <returns> Supply Price </returns>
        ///  <param name="provider_no">Provider No</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<SupplyPriceListViewModel>> FetchAllSupplyPriceByProviderNo(int provider_no, PagingParam param)
        {
            var cmdText = $"SELECT COUNT([ProviderNo]) FROM [dbo].[vw_SupplyPriceList] Where [ProviderNo]='{provider_no}'; SELECT * FROM [dbo].[vw_SupplyPriceList] " +
               $"Where [ProviderNo]='{provider_no}' ORDER BY [ProviderNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<SupplyPriceListViewModel>();
            return new PagedResponse<SupplyPriceListViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };



        }


        /// <summary>
        /// Returns List of Member Policies
        /// </summary>
        /// <returns>Member Policies</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<MemberPolicyClassViewModel>> FetchAllMemberPolicies(PagingParam param)
        {
            var cmdText = $"SELECT COUNT([PolicyNo]) FROM [dbo].[vw_tblMemberPolicyClass]; SELECT [Enrollee Name] As EnrolleeName,[DOB],[Gender],[Relation],[MemberType]," +
                          $"[Clientname],[PrimaryProvider],[PlanName],[PolicyExpiry Date] as PolicyExpiryDate,[PolicyNo],[FromDate],[ClassCode]," +
                          $"[CardNo],[Status],[HireDate],[EnrollmentDate],[MemberExpirydate],[CardExpirydate],[ReqProcessDate]," +
                          $"[CardProcessDate],[EmpNo],[BranchNo],[DBNNo],[CBNNo]," +
                          $"[Membershipno],[Notes],[TRANS_DATE],[USERID],[PaymentTerms],[HouseholdId],[KNCU_MemberNo],[HasInsurance]," +
                          $"[PremiumType],[ApplicationNo],[Gm_Memberno]," +
                          $"[Gm_TranDate],[IndPolicyNo],[VerifiedBy],[EXCEL_NAME],[CardPrintDate]," +
                          $"[CertificatePrintDate],[PolicyDocPrintDate],[CMemberNo],[MemberMailStatus]," +
                          $"[MemberNote],[SF_Trans_Type_Add],[NewRepMemberFlag] FROM [dbo].[vw_tblMemberPolicyClass] " +
                          $"ORDER BY [PolicyNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<MemberPolicyClassViewModel>();
            return new PagedResponse<MemberPolicyClassViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Returns List of Member Policies By policy No
        /// </summary>
        /// <returns> Member Policies </returns>
        ///  <param name="policy_no">policy no</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<MemberPolicyClassViewModel>> FetchMemberPoliciesByPolicyNo(int policy_no, PagingParam param)
        {
            var cmdText = $"SELECT COUNT([PolicyNo]) FROM [dbo].[vw_tblMemberPolicyClass] Where [PolicyNo]='{policy_no}'; SELECT [Enrollee Name] As EnrolleeName,[DOB],[Gender],[Relation],[MemberType]," +
                         $"[Clientname],[PrimaryProvider],[PlanName],[PolicyExpiry Date] as PolicyExpiryDate,[PolicyNo],[FromDate],[ClassCode]," +
                         $"[CardNo],[Status],[HireDate],[EnrollmentDate],[MemberExpirydate],[CardExpirydate],[ReqProcessDate]," +
                         $"[CardProcessDate],[EmpNo],[BranchNo],[DBNNo],[CBNNo]," +
                         $"[Membershipno],[Notes],[TRANS_DATE],[USERID],[PaymentTerms],[HouseholdId],[KNCU_MemberNo],[HasInsurance]," +
                         $"[PremiumType],[ApplicationNo],[Gm_Memberno]," +
                         $"[Gm_TranDate],[IndPolicyNo],[VerifiedBy],[EXCEL_NAME],[CardPrintDate]," +
                         $"[CertificatePrintDate],[PolicyDocPrintDate],[CMemberNo],[MemberMailStatus]," +
                         $"[MemberNote],[SF_Trans_Type_Add],[NewRepMemberFlag] FROM [dbo].[vw_tblMemberPolicyClass] " +
                         $"Where [PolicyNo]='{policy_no}' ORDER BY [PolicyNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<MemberPolicyClassViewModel>();
            return new PagedResponse<MemberPolicyClassViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

        }


        /// <summary>
        /// Returns List of Toshfa Unique Numbers
        /// </summary>
        /// <returns>Toshfa Unique Numbers</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<ToshfaUniqueNoViewModel>> FetchAllToshfaUniqueNo(PagingParam param)
        {
            var cmdText = $"SELECT COUNT([MemberNo]) FROM [dbo].[vw_ToshfaUniqueNo];SELECT * FROM [dbo].[vw_ToshfaUniqueNo] " +
                          $"ORDER BY [MemberNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<ToshfaUniqueNoViewModel>();
            return new PagedResponse<ToshfaUniqueNoViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }


        /// <summary>
        /// Returns List of Toshfa Unique Numbers By Member No
        /// </summary>
        /// <returns> Toshfa Unique Numbers </returns>
        /// <param name="member_no">Member No</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<ToshfaUniqueNoViewModel>> FetchToshfaUniqueNoByMemberNo(int member_no, PagingParam param)
        {
            var cmdText = $"SELECT COUNT([MemberNo]) FROM [dbo].[vw_ToshfaUniqueNo] Where [MemberNo]='{member_no}';SELECT * FROM [dbo].[vw_ToshfaUniqueNo] " +
                          $"Where [MemberNo]='{member_no}' ORDER BY [MemberNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<ToshfaUniqueNoViewModel>();
            return new PagedResponse<ToshfaUniqueNoViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }


        /// <summary>
        /// Returns  Toshfa Unique Number By Toshfa Unique Id
        /// </summary>
        /// <returns> Toshfa Unique Number </returns>
        ///  <param name="toshfa_unique_id">Member No</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<ToshfaUniqueNoViewModel>> FetchToshfaUniqueNoByUniqueId(string toshfa_unique_id, PagingParam param)
        {
            var cmdText = $"SELECT COUNT([MemberNo]) FROM [dbo].[vw_ToshfaUniqueNo] Where [ToshfaUniqueId]='{toshfa_unique_id}';SELECT * FROM [dbo].[vw_ToshfaUniqueNo] " +
                        $"Where [ToshfaUniqueId]='{toshfa_unique_id}' ORDER BY [MemberNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<ToshfaUniqueNoViewModel>();
            return new PagedResponse<ToshfaUniqueNoViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };


        }



        /// <summary>
        /// Returns all HMO Member Details
        /// </summary>
        /// <returns>HMO Member Details</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 03-11-2021 1:45pM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberDetailsViewModel>> FetchAllMemberDetails(PagingParam param)
        {
            var cmdText = "SELECT COUNT(*) FROM VW_MemberDetails;SELECT * FROM VW_MemberDetails ORDER BY MemberNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<HmoMemberDetailsViewModel>();

            return new PagedResponse<HmoMemberDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT MemberNo, MemberName, MobileNo, EMAIL, ClaimIncurredDate, ClaimReceivedDate, TRANS_DATE FROM dbo.VW_MemberDetails";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberDetailsViewModel>();
            #endregion
        }






        /// <summary>
        /// Returns all HMO Member Details
        /// </summary>
        /// <returns>HMO Member Details</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 09-11-2021 2:45PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberDetailsViewModel>> FetchAllMemberDetailsByMemberNo(PagingParam param, int member_no)
        {
            var cmdText = $"SELECT COUNT(*) FROM VW_MemberDetails where MemberNo = {member_no};" +
                          $"SELECT * FROM VW_MemberDetails where MemberNo = {member_no} ORDER BY MemberNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<HmoMemberDetailsViewModel>();

            return new PagedResponse<HmoMemberDetailsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT MemberNo, MemberName, MobileNo, EMAIL, ClaimIncurredDate, ClaimReceivedDate, TRANS_DATE FROM dbo.VW_MemberDetails";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberDetailsViewModel>();
            #endregion
        }






        /// <summary>
        /// Returns all HMO Member Details With Toshfa UID
        /// </summary>
        /// <returns>HMO Member Details With Toshfa UID</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 03-11-2021 1:48pM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberDetailsWithToshfaUIDViewModel>> FetchAllMemberDetailsWithToshfaUID(PagingParam param)
        {
            var cmdText = "SELECT COUNT(*) FROM VW_MemberDetailswithToshfaUID;SELECT * FROM VW_MemberDetailswithToshfaUID ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<HmoMemberDetailsWithToshfaUIDViewModel>();

            return new PagedResponse<HmoMemberDetailsWithToshfaUIDViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "Select ToshfaUID,Memberno,HouseHoldId,SurName,FirstName,MiddleName,MaidenName,Age," +
            //            "Sex,MobileNo,Email,Maritalstatus,PrimaryProviderName,ClientName,PolicyStartDate,PolicyEndDate" +
            //            " FROM dbo.VW_MemberDetailswithToshfaUID";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberDetailsWithToshfaUIDViewModel>();
            #endregion
        }






        /// <summary>
        /// Returns all HMO Member Details With Toshfa UID by Toshfa UID
        /// </summary>
        /// <returns>HMO Member Details With Toshfa UID by Toshfa UID</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 03-11-2021 3:17PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberDetailsWithToshfaUIDViewModel>> FetchAllMemberDetailsWithToshfaUIDByToshfaUID(PagingParam param, string toshfaUID)
        {
            var cmdText = $"SELECT COUNT(*) FROM VW_MemberDetailswithToshfaUID where ToshfaUID = '{toshfaUID}' ;" +
                          $"SELECT * FROM VW_MemberDetailswithToshfaUID where ToshfaUID = '{toshfaUID}' ORDER BY ToshfaUID OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
            var pageResult = query.Read<HmoMemberDetailsWithToshfaUIDViewModel>();

            return new PagedResponse<HmoMemberDetailsWithToshfaUIDViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "Select ToshfaUID,Memberno,HouseHoldId,SurName,FirstName,MiddleName,MaidenName,Age," +
            //            "Sex,MobileNo,Email,Maritalstatus,PrimaryProviderName,ClientName,PolicyStartDate,PolicyEndDate" +
            //            " FROM dbo.VW_MemberDetailswithToshfaUID";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberDetailsWithToshfaUIDViewModel>();
            #endregion
        }




        /// <summary>
        /// Returns all HMO Member Information
        /// </summary>
        /// <returns>HMO Member Information</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 03-11-2021 1:52pM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberInformationViewModel>> FetchAllMemberInformation(PagingParam param)
        {

            var cmdText = "SELECT COUNT(*) FROM vw_MemberInformation;SELECT * FROM vw_MemberInformation ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMemberInformationViewModel>();

            return new PagedResponse<HmoMemberInformationViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT PolicyNo,FromDate,ClassCode,Member,Policy,[Member Enrollment Date] MemberEnrollmentDate," +
            //             "[Member Status] MemberStatus,Sex,[Staff ID] StaffID,[Insurance Id] InsuranceId,[Primary Provider] PrimaryProvider," +
            //             "[Secondary Provider] SecondaryProvider,[Individual Policy No]  IndividualPolicyNo,AxaPolicyNo,Nationality," +
            //             "[Inception Date] InceptionDate,[Expiry Date] ExpiryDate,Relation,[Date of Birth] DateofBirth,Age,MobileNo,Address," +
            //             "[Plan],SBU,[Policy Plan Type] PolicyPlanType,AxaMemberNo,Notes,Branch,KNCU_MemberNo,MemberPhoto," +
            //             "MemberImage,CardExpirydate,MemberHeadNo,DepIqamaNo,EmpNo,MemberNo" + //PolicyPlanType --> A duplicate from db
            //             " FROM dbo.vw_MemberInformation";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberInformationViewModel>();
            #endregion
        }





        /// <summary>
        /// Returns all HMO Member Information By Member No
        /// </summary>
        /// <returns>HMO Member Information By Member No</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 09-11-2021 3:37PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberInformationViewModel>> FetchAllMemberInformationByMemberNo(PagingParam param, int memberNo)
        {

            var cmdText = $"SELECT COUNT(*) FROM vw_MemberInformation where MemberNo = {memberNo} ;" +
                          $"SELECT * FROM vw_MemberInformation where MemberNo = {memberNo} ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMemberInformationViewModel>();

            return new PagedResponse<HmoMemberInformationViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT PolicyNo,FromDate,ClassCode,Member,Policy,[Member Enrollment Date] MemberEnrollmentDate," +
            //             "[Member Status] MemberStatus,Sex,[Staff ID] StaffID,[Insurance Id] InsuranceId,[Primary Provider] PrimaryProvider," +
            //             "[Secondary Provider] SecondaryProvider,[Individual Policy No]  IndividualPolicyNo,AxaPolicyNo,Nationality," +
            //             "[Inception Date] InceptionDate,[Expiry Date] ExpiryDate,Relation,[Date of Birth] DateofBirth,Age,MobileNo,Address," +
            //             "[Plan],SBU,[Policy Plan Type] PolicyPlanType,AxaMemberNo,Notes,Branch,KNCU_MemberNo,MemberPhoto," +
            //             "MemberImage,CardExpirydate,MemberHeadNo,DepIqamaNo,EmpNo,MemberNo" + //PolicyPlanType --> A duplicate from db
            //             " FROM dbo.vw_MemberInformation";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberInformationViewModel>();
            #endregion
        }




        /// <summary>
        /// Returns all HMO Member Master
        /// </summary>
        /// <returns>HMO Member Master</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 04-11-2021 4:40AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberMasterViewModel>> FetchAllMemberMaster(PagingParam param)
        {
            //var cmdText = "SELECT COUNT(PolicyNo) FROM vw_MemberMasterView;SELECT * FROM vw_MemberMasterView ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var cmdText = $"SELECT COUNT(PolicyNo) FROM vw_MemberMasterView;SELECT PolicyNo, ClientName,[Policy Inception] PolicyInception,[Policy Expiry] PolicyExpiry,PlanType," +
                  $"[Plan Type Category] PlanTypeCategory,MemberHeadNo,MemberType,MemberNo" +
                  $",AvonOldEnrolleId, PremiumType,Name,SurName, FirstName, MiddleName" +
                  $",Gender, Relation, MaritalStatus, DOB, Country, State, City, Address" +
                  $",SBU , EnrollmentDate , PrimaryProviderNo , PrimaryProviderName, MemberExpirydate " +
                  $",StaffID, EMAIL, MobileNo , CapitatedMember , CapitationRate '' bloodType, '' weight, '' height, '' imageUrl" +
              $"FROM vw_MemberMasterView  WHERE Relation='MEMBER' ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMemberMasterViewModel>();

            return new PagedResponse<HmoMemberMasterViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };


        }

        //AllHmoMemberMasterViewModel


        public async Task<PagedResponse<AllHmoMemberMasterViewModel>> FetchExistingMemberMasterWithEmail(PagingParam param)
        {
            //var cmdText = "SELECT COUNT(PolicyNo) FROM vw_MemberMasterView;SELECT * FROM vw_MemberMasterView ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var cmdText = $"SELECT COUNT(PolicyNo) FROM vw_MemberMasterView;SELECT PolicyNo, ClientName,[Policy Inception] PolicyInception,[Policy Expiry] PolicyExpiry,PlanType," +
                  $"[Plan Type Category] PlanTypeCategory,MemberHeadNo,MemberType,MemberNo" +
                  $",AvonOldEnrolleId, PremiumType,Name,SurName, FirstName, MiddleName" +
                  $",Gender, Relation, MaritalStatus, DOB, Country, State, City, Address" +
                  $",SBU , EnrollmentDate , PrimaryProviderNo , PrimaryProviderName, MemberExpirydate " +
                  $",StaffID, EMAIL, MobileNo , CapitatedMember, CapitationRate " +
              $"FROM vw_MemberMasterView WHERE ClientName NOT IN ('UNITED BANK FOR AFRICA','TRANSCORP HILTON HOTEL ABUJA','TRANSCORP POWER UGHELLI','UNITED CAPITAL PLC'," +
              $"'AVON HEALTHCARE LIMITED','HEIRS HOLDING OIL AND GAS LTD','AFRICA PRUDENTIAL REGISTRARS','HEIRS INSURANCE LIMITED','HEIRS LIFE ASSURANCE','AFRILAND PROPERTIES PLC'," +
              $"'HEIRS LIFE ASSURANCE DSA','TRANSCORP PLC','TRANSCORP HOTEL CALABAR','TRANS AFAM POWER PLANT LIMITED','HEIRS HOLDINGS','TRANSCORP HOTELS ABUJA','HEIRS INSURANCE BROKERS', " +
                $"'TONY ELUMELU FOUNDATION','REDTECH LIMITED','TENOIL') AND  (email <>'' or email NOT like '%default%') AND MemberType='EMPLOYEE' ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<AllHmoMemberMasterViewModel>();

            return new PagedResponse<AllHmoMemberMasterViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };


        }


        public async Task<PagedResponse<AllHmoMemberMasterViewModel>> FetchExistingMemberMasterWithoutEmail(PagingParam param)
        {
            //var cmdText = "SELECT COUNT(PolicyNo) FROM vw_MemberMasterView;SELECT * FROM vw_MemberMasterView ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var cmdText = $"SELECT COUNT(PolicyNo) FROM vw_MemberMasterView;SELECT PolicyNo, ClientName,[Policy Inception] PolicyInception,[Policy Expiry] PolicyExpiry,PlanType," +
                  $"[Plan Type Category] PlanTypeCategory,MemberHeadNo,MemberType,MemberNo" +
                  $",AvonOldEnrolleId, PremiumType,Name,SurName, FirstName, MiddleName" +
                  $",Gender, Relation, MaritalStatus, DOB, Country, State, City, Address" +
                  $",SBU , EnrollmentDate , PrimaryProviderNo , PrimaryProviderName, MemberExpirydate " +
                  $",StaffID, EMAIL, MobileNo , CapitatedMember, CapitationRate " +
              $"FROM vw_MemberMasterView WHERE  (email ='' or email like '%default%') AND MemberType='EMPLOYEE' ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<AllHmoMemberMasterViewModel>();

            return new PagedResponse<AllHmoMemberMasterViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };


        }

        public async Task<PagedResponse<AllHmoMemberMasterViewModel>> FetchExistingMemberMaster(PagingParam param)
        {
            //var cmdText = "SELECT COUNT(PolicyNo) FROM vw_MemberMasterView;SELECT * FROM vw_MemberMasterView ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var cmdText = $"SELECT COUNT(PolicyNo) FROM vw_MemberMasterView;SELECT PolicyNo, ClientName,[Policy Inception] PolicyInception,[Policy Expiry] PolicyExpiry,PlanType," +
                  $"[Plan Type Category] PlanTypeCategory,MemberHeadNo,MemberType,MemberNo" +
                  $",AvonOldEnrolleId, PremiumType,Name,SurName, FirstName, MiddleName" +
                  $",Gender, Relation, MaritalStatus, DOB, Country, State, City, Address" +
                  $",SBU , EnrollmentDate , PrimaryProviderNo , PrimaryProviderName, MemberExpirydate " +
                  $",StaffID, EMAIL, MobileNo , CapitatedMember, CapitationRate " +
              $"FROM vw_MemberMasterView  WHERE Relation='MEMBER' ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<AllHmoMemberMasterViewModel>();

            return new PagedResponse<AllHmoMemberMasterViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };


        }

        public async Task<AllHmoMemberMasterViewModel> FetchMemberByNumber(int memberNumber)
        {
            //var cmdText = "SELECT COUNT(PolicyNo) FROM vw_MemberMasterView;SELECT * FROM vw_MemberMasterView ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var cmdText = $"SELECT Top 1 PolicyNo, ClientName,[Policy Inception] PolicyInception,[Policy Expiry] PolicyExpiry,PlanType," +
                  $"[Plan Type Category] PlanTypeCategory,MemberHeadNo,MemberType,MemberNo" +
                  $",AvonOldEnrolleId, PremiumType,Name,SurName, FirstName, MiddleName" +
                  $",Gender, Relation, MaritalStatus, DOB, Country, State, City, Address" +
                  $",SBU , EnrollmentDate , PrimaryProviderNo , PrimaryProviderName, MemberExpirydate " +
                  $",StaffID, EMAIL, MobileNo , CapitatedMember, CapitationRate " +
              $"FROM vw_MemberMasterView  WHERE MemberNo={memberNumber}";

            var result = await _connection.QueryFirstAsync<AllHmoMemberMasterViewModel>(cmdText);


            //var result = query

            return result;


        }




        public async Task<PagedResponse<AllHmoMemberMasterViewModel>> FetchExistingAvonStaffMemberMaster(PagingParam param)
        {
            //var cmdText = "SELECT COUNT(PolicyNo) FROM vw_MemberMasterView;SELECT * FROM vw_MemberMasterView ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var cmdText = $"SELECT COUNT(PolicyNo) FROM vw_MemberMasterView WHERE plantype = 'AVON STAFF PLAN' AND MemberType='EMPLOYEE';SELECT PolicyNo, ClientName,[Policy Inception] PolicyInception,[Policy Expiry] PolicyExpiry,PlanType," +
                  $"[Plan Type Category] PlanTypeCategory,MemberHeadNo,MemberType,MemberNo" +
                  $",AvonOldEnrolleId, PremiumType,Name,SurName, FirstName, MiddleName" +
                  $",Gender, Relation, MaritalStatus, DOB, Country, State, City, Address" +
                  $",SBU , EnrollmentDate , PrimaryProviderNo , PrimaryProviderName, MemberExpirydate " +
                  $",StaffID, EMAIL, MobileNo , CapitatedMember, CapitationRate " +
              $"FROM vw_MemberMasterView  WHERE plantype = 'AVON STAFF PLAN' AND MemberType='EMPLOYEE' ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<AllHmoMemberMasterViewModel>();

            return new PagedResponse<AllHmoMemberMasterViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };


        }




        /// <summary>
        /// Returns all HMO Member Master By Primary Provider No
        /// </summary>
        /// <returns>HMO Member Master</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 11-11-2021 10:13AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberMasterViewModel>> FetchAllMemberMasterByPrimaryProviderNo(PagingParam param, int prim_prov_no)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_MemberMasterView where PrimaryProviderNo = {prim_prov_no};" +
                $"SELECT * FROM vw_MemberMasterView where PrimaryProviderNo = {prim_prov_no} ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMemberMasterViewModel>();

            return new PagedResponse<HmoMemberMasterViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT PolicyNo,ClientName,[Policy Inception] PolicyInception,[Policy Expiry] PolicyExpiry,PlanType," +
            //    "[Plan Type Category] PlanTypeCategory,MemberHeadNo,MemberType,MemberNo,AvonOldEnrolleId,PremiumType,Name,SurName,FirstName,MiddleName,Gender," +
            //    "Relation,MaritalStatus,DOB,Country,State,City,Address,SBU,EnrollmentDate,PrimaryProviderNo," +
            //    "PrimaryProviderName,MemberExpirydate,StaffID,EMAIL,MobileNo,CapitatedMember,CapitationRate" +
            //    " FROM dbo.vw_MemberMasterView";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberMasterViewModel>();
            #endregion
        }





        /// <summary>
        /// Returns all HMO Member Policy Limits Exhausted And Available
        /// </summary>
        /// <returns>HMO Member Policy Limits Exhausted And Available</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 04-11-2021 4:45AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberPolicyLimitsExhaustedAndAvailableViewModel>> FetchAllMemberPolicyLimitsExhaustedAndAvailable(PagingParam param)
        {

            var cmdText = "SELECT COUNT(*) FROM vw_MemberPolicyLimitsExhaustedAndAvailable;SELECT * FROM vw_MemberPolicyLimitsExhaustedAndAvailable ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMemberPolicyLimitsExhaustedAndAvailableViewModel>();

            return new PagedResponse<HmoMemberPolicyLimitsExhaustedAndAvailableViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT Sno,Policyno,FRomDate,ClassCode,MemberNo,Limits,[Policy Limit] PolicyLimit," +
            //            "[Approved In LC] ApprovedInLC, [Claimed In LC] ClaimedInLC,Exhausted,Available" +
            //            " FROM dbo.vw_MemberPolicyLimitsExhaustedAndAvailable";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberPolicyLimitsExhaustedAndAvailableViewModel>();
            #endregion
        }




        /// <summary>
        /// Returns all HMO Member Policy Limits Exhausted And Available By Member No
        /// </summary>
        /// <returns>HMO Member Policy Limits Exhausted And Available By Member No</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 8:31AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberPolicyLimitsExhaustedAndAvailableViewModel>> FetchAllMemberPolicyLimitsExhaustedAndAvailableByMemberNo(PagingParam param, int member_no)
        {

            var cmdText = $"SELECT COUNT(*) FROM vw_MemberPolicyLimitsExhaustedAndAvailable where MemberNo = {member_no} ;" +
                          $"SELECT * FROM vw_MemberPolicyLimitsExhaustedAndAvailable where MemberNo = {member_no} ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMemberPolicyLimitsExhaustedAndAvailableViewModel>();

            return new PagedResponse<HmoMemberPolicyLimitsExhaustedAndAvailableViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT Sno,Policyno,FRomDate,ClassCode,MemberNo,Limits,[Policy Limit] PolicyLimit," +
            //            "[Approved In LC] ApprovedInLC, [Claimed In LC] ClaimedInLC,Exhausted,Available" +
            //            " FROM dbo.vw_MemberPolicyLimitsExhaustedAndAvailable";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberPolicyLimitsExhaustedAndAvailableViewModel>();
            #endregion
        }





        /// <summary>
        /// Returns all HMO Member Policy Status
        /// </summary>
        /// <returns>HMO Member Policy Status</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 04-11-2021 5:11AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberPolicyStatusViewModel>> FetchAllMemberPolicyStatus(PagingParam param)
        {
            var cmdText = "SELECT COUNT(*) FROM vw_MemberPolicyStatus;SELECT * FROM vw_MemberPolicyStatus ORDER BY Memberno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMemberPolicyStatusViewModel>();

            return new PagedResponse<HmoMemberPolicyStatusViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            /*var query = "SELECT MemberNo,DOB,Sex,MemberheadNo,Firstname,MiddleName,SurName,Status," +
                         "ToshfaUniqueId,Policyno,Fromdate,Todate,EnrollmentDate,MemberExpirydate" +
                         " FROM dbo.vw_MemberPolicyStatus";

            var sprocContext = _context.LoadSqlQuery(query);
            return await sprocContext.ExecuteStoreProcedure<HmoMemberPolicyStatusViewModel>();
            */
            #endregion
        }

        /// Returns List of Total Premium Per Client And Retail
        /// </summary>
        /// <returns>Total Premium Per Client And Retail</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<TotalPremiumPerClientAndRetailViewModel>> FetchAllTotalPremiumPerClientAndRetail(PagingParam param)
        {
            var cmdText = $"SELECT COUNT([PolicyNo]) FROM [dbo].[vw_TotalPremiumPerClientAndRetail];" +
                          $"SELECT  [ClientName],[PolicyNo],[FromDate],[MemberNo],[MemberHeadNo],[EnrollmentDate],[Name],[PlanType]," +
                          $"[Plan Type Category] As PlanTypeCategory,[PolicyPlanType],[PolicyType],[PaidDate],[SBU],[AgentId],[AgentName]  " +
                          $"FROM [dbo].[vw_TotalPremiumPerClientAndRetail] " +
                          $"ORDER BY [PolicyNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<TotalPremiumPerClientAndRetailViewModel>();
            return new PagedResponse<TotalPremiumPerClientAndRetailViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Returns List of Total Premium Per Client And Retail By Member No
        /// </summary>
        /// <returns> Total Premium Per Client And Retail </returns>
        ///  <param name="member_no">Member No</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<TotalPremiumPerClientAndRetailViewModel>> FetchTotalPremiumPerClientAndRetailByMemberNo(int member_no, PagingParam param)
        {
            var cmdText = $"SELECT COUNT([PolicyNo]) FROM [dbo].[vw_TotalPremiumPerClientAndRetail] Where [MemberNo]='{member_no}';" +
                          $"SELECT  [ClientName],[PolicyNo],[FromDate],[MemberNo],[MemberHeadNo],[EnrollmentDate],[Name],[PlanType]," +
                          $"[Plan Type Category] As PlanTypeCategory,[PolicyPlanType],[PolicyType],[PaidDate],[SBU],[AgentId],[AgentName]  " +
                          $"FROM [dbo].[vw_TotalPremiumPerClientAndRetail] " +
                          $"Where [MemberNo]='{member_no}' ORDER BY [PolicyNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<TotalPremiumPerClientAndRetailViewModel>();
            return new PagedResponse<TotalPremiumPerClientAndRetailViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

        }

        /// <summary>
        /// Returns List of Total Premium Per Client And Retail By Member No
        /// </summary>
        /// <returns> Total Premium Per Client And Retail </returns>
        ///  <param name="policy_no">Member No</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<TotalPremiumPerClientAndRetailViewModel>> FetchTotalPremiumPerClientAndRetailByPolicyNo(int policy_no, PagingParam param)
        {

            var cmdText = $"SELECT COUNT([PolicyNo]) FROM [dbo].[vw_TotalPremiumPerClientAndRetail] Where [PolicyNo]='{policy_no}';" +
                         $"SELECT  [ClientName],[PolicyNo],[FromDate],[MemberNo],[MemberHeadNo],[EnrollmentDate],[Name],[PlanType]," +
                         $"[Plan Type Category] As PlanTypeCategory,[PolicyPlanType],[PolicyType],[PaidDate],[SBU],[AgentId],[AgentName]  " +
                         $"FROM [dbo].[vw_TotalPremiumPerClientAndRetail] " +
                         $"Where [PolicyNo]='{policy_no}' ORDER BY [PolicyNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<TotalPremiumPerClientAndRetailViewModel>();
            return new PagedResponse<TotalPremiumPerClientAndRetailViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };


        }


        /// <summary>
        /// Returns List of CCA
        /// </summary>
        /// <returns>CCA</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<CCAViewModel>> FetchAllCCA(PagingParam param)
        {
            var cmdText = $"SELECT COUNT([MemberNo]) FROM [dbo].[CCA_View];" +
                          $"SELECT * " +
                          $"FROM [dbo].[CCA_View] " +
                          $"ORDER BY [MemberNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<CCAViewModel>();
            return new PagedResponse<CCAViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Returns List of CCA By Member No
        /// </summary>
        /// <returns> CCA </returns>
        ///  <param name="member_no">Member No</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<CCAViewModel>> FetchCCAByMemberNo(int member_no, PagingParam param)
        {
            var cmdText = $"SELECT COUNT([MemberNo]) FROM [dbo].[CCA_View] Where [MemberNo]='{member_no}';" +
                          $"SELECT * " +
                          $"FROM [dbo].[CCA_View] Where [MemberNo]='{member_no}' " +
                          $"ORDER BY [MemberNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<CCAViewModel>();
            return new PagedResponse<CCAViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

        }

        /// <summary>
        /// Returns List of CCA By Policy No
        /// </summary>
        /// <returns> CCA </returns>
        ///  <param name="policy_no">Member No</param>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<CCAViewModel>> FetchCCAByPolicyNo(int policy_no, PagingParam param)
        {
            var cmdText = $"SELECT COUNT([MemberNo]) FROM [dbo].[CCA_View] Where [PolicyNo]='{policy_no}';" +
                         $"SELECT * " +
                         $"FROM [dbo].[CCA_View] Where [PolicyNo]='{policy_no}' " +
                         $"ORDER BY [MemberNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<CCAViewModel>();
            return new PagedResponse<CCAViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

        }



        /// <summary>
        /// Returns all HMO Members List
        /// </summary>
        /// <returns>HMO Members List</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 04-11-2021 3:15PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMembersListViewModel>> FetchAllMembersList(PagingParam param)
        {
            var cmdText = "SELECT COUNT(*) FROM vw_MembersList;SELECT * FROM vw_MembersList ORDER BY Memberno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMembersListViewModel>();

            return new PagedResponse<HmoMembersListViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT [MemberNo],[MemberName],[StaffId],[Age],[Sex],[PolicyName],[PlanName],[MemberType]," +
            //            "[PremiumType],[Status],[PolicyNo],[Fromdate],[Todate],[DebitNoteGenerated]" +
            //            " FROM [dbo].[vw_MembersList]";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMembersListViewModel>();
            #endregion
        }


        /// <summary>
        /// Returns all HMO Members List By MemberNo
        /// </summary>
        /// <returns>HMO Members List By MemberNo</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 8:48AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMembersListViewModel>> FetchAllMembersListByMemberNo(PagingParam param, int member_no)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_MembersList where MemberNo = {member_no} ;" +
                          $"SELECT * FROM vw_MembersList where MemberNo = {member_no} ORDER BY Memberno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMembersListViewModel>();

            return new PagedResponse<HmoMembersListViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT [MemberNo],[MemberName],[StaffId],[Age],[Sex],[PolicyName],[PlanName],[MemberType]," +
            //            "[PremiumType],[Status],[PolicyNo],[Fromdate],[Todate],[DebitNoteGenerated]" +
            //            " FROM [dbo].[vw_MembersList]";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMembersListViewModel>();
            #endregion
        }


        /// <summary>
        /// Returns all HMO Member Status
        /// </summary>
        /// <returns>HMO Members Status</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 04-11-2021 3:35PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberStatusViewModel>> FetchAllMemberStatus(PagingParam param)
        {

            var cmdText = "SELECT COUNT(*) FROM vw_MemberStatus;SELECT * FROM vw_MemberStatus ORDER BY Memberno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMemberStatusViewModel>();

            return new PagedResponse<HmoMemberStatusViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            /*
            var query = "SELECT [Memberno],[MemberStatus],[MemberStatusDate],[PolicyName],[Policyno]," +
                        "[PolicyStartDate],[PolicyEndDate],[PolicyStatus],[PolicyStatusDate]" +
                        " FROM [dbo].[vw_MemberStatus]";

            var sprocContext = _context.LoadSqlQuery(query);
            return await sprocContext.ExecuteStoreProcedure<HmoMemberStatusViewModel>();
            */
            #endregion
        }



        /// <summary>
        /// Returns all HMO Member Wise Premium Details
        /// </summary>
        /// <returns>HMO Members Wise Premium Details</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 04-11-2021 3:50PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberWisePremiumDtlsViewModel>> FetchAllMemberWisePremiumDtls(PagingParam param)
        {
            var cmdText = "SELECT COUNT(*) FROM vw_MemberWisePremiumDtls;SELECT * FROM vw_MemberWisePremiumDtls ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMemberWisePremiumDtlsViewModel>();

            return new PagedResponse<HmoMemberWisePremiumDtlsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT ClientName,PolicyNo,Inception,Expiry,PlanType,PolicyPlanType,PolicyType," +
            //            "PlanCode,MemberNo,Name,Gender,DOB,Address,SBU,Country," +
            //            "StateName,Town," +
            //            "MemberType,MemberHeadNo,HeadMember,AgentId,AgentName,EnrollmentDate," +
            //            "CardPrintDate,CardProcessDate,MemberRelation,PaidDate" +
            //            " FROM dbo.vw_MemberWisePremiumDtls";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberWisePremiumDtlsViewModel>();
            #endregion
        }



        /// <summary>
        /// Returns all HMO Member Wise Premium Details by Policy No
        /// </summary>
        /// <returns>HMO Members Wise Premium Detailsnby Policy No</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 1:06PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMemberWisePremiumDtlsViewModel>> FetchAllMemberWisePremiumDtlsByPolicyNo(PagingParam param, int policy_no)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_MemberWisePremiumDtls where PolicyNo = {policy_no} ;" +
                          $"SELECT * FROM vw_MemberWisePremiumDtls where PolicyNo = {policy_no}  ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMemberWisePremiumDtlsViewModel>();

            return new PagedResponse<HmoMemberWisePremiumDtlsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT ClientName,PolicyNo,Inception,Expiry,PlanType,PolicyPlanType,PolicyType," +
            //            "PlanCode,MemberNo,Name,Gender,DOB,Address,SBU,Country," +
            //            "StateName,Town," +
            //            "MemberType,MemberHeadNo,HeadMember,AgentId,AgentName,EnrollmentDate," +
            //            "CardPrintDate,CardProcessDate,MemberRelation,PaidDate" +
            //            " FROM dbo.vw_MemberWisePremiumDtls";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoMemberWisePremiumDtlsViewModel>();
            #endregion
        }


        /// <summary>
        /// Returns all HMO Missing Services Details Approval
        /// </summary>
        /// <returns>HMO Missing Services Details Approval</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 04-11-2021 4:10PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMissingServicesDetailsApprovalViewModel>> FetchAllMissingServicesDetailsApproval(PagingParam param)
        {

            var cmdText = "SELECT COUNT(*) FROM vw_MissingServicesDetailsApproval;SELECT * FROM vw_MissingServicesDetailsApproval ORDER BY RequestNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMissingServicesDetailsApprovalViewModel>();

            return new PagedResponse<HmoMissingServicesDetailsApprovalViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            /*var query = "SELECT RequestNo,ProviderNo,ProviderName,AvonPaCode,ReceivedDate,ApprovalDate," +
                          "[OPD/IPD] OPDIPD,ClaimStatus,PolicyNo,FromDate,MemberNo,FirstName,MiddleName," +
                          "SurName,DOB,Gender,Relation,MobileNo,AvonMemberNo,ClassCode,PlanName," +
                          "PremiumType,ProviderManager,PrimaryHospNo,ApprovalType,Benefits,Diagnosis," +
                          "Case_UtilizationManager,ServiceType,Speciality,LGA,ProviderCity,ApproveRejectCloseNotes," +
                          "ProviderManagerRemarks,PrimaryCareProvider,PARequired,NoOfUnits,UnitCost,SBUName," +
                          "TotalToshfaAmount,NegotiatedAmount,[Modified Amount] ModifiedAmount," +
                          "ServiceNotFoundDescription,ServiceNotFoundAmount,[PA Approval Amount] PAApprovalAmount," +
                          "MissingServiceRemarks,State,City,ClientName,[PA Issued By] PAIssuedBy,DecisionBy,Notes" +
                          " FROM dbo.vw_MissingServicesDetailsApproval";

            var sprocContext = _context.LoadSqlQuery(query);
            return await sprocContext.ExecuteStoreProcedure<HmoMissingServicesDetailsApprovalViewModel>();
            */
            #endregion
        }



        /// <summary>
        /// Returns all HMO Missing Services Details Approval By Request No
        /// </summary>
        /// <returns>HMO Missing Services Details Approval By Request No</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 1:25PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMissingServicesDetailsApprovalViewModel>> FetchAllMissingServicesDetailsApprovalByRequestNo(PagingParam param, int request_no)
        {

            var cmdText = $"SELECT COUNT(*) FROM vw_MissingServicesDetailsApproval where RequestNo = {request_no};" +
                          $"SELECT * FROM vw_MissingServicesDetailsApproval where RequestNo = {request_no} ORDER BY RequestNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMissingServicesDetailsApprovalViewModel>();

            return new PagedResponse<HmoMissingServicesDetailsApprovalViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            /*var query = "SELECT RequestNo,ProviderNo,ProviderName,AvonPaCode,ReceivedDate,ApprovalDate," +
                          "[OPD/IPD] OPDIPD,ClaimStatus,PolicyNo,FromDate,MemberNo,FirstName,MiddleName," +
                          "SurName,DOB,Gender,Relation,MobileNo,AvonMemberNo,ClassCode,PlanName," +
                          "PremiumType,ProviderManager,PrimaryHospNo,ApprovalType,Benefits,Diagnosis," +
                          "Case_UtilizationManager,ServiceType,Speciality,LGA,ProviderCity,ApproveRejectCloseNotes," +
                          "ProviderManagerRemarks,PrimaryCareProvider,PARequired,NoOfUnits,UnitCost,SBUName," +
                          "TotalToshfaAmount,NegotiatedAmount,[Modified Amount] ModifiedAmount," +
                          "ServiceNotFoundDescription,ServiceNotFoundAmount,[PA Approval Amount] PAApprovalAmount," +
                          "MissingServiceRemarks,State,City,ClientName,[PA Issued By] PAIssuedBy,DecisionBy,Notes" +
                          " FROM dbo.vw_MissingServicesDetailsApproval";

            var sprocContext = _context.LoadSqlQuery(query);
            return await sprocContext.ExecuteStoreProcedure<HmoMissingServicesDetailsApprovalViewModel>();
            */
            #endregion
        }



        /// <summary>
        /// Returns all HMO Missing Services Details Approval By Provider No
        /// </summary>
        /// <returns>HMO Missing Services Details Approval By Provider No</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 1:29PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMissingServicesDetailsApprovalViewModel>> FetchAllMissingServicesDetailsApprovalByProviderNo(PagingParam param, int provider_no)
        {

            var cmdText = $"SELECT COUNT(*) FROM vw_MissingServicesDetailsApproval where ProviderNo = {provider_no};" +
                          $"SELECT * FROM vw_MissingServicesDetailsApproval where ProviderNo = {provider_no} ORDER BY RequestNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMissingServicesDetailsApprovalViewModel>();

            return new PagedResponse<HmoMissingServicesDetailsApprovalViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            /*var query = "SELECT RequestNo,ProviderNo,ProviderName,AvonPaCode,ReceivedDate,ApprovalDate," +
                          "[OPD/IPD] OPDIPD,ClaimStatus,PolicyNo,FromDate,MemberNo,FirstName,MiddleName," +
                          "SurName,DOB,Gender,Relation,MobileNo,AvonMemberNo,ClassCode,PlanName," +
                          "PremiumType,ProviderManager,PrimaryHospNo,ApprovalType,Benefits,Diagnosis," +
                          "Case_UtilizationManager,ServiceType,Speciality,LGA,ProviderCity,ApproveRejectCloseNotes," +
                          "ProviderManagerRemarks,PrimaryCareProvider,PARequired,NoOfUnits,UnitCost,SBUName," +
                          "TotalToshfaAmount,NegotiatedAmount,[Modified Amount] ModifiedAmount," +
                          "ServiceNotFoundDescription,ServiceNotFoundAmount,[PA Approval Amount] PAApprovalAmount," +
                          "MissingServiceRemarks,State,City,ClientName,[PA Issued By] PAIssuedBy,DecisionBy,Notes" +
                          " FROM dbo.vw_MissingServicesDetailsApproval";

            var sprocContext = _context.LoadSqlQuery(query);
            return await sprocContext.ExecuteStoreProcedure<HmoMissingServicesDetailsApprovalViewModel>();
            */
            #endregion
        }



        /// <summary>
        /// Returns all HMO Missing Services Details Approval By Policy No
        /// </summary>
        /// <returns>HMO Missing Services Details Approval By Policy No</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 1:30PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMissingServicesDetailsApprovalViewModel>> FetchAllMissingServicesDetailsApprovalByPolicyNo(PagingParam param, int policy_no)
        {

            var cmdText = $"SELECT COUNT(*) FROM vw_MissingServicesDetailsApproval where PolicyNo = {policy_no};" +
                          $"SELECT * FROM vw_MissingServicesDetailsApproval where PolicyNo = {policy_no} ORDER BY RequestNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMissingServicesDetailsApprovalViewModel>();

            return new PagedResponse<HmoMissingServicesDetailsApprovalViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            /*var query = "SELECT RequestNo,ProviderNo,ProviderName,AvonPaCode,ReceivedDate,ApprovalDate," +
                          "[OPD/IPD] OPDIPD,ClaimStatus,PolicyNo,FromDate,MemberNo,FirstName,MiddleName," +
                          "SurName,DOB,Gender,Relation,MobileNo,AvonMemberNo,ClassCode,PlanName," +
                          "PremiumType,ProviderManager,PrimaryHospNo,ApprovalType,Benefits,Diagnosis," +
                          "Case_UtilizationManager,ServiceType,Speciality,LGA,ProviderCity,ApproveRejectCloseNotes," +
                          "ProviderManagerRemarks,PrimaryCareProvider,PARequired,NoOfUnits,UnitCost,SBUName," +
                          "TotalToshfaAmount,NegotiatedAmount,[Modified Amount] ModifiedAmount," +
                          "ServiceNotFoundDescription,ServiceNotFoundAmount,[PA Approval Amount] PAApprovalAmount," +
                          "MissingServiceRemarks,State,City,ClientName,[PA Issued By] PAIssuedBy,DecisionBy,Notes" +
                          " FROM dbo.vw_MissingServicesDetailsApproval";

            var sprocContext = _context.LoadSqlQuery(query);
            return await sprocContext.ExecuteStoreProcedure<HmoMissingServicesDetailsApprovalViewModel>();
            */
            #endregion
        }



        /// <summary>
        /// Returns all HMO Missing Services Details Approval By AvonPaCode
        /// </summary>
        /// <returns>HMO Missing Services Details Approval By AvonPaCode</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 1:35PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoMissingServicesDetailsApprovalViewModel>> FetchAllMissingServicesDetailsApprovalByAvonPaCode(PagingParam param, string avon_pa_code)
        {

            var cmdText = $"SELECT COUNT(*) FROM vw_MissingServicesDetailsApproval where AvonPaCode = '{avon_pa_code}';" +
                          $"SELECT * FROM vw_MissingServicesDetailsApproval where AvonPaCode = '{avon_pa_code}' ORDER BY RequestNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMissingServicesDetailsApprovalViewModel>();

            return new PagedResponse<HmoMissingServicesDetailsApprovalViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            /*var query = "SELECT RequestNo,ProviderNo,ProviderName,AvonPaCode,ReceivedDate,ApprovalDate," +
                          "[OPD/IPD] OPDIPD,ClaimStatus,PolicyNo,FromDate,MemberNo,FirstName,MiddleName," +
                          "SurName,DOB,Gender,Relation,MobileNo,AvonMemberNo,ClassCode,PlanName," +
                          "PremiumType,ProviderManager,PrimaryHospNo,ApprovalType,Benefits,Diagnosis," +
                          "Case_UtilizationManager,ServiceType,Speciality,LGA,ProviderCity,ApproveRejectCloseNotes," +
                          "ProviderManagerRemarks,PrimaryCareProvider,PARequired,NoOfUnits,UnitCost,SBUName," +
                          "TotalToshfaAmount,NegotiatedAmount,[Modified Amount] ModifiedAmount," +
                          "ServiceNotFoundDescription,ServiceNotFoundAmount,[PA Approval Amount] PAApprovalAmount," +
                          "MissingServiceRemarks,State,City,ClientName,[PA Issued By] PAIssuedBy,DecisionBy,Notes" +
                          " FROM dbo.vw_MissingServicesDetailsApproval";

            var sprocContext = _context.LoadSqlQuery(query);
            return await sprocContext.ExecuteStoreProcedure<HmoMissingServicesDetailsApprovalViewModel>();
            */
            #endregion
        }






        /// <summary>
        /// Returns all HMO Package Price List
        /// </summary>
        /// <returns>HMO Package Price List</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 04-11-2021 5:23PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPackagePriceListViewModel>> FetchAllPackagePriceList(PagingParam param)
        {

            var cmdText = "SELECT COUNT(*) FROM vw_PackagePriceList;SELECT * FROM vw_PackagePriceList ORDER BY ProviderNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPackagePriceListViewModel>();

            return new PagedResponse<HmoPackagePriceListViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT ProviderNo,ProviderName,ProviderType,Code,Description,Amount,Capitation," +
            //            "CPTCode,CPTDescription,PAApprove,PlanName,EffectiveFrom,TRANS_DATE" +
            //            " FROM dbo.vw_PackagePriceList";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPackagePriceListViewModel>();
            #endregion
        }





        /// <summary>
        /// Returns all HMO Package Price List By Provider No
        /// </summary>
        /// <returns>HMO Package Price List By Provider No</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 2:08PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPackagePriceListViewModel>> FetchAllPackagePriceListByProviderNo(PagingParam param, int provider_no)
        {

            var cmdText = $"SELECT COUNT(*) FROM vw_PackagePriceList where ProviderNo = {provider_no};" +
                          $"SELECT * FROM vw_PackagePriceList where ProviderNo = {provider_no} ORDER BY ProviderNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPackagePriceListViewModel>();

            return new PagedResponse<HmoPackagePriceListViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT ProviderNo,ProviderName,ProviderType,Code,Description,Amount,Capitation," +
            //            "CPTCode,CPTDescription,PAApprove,PlanName,EffectiveFrom,TRANS_DATE" +
            //            " FROM dbo.vw_PackagePriceList";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPackagePriceListViewModel>();
            #endregion
        }




        /// <summary>
        /// Returns all Plan Master Details Dental Exclusions
        /// </summary>
        /// <returns>HMO Plan Master Details Dental Exclusions</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 04-11-2021 5:37PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPlanMasterDetailsDentalExclusionsViewModel>> FetchAllPlanMasterDetailsDentalExclusions(PagingParam param)
        {
            var cmdText = "SELECT COUNT(*) FROM vw_PlanMasterDetailsDentalExclusions;SELECT * FROM vw_PlanMasterDetailsDentalExclusions ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPlanMasterDetailsDentalExclusionsViewModel>();

            return new PagedResponse<HmoPlanMasterDetailsDentalExclusionsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT PolicyNo,PolicyName,FromDate,ToDate,ClassCode,ClassName,Code,Description" +
            //            " FROM dbo.vw_PlanMasterDetailsDentalExclusions";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPlanMasterDetailsDentalExclusionsViewModel>();
            #endregion
        }





        /// <summary>
        /// Returns all Plan Master Details Dental Exclusions By PolicyNo
        /// </summary>
        /// <returns>HMO Plan Master Details Dental Exclusions By PolicyNo</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 2:27PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPlanMasterDetailsDentalExclusionsViewModel>> FetchAllPlanMasterDetailsDentalExclusionsByPolicyNo(PagingParam param, int policy_no)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_PlanMasterDetailsDentalExclusions where PolicyNo = {policy_no};" +
                          $"SELECT * FROM vw_PlanMasterDetailsDentalExclusions where PolicyNo = {policy_no} ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPlanMasterDetailsDentalExclusionsViewModel>();

            return new PagedResponse<HmoPlanMasterDetailsDentalExclusionsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT PolicyNo,PolicyName,FromDate,ToDate,ClassCode,ClassName,Code,Description" +
            //            " FROM dbo.vw_PlanMasterDetailsDentalExclusions";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPlanMasterDetailsDentalExclusionsViewModel>();
            #endregion
        }




        /// <summary>
        /// Returns all Plan Master Details Dental Inclusions 
        /// </summary>
        /// <returns>HMO Plan Master Details Dental Inclusions</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 04-11-2021 5:50PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPlanMasterDetailsDentalInclusionsViewModel>> FetchAllPlanMasterDetailsDentalInclusions(PagingParam param)
        {

            var cmdText = "SELECT COUNT(*) FROM vw_PlanMasterDetailsDentalInclusions;SELECT * FROM vw_PlanMasterDetailsDentalInclusions ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPlanMasterDetailsDentalInclusionsViewModel>();

            return new PagedResponse<HmoPlanMasterDetailsDentalInclusionsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT PolicyNo, PolicyName, FromDate, ToDate, ClassCode, ClassName, Code, Description" +
            //            " FROM dbo.vw_PlanMasterDetailsDentalInclusions";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPlanMasterDetailsDentalInclusionsViewModel>();
            #endregion
        }





        /// <summary>
        /// Returns all Plan Master Details Dental Inclusions By PolicyNo
        /// </summary>
        /// <returns>HMO Plan Master Details Dental Inclusions By PolicyNo</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 2:36PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPlanMasterDetailsDentalInclusionsViewModel>> FetchAllPlanMasterDetailsDentalInclusionsByPolicyNo(PagingParam param, int policy_no)
        {

            var cmdText = $"SELECT COUNT(*) FROM vw_PlanMasterDetailsDentalInclusions where PolicyNo = {policy_no} ;" +
                          $"SELECT * FROM vw_PlanMasterDetailsDentalInclusions where PolicyNo = {policy_no} ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPlanMasterDetailsDentalInclusionsViewModel>();

            return new PagedResponse<HmoPlanMasterDetailsDentalInclusionsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT PolicyNo, PolicyName, FromDate, ToDate, ClassCode, ClassName, Code, Description" +
            //            " FROM dbo.vw_PlanMasterDetailsDentalInclusions";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPlanMasterDetailsDentalInclusionsViewModel>();
            #endregion
        }




        /// <summary>
        /// Returns all Plan Master Details Dental SubLimit
        /// </summary>
        /// <returns>HMO Plan Master Details Dental SubLimit</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 04-11-2021 6:10PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<PlanMasterDetailsDentalSubLimitViewModel>> FetchAllPlanMasterDetailsDentalSubLimit(PagingParam param)
        {

            var cmdText = "SELECT COUNT(*) FROM vw_PlanMasterDetailsDentalSubLimit;SELECT * FROM vw_PlanMasterDetailsDentalSubLimit ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<PlanMasterDetailsDentalSubLimitViewModel>();

            return new PagedResponse<PlanMasterDetailsDentalSubLimitViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT PolicyNo,PolicyName,FromDate,ToDate,ClassCode,ClassName," +
            //            "Code,Description,SubLimit,CoInsurance,TotalLimit,ListInMemberVerification" +
            //            " FROM dbo.vw_PlanMasterDetailsDentalSubLimit";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<PlanMasterDetailsDentalSubLimitViewModel>();
            #endregion
        }





        /// <summary>
        /// Returns all Plan Master Details Dental SubLimit By PolicyNo
        /// </summary>
        /// <returns>HMO Plan Master Details Dental SubLimit By PolicyNo </returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 2:49PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<PlanMasterDetailsDentalSubLimitViewModel>> FetchAllPlanMasterDetailsDentalSubLimitByPolicyNo(PagingParam param, int policy_no)
        {

            var cmdText = $"SELECT COUNT(*) FROM vw_PlanMasterDetailsDentalSubLimit where PolicyNo = {policy_no};" +
                          $"SELECT * FROM vw_PlanMasterDetailsDentalSubLimit where PolicyNo = {policy_no} ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<PlanMasterDetailsDentalSubLimitViewModel>();

            return new PagedResponse<PlanMasterDetailsDentalSubLimitViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT PolicyNo,PolicyName,FromDate,ToDate,ClassCode,ClassName," +
            //            "Code,Description,SubLimit,CoInsurance,TotalLimit,ListInMemberVerification" +
            //            " FROM dbo.vw_PlanMasterDetailsDentalSubLimit";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<PlanMasterDetailsDentalSubLimitViewModel>();
            #endregion
        }




        /// <summary>
        /// Returns all Plan Master Details Dental SubLimit By Code
        /// </summary>
        /// <returns>HMO Plan Master Details Dental SubLimit By Code </returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 2:50PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<PlanMasterDetailsDentalSubLimitViewModel>> FetchAllPlanMasterDetailsDentalSubLimitByCode(PagingParam param, string code)
        {

            var cmdText = $"SELECT COUNT(*) FROM vw_PlanMasterDetailsDentalSubLimit where Code = '{code}' ;" +
                          $"SELECT * FROM vw_PlanMasterDetailsDentalSubLimit where Code = '{code}' order BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<PlanMasterDetailsDentalSubLimitViewModel>();

            return new PagedResponse<PlanMasterDetailsDentalSubLimitViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT PolicyNo,PolicyName,FromDate,ToDate,ClassCode,ClassName," +
            //            "Code,Description,SubLimit,CoInsurance,TotalLimit,ListInMemberVerification" +
            //            " FROM dbo.vw_PlanMasterDetailsDentalSubLimit";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<PlanMasterDetailsDentalSubLimitViewModel>();
            #endregion
        }





        /// <summary>
        /// Returns all Plan Master Details ICD Exclusions
        /// </summary>
        /// <returns>HMO Plan Master Details ICD Exclusions</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 05-11-2021 2:11AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPlanMasterDetailsICDExclusionsViewModel>> FetchAllHmoPlanMasterDetailsICDExclusions(PagingParam param)
        {
            var cmdText = "SELECT COUNT(*) FROM vw_PlanMasterDetailsICDExclusions;SELECT * FROM vw_PlanMasterDetailsICDExclusions ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPlanMasterDetailsICDExclusionsViewModel>();

            return new PagedResponse<HmoPlanMasterDetailsICDExclusionsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT PolicyNo,PolicyName,FromDate,ToDate,ClassCode,ClassName,Code,Description" +
            //            " FROM dbo.vw_PlanMasterDetailsICDExclusions";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPlanMasterDetailsICDExclusionsViewModel>();
            #endregion
        }





        /// <summary>
        /// Returns all Plan Master Details ICD Exclusions By PolicyNo
        /// </summary>
        /// <returns>HMO Plan Master Details ICD Exclusions By PolicyNo</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 3:01PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPlanMasterDetailsICDExclusionsViewModel>> FetchAllHmoPlanMasterDetailsICDExclusionsByPolicyNo(PagingParam param, int policy_no)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_PlanMasterDetailsICDExclusions where PolicyNo = {policy_no} ;" +
                          $"SELECT * FROM vw_PlanMasterDetailsICDExclusions where PolicyNo = {policy_no} ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPlanMasterDetailsICDExclusionsViewModel>();

            return new PagedResponse<HmoPlanMasterDetailsICDExclusionsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT PolicyNo,PolicyName,FromDate,ToDate,ClassCode,ClassName,Code,Description" +
            //            " FROM dbo.vw_PlanMasterDetailsICDExclusions";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPlanMasterDetailsICDExclusionsViewModel>();
            #endregion
        }





        /// <summary>
        /// Returns all Plan Master Details ICD Exclusions By Code
        /// </summary>
        /// <returns>HMO Plan Master Details ICD Exclusions By Code</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 3:09PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPlanMasterDetailsICDExclusionsViewModel>> FetchAllHmoPlanMasterDetailsICDExclusionsByCode(PagingParam param, string code)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_PlanMasterDetailsICDExclusions where Code = '{code}' ;" +
                          $"SELECT * FROM vw_PlanMasterDetailsICDExclusions where Code = '{code}' ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPlanMasterDetailsICDExclusionsViewModel>();

            return new PagedResponse<HmoPlanMasterDetailsICDExclusionsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT PolicyNo,PolicyName,FromDate,ToDate,ClassCode,ClassName,Code,Description" +
            //            " FROM dbo.vw_PlanMasterDetailsICDExclusions";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPlanMasterDetailsICDExclusionsViewModel>();
            #endregion
        }






        /// <summary>
        /// Returns all Plan Master Details ICD Inclusions
        /// </summary>
        /// <returns>HMO Plan Master Details ICD Inclusions</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 2:31AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPlanMasterDetailsICDInclusionsViewModel>> FetchAllHmoPlanMasterDetailsICDInclusions(PagingParam param)
        {
            var cmdText = "SELECT COUNT(*) FROM vw_PlanMasterDetailsICDInclusions;SELECT * FROM vw_PlanMasterDetailsICDInclusions ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPlanMasterDetailsICDInclusionsViewModel>();

            return new PagedResponse<HmoPlanMasterDetailsICDInclusionsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
            #region
            //var query = "SELECT PolicyNo,PolicyName,FromDate,ToDate,ClassCode,ClassName,Code,Description" +
            //            " FROM dbo.vw_PlanMasterDetailsICDInclusions";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPlanMasterDetailsICDInclusionsViewModel>();
            #endregion
        }




        /// <summary>
        /// Returns all Plan Master Details ICD Inclusions By PolicyNo
        /// </summary>
        /// <returns>HMO Plan Master Details ICD Inclusions By PolicyNo</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 3:20PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPlanMasterDetailsICDInclusionsViewModel>> FetchAllHmoPlanMasterDetailsICDInclusionsByPolicyNo(PagingParam param, int policy_no)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_PlanMasterDetailsICDInclusions where PolicyNo = {policy_no};" +
                          $"SELECT * FROM vw_PlanMasterDetailsICDInclusions where PolicyNo = {policy_no} ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPlanMasterDetailsICDInclusionsViewModel>();

            return new PagedResponse<HmoPlanMasterDetailsICDInclusionsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
            #region
            //var query = "SELECT PolicyNo,PolicyName,FromDate,ToDate,ClassCode,ClassName,Code,Description" +
            //            " FROM dbo.vw_PlanMasterDetailsICDInclusions";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPlanMasterDetailsICDInclusionsViewModel>();
            #endregion
        }




        /// <summary>
        /// Returns all Plan Master Details ICD Inclusions By Code
        /// </summary>
        /// <returns>HMO Plan Master Details ICD Inclusions By Code</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 3:20PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPlanMasterDetailsICDInclusionsViewModel>> FetchAllHmoPlanMasterDetailsICDInclusionsByCode(PagingParam param, string code)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_PlanMasterDetailsICDInclusions where Code = '{code}';" +
                          $"SELECT * FROM vw_PlanMasterDetailsICDInclusions where Code = '{code}' ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPlanMasterDetailsICDInclusionsViewModel>();

            return new PagedResponse<HmoPlanMasterDetailsICDInclusionsViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
            #region
            //var query = "SELECT PolicyNo,PolicyName,FromDate,ToDate,ClassCode,ClassName,Code,Description" +
            //            " FROM dbo.vw_PlanMasterDetailsICDInclusions";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPlanMasterDetailsICDInclusionsViewModel>();
            #endregion
        }







        /// <summary>
        /// Returns all Plan Master Details Information
        /// </summary>
        /// <returns>HMO Plan Master Details Information</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 05-11-2021 2:53AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPlanMasterDetailsInformationViewModel>> FetchAllHmoPlanMasterDetailsInformation(PagingParam param)
        {

            var cmdText = "SELECT COUNT(*) FROM vw_PlanMasterDetailsInformation;SELECT * FROM vw_PlanMasterDetailsInformation ORDER BY GroupName OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPlanMasterDetailsInformationViewModel>();

            return new PagedResponse<HmoPlanMasterDetailsInformationViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query =   "SELECT GroupName,PolicyNo,PolicyName,ClassCode,ClassName,FromDate,ToDate,PlanType,TemplateCode,"+
            //              "TemplateName,PolicyPlanType,PlanCategoryCode,PlanCategoryName,AvonHMoPlanType,MinDpndsCovered," +
            //              "DaysCoveredPolExp,MaxEmpAge,MinEmpAge,MinSonAgeDays,MaxSonAgeYear,MinDaughterAgeDays,MaxDaughterAgeYear," +
            //              "SecondOpnionReq,PreExistAllow,ConginatalDeseaseAllow,PreExistMaternityAllow,MaternityWaitPeriod,PreExistDisSubLimitPerMem," +
            //              "PreExistDisClassAggrLimit,PreExistMaternityLimitperMem,PreExistClassAggrLimitForMaternity," +
            //              "ConginatalSubLimitPerMem,ConginatalClassAggrLimit,MaxConsultation,AggregrateAnnualLimitPerMem,BenefitType," +
            //              "[Primary],Secondary,Tertiary,Chronic,ANCAndDeliveryServices,Currency,Broker,Relation," +
            //              "BasicPremium,MaternityPremium,DentalPremium,OpticalPremium,VaccPremium,OtherPremium,TotalPremium" +
            //              " FROM dbo.vw_PlanMasterDetailsInformation";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPlanMasterDetailsInformationViewModel>();
            #endregion
        } //FetchAllHmoPlanMasterDetailsInformationByPolicyNo




        /// <summary>
        /// Returns all Plan Master Details Information by Policy No
        /// </summary>
        /// <returns>HMO Plan Master Details Information by Policy No</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 3:35PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPlanMasterDetailsInformationViewModel>> FetchAllHmoPlanMasterDetailsInformationByPolicyNo(PagingParam param, int policy_no)
        {

            var cmdText = $"SELECT COUNT(*) FROM vw_PlanMasterDetailsInformation where PolicyNo = {policy_no} ;" +
                          $"SELECT * FROM vw_PlanMasterDetailsInformation where PolicyNo = {policy_no} ORDER BY GroupName OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPlanMasterDetailsInformationViewModel>();

            return new PagedResponse<HmoPlanMasterDetailsInformationViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query =   "SELECT GroupName,PolicyNo,PolicyName,ClassCode,ClassName,FromDate,ToDate,PlanType,TemplateCode,"+
            //              "TemplateName,PolicyPlanType,PlanCategoryCode,PlanCategoryName,AvonHMoPlanType,MinDpndsCovered," +
            //              "DaysCoveredPolExp,MaxEmpAge,MinEmpAge,MinSonAgeDays,MaxSonAgeYear,MinDaughterAgeDays,MaxDaughterAgeYear," +
            //              "SecondOpnionReq,PreExistAllow,ConginatalDeseaseAllow,PreExistMaternityAllow,MaternityWaitPeriod,PreExistDisSubLimitPerMem," +
            //              "PreExistDisClassAggrLimit,PreExistMaternityLimitperMem,PreExistClassAggrLimitForMaternity," +
            //              "ConginatalSubLimitPerMem,ConginatalClassAggrLimit,MaxConsultation,AggregrateAnnualLimitPerMem,BenefitType," +
            //              "[Primary],Secondary,Tertiary,Chronic,ANCAndDeliveryServices,Currency,Broker,Relation," +
            //              "BasicPremium,MaternityPremium,DentalPremium,OpticalPremium,VaccPremium,OtherPremium,TotalPremium" +
            //              " FROM dbo.vw_PlanMasterDetailsInformation";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPlanMasterDetailsInformationViewModel>();
            #endregion
        }





        /// <summary>
        /// Returns all Plan Master Details Information byTemplate Code
        /// </summary>
        /// <returns>HMO Plan Master Details Information by Template Code</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 3:38PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPlanMasterDetailsInformationViewModel>> FetchAllHmoPlanMasterDetailsInformationByTemplateCode(PagingParam param, int temp_code)
        {

            var cmdText = $"SELECT COUNT(*) FROM vw_PlanMasterDetailsInformation where TemplateCode = {temp_code} ;" +
                          $"SELECT * FROM vw_PlanMasterDetailsInformation where TemplateCode = {temp_code} ORDER BY GroupName OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPlanMasterDetailsInformationViewModel>();

            return new PagedResponse<HmoPlanMasterDetailsInformationViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query =   "SELECT GroupName,PolicyNo,PolicyName,ClassCode,ClassName,FromDate,ToDate,PlanType,TemplateCode,"+
            //              "TemplateName,PolicyPlanType,PlanCategoryCode,PlanCategoryName,AvonHMoPlanType,MinDpndsCovered," +
            //              "DaysCoveredPolExp,MaxEmpAge,MinEmpAge,MinSonAgeDays,MaxSonAgeYear,MinDaughterAgeDays,MaxDaughterAgeYear," +
            //              "SecondOpnionReq,PreExistAllow,ConginatalDeseaseAllow,PreExistMaternityAllow,MaternityWaitPeriod,PreExistDisSubLimitPerMem," +
            //              "PreExistDisClassAggrLimit,PreExistMaternityLimitperMem,PreExistClassAggrLimitForMaternity," +
            //              "ConginatalSubLimitPerMem,ConginatalClassAggrLimit,MaxConsultation,AggregrateAnnualLimitPerMem,BenefitType," +
            //              "[Primary],Secondary,Tertiary,Chronic,ANCAndDeliveryServices,Currency,Broker,Relation," +
            //              "BasicPremium,MaternityPremium,DentalPremium,OpticalPremium,VaccPremium,OtherPremium,TotalPremium" +
            //              " FROM dbo.vw_PlanMasterDetailsInformation";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPlanMasterDetailsInformationViewModel>();
            #endregion
        }




        /// <summary>
        /// Returns all Plan Master Details Maternity SubLimit
        /// </summary>
        /// <returns>HMO Plan Master Details Maternity SubLimit</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 05-11-2021 3:18AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPlanMasterDetailsMaternitySubLimitViewModel>> FetchAllHmoPlanMasterDetailsMaternitySubLimit(PagingParam param)
        {
            var cmdText = "SELECT COUNT(*) FROM vw_PlanMasterDetailsMaternitySubLimit;SELECT * FROM vw_PlanMasterDetailsMaternitySubLimit ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPlanMasterDetailsMaternitySubLimitViewModel>();

            return new PagedResponse<HmoPlanMasterDetailsMaternitySubLimitViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT PolicyNo,PolicyName,FromDate,ToDate,ClassCode,ClassName," +
            //            "Code,Description,SubLimit,CoInsurance,TotalLimit,ListInMemberVerification" +
            //            " FROM dbo.vw_PlanMasterDetailsMaternitySubLimit";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPlanMasterDetailsMaternitySubLimitViewModel>();
            #endregion
        }




        /// <summary>
        /// Returns all Plan Master Details Maternity SubLimit By Policy No
        /// </summary>
        /// <returns>HMO Plan Master Details Maternity SubLimit By Policy No </returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 05-11-2021 3:58PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPlanMasterDetailsMaternitySubLimitViewModel>> FetchAllHmoPlanMasterDetailsMaternitySubLimitByPolicyNo(PagingParam param, int policy_no)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_PlanMasterDetailsMaternitySubLimit where PolicyNo = {policy_no} ;" +
                          $"SELECT * FROM vw_PlanMasterDetailsMaternitySubLimit where PolicyNo = {policy_no} ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPlanMasterDetailsMaternitySubLimitViewModel>();

            return new PagedResponse<HmoPlanMasterDetailsMaternitySubLimitViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT PolicyNo,PolicyName,FromDate,ToDate,ClassCode,ClassName," +
            //            "Code,Description,SubLimit,CoInsurance,TotalLimit,ListInMemberVerification" +
            //            " FROM dbo.vw_PlanMasterDetailsMaternitySubLimit";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPlanMasterDetailsMaternitySubLimitViewModel>();
            #endregion
        }





        /// <summary>
        /// Returns all Plan Master Details Maternity SubLimit By Code
        /// </summary>
        /// <returns>HMO Plan Master Details Maternity SubLimit By Code </returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 05-11-2021 3:58PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPlanMasterDetailsMaternitySubLimitViewModel>> FetchAllHmoPlanMasterDetailsMaternitySubLimitByCode(PagingParam param, string code)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_PlanMasterDetailsMaternitySubLimit where Code = '{code}' ;" +
                          $"SELECT * FROM vw_PlanMasterDetailsMaternitySubLimit where Code = '{code}' ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPlanMasterDetailsMaternitySubLimitViewModel>();

            return new PagedResponse<HmoPlanMasterDetailsMaternitySubLimitViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT PolicyNo,PolicyName,FromDate,ToDate,ClassCode,ClassName," +
            //            "Code,Description,SubLimit,CoInsurance,TotalLimit,ListInMemberVerification" +
            //            " FROM dbo.vw_PlanMasterDetailsMaternitySubLimit";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPlanMasterDetailsMaternitySubLimitViewModel>();
            #endregion
        }









        /// <summary>
        /// Returns all Plan Master Details Optical SubLimit
        /// </summary>
        /// <returns>HMO Plan Master Details Optical SubLimit</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 05-11-2021 3:39AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPlanMasterDetailsOpticalSubLimitViewModel>> FetchAllHmoPlanMasterDetailsOpticalSubLimit(PagingParam param)
        {
            var cmdText = "SELECT COUNT(*) FROM vw_PlanMasterDetailsOpticalSubLimit;SELECT * FROM vw_PlanMasterDetailsOpticalSubLimit ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPlanMasterDetailsOpticalSubLimitViewModel>();

            return new PagedResponse<HmoPlanMasterDetailsOpticalSubLimitViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT PolicyNo,PolicyName,FromDate,ToDate,ClassCode,ClassName," +
            //            "Code,Description,SubLimit,CoInsurance,TotalLimit,ListInMemberVerification" +
            //            " FROM dbo.vw_PlanMasterDetailsOpticalSubLimit";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPlanMasterDetailsOpticalSubLimitViewModel>();
            #endregion
        }





        /// <summary>
        /// Returns all Plan Master Details Optical SubLimit By Policy No
        /// </summary>
        /// <returns>HMO Plan Master Details Optical SubLimit By Policy No</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 4:13PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPlanMasterDetailsOpticalSubLimitViewModel>> FetchAllHmoPlanMasterDetailsOpticalSubLimitByPolicyNo(PagingParam param, int policy_no)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_PlanMasterDetailsOpticalSubLimit where PolicyNo = {policy_no};" +
                          $"SELECT * FROM vw_PlanMasterDetailsOpticalSubLimit where PolicyNo = {policy_no} ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPlanMasterDetailsOpticalSubLimitViewModel>();

            return new PagedResponse<HmoPlanMasterDetailsOpticalSubLimitViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT PolicyNo,PolicyName,FromDate,ToDate,ClassCode,ClassName," +
            //            "Code,Description,SubLimit,CoInsurance,TotalLimit,ListInMemberVerification" +
            //            " FROM dbo.vw_PlanMasterDetailsOpticalSubLimit";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPlanMasterDetailsOpticalSubLimitViewModel>();
            #endregion
        }






        /// <summary>
        /// Returns all Plan Master Details Optical SubLimit By Code
        /// </summary>
        /// <returns>HMO Plan Master Details Optical SubLimit By Code </returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 15-11-2021 4:15PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoPlanMasterDetailsOpticalSubLimitViewModel>> FetchAllHmoPlanMasterDetailsOpticalSubLimitByCode(PagingParam param, string code)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_PlanMasterDetailsOpticalSubLimit where Code = '{code}';" +
                          $"SELECT * FROM vw_PlanMasterDetailsOpticalSubLimit where Code = '{code}' ORDER BY PolicyNo OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoPlanMasterDetailsOpticalSubLimitViewModel>();

            return new PagedResponse<HmoPlanMasterDetailsOpticalSubLimitViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT PolicyNo,PolicyName,FromDate,ToDate,ClassCode,ClassName," +
            //            "Code,Description,SubLimit,CoInsurance,TotalLimit,ListInMemberVerification" +
            //            " FROM dbo.vw_PlanMasterDetailsOpticalSubLimit";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoPlanMasterDetailsOpticalSubLimitViewModel>();
            #endregion
        }





        /// <summary>
        /// Returns all Total Claims Per Health Plan
        /// </summary>
        /// <returns>HMO Total Claims Per Health Plan</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 05-11-2021 3:48AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoTotalClaimsPerHealthPlanViewModel>> FetchAllHmoTotalClaimsPerHealthPlan(PagingParam param)
        {

            var cmdText = "SELECT COUNT(*) FROM vw_TotalClaimsPerHealthPlan;SELECT * FROM vw_TotalClaimsPerHealthPlan ORDER BY ClientName OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoTotalClaimsPerHealthPlanViewModel>();

            return new PagedResponse<HmoTotalClaimsPerHealthPlanViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT ClientName,PolicyNo,FromDate,[Policy Inception] PolicyInception,MemberNo,MemberHeadNo,EnrollmentDate,Name," +
            //             "PlanType,[Plan Type Category] PlanTypeCategory,PAIDAMOUNT,ClaimNo,ClaimIncurredDate," +
            //             "ClaimReceivedDate,HOSPNO,HospitalName,SBU" +
            //             " FROM dbo.vw_TotalClaimsPerHealthPlan";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoTotalClaimsPerHealthPlanViewModel>();
            #endregion
        }



        /// <summary>
        /// Returns all Total Health Premium By Agent
        /// </summary>
        /// <returns>HMO Total Health Premium By Agent</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 05-11-2021 4:08AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoTotalHealthPremiumByAgentViewModel>> FetchAllHmoTotalHealthPremiumByAgent(PagingParam param)
        {
            var cmdText = "SELECT COUNT(*) FROM vw_TotalHealthPremiumByAgent;SELECT * FROM vw_TotalHealthPremiumByAgent ORDER BY ClientName OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoTotalHealthPremiumByAgentViewModel>();

            return new PagedResponse<HmoTotalHealthPremiumByAgentViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT ClientName,PolicyNo,FromDate,MemberNo,MemberHeadNo,EnrollmentDate,Name,PlanType," +
            //             "[Plan Type Category] PlanTypeCategory,PaidDate,SBU,AgentId,AgentName,State,City,Address,Gender,DOB" +
            //             " FROM dbo.vw_TotalHealthPremiumByAgent";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoTotalHealthPremiumByAgentViewModel>();
            #endregion
        }




        /// <summary>
        /// Returns all Total Health Premium By Agent By Policy No
        /// </summary>
        /// <returns>HMO Total Health Premium By Agent</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 07-11-2021 5:18PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoTotalHealthPremiumByAgentViewModel>> FetchAllHmoTotalHealthPremiumByAgentByPolicyNo(PagingParam param, int policy_no)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_TotalHealthPremiumByAgent where PolicyNo = {policy_no} ;SELECT * FROM vw_TotalHealthPremiumByAgent where PolicyNo = {policy_no} ORDER BY ClientName OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoTotalHealthPremiumByAgentViewModel>();

            return new PagedResponse<HmoTotalHealthPremiumByAgentViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT ClientName,PolicyNo,FromDate,MemberNo,MemberHeadNo,EnrollmentDate,Name,PlanType," +
            //             "[Plan Type Category] PlanTypeCategory,PaidDate,SBU,AgentId,AgentName,State,City,Address,Gender,DOB" +
            //             " FROM dbo.vw_TotalHealthPremiumByAgent";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoTotalHealthPremiumByAgentViewModel>();
            #endregion
        }




        /// <summary>
        /// Returns all Total Health Premium By Agent By Member No
        /// </summary>
        /// <returns>HMO Total Health Premium By Agent By Member No</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 07-11-2021 5:18PM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoTotalHealthPremiumByAgentViewModel>> FetchAllHmoTotalHealthPremiumByAgentByMemberNo(PagingParam param, int member_no)
        {
            var cmdText = $"SELECT COUNT(*) FROM vw_TotalHealthPremiumByAgent where MemberNo = {member_no} ;SELECT * FROM vw_TotalHealthPremiumByAgent where MemberNo = {member_no} ORDER BY ClientName OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoTotalHealthPremiumByAgentViewModel>();

            return new PagedResponse<HmoTotalHealthPremiumByAgentViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT ClientName,PolicyNo,FromDate,MemberNo,MemberHeadNo,EnrollmentDate,Name,PlanType," +
            //             "[Plan Type Category] PlanTypeCategory,PaidDate,SBU,AgentId,AgentName,State,City,Address,Gender,DOB" +
            //             " FROM dbo.vw_TotalHealthPremiumByAgent";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoTotalHealthPremiumByAgentViewModel>();
            #endregion
        }




        /// <summary>
        /// Returns all Total Premium
        /// </summary>
        /// <returns>HMO Total Premium</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 05-11-2021 4:25AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoTotalPremiumViewModel>> FetchAllHmoTotalPremium(PagingParam param)
        {

            var cmdText = "SELECT COUNT(*) FROM vw_TotalPremium;SELECT * FROM vw_TotalPremium ORDER BY ClientName OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoTotalPremiumViewModel>();

            return new PagedResponse<HmoTotalPremiumViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT ClientName,PolicyNo,FromDate,MemberNo,MemberHeadNo,EnrollmentDate,Name,PlanType," +
            //             "[Plan Type Category] PlanTypeCategory,PaidDate,SBU,AgentId,AgentName,State,City,Address,Gender,DOB" +
            //             " FROM dbo.vw_TotalHealthPremiumByAgent";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoTotalPremiumViewModel>();
            #endregion
        }




        /// <summary>
        /// Returns all Total Premium Per Health Plan
        /// </summary>
        /// <returns>HMO Total Premium Per Health Plan</returns>
        /// <remarks>
        /// Author ::  George Coker
        /// Created :: George Coker 05-11-2021 4:39AM
        /// Updated :: 
        /// </remarks>
        public async Task<PagedResponse<HmoTotalPremiumPerHealthPlanViewModel>> FetchAllHmoTotalPremiumPerHealthPlan(PagingParam param)
        {

            var cmdText = "SELECT COUNT(*) FROM vw_TotalPremiumPerHealthPlan;SELECT * FROM vw_TotalPremiumPerHealthPlan ORDER BY ClientName OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoTotalPremiumPerHealthPlanViewModel>();

            return new PagedResponse<HmoTotalPremiumPerHealthPlanViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

            #region
            //var query = "SELECT ClientName,PolicyNo,FromDate,MemberNo,MemberHeadNo,EnrollmentDate,Name," +
            //            "PlanType,[Plan Type Category] PlanTypeCategory,PaidDate,SBU,AgentId,AgentName" +
            //            " FROM dbo.vw_TotalPremiumPerHealthPlan";

            //var sprocContext = _context.LoadSqlQuery(query);
            //return await sprocContext.ExecuteStoreProcedure<HmoTotalPremiumPerHealthPlanViewModel>();
            #endregion
        }
        /// Returns List of Supply Lists
        /// </summary>
        /// <returns>Supply Lists</returns>
        /// <remarks>
        /// Author :: Akintunde Toba
        /// Created :: Akintunde Toba 04-11-2021 4:00PM
        /// </remarks>
        public async Task<PagedResponse<SupplyListViewModel>> FetchSupplyLists(PagingParam param)
        {
            var cmdText = $"SELECT COUNT([MemberNo]) FROM [dbo].[SupplyList];" +
                          $"SELECT * " +
                          $"FROM [dbo].[SupplyList] " +
                          $"ORDER BY [MemberNo] OFFSET((@PageNumber -1) *@NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });
            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<SupplyListViewModel>();
            return new PagedResponse<SupplyListViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };

        }

        public async Task<CurrentPlanDetail> GetCurrendEnrollePlan(string enrolleeNumber)
        {

            var dbname = _connection.Database;
            var cmdText = @"select top 1 MemMst.MemberExpirydate,MemMst.MemberNo,
                           MemMst.PlanType,MemMst.[Plan Type Category] as planTypeCategory, MemMst.plancode,
                           plt.TotalPremium,plt.BasicPremium,plt.MaternityPremium,  
                           plt.DentalPremium,plt.OpticalPremium, plt.VaccPremium, plt.OtherPremium,
                           plt.MaxConsultation,plt.MaxDaughterAgeYear,
                           plt.MinSonAgeDays, plt.MaxSonAgeYear, plt.MinSonAgeDays , plt.MinDpndsCovered as DependantsCovered, plt.MaxEmpAge as maxAge
                           from [dbo].[vw_MemberMasterView] MemMst
                           inner join [dbo].[vw_PlanTemplateMaster] as plt on MemMst.PlanType = plt.ClassName
                           where MemMst.MemberNo=@enrolleeNumber";
            try
            {
                var plan = await _connection.QueryAsync<CurrentPlanDetail>(cmdText, new { enrolleeNumber = enrolleeNumber, dbName = dbname });
                return plan.FirstOrDefault();
            }
            catch
            {

                throw;
            }

        }
        public async Task<HmoMemberMasterViewModel> GetEnrollePlan(int enrolleeNumber)
        {
            var cmdText = "Select * from vw_MemberMasterView where MemberNo=@enrolleeNumber";
            try
            {
                var plan = await _connection.QueryAsync<HmoMemberMasterViewModel>(cmdText, new { enrolleeNumber = enrolleeNumber });

                return plan.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<PagedResponse<HmoMemberMasterViewModel>> FetchAllEnrolleeDependants(PagingParam param, int enrolleeNumber)
        {
            var cmdText = $"SELECT COUNT(PolicyNo) FROM vw_MemberMasterView WHERE MemberHeadNo={enrolleeNumber};" +
                $"SELECT * FROM vw_MemberMasterView WHERE MemberHeadNo={enrolleeNumber} ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";
            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<HmoMemberMasterViewModel>();

            return new PagedResponse<HmoMemberMasterViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        public async Task<List<CurrencyViewModel>> FecthCurrencies()
        {
            var cmdText = "SELECT CurrCode, [Description] FROM tblCurrency";

            var query = await _connection.QueryAsync<CurrencyViewModel>(cmdText);


            return query.ToList();
        }


        ///To be added to the Interface

        public async Task<PagedResponse<EnrolleeMasterViewModel>> FetchAllEnrolleeMasterRecord(PagingParam param)
        {
            var cmdText = $"SELECT COUNT(PolicyNo) FROM vw_MemberMasterView;SELECT PolicyNo, ClientName,[Policy Inception] PolicyInception,[Policy Expiry] PolicyExpiry,PlanType," +
                  $"[Plan Type Category] PlanTypeCategory,MemberHeadNo,MemberType,MemberNo" +
                  $",AvonOldEnrolleId, PremiumType,Name,SurName, FirstName, MiddleName" +
                  $",Gender, Relation, MaritalStatus, DOB, Country, State, City, Address" +
                  $",SBU , EnrollmentDate , PrimaryProviderNo , PrimaryProviderName, MemberExpirydate " +
                  $",StaffID, EMAIL, MobileNo , CapitatedMember, CapitationRate,Plancode " +
              $"FROM vw_MemberMasterView  ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<EnrolleeMasterViewModel>();

            return new PagedResponse<EnrolleeMasterViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }


        public async Task<PagedResponse<EnrolleeMasterViewModel>> FetchAvonStaffEnrolleeMasterRecord(PagingParam param)
        {
            var cmdText = $"SELECT COUNT(PolicyNo) FROM vw_MemberMasterView;SELECT PolicyNo, ClientName,[Policy Inception] PolicyInception,[Policy Expiry] PolicyExpiry,PlanType," +
                  $"[Plan Type Category] PlanTypeCategory,MemberHeadNo,MemberType,MemberNo" +
                  $",AvonOldEnrolleId, PremiumType,Name,SurName, FirstName, MiddleName" +
                  $",Gender, Relation, MaritalStatus, DOB, Country, State, City, Address" +
                  $",SBU , EnrollmentDate , PrimaryProviderNo , PrimaryProviderName, MemberExpirydate " +
                  $",StaffID, EMAIL, MobileNo , CapitatedMember, CapitationRate,Plancode " +
              $"FROM vw_MemberMasterView WHERE ClientName='AVON HEALTHCARE LIMITED' AND Relation='MEMBER'" +
              $" ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<EnrolleeMasterViewModel>();

            return new PagedResponse<EnrolleeMasterViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }

        public async Task<IEnumerable<EnrolleeMasterViewModel>> FetchHHStaffEnrolleeMasterRecord(int pageNumber,int pageSize)
        {
            var cmdText = $"SELECT PolicyNo, ClientName,[Policy Inception] PolicyInception,[Policy Expiry] PolicyExpiry,PlanType," +
                  $"[Plan Type Category] PlanTypeCategory,MemberHeadNo,MemberType,MemberNo" +
                  $",AvonOldEnrolleId, PremiumType,Name,SurName, FirstName, MiddleName" +
                  $",Gender, Relation, MaritalStatus, DOB, Country, State, City, Address" +
                  $",SBU , EnrollmentDate , PrimaryProviderNo , PrimaryProviderName, MemberExpirydate " +
                  $",StaffID, EMAIL, MobileNo , CapitatedMember, CapitationRate,Plancode " +
                $"FROM vw_MemberMasterView WHERE Relation='MEMBER' AND EMAIL NOT LIKE '%'+FirstName+'%' AND  ClientName IN ('UNITED BANK FOR AFRICA','TRANSCORP HILTON HOTEL ABUJA','TRANSCORP POWER UGHELLI','UNITED CAPITAL PLC'," +
              $"'AVON HEALTHCARE LIMITED','HEIRS HOLDING OIL AND GAS LTD','AFRICA PRUDENTIAL REGISTRARS','HEIRS INSURANCE LIMITED','HEIRS LIFE ASSURANCE','AFRILAND PROPERTIES PLC'," +
              $"'HEIRS LIFE ASSURANCE DSA','TRANSCORP PLC','TRANSCORP HOTEL CALABAR','TRANS AFAM POWER PLANT LIMITED','HEIRS HOLDINGS','TRANSCORP HOTELS ABUJA','HEIRS INSURANCE BROKERS'" +
                $"'TONY ELUMELU FOUNDATION','REDTECH LIMITED','TENOIL')" +
              $" ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";


            var query = await _connection.QueryAsync<EnrolleeMasterViewModel> (cmdText, new { PageNumber = pageNumber, NumRows = pageSize });

           

            return query;
        }


        public async Task<PagedResponse<EnrolleeMasterViewModel>> FetchHHStaffEnrolleeMasterRecord(PagingParam param)
        {
            var cmdText = $"SELECT COUNT(PolicyNo) FROM vw_MemberMasterView;SELECT PolicyNo, ClientName,[Policy Inception] PolicyInception,[Policy Expiry] PolicyExpiry,PlanType," +
                  $"[Plan Type Category] PlanTypeCategory,MemberHeadNo,MemberType,MemberNo" +
                  $",AvonOldEnrolleId, PremiumType,Name,SurName, FirstName, MiddleName" +
                  $",Gender, Relation, MaritalStatus, DOB, Country, State, City, Address" +
                  $",SBU , EnrollmentDate , PrimaryProviderNo , PrimaryProviderName, MemberExpirydate " +
                  $",StaffID, EMAIL, MobileNo , CapitatedMember, CapitationRate,Plancode " +
                $"FROM vw_MemberMasterView WHERE Relation='MEMBER' AND EMAIL LIKE '%'+FirstName+'%' AND  ClientName IN ('UNITED BANK FOR AFRICA','TRANSCORP HILTON HOTEL ABUJA','TRANSCORP POWER UGHELLI','UNITED CAPITAL PLC'," +
              $"'AVON HEALTHCARE LIMITED','HEIRS HOLDING OIL AND GAS LTD','AFRICA PRUDENTIAL REGISTRARS','HEIRS INSURANCE LIMITED','HEIRS LIFE ASSURANCE','AFRILAND PROPERTIES PLC'," +
              $"'HEIRS LIFE ASSURANCE DSA','TRANSCORP PLC','TRANSCORP HOTEL CALABAR','TRANS AFAM POWER PLANT LIMITED','HEIRS HOLDINGS','TRANSCORP HOTELS ABUJA','HEIRS INSURANCE BROKERS', " +
                $"'TONY ELUMELU FOUNDATION','REDTECH LIMITED','TENOIL')" +
              $" ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<EnrolleeMasterViewModel>();

            return new PagedResponse<EnrolleeMasterViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }


        public async Task<IEnumerable<EnrolleeMasterViewModel>> FetchMemberWithEmail(PagingParam param)
        {
            var cmdText = $"SELECT PolicyNo, ClientName,[Policy Inception] PolicyInception,[Policy Expiry] PolicyExpiry,PlanType," +
                  $"[Plan Type Category] PlanTypeCategory,MemberHeadNo,MemberType,MemberNo" +
                  $",AvonOldEnrolleId, PremiumType,Name,SurName, FirstName, MiddleName" +
                  $",Gender, Relation, MaritalStatus, DOB, Country, State, City, Address" +
                  $",SBU , EnrollmentDate , PrimaryProviderNo , PrimaryProviderName, MemberExpirydate " +
                  $",StaffID, EMAIL, MobileNo , CapitatedMember, CapitationRate,Plancode " +
              $"FROM vw_MemberMasterView WHERE ClientName NOT IN ('UNITED BANK FOR AFRICA','TRANSCORP HILTON HOTEL ABUJA','TRANSCORP POWER UGHELLI','UNITED CAPITAL PLC'," +
              $"'AVON HEALTHCARE LIMITED','HEIRS HOLDING OIL AND GAS LTD','AFRICA PRUDENTIAL REGISTRARS','HEIRS INSURANCE LIMITED','HEIRS LIFE ASSURANCE','AFRILAND PROPERTIES PLC'," +
              $"'HEIRS LIFE ASSURANCE DSA','TRANSCORP PLC','TRANSCORP HOTEL CALABAR','TRANS AFAM POWER PLANT LIMITED','HEIRS HOLDINGS','TRANSCORP HOTELS ABUJA','HEIRS INSURANCE BROKERS', " +
                $"'TONY ELUMELU FOUNDATION','REDTECH LIMITED','TENOIL') AND Relation='MEMBER' AND (EMAIL <>'' or email NOT like '%default%')" +
              $" ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryAsync<EnrolleeMasterViewModel>(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            return query;

        }

        public async Task<PagedResponse<EnrolleeMasterViewModel>> FetchMemberWithoutEmail(PagingParam param)
        {
            var cmdText = $"SELECT COUNT(PolicyNo) FROM vw_MemberMasterView;SELECT PolicyNo, ClientName,[Policy Inception] PolicyInception,[Policy Expiry] PolicyExpiry,PlanType," +
                  $"[Plan Type Category] PlanTypeCategory,MemberHeadNo,MemberType,MemberNo" +
                  $",AvonOldEnrolleId, PremiumType,Name,SurName, FirstName, MiddleName" +
                  $",Gender, Relation, MaritalStatus, DOB, Country, State, City, Address" +
                  $",SBU , EnrollmentDate , PrimaryProviderNo , PrimaryProviderName, MemberExpirydate " +
                  $",StaffID, EMAIL, MobileNo , CapitatedMember, CapitationRate,Plancode " +
              $"FROM vw_MemberMasterView WHERE ClientName NOT IN ('UNITED BANK FOR AFRICA','TRANSCORP HILTON HOTEL ABUJA','TRANSCORP POWER UGHELLI','UNITED CAPITAL PLC'," +
              $"'AVON HEALTHCARE LIMITED','HEIRS HOLDING OIL AND GAS LTD','AFRICA PRUDENTIAL REGISTRARS','HEIRS INSURANCE LIMITED','HEIRS LIFE ASSURANCE','AFRILAND PROPERTIES PLC'," +
              $"'HEIRS LIFE ASSURANCE DSA','TRANSCORP PLC','TRANSCORP HOTEL CALABAR','TRANS AFAM POWER PLANT LIMITED','HEIRS HOLDINGS','TRANSCORP HOTELS ABUJA','HEIRS INSURANCE BROKERS', " +
                $"'TONY ELUMELU FOUNDATION','REDTECH LIMITED','TENOIL') AND Relation='MEMBER' AND (EMAIL ='' OR EMAIL LIKE '%default%')" +
              $" ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";

            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First(); ;
            var pageResult = query.Read<EnrolleeMasterViewModel>();

            return new PagedResponse<EnrolleeMasterViewModel>
            {
                Data = pageResult.ToList(),
                Totalrecords = totalrecord,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize,
                StatusCode = 200,
                hasError = false,
                Message = string.Empty
            };
        }


        public async Task<EnrolleePlanClassViewModel> FetchEnrolleePlanClass(int memberNo)
        {
            var sqlQuery = $"SELECT  [Plan Type Category] AS PlanClass, MemberNo FROM vw_MemberMasterView where MemberNo=@MemberNo";

            var query = await _connection.QueryAsync<EnrolleePlanClassViewModel>(sqlQuery, new { MemberNo = memberNo });

            var result = query.FirstOrDefault();

            return result;
        }



    }
}
