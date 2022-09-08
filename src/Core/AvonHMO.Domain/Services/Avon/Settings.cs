using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvonHMO.Application.ViewModels.Avon.Authentication;
using AvonHMO.Application.ViewModels.Avon.Notifications;
using AvonHMO.Application.ViewModels.Avon.ViewModels;
using AvonHMO.Domain.Interfaces.Avon;
using AvonHMO.Entities;
using AvonHMO.Persistence.StorageContexts.Avon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AvonHMO.Domain.Services.Avon
{
    public class Settings : ISettings
    {

        private readonly AvonDbContext _context;
        public Settings(AvonDbContext context)
        {
            _context = context;
        }


        public string GetSetting(string configKey)
        {
            var setting = _context.AppSettings.AsNoTracking().FirstOrDefault(x => x.Key == configKey);

            if (setting == null) return null;

            return setting.Value;
        }

        public void LoadAppSetting()
        {
            throw new NotImplementedException();
        }

        public void AddSetting(string key, string value)
        {
            var setting = _context.AppSettings.FirstOrDefault(x => x.Key == key);

            if (setting == null)
            {
                var newSetting = new AppSetting()
                {
                    Key = key,
                    Value = value
                };

                _context.AppSettings.Add(newSetting);

            }
            else
            {
                setting.Value = value;
            }

            _context.SaveChanges();
        }

        public void SeedSettings(List<KeyValuePair<string, string>> model)
        {
            foreach (var item in model)
            {
                AddSetting(item.Key, item.Value);
            }
        }

        public string GetUserPref(string key, string memberNo)
        {
            var pref = _context.UserPreferences.Where(x => x.PrefKey == key && x.MemberNo == memberNo).FirstOrDefault();
            if (pref == null) return string.Empty;

            return pref.PrefValue;
        }

        public void SetUserPref(string key, string memberNo, string value)
        {
            var pref = _context.UserPreferences.Where(x => x.PrefKey == key && x.MemberNo == memberNo).FirstOrDefault();

            if (pref == null)
            {
                var newPref = new UserPreference()
                {
                    MemberNo = memberNo,
                    PrefValue = value,
                    PrefKey = key
                };

                _context.UserPreferences.Add(newPref);
            }
            else
            {
                pref.PrefValue = value;
            }

            _context.SaveChanges();
        }

        public void AddSetting(List<SettingsViewModel> settings)
        {
            foreach (var item in settings)
            {
                var setting = _context.AppSettings.FirstOrDefault(x => x.Key == item.SettingKey);

                if (setting == null)
                {
                    var newSetting = new AppSetting()
                    {
                        Key = item.SettingKey,
                        Value = item.SettingValue
                    };

                    _context.AppSettings.Add(newSetting);

                }
                else
                {
                    setting.Value = item.SettingValue;
                }

            }

            _context.SaveChanges();
        }

        public List<PrefModel> GetUserPrefs(string memberNo)
        {
            return _context.UserPreferences.Where(_x => _x.MemberNo == memberNo)
                .Select(x => new PrefModel() { 
                
                    prefType = x.PrefKey,
                    prefValue =x.PrefValue
                
                }).ToList();
        }

        public Guid AddEmailLog(EmailViewModel model)
        {
            var log = new EmailLog()
            {
                RecipientEmailAddress = model.RecipientEmailAddress,
                MailBody = model.MailBody,
                MessageTitle = model.MessageTitle,
                AttachmentFileName = model.AttachmentFileName,
                HasAttachment = model.HasAttachment,
                IsProcessed = model.IsProcessed,
                IsProcessing = model.IsProcessing,
                RequestReference = model.RequestReference,
                SendDateAndTime = model.SendDateAndTime,
                SendStatus = model.SendStatus,
                SendSuccessfully = model.SendSuccessfully,
                UserId = model.UserId,
                AttachmentFileUrl=model.AttachmentFileUrl

                
            };
            _context.Add(log);

            if (_context.SaveChanges() > 0)
            {
                return log.EmailLogId;
            }
            throw new Exception("unable to save email log ");
        }

        public void UpdateEmailLog(EmailViewModel model)
        {
            var data = _context.EmailLogs.FirstOrDefault(x => x.EmailLogId == model.EmailLogId);
            data.RecipientEmailAddress = model.RecipientEmailAddress;
            data.MailBody = model.MailBody;
            data.MessageTitle = model.MessageTitle;
            data.AttachmentFileName = model.AttachmentFileName;
            data.HasAttachment = model.HasAttachment;
            data.IsProcessed = model.IsProcessed;
            data.IsProcessing = model.IsProcessing;
            data.SendStatus = model.SendStatus;
            data.SendSuccessfully = model.SendSuccessfully;
            data.AttachmentFileUrl=model.AttachmentFileUrl;
            _context.SaveChanges();

        }

        public async Task<bool> IsDuplicateRequest(string reference)
        {
            return await _context.EmailLogs.AnyAsync(k=>k.RequestReference==reference);
        }

        public async Task<EmailViewModel> GetEmailLogById(Guid logId)
        {
            return await _context.EmailLogs.Select(x => new EmailViewModel()
            {
                MailBody = x.MailBody,
                MessageTitle = x.MessageTitle,
                AttachmentFileName = x.AttachmentFileName,
                AttachmentFileUrl = x.AttachmentFileUrl,
                EmailLogId = x.EmailLogId,
                HasAttachment = x.HasAttachment,
                IsProcessed = x.IsProcessed,
                IsProcessing = x.IsProcessing,
                RecipientEmailAddress = x.RecipientEmailAddress,
                RequestReference = x.RequestReference,
                SendDateAndTime = x.SendDateAndTime,
                SendStatus = x.SendStatus,
                SendSuccessfully = x.SendSuccessfully,
                UserId = x.UserId,
            }).FirstOrDefaultAsync(j => j.EmailLogId==logId);
        }
        public async Task<List<EmailViewModel>> GetEmailLog()
        {
            return await _context.EmailLogs.Select(x => new EmailViewModel()
            {
                MailBody = x.MailBody,
                MessageTitle = x.MessageTitle,
                AttachmentFileName = x.AttachmentFileName,
                AttachmentFileUrl = x.AttachmentFileUrl,
                EmailLogId = x.EmailLogId,
                HasAttachment = x.HasAttachment,
                IsProcessed = x.IsProcessed,
                IsProcessing = x.IsProcessing,
                RecipientEmailAddress = x.RecipientEmailAddress,
                RequestReference = x.RequestReference,
                SendDateAndTime = x.SendDateAndTime,
                SendStatus = x.SendStatus,
                SendSuccessfully = x.SendSuccessfully,
                UserId = x.UserId,
            }).OrderByDescending(j => j.SendDateAndTime).ToListAsync();
        }
        public async Task<List<EmailViewModel>> GetEmailLogForUser(string userId)
        {
            return await _context.EmailLogs.Where(l=>l.UserId==userId).Select(x => new EmailViewModel()
            {
                MailBody = x.MailBody,
                MessageTitle = x.MessageTitle,
                AttachmentFileName = x.AttachmentFileName,
                AttachmentFileUrl = x.AttachmentFileUrl,
                EmailLogId = x.EmailLogId,
                HasAttachment = x.HasAttachment,
                IsProcessed = x.IsProcessed,
                IsProcessing = x.IsProcessing,
                RecipientEmailAddress = x.RecipientEmailAddress,
                RequestReference = x.RequestReference,
                SendDateAndTime = x.SendDateAndTime,
                SendStatus = x.SendStatus,
                SendSuccessfully = x.SendSuccessfully,
                UserId = x.UserId,
            }).OrderByDescending(j => j.SendDateAndTime).ToListAsync();
        }

    }
}
