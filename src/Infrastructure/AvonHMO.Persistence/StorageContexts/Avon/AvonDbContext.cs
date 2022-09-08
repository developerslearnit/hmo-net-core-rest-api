using AvonHMO.Entities;
using AvonHMO.Persistence.AuditUtils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvonHMO.Persistence.StorageContexts.Avon
{

    public partial class AvonDbContext : DbContext //:
    {
        private string _userId;
        //UserResolverService userService  _userId = userService.GetUser(); 
        public AvonDbContext(DbContextOptions<AvonDbContext> options) : base(options)
        {
            //_userId = userService.GetUser();
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<SubscriptionHistory> SubscriptionHistories { get; set; }
        public virtual DbSet<EmailLog> EmailLogs { get; set; }
        public virtual DbSet<HCPInspectionGuildAnswer> HCPInspectionGuildAnswers { get; set; }
        public virtual DbSet<HCPInspectionGuideOptions> HCPInspectionGuildOptions { get; set; }
        public virtual DbSet<HCPInspectionGuideQuestionMaster> HCPInspectionGuildQuestionMasters { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<TempLog> TempLogs { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<AppUserStore> ApplicationUsers { get; set; }
        public virtual DbSet<BulkPaymentLog> BulkPaymentLogs { get; set; }
        public virtual DbSet<ChangePrimaryProviderRequest> ChangePrimaryProviderRequests { get; set; }

        public virtual DbSet<LoginToken> LoginTokens { get; set; }

        public virtual DbSet<PasswordChangeHistory> PasswordChangeHistories { get; set; }

        public virtual DbSet<PasswordResetRequest> PasswordChangeRequests { get; set; }

        public virtual DbSet<AppClient> AppClients { get; set; }

        public virtual DbSet<AppSetting> AppSettings { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<PartnerBroker> PartnerBrokers { get; set; }

        public virtual DbSet<PartnerAgent> PartnerAgents { get; set; }

        public virtual DbSet<PartnerProvider> PartnerProviders { get; set; }

        public virtual DbSet<NotificationLog> NotificationLogs { get; set; }
        public virtual DbSet<RiskAssessmentRequest> RiskAssessmentRequests { get; set; }
        public virtual DbSet<HospitalReview> HospitalReviews { get; set; }
        public virtual DbSet<ProviderRating> ProviderRatings { get; set; }
        public virtual DbSet<HospitalImage> HospitalImages { get; set; }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Enrollee> Enrollees { get; set; }
        public virtual DbSet<Temp_Enrollee> TemEnrollee { get; set; }

        public virtual DbSet<EnrolleeDependant> EnrolleeDependants { get; set; }

        public virtual DbSet<PostCategory> PostCategories { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Prospect> Prospects { get; set; }

        public virtual DbSet<PlanType> PlanTypes { get; set; }

        public virtual DbSet<CycleInfo> CycleInfos { get; set; }

        public virtual DbSet<CyclePlannerCategory> CyclePlannerCategories { get; set; }

        public virtual DbSet<Plan> Plans { get; set; }

        public virtual DbSet<RequestAuthorization> RequestAuthorizations { get; set; }

        public virtual DbSet<DependantRequest> DependantRequests { get; set; }
        public virtual DbSet<EnrolleeFeedback> EnrolleeFeedbacks { get; set; }
        public virtual DbSet<EnrolleeComplaint> EnrolleeComplaints { get; set; }
        public virtual DbSet<EnrolleeComplaintAdminResponse> EnrolleeComplaintAdminResponses { get; set; }
        public virtual DbSet<DrugRefillRequest> DrugRefillRequests { get; set; }

        public virtual DbSet<EnrolleeReferalCode> EnrolleeReferalCodes { get; set; }

        public virtual DbSet<Referalhistory> Referalhistories { get; set; }

        public virtual DbSet<PostMainCategory> MainCategories { get; set; }
        public virtual DbSet<ReferalTransaction> ReferalTransactions { get; set; }
        public virtual DbSet<RequestRefund> RequestRefunds { get; set; }
        public virtual DbSet<EnrolleeRecommendation> EnrolleeRecommendations { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<ProviderContact> ProviderContacts { get; set; }
        public virtual DbSet<RequestQuote> RequestQuotes { get; set; }
        public virtual DbSet<Claim> Claims { get; set; }
        public virtual DbSet<FAQCategory> FAQCategorys { get; set; }
        public virtual DbSet<FAQ> FAQs { get; set; }

        public virtual DbSet<PlanCategory> PlanCategories { get; set; }
        public virtual DbSet<UserPreference> UserPreferences { get; set; }
        public virtual DbSet<HealthRiskAssessmentQuestion> HealthRiskAssessmentQuestions { get; set; }

        public virtual DbSet<ProviderPlanMap> ProviderPlanMap { get; set; }
        public virtual DbSet<ReferralRequest> ReferralRequests { get; set; }

        public virtual DbSet<ProviderChangeLog> ProviderChangeLogs { get; set; }

        public DbSet<Audit> AuditLogs { get; set; }

        public virtual DbSet<ProviderContractualDoc> ProviderContractualDocs { get; set; }
        
        public DbSet<HCPManagerRequest> HCPManagerRequests { get; set; }

        //TODO::Remove this later
        public virtual DbSet<ExistingEnrolleAccountInfo> ExistingEnrolleAccountInfos { get; set; }

        private void OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();

            var user = _userId ?? "Anonnymous";

            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;
                var auditEntry = new AuditEntry(entry);
                auditEntry.TableName = entry.Entity.GetType().Name;
                auditEntry.UserId = user;
                auditEntries.Add(auditEntry);
                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = AuditType.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Deleted:
                            auditEntry.AuditType = AuditType.Delete;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.ChangedColumns.Add(propertyName);
                                auditEntry.AuditType = AuditType.Update;
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }
            foreach (var auditEntry in auditEntries)
            {
                AuditLogs.Add(auditEntry.ToAudit());
            }
        }

        //public virtual async Task<int> SaveChangesAsync()
        //{
        //    OnBeforeSaveChanges();
        //    var result = await base.SaveChangesAsync();
        //    return result;
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<HCPManagerRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId);
                entity.Property(e => e.RequestId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.RequestDate).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.Status).HasMaxLength(2).IsRequired();
                entity.Property(e => e.ManagerCode).HasMaxLength(10).IsRequired();
                entity.Property(e => e.ManagerName).HasMaxLength(150).IsRequired();
                entity.Property(e => e.PhoneNumber).HasMaxLength(12).IsRequired();
            });

            modelBuilder.Entity<ProviderContractualDoc>(entity =>
            {
                entity.HasKey(e => e.DocumentId);
                entity.Property(e => e.DocumentId).HasDefaultValueSql("(newid())");
                entity.Property(x => x.ProviderCode).IsRequired().HasMaxLength(50);
                entity.Property(x => x.DocumentUri).IsRequired().HasMaxLength(3000);
            });



            modelBuilder.Entity<SubscriptionHistory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(x => x.PlanId).IsRequired();
                entity.Property(x => x.DateTime).IsRequired();
                entity.Property(x => x.AmountPaid).IsRequired();
            });

            modelBuilder.Entity<EmailLog>(entity =>
            {
                entity.HasKey(e => e.EmailLogId);
                entity.Property(e => e.EmailLogId).HasDefaultValueSql("(newid())");
                entity.HasIndex(x => x.RequestReference).IsUnique();
            });
            modelBuilder.Entity<HCPInspectionGuildAnswer>(entity =>
            {
                entity.HasKey(e => e.AnswerId);
                entity.Property(e => e.AnswerId).HasDefaultValueSql("(newid())");
                entity.Property(x => x.Answer).IsRequired();
                entity.Property(x => x.QuestionId).IsRequired();
                entity.Property(x => x.HCPId);
            });
            modelBuilder.Entity<HCPInspectionGuideOptions>(entity =>
            {
                entity.HasKey(e => e.OptionId);
                entity.Property(e => e.OptionId).HasDefaultValueSql("(newid())");
                entity.Property(x => x.Option).IsRequired();
                entity.Property(x => x.QuestionId).IsRequired();
                entity.Property(x => x.OrderNo);
            });
            modelBuilder.Entity<HCPInspectionGuideQuestionMaster>(entity =>
            {
                entity.HasKey(e => e.QuestionId);
                entity.Property(e => e.QuestionId).HasDefaultValueSql("(newid())");
                entity.Property(x => x.Question).IsRequired();
                entity.Property(x => x.isMultipleChoice).IsRequired();
                entity.Property(x => x.orderNo);
            });


            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PaymentId);
                entity.Property(e => e.PaymentId).HasDefaultValueSql("(newid())");
                entity.Property(x => x.PaymentReference).IsRequired();
                entity.Property(x => x.Amount).IsRequired();
                entity.Property(x => x.DateCreated).IsRequired();
                entity.Property(x => x.ProductId).IsRequired();
                entity.HasIndex(x => x.PaymentReference).IsUnique();
            });

            modelBuilder.Entity<PlanCategory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(x => x.Code).IsRequired().HasMaxLength(4);
                entity.Property(x => x.CategoryName).IsRequired().HasMaxLength(255);
            });

            modelBuilder.Entity<TempLog>(entity =>
            {
                entity.ToTable("TempLog");
                entity.HasKey(x => x.TemLogId);
                entity.Property(e => e.TemLogId).HasDefaultValueSql("(newid())");
                entity.Property(x => x.DateCreated).IsRequired();
                entity.Property(x => x.Action).IsRequired(false);
                entity.Property(x => x.Message).IsRequired(false);
                entity.Property(x => x.Controller).IsRequired(false);
                entity.Property(x => x.PayLoad).IsRequired(false);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");
                entity.HasKey(x => x.CartId);
                entity.Property(e => e.CartId).HasDefaultValueSql("(newid())");
                entity.Property(x => x.DateCreated).IsRequired();
                entity.Property(x => x.ProductId).IsRequired();
                entity.Property(x => x.Price).IsRequired();
                entity.Property(x => x.Quantity).IsRequired();
                entity.Property(x => x.UniqueReference).IsRequired();
            });

            modelBuilder.Entity<BulkPaymentLog>(entity =>
            {
                entity.ToTable("BulkPaymentLog");
                entity.HasKey(x => x.BulkPaymentLogId);
                entity.Property(e => e.BulkPaymentLogId).HasDefaultValueSql("(newid())");
                entity.Property(x => x.NoOfPlans);
                entity.Property(x => x.PaymentReference);
                entity.Property(x => x.PaymentDate).IsRequired();
                entity.Property(x => x.PaymentMethod);
            });


            modelBuilder.Entity<NotificationLog>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.OwnerId).HasMaxLength(34).IsRequired();
                entity.Property(e => e.body).IsRequired();
                entity.Property(e => e.Subject).IsRequired();
                entity.Property(e => e.Status).IsRequired();

            });

            modelBuilder.Entity<UserPreference>(entity =>
            {
                entity.HasKey(e => e.PrefId);
                entity.Property(e => e.PrefId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.PrefKey).HasMaxLength(50).IsRequired();
                entity.Property(e => e.PrefValue).HasMaxLength(100).IsRequired();
                entity.Property(e => e.MemberNo).HasMaxLength(50).IsRequired();
            });


            modelBuilder.Entity<ExistingEnrolleAccountInfo>(ent =>
            {

                ent.HasKey(x => x.Id);
                ent.Property(x => x.FirstName).HasMaxLength(50);
                ent.Property(x => x.LastName).HasMaxLength(50);
                ent.Property(x => x.Email).HasMaxLength(100);
                ent.Property(x => x.Password).HasMaxLength(150);

            });

            modelBuilder.Entity<CyclePlannerCategory>(entity =>
            {
                entity.ToTable("CyclePlannerCategory");

                entity.HasKey(e => e.CyclePlannerCategoryId);
                entity.Property(e => e.CyclePlannerCategoryId).HasDefaultValueSql("(newid())");

            });

            modelBuilder.Entity<CycleInfo>(entity =>
            {
                entity.ToTable("CycleInfo");
                entity.HasKey(e => e.CycleId);
                entity.Property(e => e.CycleId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.AppuserId).IsRequired();
                entity.Property(e => e.PeriodCycle).IsRequired();
                entity.Property(e => e.PeriodDuration).IsRequired();
                entity.Property(e => e.CyclePlannerCategoryId);
            });

            modelBuilder.Entity<ChangePrimaryProviderRequest>(entity =>
            {
                entity.ToTable("ChangePrimaryProviderRequest");
                entity.HasKey(e => e.ChangeProviderRequestId);
                entity.Property(e => e.ChangeProviderRequestId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.MemberNumber).IsRequired();
                entity.Property(e => e.CurrentProviderCode).IsRequired();
                entity.Property(e => e.NewProviderCode).IsRequired();
                entity.Property(e => e.RequestDate).IsRequired();

                modelBuilder.Entity<ReferalTransaction>(ent =>
                {
                    ent.HasKey(r => r.ReferalTransactionId);
                    ent.Property(r => r.ReferalTransactionId).HasDefaultValueSql("(newid())");
                    ent.Property(r => r.ReferalCode).IsRequired().HasMaxLength(8);
                    ent.Property(r => r.EnrolleeReferalId).IsRequired();
                    ent.Property(r => r.EnrolleeIviteeId).IsRequired().HasMaxLength(50);
                    ent.Property(r => r.PlanCode).HasMaxLength(20).IsRequired();
                    ent.Property(r => r.Amount).IsRequired();
                    ent.Property(r => r.TransactionDate).IsRequired();
                });
            });

            modelBuilder.Entity<Referalhistory>(ent =>
            {
                ent.HasKey(r => r.ReferalhistoryId);
                ent.Property(r => r.ReferalhistoryId).HasDefaultValueSql("(newid())");
                ent.Property(r => r.ReferalCode).IsRequired().HasMaxLength(8);
                ent.Property(r => r.EnrolleeId).IsRequired();
                ent.Property(r => r.InviteePhone).IsRequired().HasMaxLength(50);
                ent.Property(r => r.ReferalLink).HasMaxLength(1000);
                ent.Property(r => r.ReferDate).IsRequired();
            });


            modelBuilder.Entity<EnrolleeReferalCode>(e =>
            {
                e.HasKey(r => r.EnrolleeReferalCodeId);
                e.Property(r => r.EnrolleeReferalCodeId).HasDefaultValueSql("(newid())");
                e.Property(r => r.ReferalCode).IsRequired().HasMaxLength(8);
            });


            modelBuilder.Entity<EnrolleeDependant>(entity =>
            {

                entity.HasKey(e => e.EnrolleeDependantId);
                entity.Property(e => e.EnrolleeDependantId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.HeadMemberEmail).HasMaxLength(100)
                    .IsRequired();
                entity.Property(e => e.FirstName).HasMaxLength(50)
              .IsRequired();
                entity.Property(e => e.Surname).HasMaxLength(50)
            .IsRequired();
                entity.Property(e => e.MiddleName).HasMaxLength(50);
                entity.Property(e => e.Title).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.MaritalStatus).HasMaxLength(20);

                entity.Property(e => e.PicturePath).HasMaxLength(2000);

                entity.Property(e => e.DateOfBirth)
                                   .IsRequired();

                entity.Property(e => e.Relationship).HasMaxLength(100);

                entity.Property(e => e.RelationshipId).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(20);

            });

            modelBuilder.Entity<Prospect>(entity =>
            {

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Name).HasMaxLength(500)
                    .IsRequired();
                entity.Property(e => e.Email).HasMaxLength(50)
              .IsRequired();

                entity.Property(e => e.DateCreated)
                                   .IsRequired();

            });

            modelBuilder.Entity<Comment>(entity =>
            {

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Content).HasMaxLength(1500)
                    .IsRequired();
                entity.Property(e => e.Author).HasMaxLength(50)
              .IsRequired();

                entity.Property(e => e.DateCreated)
                                   .IsRequired();

            });

            modelBuilder.Entity<PostMainCategory>(entity =>
            {
                entity.HasKey(e => e.Code);
                entity.Property(e => e.Name).HasMaxLength(250).IsRequired();
                entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Post>(entity =>
            {

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.CategoryId);
                entity.Property(e => e.Title).HasMaxLength(1000)
                    .IsRequired();
                entity.Property(e => e.Slug).HasMaxLength(1500)
                   .IsRequired();
                entity.Property(e => e.Content)
                                   .IsRequired();
                entity.Property(e => e.Excerpt).HasMaxLength(1500)
                                .IsRequired();
                entity.Property(e => e.Author).HasMaxLength(50)
                  .IsRequired();

                entity.Property(e => e.DateCreated)
                                   .IsRequired();

                entity.Property(e => e.PublishedDate)
                                  .IsRequired();

                entity.Property(e => e.FeaturedImage)
                                   .IsRequired(false)
                                   .HasMaxLength(1500);

                entity.Property(e => e.PostType).HasMaxLength(50)
                  .IsRequired();

            });

            modelBuilder.Entity<PostCategory>(entity =>
            {

                entity.HasKey(e => e.CategoryId);
                entity.Property(e => e.CategoryId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.CategoryName).HasMaxLength(350)
                    .IsRequired();
                entity.Property(e => e.PostType).HasMaxLength(50)
                  .IsRequired();
                entity.Property(e => e.Url).HasMaxLength(500);

            });


            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("AppRole");
                entity.HasKey(e => e.RoleId);
                entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.RoleName).HasMaxLength(50)
                    .IsRequired();

            });


            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("AppUserRole");
                entity.HasKey(e => e.UserRoleId);
                entity.Property(e => e.UserRoleId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.UserId)
                    .IsRequired();
                entity.Property(e => e.RoleId)
                    .IsRequired();

            });

            modelBuilder.Entity<Temp_Enrollee>(entity =>
            {
                entity.ToTable("Temp_Enrollee");
                entity.HasKey(e => e.Temp_EnrolleeId);
                entity.Property(e => e.Temp_EnrolleeId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Surname).IsRequired().HasMaxLength(100);
                entity.Property(e => e.DateOfBirth).IsRequired().HasMaxLength(10);
                entity.Property(e => e.Address).IsRequired(false).HasMaxLength(1000);
                entity.Property(e => e.Country).IsRequired(false).HasMaxLength(80);
                entity.Property(e => e.State).IsRequired(false).HasMaxLength(80);
                entity.Property(e => e.City).HasMaxLength(50);
                entity.Property(e => e.Title).HasMaxLength(10);
                entity.Property(e => e.Gender).HasMaxLength(10);
                entity.Property(m => m.MailingAddress).HasMaxLength(1000);
                entity.Property(m => m.PicturePath).HasMaxLength(2000);

                entity.Property(e => e.IsSponsored).IsRequired(false);
                entity.Property(m => m.PlanRate).IsRequired(false);
                entity.Property(m => m.TotalAmount).IsRequired(false);
                entity.Property(m => m.IsActive).IsRequired(false);
                entity.Property(m => m.ProviderName).IsRequired(false);
                entity.Property(m => m.OrderPaymentRefrence).IsRequired(false);
            });

            modelBuilder.Entity<Enrollee>(entity =>
            {
                entity.ToTable("Enrollee");
                entity.HasKey(e => e.EnrolleeId);
                entity.Property(e => e.EnrolleeId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Surname).IsRequired().HasMaxLength(100);
                entity.Property(e => e.DateOfBirth).IsRequired().HasMaxLength(10);
                entity.Property(e => e.Address).IsRequired(false).HasMaxLength(1000);
                entity.Property(e => e.Country).IsRequired(false).HasMaxLength(80);
                entity.Property(e => e.State).IsRequired(false).HasMaxLength(80);
                entity.Property(e => e.City).HasMaxLength(50);
                entity.Property(e => e.DateCreated).HasMaxLength(10);
                entity.Property(e => e.Comment).HasMaxLength(5000);
                entity.Property(e => e.Title).HasMaxLength(10);
                entity.Property(e => e.Gender).HasMaxLength(10);
                entity.Property(m => m.MailingAddress).HasMaxLength(1000);
                entity.Property(m => m.PicturePath).HasMaxLength(2000);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.IsSponsored).IsRequired(false);
                entity.Property(e => e.NumberOfBenefact).IsRequired(false);
                entity.Property(e => e.SkipOnlinePayment).IsRequired(false);
                entity.Property(m => m.PlanRate).IsRequired(false);
                entity.Property(m => m.TotalAmount).IsRequired(false);
                entity.Property(m => m.IsActive).IsRequired(false);
                entity.Property(m => m.ProviderName).IsRequired(false);
                entity.Property(m => m.OrderRef).IsRequired(false);
                entity.Property(m => m.PaymentRef).IsRequired(false);

            });
            modelBuilder.Entity<EnrolleeDependant>(entity =>
            {
                entity.HasKey(e => e.EnrolleeDependantId);
                entity.Property(e => e.EnrolleeDependantId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Surname).IsRequired().HasMaxLength(100);
                entity.Property(e => e.DateOfBirth).IsRequired().HasMaxLength(10);
                entity.Property(e => e.EnrolleeId).IsRequired();
                entity.Property(e => e.PicturePath).HasMaxLength(500);
                entity.Property(e => e.Title).HasMaxLength(4);
                entity.Property(e => e.Gender).HasMaxLength(5);
                entity.Property(m => m.PicturePath).HasMaxLength(2000);
            });


            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId);
                entity.Property(e => e.OrderId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.Surname).IsRequired().HasMaxLength(400);
                entity.Property(e => e.Address).IsRequired(false).HasMaxLength(1000);
                entity.Property(e => e.DateOfBirth).IsRequired().HasMaxLength(10);
                entity.Property(e => e.Country).HasMaxLength(50);
                entity.Property(e => e.State).HasMaxLength(50);
                entity.Property(e => e.City).HasMaxLength(50);
                entity.Property(e => e.DateCreated).HasMaxLength(10);
                entity.Property(e => e.OrderReference).IsRequired().HasMaxLength(20);
                entity.Property(e => e.PaymentReference).HasMaxLength(150);
                entity.Property(e => e.PicturePath).HasMaxLength(500);
                entity.Property(e => e.Title).HasMaxLength(10);
                entity.Property(e => e.Gender).HasMaxLength(10);
                entity.HasIndex(m => m.OrderReference).IsUnique();
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.ClientId);
                entity.Property(e => e.ClientId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.ClientNumber).IsRequired(false);
                entity.Property(e => e.ClientName).IsRequired().HasMaxLength(400);
                entity.Property(e => e.Address).IsRequired(false).HasMaxLength(1000);
                entity.Property(e => e.GroupId).IsRequired().HasMaxLength(10);
                entity.Property(e => e.Country).IsRequired().HasMaxLength(10);
                entity.Property(e => e.State).IsRequired().HasMaxLength(10);
                entity.Property(e => e.City).HasMaxLength(10);
                entity.Property(e => e.ClientIndustryType).HasMaxLength(10);
                entity.Property(e => e.ClientManager).HasMaxLength(10);
                entity.Property(e => e.CommunicationType).HasMaxLength(10);
                entity.Property(e => e.Logo).IsRequired(false);
                entity.Property(e => e.LocalGovtArea).HasMaxLength(50);
                entity.Property(e => e.PhoneCountryCode).HasMaxLength(5);
                entity.Property(e => e.ShortName).IsRequired(false).HasMaxLength(10);

            });

            modelBuilder.Entity<AppSetting>(entity =>
            {
                entity.HasKey(e => e.AppSettingId);
                entity.Property(e => e.AppSettingId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Key).HasMaxLength(20)
                .IsRequired();
                entity.Property(e => e.Key)
               .IsRequired();

            });

            modelBuilder.Entity<AppUserStore>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId)
                .HasColumnName("AppuserId")
                .HasDefaultValueSql("(newid())")
                .IsRequired();

                entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(200);

                entity.Property(e => e.MobilePhone)
                .HasMaxLength(22)
                .IsRequired(false);

                entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(2000);

                entity.Property(e => e.PasswordSalt)
                .IsRequired()
                .HasMaxLength(2000);

                entity.Property(e => e.FirstName)
                .IsRequired(false)
                .HasMaxLength(50);

                entity.Property(e => e.LastName)
                .IsRequired(false)
                .HasMaxLength(50);

                entity.Property(e => e.CompanyId)
                .IsRequired(false)
                .HasMaxLength(10);

                entity.Property(e => e.LoginMemberNo)
              .IsRequired(false)
              .HasMaxLength(15);


                entity.Property(e => e.DateCreated)
                 .IsRequired()
                 .HasDefaultValueSql("(getDate())");

            });

            modelBuilder.Entity<LoginToken>(entity =>
            {

                entity.HasKey(e => e.LoginTokenId);

                entity.Property(e => e.LoginTokenId)
                .HasColumnName("Id").HasDefaultValueSql("(newid())");

                entity.Property(e => e.ExpiryDate)
                .IsRequired();

                entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.AuthToken)
                .IsRequired()
                .HasMaxLength(2000);

            });

            modelBuilder.Entity<AppClient>(entity =>
            {
                entity.HasKey(e => e.AppClientId);

                entity.Property(e => e.AppClientId)
                .HasColumnName("ClientId").HasDefaultValueSql("(newid())");

                entity.Property(e => e.Status)
                .IsRequired();

                entity.Property(e => e.ClientName)
                .IsRequired()
                .HasMaxLength(200);

                entity.Property(e => e.ClientApiKey)
              .IsRequired()
              .HasMaxLength(2000);

                entity.Property(e => e.DateCreated)
                 .IsRequired()
                 .HasDefaultValueSql("(getDate())");
            });

            modelBuilder.Entity<PasswordChangeHistory>(entity =>
            {
                entity.HasKey(e => e.PasswordChangeHistoryId);

                entity.Property(e => e.PasswordChangeHistoryId)
                .HasColumnName("Id").HasDefaultValueSql("(newid())");

                entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(2000);

                entity.Property(e => e.ChangeDate)
                 .IsRequired()
                 .HasDefaultValueSql("(getDate())");
            });

            modelBuilder.Entity<PasswordResetRequest>(entity =>
            {
                entity.HasKey(e => e.ResetRequestId);
                entity.Property(e => e.ResetRequestId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Token)
                .HasMaxLength(50)
                .IsRequired();

                entity.Property(e => e.ExpiryDate)
                .IsRequired();

                entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.ExpiryDate)
               .IsRequired();

                entity.Property(e => e.RequestDate)
                 .IsRequired()
                 .HasDefaultValueSql("(getDate())");
            });

            modelBuilder.Entity<HospitalReview>(entity =>
            {
                entity.HasKey(e => e.HospitalReviewId);
                entity.Property(e => e.HospitalReviewId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.MemberNumber).IsRequired(false);
                entity.Property(e => e.EnrolleeId).IsRequired();
                entity.Property(e => e.HospitalCode).IsRequired();
                entity.Property(e => e.Occupation).IsRequired(false).HasMaxLength(100);
                entity.Property(e => e.Review).IsRequired().HasMaxLength(3000);
                entity.Property(e => e.Rating).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<ProviderRating>(entity =>
            {
                entity.HasKey(e => e.HospitalRatingId);
                entity.Property(e => e.HospitalRatingId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.EnrolleeAccountId).IsRequired();
                entity.Property(e => e.ProviderId).IsRequired();
                entity.Property(e => e.ProviderName).IsRequired(false).HasMaxLength(500);
                entity.Property(e => e.ReviewerName).IsRequired(false).HasMaxLength(100);
                entity.Property(e => e.Occupation).IsRequired(false).HasMaxLength(100);
                entity.Property(e => e.Review).IsRequired().HasMaxLength(3000);
                entity.Property(e => e.Rating).IsRequired().HasMaxLength(50);
                entity.Property(e => e.EasyAccessingCare).IsRequired().HasMaxLength(50);
                entity.Property(e => e.SatisfactoryLevel).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<RiskAssessmentRequest>(entity =>
            {
                entity.HasKey(e => e.RiskAssessmentRequestId);
                entity.Property(e => e.RiskAssessmentRequestId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Age).IsRequired().HasMaxLength(5);
                entity.Property(e => e.Address).IsRequired(false).HasMaxLength(1000);
                entity.Property(e => e.DrinkingFrequency).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Sex).IsRequired().HasMaxLength(10);
                entity.Property(e => e.IsSmoker).IsRequired().HasMaxLength(5);
            });

            modelBuilder.Entity<PartnerProvider>(entity =>
            {
                entity.HasKey(e => e.PartnerProviderId);
                entity.Property(e => e.PartnerProviderId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Surname).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Address).IsRequired(false).HasMaxLength(1000);
                entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.City).IsRequired().HasMaxLength(50);
                entity.Property(e => e.State).IsRequired(false).HasMaxLength(50);
                entity.Property(e => e.Country).IsRequired(false).HasMaxLength(50);
                entity.Property(e => e.LocalGovtArea).IsRequired(false).HasMaxLength(100);
                entity.Property(e => e.Title).IsRequired(false).HasMaxLength(10);
                entity.Property(e => e.ProviderName).IsRequired(false).HasMaxLength(200);
            });

            modelBuilder.Entity<PartnerAgent>(entity =>
            {
                entity.HasKey(e => e.PartnerAgentId);
                entity.Property(e => e.PartnerAgentId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Surname).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Address).IsRequired(false).HasMaxLength(1000);
                entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.City).IsRequired().HasMaxLength(50);
                entity.Property(e => e.State).IsRequired(false).HasMaxLength(50);
                entity.Property(e => e.Country).IsRequired(false).HasMaxLength(50);
                entity.Property(e => e.LocalGovtArea).IsRequired(false).HasMaxLength(100);
                entity.Property(e => e.Message).IsRequired(false).HasMaxLength(2000);
                entity.Property(e => e.Title).IsRequired(false).HasMaxLength(10);
            });

            modelBuilder.Entity<HospitalImage>(entity =>
            {
                entity.HasKey(e => e.HospitalImageId);
                entity.Property(e => e.HospitalImageId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Image).IsRequired().HasMaxLength(5000);
                entity.Property(e => e.HospitalCode).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<PartnerBroker>(entity =>
            {
                entity.HasKey(e => e.PartnerBrokerId);
                entity.Property(e => e.PartnerBrokerId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Surname).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Message).IsRequired().HasMaxLength(3000);
                entity.Property(e => e.Country).IsRequired().HasMaxLength(10);
                entity.Property(e => e.State).IsRequired().HasMaxLength(10);
                entity.Property(e => e.City).HasMaxLength(10);
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
                entity.Property(e => e.Address).HasMaxLength(500);
                entity.Property(e => e.CompanyName).HasMaxLength(300);
                entity.Property(e => e.Title).IsRequired(false).HasMaxLength(10);
                entity.Property(e => e.LocalGovtArea).HasMaxLength(50);


            });

            modelBuilder.Entity<PlanType>(entity =>
            {
                entity.HasKey(e => e.PlanTypeId);
                entity.Property(e => e.PlanTypeId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(400);
                entity.Property(e => e.PlanColor).HasMaxLength(10);
                entity.Property(e => e.PlanIcon).HasMaxLength(600);
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(e => e.PlanId);
                entity.Property(e => e.PlanId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.PlanName).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.Premium).IsRequired();
                entity.Property(e => e.PlanCode).IsRequired();
                entity.Property(e => e.SubCategory).IsRequired(false);
                entity.Property(e => e.PlanColor).HasMaxLength(10);
                entity.Property(e => e.PlanBgImage).HasMaxLength(600);
                entity.Property(e => e.PlanIcon).HasMaxLength(600);
                entity.Property(e => e.PlanClass).HasMaxLength(20).IsRequired(false);
            });




            modelBuilder.Entity<RequestAuthorization>(entity =>
            {
                entity.HasKey(e => e.RequestAuthorizationId);
                entity.Property(e => e.RequestAuthorizationId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.EnrolleeId).IsRequired();
                entity.Property(e => e.ProviderId);
                entity.Property(e => e.AvonEnrolleId).IsRequired(false).HasMaxLength(150);
                entity.Property(e => e.MemberNo).IsRequired(false).HasMaxLength(15);
                entity.Property(e => e.PACode).IsRequired(false).HasMaxLength(15);
                entity.Property(e => e.Email).IsRequired(false).HasMaxLength(250);
                entity.Property(e => e.PhoneNumber).IsRequired(false).HasMaxLength(30);
                entity.Property(e => e.Reason).IsRequired(false).HasMaxLength(5000);


            });

            modelBuilder.Entity<ReferralRequest>(entity =>
            {
                entity.HasKey(e => e.ReferralRequestId);
                entity.Property(e => e.ReferralRequestId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.BeneficiaryName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.ReferralDate).IsRequired();
                entity.Property(e => e.ReferralTime).IsRequired();
                entity.Property(e => e.EnrolleeId).IsRequired().HasMaxLength(150);
                entity.Property(e => e.MemberNo).IsRequired(false).HasMaxLength(15);
                entity.Property(e => e.MedicalSummary).IsRequired(false).HasMaxLength(5000);
                entity.Property(e => e.ReferralStatus).IsRequired(false).HasMaxLength(50);
                entity.Property(e => e.MedicalDocPath).IsRequired();


            });

            modelBuilder.Entity<DependantRequest>(entity =>
            {
                entity.HasKey(e => e.DependantRequestId);
                entity.Property(e => e.DependantRequestId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Surname).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Title).IsRequired(false).HasMaxLength(50);
                entity.Property(e => e.MaritalStatus).IsRequired(false).HasMaxLength(50);
                entity.Property(e => e.EnrolleeId).IsRequired();
                entity.Property(e => e.MemberNo).IsRequired(false);
                entity.Property(e => e.RelationshipId).IsRequired();
                entity.Property(e => e.Gender).IsRequired(false);
                entity.Property(e => e.YourPlan);
                entity.Property(e => e.DateOfBirth);
                entity.Property(e => e.PicturePath).IsRequired(false);
                entity.Property(e => e.RequestStatus).IsRequired(false);
                entity.Property(e => e.Email).IsRequired(false).HasMaxLength(150);
                entity.Property(e => e.PhoneNumber).IsRequired(false).HasMaxLength(50);


            });

            modelBuilder.Entity<DrugRefillRequest>(entity =>
            {
                entity.HasKey(e => e.DrugRefillRequestId);
                entity.Property(e => e.DrugRefillRequestId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Surname).IsRequired().HasMaxLength(50);
                entity.Property(e => e.EnrolleeId).IsRequired();
                entity.Property(e => e.MemberNo).IsRequired(false);
                entity.Property(e => e.Email).IsRequired(false);
                entity.Property(e => e.PhoneNumber).IsRequired(false);
                entity.Property(e => e.DeliverAddress).IsRequired(false);
                entity.Property(e => e.DateOfBirth).IsRequired(false);
                entity.Property(e => e.PrescriptionePath).IsRequired();
                entity.Property(e => e.RequestStatus).IsRequired(false);
                entity.Property(e => e.RequestState).IsRequired();
                entity.Property(e => e.MonthlyRefill);



            });

            modelBuilder.Entity<RequestRefund>(entity =>
            {
                entity.HasKey(e => e.RequestRefundId);
                entity.Property(e => e.RequestRefundId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.MemberNo).IsRequired(false);
                entity.Property(e => e.EnrolleeId).IsRequired();
                entity.Property(e => e.Reason).IsRequired(false);
                entity.Property(e => e.OtherReasons).IsRequired(false);
                entity.Property(e => e.Amount).IsRequired();
                entity.Property(e => e.RequestStatus).IsRequired(false);
                entity.Property(e => e.EncounteredDate).IsRequired();
                entity.Property(e => e.HospitalLocation).IsRequired(false);
                entity.Property(e => e.HospitalName).IsRequired(false);
                entity.Property(e => e.BeneficiaryName).IsRequired(false);
                entity.Property(e => e.AccountNumber).IsRequired(false);
                entity.Property(e => e.BankName).IsRequired(false);
                entity.Property(e => e.CompanyName).IsRequired(false);
                entity.Property(e => e.PACode).IsRequired(false);
                entity.Property(e => e.MedicalReportDoc).IsRequired(false);
                entity.Property(e => e.InvoiceDoc).IsRequired(false);
                entity.Property(e => e.ReceiptsDoc).IsRequired(false);

            });

            modelBuilder.Entity<EnrolleeRecommendation>(entity =>
            {
                entity.HasKey(e => e.EnrolleeRecommendationId);
                entity.Property(e => e.EnrolleeRecommendationId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Recommendation).IsRequired(false);
                entity.Property(e => e.BeneficairyName).IsRequired().HasMaxLength(250);
                entity.Property(e => e.RecommendationCategory).IsRequired().HasMaxLength(100);
                entity.Property(e => e.EnrolleeId).IsRequired();
                entity.Property(e => e.MemberNo).IsRequired(false);


            });


            modelBuilder.Entity<ProviderContact>(entity =>
            {
                entity.HasKey(e => e.ProviderContactID);
                entity.Property(e => e.ProviderContactID).HasDefaultValueSql("(newid())");
                entity.Property(e => e.ProviderID).IsRequired();
                entity.Property(e => e.ContactName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.ContactEmail).IsRequired(false).HasMaxLength(100);
                entity.Property(e => e.ContactPhoneNo).IsRequired().HasMaxLength(20);
                entity.Property(e => e.ContactDesignation).IsRequired(false).HasMaxLength(100);
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(e => e.ProviderID);
                entity.Property(e => e.ProviderID).HasDefaultValueSql("(newid())");
                entity.Property(e => e.DoctorCoverageHour).IsRequired().HasMaxLength(256);
                entity.Property(e => e.ProviderName).IsRequired().HasMaxLength(510);
                entity.Property(e => e.HMOOfficerGSM).IsRequired().HasMaxLength(25);
                entity.Property(e => e.Address).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.LGA).IsRequired(false).HasMaxLength(50);
                entity.Property(e => e.State).IsRequired().HasMaxLength(50);
                entity.Property(e => e.City).IsRequired().HasMaxLength(50);
                entity.Property(e => e.MDName).IsRequired(false).HasMaxLength(500);
                entity.Property(e => e.MDEmail).IsRequired(false).HasMaxLength(100);
                entity.Property(e => e.MDPhoneNo).IsRequired(false).HasMaxLength(20);
                entity.Property(e => e.MDDirectLine).IsRequired(false).HasMaxLength(500);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(500);
                // entity.Property(e => e.Phoneno).IsRequired().HasMaxLength(500);
                entity.Property(e => e.HMOOfficerName).IsRequired(false).HasMaxLength(500);
                entity.Property(e => e.ProviderOperationDay).IsRequired(false).HasMaxLength(500);
                entity.Property(e => e.HMODeskPhoneNo).IsRequired(false).HasMaxLength(20);
                entity.Property(e => e.ProviderServiceType).IsRequired(false).HasMaxLength(100);
                entity.Property(e => e.ProviderOperationHour).IsRequired().HasMaxLength(500);
                entity.Property(e => e.ProviderOperationDay).IsRequired().HasMaxLength(500);
                entity.Property(e => e.DoctorCoverageHour).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Bankname).IsRequired(false).HasMaxLength(100);
                entity.Property(e => e.AccountName).IsRequired(false).HasMaxLength(100);
                entity.Property(e => e.AccountNo).IsRequired(false).HasMaxLength(10);
                entity.Property(e => e.SortCode).IsRequired(false).HasMaxLength(50);

                entity.Property(e => e.ProviderOperationHour).IsRequired(false).HasMaxLength(510);
                //entity.Property(e => e.ImageUrl).IsRequired(false).HasMaxLength(5000);
            });
            modelBuilder.Entity<RequestQuote>(entity =>
            {
                entity.HasKey(e => e.RequestQuoteId);
                entity.Property(e => e.RequestQuoteId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(150);
                entity.Property(e => e.PlanName).IsRequired().HasMaxLength(350);
                entity.Property(e => e.EmailAddress).IsRequired().HasMaxLength(100);
                entity.Property(e => e.MobileNumber).IsRequired().HasMaxLength(20);
                entity.Property(e => e.CompanyName).IsRequired().HasMaxLength(250);
                entity.Property(e => e.CompanyAddress).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.ContactRole).IsRequired().HasMaxLength(100);
                entity.Property(e => e.NoToEnrollee).IsRequired().HasMaxLength(5);
                entity.Property(e => e.InternationalHealthPlan);
                entity.Property(e => e.CompanyAndLargeAssociation);
            });

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.HasKey(e => e.ClaimId);
                entity.Property(e => e.ClaimId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(150);
                entity.Property(e => e.PreAuthorizationCode).IsRequired().HasMaxLength(20);
                entity.Property(e => e.PlanName).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Gender).IsRequired(false).HasMaxLength(20);
                entity.Property(e => e.Diagnosis).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.Services).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.EncounterDate).IsRequired();
                entity.Property(e => e.CloseClaim);
                entity.Property(e => e.CloseReason).IsRequired(false).HasMaxLength(500);
                entity.Property(e => e.Amount).IsRequired().HasMaxLength(5);
                entity.Property(e => e.Notes).IsRequired(false).HasMaxLength(1000);
            });

            modelBuilder.Entity<FAQCategory>(entity =>
            {
                entity.HasKey(e => e.FAQCategoryId);
                entity.Property(e => e.FAQCategoryId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);

            });

            modelBuilder.Entity<FAQ>(entity =>
            {
                entity.HasKey(e => e.FAQId);
                entity.Property(e => e.FAQId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.FAQCategoryId).IsRequired();
                entity.Property(e => e.QuestionText).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.AnswerText).IsRequired().HasMaxLength(8000);

            });

            modelBuilder.Entity<HealthRiskAssessmentQuestion>(entity =>
            {
                entity.HasKey(e => e.HealthRiskAssessmentQuestionId);
                entity.Property(e => e.HealthRiskAssessmentQuestionId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.QuestionText).IsRequired().HasMaxLength(2000);

            });

            modelBuilder.Entity<EnrolleeFeedback>(entity =>
            {
                entity.HasKey(e => e.EnrolleeFeedbackId);
                entity.Property(e => e.EnrolleeFeedbackId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Message).IsRequired(false).HasMaxLength(5000);
                entity.Property(e => e.Name).IsRequired(false).HasMaxLength(500);
                entity.Property(e => e.Email).IsRequired(false).HasMaxLength(500);
                entity.Property(e => e.Subject).IsRequired(false).HasMaxLength(500);

            });

            modelBuilder.Entity<EnrolleeComplaint>(entity =>
            {
                entity.HasKey(e => e.EnrolleeComplaintId);
                entity.Property(e => e.EnrolleeComplaintId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Message).IsRequired(false).HasMaxLength(5000);
                entity.Property(e => e.Name).IsRequired(false).HasMaxLength(500);
                entity.Property(e => e.Email).IsRequired(false).HasMaxLength(500);
                entity.Property(e => e.MemberNo).IsRequired(false).HasMaxLength(50);
                entity.Property(e => e.EnrolleeId).IsRequired();
                entity.Property(e => e.Plan).IsRequired(false).HasMaxLength(500);
                entity.Property(e => e.ComplaintStatus).IsRequired(false).HasMaxLength(10);
                entity.Property(e => e.Subject).IsRequired(false).HasMaxLength(500);

            });
            modelBuilder.Entity<EnrolleeComplaintAdminResponse>(entity =>
            {
                entity.HasKey(e => e.EnrolleeComplaintAdminId);
                entity.Property(e => e.EnrolleeComplaintAdminId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.EnrolleeComplaintId).IsRequired();
                entity.Property(e => e.AdminResponse).IsRequired().HasMaxLength(5000);

            });

            modelBuilder.Entity<Audit>(entity =>
            {
                entity.HasKey(e => e.Id);

            });



            modelBuilder.Entity<ProviderChangeLog>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.MemberNo).IsRequired().HasMaxLength(15);

            });



            modelBuilder.Entity<ProviderPlanMap>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.ProviderClass).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Plan).IsRequired().HasMaxLength(255);

            });




            //SeedData(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
