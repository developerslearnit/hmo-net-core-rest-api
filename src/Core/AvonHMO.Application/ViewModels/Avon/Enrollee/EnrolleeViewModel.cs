using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Enrollee
{
    public class EnrolleeViewModel
    {
        public Guid enrolleeId { get; set; }
        public int memberNumber { get; set; }
        public bool isActive { get; set; }
        public int numberOfBenefact { get; set; }

        public string clientName { get; set; }
        public PersonalDetailViewModel personalDetail { get; set; } =new PersonalDetailViewModel();
        public ContactDetailView contactDetail { get; set; }=new ContactDetailView();
        public ProviderInfo providerInfo { get; set; }=new ProviderInfo();
        public PlanDetail planDetail { get; set; }=new PlanDetail();

    }
    public class EnrolleePayloadModel
    {
        public Guid enrolleeIdAccountId;

        public string enrolleeId { get; set; }
        public int providerId { get; set; }
        public int isSponsored { get; set; } = 0;
        public int numberOfBenefact { get; set; } = 0;
        public int skipOnlinePayment { get; set; } = 0;

        public decimal planRate { get; set; } = 0;
        public decimal totalAmount { get; set; } = 0;

        [JsonIgnore]
        public string pictureUrl { get; set; }

        [JsonIgnore]
        public string appUser { get; set; }

        [Required]
        public int productId { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string firstName { get; set; }
        [Required]
        public string surname { get; set; }
        public string middleName { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string maritalStatus { get; set; }

        [Required]
        /// Date Format dd/MM/yyyy
        public string dateOfBirth { get; set; }


        public string bloodType { get; set; }

        public decimal weight { get; set; }

        public string height { get; set; }

        public string enrolleeType { get; set; }


        [Required]
        public string address { get; set; }
        public string lga { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        public string phoneNumber2 { get; set; }
        [Required]
        public string email { get; set; }
        public string mailingAddress { get; set; }
        public string mailingState { get; set; }
        public string mailingLga { get; set; }

        public string providerLGA { get; set; }
        public string providerState { get; set; }
        public string providerCountry { get; set; }
        public string providerName { get; set; }
        public string paymentReference { get; set; }

        public string memberNumber { get; set; }

        public string companyName { get; set; }
    }
    public class TempEnrolleePayloadModel
    {
        public Guid enrolleeIdAccountId;

        public string enrolleeId { get; set; }
      
        [Required]
        public int providerId { get; set; }
        public int isSponsored { get; set; } = 0;
        public int numberOfBenefact { get; set; } = 0;
        public int skipOnlinePayment { get; set; } = 0;

        public decimal planRate { get; set; } = 0;
        public decimal totalAmount { get; set; } = 0;

        [JsonIgnore]
        public string pictureUrl { get; set; }

        [JsonIgnore]
        public string appUser { get; set; }

        [Required]
        public int productId { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string firstName { get; set; }
        [Required]
        public string surname { get; set; }
        public string middleName { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string maritalStatus { get; set; }

        [Required]
        /// Date Format dd/MM/yyyy
        public string dateOfBirth { get; set; }


        public string bloodType { get; set; }

        public decimal weight { get; set; }

        public string height { get; set; }

        public string enrolleeType { get; set; }


        public string address { get; set; }
        public string lga { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string phoneNumber { get; set; }
        public string phoneNumber2 { get; set; }
        [Required]
        public string email { get; set; }
        public string mailingAddress { get; set; }
        public string mailingState { get; set; }
        public string mailingLga { get; set; }

        public string providerLGA { get; set; }
        public string providerState { get; set; }
        public string providerCountry { get; set; }
        public string providerName { get; set; }
        public string paymentReference { get; set; }

        public string memberNumber { get; set; }

        public string companyName { get; set; }
    }
    public class PersonalDetailBirthCertDTO
    {
        [Required]
        public string enrolleeId { get; set; }

        public string bloodType { get; set; }

        public decimal weight { get; set; }

        public string height { get; set; }

        public string phoneNumber { get; set; }

    }


    public class PersonalDetailDTO
    {
        public string enrolleeId { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string firstName { get; set; }
        [Required]
        public string surname { get; set; }
        public string middleName { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string maritalStatus { get; set; }
        public string paymentReference { get; set; }
        public string enrolleeType { get; set; }

        [Required]
        /// Date Format dd/MM/yyyy
        public string dateOfBirth { get; set; }

        [Required]
        public string bloodType { get; set; }

        [Required]
        public decimal weight { get; set; }

        [Required]
        public string height { get; set; }

        public string imageUrl { get; set; }
    }
    public class ContactDetailDTO
    {

        [Required]
        public string enrolleeId { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string lga { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        public string phoneNumber2 { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string mailingAddress { get; set; }
        [Required]
        public string mailingState { get; set; }
        [Required]
        public string mailingLga { get; set; }
    }

    public class ContactDetailView
    {
        public string address { get; set; }
        public string lga { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string phoneNumber { get; set; }
        public string phoneNumber2 { get; set; }
        public string email { get; set; }
        public string mailingAddress { get; set; }
        public string mailingState { get; set; }
        public string mailingLga { get; set; }
    }

    public class PersonalDetailViewModel
    {
        public string title { get; set; }
        public string firstName { get; set; }
        public string surname { get; set; }
        public string middleName { get; set; }
        public string gender { get; set; }
        public string maritalStatus { get; set; }
        public string relation { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int age
        {
            get
            {
                var _age = 0;
                try
                {
                    var today = DateTime.Today;
                    _age = today.Year - dateOfBirth.Year;
                    if (dateOfBirth.Date > today.AddYears(-_age)) _age--;
                }
                catch
                {
                }

                return _age < 0 ? 0 : _age;
            }
        }
        public string bloodType { get; set; }
        public string weight { get; set; }
        public string height { get; set; }
        public string imageUrl { get; set; }


    }

    public class ProviderInfo
    {
        public string providerLGA { get; set; }
        public int providerId { get; set; }
        public string providerState { get; set; }
        public string providerCountry { get; set; }
        public string providerName { get; set; }
        public string providerAddress { get; set; }
    }

    public class EnrolleeSub
    {
        public Guid enrolleeId { get; set; }
        public string firstName { get; set; }
        public string surname { get; set; }
        public string middleName { get; set; }
        public int planId { get; set; }
        public string planName { get; set; }
    }

    public class Temp_ResData
    {
        public Guid Temp_EnrolleeId { get; set; }
        public string OrderPaymentRefrence { get; set; }
        public string email { get; set; }
        public bool hasError { get; set; }

    }
    public class ResData
    {
        public Guid enrolleeId { get; set; }

        public string picturePath { get; set; }
        public bool hasError { get; set; }

    }

    public class ActivateDeactivateEnrolleePayload
    {
        [Required]
        public Guid enrolleeId { get; set; }
        [Required]
        public int activateOrDeactivate { get; set; }
    }
    public class BulkActivateDeactivateEnrolleePayload
    {
        public List<ActivateDeactivateEnrolleePayload> data { get; set; }
    }

    public class EnrolleeViewDTO
    {

        public Guid enrolleeId { get; set; }
        public int memberNumber { get; set; }
        public bool isActive { get; set; }
        public int numberOfBenefact { get; set; }

        public string title { get; set; }
        public string firstName { get; set; }
        public string surname { get; set; }
        public string middleName { get; set; }
        public string gender { get; set; }
        public string maritalStatus { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string bloodType { get; set; }
        public string weight { get; set; }
        public string height { get; set; }
        public string imageUrl { get; set; }

        public string address { get; set; }
        public string lga { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string phoneNumber { get; set; }
        public string phoneNumber2 { get; set; }
        public string email { get; set; }
        public string mailingAddress { get; set; }
        public string mailingState { get; set; }
        public string mailingLga { get; set; }

        public string providerLGA { get; set; }
        public int providerId { get; set; }
        public string providerState { get; set; }
        public string providerCountry { get; set; }
        public string providerName { get; set; }
        public string fullName { get { return $"{firstName} {middleName} {surname}"; } }
        public DateTime dateCreated { get; set; }
    }

    public class EnrolleeFiteredModel
    {
        public int totalCount { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string sort_param { get; set; }
        public List<EnrolleeViewDTO> enrollees { get; set; }
    }

    public class PaggingFilterParams
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }

        public string name { get; set; }
        /// <summary>
        /// Filter date range start date, Format dd-MM-yyyy 
        /// </summary>
        public string startDate { get; set; }

        /// <summary>
        /// Filter date range end date, Format dd-MM-yyyy 
        /// </summary>
        public string endDate { get; set; }
        /// <summary>
        /// Filter by provider Code 
        /// </summary>
        public int providerCode { get; set; }
        /// <summary>
        /// Filter by number Of Beneficiary
        /// </summary>
        public int noOfBeneficiary { get; set; } = 0;
        /// <summary>
        /// Filter by Plan type 
        /// </summary>
        public string planType { get; set; }
        /// <summary>
        /// Filter by Card Number
        /// </summary>
        public string cardNumber { get; set; }
        /// <summary>
        /// fhone Number
        /// </summary>
        public string phoneNo { get; set; }

        /// <summary>
        /// Sorting: Value can be id_asc or id_desc, name_asc or name_desc, status_asc or status_desc
        /// </summary>
        public string sortParam { get; set; }



    }


    public class BuyPlanModel
    {
        [Required]
        public int noOfPlans { get; set; }
        [Required]
        public decimal totalAmount { get; set; }
        public string paymentReference { get; set; }
        public string paymentMethod { get; set; }
        public List<SubscriptionModel> subscriptions { get; set; }
    }

    public class SubscriptionModel
    {
        [Required]
        public string title { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string surname { get; set; }
        public string middleName { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string maritalStatus { get; set; }
        [Required]
        public string email { get; set; }
        
        public string imageUrl { get; set; }

        [Required]
        /// Date Format dd/MM/yyyy
        public string dateOfBirth { get; set; }

        public string bloodType { get; set; }

        public string weight { get; set; }

        public string height { get; set; }
        public int isSponsored { get; set; }
        public string sponsorEmail { get; set; }

        public string phoneNumber { get; set; }
        public string phoneNumber2 { get; set; }

        public int productId { get; set; }
        public decimal planRate { get; set; }
        public decimal amount { get; set; }
        public decimal nhis { get; set; }

        public string address { get; set; }
        public string lga { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string contactEmail { get; set; }
        public string mailingAddress { get; set; }
        public string mailingState { get; set; }
        public string mailingLga { get; set; }
        public int providerId { get; set; }
        public int skipOnlinePayment { get; set; }
    }

    public class ProfilePxModel
    {
        public IFormFile profilePix { get; set; }
        public string principlaEmail { get; set; }
    }

    public class providerDetailDTO
    {
        public int? ProviderId { get; set; }
        public string ProviderLGA { get; set; }
        public string ProviderName { get; set; }
        public string ProviderState { get; set; }
        public string ProviderCountry { get; set; }
    }



    public class TempEnrollee
    {
        public Guid enrolleeId { get; set; }
        public int memberNumber { get; set; }
        public bool isActive { get; set; }
        public int numberOfBenefact { get; set; }

        public string title { get; set; }
        public string firstName { get; set; }
        public string surname { get; set; }
        public string middleName { get; set; }
        public string gender { get; set; }
        public string maritalStatus { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int age
        {
            get
            {
                var _age = 0;
                try
                {
                    var today = DateTime.Today;
                    _age = today.Year - dateOfBirth.Year;
                    if (dateOfBirth.Date > today.AddYears(-_age)) _age--;
                }
                catch
                {
                }

                return _age < 0 ? 0 : _age;
            }
        }
        public string bloodType { get; set; }
        public string weight { get; set; }
        public string height { get; set; }
        public string imageUrl { get; set; }

        public string address { get; set; }
        public string lga { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string phoneNumber { get; set; }
        public string phoneNumber2 { get; set; }
        public string email { get; set; }
        public string mailingAddress { get; set; }
        public string mailingState { get; set; }
        public string mailingLga { get; set; }

        public string providerLGA { get; set; }
        public int providerId { get; set; }
        public string providerState { get; set; }
        public string providerCountry { get; set; }
        public string providerName { get; set; }
        public string providerAddress { get; set; }

        public int PlanCode { get; set; }
        public string PlanName { get; set; }
        public decimal PlanRate { get; set; }
        public decimal TotalAmount { get; set; }
    }
    public class PlanDetail
    {
        public int PlanCode { get; set; }
        public string PlanName { get; set; }
        public decimal PlanRate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
