using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
using FlickrClient.Profile.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FlickrClient.Upload.ViewModel
{
    internal class UploadViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly IProfileManager _profileManager;

        public ObservableCollection<UploadItemTemplateViewModel> UploadItems { get; }
        public ICommand UploadCommand { get; }

        public UploadViewModel(IDialogService dialogService,
            IProfileManager profileManager)
        {
            _dialogService = dialogService;
            _profileManager = profileManager;

            UploadItems = new ObservableCollection<UploadItemTemplateViewModel>();
        }
    }
}
