using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
using FlickrClient.Profile.Services;

namespace FlickrClient.Upload.ViewModel
{
    internal class UploadViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly IProfileManager _profileManager;



        public UploadViewModel(IDialogService dialogService,
            IProfileManager profileManager)
        {
            _dialogService = dialogService;
            _profileManager = profileManager;
        }
    }
}
