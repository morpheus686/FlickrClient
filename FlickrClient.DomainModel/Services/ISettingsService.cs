using FlickrNet;

namespace FlickrClient.DomainModel.Services
{
    public interface ISettingsService
    {
        OAuthAccessToken GetOAuthAccessToken();
        void SetOAuthoAccessToken(OAuthAccessToken oAuthAccessToken);
    }
}
