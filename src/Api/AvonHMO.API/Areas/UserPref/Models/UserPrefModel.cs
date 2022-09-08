namespace AvonHMO.API.Areas.UserPref.Models
{
    public class UserPrefModel
    {
        public string prefType { get; set; } // cycle_planned, referer_sent,toggle_notification,toggle_cycleplanner

        public string prefValue { get; set; }

        public string enrollee_id { get; set; }
    }

   
}
