
using AvonHMO.Application.ViewModels.Avon.Authentication;

using AvonHMO.Application.ViewModels.Avon.Plan;

using AvonHMO.Application.ViewModels.Avon.EnrolleFlow;


using AvonHMO.Application.ViewModels.Avon.ViewModels;
using AvonHMO.Common;
using AvonHMO.Domain.Interfaces.Avon;
using AvonHMO.Entities;
using AvonHMO.Persistence.StorageContexts.Avon;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AvonHMO.Application.Contracts;

using AvonHMO.Application.ViewModels.Avon.SelfService;
using AvonHMO.Application.ViewModels.Avon.Enrollee;
using AvonHMO.API.Models.Providers;
using AvonHMO.Application.ViewModels.Avon.Communication;
using AvonHMO.Application.ViewModels.Avon.Explore;
using AvonHMO.Application.ViewModels.Avon.Provider;
using static AvonHMO.Application.ViewModels.Avon.Explore.CompliantViewModel;
namespace AvonHMO.Domain.Services.Avon
{
    public class AvonRepository : IAvonRepository
    {
        private readonly AvonDbContext _context;
        public AvonRepository(AvonDbContext context)
        {
            _context = context;
        }



        #region Explore
        /// <summary> Capture a PartnerBroker
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 09-12-2021 6:03AM
        /// </remarks>
        public async Task AddToTempLog(TempLogModel model)
        {
            var temlog = new TempLog()
            {
                PayLoad = model.PayLoad,
                Message = model.Message,
                Action = model.Action,
                Controller = model.Controller,
                DateCreated = DateTime.Now,
            };

            await _context.TempLogs.AddAsync(temlog);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CreatePartnerBroker(PartnerBrokerViewModel partner)
        {
            var partnerBroker = new PartnerBroker()
            {
                Surname = partner.Surname,
                FirstName = partner.FirstName,
                Email = partner.Email,
                PhoneNumber = partner.PhoneNumber,
                Address = partner.Address,
                City = partner.City,
                CompanyName = partner.CompanyName,
                Country = partner.Country,
                DateCreated = DateTime.Now,
                LocalGovtArea = partner.LocalGovtArea,
                Message = partner.Message,
                State = partner.State,
                Title = partner.Title,



            };

            await _context.PartnerBrokers.AddAsync(partnerBroker);

            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<List<PartnerBrokerModel>> GetPartnerBroker()
        {
            var requests = await _context.PartnerBrokers.AsNoTracking()
                .Select(k => new PartnerBrokerModel()
                {
                    PartnerBrokerId = k.PartnerBrokerId,
                    Address = k.Address,
                    City = k.City,
                    Country = k.Country,
                    DateCreated = k.DateCreated,
                    Email = k.Email,
                    FirstName = k.FirstName,
                    Surname = k.Surname,
                    LocalGovtArea = k.LocalGovtArea,
                    PhoneNumber = k.PhoneNumber,
                    Message = k.Message,
                    State = k.State,
                    Title = k.Title,

                }).ToListAsync();
            return requests;
        }
        public async Task<bool> IsEnrolleeExist(Guid userID)
        {
            return (await _context.Enrollees.AsNoTracking().AnyAsync(m => m.EnrolleeAccountId == userID));
        }
        public async Task<bool> CheckDependantRequestCount(Guid userID)
        {
            var getDetail = await _context.DependantRequests.AsNoTracking().Where(m => m.EnrolleeId == userID && m.RequestStatus == "A").ToListAsync();

            if (getDetail.Any())
            {
                if (getDetail.Count >= 5)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<int> GetDependantRequestCount(Guid userID)
        {
            var getDetail = await _context.DependantRequests.AsNoTracking().Where(m => m.EnrolleeId == userID && m.RequestStatus == "A").ToListAsync();

            if (getDetail.Any())
            {
                return getDetail.Count;

            }
            return 0;
        }

        public async Task<bool> CheckDependantSpouseExist(Guid userID)
        {
            var spouseExist = await _context.DependantRequests.AsNoTracking().AnyAsync(m => m.EnrolleeId == userID && m.RelationshipId == "spouse");

            if (spouseExist)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> IsEnrolleeIDExist(Guid enrolleeID)
        {
            return (await _context.Enrollees.AsNoTracking().AnyAsync(m => m.EnrolleeId == enrolleeID));
        }

        /// <summary> Capture a PartnerAgent
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 14-12-2021 10:21AM
        /// </remarks>
        public async Task<bool> CreatePartnerAgent(PartnerAgentViewModel partner)
        {
            var partnerAgent = new PartnerAgent()
            {
                Surname = partner.Surname,
                FirstName = partner.FirstName,
                Email = partner.Email,
                PhoneNumber = partner.PhoneNumber,
                Address = partner.Address,
                City = partner.City,
                CompanyName = partner.CompanyName,
                Country = partner.Country,
                DateCreated = DateTime.Now,
                LocalGovtArea = partner.LocalGovtArea,
                Message = partner.Message,
                State = partner.State,
                Title = partner.Title,



            };

            await _context.PartnerAgents.AddAsync(partnerAgent);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<PartnerAgentModel>> GetPartnerAgent()
        {
            var requests = await _context.PartnerAgents.AsNoTracking()
                .Select(k => new PartnerAgentModel()
                {
                    PartnerAgentId = k.PartnerAgentId,
                    Address = k.Address,
                    City = k.City,
                    Country = k.Country,
                    DateCreated = k.DateCreated,
                    Email = k.Email,
                    FirstName = k.FirstName,
                    Surname = k.Surname,
                    LocalGovtArea = k.LocalGovtArea,
                    PhoneNumber = k.PhoneNumber,
                    Message = k.Message,
                    State = k.State,
                    Title = k.Title,
                    CompanyName = k.CompanyName

                }).ToListAsync();
            return requests;
        }
        ///  <summary> Capture a PartnerProvider
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 14-12-2021 11:02AM
        /// </remarks>
        public async Task<bool> CreatePartnerProvider(PartnerProviderViewModel partner)
        {
            var partnerProvider = new PartnerProvider()
            {
                Surname = partner.Surname,
                FirstName = partner.FirstName,
                Email = partner.Email,
                PhoneNumber = partner.PhoneNumber,
                Address = partner.Address,
                City = partner.City,
                Country = partner.Country,
                DateCreated = DateTime.Now,
                LocalGovtArea = partner.LocalGovtArea,
                State = partner.State,
                Title = partner.Title,
                ProviderName = partner.ProviderName
            };

            await _context.PartnerProviders.AddAsync(partnerProvider);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<PartnerProviderModel>> GetPartnerProvider()
        {
            var requests = await _context.PartnerProviders.AsNoTracking()
                .Select(k => new PartnerProviderModel()
                {
                    PartnerProviderId = k.PartnerProviderId,
                    Address = k.Address,
                    City = k.City,
                    Country = k.Country,
                    DateCreated = k.DateCreated,
                    Email = k.Email,
                    FirstName = k.FirstName,
                    Surname = k.Surname,
                    LocalGovtArea = k.LocalGovtArea,
                    PhoneNumber = k.PhoneNumber,
                    State = k.State,
                    Title = k.Title,
                    ProviderName = k.ProviderName
                }).ToListAsync();
            return requests;
        }


        /// <summary> Capture a HealthRiskAssessment
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 14-12-2021 11:06AM
        /// </remarks>
        public async Task<bool> CreateHealthRiskAssessment(RiskAssessmentRequestViewModel risk)
        {
            var riskAssessment = new RiskAssessmentRequest()
            {
                Name = risk.Name,
                Age = risk.Age,
                DrinkingFrequency = risk.DrinkingFrequency,
                IsSmoker = risk.IsSmoker,
                Sex = risk.Sex,
                Address = risk.Address,
                DateCreated = DateTime.Now,

            };

            await _context.RiskAssessmentRequests.AddAsync(riskAssessment);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<RiskAssessmentRequestModel>> GetHealthRiskAssessment()
        {
            var requests = await _context.RiskAssessmentRequests.AsNoTracking()
                .Select(k => new RiskAssessmentRequestModel()
                {
                    RiskAssessmentRequestId = k.RiskAssessmentRequestId,
                    Address = k.Address,
                    Age = k.Age,
                    DrinkingFrequency = k.DrinkingFrequency,
                    IsSmoker = k.IsSmoker,
                    Name = k.Name,
                    Sex = k.Sex
                }).ToListAsync();
            return requests;
        }

        public async Task<List<RiskAssessmentQuestionModel>> GetHealthRiskAssessmentQuestion()
        {
            var requests = await _context.HealthRiskAssessmentQuestions.AsNoTracking()
                .Select(k => new RiskAssessmentQuestionModel()
                {
                    HealthRiskAssessmentQuestionId = k.HealthRiskAssessmentQuestionId,
                    QuestionText = k.QuestionText,
                }).ToListAsync();
            return requests;
        }

        public IQueryable<RiskAssessmentQuestionAnswerModel> GetHealthRiskAssessmentQuestionAnswer()
        {
            return _context.HealthRiskAssessmentQuestions.AsNoTracking()
                .Select(c => new RiskAssessmentQuestionAnswerModel
                {
                    HealthRiskAssessmentQuestionId = c.HealthRiskAssessmentQuestionId,
                    Never = c.Never,
                    Ocassionally = c.Ocassionally,
                    Always = c.Always
                });
        }

        public string ComputeRiskAssessmentAnswer(List<RiskAssessmentAnsweredModel> assessmentResult, string userId)
        {
            var result = string.Empty;
            var computeResult = 0;
            foreach (var item in assessmentResult)
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = $"SELECT [" + item.AnswerText.Trim() + "] FROM HealthRiskAssessmentQuestions WHERE HealthRiskAssessmentQuestionId =  '" + item.HealthRiskAssessmentQuestionId + "'";
                    _context.Database.OpenConnection();
                    var xx = command.ExecuteScalar();
                    int outputResult = Convert.ToInt32(xx);
                    computeResult += outputResult;
                }

            }
            if (!string.IsNullOrWhiteSpace(userId))
            {
                if (computeResult <= 12)
                {
                    result = "You need to take your health needs more seriously. Kindly do a full wellness check soon.";
                }
                else if (computeResult >= 13 && computeResult <= 21)
                {
                    result = "You seem to be doing your best but need to be a bit more consistent and intentional as regards your health. Don’t forget to get a wellness check regularly.";
                }
                else
                {
                    result = "You’re doing great but can always be better.";
                }
            }
            else
            {
                if (computeResult <= 12)
                {
                    result = "You need to take your health needs more seriously. Kindly do a full wellness check soon. If you don’t have a health plan yet, get one from Avon HMO to manage your health properly.";
                }
                else if (computeResult >= 13 && computeResult <= 21)
                {
                    result = "You seem to be doing your best but need to be a bit more consistent and intentional as regards your health. Don’t forget to get a wellness check regularly and if you don’t have a health plan, you can get one from Avon HMO to access preventive healthcare services when you need them";
                }
                else
                {
                    result = "You’re doing great but can always be better. Consider getting an Avon HMO health plan to continue living a healthier fully life.";
                }
            }


            return result;
        }

        /// <summary> Capture a HospitalReview
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 14-12-2021 01:12PM
        /// </remarks>
        public async Task<bool> CreateHospitalReview(HospitalReviewRequestModel review, System.Guid enrolleeID)
        {

            var hospitalReview = new HospitalReview()
            {
                //MemberNumber = review.memberNumber,
                EnrolleeId = enrolleeID,
                Occupation = review.Occupation,
                Review = review.Review,
                Rating = review.Rating,
                DateCreated = DateTime.Now,
                HospitalCode = review.HospitalCode

            };

            await _context.HospitalReviews.AddAsync(hospitalReview);



            var res = await _context.SaveChangesAsync() > 0;
            return res;
        }


        /// <summary> Capture a ProviderRating
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 14-12-2021 01:12PM
        /// </remarks>
        public async Task<bool> CreateProviderRating(ProviderRatingRequestModel rating, System.Guid enrolleeAccountID, string ProviderName)
        {
            var userinfo = _context.ApplicationUsers.FirstOrDefault(m => m.UserId == enrolleeAccountID);
            if (userinfo != null)
            {
                var providerRating = new ProviderRating()
                {
                    EnrolleeAccountId = enrolleeAccountID,
                    //Occupation = userinfo.Occupation,
                    Review = rating.Review,
                    Rating = rating.Rating,
                    DateCreated = DateTime.Now,
                    ProviderId = rating.ProviderId,
                    ProviderName = ProviderName,
                    ReviewerName = userinfo.LastName + " " + userinfo.FirstName,
                    SatisfactoryLevel = rating.SatisfactoryLevel,
                    EasyAccessingCare = rating.EasyAccessingCare

                };

                await _context.ProviderRatings.AddAsync(providerRating);
            }


            var res = await _context.SaveChangesAsync() > 0;
            return res;
        }

        /// <summary> Get a ProviderRating
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 19-01-2022 08:00AM
        /// </remarks>
        public IQueryable<ProviderRatingViewModel> FetchProviderRatingByProviderID(PagingParam param, int providerId)
        {
            var requestQuery = from hospReview in _context.ProviderRatings.AsNoTracking()
                               where hospReview.ProviderId == providerId
                               select new ProviderRatingViewModel
                               {
                                   ReviewerName = hospReview.ReviewerName,
                                   //Occupation = hospReview.Occupation,
                                   Review = hospReview.Review,
                                   ProviderId = hospReview.ProviderId,
                                   Rating = hospReview.Rating,
                                   DateCreated = hospReview.DateCreated,
                                   HospitalRatingId = hospReview.HospitalRatingId,
                                   EasyAccessingCare = hospReview.EasyAccessingCare,
                                   SatisfactoryLevel = hospReview.SatisfactoryLevel

                               };

            var skip = (param.PageNumber - 1) * param.PageSize;

            return requestQuery.Skip(skip).Take(param.PageSize);
        }


        /// <summary> Get a HospitalReview
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 19-01-2022 08:00AM
        /// </remarks>
        public IQueryable<HospitalReviewViewModel> FetchHospitalReviewByHospitalCode(PagingParam param, string hospitalCode)
        {
            var requestQuery = from hospReview in _context.HospitalReviews.AsNoTracking()
                               join enrol in _context.Enrollees.AsNoTracking()
                               on hospReview.EnrolleeId equals enrol.EnrolleeId
                               where hospReview.HospitalCode == hospitalCode
                               select new HospitalReviewViewModel
                               {
                                   ReviewerName = enrol.Surname + enrol.FirstName,
                                   Occupation = hospReview.Occupation,
                                   Review = hospReview.Review,
                                   HospitalCode = hospReview.HospitalCode,
                                   Rating = hospReview.Rating,
                                   DateCreated = hospReview.DateCreated,
                                   HospitalReviewId = hospReview.HospitalReviewId,


                               };

            var skip = (param.PageNumber - 1) * param.PageSize;

            return requestQuery.Skip(skip).Take(param.PageSize);
        }

        /// <summary> Get a HospitalReview
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 19-01-2022 08:00AM
        /// </remarks>
        public IQueryable<HospitalReviewViewModel> FetchHospitalReview(PagingParam param)
        {
            var requestQuery = from hospReview in _context.HospitalReviews.AsNoTracking()
                               join enrol in _context.Enrollees.AsNoTracking()
                               on hospReview.EnrolleeId equals enrol.EnrolleeId
                               select new HospitalReviewViewModel
                               {
                                   ReviewerName = enrol.Surname + enrol.FirstName,
                                   Occupation = hospReview.Occupation,
                                   Review = hospReview.Review,
                                   HospitalCode = hospReview.HospitalCode,
                                   Rating = hospReview.Rating,
                                   DateCreated = hospReview.DateCreated,
                                   HospitalReviewId = hospReview.HospitalReviewId
                               };

            var skip = (param.PageNumber - 1) * param.PageSize;

            return requestQuery.Skip(skip).Take(param.PageSize);
        }



        /// <summary> Capture a HospitalImages
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 14-12-2021 05:42PM
        /// </remarks>
        public async Task<bool> CreateHospitalImage(HospitalImageRequestModel image)
        {
            var hospitalImage = new HospitalImage()
            {
                Image = image.Image,
                HospitalCode = image.HospitalCode,
            };

            await _context.HospitalImages.AddAsync(hospitalImage);

            return await _context.SaveChangesAsync() > 0;
        }



        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="images"></param>
        /// <returns></returns>
        public async Task<bool> UploadContractualDocs(List<HospitalImageRequestModel> images)
        {

            foreach (var img in images)
            {
                var hospitalImage = new ProviderContractualDoc()
                {
                    DocumentUri = img.Image,
                    ProviderCode = img.HospitalCode,
                };

                await _context.ProviderContractualDocs.AddAsync(hospitalImage);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        
        public async Task<bool> UploadHospitalImages(List<HospitalImageRequestModel> images)
        {

            foreach (var img in images)
            {
                var hospitalImage = new HospitalImage()
                {
                    Image = img.Image,
                    HospitalCode = img.HospitalCode,
                };

                await _context.HospitalImages.AddAsync(hospitalImage);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary> Get a HospitalImage
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 18-01-2022 08:00AM
        /// </remarks>
        public IQueryable<HospitalImageViewModel> FetchHospitalImageByHospitalCode(string hospitalCode)
        {
            var requestQuery = from request in _context.HospitalImages.AsNoTracking()
                               where request.HospitalCode == hospitalCode
                               select new HospitalImageViewModel
                               {
                                   HospitalImageId = request.HospitalImageId,
                                   HospitalCode = request.HospitalCode,
                                   Image = request.Image
                               };

            return requestQuery;
        }


        #endregion

        public async Task BulkActivateDeactivateEnrollee(BulkActivateDeactivateEnrolleePayload model)
        {
            foreach (var item in model.data)
            {
                var qry = $"update dbo.Enrollee set IsActive={item.activateOrDeactivate} where EnrolleeId='{item.enrolleeId}'";
                _ = await _context.Database.ExecuteSqlRawAsync(qry);
            }
        }

        public async Task<bool> IsEnrolleeExists(int memberNo)
        {
            var enrollee = await _context.Enrollees.SingleOrDefaultAsync(x => x.MemberNumber == memberNo);

            return enrollee != null;
        }

        public void RemoveEnrollee(int memberNo)
        {
            var enrollee = _context.Enrollees.SingleOrDefault(x => x.MemberNumber == memberNo);
            if (enrollee != null)
            {
                _context.Enrollees.Remove(enrollee);
                _context.SaveChanges();
            }
        }

        public async Task<bool> ActivateDeactivateEnrollee(Guid enrolleeId, int activateOrDeactive)
        {
            var enrollee = await _context.Enrollees.FirstOrDefaultAsync(j => j.EnrolleeId == enrolleeId);
            if (enrollee is not null)
            {
                enrollee.IsActive = activateOrDeactive > 0;
            }
            return (await _context.SaveChangesAsync()) > 0;


        }
        public async Task<ResData> AddEnrolleePrincipalInfo(PersonalDetailDTO model)
        {

            var enrollee = new Enrollee()
            {
                FirstName = model.firstName,
                Surname = model.surname,
                DateOfBirth = model.dateOfBirth.ToDateTime("dd/MM/yyyy"),// ?? new DateTime(),
                Deleted = false,
                Title = model.title,
                PicturePath = model.imageUrl,
                MiddleName = model.middleName,
                Gender = model.gender,
                MaritalStatus = model.maritalStatus,
                BloodType = model.bloodType,
                Height = model.height,
                Weight = model.weight.ToString(),
                sponsoredEmail = "",
                EnrolleeType = model.enrolleeType,
                PaymentRef = model.paymentReference,
                IsActive = true,
                Status = "A",
                SyncStatus = "P",
                DateCreated = DateTime.Now,
            };
            await _context.Enrollees.AddAsync(enrollee);
            if ((await _context.SaveChangesAsync()) > 0)
                return new ResData
                {
                    enrolleeId = enrollee.EnrolleeId,
                    hasError = false
                };

            return new ResData
            {
                hasError = true
            };
        }
        public async Task<ResData> EditEnrolleePrincipalInfo(PersonalDetailDTO model)
        {
            var enrollId = Guid.Parse(model.enrolleeId);

            var enrollee = await _context.Enrollees.FirstOrDefaultAsync(j => j.EnrolleeId == enrollId);

            if (enrollee is not null)
            {
                enrollee.FirstName = model.firstName;
                enrollee.Surname = model.surname;
                enrollee.DateOfBirth = model.dateOfBirth.ToDateTime("dd/MM/yyyy");// ?? new DateTime();
                enrollee.Deleted = false;
                enrollee.Title = model.title;
                enrollee.PicturePath = model.imageUrl;
                enrollee.MiddleName = model.middleName;
                enrollee.Gender = model.gender;
                enrollee.MaritalStatus = model.maritalStatus;
                enrollee.BloodType = model.bloodType;
                enrollee.Height = model.height;
                enrollee.Weight = model.weight.ToString();
            }
            if ((await _context.SaveChangesAsync()) > 0)
                return new ResData
                {
                    enrolleeId = enrollee.EnrolleeId,
                    hasError = false
                };

            return new ResData
            {
                hasError = true
            };
        }
        public async Task<ResData> EditEnrolleeBasicInfo(PersonalDetailBirthCertDTO model,string pictureUrl=null)
        {
            var enrollId = Guid.Parse(model.enrolleeId);
            try
            {
                var enrollee = await _context.Enrollees.FirstOrDefaultAsync(j => j.EnrolleeId == enrollId);

                if (enrollee != null)
                {
                    enrollee.BloodType = model.bloodType;
                    enrollee.Height = model.height;
                    enrollee.Weight = model.weight.ToString();

                    enrollee.PrimaryPhoneNumber = model.phoneNumber;
                 
                    if (!string.IsNullOrWhiteSpace(pictureUrl))
                    {
                        enrollee.PicturePath = pictureUrl;
                    }
                    

                }
                await _context.SaveChangesAsync();
                return new ResData
                {
                    enrolleeId = enrollee.EnrolleeId,
                    hasError = false,
                    picturePath = enrollee.PicturePath
                };
            }
            catch
            {

            }

            return new ResData
            {
                hasError = true
            };
        }


        public async Task<PaymentRepoResponseModel> AddEnrolleePayment(PaymentRequestModel model)
        {

            var payment = new Payment()
            {
                Amount = model.amount,
                TotalAmount = model.TotalAmount,
                PaymentMethod = model.paymentMethod,
                PaymentDate = DateTime.Now,
                DateCreated = DateTime.Now,
                NHIS = model.nhis,
                ProductId = model.productId,
                TransactionReference = model.transactionReference,
                PaymentReference = StringExtensions.RandomString(20, true, true, true, false),
            };
            await _context.Payments.AddAsync(payment);

            if ((await _context.SaveChangesAsync()) > 0)
                return new PaymentRepoResponseModel()
                {
                    PaymentReference = payment.PaymentReference,
                    hasError = false
                };

            return new PaymentRepoResponseModel
            {
                hasError = true
            };
        }



        public async Task<ResData> EditEnrolleeContactInfo(ContactDetailDTO model)
        {
            var enrollId = Guid.Parse(model.enrolleeId);

            var enrollee = await _context.Enrollees.FirstOrDefaultAsync(j => j.EnrolleeId == enrollId);

            if (enrollee is not null)
            {
                enrollee.Address = model.address;
                enrollee.Email = model.email;
                enrollee.Deleted = false;
                enrollee.PrimaryPhoneNumber = model.phoneNumber;
                enrollee.Country = model.country;
                enrollee.State = model.state;
                enrollee.PhoneNumber2 = model.phoneNumber2;
                enrollee.MailingAddress = model.mailingAddress;
                enrollee.MailingLGA = model.mailingLga;
                enrollee.MailingState = model.mailingState;
                enrollee.LGA = model.lga;
                enrollee.ProviderState = model.state;
                enrollee.ProviderCountry = model.country;
            }
            if ((await _context.SaveChangesAsync()) > 0)
                return new ResData
                {
                    enrolleeId = enrollee.EnrolleeId,
                    hasError = false
                };

            return new ResData
            {
                hasError = true
            };
        }
        public async Task<Temp_ResData> AddTempEnrollee(TempEnrolleePayloadModel model)
        {
            var enrollee = new Temp_Enrollee()
            {
                FirstName = model.firstName,
                Surname = model.surname,
                Address = model.address,
                DateOfBirth = model.dateOfBirth.ToDateTime("dd/MM/yyyy"),// ?? new DateTime(),
                Email = model.email,
                Title = model.title,
                PicturePath = model.pictureUrl,
                PrimaryPhoneNumber = model.phoneNumber,
                City = "",
                Country = model.country,
                State = model.state,
                MiddleName = model.middleName,
                Gender = model.gender,
                PhoneNumber2 = model.phoneNumber2,
                ProductId = model.productId,
                MailingAddress = model.mailingAddress,
                MailingLGA = model.mailingLga,
                MailingState = model.mailingState,
                MaritalStatus = model.maritalStatus,
                BloodType = model.bloodType,
                EnrolleeType = model.enrolleeType,
                Height = model.height,
                Weight = model.weight.ToString(),
                LGA = model.lga,
                IsActive = true,
                ProviderLGA = model.providerLGA,
                ProviderState = model.state,
                ProviderCountry = model.country,
                ProviderName = model.providerName,
                ProviderId = model.providerId,
                OrderPaymentRefrence = StringExtensions.RandomString(20, true, true, true, false),
                IsSponsored = model.isSponsored,
                Status = "P",
            };

            await _context.TemEnrollee.AddAsync(enrollee);

            if ((await _context.SaveChangesAsync()) > 0)
                return new Temp_ResData
                {
                    Temp_EnrolleeId = enrollee.Temp_EnrolleeId,
                    email = enrollee.Email,
                    OrderPaymentRefrence = enrollee.OrderPaymentRefrence,
                    hasError = false
                };

            return new Temp_ResData
            {
                hasError = true
            };
        }


        public async Task<ResData> AddEnrollee(EnrolleePayloadModel model)
        {

            if (string.IsNullOrEmpty(model.memberNumber)) model.memberNumber = "0";

            var enrollee = new Enrollee()
            {
                FirstName = model.firstName,
                Surname = model.surname,
                Address = model.address,
                DateOfBirth = model.dateOfBirth.ToDateTime("dd/MM/yyyy"),// ?? new DateTime(),
                CreatedBy = model.appUser,
                Email = model.email,
                Deleted = false,
                Title = model.title,
                PicturePath = model.pictureUrl,
                PrimaryPhoneNumber = model.phoneNumber,
                City = "",
                Country = model.country,
                State = model.state,
                MiddleName = model.middleName,
                DateCreated = DateTime.Now,
                Gender = model.gender,
                PhoneNumber2 = model.phoneNumber2,
                ProductId = model.productId,
                MailingAddress = model.mailingAddress,
                MailingLGA = model.mailingLga,
                MailingState = model.mailingState,
                MaritalStatus = model.maritalStatus,
                BloodType = model.bloodType,
                EnrolleeType = model.enrolleeType,
                Height = model.height,
                Weight = model.weight.ToString(),
                LGA = model.lga,
                SyncStatus = "P",
                IsActive = true,
                ProviderLGA = model.providerLGA,
                ProviderState = model.state,
                ProviderCountry = model.country,
                ProviderName = model.providerName,
                ProviderId = model.providerId,
                PaymentRef = model.paymentReference,
                IsSponsored = 0,
                sponsoredEmail = "",
                SkipOnlinePayment = model.skipOnlinePayment,
                Status = "A",
                EnrolleeAccountId = model.enrolleeIdAccountId,
                MemberNumber = int.Parse(model.memberNumber)


            };

            await _context.Enrollees.AddAsync(enrollee);

            if ((await _context.SaveChangesAsync()) > 0)
                return new ResData
                {
                    enrolleeId = enrollee.EnrolleeId,
                    hasError = false
                };

            return new ResData
            {
                hasError = true
            };
        }

        public async Task<ResData> AddEnrollee(EnrolleePayloadModel model, string sponsorEmail)
        {

            if (string.IsNullOrEmpty(model.memberNumber)) model.memberNumber = "0";

            var enrollee = new Enrollee()
            {
                FirstName = model.firstName,
                Surname = model.surname,
                Address = model.address,
                DateOfBirth = model.dateOfBirth.ToDateTime("dd/MM/yyyy"),// ?? new DateTime(),
                CreatedBy = model.appUser,
                Email = model.email,
                Deleted = false,
                Title = model.title,
                PicturePath = model.pictureUrl,
                PrimaryPhoneNumber = model.phoneNumber,
                City = "",
                Country = model.country,
                State = model.state,
                MiddleName = model.middleName,
                DateCreated = DateTime.Now,
                Gender = model.gender,
                PhoneNumber2 = model.phoneNumber2,
                ProductId = model.productId,
                MailingAddress = model.mailingAddress,
                MailingLGA = model.mailingLga,
                MailingState = model.mailingState,
                MaritalStatus = model.maritalStatus,
                BloodType = model.bloodType,
                EnrolleeType = model.enrolleeType,
                Height = model.height,
                Weight = model.weight.ToString(),
                LGA = model.lga,
                SyncStatus = "P",
                IsActive = true,
                ProviderLGA = model.providerLGA,
                ProviderState = model.state,
                ProviderCountry = model.country,
                ProviderName = model.providerName,
                ProviderId = model.providerId,
                PaymentRef = model.paymentReference,
                IsSponsored = model.isSponsored,
                sponsoredEmail = sponsorEmail,
                SkipOnlinePayment = model.skipOnlinePayment,
                Status = "A",
                EnrolleeAccountId = model.enrolleeIdAccountId,
                MemberNumber = int.Parse(model.memberNumber)


            };

            await _context.Enrollees.AddAsync(enrollee);

            if ((await _context.SaveChangesAsync()) > 0)
                return new ResData
                {
                    enrolleeId = enrollee.EnrolleeId,
                    hasError = false
                };

            return new ResData
            {
                hasError = true
            };
        }
        public async Task<ResData> EditEnrollee(EnrolleePayloadModel model)
        {
            var enrollId = Guid.Parse(model.enrolleeId);

            var enrollee = await _context.Enrollees.FirstOrDefaultAsync(j => j.EnrolleeId == enrollId);

            if (enrollee is not null)
            {
                enrollee.FirstName = model.firstName;
                enrollee.Surname = model.surname;
                enrollee.Address = model.address;
                enrollee.DateOfBirth = model.dateOfBirth.ToDateTime("dd/MM/yyyy");// ?? new DateTime();
                enrollee.Email = model.email;
                enrollee.Deleted = false;
                enrollee.Title = model.title;
                enrollee.PicturePath = model.pictureUrl;
                enrollee.PrimaryPhoneNumber = model.phoneNumber;
                enrollee.Country = model.country;
                enrollee.State = model.state;
                enrollee.MiddleName = model.middleName;
                enrollee.Gender = model.gender;
                enrollee.PhoneNumber2 = model.phoneNumber2;
                enrollee.ProductId = model.productId;
                enrollee.MailingAddress = model.mailingAddress;
                enrollee.MailingLGA = model.mailingLga;
                enrollee.MailingState = model.mailingState;
                enrollee.MaritalStatus = model.maritalStatus;
                enrollee.BloodType = model.bloodType;
                enrollee.EnrolleeType = model.enrolleeType;
                enrollee.Height = model.height;
                enrollee.Weight = model.weight.ToString();
                enrollee.LGA = model.lga;
                enrollee.SyncStatus = "P";
                enrollee.IsActive = true;
                enrollee.ProviderLGA = model.providerLGA;
                enrollee.ProviderState = model.state;
                enrollee.ProviderCountry = model.country;
                enrollee.ProviderName = model.providerName;
            }



            if ((await _context.SaveChangesAsync()) > 0)
                return new ResData
                {
                    enrolleeId = enrollee.EnrolleeId,
                    hasError = false
                };

            return new ResData
            {
                hasError = true
            };
        }
        public async Task UpdateEnrolleeProfilePix(string fileUri, Guid enrolleeId)
        {
            var enrollee = await _context.Enrollees.FirstOrDefaultAsync(o => o.EnrolleeId == enrolleeId);
            if (enrollee != null)
            {
                enrollee.PicturePath = fileUri;
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateTempEnrolleeProfilePix(string fileUri, Guid tempEnrolleeId)
        {
            var enrollee = await _context.TemEnrollee.FirstOrDefaultAsync(o => o.Temp_EnrolleeId == tempEnrolleeId);
            if (enrollee != null)
            {
                enrollee.PicturePath = fileUri;
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateEnrolleeBirthCert(string fileUri, Guid enrolleeId)
        {
            var enrollee = await _context.Enrollees.FirstOrDefaultAsync(o => o.EnrolleeId == enrolleeId);
            if (enrollee != null)
            {
                enrollee.BirthCertificateUrl = fileUri;
                await _context.SaveChangesAsync();
            }
        }
        public IQueryable<EnrolleeViewDTO> GetEnrolleeInfo()
        {
            return _context.Enrollees.AsNoTracking().Select(enrollee => new EnrolleeViewDTO()
            {
                isActive = enrollee.IsActive ?? false,
                enrolleeId = enrollee.EnrolleeId,
                memberNumber = enrollee.MemberNumber ?? 0,
                numberOfBenefact = enrollee.NumberOfBenefact ?? 0,

                providerCountry = enrollee.ProviderCountry,
                providerState = enrollee.ProviderState,
                providerLGA = enrollee.ProviderLGA,
                providerName = enrollee.ProviderName,
                providerId = enrollee.ProductId,

                imageUrl = enrollee.PicturePath,
                firstName = enrollee.FirstName,
                maritalStatus = enrollee.MaritalStatus,
                middleName = enrollee.MiddleName,
                dateOfBirth = enrollee.DateOfBirth,
                bloodType = enrollee.BloodType,
                gender = enrollee.Gender,
                height = enrollee.Height,
                weight = enrollee.Weight,
                surname = enrollee.Surname,
                title = enrollee.Title,

                address = enrollee.Address,
                mailingAddress = enrollee.MailingAddress,
                mailingLga = enrollee.MailingLGA,
                mailingState = enrollee.MailingState,
                email = enrollee.Email,
                country = enrollee.Country,
                lga = enrollee.LGA,
                state = enrollee.State,
                phoneNumber = enrollee.PrimaryPhoneNumber,

                dateCreated = enrollee.DateCreated
            });
        }

        public async Task<EnrolleeViewModel> GetEnrolleeInfoByEnrolleeId(Guid enrolleeId)
        {
            var response = new EnrolleeViewModel();

            var enrolle = from _enrollee in _context.Enrollees.AsNoTracking()
                          join pl in _context.Plans.AsNoTracking()
                          on _enrollee.ProductId equals pl.PlanCode
                          where _enrollee.EnrolleeId == enrolleeId
                          select new TempEnrollee()
                          {
                              isActive = _enrollee.IsActive ?? false,
                              enrolleeId = _enrollee.EnrolleeId,
                              memberNumber = _enrollee.MemberNumber ?? 0,
                              numberOfBenefact = _enrollee.NumberOfBenefact ?? 0,
                              providerCountry = _enrollee.ProviderCountry ?? "",
                              providerState = _enrollee.ProviderState,
                              providerLGA = _enrollee.ProviderLGA,
                              providerName = _enrollee.ProviderName,
                              providerId = _enrollee.ProviderId ?? 0,

                              imageUrl = _enrollee.PicturePath,
                              firstName = _enrollee.FirstName,
                              maritalStatus = _enrollee.MaritalStatus,
                              middleName = _enrollee.MiddleName,
                              dateOfBirth = _enrollee.DateOfBirth,
                              bloodType = _enrollee.BloodType,
                              gender = _enrollee.Gender,
                              height = _enrollee.Height,
                              weight = _enrollee.Weight,
                              surname = _enrollee.Surname,
                              title = _enrollee.Title,

                              address = _enrollee.Address,
                              mailingAddress = _enrollee.MailingAddress,
                              mailingLga = _enrollee.MailingLGA,
                              mailingState = _enrollee.MailingState,
                              email = _enrollee.Email,
                              country = _enrollee.Country,
                              lga = _enrollee.LGA,
                              state = _enrollee.State,
                              phoneNumber = _enrollee.PrimaryPhoneNumber,
                              phoneNumber2 = _enrollee.PhoneNumber2,

                              PlanCode = pl.PlanCode,
                              PlanName = pl.PlanName,
                              PlanRate = pl.Premium,
                              TotalAmount = _enrollee.TotalAmount ?? 0,

                          };


            if (enrolle.Any())
            {

                var enrollee = enrolle.First();

                response.isActive = enrollee.isActive;
                response.enrolleeId = enrollee.enrolleeId;
                response.memberNumber = enrollee.memberNumber;
                response.numberOfBenefact = enrollee.numberOfBenefact;
                response.providerInfo.providerCountry = enrollee.providerCountry;
                response.providerInfo.providerState = enrollee.providerState;
                response.providerInfo.providerLGA = enrollee.providerLGA;
                response.providerInfo.providerName = enrollee.providerName;
                response.providerInfo.providerId = enrollee.providerId;

                response.personalDetail.imageUrl = enrollee.imageUrl;
                response.personalDetail.firstName = enrollee.firstName;
                response.personalDetail.maritalStatus = enrollee.maritalStatus;
                response.personalDetail.middleName = enrollee.middleName;
                response.personalDetail.dateOfBirth = enrollee.dateOfBirth;
                response.personalDetail.bloodType = enrollee.bloodType;
                response.personalDetail.gender = enrollee.gender;
                response.personalDetail.height = enrollee.height;
                response.personalDetail.weight = enrollee.weight;
                response.personalDetail.surname = enrollee.surname;
                response.personalDetail.title = enrollee.title;

                response.contactDetail.address = enrollee.address;
                response.contactDetail.mailingAddress = enrollee.mailingAddress;
                response.contactDetail.mailingLga = enrollee.mailingLga;
                response.contactDetail.mailingState = enrollee.mailingState;
                response.contactDetail.email = enrollee.email;
                response.contactDetail.country = enrollee.country;
                response.contactDetail.lga = enrollee.lga;
                response.contactDetail.state = enrollee.state;
                response.contactDetail.phoneNumber = enrollee.phoneNumber;
                response.contactDetail.phoneNumber2 = enrollee.phoneNumber2;


                response.planDetail.PlanCode = enrollee.PlanCode;
                response.planDetail.PlanName = enrollee.PlanName;
                response.planDetail.PlanRate = enrollee.PlanRate;
                response.planDetail.TotalAmount = enrollee.TotalAmount;
                // response.planDetail

            }

            return response;
        }
        public async Task<PersonalDetailViewModel> GetEnrolleePrincipalInfo(Guid enrolleeId)
        {
            var response = new PersonalDetailViewModel();
            var enrollee = await _context.Enrollees.AsNoTracking().FirstOrDefaultAsync(j => j.EnrolleeId == enrolleeId);
            if (enrollee != null)
            {
                response.imageUrl = enrollee.PicturePath;
                response.firstName = enrollee.FirstName;
                response.maritalStatus = enrollee.MaritalStatus;
                response.middleName = enrollee.MiddleName;
                response.dateOfBirth = enrollee.DateOfBirth;
                response.bloodType = enrollee.BloodType;
                response.gender = enrollee.Gender;
                response.height = enrollee.Height;
                response.weight = enrollee.Weight;
                response.surname = enrollee.Surname;
                response.title = enrollee.Title;
            }

            return response;
        }
        public async Task<ContactDetailView> GetEnrolleeContactInfo(Guid enrolleeId)
        {
            var response = new ContactDetailView();
            var enrollee = await _context.Enrollees.AsNoTracking().FirstOrDefaultAsync(j => j.EnrolleeId == enrolleeId);
            if (enrollee != null)
            {
                response.address = enrollee.Address;
                response.mailingAddress = enrollee.MailingAddress;
                response.mailingLga = enrollee.MailingLGA;
                response.mailingState = enrollee.MailingState;
                response.email = enrollee.Email;
                response.country = enrollee.Country;
                response.lga = enrollee.LGA;
                response.state = enrollee.State;
                response.phoneNumber = enrollee.PrimaryPhoneNumber;
                response.phoneNumber2 = enrollee.PhoneNumber2;
            }

            return response;
        }
        public async Task<ProviderInfo> GetEnrolleeProviderInfoByEnrolleeId(Guid enrolleeId)
        {
            var response = new ProviderInfo();
            var enrollee = await _context.Enrollees.AsNoTracking().FirstOrDefaultAsync(j => j.EnrolleeId == enrolleeId);
            if (enrollee != null)
            {
                response.providerCountry = enrollee.ProviderCountry;
                response.providerState = enrollee.ProviderState;
                response.providerLGA = enrollee.ProviderLGA;
                response.providerName = enrollee.ProviderName;
                response.providerId = enrollee.ProductId;
            }

            return response;
        }
        public async Task<EnrolleeSub> GetEnrolleeSubByEnrolleeId(Guid enrolleeId)
        {
            var response = new EnrolleeSub();
            var enrollee = await _context.Enrollees.AsNoTracking().FirstOrDefaultAsync(j => j.EnrolleeId == enrolleeId);
            if (enrollee != null)
            {
                var product = await _context.Plans.FirstOrDefaultAsync(h => h.PlanCode == enrollee.ProductId);

                response.planName = product.PlanName;
                response.planId = product.PlanCode;
                response.firstName = enrollee.FirstName;
                response.middleName = enrollee.MiddleName;
                response.surname = enrollee.Surname;
                response.enrolleeId = enrollee.EnrolleeId;
            }

            return response;
        }
        public async Task<bool> HasActiveSubscription(string email)
        {
            return (await _context.Enrollees.AsNoTracking().AnyAsync(j => j.Email == email));
        }

        public async Task<PrincipalDetailAddedDTO> AddPrincipalDetailExplore(PrincipalDetailExploreModel model)
        {

            var response = new PrincipalDetailAddedDTO();

            var principalDetail = new Order()
            {
                FirstName = model.firstName,
                Surname = model.surname,
                MaritalStatus = model.maritalStatus,
                MiddleName = model.middleName,
                Title = model.title,
                Gender = model.gender,
                Email = model.email,
                Address = model.address,
                City = model.city,
                PhoneNumber = model.phoneNumber,
                Country = model.country,
                State = model.state,
                DateOfBirth = model.dateOfBirth.ToDateTime("dd/MM/yyyy"),
                OrderReference = StringExtensions.RandomString(20, true, true, true, false),
                DateCreated = DateTime.Now,
                CreatedBy = String.Empty,
                OrderDate = DateTime.Now,
                ProductId = model.productId,
                PicturePath = model.profilePictureUri,
                IsSponsored = model.isSponsor,
                sponsoredEmail = "",

            };

            await _context.Orders.AddAsync(principalDetail);

            if (await _context.SaveChangesAsync() > 0)
            {
                response.HasError = false;
                response.OrderReference = principalDetail.OrderReference;
                response.OrderId = principalDetail.OrderId;
                response.ProductId = principalDetail.ProductId;
            }

            return response;
        }
        public async Task<PrincipalDetailAddedDTO> AddPrincipalDetail(PrincipalDetailViewModel model, string loginUser)
        {

            var response = new PrincipalDetailAddedDTO();
            _ = Guid.TryParse(loginUser, out Guid logon);
            var _loginUser = await _context.ApplicationUsers.FirstOrDefaultAsync(m => m.UserId == logon);

            var principalDetail = new Order()
            {
                FirstName = model.firstName,
                Surname = model.surname,
                MaritalStatus = model.maritalStatus,
                MiddleName = model.middleName,
                Title = model.title,
                Gender = model.gender,
                Email = model.email,
                Address = model.address,
                City = model.city,
                PhoneNumber = model.phoneNumber,
                Country = model.country,
                State = model.state,
                DateOfBirth = model.dateOfBirth.ToDateTime("dd/MM/yyyy"),
                OrderReference = StringExtensions.RandomString(20, true, true, true, false),
                DateCreated = DateTime.Now,
                CreatedBy = model.createdBy,
                OrderDate = DateTime.Now,
                ProductId = model.productId,
                PicturePath = model.profilePictureUri,
                IsSponsored = model.isSponsor,
                sponsoredEmail = model.isSponsor == 1 ? (_loginUser != null ? _loginUser.Email : "") : "",

            };

            await _context.Orders.AddAsync(principalDetail);

            if (await _context.SaveChangesAsync() > 0)
            {
                response.HasError = false;
                response.OrderReference = principalDetail.OrderReference;
                response.OrderId = principalDetail.OrderId;
                response.ProductId = principalDetail.ProductId;
            }

            return response;
        }

        public async Task<PrincipalDetailOtherAddedDTO> AddSponsorPrincipalDetail(PrincipalSponsorDetailModel model)
        {
            var response = new PrincipalDetailOtherAddedDTO();

            var enrollee = new Enrollee()
            {
                FirstName = model.firstName,
                Surname = model.surname,
                Address = model.address,
                DateOfBirth = model.dateOfBirth.ToDateTime("dd/MM/yyyy"),
                Email = model.email,
                Deleted = false,
                Title = model.title,
                PrimaryPhoneNumber = model.phoneNumber,
                City = model.city,
                Country = model.country,
                State = model.state,
                MiddleName = model.middleName,
                DateCreated = DateTime.Now,
                Gender = model.gender,
                EnrolleeAccountId = new Guid(),
                ProductId = model.productId,
                OrderRef = model.OrderPaymentRefrence,
                PaymentRef = model.OrderPaymentRefrence,
                IsSponsored = model.isSponsor,
                sponsoredEmail = model.sponsorEmail,
                IsActive = true,
            };
            await _context.Enrollees.AddAsync(enrollee);
            if (await _context.SaveChangesAsync() > 0)
            {

                try
                {
                    //log in SubscriptionHistory
                    var subHistory = new SubscriptionHistory()
                    {
                        PaymentMethod = enrollee.PaymentRef,
                        PaymentReference = enrollee.OrderRef,
                        PlanId = model.productId,
                        AmountPaid = 0,
                        DateTime = DateTime.Now,
                        Email = enrollee.Email,
                        OrderReference = enrollee.OrderRef,
                        Type = "New Purchase",
                        userId = enrollee.EnrolleeAccountId.ToString(),
                        EnrolleeName = $"{enrollee.Surname} {enrollee.MiddleName} {enrollee.FirstName}",

                    };
                    await _context.SubscriptionHistories.AddAsync(subHistory);
                    await _context.SaveChangesAsync();

                }
                catch
                {

                }

                response.HasError = false;
                response.OrderReference = enrollee.OrderRef;
                response.enrolleeId = enrollee.EnrolleeId.ToString();
                response.ProductId = enrollee.ProductId;
            }

            return response;
        }

        public async Task<PrincipalDetailOtherAddedDTO> AddOtherPrincipalDetailExplore(PrincipalDetailModelExplore model)
        {
            var response = new PrincipalDetailOtherAddedDTO();

            var enrollee = new Enrollee()
            {
                FirstName = model.firstName,
                Surname = model.surname,
                Address = model.address,
                DateOfBirth = model.dateOfBirth.ToDateTime("dd/MM/yyyy"),
                CreatedBy = "",
                Email = model.email,
                Deleted = false,
                Title = model.title,
                PrimaryPhoneNumber = model.phoneNumber,
                City = model.city,
                Country = model.country,
                State = model.state,
                MiddleName = model.middleName,
                DateCreated = DateTime.Now,
                Gender = model.gender,
                EnrolleeAccountId = new Guid(),
                ProductId = model.productId,
                OrderRef = model.orderReference,
                IsSponsored = model.isSponsor,
                sponsoredEmail = model.sponsorEmail,
                IsActive = true,
            };
            await _context.Enrollees.AddAsync(enrollee);
            if (await _context.SaveChangesAsync() > 0)
            {
                try
                {
                    //log in SubscriptionHistory
                    var subHistory = new SubscriptionHistory()
                    {
                        PaymentMethod = enrollee.PaymentRef,
                        PaymentReference = enrollee.OrderRef,
                        PlanId = model.productId,
                        AmountPaid = 0,
                        DateTime = DateTime.Now,
                        Email = enrollee.Email,
                        OrderReference = enrollee.OrderRef,
                        Type = "New Purchase",
                        userId = enrollee.EnrolleeAccountId.ToString(),
                        EnrolleeName = $"{enrollee.Surname} {enrollee.MiddleName} {enrollee.FirstName}",

                    };
                    await _context.SubscriptionHistories.AddAsync(subHistory);
                    await _context.SaveChangesAsync();

                }
                catch
                {

                }

                response.HasError = false;
                response.OrderReference = enrollee.OrderRef;
                response.enrolleeId = enrollee.EnrolleeId.ToString();
                response.ProductId = enrollee.ProductId;
            }

            return response;
        }
        public async Task<PrincipalDetailOtherAddedDTO> AddOtherPrincipalDetail(PrincipalDetailViewModelDTO model, string loginUser)
        {
            var response = new PrincipalDetailOtherAddedDTO();
            _ = Guid.TryParse(loginUser, out Guid logon);
            var _loginUser = await _context.ApplicationUsers.FirstOrDefaultAsync(m => m.UserId == logon);
            var enrollee = new Enrollee()
            {
                FirstName = model.firstName,
                Surname = model.surname,
                Address = model.address,
                DateOfBirth = model.dateOfBirth.ToDateTime("dd/MM/yyyy"),
                CreatedBy = _loginUser != null ? _loginUser.Email : "",
                Email = model.email,
                Deleted = false,
                Title = model.title,
                PrimaryPhoneNumber = model.phoneNumber,
                City = model.city,
                Country = model.country,
                State = model.state,
                MiddleName = model.middleName,
                DateCreated = DateTime.Now,
                Gender = model.gender,
                EnrolleeAccountId = model.isSponsor == 1 ? new Guid() : (_loginUser == null ? new Guid() : _loginUser.UserId),
                ProductId = model.productId,
                OrderRef = model.orderReference,
                IsSponsored = model.isSponsor,
                sponsoredEmail = model.isSponsor == 1 ? (_loginUser != null ? _loginUser.Email : "") : "",
                IsActive = true,
            };
            await _context.Enrollees.AddAsync(enrollee);
            if (await _context.SaveChangesAsync() > 0)
            {
                try
                {
                    //log in SubscriptionHistory
                    var subHistory = new SubscriptionHistory()
                    {
                        PaymentMethod = enrollee.PaymentRef,
                        PaymentReference = enrollee.OrderRef,
                        PlanId = model.productId,
                        AmountPaid = 0,
                        DateTime = DateTime.Now,
                        Email = enrollee.Email,
                        OrderReference = enrollee.OrderRef,
                        Type = "New Purchase",
                        userId = enrollee.EnrolleeAccountId.ToString(),
                        EnrolleeName = $"{enrollee.Surname} {enrollee.MiddleName} {enrollee.FirstName}",

                    };
                    await _context.SubscriptionHistories.AddAsync(subHistory);
                    await _context.SaveChangesAsync();

                }
                catch
                {

                }

                response.HasError = false;
                response.OrderReference = enrollee.OrderRef;
                response.enrolleeId = enrollee.EnrolleeId.ToString();
                response.ProductId = enrollee.ProductId;
            }

            return response;
        }
        public async Task<bool> AddBulkPlan(BuyPlanModel model, List<providerDetailDTO> providers)
        {

            var paymentLog = new BulkPaymentLog()
            {
                NoOfPlans = model.noOfPlans,
                PaymentMethod = model.paymentMethod,
                PaymentDate = DateTime.Now,
                TotalAmount = model.totalAmount,
                PaymentReference = model.paymentReference,
            };

            await _context.BulkPaymentLogs.AddAsync(paymentLog);
            if (await _context.SaveChangesAsync() > 0)
            {
                var enrollees = new List<Enrollee>();

                foreach (var item in model.subscriptions)
                {
                    var provider = providers.FirstOrDefault(k => k.ProviderId == item.providerId);
                    var erollee = new Enrollee()
                    {
                        FirstName = item.firstName,
                        Surname = item.surname,
                        MaritalStatus = item.maritalStatus,
                        MiddleName = item.middleName,
                        Title = item.title,
                        Gender = item.gender,
                        Country = item.country,
                        DateOfBirth = item.dateOfBirth.ToDateTime("dd/MM/yyyy"),
                        DateCreated = DateTime.Now,
                        ProductId = item.productId,
                        City = item.city,
                        TotalAmount = item.amount,
                        nhis = item.nhis,
                        PlanRate = item.planRate,
                        Email = item.email,
                        PrimaryPhoneNumber = item.phoneNumber,
                        Address = item.address,
                        State = item.state,
                        LGA = item.lga,
                        MailingAddress = item.mailingAddress,
                        BloodType = item.bloodType,
                        MailingLGA = item.mailingLga,
                        MailingState = item.mailingState,
                        BulkPaymentLogId = paymentLog.BulkPaymentLogId,
                        Deleted = false,
                        PhoneNumber2 = item.phoneNumber2,
                        ProviderId = item.providerId,
                        Height = item.height,
                        Weight = item.weight,
                        IsActive = true,
                        PicturePath = item.imageUrl,

                        IsSponsored = item.isSponsored,
                        sponsoredEmail = item.sponsorEmail,

                        SkipOnlinePayment = item.skipOnlinePayment,
                        ProviderName = provider.ProviderName,
                        ProviderLGA = provider.ProviderLGA,
                        ProviderState = provider.ProviderState,
                    };

                    enrollees.Add(erollee);
                }

                await _context.Enrollees.AddRangeAsync(enrollees);

            }
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> IsOrderWithRefExist(string orderRef)
        {
            return (await _context.Orders.AsNoTracking().AnyAsync(m => m.OrderReference == orderRef));
        }
        public async Task<bool> IsPaymentOrderWithRefExist(string orderRef)
        {
            return (await _context.TemEnrollee.AsNoTracking().AnyAsync(m => m.OrderPaymentRefrence == orderRef));
        }

        public async Task<CompletePlanSubscriptionResponseDTO> CompletePlanPurchaseExplore(CompletePlanSubscriptionDto model)
        {


            var order = await _context.Orders.FirstOrDefaultAsync(m => m.OrderReference == model.OrderReference && m.PaymentStatus != "A");
            if (order == null)
                throw new Exception($"order With Refrence:{model.OrderReference} Could Not Be found");


            order.Amount = model.Amount;
            order.NHISAmount = model.NHISAmount;
            order.TotalAmount = model.TotalAmount;
            order.PaymentMethod = model.PaymentMethod;
            order.UpdatedBy = "";
            order.PaymentStatus = "A";
            order.PaymentReference = model.PaymentReference;

            var enrollee = new Enrollee()
            {
                FirstName = order.FirstName,
                Surname = order.Surname,
                Address = order.Address,
                DateOfBirth = order.DateOfBirth ?? new DateTime(),
                CreatedBy = order.CreatedBy,
                Email = order.Email,
                Deleted = false,
                Title = order.Title,
                PicturePath = order.PicturePath,
                PrimaryPhoneNumber = order.PhoneNumber,
                City = order.City,
                Country = order.Country,
                State = order.State,
                MiddleName = order.MiddleName,
                DateCreated = DateTime.Now,
                ClientId = order.ClientId,
                Gender = order.Gender,
                EnrolleeAccountId = new Guid(),
                ProductId = order.ProductId,
                TotalAmount = order.TotalAmount,
                OrderRef = order.OrderReference,
                IsSponsored = order.IsSponsored,
                sponsoredEmail = order.sponsoredEmail,
                IsActive = true,
            };

            await _context.Enrollees.AddAsync(enrollee);

            if (await _context.SaveChangesAsync() > 0)
            {
                try
                {
                    //log in SubscriptionHistory
                    var subHistory = new SubscriptionHistory()
                    {
                        PaymentMethod = model.PaymentMethod,
                        PaymentReference = model.PaymentReference,
                        PlanId = model.ProductId,
                        AmountPaid = model.TotalAmount,
                        DateTime = DateTime.Now,
                        Email = enrollee.Email,
                        OrderReference = enrollee.OrderRef,
                        Type = "New Purchase",
                        userId = enrollee.EnrolleeAccountId.ToString(),
                        EnrolleeName = $"{enrollee.Surname} {enrollee.MiddleName} {enrollee.FirstName}",

                    };
                    await _context.SubscriptionHistories.AddAsync(subHistory);
                    await _context.SaveChangesAsync();

                }
                catch
                {

                }
                return new CompletePlanSubscriptionResponseDTO()
                {
                    orderId = order.OrderId,
                    orderReference = order.OrderReference,
                    enrolleeId = enrollee.EnrolleeId,
                    paymentReference = order.PaymentReference,
                    productId = order.ProductId,
                    email = enrollee.Email,
                    hasError = false,
                    firstName = enrollee.FirstName,
                    lastName = enrollee.Surname,
                    // createAcct = order.IsSponsored == 1
                };
            }


            return new CompletePlanSubscriptionResponseDTO()
            {
                hasError = true
            };
        }
        public async Task<CompletePlanSubscriptionResponseDTO> CompletePlanPurchase(CompletePlanSubscriptionDto model, string user)
        {


            var order = await _context.Orders.FirstOrDefaultAsync(m => m.OrderReference == model.OrderReference && m.PaymentStatus != "A");
            if (order == null)
                throw new Exception($"order With Refrence:{model.OrderReference} Could Not Be found");
            user = user.ToLower();
            var userinfo = _context.ApplicationUsers.FirstOrDefault(m => m.UserName.ToLower() == user);


            order.Amount = model.Amount;
            order.NHISAmount = model.NHISAmount;
            order.TotalAmount = model.TotalAmount;
            order.PaymentMethod = model.PaymentMethod;
            order.UpdatedBy = userinfo == null ? "" : userinfo.UserName;
            order.PaymentStatus = "A";
            order.PaymentReference = model.PaymentReference;

            var enrollee = new Enrollee()
            {
                FirstName = order.FirstName,
                Surname = order.Surname,
                Address = order.Address,
                DateOfBirth = order.DateOfBirth ?? new DateTime(),
                CreatedBy = order.CreatedBy,
                Email = string.IsNullOrWhiteSpace(order.Email) ? (userinfo == null ? "" : userinfo.Email) : order.Email,
                Deleted = false,
                Title = order.Title,
                PicturePath = order.PicturePath,
                PrimaryPhoneNumber = order.PhoneNumber,
                City = order.City,
                Country = order.Country,
                State = order.State,
                MiddleName = order.MiddleName,
                DateCreated = DateTime.Now,
                ClientId = order.ClientId,
                Gender = order.Gender,
                EnrolleeAccountId = order.IsSponsored == 1 ? new Guid() : (userinfo == null ? new Guid() : userinfo.UserId),
                ProductId = order.ProductId,
                TotalAmount = order.TotalAmount,
                OrderRef = order.OrderReference,
                IsSponsored = order.IsSponsored,
                sponsoredEmail = order.sponsoredEmail,
                IsActive = true,
            };

            await _context.Enrollees.AddAsync(enrollee);

            if (await _context.SaveChangesAsync() > 0)
            {
                try
                {
                    //log in SubscriptionHistory
                    var subHistory = new SubscriptionHistory()
                    {
                        PaymentMethod = model.PaymentMethod,
                        PaymentReference = model.PaymentReference,
                        PlanId = model.ProductId,
                        AmountPaid = model.TotalAmount,
                        DateTime = DateTime.Now,
                        Email = enrollee.Email,
                        OrderReference = enrollee.OrderRef,
                        Type = "New Purchase",
                        userId = enrollee.EnrolleeAccountId.ToString(),
                        EnrolleeName = $"{enrollee.Surname} {enrollee.MiddleName} {enrollee.FirstName}",

                    };
                    await _context.SubscriptionHistories.AddAsync(subHistory);
                    await _context.SaveChangesAsync();

                }
                catch 
                {

                }
                return new CompletePlanSubscriptionResponseDTO()
                {
                    orderId = order.OrderId,
                    orderReference = order.OrderReference,
                    enrolleeId = enrollee.EnrolleeId,
                    paymentReference = order.PaymentReference,
                    productId = order.ProductId,
                    email = enrollee.Email,
                    hasError = false,
                    firstName = enrollee.FirstName,
                    lastName = enrollee.Surname,
                    createAcct = order.IsSponsored == 1
                };
            }


            return new CompletePlanSubscriptionResponseDTO()
            {
                hasError = true
            };
        }
        public async Task<CompletePlanRenewalRes> RenewPlan(CompletePlanRenewal model, string user)
        {
            var enrollee = _context.Enrollees.FirstOrDefault(m => m.EnrolleeId == model.enrolleeId);
            if (enrollee != null)
            {
                enrollee.ProductId = model.NewPlanId;
                enrollee.PaymentRef = model.PaymentReference;
                enrollee.TotalAmount = model.Amount + model.NHISAmount;
                enrollee.nhis = model.NHISAmount;
                enrollee.PlanRate = model.Amount;
                enrollee.UpdatedBy = user;

                await _context.SaveChangesAsync();

                try
                {
                    //log in SubscriptionHistory
                    var subHistory = new SubscriptionHistory()
                    {
                        PaymentMethod = enrollee.PaymentRef,
                        PaymentReference = enrollee.OrderRef,
                        PlanId = model.NewPlanId,
                        AmountPaid = enrollee.TotalAmount ?? 0,
                        DateTime = DateTime.Now,
                        Email = enrollee.Email,
                        OrderReference = enrollee.OrderRef,
                        Type = "Renewal",
                        userId = enrollee.EnrolleeAccountId.ToString(),
                        EnrolleeName = $"{enrollee.Surname} {enrollee.MiddleName} {enrollee.FirstName}",

                    };
                    await _context.SubscriptionHistories.AddAsync(subHistory);
                    await _context.SaveChangesAsync();
                }
                catch
                {

                }

                return new CompletePlanRenewalRes() 
                {
                    hasError = false,
                    email= enrollee.Email,
                    firstName=enrollee.FirstName,
                    lastName=enrollee.Surname,
                };
            }

            return new CompletePlanRenewalRes()
            {
                hasError = true,
            };
        }
        public async Task<CompletePlanSubscriptionResponseDTO> CompletePlanPay(CompletePlanPayment model)
        {

            var order = await _context.TemEnrollee.FirstOrDefaultAsync(m => m.OrderPaymentRefrence == model.OrderPaymentRefrence && m.Status != "A");
            if (order == null)
                throw new Exception($"order With Refrence:{model.OrderPaymentRefrence} Could Not Be found");



            order.TotalAmount = model.Amount;
            order.nhis = model.NHISAmount;
            order.PaymentMethod = model.PaymentMethod;
            order.Status = "A";
            order.TransactionRef = model.TransactionReference;

            var enrollee = new Enrollee()
            {
                FirstName = order.FirstName,
                Surname = order.Surname,
                Address = order.Address,
                DateOfBirth = order.DateOfBirth,// order.DateOfBirth ?? new DateTime(),
                                                // CreatedBy = order.CreatedBy,
                Email = order.Email,
                Deleted = false,
                Title = order.Title,
                PicturePath = order.PicturePath,
                PrimaryPhoneNumber = order.PrimaryPhoneNumber,
                City = order.City,
                Country = order.Country,
                State = order.State,
                MiddleName = order.MiddleName,
                DateCreated = DateTime.Now,
                ClientId = order.ClientId,
                Gender = order.Gender,
                EnrolleeAccountId = new Guid(),
                ProductId = order.ProductId,
                TotalAmount = order.TotalAmount,
                OrderRef = order.OrderPaymentRefrence,
                PaymentRef = order.OrderPaymentRefrence,
                IsSponsored = order.IsSponsored,
                sponsoredEmail = order.sponsoredEmail,
                IsActive = true,
                MailingAddress = order.MailingAddress,
                MailingLGA = order.MailingLGA,
                MailingState = order.MailingState,
                MaritalStatus = order.MaritalStatus,
                MemberNumber = order.MemberNumber,
                BirthCertificateUrl = order.BirthCertificateUrl,
                BloodType = order.BloodType,
                Height = order.Height,
                nhis = order.nhis,
                LGA = order.LGA,
                EnrolleeType = order.EnrolleeType,
                ProviderLGA = order.ProviderLGA,
                PlanRate = order.PlanRate,
                ProviderId = order.ProviderId,
                ProviderCountry = order.ProviderCountry,
                ProviderName = order.ProviderName,
                ProviderState = order.ProviderState,
                Weight = order.Weight,
                Status = "A",

            };

            await _context.Enrollees.AddAsync(enrollee);

            if (await _context.SaveChangesAsync() > 0)
            {
                try
                {
                    //log in SubscriptionHistory
                    var subHistory = new SubscriptionHistory()
                    {
                        PaymentMethod = model.PaymentMethod,
                        PaymentReference = model.TransactionReference,
                        PlanId = model.ProductId,
                        AmountPaid = model.Amount + model.NHISAmount,
                        DateTime = DateTime.Now,
                        Email = enrollee.Email,
                        OrderReference = enrollee.OrderRef,
                        Type = "New Purchase",
                        userId = enrollee.EnrolleeAccountId.ToString(),
                        EnrolleeName = $"{enrollee.Surname} {enrollee.MiddleName} {enrollee.FirstName}",

                    };
                    await _context.SubscriptionHistories.AddAsync(subHistory);
                    await _context.SaveChangesAsync();

                }
                catch
                {

                }
                return new CompletePlanSubscriptionResponseDTO()
                {
                    orderReference = order.OrderPaymentRefrence,
                    enrolleeId = enrollee.EnrolleeId,
                    paymentReference = order.OrderPaymentRefrence,
                    productId = order.ProductId,
                    email = enrollee.Email,
                    hasError = false,
                    firstName = enrollee.FirstName,
                    lastName = enrollee.Surname,
                };
            }


            return new CompletePlanSubscriptionResponseDTO()
            {
                hasError = true
            };
        }

        public async Task UpdatePrinciDetailProfilePix(string fileUri, Guid orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
            if (order != null)
            {
                order.PicturePath = fileUri;
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdatePrinciDetailOthersProfilePix(string fileUri, string enrolleeId)
        {
            _ = Guid.TryParse(enrolleeId, out Guid _enrolleeId);
            var enrollee = await _context.Enrollees.FirstOrDefaultAsync(o => o.EnrolleeId == _enrolleeId);
            if (enrollee != null)
            {
                enrollee.PicturePath = fileUri;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> UpdateEnrolleeContactDetail(EnrolleeContactDetailViewModel model)
        {
            var enrollee = await _context.Enrollees.FirstOrDefaultAsync(m => m.EnrolleeId == model.enrolleeId);
            if (enrollee != null)
            {
                enrollee.Email = model.email;
                enrollee.PrimaryPhoneNumber = model.phoneNumber;
                enrollee.Address = model.residentAddress;
                enrollee.State = model.state;
                enrollee.LGA = model.lga;
                enrollee.MailingAddress = model.mailingAddress;
                await _context.SaveChangesAsync();
            }

            var res = await _context.SaveChangesAsync() > 0;

            return res;

        }
        public async Task<bool> UpdateEnrolleeProviderDetail(EnrolleeProviderViewModel model)
        {
            var enrollee = await _context.Enrollees.FirstOrDefaultAsync(m => m.EnrolleeId == model.enrolleeId);
            if (enrollee != null)
            {
                enrollee.ProviderId = model.providerCode;
                await _context.SaveChangesAsync();
            }
            var res = await _context.SaveChangesAsync() > 0;
            return res;
        }
        public async Task<List<EnrolleeViewModelDTO>> GetEnrollee()
        {
            var enrollee = await _context.Enrollees.AsNoTracking().Select(m => new EnrolleeViewModelDTO()
            {
                enrolleeId = m.EnrolleeId,
                firstName = m.FirstName,
                providerId = m.ProviderId,
                email = m.Email,
                enrolleeAccountId = m.EnrolleeAccountId,
                memberNumber = m.MemberNumber

            }).ToListAsync();
            return enrollee;
        }

        public async Task<PendingRegistrationModel> GetEnrolleependingTasks(Guid enrolleeId)
        {
            var res = new PendingRegistrationModel();
            var pendings = new List<string>();
            var enrollee = await _context.Enrollees.AsNoTracking().FirstOrDefaultAsync(m => m.EnrolleeId == enrolleeId);
            if (enrollee != null)
            {
                if (string.IsNullOrWhiteSpace(enrollee.Address) && string.IsNullOrWhiteSpace(enrollee.State) && string.IsNullOrWhiteSpace(enrollee.LGA))
                    pendings.Add("Pending Contact Detail");

                if ((enrollee.ProviderId ?? 0) <= 0)
                    pendings.Add("Pending Provider");
            }

            res.hasIncompleteRegistration = pendings.Count() > 0;
            res.pendingTasks = pendings;

            return res;
        }
        public async Task<bool> ChangePrimaryProvider(ChangeProviderRequestViewModel model)
        {
            var request = new ChangePrimaryProviderRequest()
            {
                MemberNumber = model.MemberNo,
                MemberEmail = model.MemberEmail,
                CurrentProviderCode = model.CurrentProviderCode,
                CurrentProviderName = model.CurrentProviderName,
                NewProviderCode = model.NewProviderCode,
                NewProviderName = model.NewProviderName,
                RequestDate = DateTime.Now,
                RequestStatus = "P",
                EnrolleeId = model.EnrolleeId
            };

            await _context.ChangePrimaryProviderRequests.AddAsync(request);

            return (await _context.SaveChangesAsync()) > 0;
        }


        public async Task<List<ChangeProviderRequestViewModel>> GetChangePrimaryProviderRequestByMemberNo(int memberNo)
        {
            var requests = await _context.ChangePrimaryProviderRequests.AsNoTracking()
                .Where(k => k.MemberNumber == memberNo)
                .Select(k => new ChangeProviderRequestViewModel()
                {
                    RequestStatus = k.RequestStatus,
                    CurrentProviderCode = k.CurrentProviderCode,
                    ChangeProviderRequestId = k.ChangeProviderRequestId,
                    MemberEmail = k.MemberEmail,
                    CurrentProviderName = k.CurrentProviderName,
                    MemberNo = k.MemberNumber,
                    NewProviderCode = k.NewProviderCode,
                    EnrolleeId = k.EnrolleeId,
                    NewProviderName = k.NewProviderName,
                    RequestDate = k.RequestDate
                }).ToListAsync();
            return requests;
        }

        public async Task<List<ChangeProviderRequestViewModel>> GetChangePrimaryProviderRequestByEnrolleeId(Guid enrolleeId)
        {
            var requests = await _context.ChangePrimaryProviderRequests.AsNoTracking()
                .Where(k => k.EnrolleeId == enrolleeId)
                .Select(k => new ChangeProviderRequestViewModel()
                {
                    RequestStatus = k.RequestStatus,
                    CurrentProviderCode = k.CurrentProviderCode,
                    ChangeProviderRequestId = k.ChangeProviderRequestId,
                    MemberEmail = k.MemberEmail,
                    CurrentProviderName = k.CurrentProviderName,
                    MemberNo = k.MemberNumber,
                    NewProviderCode = k.NewProviderCode,
                    EnrolleeId = k.EnrolleeId,
                    NewProviderName = k.NewProviderName,
                    RequestDate = k.RequestDate
                }).ToListAsync();
            return requests;
        }
        public async Task<List<ChangeProviderRequestViewModel>> GetChangePrimaryProviderRequestByRequestId(Guid ChangeProviderRequestId)
        {
            var requests = await _context.ChangePrimaryProviderRequests.AsNoTracking()
                .Where(k => k.ChangeProviderRequestId == ChangeProviderRequestId)
                .Select(k => new ChangeProviderRequestViewModel()
                {
                    RequestStatus = k.RequestStatus,
                    CurrentProviderCode = k.CurrentProviderCode,
                    ChangeProviderRequestId = k.ChangeProviderRequestId,
                    MemberEmail = k.MemberEmail,
                    CurrentProviderName = k.CurrentProviderName,
                    MemberNo = k.MemberNumber,
                    NewProviderCode = k.NewProviderCode,
                    EnrolleeId = k.EnrolleeId,
                    NewProviderName = k.NewProviderName,
                    RequestDate = k.RequestDate
                }).ToListAsync();
            return requests;
        }

        public async Task<List<CyclePlannerCategoryViewModel>> GetCyclePlannerCategories()
        {
            var requests = await _context.CyclePlannerCategories.AsNoTracking()
                .Select(k => new CyclePlannerCategoryViewModel()
                {
                    cyclePlannerCategoryId = k.CyclePlannerCategoryId,
                    description = k.Description,
                }).ToListAsync();
            return requests;
        }


        public async Task<bool> UpdateCycleInfo(CycleInfoRequestModel model, Guid userid)
        {
            var cycleId = Guid.Parse(model.cycleId);
            var cycleInfo = await _context.CycleInfos.FirstOrDefaultAsync(m => m.CycleId == cycleId);
            if (cycleInfo == null) return false;

            cycleInfo.PeriodCycle = model.periodCycle;
            cycleInfo.PeriodDuration = model.periodDuration;
            cycleInfo.PeriodStartDate = model.periodStartDate.ToDateTime("dd/MM/yyyy");

            return (await _context.SaveChangesAsync()) > 0;
        }
        public async Task<CycleInfoResponseDTO> AddCycleInfo(CycleInfoRequestModel model, Guid userid)
        {
            var res = new CycleInfoResponseDTO();
            var request = new CycleInfo()
            {
                AppuserId = userid,
                DateCreated = DateTime.Now,
                PeriodCycle = model.periodCycle,
                PeriodDuration = model.periodDuration,
                PeriodStartDate = model.periodStartDate.ToDateTime("dd/MM/yyyy"),
                CyclePlannerCategoryId = model.CyclePlannerCategoryId
            };

            await _context.CycleInfos.AddAsync(request);
            var actn = await _context.SaveChangesAsync();
            if (actn > 0)
            {
                res.cycleId = request.CycleId;
                res.hasError = false;

                return res;
            }
            res.hasError = true;
            return res;
        }

        public async Task<List<CycleInfoViewModel>> GetCycleInfoByCycleId(Guid cycleId)
        {
            return (await _context.CycleInfos.Where(k => k.CycleId == cycleId)
                .OrderByDescending(l => l.DateCreated).Select(m => new CycleInfoViewModel()
                {
                    cycleId = m.CycleId,
                    periodDuration = m.PeriodDuration,
                    periodCycle = m.PeriodCycle,
                    periodStartDate = m.PeriodStartDate,
                    CyclePlannerCategoryId = m.CyclePlannerCategoryId,
                }).ToListAsync());
        }
        public async Task<List<CycleInfoViewModel>> GetCycleInfo(Guid userid)
        {
            return (await _context.CycleInfos.Where(k => k.AppuserId == userid)
                .OrderByDescending(l => l.PeriodStartDate)
                .Select(m => new CycleInfoViewModel()
                {
                    cycleId = m.CycleId,
                    periodDuration = m.PeriodDuration,
                    periodCycle = m.PeriodCycle,
                    periodStartDate = m.PeriodStartDate,
                    CyclePlannerCategoryId = m.CyclePlannerCategoryId,
                }).ToListAsync());
        }
        public async Task<CycleInfoViewModel> GetRecentCycleInfo(Guid userid)
        {
            return (await _context.CycleInfos.Where(k => k.AppuserId == userid)
                .OrderByDescending(l => l.PeriodStartDate)
                .Select(m => new CycleInfoViewModel()
                {
                    cycleId = m.CycleId,
                    periodDuration = m.PeriodDuration,
                    periodCycle = m.PeriodCycle,
                    periodStartDate = m.PeriodStartDate,
                    CyclePlannerCategoryId = m.CyclePlannerCategoryId,

                }).FirstOrDefaultAsync());
        }

        public async Task<NextPeriodInfoViewModel> GetNextPeriodInfo(Guid userId)
        {
            var cycleinfo = await _context.CycleInfos.Where(k => k.AppuserId == userId)
                .OrderByDescending(m => m.PeriodStartDate)
                .Take(10).ToListAsync();
            if (cycleinfo == null || !cycleinfo.Any()) return new NextPeriodInfoViewModel();
            var lastCycleInfo = cycleinfo.FirstOrDefault();
            var averageCycle = (int)Math.Round(cycleinfo.Average(m => m.PeriodCycle), 0);
            var averageduration = (int)Math.Round(cycleinfo.Average(m => m.PeriodDuration), 0);

            var response = new NextPeriodInfoViewModel()
            {
                averageperiodCycle = averageCycle,
                averageperiodDuration = averageduration,
                nextPeriodStartDate = lastCycleInfo.PeriodStartDate.AddDays(averageCycle),
                nextOvulationDate = lastCycleInfo.PeriodStartDate.AddDays(averageCycle - 14),
                lastPeriodStartDate = lastCycleInfo.PeriodStartDate,
            };

            return response;
        }

        #region EnrolleeFlow
        /// <summary> Capture a RequestAuthorization
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 13-01-2022 7:00PM
        /// </remarks>
        public async Task<bool> CreateRequestAuthorization(RequestAuthorizationViewModel reqAuth, Guid enrolleeID)
        {

            var requestAuthorization = new RequestAuthorization()
            {
                EnrolleeId = enrolleeID,
                AvonEnrolleId = reqAuth.AvonEnrolleId,
                FirstName = reqAuth.FirstName,
                PhoneNumber = reqAuth.PhoneNumber,
                Email = reqAuth.Email,
                MemberNo = reqAuth.MemberNo,
                ProviderId = reqAuth.ProviderId,
                PACode = reqAuth.PaCode ?? ""

            };

            await _context.RequestAuthorizations.AddAsync(requestAuthorization);



            var res = await _context.SaveChangesAsync() > 0;
            return res;
        }
        public async Task<List<RequestAuthorizationModel>> GetRequestAuthorization()
        {
            var requests = await _context.RequestAuthorizations.AsNoTracking()
                .Select(k => new RequestAuthorizationModel()
                {
                    RequestAuthorizationId = k.RequestAuthorizationId,
                    ProviderId = k.ProviderId,
                    FirstName = k.FirstName,
                    Email = k.Email,
                    PhoneNumber = k.PhoneNumber,
                    EnrolleeId = k.EnrolleeId,
                    AvonEnrolleId = k.AvonEnrolleId,
                    DateCreated = k.DateCreated,
                    MemberNo = k.MemberNo

                }).ToListAsync();
            return requests;
        }

        /// <summary> Capture a DependantRequest
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 14-01-2022 4:15PM
        /// </remarks>

        public async Task<bool> AddDependantRequest(DependantRequestPayloadModel model)
        {
            var memberNo = 0;
            var userinfo = _context.Enrollees.FirstOrDefault(m => m.EnrolleeAccountId == model.userId);
            if (userinfo != null)
            {
                memberNo = userinfo.MemberNumber.HasValue ? userinfo.MemberNumber.Value : 0;
            }
            var dependantRequest = new DependantRequest()
            {
                FirstName = model.FirstName,
                Surname = model.Surname,
                EnrolleeId = model.userId,
                MemberNo = memberNo.ToString() ?? "0",
                RelationshipId = model.RelationshipId,
                PicturePath = model.PicturePath,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth.ToDateTime("dd/MM/yyyy"),
                RequestDate = DateTime.Now,
                RequestStatus = "P",
                YourPlan = model.YourPlan == 1,
                Title = model.Title,
                MaritalStatus = model.MaritalStatus,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email


            };

            await _context.DependantRequests.AddAsync(dependantRequest);




            var res = await _context.SaveChangesAsync() > 0;
            return res;

        }




        /// <summary> Get a DependantRequest for an Enrolle
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 16-01-2022 3:35PM
        /// </remarks>
        public async Task<DependantRequestViewModel> FetchDependantRequestByMemberNo(string memberNo)
        {
            var requestQuery = from request in _context.DependantRequests.AsNoTracking()

                               select new DependantRequestViewModel
                               {
                                   DependantRequestId = request.DependantRequestId,
                                   FirstName = request.FirstName,
                                   Surname = request.Surname,
                                   EnrolleeId = request.EnrolleeId,
                                   MemberNo = request.MemberNo,
                                   Gender = request.Gender,
                                   RelationshipId = request.RelationshipId,
                                   YourPlan = request.YourPlan == true ? 1 : 0,
                                   PicturePath = request.PicturePath,
                                   DateOfBirth = request.DateOfBirth.ToString(),
                                   RequestDate = request.RequestDate.ToString(),
                                   RequestStatus = request.RequestStatus

                               };

            return await requestQuery.FirstOrDefaultAsync(x => x.MemberNo == memberNo);
        }

        /// <summary> Get a DependantRequest for a LoggedOn User
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 16-01-2022 3:20PM
        /// </remarks>
        public IQueryable<DependantRequestViewModel> FetchDependantRequestForLoggedOnUser(PagingParam param, Guid enrolleeId)
        {
            var requestQuery = from request in _context.DependantRequests.AsNoTracking()
                               where request.EnrolleeId == enrolleeId
                               select new DependantRequestViewModel
                               {
                                   DependantRequestId = request.DependantRequestId,
                                   FirstName = request.FirstName,
                                   Surname = request.Surname,
                                   EnrolleeId = request.EnrolleeId,
                                   MemberNo = request.MemberNo,
                                   Gender = request.Gender,
                                   RelationshipId = request.RelationshipId,
                                   YourPlan = request.YourPlan == true ? 1 : 0,
                                   PicturePath = request.PicturePath,
                                   DateOfBirth = request.DateOfBirth.ToString(),
                                   RequestDate = request.RequestDate.ToString(),
                                   RequestStatus = request.RequestStatus

                               };


            //requestQuery = requestQuery.Where(x => x.EnrolleeId == enrolleeId);


            var skip = (param.PageNumber - 1) * param.PageSize;

            return requestQuery.Skip(skip).Take(param.PageSize);
        }


        public IQueryable<DependantRequestViewModel> FetchDependantRequest(PagingParam param)
        {
            var postQuery = from request in _context.DependantRequests.AsNoTracking()

                            select new DependantRequestViewModel
                            {
                                DependantRequestId = request.DependantRequestId,
                                FirstName = request.FirstName,
                                Surname = request.Surname,
                                EnrolleeId = request.EnrolleeId,
                                MemberNo = request.MemberNo,
                                Gender = request.Gender,
                                RelationshipId = request.RelationshipId,
                                YourPlan = request.YourPlan == true ? 1 : 0,
                                PicturePath = request.PicturePath,
                                DateOfBirth = request.DateOfBirth.ToString(),
                                RequestDate = request.RequestDate.ToString(),
                                RequestStatus = request.RequestStatus

                            };



            var skip = (param.PageNumber - 1) * param.PageSize;

            return postQuery.Skip(skip).Take(param.PageSize);
        }

        /// <summary> Capture a DrugRefilRequest
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 16-01-2022 1:22PM
        /// </remarks>

        public async Task<bool> AddDrugRefillRequest(DrugRefillRequestViewModel model)
        {

            //var userinfo = _context.Enrollees.FirstOrDefault(m => m.EnrolleeAccountId == model.userId);

            // if (userinfo != null)
            //{
            var drugRequest = new DrugRefillRequest()
            {
                FirstName = model.FirstName,
                Surname = model.Surname,
                EnrolleeId = model.userId,
                //MemberNo = model.MemberNo,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                PrescriptionePath = model.PrescriptionPath,
                DateOfBirth = model.DateOfBirth.ToDateTime("dd/MM/yyyy"),
                RequestDate = DateTime.Now,
                RequestStatus = "P",
                DeliverAddress = model.DeliverAddress,
                MonthlyRefill = model.MonthlyRefill == 1 ? true : false

            };

            await _context.DrugRefillRequests.AddAsync(drugRequest);
            //  }

            var res = await _context.SaveChangesAsync() > 0;
            return res;

        }


        public async Task<bool> AddDrugRefillRequestForAdmin(DrugRefillRequestViewModel model)
        {

            var userinfo = _context.Enrollees.FirstOrDefault(m => m.EnrolleeId == model.EnrolleeId);

            if (userinfo != null)
            {
                var drugRequest = new DrugRefillRequest()
                {
                    FirstName = userinfo.FirstName,
                    Surname = userinfo.Surname,
                    EnrolleeId = userinfo.EnrolleeAccountId,
                    MemberNo = userinfo.MemberNumber == null ? "0" : userinfo.MemberNumber.ToString(),
                    Email = userinfo.Email,
                    PhoneNumber = userinfo.PrimaryPhoneNumber,
                    PrescriptionePath = model.PrescriptionPath,
                    DateOfBirth = userinfo.DateOfBirth,
                    RequestDate = DateTime.Now,
                    RequestStatus = "P",
                    DeliverAddress = userinfo.Address,
                    MonthlyRefill = model.MonthlyRefill == 1 ? true : false

                };

                await _context.DrugRefillRequests.AddAsync(drugRequest);
            }

            var res = await _context.SaveChangesAsync() > 0;
            return res;

        }

        public async Task<bool> AddDrugRefillRequestForWeb(DrugRefillRequestViewModel model)
        {

            var userinfo = _context.Enrollees.FirstOrDefault(m => m.EnrolleeAccountId == model.userId);

            if (userinfo != null)
            {
                var drugRequest = new DrugRefillRequest()
                {
                    FirstName = userinfo.FirstName,
                    Surname = userinfo.Surname,
                    EnrolleeId = userinfo.EnrolleeAccountId,
                    MemberNo = userinfo.MemberNumber == null ? "0" : userinfo.MemberNumber.ToString(),
                    Email = userinfo.Email,
                    PhoneNumber = userinfo.PrimaryPhoneNumber,
                    PrescriptionePath = model.PrescriptionPath,
                    DateOfBirth = userinfo.DateOfBirth,
                    RequestDate = DateTime.Now,
                    RequestStatus = "P",
                    DeliverAddress = userinfo.Address,
                    MonthlyRefill = model.MonthlyRefill == 1 ? true : false

                };

                await _context.DrugRefillRequests.AddAsync(drugRequest);
            }

            var res = await _context.SaveChangesAsync() > 0;
            return res;

        }

        /// <summary> Get a DrugRefilRequest for an Enrolle
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 16-01-2022 3:20PM
        /// </remarks>
        public async Task<DrugRefillRequestViewModel> FetchDrugRefillRequestByMemberNo(string memberNo)
        {
            var requestQuery = from request in _context.DrugRefillRequests.AsNoTracking()

                               select new DrugRefillRequestViewModel
                               {
                                   DrugRefillRequestId = request.DrugRefillRequestId,
                                   FirstName = request.FirstName,
                                   Surname = request.Surname,
                                   EnrolleeId = request.EnrolleeId,
                                   MemberNo = request.MemberNo,
                                   DeliverAddress = request.DeliverAddress,
                                   Email = request.Email,
                                   PhoneNumber = request.PhoneNumber,
                                   PrescriptionPath = request.PrescriptionePath,
                                   DateOfBirth = request.DateOfBirth.ToString(),
                                   RequestDate = request.RequestDate.ToString("dd/MM/yyyy"),
                                   RequestStatus = request.RequestStatus

                               };

            return await requestQuery.FirstOrDefaultAsync(x => x.MemberNo == memberNo);
        }


        /// <summary> Get a DrugRefilRequest for a LoggedOn User
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 16-01-2022 3:20PM
        /// </remarks>
        public IQueryable<DrugRefillRequestViewModel> FetchDrugRefillRequestForLoggedOnUser(PagingParam param, Guid enrolleeId)
        {
            var requestQuery = from request in _context.DrugRefillRequests.AsNoTracking()
                               where request.EnrolleeId == enrolleeId
                               select new DrugRefillRequestViewModel
                               {
                                   DrugRefillRequestId = request.DrugRefillRequestId,
                                   FirstName = request.FirstName,
                                   Surname = request.Surname,
                                   EnrolleeId = request.EnrolleeId,
                                   MemberNo = request.MemberNo,
                                   DeliverAddress = request.DeliverAddress,
                                   Email = request.Email,
                                   PhoneNumber = request.PhoneNumber,
                                   PrescriptionPath = request.PrescriptionePath,
                                   DateOfBirth = request.DateOfBirth.ToString(),
                                   RequestDate = request.RequestDate.ToString("dd/MM/yyyy"),
                                   RequestStatus = request.RequestStatus,
                                   CreatedDate = request.DateCreated

                               };


            var skip = (param.PageNumber - 1) * param.PageSize;

            return requestQuery.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(param.PageSize);
        }


        /// <summary> Get a DrugRefilRequest for a LoggedOn User with Status
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 19-01-2022 8:04PM
        /// </remarks>
        public IQueryable<DrugRefillRequestViewModel> FetchDrugRefillRequestForLoggedOnUserWithStatus(PagingParam param, Guid enrolleeId, string status)
        {
            var requestQuery = from request in _context.DrugRefillRequests.AsNoTracking()
                               where request.EnrolleeId == enrolleeId && request.RequestStatus == status
                               select new DrugRefillRequestViewModel
                               {
                                   DrugRefillRequestId = request.DrugRefillRequestId,
                                   FirstName = request.FirstName,
                                   Surname = request.Surname,
                                   EnrolleeId = request.EnrolleeId,
                                   MemberNo = request.MemberNo,
                                   DeliverAddress = request.DeliverAddress,
                                   Email = request.Email,
                                   PhoneNumber = request.PhoneNumber,
                                   PrescriptionPath = request.PrescriptionePath,
                                   DateOfBirth = request.DateOfBirth.ToString(),
                                   RequestDate = request.RequestDate.ToString("dd/MM/yyyy"),
                                   RequestStatus = request.RequestStatus,
                                   CreatedDate = request.DateCreated

                               };



            var skip = (param.PageNumber - 1) * param.PageSize;

            return requestQuery.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(param.PageSize);
        }

        /// <summary> Get a DrugRefilRequest for a LoggedOn User with State
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 19-01-2022 8:04PM
        /// </remarks>
        public IQueryable<DrugRefillRequestViewModel> FetchDrugRefillRequestForLoggedOnUserWithState(PagingParam param, Guid enrolleeId, bool reqState)
        {
            var requestQuery = from request in _context.DrugRefillRequests.AsNoTracking()
                               where request.EnrolleeId == enrolleeId && request.RequestState == reqState
                               select new DrugRefillRequestViewModel
                               {
                                   DrugRefillRequestId = request.DrugRefillRequestId,
                                   FirstName = request.FirstName,
                                   Surname = request.Surname,
                                   EnrolleeId = request.EnrolleeId,
                                   MemberNo = request.MemberNo,
                                   DeliverAddress = request.DeliverAddress,
                                   Email = request.Email,
                                   PhoneNumber = request.PhoneNumber,
                                   PrescriptionPath = request.PrescriptionePath,
                                   DateOfBirth = request.DateOfBirth.ToString(),
                                   RequestDate = request.RequestDate.ToString("dd/MM/yyyy"),
                                   RequestStatus = request.RequestStatus,
                                   CreatedDate = request.DateCreated

                               };


            var skip = (param.PageNumber - 1) * param.PageSize;

            return requestQuery.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(param.PageSize);
        }

        /// <summary> Get a DrugRefilRequest for a LoggedOn User with State and Status
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 19-01-2022 8:04PM
        /// </remarks>
        public IQueryable<DrugRefillRequestViewModel> FetchDrugRefillRequestForLoggedOnUserWithStateAndStatus(PagingParam param, Guid enrolleeId, bool reqState, string status)
        {
            var requestQuery = from request in _context.DrugRefillRequests.AsNoTracking()
                               where request.EnrolleeId == enrolleeId && request.RequestState == reqState && request.RequestStatus == status
                               select new DrugRefillRequestViewModel
                               {
                                   DrugRefillRequestId = request.DrugRefillRequestId,
                                   FirstName = request.FirstName,
                                   Surname = request.Surname,
                                   EnrolleeId = request.EnrolleeId,
                                   MemberNo = request.MemberNo,
                                   DeliverAddress = request.DeliverAddress,
                                   Email = request.Email,
                                   PhoneNumber = request.PhoneNumber,
                                   PrescriptionPath = request.PrescriptionePath,
                                   DateOfBirth = request.DateOfBirth.ToString(),
                                   RequestDate = request.RequestDate.ToString("dd/MM/yyyy"),
                                   RequestStatus = request.RequestStatus,
                                   CreatedDate = request.DateCreated

                               };



            var skip = (param.PageNumber - 1) * param.PageSize;

            return requestQuery.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(param.PageSize);
        }

        public IQueryable<DrugRefillRequestViewModel> FetchDrugRefillRequest(PagingParam param)
        {


            var postQuery = from request in _context.DrugRefillRequests.AsNoTracking()

                            select new DrugRefillRequestViewModel
                            {
                                DrugRefillRequestId = request.DrugRefillRequestId,
                                FirstName = request.FirstName,
                                Surname = request.Surname,
                                EnrolleeId = request.EnrolleeId,
                                MemberNo = request.MemberNo,
                                DeliverAddress = request.DeliverAddress,
                                Email = request.Email,
                                PhoneNumber = request.PhoneNumber,
                                PrescriptionPath = request.PrescriptionePath,
                                DateOfBirth = request.DateOfBirth.ToString(),
                                RequestDate = request.RequestDate.ToString("dd/MM/yyyy"),
                                RequestStatus = request.RequestStatus,
                                CreatedDate = request.DateCreated

                            };



            var skip = (param.PageNumber - 1) * param.PageSize;

            return postQuery.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(param.PageSize);
        }

        public async Task<DrugRefillRequestViewModel> GetDrugRefillInfo(Guid refillId)
        {
            var response = new DrugRefillRequestViewModel();
            var refillresponse = await _context.DrugRefillRequests.AsNoTracking().FirstOrDefaultAsync(j => j.DrugRefillRequestId == refillId);
            if (refillresponse != null)
            {
                response.DrugRefillRequestId = refillresponse.DrugRefillRequestId;
                response.FirstName = refillresponse.FirstName;
                response.Surname = refillresponse.Surname;
                response.EnrolleeId = refillresponse.EnrolleeId;
                response.MemberNo = refillresponse.MemberNo;
                response.DeliverAddress = refillresponse.DeliverAddress;
                response.Email = refillresponse.Email;
                response.PhoneNumber = refillresponse.PhoneNumber;
                response.PrescriptionPath = refillresponse.PrescriptionePath;
                response.DateOfBirth = refillresponse.DateOfBirth.ToString();
                response.RequestDate = refillresponse.RequestDate.ToString("dd/MM/yyyy");
                response.RequestStatus = refillresponse.RequestStatus;
                response.CreatedDate = refillresponse.DateCreated;
            }

            return response;
        }

        public async Task<bool> IsDrugRefillIDExist(Guid refillID)
        {
            return (await _context.DrugRefillRequests.AsNoTracking().AnyAsync(m => m.DrugRefillRequestId == refillID));
        }

        public async Task<bool> UpdateDrugRefillStatus(DrugRefillUpdateViewModel model)
        {
            var res = false;
            var claim = await _context.DrugRefillRequests.FirstOrDefaultAsync(m => m.DrugRefillRequestId == model.DrugRefillRequestId);
            if (claim != null)
            {
                claim.RequestStatus = model.Status.Capitalize();
                claim.DateUpdated = DateTime.Now;

                res = await _context.SaveChangesAsync() > 0;
            }



            return res;

        }

        /// <summary> Capture a RequestRefund
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 17-01-2022 11:19AM
        /// </remarks>
        public async Task<bool> CreateRequestRefund(RequestRefundRequestModel reqRefund, Guid enrolleeID)
        {
            // var userinfo = _context.Enrollees.FirstOrDefault(m => m.EnrolleeAccountId == enrolleeID);
            // if (userinfo != null)
            // {
            var requestRefund = new RequestRefund()
            {
                EnrolleeId = enrolleeID,
                Reason = reqRefund.Reason,
                OtherReasons = reqRefund.OtherReasons,
                Amount = Convert.ToDecimal(reqRefund.Amount),
                RequestDate = DateTime.Now,
                RequestStatus = "P",
                EncounteredDate = reqRefund.EncounteredDate.ToDateTime("dd/MM/yyyy"),
                HospitalName = reqRefund.HospitalName,
                HospitalLocation = reqRefund.HospitalLocation,
                PACode = reqRefund.PACode,
                CompanyName = reqRefund.CompanyName,
                BeneficiaryName = reqRefund.BeneficiaryName,
                BankName = reqRefund.BankName,
                AccountNumber = reqRefund.AccountNumber,
                InvoiceDoc = reqRefund.InvoiceDoc,
                MedicalReportDoc = reqRefund.MedicalReportDoc,
                ReceiptsDoc = reqRefund.ReceiptsDoc
            };

            await _context.RequestRefunds.AddAsync(requestRefund);
            //  }


            var res = await _context.SaveChangesAsync() > 0;
            return res;
        }

        public IQueryable<RequestRefundViewModel> FetchRequestRefund(PagingParam param)
        {
            var postQuery = from request in _context.RequestRefunds.AsNoTracking()
                            select new RequestRefundViewModel
                            {
                                RequestRefundId = request.RequestRefundId,
                                Reason = request.Reason,
                                OtherReasons = request.OtherReasons,
                                Amount = request.Amount,
                                MemberNo = request.MemberNo,
                                RequestDate = request.RequestDate.ToString(),
                                RequestStatus = request.RequestStatus

                            };


            var skip = (param.PageNumber - 1) * param.PageSize;

            return postQuery.Skip(skip).Take(param.PageSize);
        }

        /// <summary> Get a RequestRefund for an Enrolle
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 17-01-2022 11:36PM
        /// </remarks>
        public async Task<RequestRefundViewModel> FetchRequestRefundByMemberNo(string memberNo)
        {
            var requestQuery = from request in _context.RequestRefunds.AsNoTracking()

                               select new RequestRefundViewModel
                               {
                                   RequestRefundId = request.RequestRefundId,
                                   Reason = request.Reason,
                                   OtherReasons = request.OtherReasons,
                                   Amount = request.Amount,
                                   MemberNo = request.MemberNo,
                                   RequestDate = request.RequestDate.ToString(),
                                   RequestStatus = request.RequestStatus

                               };

            return await requestQuery.FirstOrDefaultAsync(x => x.MemberNo == memberNo);
        }

        /// <summary> Get a RequestRefund for a LoggedOn User
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 16-01-2022 3:20PM
        /// </remarks>
        public IQueryable<RequestRefundViewModel> FetchRequestRefundForLoggedOnUser(PagingParam param, Guid enrolleeId)
        {
            var requestQuery = from request in _context.RequestRefunds.AsNoTracking()
                               where request.EnrolleeId == enrolleeId
                               select new RequestRefundViewModel
                               {
                                   RequestRefundId = request.RequestRefundId,
                                   Reason = request.Reason,
                                   OtherReasons = request.OtherReasons,
                                   Amount = request.Amount,
                                   //MemberNo = request.MemberNo,
                                   EnrolleeId = request.EnrolleeId,
                                   RequestDate = request.RequestDate.ToString(),
                                   RequestStatus = request.RequestStatus

                               };


            var skip = (param.PageNumber - 1) * param.PageSize;

            return requestQuery.Skip(skip).Take(param.PageSize);
        }

        /// <summary> Capture a Recommendation
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 17-01-2022 11:51AM
        /// </remarks>
        public async Task<bool> CreateEnrolleeRecommendation(EnrolleeRecommendationRequestModel enrolleeRecommendation)
        {
            var recommend = new EnrolleeRecommendation()
            {
                BeneficairyId = enrolleeRecommendation.BeneficairyId,
                BeneficairyName = enrolleeRecommendation.BeneficairyName,
                Recommendation = enrolleeRecommendation.Recommendation,
                RecommendationCategory = enrolleeRecommendation.RecommendationCategory,
                DateCreated = DateTime.Now,
            };

            await _context.EnrolleeRecommendations.AddAsync(recommend);

            return await _context.SaveChangesAsync() > 0;
        }

        public IQueryable<EnrolleeRecommendationViewModel> FetchEnrolleeRecommendation(PagingParam param)
        {
            var postQuery = from request in _context.EnrolleeRecommendations.AsNoTracking()

                            select new EnrolleeRecommendationViewModel
                            {
                                BeneficairyId = request.BeneficairyId,
                                Recommendation = request.Recommendation,
                                RecommendationCategory = request.RecommendationCategory,
                                MemberNo = request.MemberNo,
                                DateCreated = request.DateCreated,
                                EnrolleeRecommendationId = request.EnrolleeRecommendationId
                            };



            var skip = (param.PageNumber - 1) * param.PageSize;

            return postQuery.Skip(skip).Take(param.PageSize);
        }


        public async Task<bool> UpdateAddToCart(CartPayLoadDTO model)
        {
            var cartItem = await _context.Carts.FirstOrDefaultAsync(m => m.CartId == model.cartId);
            if (cartItem != null)
            {
                cartItem.Quantity = cartItem.Quantity + model.quantity;
                cartItem.Price = model.price;
                return await _context.SaveChangesAsync() > 0;
            }

            return false;

        }
        public async Task RemoveCartItem(Guid cartId)
        {
            var cartItem = await _context.Carts.FirstOrDefaultAsync(m => m.CartId == cartId);
            if (cartItem != null)
            {
                _context.Carts.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }
        public async Task ClearCartItem(string uniqueReference)
        {
            var cartItem = _context.Carts.Where(m => m.UniqueReference == uniqueReference);
            _context.Carts.RemoveRange(cartItem);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<CartViewModel>> GetCart(string uniqueReference)
        {
            return await _context.Carts.Where(k => k.UniqueReference == uniqueReference).Select(k => new CartViewModel()
            {
                cartId = k.CartId,
                dateCreated = k.DateCreated,
                price = k.Price,
                productId = k.ProductId,
                productName = k.ProductName,
                quantity = k.Quantity,
                uniqueReference = uniqueReference,
            }).ToListAsync();
        }
        public async Task<bool> AddToCart(CartDTO model)
        {
            var cartItem = await _context.Carts.FirstOrDefaultAsync(m => m.ProductId == model.productId && m.UniqueReference == m.UniqueReference);
            if (cartItem == null)
            {
                var plan = await _context.Plans.FirstOrDefaultAsync(k => k.PlanCode == model.productId);
                var cart = new Cart()
                {
                    DateCreated = DateTime.Now,
                    Price = model.price,
                    ProductId = model.productId,
                    Quantity = model.quantity,
                    UniqueReference = model.UniqueReference,
                    Amount = model.price * model.quantity,
                    ProductName = plan == null ? "" : plan.PlanName
                };
                await _context.Carts.AddAsync(cart);
            }
            else
            {
                cartItem.Quantity = cartItem.Quantity + model.quantity;
                cartItem.Price = model.price;
                cartItem.Amount = cartItem.Quantity * cartItem.Price;
            }

            return await _context.SaveChangesAsync() > 0;
        }
        #endregion

        #region Provider Web

        public async Task<bool> PostGuideQuestion(ProviderInspectionGuideAnswerDTO model)
        {
            var data = model.providerAnswers.Select(m => new HCPInspectionGuildAnswer()
            {
                Answer = m.answer,
                DateCreated = DateTime.Now,
                HCPId = model.providerId,
                QuestionId = m.questionId,
            });

            await _context.HCPInspectionGuildAnswers.AddRangeAsync(data);

            return (await _context.SaveChangesAsync()) > 0;

        }
        public async Task<List<ProviderInspectionGuideViewModel>> GetInspectionGuideQestions()
        {
            var qst = await _context.HCPInspectionGuildQuestionMasters
                .Select(m => new ProviderInspectionGuideViewModel()
                {
                    isMultipleChoice = m.isMultipleChoice,
                    orderNo = m.orderNo,
                    question = m.Question,
                    questionId = m.QuestionId
                }).OrderBy(m => m.orderNo)
            .ToListAsync();

            qst = qst.Select(m => new ProviderInspectionGuideViewModel()
            {
                isMultipleChoice = m.isMultipleChoice,
                orderNo = m.orderNo,
                question = m.question,
                questionId = m.questionId,
                options = _context.HCPInspectionGuildOptions.Where(k => k.QuestionId == m.questionId)
                .Select(k => new ProviderInspectionGuideOptions()
                {
                    Option = k.Option,
                    optionId = k.OptionId,
                    orderNo = k.OrderNo
                }).OrderBy(j => j.orderNo).ToList()

            }).ToList();

            return qst;
        }


        public async Task<Guid> AddNewProvider(ProviderViewModels model)
        {

            var provider = new Provider()
            {
                ProviderName = model.providerName,
                MDName = model.mdName,
                Address = model.providerAddress,
                MDPhoneNo = model.mdPhoneNo,
                MDEmail = model.mdEmail,
                MDDirectLine = model.mdDirectLine,
                Email = model.hmoContactDetailsEmail,
                HMODeskPhoneNo = model.hmoDeskPhoneNo,
                HMOOfficerName = model.hmoOfficerName,
                HMOOfficerGSM = model.hmoOfficerGSM,
                ProviderServiceType = model.providerServiceType,
                ProviderOperationHour = model.providerOperationHour,
                ProviderOperationDay = model.providerOperationDay,
                DoctorCoverageHour = model.doctorCoverageHour,
                LGA = model.lga,
                City = model.city,
                State = model.state,
                Bankname = model.bankname,
                AccountName = model.accountName,
                SortCode = model.sortCode,
                AccountNo = model.accountNo,
                Deleted = false,
                DateCreated = DateTime.Now,

            };

            await _context.Providers.AddAsync(provider);

            _context.SaveChanges();

            var providerId = provider.ProviderID;

            if (model.otherContacts.Any())
            {
                foreach (var item in model.otherContacts)
                {
                    var contact = new ProviderContact()
                    {
                        ContactName = item.contactName,
                        ContactPhoneNo = item.contactPhoneNo,
                        ContactEmail = item.contactEmail,
                        ProviderID = providerId
                    };

                    _context.ProviderContacts.Add(contact);
                }

                _context.SaveChanges();

            }

            return providerId;
        }

        public async Task<bool> AddProviderDetail(ProvidersRepoDTO model)
        {
            var providerDetail = new Provider()
            {
                //Code = model.code,
                //Name = model.name,
                //ShortName = model.shortName,
                //Address = model.address,
                City = model.city,
                LGA = model.lga,
                State = model.state,
                MDName = model.mdName,
                MDEmail = model.mdEmail,
                MDDirectLine = model.mdDirectLine,
                MDPhoneNo = model.mdPhoneNo,
                Email = model.email,
                // Phoneno = model.phoneno,
                HMODeskPhoneNo = model.hmoDeskPhoneNo,
                //HMOOfficerEmail = model.hmoOfficerEmail,
                HMOOfficerName = model.hmoOfficerName,
                ProviderServiceType = model.providerServiceType,
                ProviderOperationDay = model.providerOperationDay,
                ProviderOperationHour = model.providerOperationHour,
                DoctorCoverageHour = model.doctorCoverageHour,
                Bankname = model.bankname,
                AccountName = model.accountName,
                AccountNo = model.accountNo,
                SortCode = model.sortCode,

            };

            await _context.Providers.AddAsync(providerDetail);

            //if (await _context.SaveChangesAsync() > 0)
            //{
            //    response.HasError = false;
            //    response.OrderReference = principalDetail.OrderReference;
            //    response.OrderId = principalDetail.OrderId;
            //    response.ProductId = principalDetail.ProductId;
            //}

            return true;
        }


        /// <summary> Capture a RequestQuote
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 19-02-2022 12:23PM
        /// </remarks>
        public async Task<bool> CreateRequestQuote(RequestQuoteRequestModel quote)
        {
            var request = new RequestQuote()
            {
                Name = quote.Name,
                //CategoryCode = quote.CategoryCode,
                PlanName = quote.PlanName,
                EmailAddress = quote.EmailAddress,
                MobileNumber = quote.MobileNumber,
                CompanyAddress = quote.CompanyAddress,
                CompanyName = quote.CompanyName,
                ContactRole = quote.ContactRole,
                NoToEnrollee = quote.NoToEnrollee,
                CompanyAndLargeAssociation = quote.CompanyAndLargeAssociation,
                InternationalHealthPlan = quote.InternationalHealthPlan,
                DateCreated = DateTime.Now,
                RequestStatus = "Pending"
            };

            await _context.RequestQuotes.AddAsync(request);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<RequestQuoteModel>> GetQuoteRequests()
        {
            var requests = await _context.RequestQuotes.AsNoTracking()
                .Select(k => new RequestQuoteModel()
                {
                    RequestQuoteId = k.RequestQuoteId,
                    Name = k.Name,
                    EmailAddress = k.EmailAddress,
                    CompanyAddress = k.CompanyAddress,
                    CompanyAndLargeAssociation = k.CompanyAndLargeAssociation,
                    CompanyName = k.CompanyName,
                    ContactRole = k.ContactRole,
                    InternationalHealthPlan = k.InternationalHealthPlan,
                    MobileNumber = k.MobileNumber,
                    NoToEnrollee = k.NoToEnrollee,
                    RequestDate = k.RequestDate,
                    RequestStatus = k.RequestStatus
                }).ToListAsync();
            return requests;
        }

        public async Task<RequestQuoteModel> GetQuoteRequestById(Guid quoteId)
        {
            var response = new RequestQuoteModel();
            var claim = await _context.RequestQuotes.AsNoTracking().FirstOrDefaultAsync(j => j.RequestQuoteId == quoteId);
            if (claim != null)
            {
                response.RequestQuoteId = claim.RequestQuoteId;
                response.Name = claim.Name;
                response.EmailAddress = claim.EmailAddress;
                response.CompanyAddress = claim.CompanyAddress;
                response.CompanyAndLargeAssociation = claim.CompanyAndLargeAssociation;
                response.CompanyName = claim.CompanyName;
                response.ContactRole = claim.ContactRole;
                response.InternationalHealthPlan = claim.InternationalHealthPlan;
                response.MobileNumber = claim.MobileNumber;
                response.NoToEnrollee = claim.NoToEnrollee;
                response.RequestDate = claim.RequestDate;
                response.RequestStatus = claim.RequestStatus;

            }

            return response;
        }

        /// <summary> Capture a Claims
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 19-02-2022 4:01PM
        /// </remarks>
        public async Task<bool> CreateClaims(ClaimsRequestModel claims)
        {
            var request = new Claim()
            {
                Name = claims.Name,
                PreAuthorizationCode = claims.PreAuthorizationCode,
                PlanName = claims.PlanName.Trim(),
                Gender = claims.Gender,
                Diagnosis = claims.Diagnosis,
                Services = claims.Services,
                EncounterDate = claims.EncounterDate,
                Amount = claims.Amount,
                Notes = claims.Notes,
                DateCreated = DateTime.Now,
                DrugQuantity = claims.DrugQuantity,
                RequestStatus = "Pending"
            };

            await _context.Claims.AddAsync(request);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<ClaimsViewModel>> GetClaims()
        {
            var requests = await _context.Claims.AsNoTracking()
                .Select(k => new ClaimsViewModel()
                {
                    ClaimId = k.ClaimId,
                    CloseClaim = k.CloseClaim,
                    Name = k.Name,
                    PreAuthorizationCode = k.PreAuthorizationCode,
                    PlanName = k.PlanName,
                    Gender = k.Gender,
                    Diagnosis = k.Diagnosis,
                    Services = k.Services,
                    EncounterDate = k.EncounterDate,
                    Amount = k.Amount,
                    Notes = k.Notes,
                    DateCreated = k.DateCreated,
                    RequestStatus = k.RequestStatus,
                    DrugQuantity = k.DrugQuantity
                }).ToListAsync();
            return requests;
        }

        public async Task<ClaimsViewModel> GetClaimInfo(Guid claimId)
        {
            var response = new ClaimsViewModel();
            var claim = await _context.Claims.AsNoTracking().FirstOrDefaultAsync(j => j.ClaimId == claimId);
            if (claim != null)
            {
                response.PreAuthorizationCode = claim.PreAuthorizationCode;
                response.Name = claim.Name;
                response.PlanName = claim.PlanName;
                response.Gender = claim.Gender;
                response.Diagnosis = claim.Diagnosis;
                response.Services = claim.Services;
                response.EncounterDate = claim.EncounterDate;
                response.Amount = claim.Amount;
                response.Notes = claim.Notes;
                response.DateCreated = claim.DateCreated;
                response.RequestStatus = claim.RequestStatus;
                response.DrugQuantity = claim.DrugQuantity;
                response.CloseClaim = claim.CloseClaim;
                response.ClaimId = claim.ClaimId;
            }

            return response;
        }

        public async Task<bool> CloseClaimInfo(CloseClaimsModel claimModel)
        {
            var claim = await _context.Claims.AsNoTracking().FirstOrDefaultAsync(j => j.ClaimId == claimModel.ClaimId);
            if (claim != null)
            {
                claim.CloseClaim = true;
                claim.CloseReason = claimModel.CloseReason;
                claim.DateUpdated = DateTime.Now;

                await _context.SaveChangesAsync();
            }

            var res = await _context.SaveChangesAsync() > 0;

            return res;
        }

        public async Task<bool> IsClaimIDExist(Guid claimID)
        {
            return (await _context.Claims.AsNoTracking().AnyAsync(m => m.ClaimId == claimID));
        }
        public async Task<bool> UpdateClaimStatus(ClaimsUpdateViewModel model)
        {
            try
            {


                var claim = await _context.Claims.FirstOrDefaultAsync(m => m.ClaimId == model.ClaimId);
                if (claim != null)
                {
                    claim.RequestStatus = model.RequestStatus;
                    claim.DateUpdated = DateTime.Now;
                }
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }



        }
        public IQueryable<ClaimsViewModel> SearchClaims(PagingParam param, string searchText)
        {
            var postQuery = from claim in _context.Claims.AsNoTracking()
                            select new ClaimsViewModel
                            {
                                PreAuthorizationCode = claim.PreAuthorizationCode,
                                Name = claim.Name,
                                PlanName = claim.PlanName,
                                Gender = claim.Gender,
                                Diagnosis = claim.Diagnosis,
                                Services = claim.Services,
                                EncounterDate = claim.EncounterDate,
                                Amount = claim.Amount,
                                Notes = claim.Notes,
                                DateCreated = claim.DateCreated,
                                RequestStatus = claim.RequestStatus,
                                DrugQuantity = claim.DrugQuantity,
                                CloseClaim = claim.CloseClaim,
                                ClaimId = claim.ClaimId,

                            };


            if (!string.IsNullOrEmpty(searchText))
            {
                postQuery = postQuery.Where(x => x.RequestStatus == searchText || x.Diagnosis.Contains(searchText) || x.Services.Contains(searchText) || x.PlanName == searchText);
            }
            var skip = (param.PageNumber - 1) * param.PageSize;

            return postQuery.Skip(skip).Take(param.PageSize);
        }



        #endregion

        #region Notification
        public IEnumerable<NotificationLogVM> PendingNotifications(string ownerId)
        {
            return _context.NotificationLogs.AsNoTracking().Where(x => x.OwnerId == ownerId && x.Status == 1)
                .Select(x => new NotificationLogVM
                {
                    ownerId = x.OwnerId,
                    body = x.body,
                    subject = x.Subject,
                    id = x.Id,

                });
        }

        public async Task<bool> LogNotification(NotificationLogVM notification)
        {
            var newNotification = new NotificationLog()
            {
                body = notification.body,
                Subject = notification.subject,
                DateSent = DateTime.Now,
                OwnerId = notification.ownerId
            };

            await _context.NotificationLogs.AddAsync(newNotification);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateNotification(Guid notificationId)
        {
            var targetMessage = await _context.NotificationLogs.FindAsync(notificationId);
            if (targetMessage == null) return false;
            targetMessage.Status = 1;
            _context.SaveChanges();
            return true;
        }

        public IQueryable<FAQViewModel> FAQs(PagingParam param)
        {
            var postQuery = from faq in _context.FAQs.AsNoTracking()
                            join fcat in _context.FAQCategorys.AsNoTracking()
                            on faq.FAQCategoryId equals fcat.FAQCategoryId
                            select new FAQViewModel
                            {
                                faqCategoryId = faq.FAQCategoryId,
                                faqCategory = fcat.Description,
                                questionText = faq.QuestionText,
                                answerText = faq.AnswerText,
                            };

            var skip = (param.PageNumber - 1) * param.PageSize;

            return postQuery.Skip(skip).Take(param.PageSize);
        }
        public IQueryable<FAQCategoryViewModel> GetFAQCategories()
        {
            return _context.FAQCategorys.AsNoTracking().Select(c => new FAQCategoryViewModel
            {
                faqCategoryId = c.FAQCategoryId,
                description = c.Description,
            });
        }

        public IQueryable<FAQViewModel> SearchFAQs(PagingParam param, string textQue)
        {
            var postQuery = from faq in _context.FAQs.AsNoTracking()
                            join fcat in _context.FAQCategorys.AsNoTracking()
                            on faq.FAQCategoryId equals fcat.FAQCategoryId
                            select new FAQViewModel
                            {
                                faqCategoryId = faq.FAQCategoryId,
                                faqCategory = fcat.Description,
                                questionText = faq.QuestionText,
                                answerText = faq.AnswerText,
                            };


            if (!string.IsNullOrEmpty(textQue))
            {
                postQuery = postQuery.Where(x => x.questionText.Contains(textQue) || x.answerText.Contains(textQue));
            }
            var skip = (param.PageNumber - 1) * param.PageSize;

            return postQuery.Skip(skip).Take(param.PageSize);
        }


        public async Task<bool> CreateFeedback(FeedbackRequestModel feedback)
        {

            var userFeedback = new EnrolleeFeedback()
            {
                Name = feedback.Name,
                Email = feedback.Email,
                Subject = feedback.Subject,
                Message = feedback.Message,
                DateCreated = DateTime.Now,
            };

            await _context.EnrolleeFeedbacks.AddAsync(userFeedback);

            return await _context.SaveChangesAsync() > 0;
        }
        /// <summary>
        /// Created response for Admin
        /// </summary>
        /// <param name="compliant"></param>
        /// <returns></returns>
        public async Task<bool> CreateCompliantAdminResponse(CompliantAdminRequestModel compliant)
        {

            var adminResponse = new EnrolleeComplaintAdminResponse()
            {
                EnrolleeComplaintId = compliant.enrolleeComplaintId,
                AdminResponse = compliant.adminResponse,
                DateCreated = DateTime.Now,

            };
            await _context.EnrolleeComplaintAdminResponses.AddAsync(adminResponse);

            return await _context.SaveChangesAsync() > 0;
        }

        public IQueryable<CompliantAdminViewModel> FetchAdminComplaintResponseByComplaintID(Guid complaintId)
        {
            var requestQuery = from compliant in _context.EnrolleeComplaintAdminResponses.AsNoTracking()
                               where compliant.EnrolleeComplaintId == complaintId
                               select new CompliantAdminViewModel
                               {
                                   EnrolleeComplaintAdminId = compliant.EnrolleeComplaintAdminId,
                                   enrolleeComplaintId = compliant.EnrolleeComplaintId,
                                   adminResponse = compliant.AdminResponse,
                                   dateCreated = compliant.DateCreated
                               };




            return requestQuery.OrderByDescending(x => x.dateCreated);
        }
        public IQueryable<CompliantAdminViewModel> FetchAdminComplaintResponse(PagingParam param)
        {
            var requestQuery = from compliant in _context.EnrolleeComplaintAdminResponses.AsNoTracking()
                               select new CompliantAdminViewModel
                               {
                                   EnrolleeComplaintAdminId = compliant.EnrolleeComplaintAdminId,
                                   enrolleeComplaintId = compliant.EnrolleeComplaintId,
                                   adminResponse = compliant.AdminResponse,
                                   dateCreated = compliant.DateCreated

                               };

            var skip = (param.PageNumber - 1) * param.PageSize;

            return requestQuery.Skip(skip).Take(param.PageSize);
        }

        public async Task<bool> CreateCompliant(CompliantRequestModel compliant, Guid enrolleeID)
        {
            var plnName = string.Empty;
            var getUser = await _context.Enrollees.FirstOrDefaultAsync(x => x.EnrolleeAccountId == enrolleeID);
            if (getUser != null)
            {
                var getPlan = await _context.Plans.FirstOrDefaultAsync(x => x.PlanCode == getUser.ProductId);
                plnName = getPlan.PlanName ?? "";
            }


            var userFeedback = new EnrolleeComplaint()
            {
                Name = compliant.Name,
                Email = compliant.Email,
                Subject = compliant.Subject,
                Message = compliant.Message,
                DateCreated = DateTime.Now,
                MemberNo = getUser.MemberNumber ?? 0,
                EnrolleeId = enrolleeID,
                ComplaintStatus = "Open",
                Plan = plnName ?? ""

            };
            await _context.EnrolleeComplaints.AddAsync(userFeedback);

            return await _context.SaveChangesAsync() > 0;
        }


        /// <summary> Get a User's Feedback
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author :: Simeon Folaranmi
        /// Created :: Simeon Folaranmi 01-03-2022 11:19AM
        /// </remarks>
        public IQueryable<CompliantViewModel> FetchComplaint(PagingParam param)
        {
            var requestQuery = from compliant in _context.EnrolleeComplaints.AsNoTracking()
                               select new CompliantViewModel
                               {
                                   EnrolleeComplaintId = compliant.EnrolleeComplaintId,
                                   Name = compliant.Name,
                                   Email = compliant.Email,
                                   Subject = compliant.Subject,
                                   Message = compliant.Message,
                                   MemberNo = compliant.MemberNo.HasValue ? compliant.MemberNo.Value.ToString() : "0",
                                   Status = compliant.ComplaintStatus,
                                   Plan = compliant.Plan,
                                   CreatedDate = compliant.DateCreated,

                               };

            var skip = (param.PageNumber - 1) * param.PageSize;

            return requestQuery.Skip(skip).Take(param.PageSize);
        }

        public IQueryable<CompliantViewModel> FetchComplaintByUser(PagingParam param, Guid enrolleeId)
        {
            var requestQuery = from compliant in _context.EnrolleeComplaints.AsNoTracking()
                               where compliant.EnrolleeId == enrolleeId
                               select new CompliantViewModel
                               {
                                   EnrolleeComplaintId = compliant.EnrolleeComplaintId,
                                   Name = compliant.Name,
                                   Email = compliant.Email,
                                   Subject = compliant.Subject,
                                   Message = compliant.Message,
                                   MemberNo = compliant.MemberNo.HasValue ? compliant.MemberNo.Value.ToString() : "0",
                                   Status = compliant.ComplaintStatus,
                                   Plan = compliant.Plan,
                                   CreatedDate = compliant.DateCreated,

                               };



            var skip = (param.PageNumber - 1) * param.PageSize;

            return requestQuery.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(param.PageSize);
        }

        public IQueryable<CompliantViewModel> FetchUserComplaintByStatus(PagingParam param, Guid enrolleeId, string status)
        {
            var requestQuery = from compliant in _context.EnrolleeComplaints.AsNoTracking()
                               where compliant.EnrolleeId == enrolleeId && compliant.ComplaintStatus == status
                               select new CompliantViewModel
                               {
                                   EnrolleeComplaintId = compliant.EnrolleeComplaintId,
                                   Name = compliant.Name,
                                   Email = compliant.Email,
                                   Subject = compliant.Subject,
                                   Message = compliant.Message,
                                   MemberNo = compliant.MemberNo.HasValue ? compliant.MemberNo.Value.ToString() : "0",
                                   Status = compliant.ComplaintStatus,
                                   Plan = compliant.Plan,
                                   CreatedDate = compliant.DateCreated,

                               };

            var skip = (param.PageNumber - 1) * param.PageSize;

            return requestQuery.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(param.PageSize);
        }

        public IQueryable<CompliantViewModel> FetchComplaintByStatus(PagingParam param, string status)
        {
            var requestQuery = from compliant in _context.EnrolleeComplaints.AsNoTracking()
                               where compliant.ComplaintStatus == status
                               select new CompliantViewModel
                               {
                                   EnrolleeComplaintId = compliant.EnrolleeComplaintId,
                                   Name = compliant.Name,
                                   Email = compliant.Email,
                                   Subject = compliant.Subject,
                                   Message = compliant.Message,
                                   MemberNo = compliant.MemberNo.HasValue ? compliant.MemberNo.Value.ToString() : "0",
                                   Status = compliant.ComplaintStatus,
                                   Plan = compliant.Plan,
                                   CreatedDate = compliant.DateCreated,

                               };

            var skip = (param.PageNumber - 1) * param.PageSize;

            return requestQuery.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(param.PageSize);
        }


        public async Task<CompliantViewModel> GetComplaintInfo(Guid complaintId)
        {
            var response = new CompliantViewModel();
            var compliant = await _context.EnrolleeComplaints.AsNoTracking().FirstOrDefaultAsync(j => j.EnrolleeComplaintId == complaintId);
            if (compliant != null)
            {
                response.EnrolleeComplaintId = compliant.EnrolleeComplaintId;
                response.Name = compliant.Name;
                response.Email = compliant.Email;
                response.Subject = compliant.Subject;
                response.Message = compliant.Message;
                response.MemberNo = compliant.MemberNo.HasValue ? compliant.MemberNo.Value.ToString() : "0";
                response.Status = compliant.ComplaintStatus;
                response.Plan = compliant.Plan;
                response.CreatedDate = compliant.DateCreated;
            }

            return response;
        }
        public async Task<bool> IsComplaintIDExist(Guid complaintID)
        {
            return (await _context.EnrolleeComplaints.AsNoTracking().AnyAsync(m => m.EnrolleeComplaintId == complaintID));
        }
        public async Task<bool> UpdateComplaintStatus(CompliantUpdateViewModel model)
        {
            var res = false;
            var claim = await _context.EnrolleeComplaints.FirstOrDefaultAsync(m => m.EnrolleeComplaintId == model.EnrolleeComplaintId);
            if (claim != null)
            {
                claim.ComplaintStatus = model.Status.Capitalize();
                claim.DateUpdated = DateTime.Now;

                res = await _context.SaveChangesAsync() > 0;
            }


            return res;

        }
        public IQueryable<FeedbackViewModel> FetchFeedback(PagingParam param)
        {
            var requestQuery = from feedback in _context.EnrolleeFeedbacks.AsNoTracking()
                               select new FeedbackViewModel
                               {
                                   EnrolleeFeedbackId = feedback.EnrolleeFeedbackId,
                                   Name = feedback.Name,
                                   Email = feedback.Email,
                                   Subject = feedback.Subject,
                                   Message = feedback.Message
                               };

            var skip = (param.PageNumber - 1) * param.PageSize;

            return requestQuery.Skip(skip).Take(param.PageSize);
        }

        public List<ProviderPlansViewModel> GetProviderPlans(string providerClass)
        {
            return _context.ProviderPlanMap.Where(p => p.ProviderClass.ToLower() == providerClass)
                 .Select(x => new ProviderPlansViewModel
                 {
                     planName = x.Plan.Trim(),
                     providerClass = x.ProviderClass.Trim(),

                 }).ToList();

        }
        #endregion

        #region ReferralRequest
        public async Task<bool> CreateReferralRequest(ReferralRequestRequestModel refRequest, Guid userID)
        {
            var enrollee = _context.Enrollees.FirstOrDefault(x => x.EnrolleeId == refRequest.EnrolleeId);
            var memberNo = 0;
            if (enrollee == null)
            {
                memberNo = enrollee.MemberNumber.HasValue ? enrollee.MemberNumber.Value : 0;
            }
            var referralRequest = new ReferralRequest()
            {
                EnrolleeId = refRequest.EnrolleeId,
                MemberNo = memberNo,
                BeneficiaryName = refRequest.BeneficiaryName,
                ReferralDate = refRequest.ReferralDate.ToDateTime("dd/MM/yyyy"),
                ReferralTime = refRequest.ReferralTime,
                MedicalDocPath = refRequest.MedicalDocPath,
                CreatedBy = userID.ToString(),
                DateCreated = DateTime.Now,
                MedicalSummary = refRequest.MedicalSummary,
                ReferralStatus = "P",
                Deleted = false
            };

            await _context.ReferralRequests.AddAsync(referralRequest);

            var res = await _context.SaveChangesAsync() > 0;
            return res;
        }

        public IQueryable<ReferralRequestViewModel> FetchReferralRequest(PagingParam param)
        {
            var postQuery = from refRequest in _context.ReferralRequests.AsNoTracking()
                            select new ReferralRequestViewModel
                            {
                                EnrolleeId = refRequest.EnrolleeId,
                                MemberNo = refRequest.MemberNo,
                                BeneficiaryName = refRequest.BeneficiaryName,
                                ReferralDate = refRequest.ReferralDate.ToString(),
                                ReferralTime = refRequest.ReferralTime,
                                MedicalDocPath = refRequest.MedicalDocPath,
                                MedicalSummary = refRequest.MedicalSummary,
                                ReferralStatus = refRequest.ReferralStatus,
                                Reason = refRequest.Reason,
                                ReferralRequestId = refRequest.ReferralRequestId,
                                DateCreated = refRequest.DateCreated
                            };


            var skip = (param.PageNumber - 1) * param.PageSize;

            return postQuery.OrderByDescending(x => x.DateCreated).Skip(skip).Take(param.PageSize);
        }
        public async Task<ReferralRequestViewModel> FetchReferralRequestByID(Guid id)
        {
            var response = new ReferralRequestViewModel();
            var refRequest = await _context.ReferralRequests.AsNoTracking().FirstOrDefaultAsync(j => j.ReferralRequestId == id);
            if (refRequest != null)
            {
                response.EnrolleeId = refRequest.EnrolleeId;
                response.MemberNo = refRequest.MemberNo;
                response.BeneficiaryName = refRequest.BeneficiaryName;
                response.ReferralDate = refRequest.ReferralDate.ToString();
                response.ReferralTime = refRequest.ReferralTime;
                response.MedicalDocPath = refRequest.MedicalDocPath;
                response.MedicalSummary = refRequest.MedicalSummary;
                response.ReferralStatus = refRequest.ReferralStatus;
                response.Reason = refRequest.Reason;
                response.ReferralRequestId = refRequest.ReferralRequestId;
                response.DateCreated = refRequest.DateCreated;
            }

            return response;
        }

        public async Task<bool> ChangeProviderManager(HCPManagerModel model)
        {
            var newHCPManager = new HCPManagerRequest()
            {
                ManagerName = model.managerName,
                PhoneNumber = model.phoneNumber,
                RequestDate = DateTime.Now,
                Status = "P",
                ManagerCode = model.managerCode,
            };

            await _context.HCPManagerRequests.AddAsync(newHCPManager);

            return await _context.SaveChangesAsync() > 0;
        }


        #endregion
    }
}
