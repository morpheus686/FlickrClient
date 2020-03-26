using FlickrClient.DomainModel.Services;

namespace FlickrClient.ViewModel
{
    public class MainWindowViewModel
    {
        private readonly IDialogService _dialogService;

        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }
    }
}
