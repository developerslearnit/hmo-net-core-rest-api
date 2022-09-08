using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Toshfa;

namespace AvonHMO.Domain.Interfaces.Toshfa
{
    public interface IToshfaRepository
    {
        //FetchEnrolleePlanClass

        Task<EnrolleePlanClassViewModel> FetchEnrolleePlanClass(int memberNo);
        Task<AllHmoMemberMasterViewModel> FetchMemberByNumber(int memberNumber);
        Task<PagedResponse<AllHmoMemberMasterViewModel>> FetchExistingMemberMasterWithoutEmail(PagingParam param);
        Task<PagedResponse<AllHmoMemberMasterViewModel>> FetchExistingMemberMasterWithEmail(PagingParam param);
        Task<PagedResponse<AllHmoMemberMasterViewModel>> FetchExistingAvonStaffMemberMaster(PagingParam param);
        Task<PagedResponse<AllHmoMemberMasterViewModel>> FetchExistingMemberMaster(PagingParam param);
        Task<PagedResponse<HmoProvidersViewModel>> FetchProviderFilterByCategoryAndSearchKey(ProviderSearchFilterParam param);
        Task<PagedResponse<string>> FetchProviderCategory(PagingParam param);
        Task<HmoProvidersViewModel> FetchProviderByProviderCode(int code);

        Task<PagedResponse<HmoMemberApprovalDetailsViewModel>> FetchAllMemberApprovalDetails(PagingParam param);

        Task<PagedResponse<HmoMemberApprovalDetailsViewModel>> FetchAllMemberApprovalDetailsByRequestNo(PagingParam param, int request_no);

        Task<PagedResponse<HmoMemberApprovalDetailsViewModel>> FetchAllMemberApprovalDetailsByMemberNo(PagingParam param, int member_no);

        Task<PagedResponse<HmoMemberApprovalDetailsViewModel>> FetchAllMemberApprovalDetailsByAvonPaCode(PagingParam param, string avon_pa_code);

        Task<PagedResponse<MemberApprovedProvidersViewModel>> FetchAllMemberApprovedProviders(PagingParam param);

        Task<PagedResponse<MemberApprovedProvidersViewModel>> FetchAllMemberApprovedProvidersByHospitalNo(PagingParam param, int hospital_no);

        Task<PagedResponse<MemberApprovedProvidersViewModel>> FetchAllMemberApprovedProvidersByPolicyNo(PagingParam param, int policy_no);


        Task<PagedResponse<HmoMemberClaimsDetailsViewModel>> FetchAllMemberClaimsDetails(PagingParam param);
        Task<PagedResponse<HmoMemberClaimsDetailsViewModel>> FetchAllMemberClaimsDetailsByClaimNo(PagingParam param, int claim_no);

        Task<PagedResponse<HmoMemberDependentApprovalDetailsViewModel>> FetchAllMemberDependentApprovalDetails(PagingParam param);

        Task<PagedResponse<HmoMemberDependentApprovalDetailsViewModel>> FetchAllMemberDependentApprovalDetailsByRequestNo(PagingParam param, int request_no);

        Task<PagedResponse<HmoMemberDependentApprovalDetailsViewModel>> FetchAllMemberDependentApprovalDetailsByMemberNo(PagingParam param, int member_no);

        Task<PagedResponse<HmoMemberDependentApprovalDetailsViewModel>> FetchAllMemberDependentApprovalDetailsByAvonPaCode(PagingParam param, string avon_pa_code);

        Task<PagedResponse<HmoMemberDependentClaimsDetailsViewModel>> FetchAllMemberDependentClaimsDetails(PagingParam param);

        Task<PagedResponse<HmoMemberDependentClaimsDetailsViewModel>> FetchAllMemberDependentClaimsDetailsByClaimNo(PagingParam param, int claim_No);

        Task<PagedResponse<HmoMemberDependentClaimsDetailsViewModel>> FetchAllMemberDependentClaimsDetailsByMemberNo(PagingParam param, int member_no);

        Task<PagedResponse<HmoMemberDependentDetailsViewModel>> FetchAllMemberDependentDetails(PagingParam param);

        Task<PagedResponse<HmoMemberDependentDetailsViewModel>> FetchAllMemberDependentDetailsByMemberNo(PagingParam param, int member_no);


        Task<PagedResponse<HmoMemberDetailsViewModel>> FetchAllMemberDetails(PagingParam param);

        Task<PagedResponse<HmoMemberDetailsViewModel>> FetchAllMemberDetailsByMemberNo(PagingParam param, int member_no);


        Task<PagedResponse<HmoMemberDetailsWithToshfaUIDViewModel>> FetchAllMemberDetailsWithToshfaUID(PagingParam param);

        Task<PagedResponse<HmoMemberDetailsWithToshfaUIDViewModel>> FetchAllMemberDetailsWithToshfaUIDByToshfaUID(PagingParam param, string toshfaUID);

        Task<PagedResponse<HmoMemberInformationViewModel>> FetchAllMemberInformation(PagingParam param);

        Task<PagedResponse<HmoMemberInformationViewModel>> FetchAllMemberInformationByMemberNo(PagingParam param, int memberNo);

        Task<PagedResponse<HmoMemberMasterViewModel>> FetchAllMemberMaster(PagingParam param); //--**--//

        Task<PagedResponse<HmoMemberMasterViewModel>> FetchAllMemberMasterByPrimaryProviderNo(PagingParam param, int prim_prov_no);

        Task<PagedResponse<HmoMemberPolicyLimitsExhaustedAndAvailableViewModel>> FetchAllMemberPolicyLimitsExhaustedAndAvailable(PagingParam param);

        Task<PagedResponse<HmoMemberPolicyLimitsExhaustedAndAvailableViewModel>> FetchAllMemberPolicyLimitsExhaustedAndAvailableByMemberNo(PagingParam param, int member_no);

        Task<PagedResponse<HmoMemberPolicyStatusViewModel>> FetchAllMemberPolicyStatus(PagingParam param);

        Task<PagedResponse<HmoMembersListViewModel>> FetchAllMembersList(PagingParam param);

        Task<PagedResponse<HmoMembersListViewModel>> FetchAllMembersListByMemberNo(PagingParam param, int member_no);

        Task<PagedResponse<HmoMemberStatusViewModel>> FetchAllMemberStatus(PagingParam param);

        Task<PagedResponse<HmoMemberWisePremiumDtlsViewModel>> FetchAllMemberWisePremiumDtls(PagingParam param);

        Task<PagedResponse<HmoMemberWisePremiumDtlsViewModel>> FetchAllMemberWisePremiumDtlsByPolicyNo(PagingParam param, int policy_no);

        Task<PagedResponse<HmoMissingServicesDetailsApprovalViewModel>> FetchAllMissingServicesDetailsApproval(PagingParam param);
        Task<PagedResponse<HmoMissingServicesDetailsApprovalViewModel>> FetchAllMissingServicesDetailsApprovalByRequestNo(PagingParam param, int request_no);
        Task<PagedResponse<HmoMissingServicesDetailsApprovalViewModel>> FetchAllMissingServicesDetailsApprovalByProviderNo(PagingParam param, int provider_no);
        Task<PagedResponse<HmoMissingServicesDetailsApprovalViewModel>> FetchAllMissingServicesDetailsApprovalByPolicyNo(PagingParam param, int policy_no);
        Task<PagedResponse<HmoMissingServicesDetailsApprovalViewModel>> FetchAllMissingServicesDetailsApprovalByAvonPaCode(PagingParam param, string avon_pa_code);

        //-------------------------------------------------//

        Task<PagedResponse<HmoPackagePriceListViewModel>> FetchAllPackagePriceList(PagingParam param);
        Task<PagedResponse<HmoPackagePriceListViewModel>> FetchAllPackagePriceListByProviderNo(PagingParam param, int provider_no);

        Task<PagedResponse<HmoPlanMasterDetailsDentalExclusionsViewModel>> FetchAllPlanMasterDetailsDentalExclusions(PagingParam param);
        Task<PagedResponse<HmoPlanMasterDetailsDentalExclusionsViewModel>> FetchAllPlanMasterDetailsDentalExclusionsByPolicyNo(PagingParam param, int policy_no);


        Task<PagedResponse<HmoPlanMasterDetailsDentalInclusionsViewModel>> FetchAllPlanMasterDetailsDentalInclusions(PagingParam param);
        Task<PagedResponse<HmoPlanMasterDetailsDentalInclusionsViewModel>> FetchAllPlanMasterDetailsDentalInclusionsByPolicyNo(PagingParam param, int policy_no);

        Task<PagedResponse<PlanMasterDetailsDentalSubLimitViewModel>> FetchAllPlanMasterDetailsDentalSubLimit(PagingParam param);
        Task<PagedResponse<PlanMasterDetailsDentalSubLimitViewModel>> FetchAllPlanMasterDetailsDentalSubLimitByPolicyNo(PagingParam param, int policy_no);
        Task<PagedResponse<PlanMasterDetailsDentalSubLimitViewModel>> FetchAllPlanMasterDetailsDentalSubLimitByCode(PagingParam param, string code);

        Task<PagedResponse<HmoPlanMasterDetailsICDExclusionsViewModel>> FetchAllHmoPlanMasterDetailsICDExclusions(PagingParam param);
        Task<PagedResponse<HmoPlanMasterDetailsICDExclusionsViewModel>> FetchAllHmoPlanMasterDetailsICDExclusionsByPolicyNo(PagingParam param, int policy_no);
        Task<PagedResponse<HmoPlanMasterDetailsICDExclusionsViewModel>> FetchAllHmoPlanMasterDetailsICDExclusionsByCode(PagingParam param, string code);

        Task<PagedResponse<HmoPlanMasterDetailsICDInclusionsViewModel>> FetchAllHmoPlanMasterDetailsICDInclusions(PagingParam param);
        Task<PagedResponse<HmoPlanMasterDetailsICDInclusionsViewModel>> FetchAllHmoPlanMasterDetailsICDInclusionsByPolicyNo(PagingParam param, int policy_no);
        Task<PagedResponse<HmoPlanMasterDetailsICDInclusionsViewModel>> FetchAllHmoPlanMasterDetailsICDInclusionsByCode(PagingParam param, string code);

        Task<PagedResponse<HmoPlanMasterDetailsInformationViewModel>> FetchAllHmoPlanMasterDetailsInformation(PagingParam param);
        Task<PagedResponse<HmoPlanMasterDetailsInformationViewModel>> FetchAllHmoPlanMasterDetailsInformationByPolicyNo(PagingParam param, int policy_no);
        Task<PagedResponse<HmoPlanMasterDetailsInformationViewModel>> FetchAllHmoPlanMasterDetailsInformationByTemplateCode(PagingParam param, int temp_code);

        Task<PagedResponse<HmoPlanMasterDetailsMaternitySubLimitViewModel>> FetchAllHmoPlanMasterDetailsMaternitySubLimit(PagingParam param);
        Task<PagedResponse<HmoPlanMasterDetailsMaternitySubLimitViewModel>> FetchAllHmoPlanMasterDetailsMaternitySubLimitByPolicyNo(PagingParam param, int policy_no);
        Task<PagedResponse<HmoPlanMasterDetailsMaternitySubLimitViewModel>> FetchAllHmoPlanMasterDetailsMaternitySubLimitByCode(PagingParam param, string code);

        Task<PagedResponse<HmoPlanMasterDetailsOpticalSubLimitViewModel>> FetchAllHmoPlanMasterDetailsOpticalSubLimit(PagingParam param);
        Task<PagedResponse<HmoPlanMasterDetailsOpticalSubLimitViewModel>> FetchAllHmoPlanMasterDetailsOpticalSubLimitByPolicyNo(PagingParam param, int policy_no);
        Task<PagedResponse<HmoPlanMasterDetailsOpticalSubLimitViewModel>> FetchAllHmoPlanMasterDetailsOpticalSubLimitByCode(PagingParam param, string code);
        //-----------------------------//
        Task<PagedResponse<HmoTotalClaimsPerHealthPlanViewModel>> FetchAllHmoTotalClaimsPerHealthPlan(PagingParam param);

        Task<PagedResponse<HmoTotalHealthPremiumByAgentViewModel>> FetchAllHmoTotalHealthPremiumByAgent(PagingParam param);//--##--//

        Task<PagedResponse<HmoTotalHealthPremiumByAgentViewModel>> FetchAllHmoTotalHealthPremiumByAgentByPolicyNo(PagingParam param, int policy_no);

        Task<PagedResponse<HmoTotalHealthPremiumByAgentViewModel>> FetchAllHmoTotalHealthPremiumByAgentByMemberNo(PagingParam param, int member_no);//--##--//

        Task<PagedResponse<HmoTotalPremiumViewModel>> FetchAllHmoTotalPremium(PagingParam param);

        Task<PagedResponse<HmoTotalPremiumPerHealthPlanViewModel>> FetchAllHmoTotalPremiumPerHealthPlan(PagingParam param);

        Task<PagedResponse<HmoProvidersViewModel>> FetchAllProviders(PagingParam param);
        Task<PagedResponse<HmoProvidersViewModel>> FetchProviderByProviderCode(PagingParam param, string code);
        Task<PagedResponse<HmoProvidersViewModel>> FetchProviderByFilter(ProviderFilterParam param);
        Task<PagedResponse<BenefitNameViewModel>> FetchAllBenefitNames(PagingParam param);
        Task<List<BenefitNameViewModel>> FetchSingleBenefitNameByCode(string code);
        Task<PagedResponse<AgentOrBrokerInfomationViewModel>> FetchAllAgentOrBrokerInfo(PagingParam param);
        Task<List<AgentOrBrokerInfomationViewModel>> FetchAgentOrBrokerInfoByCode(string code);
        Task<PagedResponse<ProviderApprovalCountViewModel>> FetchAllProviderApprovalCount(PagingParam param);
        Task<PagedResponse<ProviderApprovalCountViewModel>> FetchProviderApprovalCountByProviderNo(int provider_no, PagingParam param);

        Task<PagedResponse<ApprovalRequestDetailedViewModel>> FetchAllApprovalRequestDetails(PagingParam param);
        Task<PagedResponse<ApprovalRequestDetailedViewModel>> FetchApprovalRequestDetailByPacode(string pacode, PagingParam param);
        Task<PagedResponse<ApprovalRequestDetailedViewModel>> FetchApprovalRequestDetailByProvider(string provider, PagingParam param);
        Task<List<ApprovalRequestServiceWiseDetailedViewModel>> FetchApprovalRequestDetailByRequestNo(int request_no);
        Task<PagedResponse<ApprovalRequestDetailedViewModel>> FetchApprovalRequestDetailByPolicyNo(int policy_no, PagingParam param);
        Task<PagedResponse<ApprovalRequestDetailedViewModel>> FetchApprovalRequestDetailByMemberNo(int member_no, PagingParam param);
        Task<PagedResponse<ApprovalRequestServiceWiseDetailedViewModel>> FetchAllApprovalRequestServiceDetails(PagingParam param);


        Task<PagedResponse<ApprovalRequestServiceWiseDetailedViewModel>> FetchAllApprovalRequestServiceByPacode(string pacode, PagingParam param);
        Task<PagedResponse<ApprovalRequestServiceWiseDetailedViewModel>> FetchAllApprovalRequestServiceByProvider(int provider, PagingParam param);
        Task<List<ApprovalRequestServiceWiseDetailedViewModel>> FetchApprovalRequestServiceByRequestNo(int request_no);
        Task<PagedResponse<ApprovalRequestServiceWiseDetailedViewModel>> FetchApprovalRequestServiceByPolicyNo(int policy_no, PagingParam param);
        Task<PagedResponse<ApprovalRequestServiceWiseDetailedViewModel>> FetchApprovalRequestServiceByMemberNo(int member_no, PagingParam param);
        Task<PagedResponse<ApprovalRequestServiceWiseDetailedViewModel>> FetchApprovalRequestServiceByAvonMemberNo(string avon_member_no, PagingParam param);


        Task<PagedResponse<ApprovalReqUtilizationDetailsViewModel>> FetchAllApprovalRequestUtilizationDetail(PagingParam param);
        Task<List<ApprovalReqUtilizationDetailsViewModel>> FetchApprovalRequestUtilizationRequestNo(int request_no);
        Task<PagedResponse<ApprovalReqUtilizationDetailsViewModel>> FetchApprovalRequestUtilizationByPacode(string pacode, PagingParam param);

        Task<PagedResponse<ApprovalReqUtilizationPendingDetailsViewModel>> FetchPendingApprovalRequestUtilizationByPacode(string pacode, PagingParam param);
        Task<List<ApprovalReqUtilizationPendingDetailsViewModel>> FetchPendingApprovalRequestUtilizationRequestNo(int request_no);
        Task<PagedResponse<ApprovalReqUtilizationPendingDetailsViewModel>> FetchAllPendingApprovalRequestUtilizationDetail(PagingParam param);


        Task<PagedResponse<AverageClaimsPaidPerEnrolleeViewModel>> FetchAllAverageClaimsPaidPerEnrollee(PagingParam param);
        Task<PagedResponse<AveragePremiumPerEnrolleeViewModel>> FetchAllAveragePremiumPaidPerEnrollee(PagingParam param);
        Task<PagedResponse<AveragePremiumPerPlanViewModel>> FetchAllAveragePremiumPerPlan(PagingParam param);
        Task<PagedResponse<CapitationEnrolleePolicyandPlanWiseDetailsReportViewModel>> FetchAllEnrolleeCapitationDetailReport(PagingParam param);
        Task<PagedResponse<CapitationEnrolleePolicyandPlanWiseDetailsReportViewModel>> FetchEnrolleeCapitationDetailReportByPolicyNo(int policy_no, PagingParam param);
        Task<PagedResponse<ClaimsActuarialAnalysis5ViewModel>> FetchClaimsActuarialAnalysis5(PagingParam param);

        Task<PagedResponse<ClaimsInformationViewModel>> FetchAllClaimsInformation(PagingParam param);
        Task<PagedResponse<ClientPremiumPostDtlsViewModel>> FetchAllClientPostedPremium(PagingParam param);

        Task<PagedResponse<ConsultationPriceListViewModel>> FetchAllConsultationPrices(PagingParam param);
        Task<PagedResponse<ConsultationPriceListViewModel>> FetchAllConsultationPricesByProvider(int provider_no, PagingParam param);
        Task<PagedResponse<Enrollee_InformationViewModel>> FetchEnrollee_Information(PagingParam param);
        Task<PagedResponse<Enrollee_InformationViewModel>> FetchEnrollee_InformationByMemberNo(int member_no, PagingParam param);


        Task<PagedResponse<EnrolleMemberViewModel>> FetchAllEnrolleeMember(PagingParam param);
        Task<PagedResponse<EnrolleMemberViewModel>> FetchEnrolleeMemberByMemberNo(int member_no, PagingParam param);

        Task<PagedResponse<ERXDiagnosisDetailsViewModel>> FetchAllERXDiagnosisDetails(PagingParam param);
        Task<PagedResponse<ERXDiagnosisDetailsViewModel>> FetchERXDiagnosisDetailByCodes(string code, PagingParam param);


        Task<PagedResponse<SpecialityMasterViewModel>> FetchASepcialities(PagingParam param);
        Task<PagedResponse<SpecialityMasterViewModel>> FetchSepcialityByCodes(string code, PagingParam param);

        Task<PagedResponse<ICDCODESViewModel>> FetchAllICDCodes(PagingParam param);
        Task<List<SpecialityMasterViewModel>> FetchICDCodeByCodes(string code);


        Task<PagedResponse<ICDDENTALViewModel>> FetchAllICDDentals(PagingParam param);
        Task<PagedResponse<ICDDENTALViewModel>> FetchICDDentalsByCodes(string code, PagingParam param);

        Task<PagedResponse<LossRatioPerPlanViewModel>> FetchAllLossRatioPerPlan(PagingParam param);

        Task<PagedResponse<MemberApprovalViewModel>> FetchAllMemberApproval(PagingParam param);

        Task<List<MemberApprovalViewModel>> FetchMemberApprovalByRequestNo(string request_no);
        Task<PagedResponse<MemberApprovalViewModel>> FetchMemberApprovalByPaCode(string pacode, PagingParam param);
        Task<PagedResponse<MemberApprovalViewModel>> FetchMemberApprovalByPolicyNo(int policy_no, PagingParam param);
        Task<PagedResponse<MemberApprovalViewModel>> FetchMemberApprovalByMemberNo(int member_no, PagingParam param);

        Task<PagedResponse<MemberDetailswithToshfaUIDViewModel>> FetchAllMemberDetailswithToshfaUID(PagingParam param);
        Task<PagedResponse<MemberDetailswithToshfaUIDViewModel>> FetchMemberDetailswithByToshfaUID(string toshfa_uid, PagingParam param);
        Task<PagedResponse<MemberDetailswithToshfaUIDViewModel>> FetchMemberDetailswithToshfaUIDByMemberNo(int member_no, PagingParam param);


        Task<PagedResponse<SupplyPriceListViewModel>> FetchAllSupplyPrices(PagingParam param);
        Task<PagedResponse<SupplyPriceListViewModel>> FetchAllSupplyPriceByProviderNo(int provider_no, PagingParam param);

        Task<PagedResponse<MemberPolicyClassViewModel>> FetchAllMemberPolicies(PagingParam param);
        Task<PagedResponse<MemberPolicyClassViewModel>> FetchMemberPoliciesByPolicyNo(int policy_no, PagingParam param);


        Task<PagedResponse<ToshfaUniqueNoViewModel>> FetchAllToshfaUniqueNo(PagingParam param);
        Task<PagedResponse<ToshfaUniqueNoViewModel>> FetchToshfaUniqueNoByMemberNo(int member_no, PagingParam param);
        Task<PagedResponse<ToshfaUniqueNoViewModel>> FetchToshfaUniqueNoByUniqueId(string toshfa_unique_id, PagingParam param);
        Task<PagedResponse<TotalPremiumPerClientAndRetailViewModel>> FetchAllTotalPremiumPerClientAndRetail(PagingParam param);
        Task<PagedResponse<TotalPremiumPerClientAndRetailViewModel>> FetchTotalPremiumPerClientAndRetailByMemberNo(int member_no, PagingParam param);
        Task<PagedResponse<TotalPremiumPerClientAndRetailViewModel>> FetchTotalPremiumPerClientAndRetailByPolicyNo(int policy_no, PagingParam param);

        Task<PagedResponse<CCAViewModel>> FetchAllCCA(PagingParam param);
        Task<PagedResponse<CCAViewModel>> FetchCCAByMemberNo(int member_no, PagingParam param);
        Task<PagedResponse<CCAViewModel>> FetchCCAByPolicyNo(int policy_no, PagingParam param);


        Task<PagedResponse<SupplyListViewModel>> FetchSupplyLists(PagingParam param);

        Task<HmoMemberMasterViewModel> GetEnrollePlan(int enrolleeNumber);
        Task<CurrentPlanDetail> GetCurrendEnrollePlan(string enrolleeNumber);
        Task<PagedResponse<HmoMemberMasterViewModel>> FetchAllEnrolleeDependants(PagingParam param, int enrolleeNumber);

        Task<List<CurrencyViewModel>> FecthCurrencies();

        Task<PagedResponse<EnrolleeMasterViewModel>> FetchAllEnrolleeMasterRecord(PagingParam param);
        Task<PagedResponse<EnrolleeMasterViewModel>> FetchAvonStaffEnrolleeMasterRecord(PagingParam param);
        Task<IEnumerable<EnrolleeMasterViewModel>> FetchMemberWithEmail(PagingParam param);
        Task<PagedResponse<EnrolleeMasterViewModel>> FetchMemberWithoutEmail(PagingParam param);
        Task<PagedResponse<EnrolleeMasterViewModel>> FetchHHStaffEnrolleeMasterRecord(PagingParam param);

        Task<IEnumerable<EnrolleeMasterViewModel>> FetchHHStaffEnrolleeMasterRecord(int pageNumber, int pageSize);

    }
}
