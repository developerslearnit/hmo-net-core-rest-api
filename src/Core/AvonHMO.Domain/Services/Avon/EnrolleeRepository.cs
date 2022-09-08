using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Plan;
using AvonHMO.Application.ViewModels.Avon.Referral;
using AvonHMO.Application.ViewModels.Toshfa;
using AvonHMO.Domain.Interfaces.Avon;
using AvonHMO.Entities;
using AvonHMO.Persistence.StorageContexts.Avon;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvonHMO.Domain.Extensions;
using AvonHMO.Persistence.StorageContexts.Toshfa;
using System.Diagnostics.Metrics;
using System.Net;
using System.Reflection;
using System.Xml.Linq;
using System.Xml;
using System.Data;
using Dapper;
using AvonHMO.Application.ViewModels.Avon.Enrollee;

namespace AvonHMO.Domain.Services.Avon
{
    public class EnrolleeRepository : IEnrolleeRepository
    {

        private readonly AvonDbContext _context;
        private readonly ToshfaDbContext _toshfaDbContext;
        private readonly IDbConnection _connection;
        public EnrolleeRepository(AvonDbContext context, ToshfaDbContext toshfaDbContext, IDbConnection connection)
        {
            _context = context;
            _toshfaDbContext = toshfaDbContext;
            _connection = connection;
        }

        public async Task<bool> UpdateEnrolleePhoto(int memberNumber, string photoPath)
        {
            var enrollee = await _context.Enrollees.FirstOrDefaultAsync(x => x.MemberNumber == memberNumber);
            if (enrollee != null)
            {
                enrollee.PicturePath = photoPath;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> AddEnrolleeReferrals(ReferralInviteModel model)
        {
            var referral = new Referalhistory()
            {
                EnrolleeId = Guid.Parse(model.enrolleeId),
                InviteePhone = model.friendPhone,
                ReferalCode = model.referralCode,
                ReferalLink = model.referralLink,
                ReferDate = DateTime.Now,
            };

            await _context.Referalhistories.AddAsync(referral);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ReferralCodeViewModel> FetchEnrolleeReferalCode(Guid id)
        {
            return await _context.EnrolleeReferalCodes.AsNoTracking()
                .Where(x => x.EnrolleeId == id)
                .Select(x => new ReferralCodeViewModel
                {
                    referralLink = "",
                    referralCode = x.ReferalCode

                }).FirstOrDefaultAsync();
        }

        public async Task<TempEnrolleeViewModel> FetchLocalEnrolleeWithmemberNumber(int memberNumber)
        {

            var data = from e in _context.Enrollees.AsNoTracking()
                       join pl in _context.Plans.AsNoTracking()
                       on e.ProductId equals pl.PlanCode
                       where e.MemberNumber == memberNumber
                       select new TempEnrolleeViewModel()
                       {
                           Address = e.Address,
                           bloodType = e.BloodType,
                           DOB = e.DateOfBirth,
                           EMAIL = e.Email,
                           imageUrl = e.PicturePath,
                           MaritalStatus = e.MaritalStatus,
                           FirstName = e.FirstName,
                           SurName = e.Surname,
                           height = e.Height,
                           Gender = e.Gender,
                           MobileNo = e.PrimaryPhoneNumber,
                           PrimaryProviderNo = e.ProviderId.HasValue ? e.ProviderId.Value : 0,
                           weight = e.Weight,
                           PlanCode = pl.PlanCode,
                           PlanName = pl.PlanName,
                           PlanRate = pl.Premium,
                           TotalAmount = e.TotalAmount ?? 0,
                       };

            return await data.FirstOrDefaultAsync();

        }


        public async Task<TempEnrolleeViewModel> FetchLocalEnrollee(string email)
        {

            var data = from e in _context.Enrollees.AsNoTracking()
                        join pl in _context.Plans.AsNoTracking()
                        on e.ProductId equals pl.PlanCode
                        where e.Email == email
                        select new TempEnrolleeViewModel()
                        {
                            Address = e.Address,
                            bloodType = e.BloodType,
                            DOB = e.DateOfBirth,
                            EMAIL = e.Email,
                            imageUrl = e.PicturePath,
                            MaritalStatus = e.MaritalStatus,
                            FirstName = e.FirstName,
                            SurName = e.Surname,
                            height = e.Height,
                            Gender = e.Gender,
                            MobileNo = e.PrimaryPhoneNumber,
                            PrimaryProviderNo = e.ProviderId.HasValue ? e.ProviderId.Value : 0,
                            weight = e.Weight,
                            PlanCode = pl.PlanCode,
                            PlanName = pl.PlanName,
                            PlanRate = pl.Premium,
                            TotalAmount = e.TotalAmount ?? 0,
                        };

            return await data.FirstOrDefaultAsync();

        }


        public IQueryable<TempEnrolleeDependantViewModel> FetchLocalAllEnrollee()
        {
            return from e in _context.DependantRequests.AsNoTracking()
                   select new TempEnrolleeDependantViewModel()
                   {
                       imageUrl = e.PicturePath,
                       FirstName = e.FirstName,
                       SurName = e.Surname,
                       Gender = e.Gender,
                       dependantId = e.DependantRequestId,
                       strMemberNo = e.MemberNo,
                       DOB = e.DateOfBirth.HasValue ? e.DateOfBirth.Value : DateTime.Now,
                       enrolleeId = e.EnrolleeId,
                       Relation = e.RelationshipId
                   };
        }


        public async Task<List<TempEnrolleeDependantViewModel>> FetchuserLocalEnrolleeDependants(Guid enrolleeId, string loggedInUserId)
        {

            var _enrollee = from e in _context.Enrollees.AsNoTracking()
                            join pl in _context.Plans.AsNoTracking()
                            on e.ProductId equals pl.PlanCode
                            where e.EnrolleeId == enrolleeId
                            select new TempEnrolleeViewModel()
                            {
                                Address = e.Address,
                                bloodType = e.BloodType,
                                DOB = e.DateOfBirth,
                                EMAIL = e.Email,
                                imageUrl = e.PicturePath,
                                MaritalStatus = e.MaritalStatus,
                                FirstName = e.FirstName,
                                SurName = e.Surname,
                                height = e.Height,
                                Gender = e.Gender,
                                MobileNo = e.PrimaryPhoneNumber,
                                PrimaryProviderNo = e.ProviderId.HasValue ? e.ProviderId.Value : 0,
                                weight = e.Weight,
                                PlanCode = pl.PlanCode,
                                PlanName = pl.PlanName,
                                PlanRate = pl.Premium,
                                TotalAmount = e.TotalAmount ?? 0,
                                MemberExpirydate = DateTime.UtcNow,
                                PolicyExpiry = DateTime.UtcNow,
                            };
            var enrollee = await _enrollee.FirstOrDefaultAsync();

            if (enrollee == null) return null;

            var data = from e in _context.DependantRequests.AsNoTracking()
                       where e.EnrolleeId == enrolleeId
                       select new TempEnrolleeDependantViewModel()
                       {
                           imageUrl = e.PicturePath,
                           FirstName = e.FirstName,
                           SurName = e.Surname,
                           Gender = e.Gender,
                           PlanCode = enrollee.PlanCode,
                           PlanName = enrollee.PlanName,
                           PlanRate = enrollee.PlanRate,
                           dependantId = e.DependantRequestId
                       };

            var res = await data.ToListAsync();
            if (res != null && res.Count <= 0 && !string.IsNullOrEmpty(loggedInUserId))
            {
                var logUs = Guid.Parse(loggedInUserId);
                data = from e in _context.DependantRequests.AsNoTracking()
                       where e.EnrolleeId == logUs
                       select new TempEnrolleeDependantViewModel()
                       {
                           imageUrl = e.PicturePath,
                           FirstName = e.FirstName,
                           SurName = e.Surname,
                           Gender = e.Gender,
                           PlanCode = enrollee.PlanCode,
                           PlanName = enrollee.PlanName,
                           PlanRate = enrollee.PlanRate,
                       };

                res = await data.ToListAsync();
            }
            return res;


        }
        public async Task<List<TempSponsoredViewModel>> FetchLocalEnrolleeSponsor(Guid enrolleeId)
        {
            var _enrollee = await _context.Enrollees.AsNoTracking().FirstOrDefaultAsync(m => m.EnrolleeId == enrolleeId);
            var data = from e in _context.Enrollees.AsNoTracking()
                       join pl in _context.Plans.AsNoTracking()
                       on e.ProductId equals pl.PlanCode
                       where e.sponsoredEmail == _enrollee.Email
                       select new TempSponsoredViewModel()
                       {
                           sponsoredId = e.EnrolleeId,
                           Address = e.Address,
                           bloodType = e.BloodType,
                           DOB = e.DateOfBirth,
                           EMAIL = e.Email,
                           imageUrl = e.PicturePath,
                           MaritalStatus = e.MaritalStatus,
                           FirstName = e.FirstName,
                           SurName = e.Surname,
                           height = e.Height,
                           Gender = e.Gender,
                           MobileNo = e.PrimaryPhoneNumber,
                           PrimaryProviderNo = e.ProviderId.HasValue ? e.ProviderId.Value : 0,
                           weight = e.Weight,
                           PlanCode = pl.PlanCode,
                           PlanName = pl.PlanName,
                           PlanRate = pl.Premium,
                           TotalAmount = e.TotalAmount ?? 0,
                       };
            return await data.ToListAsync();
        }
        public async Task<TempEnrolleeViewModel> FetchLocalEnrollee(Guid enrolleeId)
        {
            return await _context.Enrollees.AsNoTracking().Where(x => x.EnrolleeAccountId == enrolleeId)
               .Select(e => new TempEnrolleeViewModel
               {
                   Address = e.Address,
                   bloodType = e.BloodType,
                   DOB = e.DateOfBirth,
                   EMAIL = e.Email,
                   imageUrl = e.PicturePath,
                   MaritalStatus = e.MaritalStatus,
                   FirstName = e.FirstName,
                   SurName = e.Surname,
                   height = e.Height,
                   Gender = e.Gender,
                   MobileNo = e.PrimaryPhoneNumber,
                   PrimaryProviderNo = e.ProviderId.Value,
                   weight = e.Weight,
                   MemberNo = e.MemberNumber ?? 0
               }).FirstOrDefaultAsync();
        }


        public async Task<TempEnrolleeViewModel> FetchLocalEnrolleeByMemberNo(int memberNo)
        {
            return await _context.Enrollees.AsNoTracking().Where(x => x.MemberNumber == memberNo)
               .Select(e => new TempEnrolleeViewModel
               {
                   Address = e.Address,
                   bloodType = e.BloodType,
                   DOB = e.DateOfBirth,
                   EMAIL = e.Email,
                   imageUrl = e.PicturePath,
                   MaritalStatus = e.MaritalStatus,
                   FirstName = e.FirstName,
                   SurName = e.Surname,
                   height = e.Height,
                   Gender = e.Gender,
                   MobileNo = e.PrimaryPhoneNumber,
                   PrimaryProviderNo = e.ProviderId.Value,
                   weight = e.Weight,
                   MemberNo = e.MemberNumber ?? 0
               }).FirstOrDefaultAsync();
        }

        public async Task<TempEnrolleeViewModel> FetchBasicLocalEnrollee(Guid enrolleeId)
        {
            return await _context.Enrollees.AsNoTracking().Where(x => x.EnrolleeAccountId == enrolleeId)
               .Select(e => new TempEnrolleeViewModel
               {
                   Address = e.Address,
                   DOB = e.DateOfBirth,
                   EMAIL = e.Email,
                   imageUrl = e.PicturePath,
                   MaritalStatus = e.MaritalStatus,
                   FirstName = e.FirstName,
                   SurName = e.Surname,
                   Gender = e.Gender,
                   MobileNo = e.PrimaryPhoneNumber,
                   MemberNo = e.MemberNumber ?? 0,
                   PrimaryProviderNo = e.ProviderId ?? 0,
               }).FirstOrDefaultAsync();
        }

        public async Task<TempEnrolleeViewModel> FetchLocalEnrollee(int memberNumber)
        {
            return await _context.Enrollees.AsNoTracking().Where(x => x.MemberNumber == memberNumber)
              .Select(e => new TempEnrolleeViewModel
              {
                  Address = e.Address,
                  bloodType = e.BloodType,
                  DOB = e.DateOfBirth,
                  EMAIL = e.Email,
                  imageUrl = e.PicturePath,
                  MaritalStatus = e.MaritalStatus,
                  FirstName = e.FirstName,
                  SurName = e.Surname,
                  height = e.Height,
                  Gender = e.Gender,
                  MobileNo = e.PrimaryPhoneNumber,
                  PrimaryProviderNo = e.ProviderId.Value,
                  weight = e.Weight,

              }).FirstOrDefaultAsync();
        }

        public List<TempEnrolleeViewModel> FetchLocalEnrolleeDependents(string email)
        {
            List<TempEnrolleeViewModel> dependants = null;

            dependants = _context.EnrolleeDependants.AsNoTracking().Where(x => x.HeadMemberEmail == email)
                 .Select(e => new TempEnrolleeViewModel
                 {

                     DOB = e.DateOfBirth,
                     EMAIL = e.Email,
                     imageUrl = e.PicturePath,
                     MaritalStatus = e.MaritalStatus,
                     FirstName = e.FirstName,
                     SurName = e.Surname,
                     Gender = e.Gender
                 }).ToList();


            return dependants;
        }

        public IEnumerable<TempEnrolleeViewModel> FetchLocalEnrollees(PagingParam param)
        {

            var skip = (param.PageNumber - 1) * param.PageSize;

            return _context.Enrollees.AsNoTracking()
            .Select(e => new TempEnrolleeViewModel
            {
                Address = e.Address,
                bloodType = e.BloodType,
                DOB = e.DateOfBirth,
                EMAIL = e.Email,
                imageUrl = e.PicturePath,
                MaritalStatus = e.MaritalStatus,
                FirstName = e.FirstName,
                SurName = e.Surname,
                height = e.Height,
                Gender = e.Gender,
                MobileNo = e.PrimaryPhoneNumber,
                PrimaryProviderNo = e.ProviderId.Value,
                weight = e.Weight,

            }).Skip(skip)
                     .Take(param.PageSize);
        }

        public IEnumerable<ReferralInviteViewModel> GetEnrolleeReferrals(Guid id)
        {
            return _context.Referalhistories.AsNoTracking()
                            .Where(x => x.EnrolleeId == id)
                            .Select(x => new ReferralInviteViewModel
                            {
                                enrolleeId = x.EnrolleeId.ToString(),
                                friendPhone = x.InviteePhone,
                                referralCode = x.ReferalCode,
                                referralLink = x.ReferalLink,
                                refer_date = x.ReferDate

                            }).OrderByDescending(k => k.refer_date);
        }


        #region Data from toshfa


        public async Task<List<MemberPolicyStatus>> FetchMemberPolicyStatus(int memberNo)
        {

            var cmdText = $"SELECT  Memberno, MemberStatus,  PolicyName, PolicyStatus FROM vw_MemberStatus WHERE Memberno={memberNo}";

            var spContext = _toshfaDbContext.LoadSqlQuery(cmdText);

            return await spContext.ExecuteStoreProcedure<MemberPolicyStatus>();
        }



        public async Task<List<HmoMemberMasterViewModel>> FetchMemberInformationByNumber(int memberNumber)
        {

            var cmdText = $"SELECT PolicyNo, ClientName,[Policy Inception] PolicyInception,[Policy Expiry] PolicyExpiry,PlanType," +
                  $"[Plan Type Category] PlanTypeCategory,MemberHeadNo,MemberType,MemberNo" +
                  $",AvonOldEnrolleId, PremiumType,Name,SurName, FirstName, MiddleName" +
                  $",Gender, Relation, MaritalStatus, DOB, Country, State, City, Address" +
                  $",SBU , EnrollmentDate , PrimaryProviderNo , PrimaryProviderName, MemberExpirydate " +
                  $",StaffID, EMAIL, MobileNo , CapitatedMember , CapitationRate,planCode planCode, '' bloodType, '' weight, '' height, profilePictureUrl imageUrl " +
              $"FROM vw_MemberMasterView WHERE MemberNo={memberNumber}";

            var spContext = _toshfaDbContext.LoadSqlQuery(cmdText);

            return await spContext.ExecuteStoreProcedure<HmoMemberMasterViewModel>();


        }


        public async Task<List<HmoMemberMasterViewModel>> FetchEnrolleeDependatntsByMemberNumber(int memberNumber)
        {

            var cmdText = $"SELECT PolicyNo, ClientName,[Policy Inception] PolicyInception,[Policy Expiry] PolicyExpiry,PlanType," +
                  $"[Plan Type Category] PlanTypeCategory,MemberHeadNo,MemberType,MemberNo" +
                  $",AvonOldEnrolleId, PremiumType,Name,SurName, FirstName, MiddleName" +
                  $",Gender, Relation, MaritalStatus, DOB, Country, State, City, Address" +
                  $",SBU , EnrollmentDate , PrimaryProviderNo , PrimaryProviderName, MemberExpirydate " +
                  $",StaffID, EMAIL, MobileNo , CapitatedMember , CapitationRate,planCode planCode, '' bloodType, '' weight, '' height, profilePictureUrl imageUrl " +
              $"FROM vw_MemberMasterView WHERE MemberHeadNo={memberNumber} AND MemberType='DEPENDENT'";

            var spContext = _toshfaDbContext.LoadSqlQuery(cmdText);

            return await spContext.ExecuteStoreProcedure<HmoMemberMasterViewModel>();


        }

        public async Task<List<HmoMemberInformationViewModel>> FetchMemberEnrollerInformationByNumber(int memberNumber)
        {

            var cmdText = $"SELECT * FROM vw_MemberInformation WHERE MemberHeadNo={memberNumber}";

            var spContext = _toshfaDbContext.LoadSqlQuery(cmdText);

            return await spContext.ExecuteStoreProcedure<HmoMemberInformationViewModel>();


        }

        //public string ProfilePictureUrl { get; set; } = "";

        //public string Age { get; set; }

        //public string Height { get; set; }

        //public string Weight { get; set; }

        public async Task<PagedResponse<HmoMemberMasterViewModel>> FetchAllMemberMaster(EnrolleeSearchParam param)
        {

            string filterQuery = string.Empty;
            var filterStr = new List<string>();

            if (!string.IsNullOrWhiteSpace(param.name))
            {
                filterStr.Add($" Name LIKE '%{param.name}%'");
            }

            if (!string.IsNullOrWhiteSpace(param.cardNo))
            {
                filterStr.Add($" AvonOldEnrolleId LIKE '%{param.cardNo}%'");
            }

            if (!string.IsNullOrWhiteSpace(param.provider))
            {
                filterStr.Add($" PrimaryProviderName LIKE '%{param.provider}%'");
            }

            if (!string.IsNullOrWhiteSpace(param.planType))
            {
                filterStr.Add($" PlanType='{param.planType}'");
            }

            if (!string.IsNullOrWhiteSpace(param.startDate) && !string.IsNullOrWhiteSpace(param.endDate))
            {
                filterStr.Add($" EnrollmentDate BETWEEN '{param.startDate}' AND '{param.endDate}'");
            }





            if (filterStr.Count > 0)
                filterQuery = $" WHERE {string.Join(" AND ", filterStr)}";



            var cmdText = $"SELECT COUNT(PolicyNo) FROM vw_MemberMasterView {filterQuery};SELECT PolicyNo, ClientName,[Policy Inception] PolicyInception,[Policy Expiry] PolicyExpiry,PlanType," +
                  $"[Plan Type Category] PlanTypeCategory,MemberHeadNo,MemberType,MemberNo" +
                  $",AvonOldEnrolleId, PremiumType,Name,SurName, FirstName, MiddleName" +
                  $",Gender, Relation, MaritalStatus, DOB, Country, State, City, Address" +
                  $",SBU , EnrollmentDate , PrimaryProviderNo , PrimaryProviderName, MemberExpirydate " +
                  $",StaffID, EMAIL, MobileNo , CapitatedMember , CapitationRate,planCode planCode, '' bloodType, '' weight, '' height, profilePictureUrl imageUrl  " +
            $"FROM vw_MemberMasterView {filterQuery} ORDER BY Policyno OFFSET ((@PageNumber - 1) * @NumRows) ROWS FETCH NEXT @NumRows ROWS ONLY";


            var query = await _connection.QueryMultipleAsync(cmdText, new { PageNumber = param.PageNumber, NumRows = param.PageSize });

            var totalrecord = query.Read<int>().First();
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

        public async Task<HmoProvidersViewModel> FetchProviderByProviderCode(int code)
        {
            var cmdText = $"SELECT top 1 * FROM VW_ProviderList Where Code='{code}'";
            var query = await _connection.QueryMultipleAsync(cmdText);
            var pageResult = query.Read<HmoProvidersViewModel>().FirstOrDefault();
            return pageResult;
        }

        public async Task<bool> LogProviderChange(string memberNo)
        {
            var log = new ProviderChangeLog()
            {
                MemberNo = memberNo,
                ChangedDate = DateTime.Now,
                NextPossibleChangeDate = DateTime.Now.AddMonths(3),
            };

            await _context.ProviderChangeLogs.AddAsync(log);

            return _context.SaveChanges() > 0;
        }

        public ProviderChangeLogVM GetLastProviderChange(string memberNo)
        {
            return _context.ProviderChangeLogs.Where(l => l.MemberNo == memberNo).
                 Select(m => new ProviderChangeLogVM
                 {
                     memberNo = m.MemberNo,
                     NextChangeDate = m.NextPossibleChangeDate
                 }).
                 FirstOrDefault();
        }



        #endregion


    }
}
