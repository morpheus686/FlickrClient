using FlickrClient.DomainModel.EventArguments;
using FlickrClient.DomainModel.Services;
using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrClient.Services
{
    internal class AuthorizationService : IAuthorizationService
    {
        private const string AuthorizationRequestText = "oob";

        private readonly ISettingsService _settingsService;
        private readonly IFlickrService _flickrService;

        public event AuthorizationChangedEventHandler AuthorizationChanged;

        public AuthorizationService(ISettingsService settingsService,
            IFlickrService flickrService)
        {
            _settingsService = settingsService;
            _flickrService = flickrService;
        }

        public async Task<OAuthRequestToken> BeginAuthentification()
        {
            Flickr flickr = _flickrService.GetInstance();
            var tcs = new TaskCompletionSource<FlickrResult<OAuthRequestToken>>();

            flickr.OAuthGetRequestTokenAsync(AuthorizationRequestText,
                result =>
                {
                    tcs.SetResult(result);
                });
 
            var requestTokenResult = await tcs.Task;

            string url = flickr.OAuthCalculateAuthorizationUrl(requestTokenResult.Result.Token, AuthLevel.Write);
            System.Diagnostics.Process.Start(url);
            return requestTokenResult.Result;
        }

        public async Task EndAuthenfication(OAuthRequestToken requestToken, string verificationCode)
        {
            if (String.IsNullOrEmpty(verificationCode))
            {
                throw new Exception("Verifier code must not be empty!");
            }

            Flickr flickr = _flickrService.GetInstance();
            var tcs = new TaskCompletionSource<FlickrResult<OAuthAccessToken>>();
            
            flickr.OAuthGetAccessTokenAsync(requestToken, 
                verificationCode, 
                result =>
                {
                    tcs.SetResult(result);
                });

            var accessTokenResult = await tcs.Task;
            _settingsService.SetOAuthoAccessToken(accessTokenResult.Result);
            RaiseAuthorizationChanged();
        }

        private void RaiseAuthorizationChanged()
        {
            AuthorizationChanged?.Invoke(this, new AuthorizationChangedEventArgs());
        }

        public string GetAuthorizationName()
        {
            var accessToken = _settingsService.GetOAuthAccessToken();

            if (accessToken == null)
            {
                return string.Empty;
            }

            return accessToken.Username;
        }
    }
}
