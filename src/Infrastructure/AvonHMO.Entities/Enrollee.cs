﻿using System;

namespace AvonHMO.Entities
{

    public class Enrollee : BaseEntity
    {
        public Guid EnrolleeId { get; set; }
        public string OrderRef { get; set; }
        public Guid EnrolleeAccountId { get; set; }
        public int? MemberNumber { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string BloodType { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string EnrolleeType { get; set; }
        public string PicturePath { get; set; }
        public string BirthCertificateUrl { get; set; }
        public string Address { get; set; }
        public string LGA { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }

        public string MailingAddress { get; set; }
        public string MailingLGA { get; set; }
        public string MailingState { get; set; }

        //Health Care Provider(HCP)
        public int? ProviderId { get; set; }
        public string ProviderLGA { get; set; }
        public string ProviderName { get; set; }
        public string ProviderState { get; set; }
        public string ProviderCountry { get; set; }

        public Guid ClientId { get; set; }
        public int ProductId { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public string SyncStatus { get; set; }

        public int? IsSponsored { get; set; } 
        public string sponsoredEmail { get; set; } 
        public int? NumberOfBenefact { get; set; } 
        public int? SkipOnlinePayment { get; set; } 

        public decimal? PlanRate { get; set; } 
        public decimal? TotalAmount { get; set; } 
        public decimal? nhis { get; set; } 
        public bool? IsActive { get; set; }

        public Guid BulkPaymentLogId { get; set; }

        public string PaymentRef { get; set; }

    }
}
