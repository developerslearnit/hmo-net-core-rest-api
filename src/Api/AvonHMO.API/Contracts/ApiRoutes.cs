namespace AvonHMO.API.Contracts
{
    public static class ApiRoutes
    {


        public static class PrefRote
        {
            public const string UserPref = "user/pref";
        }

        public static class Payments
        {
            public const string SeerBitInitTrans = "seerbit/transaction/init";
            public const string SeerBitVerifyTrans = "seerbit/transaction/verify/{paymentReference}";
            public const string PaystackInitTrans = "paystack/transaction/init";
            public const string PaystackVerifyTrans = "paystack/transaction/verify";
        }
       

        public static class PostRoute
        {
            public const string Post = "posts";
            public const string Category = "categories";
            public const string PostsByCat = "posts/category/{categoryId}";
            public const string SinglePost = "posts/{postId}";
            public const string PostReaders = "posts/reader-info";
            public const string MainCategory = "categories/main";
            public const string PostWithSearch = "posts/all/search";
        }

        public static class Providers
        {
            public const string AllProviders = "provider";
            public const string AllSearchProviders = "provider/search";
            public const string ProviderCategory = "provider/category";
            public const string ProviderByCode = "provider/{code}";
            public const string ProviderByfilter = "provider/filter";
            public const string AddNewProvider = "provider/new-provider";
            public const string ProviderTypes = "provider/types/all";
            public const string ProviderManagers = "provider/manager";

            public const string UploadProviderDocs = "provider/{providerId}/document";

            public const string ChangeProvider = "provider/member/change";

            public const string ProvidersUsageStats = "provider/usage/stats";

            public const string ProviderPlans = "provider/plans/{providerCode}";

            public const string ProvidersClaimsList = "provider/claims";
            public const string ProviderManagersChange = "provider/manager/change/request";

            public const string ProvidersGuideQst = "provider/guide";

        }

        public static class Cart
        {
            public const string addtocart = "cart";
            public const string getcart = "cart/{uniqueReference}";
            public const string updatecart = "cart/incr-decr";
            public const string remove = "cart/remove-cart-item/{cartId}";
            public const string clearItems = "cart/clear-cart-item/{uniqueReference}";
            //public const string PlanInitialize = "plans/suscribe/principal-detail";
            //public const string PlanComplete = "plans/suscribe/complete-payment";
            //public const string PlanUpdateContactDetail = "plans/suscribe/enrollee/contact-detail";
            //public const string PlanUpdateprovider = "plans/suscribe/enrollee/provider-detail";

        }
        public static class Plans
        {
            public const string AllPlanTypes = "plans";
            public const string PlanByCategory = "plans/{categoryId}";
            public const string PlanInitialize = "plans/suscribe/principal-detail";
            public const string PlanInitializeExplore = "plans/suscribe/explore/principal-detail";
            public const string PlanCompleteExplore = "plans/suscribe/explore/complete-payment";
            public const string PlanUpdateContactDetailExplore = "plans/suscribe/enrollee/explore/contact-detail";
            public const string PlanUpdateproviderExplore = "plans/suscribe/enrollee/explore/provider-detail";
            public const string PlanInitializeOthersExplore = "plans/suscribe/explore/principal-detail/others";
            public const string PlanTempInitialize = "plans/suscribe/info";
            public const string PlanInitializeOthers = "plans/suscribe/principal-detail/others";
            public const string PlanInitializeSiteOthers = "plans/suscribe/sponsor-principal-detail";
            public const string PlanInitializeBulk = "plans/suscribe/principal-detail/bulk";
            public const string bulkPlan = "plans/suscribe/bulk";
            public const string PlanComplete = "plans/suscribe/complete-payment";
            public const string PlanRenew = "plans/suscribe/Renew";
            public const string PlanCompletePayment = "plans/suscribe/complete-plan-payment";
            public const string PlanUpdateContactDetail = "plans/suscribe/enrollee/contact-detail";
            public const string PlanUpdateprovider = "plans/suscribe/enrollee/provider-detail";
            public const string uploadUtils = "plans/suscribe/upload-utils";
            public const string PlanCategories = "plan/categories";
            public const string OtherPlanForEnrollee = "plans/enrollee/other";

        }

        public static class Setup
        {
            public const string AllProviders = "providers";

            public const string ProviderByCode = "providers/{code}";
            public const string ProviderByfilter = "providers/filter";

            public const string AllMemberApprovalDetails = "membersApprovalDetails";
            public const string MemberApprovalDetailsByRequestNo = "membersApprovalDetails/requestNo/{request_no}";
            public const string MemberApprovalDetailsByMemberNo = "membersApprovalDetails/memberNo/{member_no}";
            public const string MemberApprovalDetailsByAvonPaCode = "membersApprovalDetails/avonPaCode/{avon_pa_code}";

            public const string AllMemberApprovedProviders = "memberApprovedProviders";
            public const string AllMemberApprovedProversByHospital = "memberApprovedProviders/hospitalNo/{hospital_no}";
            public const string AllMemberApprovedProversByPolicyNo = "memberApprovedProviders/policyNo/{policy_no}";

            public const string AllMemberClaimsDetails = "memberClaimsDetails";
            public const string AllMemberClaimsDetailsByClaimNo = "memberClaimsDetails/claimNo/{claim_no}";


            public const string AllMemberDependentApprovalDetails = "memberDependentApprovalDetails";
            public const string AllMemberDependentApprovalDetailsByRequestNo = "memberDependentApprovalDetails/requestNo/{request_no}";
            public const string AllMemberDependentApprovalDetailsByMemberNo = "memberDependentApprovalDetails/memberNo/{member_no}";
            public const string MemberDependentApprovalDetailsByAvonPaCode = "memberDependentApprovalDetails/avonPaCode/{avon_pa_code}";


            public const string AllMemberDependentClaimsDetails = "memberDependentClaimsDetails";
            public const string AllMemberDependentClaimsDetailsByClaimNo = "memberDependentClaimsDetails/claimNo/{claim_no}";
            public const string AllMemberDependentClaimsDetailsByMemberNo = "memberDependentClaimsDetails/memberNo/{member_no}";


            public const string AllMemberDependentDetails = "memberDependentDetails";
            public const string AllMemberDependentDetailsByMemberNo = "memberDependentDetails/memberNo/{member_no}";


            public const string AllMemberDetails = "memberDetails";
            public const string AllMemberDetailsByMemberNo = "memberDetails/memberNo/{member_no}";


            public const string AllMemberDetailsWithToshfaUID = "memberDetailsWithToshfaUID";
            public const string AllMemberDetailsWithToshfaUIDByToshfaUID = "memberDetailsWithToshfaUID/toshfaUID/{toshfa_uid}";


            public const string AllMemberInformation = "memberInformation";
            public const string AllMemberInformationByMemberNo = "memberInformation/memberNo/{member_no}";

            public const string AllMemberMaster = "memberMaster";
            public const string AllMemberMasterByPrimaryProviderNo = "memberMaster/primaryProviderNo/{primary_provider_no}";

            public const string AllMemberPolicyLimitsExhaustedAndAvailable = "memberPolicyLimitsExhaustedAndAvailable";
            public const string AllMemberPolicyLimitsExhaustedAndAvailableByMemberNo = "memberPolicyLimitsExhaustedAndAvailable/memberNo/{member_no}";

            public const string AllMemberPolicyStatus = "memberPolicyStatus";

            public const string AllHmoMembersList = "membersList";
            public const string AllHmoMembersListByMemberNo = "membersList/memberNo/{member_no}";

            public const string AllHmoMemberStatus = "memberStatus";

            public const string AllHmoMemberWisePremiumDtls = "memberWisePremiumDtls";
            public const string AllHmoMemberWisePremiumDtlsByPolicyNo = "memberWisePremiumDtls/policyNo/{policy_no}";

            public const string AllHmoMissingServicesDetailsApproval = "missingServicesDetailsApproval";
            public const string AllHmoMissingServicesDetailsApprovalByRequestNo = "missingServicesDetailsApproval/requestNo/{request_no}";
            public const string AllHmoMissingServicesDetailsApprovalByProviderNo = "missingServicesDetailsApproval/provider/{provider_no}";
            public const string AllHmoMissingServicesDetailsApprovalByPolicyNo = "missingServicesDetailsApproval/policyNo/{policy_no}";
            public const string AllHmoMissingServicesDetailsApprovalByAvonPaCode = "missingServicesDetailsApproval/avonPaCode/{avon_pa_code}";


            public const string AllHmoPackagePriceList = "packagePriceList";
            public const string AllHmoPackagePriceListByProviderNo = "packagePriceList/provider/{provider_no}";

            public const string AllHmoPlanMasterDetailsDentalExclusions = "planMasterDetailsDentalExclusions";
            public const string AllHmoPlanMasterDetailsDentalExclusionsByPolicyNo = "planMasterDetailsDentalExclusions/policyNo/{policy_no}";

            public const string AllHmoPlanMasterDetailsDentalInclusions = "planMasterDetailsDentalInclusions";
            public const string AllHmoPlanMasterDetailsDentalInclusionsByPolicyNo = "planMasterDetailsDentalInclusions/policyNo/{policy_no}";

            public const string AllHmoPlanMasterDetailsDentalSubLimit = "planMasterDetailsDentalSubLimit";
            public const string AllHmoPlanMasterDetailsDentalSubLimitByPolicyNo = "planMasterDetailsDentalSubLimit/policyNo/{policy_no}";
            public const string AllHmoPlanMasterDetailsDentalSubLimitByCode = "planMasterDetailsDentalSubLimit/code/{code}";

            public const string AllHmoPlanMasterDetailsICDExclusions = "planMasterDetailsICDExclusions";
            public const string AllHmoPlanMasterDetailsICDExclusionsByPolicyNo = "planMasterDetailsICDExclusions/policyNo/{policy_no}";
            public const string AllHmoPlanMasterDetailsICDExclusionsByCode = "planMasterDetailsICDExclusions/code/{code}";

            public const string AllHmoPlanMasterDetailsICDInclusions = "planMasterDetailsICDInclusions";
            public const string AllHmoPlanMasterDetailsICDInclusionsByPolicyNo = "planMasterDetailsICDInclusions/policyNo/{policy_no}";
            public const string AllHmoPlanMasterDetailsICDInclusionsByCode = "planMasterDetailsICDInclusions/code/{code}";

            public const string AllHmoPlanMasterDetailsInformation = "planMasterDetailsInformation";
            public const string AllHmoPlanMasterDetailsInformationByPolicyNo = "planMasterDetailsInformation/policyNo/{policy_no}";
            public const string AllHmoPlanMasterDetailsInformationByTemplateCode = "planMasterDetailsInformation/templateCode/{temp_code}";

            public const string AllHmoPlanMasterDetailsMaternitySubLimit = "planMasterDetailsMaternitySubLimit";
            public const string AllHmoPlanMasterDetailsMaternitySubLimitByPolicyNo = "planMasterDetailsMaternitySubLimit/policyNo/{policy_no}";
            public const string AllHmoPlanMasterDetailsMaternitySubLimitByCode = "planMasterDetailsMaternitySubLimit/code/{code}";

            public const string AllHmoPlanMasterDetailsOpticalSubLimit = "planMasterDetailsOpticalSubLimit";
            public const string AllHmoPlanMasterDetailsOpticalSubLimitByPolicyNo = "planMasterDetailsOpticalSubLimit/policyNo/{policy_no}";
            public const string AllHmoPlanMasterDetailsOpticalSubLimitByCode = "planMasterDetailsOpticalSubLimit/code/{code}";

            public const string AllHmoTotalClaimsPerHealthPlan = "totalClaimsPerHealthPlan";

            public const string AllHmoTotalHealthPremiumByAgentPlan = "totalHealthPremiumByAgentPlan";
            public const string AllHmoTotalHealthPremiumByAgentPlanByPolicyNo = "totalHealthPremiumByAgentPlan/policyNo/{policy_no}";
            public const string AllHmoTotalHealthPremiumByAgentPlanByMemberNo = "totalHealthPremiumByAgentPlan/memberNo/{member_no}";
            public const string AllHmoTotalPremium = "totalPremium";
            public const string AllHmoTotalPremiumPerHealthPlan = "totalPremiumPerHealthPlan";

            public const string AllBenefitNames = "benefitnames";
            public const string BenefitNamesByCode = "benefitnames/{code}";
            public const string AllAgentInfo = "agentinfo";
            public const string AgentInfoByCode = "agentinfo/{code}";
            public const string AllProviderApprovalCounts = "provider/approvalcounts";
            public const string ProviderApprovalCountByProviderNo = "provider/approvalcounts/{provider_no}";

            public const string AllApprovalRequestDetails = "approvalrequests";
            public const string ApprovalRequestDetailsByPaCode = "approvalrequests/pacode/{pacode}";
            public const string ApprovalRequestDetailsByPolicyNo = "approvalrequests/policyno/{policy_no}";
            public const string ApprovalRequestDetailsByMemberNo = "approvalrequests/memberno/{member_no}";
            public const string ApprovalRequestDetailsByRequestNo = "approvalrequests/requestno/{request_no}";
            public const string ApprovalRequestDetailsByProviderNo = "approvalrequests/providerno/{provider_no}";

            public const string AllApprovalRequestServiceDetails = "approvalrequests/service";
            public const string ApprovalRequestServiceDetailsByprovider = "approvalrequests/service/providerno/{provider_no}";
            public const string ApprovalRequestServiceDetailsByPaCode = "approvalrequests/service/pacode/{pacode}";
            public const string ApprovalRequestServiceDetailsByPolicyNo = "approvalrequests/service/policyno/{policy_no}";
            public const string ApprovalRequestServiceDetailsByMemberNo = "approvalrequests/service/memberno/{member_no}";
            public const string ApprovalRequestServiceDetailsByAvonMemberNo = "approvalrequests/service/avonmemberno/{avon_member_no}";
            public const string ApprovalRequestServiceDetailsByRequestNo = "approvalrequests/service/requestno/{request_no}";

            public const string AllApprovalRequestutilizationDetails = "approvalrequests/utilization";
            public const string ApprovalRequestutilizationDetailsByPaCode = "approvalrequests/utilization/pacode/{pacode}";
            public const string ApprovalRequestutilizationDetailsByRequestNo = "approvalrequests/utilization/requestno/{request_no}";

            public const string AllPendingApprovalRequestutilizationDetails = "approvalrequests/utilization/pending";
            public const string PendingApprovalRequestutilizationDetailsByPaCode = "approvalrequests/utilization/pending/pacode/{pacode}";
            public const string PendingApprovalRequestutilizationDetailsByRequestNo = "approvalrequests/utilization/pending/requestno/{request_no}";

            public const string AllAverageClaimsPerEnrollee = "enrollee/averageclaims";
            public const string AllAveragePremiumPerEnrollee = "enrollee/averagepremiums";
            public const string AllAveragePremiumPerPlan = "plan/averagepremiums";

            public const string AllEnrolleeCapitationPlanDetailReport = "capitation/enrollee/plan-detail-report";
            public const string AllEnrolleeCapitationPlanDetailReportByPolicyNo = "capitation/enrollee/plan-detail-report/{policy_no}";

            public const string AllClaimsActuarialAnalysis = "claims/actuarial-analysis";
            public const string AllClaimsInfo = "claims/information";
            public const string AllClientPostedPremium = "client/posted-premium";
            public const string ConsultationPrices = "consultation/prices";
            public const string ConsultationPricesByproviderno = "consultation/prices/{provider_no}";

            public const string EnrolleeInformation = "enrollee/detail";
            public const string EnrolleeInformationByMemberNo = "enrollee/detail/{member_no}";

            public const string EnrolleeMembers = "enrollee/members";
            public const string EnrolleeMemberByMemberNo = "enrollee/members/{member_no}";


            public const string ERXDiagnosis = "erxdiagnosis";
            public const string ERXDiagnosisByCode = "erxdiagnosis/{code}";

            public const string specialities = "specialities";
            public const string specialityByCode = "specialities/{code}";

            public const string IcdCodes = "icdcodes";
            public const string IcdCodesByCode = "icdcodes/{code}";

            public const string IcdDentals = "icd-dentals";
            public const string IcdDentalsByCode = "icd-dentals/{code}";

            public const string LostRatioPerPlan = "plan/loss-ratio";

            public const string AllMemberApproval = "member/approvals";
            public const string MemberApprovalByReqNo = "member/approvals/requestno/{request_no}";
            public const string MemberApprovalByCode = "member/approvals/pacode/{pacode}";
            public const string MemberApprovalByPolicyNo = "member/approvals/policyno/{policy_no}";
            public const string MemberApprovalByMemberNo = "member/approvals/memberno/{member_no}";

            public const string AllMemberDetailWithToshfaUid = "member-details/toshfa-uid";
            public const string MemberDetailWithToshfaUidByMemberNo = "member-details/toshfa-uid/memberno/{member_no}";
            public const string MemberDetailWithToshfaUidBytoshfauid = "member-details/toshfa-uid/{toshfa-uid}";

            public const string AllSupplyPrices = "supply/prices";
            public const string AllSupplyPricesByProviderNo = "supply/prices/{provider_no}";



            public const string AllMemberPolicies = "member/policies";
            public const string AllMemberPoliciesBypolicyno = "member/policies/{policy_no}";


            public const string ToshfaUniquesno = "toshfa/unique-numbers";
            public const string ToshfaUniquesnoByMemberno = "toshfa/unique-numbers/memberno/{member_no}";
            public const string ToshfaUniquesnoById = "toshfa/unique-numbers/uniqueId/{unique_id}";

            public const string ClientRetailTotalPremiums = "client-retail/total-premiums";
            public const string ClientRetailTotalPremiumsByMemberno = "client-retail/total-premiums/memberno/{member_no}";
            public const string ClientRetailTotalPremiumsByPolicyNo = "client-retail/total-premiums/policyno/{policy_no}";


            public const string AllCCA = "cca";
            public const string CCAByMemberno = "cca/memberno/{member_no}";
            public const string CCAByPolicyNo = "cca/policyno/{policy_no}";

            public const string AllSupplyLists = "supplies";

            public const string Countries = "countries";

            public const string StateByCountry = "states/{countryCode}";

            public const string LocalGovtByState = "local-govt/{stateCode}";

            public const string CityByState = "city/{stateCode}";

            public const string Currencies = "currencies";


        }
        public static class ExploreAvon
        {
            public const string PostPartnerBroker = "explore/partner-broker";
            public const string GetAllPartnerBroker = "partner-broker";
            public const string PostPartnerAgent = "explore/partner-agent";
            public const string GetAllPartnerAgent = "partner-agent";
            public const string PostPartnerProvider = "explore/partner-provider";
            public const string GetAllPartnerProvider = "partner-provider";
            public const string RiskAssessmentRequest = "explore/risk-assessment";
            public const string GetAllRiskAssessmentRequest = "risk-assessment";
            public const string GetAllRiskAssessmentQuestions = "risk-assessment/questions";
            public const string HospitalReview = "explore/hospital-review";
            public const string HospitalReviewImg = "explore/hospital/image";
            public const string GetHospitalReviewImgByHospitalCode = "explore/hospital/image/{hospitalCode}";
            public const string GetHospitalReviewByHospitalCode = "explore/hospital/review/{hospitalCode}";
            public const string GetHospitalReview = "explore/hospital/review";
            public const string CreateRequestQuote = "explore/request-quote";
            public const string GetAllRequestQuote = "explore/quote";
            public const string GetAllRequestQuoteById = "explore/quote/{quoteId}";
            public const string GetAllFAQ = "faq";
            public const string GetAllFAQCategories = "faq-categories";
            public const string FAQwithSearch = "faqs";
            public const string PostFeedback = "feedback";
            public const string GetFeedback = "get-feedback";
           

        }

        public static class Referral
        {
            public const string EnrolleeReferals = "referral";
            public const string EnrolleeReferal = "referral/{enrolleeId}/code";
            public const string EnrolleeReferalSMS = "referral/sms";
            public const string AllEnrolleeReferals = "referrals/{enrolleeId}";
        }
        
        public static class Claims
        {
            public const string CreateClaims = "claims";
            public const string GetAllClaims = "all-claims";
            public const string GetClaimDetailById = "claims/{claimId}";
            public const string UpdateClaimStatus = "claims/update-status";
            public const string CloseClaim = "claims/close";
            public const string SearchClaims = "claims/search";
        }

        public static class Enrolle
        {
            public const string PostRequestAuthourization = "enrollee/request/authourization";
            public const string AllEnrollee = "enrollee/list/all";
            public const string EnrolleeePlan = "enrollee/{enrolleeNo}";
            public const string EnrolleecurrentPlan = "enrollee/current-plan-detail";
            public const string EnrolleeeDependants = "enrollee/dependant/{enrolleeNo}";

            public const string EnrolleeeByEmail = "enrollee/email";
            public const string EnrolleeeDepenById = "enrollee/dependants/{enrolleeId}";
            public const string EnrolleeSponsor = "enrollee/sponsors/{enrolleeId}";
            public const string EnrolleeeById = "enrollee/{id}/temp";
            public const string EnrolleeeDependantList = "enrollees/dependants";
            public const string EnrolleeeByMemberNo = "enrollee/memberno/{memberNo}";
            public const string EnrolleeeInfoByMemberNo = "enrollee/memberno";
            public const string UploadEnrolleeePhoto = "enrollee/photo/upload";


            public const string EnrolleeeDependantListByNumber = "enrollees/dependants/{memberNo}/list";

            public const string CreateEnrolleee = "enrollee";
            public const string EnrolleePayment = "enrollee/payment";
            public const string getEnrolleee = "enrollee";
            public const string enrolleeInfo = "enrollee/info/{enrolleeId}";
            public const string enrolleeAccoutInfo = "enrollee/primary-account/{enrolleeId}";
            public const string enrolleePersonalDetail = "enrollee/personal-detail/";
            public const string enrolleePersonalDetailBirthCert = "enrollee/personal-detail/birth-cert";
            public const string getenrolleePersonalDetail = "enrollee/personal-detail/{enrolleeId}";
            public const string getenrolleecontactDetail = "enrollee/contact-detail/{enrolleeId}";
            public const string enrolleecontactDetail = "enrollee/contact-detail";
            public const string getenrolleeproviderDetail = "enrollee/provider-detail/{enrolleeId}";
            public const string bulkenrolleeactivate = "enrollee/activate-deactivate/bulk";
            public const string enrolleeactivate = "enrollee/activate-deactivate";


            public const string EnrolleeMedicalRecord = "enrollee/medical-records/toshfa/{memberNo}";
            public const string PostReferralRequest = "referral-request";
            public const string GetReferralRequest = "referral-request/all";
            public const string GetReferralRequestByID = "referral-request/{id}";
        }

        public static class Actions
        {
            public const string PostDependantRequest = "enrollee/actions/dependant-request";
            public const string FetchDependantRequestByMember = "enrollee/actions/dependant/{member_no}";
            public const string FetchDependantRequestForLoggedOnUser = "enrollee/actions/dependant/loggedon-user";
            public const string FetchDependantRequest = "dependant-request";
            public const string PostDrugRefillRequest = "enrollee/actions/drugrefill-request";
            public const string PostDrugRefillRequestForAdmin = "enrollee/actions/admin/drugrefill-request";
            public const string FetchDrugRefillRequestByMember = "enrollee/actions/drugrefill/{member_no}";
            public const string FetchDrugRefillRequestForLoggedOnUser = "enrollee/actions/drugrefill/loggedon-user";
            public const string FetchDrugRefillRequestForLoggedOnUserWithStatus = "enrollee/actions/drugrefill/loggedon-user/status/{status}";
            public const string FetchDrugRefillRequestForLoggedOnUserWithState = "enrollee/actions/drugrefill/loggedon-user/state/{reqState}";
            public const string FetchDrugRefillRequestForLoggedOnUserWithStateAndState = "enrollee/actions/drugrefill/loggedon-user/status-state/{reqState}/{status}";
            public const string FetchDrugRefillRequest = "drugrefill-request";
            public const string UpdateDrugRefillStatus = "drugrefill/update-status";
            public const string GetDrugRefillDetailById = "drugrefill/{refillId}";


            public const string PostRequestRefund = "enrollee/actions/request-refund";
            public const string FetchRequestRefundByMember = "enrollee/actions/refund/{member_no}";
            public const string FetchRequestRefundForLoggedOnUser = "enrollee/actions/refund/loggedon-user";
            public const string FetchRequestRefund = "request-refund";
            public const string PostEnrolleeRecommendation = "enrollee/actions/enrollee-recommendation";
            public const string FetchEnrolleeRecommendation = "enrollee-recommendation";

            public const string ChangePrimaryProviderRequest = "enrollee/actions/primary-provider-request";
            public const string ChangePrimaryProviderRequestBymemberno = "enrollee/actions/primary-provider-request/{memberno}";
            public const string ChangePrimaryProviderRequestByEnrolleeId = "enrollee/actions/primary-provider-request/{enrolleeid}";
            public const string ChangePrimaryProviderRequestByRequestId = "enrollee/actions/primary-provider-request/{requestid}";


            public const string PostProviderRating = "enrollee/actions/provider-rating";
            public const string GetProviderRating = "enrollee/actions/provider/{providerId}";

            public const string PostCompliant = "complaint";
            public const string GetCompliant = "get-complaint";
            public const string GetAdminCompliantResponse = "complaint/get-admin-response";
            public const string FetchCompliantForLoggedOnUserWithStatus = "enrollee/complaint/loggedon-user/{status}";
            public const string FetchCompliantForLoggedOnUser = "enrollee/complaint/loggedon-user";
            public const string FetchCompliantWithStatus = "enrollee/complaint/{status}";
            public const string GetCompliantDetailById = "complaint/{complaintId}";
            public const string PostAdminResponseForCompliant = "complaint/admin-response";
            public const string GetCompliantAdminResponseDetailById = "complaint/admin-response/{complaintId}";
            public const string UpdateCompliantStatus = "complaint/update-status";
        }
        public static class CyclePlanner
        {
            public const string CyclePlannerCategory = "enrollee/cycle-planner/category";
            public const string CyclePlannercategoryById = "enrollee/cycle-planner/category/{categoryId}";
            public const string PostCycleInfo = "enrollee/cycle-planner/cycleinfo";
            public const string CycleInfoByEnrolleeId = "enrollee/cycle-planner/cycleinfo/{enrolleeid}";
            public const string CycleInfoByCycleId = "enrollee/cycle-planner/cycleinfo/id/{cycleid}";
            public const string CycleInfo = "enrollee/cycle-planner/cycleinfo";
            public const string RecentCycleInfo = "enrollee/cycle-planner/recent-cycle-info";
            public const string NextPriodInfo = "enrollee/cycle-planner/next-period";
            public const string countdown = "enrollee/cycle-planner/next-period/count-down";

        }


        public static class Auth
        {
            public const string Login = "login";
            public const string RefreshToken = "token/refresh";
            public const string GoogleSignIn = "google/login";
            public const string SocialSignIn = "social/all/login";
        }

        public static class Accounts
        {
            public const string RequestPasswordChangeLink = "password/forgot";
            public const string ResetPassword = "password/reset";
        }

        public static class Profile
        {
            public const string ChangePassword = "password/change";

        }

    }
}
