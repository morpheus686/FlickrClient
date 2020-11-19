using FlickrClient.DomainModel.Services;
using FlickrNet;

namespace FlickrClient.Services
{
    public class SettingsService : ISettingsService
    {
        public FlickrNet.OAuthAccessToken GetOAuthAccessToken()
        {
            return Properties.Settings.Default.OAuthToken;
        }

        public void SetOAuthoAccessToken(OAuthAccessToken oAuthAccessToken)
        {
            Properties.Settings.Default.OAuthToken = oAuthAccessToken;
            Properties.Settings.Default.Save();
        }
    }
}
