using FlickrClient.Components.Commands;
using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
using FlickrClient.Upload.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlickrClient.Upload.ViewModel
{
    internal class UploadViewModel : LoadableViewModel
    {
        private readonly IUploadService _uploadService;

        private bool _hasAccessToken;

        public ObservableCollection<UploadItemViewModel> UploadItems { get; }
        public ICommand UploadCommand { get; }

        public UploadViewModel(
            IUploadService uploadService)
        {
            _uploadService = uploadService;

            UploadItems = new ObservableCollection<UploadItemViewModel>();
            UploadCommand = new AsyncCommand(UploadExecuted, CanExecuteUpload);
        }

        private async Task UploadExecuted()
        {
            List<Task> tasks = new List<Task>();

            foreach (var item in UploadItems)
            {
                tasks.Add(_uploadService.UploadPictureAsync(item.UploadItem, null));
            }

            await Task.WhenAll(tasks);
        }

        private bool CanExecuteUpload()
        {
            return _hasAccessToken;
        }
    }
}