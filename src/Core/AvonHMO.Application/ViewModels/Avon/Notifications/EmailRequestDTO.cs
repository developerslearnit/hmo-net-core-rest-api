using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Notifications
{
    public class EmailRequestDTO
    {
        [Required]
        public string RequestReference { get; set; }
        [Required]
        [EmailAddress]
        public string RecipientEmailAddress { get; set; }
        public List<string> AddressesToCopy { get; set; } = new List<string>();
        public List<string> AddressesToBlindCopy { get; set; } = new List<string>();
        [Required]
        public string MailBody { get; set; }
      
        [Required]
        public string MessageTitle { get; set; }
        [JsonIgnore]
        public string userId { get; set; }
        public bool HasAttachment { get; set; }
        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(this);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            EmailAddressAttribute emailAddressAttribute = new EmailAddressAttribute();

            List<ValidationResult> validationResults = new List<ValidationResult>();

            if (AddressesToCopy.Count > 0)
            {
                foreach (var item in AddressesToCopy)
                {
                    if (!emailAddressAttribute.IsValid(item))
                    {
                        validationResults.Add(new ValidationResult($"{item} is not a valid email address",
                            new List<string> { "AddressesToCopy" }));
                    }
                }
            }
            if (AddressesToBlindCopy.Count > 0)
            {
                foreach (var item in AddressesToBlindCopy)
                {
                    if (!emailAddressAttribute.IsValid(item))
                    {
                        validationResults.Add(new ValidationResult($"{item} is not a valid email address",
                            new List<string> { "AddressesToBlindCopy" }));
                    }
                }
            }


            //if (HasAttachment &)
            //{
            //    validationResults.Add(new ValidationResult($"An attachment must be specified when HasAttachment is true",
            //                new List<string> { "Attachment" }));
            //}
            return validationResults;
        }
    }
}
