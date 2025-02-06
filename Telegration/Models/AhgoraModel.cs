namespace Telegration.Models
{
    public class AhgoraModel(string siteUrl, string userRegistration, string userPassword)
    {
        public string SiteUrl { get; set; } = siteUrl;

        public string UserRegistration { get; set; } = userRegistration;

        public string UserPassword { get; set; } = userPassword;
    }
}
