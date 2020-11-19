using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
using System.Threading.Tasks;

namespace FlickrClient.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;

        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        protected override Task InitializeInternalAsync()
        {
            return _dialogService.ShowDialog(this, "EditProfileDialogView");
        }
    }
}
