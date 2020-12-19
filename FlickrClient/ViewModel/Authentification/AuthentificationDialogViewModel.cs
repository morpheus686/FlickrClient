using FlickrClient.Components.Commands;
using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlickrClient.ViewModel.Authentification
{
    public class AuthentificationDialogViewModel : LoadableViewModel
    {
        private readonly IAuthorizationService _authorizationService;
        private OAuthRequestToken _requestToken;

        public ICommand AuthenficateCommand { get; }
        public ICommand VerifyingCommand { get; }

        public string VerificationCode { get; set; }
        public string UserName { get => _authorizationService.GetAuthorizationName(); }

        public AuthentificationDialogViewModel(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;

            AuthenficateCommand = new AsyncCommand(ExecuteAuthentificateCommand);
            VerifyingCommand = new Command(CanExecuteVerifyingCommand, ExecuteVerifyingCommand);
        }

        private async void ExecuteVerifyingCommand()
        {
            await _authorizationService.EndAuthentification(_requestToken, VerificationCode);
            RaisePropertyChanged(nameof(UserName));
        }

        private bool CanExecuteVerifyingCommand()
        {
            return !string.IsNullOrWhiteSpace(VerificationCode);
        }

        private async Task ExecuteAuthentificateCommand()
        {
            _requestToken = await _authorizationService.BeginAuthentification();
            RaisePropertyChanged(nameof(UserName));
        }
    }
}
