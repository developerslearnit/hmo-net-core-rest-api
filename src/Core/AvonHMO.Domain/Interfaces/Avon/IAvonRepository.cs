
using AvonHMO.API.Models.Providers;
using AvonHMO.Application.Contracts;
using AvonHMO.Application.ViewModels.Avon.Authentication;
using AvonHMO.Application.ViewModels.Avon.Communication;
using AvonHMO.Application.ViewModels.Avon.Enrollee;
using AvonHMO.Application.ViewModels.Avon.EnrolleFlow;
using AvonHMO.Application.ViewModels.Avon.Explore;
using AvonHMO.Application.ViewModels.Avon.Plan;
using AvonHMO.Application.ViewModels.Avon.Provider;
using AvonHMO.Application.ViewModels.Avon.SelfService;
using AvonHMO.Application.ViewModels.Avon.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AvonHMO.Application.ViewModels.Avon.Explore.CompliantViewModel;

namespace AvonHMO.Domain.Interfaces.Avon
{
    public interface IAvonRepository
    {

        #region Explore
        //  Task<List<TempEnrolleeDependantViewModel>> FetchLocalEnrolleeDependants(Guid enrolleeId);
        Task<PendingRegistrationModel> GetEnrolleependingTasks(Guid enrolleeId);
        Task UpdatePrinciDetailOthersProfilePix(string fileUri, string enrolleeId);
        Task<PrincipalDetailOtherAddedDTO> AddOtherPrincipalDetail(PrincipalDetailViewModelDTO model, string loginUser);
        Task<bool> AddToCart(CartDTO model);
        Task<IEnumerable<CartViewModel>> GetCart(string uniqueReference);
        Task RemoveCartItem(Guid cartId);
        Task ClearCartItem(string uniqueReference);
        Task<bool> UpdateAddToCart(CartPayLoadDTO model);
        Task UpdateEnrolleeBirthCert(string fileUri, Guid enrolleeId);
        Task<ResData> EditEnrolleeBasicInfo(PersonalDetailBirthCertDTO model,string pictureUrl = null); 

        Task<bool> AddBulkPlan(BuyPlanModel model, List<providerDetailDTO> providers);
        Task<bool> CreatePartnerBroker(PartnerBrokerViewModel partner);
        Task<List<PartnerBrokerModel>> GetPartnerBroker();
        Task<bool> CreatePartnerAgent(PartnerAgentViewModel partner);
        Task<List<PartnerAgentModel>> GetPartnerAgent();
        Task<bool> CreatePartnerProvider(PartnerProviderViewModel partner);
        Task<List<PartnerProviderModel>> GetPartnerProvider();
        Task<bool> CreateHealthRiskAssessment(RiskAssessmentRequestViewModel risk);
        Task<List<RiskAssessmentRequestModel>> GetHealthRiskAssessment();
        Task<List<RiskAssessmentQuestionModel>> GetHealthRiskAssessmentQuestion();
        IQueryable<RiskAssessmentQuestionAnswerModel> GetHealthRiskAssessmentQuestionAnswer();
        string ComputeRiskAssessmentAnswer(List<RiskAssessmentAnsweredModel> assessmentResult, string userId);
        Task<bool> CreateProviderRating(ProviderRatingRequestModel rating, System.Guid enrolleeID, string ProviderName);
        IQueryable<ProviderRatingViewModel> FetchProviderRatingByProviderID(PagingParam param, int providerId);
        Task<bool> CreateHospitalReview(HospitalReviewRequestModel review, System.Guid enrolleeID);
        IQueryable<HospitalReviewViewModel> FetchHospitalReviewByHospitalCode(PagingParam param, string hospitalCode);
        IQueryable<HospitalReviewViewModel> FetchHospitalReview(PagingParam param);
        Task<bool> CreateHospitalImage(HospitalImageRequestModel image);
        IQueryable<HospitalImageViewModel> FetchHospitalImageByHospitalCode(string hospitalCode);
        //Task<List<HospitalImageViewModel>> FetchHospitalImageByHospitalCode(string hospitalCode);
        #endregion
        Task<CompletePlanRenewalRes> RenewPlan(CompletePlanRenewal model, string user);
        Task<PrincipalDetailAddedDTO> AddPrincipalDetailExplore(PrincipalDetailExploreModel model);
        Task<CompletePlanSubscriptionResponseDTO> CompletePlanPurchaseExplore(CompletePlanSubscriptionDto model);
        Task<PrincipalDetailOtherAddedDTO> AddOtherPrincipalDetailExplore(PrincipalDetailModelExplore model);
        Task<ResData> AddEnrolleePrincipalInfo(PersonalDetailDTO model);

        Task<PaymentRepoResponseModel> AddEnrolleePayment(PaymentRequestModel model);
        Task AddToTempLog(TempLogModel model);
        Task<bool> HasActiveSubscription(string email);
        IQueryable<EnrolleeViewDTO> GetEnrolleeInfo();
        Task BulkActivateDeactivateEnrollee(BulkActivateDeactivateEnrolleePayload model);
        Task<EnrolleeSub> GetEnrolleeSubByEnrolleeId(Guid enrolleeId);
        Task<bool> ActivateDeactivateEnrollee(Guid enrolleeId, int activateOrDeactive);
        Task<ResData> EditEnrolleeContactInfo(ContactDetailDTO model);
        Task<ResData> EditEnrolleePrincipalInfo(PersonalDetailDTO model);
        Task<PersonalDetailViewModel> GetEnrolleePrincipalInfo(Guid enrolleeId);
        Task<ContactDetailView> GetEnrolleeContactInfo(Guid enrolleeId);
        Task<ProviderInfo> GetEnrolleeProviderInfoByEnrolleeId(Guid enrolleeId);
        Task UpdatePrinciDetailProfilePix(string fileUri, Guid orderId);
        Task<ResData> EditEnrollee(EnrolleePayloadModel model);
        Task<EnrolleeViewModel> GetEnrolleeInfoByEnrolleeId(Guid enrolleeId);
        Task<PrincipalDetailAddedDTO> AddPrincipalDetail(PrincipalDetailViewModel model, string loginUser);
        Task<CompletePlanSubscriptionResponseDTO> CompletePlanPurchase(CompletePlanSubscriptionDto model, string user);
        Task<bool> UpdateEnrolleeContactDetail(EnrolleeContactDetailViewModel model);
        Task<bool> UpdateEnrolleeProviderDetail(EnrolleeProviderViewModel model);
        Task<List<EnrolleeViewModelDTO>> GetEnrollee();
        Task<bool> ChangePrimaryProvider(ChangeProviderRequestViewModel model);
        // Task<PrincipalDetailAddedDTO> AddPrincipalDetail(PrincipalDetailModel model);
        //Task<bool> CompletePlanPurchase(CompletePlanSubscriptionDto model);
        Task<bool> UpdateCycleInfo(CycleInfoRequestModel model, Guid userid);
        Task<NextPeriodInfoViewModel> GetNextPeriodInfo(Guid userId);
        Task<List<CyclePlannerCategoryViewModel>> GetCyclePlannerCategories();
        Task<CycleInfoResponseDTO> AddCycleInfo(CycleInfoRequestModel model,Guid userId);
        Task<CycleInfoViewModel> GetRecentCycleInfo(Guid userid);
        Task<List<CycleInfoViewModel>> GetCycleInfo(Guid userid);
        Task<List<CycleInfoViewModel>> GetCycleInfoByCycleId(Guid cycleId);
        #region Enrolle Flow
        Task<bool> IsEnrolleeExist(Guid userID);
        Task<bool> IsEnrolleeIDExist(Guid enrolleeID);
        
        Task<bool> CreateRequestAuthorization(RequestAuthorizationViewModel reqAuth, Guid enrolleeID);
        Task<List<RequestAuthorizationModel>> GetRequestAuthorization();
        Task<bool> AddDependantRequest(DependantRequestPayloadModel model);
        Task<bool> CheckDependantRequestCount(Guid userID);
        Task<int> GetDependantRequestCount(Guid userID);
        Task<bool> CheckDependantSpouseExist(Guid userID);
        Task<DependantRequestViewModel> FetchDependantRequestByMemberNo(string memberNo);
        IQueryable<DependantRequestViewModel> FetchDependantRequestForLoggedOnUser(PagingParam param, Guid enrolleeId);
        IQueryable<DependantRequestViewModel> FetchDependantRequest(PagingParam param);
        Task<bool> AddDrugRefillRequest(DrugRefillRequestViewModel model);
        Task<bool> AddDrugRefillRequestForAdmin(DrugRefillRequestViewModel model);
        Task<bool> AddDrugRefillRequestForWeb(DrugRefillRequestViewModel model);
        Task<DrugRefillRequestViewModel> FetchDrugRefillRequestByMemberNo(string memberNo);
        IQueryable<DrugRefillRequestViewModel> FetchDrugRefillRequestForLoggedOnUser(PagingParam param, Guid enrolleeId);
        IQueryable<DrugRefillRequestViewModel> FetchDrugRefillRequestForLoggedOnUserWithStatus(PagingParam param, Guid enrolleeId, string status);
        IQueryable<DrugRefillRequestViewModel> FetchDrugRefillRequestForLoggedOnUserWithState(PagingParam param, Guid enrolleeId, bool reqState);
        IQueryable<DrugRefillRequestViewModel> FetchDrugRefillRequestForLoggedOnUserWithStateAndStatus(PagingParam param, Guid enrolleeId, bool reqState, string status);
        IQueryable<DrugRefillRequestViewModel> FetchDrugRefillRequest(PagingParam param);
        Task<bool> UpdateDrugRefillStatus(DrugRefillUpdateViewModel model);
        Task<bool> IsDrugRefillIDExist(Guid refillID);
        Task<DrugRefillRequestViewModel> GetDrugRefillInfo(Guid refillId);
        Task<RequestRefundViewModel> FetchRequestRefundByMemberNo(string memberNo);
        IQueryable<RequestRefundViewModel> FetchRequestRefundForLoggedOnUser(PagingParam param, Guid enrolleeId);
        IQueryable<RequestRefundViewModel> FetchRequestRefund(PagingParam param);
        Task<bool> CreateRequestRefund(RequestRefundRequestModel reqRefund, Guid enrolleeID);
        Task<bool> CreateEnrolleeRecommendation(EnrolleeRecommendationRequestModel enrolleeRecommendation);
        IQueryable<EnrolleeRecommendationViewModel> FetchEnrolleeRecommendation(PagingParam param);

        #endregion

        Task<List<ChangeProviderRequestViewModel>> GetChangePrimaryProviderRequestByMemberNo(int memberNo);
        Task<List<ChangeProviderRequestViewModel>> GetChangePrimaryProviderRequestByEnrolleeId(Guid enrolleeId);
        Task<bool> IsOrderWithRefExist(string orderRef);
        Task<List<ChangeProviderRequestViewModel>> GetChangePrimaryProviderRequestByRequestId(Guid ChangeProviderRequestId);
        Task<PrincipalDetailOtherAddedDTO> AddSponsorPrincipalDetail(PrincipalSponsorDetailModel model);
        Task UpdateTempEnrolleeProfilePix(string fileUri, Guid tempEnrolleeId);
        Task<Temp_ResData> AddTempEnrollee(TempEnrolleePayloadModel model);
        Task<ResData> AddEnrollee(EnrolleePayloadModel model, string sponsorEmail);
        Task UpdateEnrolleeProfilePix(string fileUri, Guid enrolleeId);
        Task<bool> IsPaymentOrderWithRefExist(string orderRef);
        Task<CompletePlanSubscriptionResponseDTO> CompletePlanPay(CompletePlanPayment model);

        #region HCP
        Task<bool> PostGuideQuestion(ProviderInspectionGuideAnswerDTO model);
        Task<List<ProviderInspectionGuideViewModel>> GetInspectionGuideQestions();
        Task<bool> AddProviderDetail(ProvidersRepoDTO model);
        Task<bool> CreateRequestQuote(RequestQuoteRequestModel quote);
        Task<List<RequestQuoteModel>> GetQuoteRequests();
        Task<RequestQuoteModel> GetQuoteRequestById(Guid quoteId);
        Task<bool> CreateClaims(ClaimsRequestModel quote);
        Task<List<ClaimsViewModel>> GetClaims();
        Task<ClaimsViewModel> GetClaimInfo(Guid claimId);
        Task<bool> CloseClaimInfo(CloseClaimsModel claimModel);
        IQueryable<ClaimsViewModel> SearchClaims(PagingParam param, string searchText);
        Task<bool> IsClaimIDExist(Guid claimID);
        Task<bool> UpdateClaimStatus(ClaimsUpdateViewModel model);
        IQueryable<FAQViewModel> FAQs(PagingParam param);
        IQueryable<FAQCategoryViewModel> GetFAQCategories();
        IQueryable<FAQViewModel> SearchFAQs(PagingParam param, string textQue);
        Task<bool> CreateFeedback(FeedbackRequestModel feedback);
        IQueryable<FeedbackViewModel> FetchFeedback(PagingParam param);

        IQueryable<CompliantViewModel> FetchComplaint(PagingParam param);
        IQueryable<CompliantViewModel> FetchComplaintByUser(PagingParam param, Guid enrolleeId);
        IQueryable<CompliantViewModel> FetchUserComplaintByStatus(PagingParam param, Guid enrolleeId, string status);
        IQueryable<CompliantViewModel> FetchComplaintByStatus(PagingParam param, string status);
        Task<bool> CreateCompliant(CompliantRequestModel compliant, Guid enrolleeID);
        Task<bool> UpdateComplaintStatus(CompliantUpdateViewModel model);
        Task<bool> IsComplaintIDExist(Guid complaintID);
        Task<CompliantViewModel> GetComplaintInfo(Guid complaintId);
        Task<bool> CreateCompliantAdminResponse(CompliantAdminRequestModel compliant);
        IQueryable<CompliantAdminViewModel> FetchAdminComplaintResponseByComplaintID(Guid complaintId);
        IQueryable<CompliantAdminViewModel> FetchAdminComplaintResponse(PagingParam param);

        List<ProviderPlansViewModel> GetProviderPlans(string providerClass);
        Task<bool> CreateReferralRequest(ReferralRequestRequestModel refRequest, Guid userID);
        IQueryable<ReferralRequestViewModel> FetchReferralRequest(PagingParam param);
        Task<ReferralRequestViewModel> FetchReferralRequestByID(Guid id);
        #endregion


        #region Notification

        IEnumerable<NotificationLogVM> PendingNotifications(string ownerId);
        Task<bool> LogNotification(NotificationLogVM notification);
        Task<bool> UpdateNotification(Guid notificationId);

        #endregion

        Task<ResData> AddEnrollee(EnrolleePayloadModel model);

         Task<bool> IsEnrolleeExists(int memberNo);

        void RemoveEnrollee(int memberNo);

        Task<Guid> AddNewProvider(ProviderViewModels model);

        Task<bool> ChangeProviderManager(HCPManagerModel model);

        Task<bool> UploadHospitalImages(List<HospitalImageRequestModel> images);

        Task<bool> UploadContractualDocs(List<HospitalImageRequestModel> images);
    }
}
