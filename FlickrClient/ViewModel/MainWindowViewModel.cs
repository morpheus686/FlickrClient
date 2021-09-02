using FlickrClient.Components.Commands;
using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlickrClient.ViewModel
{
    public class MainWindowViewModel : LoadableViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;

        public ICommand OpenAuthentificationDialogCommand { get; }
        public ICommand OpenUploadFotosDialogCommand { get; }
        public ICommand ShowSearchTabCommand { get; }
        public ICommand ShowPhotostreamTabCommand { get; set; }

        public MainWindowViewModel(
            IDialogService dialogService,
            INavigationService navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;

            OpenAuthentificationDialogCommand = new AsyncCommand(ExecuteOpenAuthentificationDialogCommand);
            ShowSearchTabCommand = new Command(ExecuteShowSearchTab);
            ShowPhotostreamTabCommand = new Command(ExecuteShowPhotostreamTab);
            OpenUploadFotosDialogCommand = new AsyncCommand(ExecuteOpenUploadFotosDialog);
        }

        private async Task ExecuteOpenUploadFotosDialog()
        {
            await _dialogService.ShowDialog("UploadView");
        }

        private void ExecuteShowSearchTab()
        {
            _navigationService.SetMainArea("SearchTabView");
        }

        private void ExecuteShowPhotostreamTab()
        {
            _navigationService.SetMainArea("PhotostreamTabView");
        }

        private async Task ExecuteOpenAuthentificationDialogCommand()
        {
            await _dialogService.ShowDialog("AuthentificationDialogView");
        }

        protected override void InitializeInternal()
        {
            _navigationService.SetMainArea("SearchTabView");
        }
    }
}