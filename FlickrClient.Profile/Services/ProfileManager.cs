using FlickrClient.DomainModel.Services;
using FlickrNet;

namespace FlickrClient.Profile.Services
{
    internal class ProfileManager : IProfileManager
    {
        private const string ApiKey = "3a68f22971d8d66b521b362c312c175c";
        private const string SharedSecret = "b2acf0fb7910be24";

        private readonly ISettingsService _settingsService;

        public ProfileManager(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public Flickr GetInstance()
        {
            return new Flickr(ApiKey, SharedSecret);
        }

        public Flickr GetAuthInstance()
        {
            var f = new Flickr(ApiKey, SharedSecret)
            {
                OAuthAccessToken = _settingsService.GetOAuthAccessToken().Token,
                OAuthAccessTokenSecret = _settingsService.GetOAuthAccessToken().TokenSecret
            };

            return f;
        }
    }
}
