using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Enrollee;
using AvonHMO.Application.ViewModels.Avon.Plan;
using AvonHMO.Application.ViewModels.Avon.Referral;
using AvonHMO.Application.ViewModels.Toshfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Domain.Interfaces.Avon
{
    public interface IEnrolleeRepository
    {
        Task<bool> UpdateEnrolleePhoto(int memberNumber, string photoPath);
        IQueryable<TempEnrolleeDependantViewModel> FetchLocalAllEnrollee();
        Task<TempEnrolleeViewModel> FetchBasicLocalEnrollee(Guid enrolleeId);
        Task<List<TempSponsoredViewModel>> FetchLocalEnrolleeSponsor(Guid enrolleeId);
        Task<List<TempEnrolleeDependantViewModel>> FetchuserLocalEnrolleeDependants(Guid enrolleeId, string logonuser);
        Task<TempEnrolleeViewModel> FetchLocalEnrollee(string email);
        Task<TempEnrolleeViewModel> FetchLocalEnrolleeWithmemberNumber(int memberNumber);
        Task<TempEnrolleeViewModel> FetchLocalEnrollee(Guid enrolleeId);

        Task<TempEnrolleeViewModel> FetchLocalEnrollee(int memberNumber);

        IEnumerable<TempEnrolleeViewModel> FetchLocalEnrollees(PagingParam param);

        List<TempEnrolleeViewModel> FetchLocalEnrolleeDependents(string email);

        Task<ReferralCodeViewModel> FetchEnrolleeReferalCode(Guid id);

        IEnumerable<ReferralInviteViewModel> GetEnrolleeReferrals(Guid id);

        Task<bool> AddEnrolleeReferrals(ReferralInviteModel model);

        //Data from toshfa
        Task<List<MemberPolicyStatus>> FetchMemberPolicyStatus(int memberNo);
        Task<List<HmoMemberMasterViewModel>> FetchMemberInformationByNumber(int memberNumber);

        Task<List<HmoMemberInformationViewModel>> FetchMemberEnrollerInformationByNumber(int memberNumber);

        Task<PagedResponse<HmoMemberMasterViewModel>> FetchAllMemberMaster(EnrolleeSearchParam param);


        Task<List<HmoMemberMasterViewModel>> FetchEnrolleeDependatntsByMemberNumber(int memberNumber);

        Task<HmoProvidersViewModel> FetchProviderByProviderCode(int code);

        Task<bool> LogProviderChange(string memberNo);

        ProviderChangeLogVM GetLastProviderChange(string memberNo);
        Task<TempEnrolleeViewModel> FetchLocalEnrolleeByMemberNo(int memberNo);
    }
}
