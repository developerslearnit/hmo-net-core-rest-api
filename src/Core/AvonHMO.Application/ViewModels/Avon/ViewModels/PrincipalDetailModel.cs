using AvonHMO.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.ViewModels
{
    public class PrincipalDetailViewModel: PrincipalDetailModel
    {
        public string profilePictureUri { get; set; }
    }
    
    public class PrincipalDetailViewModelDTO
    {
        public string profilePictureUri { get; set; }
        public string orderReference { get; set; }
        [Required]
        public string firstName { get; set; }
        public string middleName { get; set; }
        [Required]
        public string surname { get; set; }
        public string title { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string email { get; set; }
        public string sponsorEmail { get; set; }
        public int isSponsor { get; set; }

        //[Required]
        public string address { get; set; }
        [Required]
        /// Date Format dd/MM/yyyy
        public string dateOfBirth { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }

        [Required]
        public string phoneNumber { get; set; }
        public string maritalStatus { get; set; }

        [StringLength(50)]
        public string createdBy { get; set; }

        [Required]
        public int productId { get; set; }
    }
    public class PrincipalSponsorDetailModel
    {
        [Required]
        public string firstName { get; set; }

        [Required]
        public string OrderPaymentRefrence { get; set; }
        public string middleName { get; set; }
        [Required]
        public string surname { get; set; }
        public string title { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string sponsorEmail { get; set; }
        public int isSponsor { get; set; }

        //[Required]
        public string address { get; set; }
        [Required]
        /// Date Format dd/MM/yyyy
        public string dateOfBirth { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        public string maritalStatus { get; set; }

        [StringLength(50)]
        public string createdBy { get; set; }

        [Required]
        public int productId { get; set; }
    }
    public class PrincipalDetailModelExplore
    {
        [Required]
        public string firstName { get; set; }
        public string middleName { get; set; }
        [Required]
        public string surname { get; set; }
        public string title { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string sponsorEmail { get; set; }
        public int isSponsor { get; set; }

       
        public string address { get; set; }
        [Required]
        /// Date Format dd/MM/yyyy
        public string dateOfBirth { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }

        [Required]
        public string phoneNumber { get; set; }
        public string maritalStatus { get; set; }
        public string profilePictureUri { get; set; }

        [Required]
        public string orderReference { get; set; }

        [Required]
        public int productId { get; set; }
    }
    public class PrincipalDetailModel
    {
        [Required]
        public string firstName { get; set; }
        public string middleName { get; set; }
        [Required]
        public string surname { get; set; }
        public string title { get; set; }
        [Required]
        public string gender { get; set; }
        // [Required]
        public string email { get; set; }
        public string sponsorEmail { get; set; }
        public int isSponsor { get; set; }

        //[Required]
        public string address { get; set; }
        [Required]
        /// Date Format dd/MM/yyyy
        public string dateOfBirth { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string phoneNumber { get; set; }
        public string maritalStatus { get; set; }

        [StringLength(50)]
        public string createdBy { get; set; }

        [Required]
        public int productId { get; set; }
    }
    public class PrincipalDetailOtherAddedDTO
    {
        public bool HasError { get; set; } = true;
        public string OrderReference { get; set; }
        public int ProductId { get; set; }
        public string enrolleeId { get; set; }
    }
    public class PrincipalDetailAddedDTO
    {
        public bool HasError { get; set; } = true;
        public string OrderReference { get; set; }
        public Guid OrderId { get; set; }
        public int ProductId { get; set; }
    }

    public class DependantRequestViewModel
    {
        public Guid DependantRequestId { get; set; }
        [Required]
        public Guid EnrolleeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        public string MemberNo { get; set; }
        public string Title { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string PicturePath { get; set; }
        [Required]
        public string RelationshipId { get; set; }
        public int YourPlan { get; set; }

        public string RequestStatus { get; set; }
        public string RequestDate { get; set; }
    }
    
    public class DependantRequestPayloadModel
    {

        public Guid userId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        public string MemberNo { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string PicturePath { get; set; }
        [Required]
        public string RelationshipId { get; set; }
        public int YourPlan { get; set; }
        public string RequestStatus { get; set; }
        public string RequestDate { get; set; }
    }

    public class PrincResDTO
    {

        public string enrolleeId { get; set; }
        public string OrderReference { get; set; }
        public int ProductId { get; set; }
    }

    public class PrincipalDetailExploreModel
    {
        public string profilePictureUri { get; set; }
        [Required]
        public string firstName { get; set; }
        public string middleName { get; set; }
        [Required]
        public string surname { get; set; }
        public string title { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string email { get; set; }
        public string sponsorEmail { get; set; }
        public int isSponsor { get; set; }
        public string address { get; set; }
        [Required]
        /// Date Format dd/MM/yyyy
        public string dateOfBirth { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string phoneNumber { get; set; }
        public string maritalStatus { get; set; }

        [Required]
        public int productId { get; set; }
    }
}
