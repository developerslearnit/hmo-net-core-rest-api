using AvonHMO.Application.ViewModels.Avon.Authentication;
using AvonHMO.Application.ViewModels.Avon.Notifications;
using AvonHMO.Application.ViewModels.Avon.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Domain.Interfaces.Avon
{
    public interface ISettings
    {
        string GetSetting(string configKey);
        void LoadAppSetting();
        void AddSetting(string key, string value);

        void AddSetting(List<SettingsViewModel> settings);
        void SeedSettings(List<KeyValuePair<string, string>> model);

        string GetUserPref(string key, string memberNo);
        List<PrefModel> GetUserPrefs(string memberNo);
        void SetUserPref(string key,string memberNo, string value);
        Guid AddEmailLog(EmailViewModel model);
        void UpdateEmailLog(EmailViewModel model);
        Task<List<EmailViewModel>> GetEmailLog();
        Task<List<EmailViewModel>> GetEmailLogForUser(string userId);
        Task<bool> IsDuplicateRequest(string reference);
        Task<EmailViewModel> GetEmailLogById(Guid logId);
    }
}
