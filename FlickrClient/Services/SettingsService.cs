using FlickrClient.DomainModel.Services;
using FlickrNet;

namespace FlickrClient.Services
{
    public class SettingsService : ISettingsService
    {
        public int GetMaxPhotosPerPage()
        {
            return Properties.Settings.Default.MaxPhotosPerPage;
        }

        public FlickrNet.OAuthAccessToken GetOAuthAccessToken()
        {
            return Properties.Settings.Default.OAuthToken;
        }

        public void SetMaxPhotosPerPage(int maximum)
        {
            Properties.Settings.Default.MaxPhotosPerPage = maximum;
            SaveSettings();
        }

        public void SetOAuthoAccessToken(OAuthAccessToken oAuthAccessToken)
        {
            Properties.Settings.Default.OAuthToken = oAuthAccessToken;
            SaveSettings();
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }
    }
}
