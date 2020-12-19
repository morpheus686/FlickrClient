using FlickrClient.DomainModel.Services;
using FlickrNet;

namespace FlickrClient.Services
{
    internal class FlickrService : IFlickrService
    {
        private const string ApiKey = "3a68f22971d8d66b521b362c312c175c";
        private const string SharedSecret = "b2acf0fb7910be24";

        private readonly ISettingsService _settingsService;

        public FlickrService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public Flickr GetAuthorizationInstance()
        {
            var f = new Flickr(ApiKey, SharedSecret);

            OAuthAccessToken oAuthAccessToken = _settingsService.GetOAuthAccessToken();

            if (oAuthAccessToken == null)
            {
                return GetInstance();
            }

            f.OAuthAccessToken = oAuthAccessToken.Token;
            f.OAuthAccessTokenSecret = oAuthAccessToken.TokenSecret;

            return f;
        }

        public Flickr GetInstance()
        {
            return new Flickr(ApiKey, SharedSecret);
        }

        public bool HasAccessToken()
        {
            return _settingsService.GetOAuthAccessToken() != null;
        }
    }
}
