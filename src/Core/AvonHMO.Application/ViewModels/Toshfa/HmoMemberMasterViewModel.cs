using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Toshfa
{



    public class HmoMemberMasterViewModel
    {
        public int PolicyNo { get; set; }

        public string ClientName { get; set; }

        public DateTime PolicyInception { get; set; }

        public DateTime PolicyExpiry { get; set; }

        public string PlanType { get; set; }

        public string PlanTypeCategory { get; set; }

        public string MemberHeadNo { get; set; }

        public string MemberType { get; set; }

        public int MemberNo { get; set; }

        public string AvonOldEnrolleId { get; set; }

        public string PremiumType { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Gender { get; set; }

        public string Relation { get; set; }

        public string MaritalStatus { get; set; }

        public DateTime DOB { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string SBU { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public int PrimaryProviderNo { get; set; }

        public string PrimaryProviderName { get; set; }

        public DateTime MemberExpirydate { get; set; }

        public string StaffID { get; set; }

        public string EMAIL { get; set; }

        public string MobileNo { get; set; }

        public string CapitatedMember { get; set; }

        public decimal CapitationRate { get; set; }

        public string bloodType { get; set; }

        public string weight { get; set; }

        public string height { get; set; }

        public string imageUrl { get; set; }

        public int  planCode { get; set; }

        public int age
        {
            get
            {
                var _age = 0;
                try
                {
                    var today = DateTime.Today;
                    _age = today.Year - DOB.Year;
                    if (DOB.Date > today.AddYears(-_age)) _age--;
                }
                catch
                {
                }

                return _age < 0 ? 0 : _age;
            }
        }
    }

    public class CurrentPlanDetail
    {
        public int plancode { get; set; }
        public int MemberNo { get; set; }
        public DateTime MemberExpirydate { get; set; }

        public string PlanType { get; set; }
        public string planTypeCategory { get; set; }
        public decimal? TotalPremium { get; set; }
        public decimal? BasicPremium { get; set; }
        public decimal? MaternityPremium { get; set; }
        public decimal? DentalPremium { get; set; }
        public decimal? OpticalPremium { get; set; }
        public decimal? VaccPremium { get; set; }
        public decimal? OtherPremium { get; set; }
        public int? MaxConsultation { get; set; }
        public int? MaxDaughterAgeYear { get; set; }
        public int? MinSonAgeDays { get; set; }
        public int? MaxSonAgeYear { get; set; }
        public int? DependantsCovered { get; set; }
        public int? maxAge { get; set; }

    }
    public class MemberPolicyStatus
    {
        public int Memberno { get; set; }
        public string MemberStatus { get; set; }
        public string PolicyName { get; set; }
        public string PolicyStatus { get; set; }

    }


    public class AllHmoMemberMasterViewModel
    {
        public int PolicyNo { get; set; }

        public string ClientName { get; set; }

        public DateTime PolicyInception { get; set; }

        public DateTime PolicyExpiry { get; set; }

        public string PlanType { get; set; }

        public string PlanTypeCategory { get; set; }

        public string MemberHeadNo { get; set; }

        public string MemberType { get; set; }

        public int MemberNo { get; set; }

        public string AvonOldEnrolleId { get; set; }

        public string PremiumType { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Gender { get; set; }

        public string Relation { get; set; }

        public string MaritalStatus { get; set; }

        public DateTime DOB { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string SBU { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public int PrimaryProviderNo { get; set; }

        public string PrimaryProviderName { get; set; }

        public DateTime MemberExpirydate { get; set; }

        public string StaffID { get; set; }

        public string EMAIL { get; set; }

        public string MobileNo { get; set; }

        public string CapitatedMember { get; set; }

        public decimal CapitationRate { get; set; }

        public string ProfilePictureUrl { get; set; } = "";
        
        public string Age { get; set; }

        public string Height { get; set; }

        public string Weight { get; set; }

    }



    public class EnrolleeMasterViewModel
    {
        public int PolicyNo { get; set; }

        public string ClientName { get; set; }

        public DateTime PolicyInception { get; set; }

        public DateTime PolicyExpiry { get; set; }

        public string PlanType { get; set; }

        public string PlanTypeCategory { get; set; }

        public string MemberHeadNo { get; set; }

        public string MemberType { get; set; }

        public int MemberNo { get; set; }

        public string AvonOldEnrolleId { get; set; }

        public string PremiumType { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Gender { get; set; }

        public string Relation { get; set; }

        public string MaritalStatus { get; set; }

        public DateTime DOB { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string SBU { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public int PrimaryProviderNo { get; set; }

        public string PrimaryProviderName { get; set; }

        public DateTime MemberExpirydate { get; set; }

        public string StaffID { get; set; }

        public string EMAIL { get; set; }

        public string MobileNo { get; set; }

        public string CapitatedMember { get; set; }

        public decimal CapitationRate { get; set; }

        public int Plancode { get; set; }

    }

}
