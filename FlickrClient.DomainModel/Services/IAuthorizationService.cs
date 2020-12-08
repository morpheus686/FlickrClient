using FlickrClient.DomainModel.EventArguments;
using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrClient.DomainModel.Services
{
    public delegate void AuthorizationChangedEventHandler(object sender, AuthorizationChangedEventArgs e);

    public interface IAuthorizationService
    {
        event AuthorizationChangedEventHandler AuthorizationChanged;
        Task<OAuthRequestToken> BeginAuthentification();
        Task EndAuthenfication(OAuthRequestToken oAuthRequestToken, string verificationCode);
        string GetAuthorizationName();
    }
}
