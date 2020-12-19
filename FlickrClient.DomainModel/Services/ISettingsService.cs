using FlickrNet;

namespace FlickrClient.DomainModel.Services
{
    public interface ISettingsService
    {
        int GetMaxPhotosPerPage();
        OAuthAccessToken GetOAuthAccessToken();
        void SetMaxPhotosPerPage(int maximum);
        void SetOAuthoAccessToken(OAuthAccessToken oAuthAccessToken);
    }
}
