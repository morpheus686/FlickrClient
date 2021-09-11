using FlickrClient.Components.Commands;
using FlickrClient.Components.ViewModel;
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

        public ObservableCollection<UploadItemViewModel> UploadItems { get; }
        public ICommand UploadCommand { get; }
        public ICommand DropFilesCommand { get; }

        public UploadViewModel(
            IUploadService uploadService)
        {
            _uploadService = uploadService;

            UploadItems = new ObservableCollection<UploadItemViewModel>();
            UploadCommand = new AsyncCommand(UploadExecuted, CanExecuteUpload);
            DropFilesCommand = new ParametrizedCommand<IEnumerable<string>>(DropFilesExecuted);
        }

        private void DropFilesExecuted(IEnumerable<string> fileList)
        {
            foreach (var item in fileList)
            {
                var uploadItemViewModel = new UploadItemViewModel(item, _uploadService);
                UploadItems.Add(uploadItemViewModel);
            }
        }

        private async Task UploadExecuted()
        {
            List<Task> tasks = new List<Task>();

            foreach (var item in UploadItems)
            {
                tasks.Add(item.UploadPictureAsync());
            }

            await Task.WhenAll(tasks);
        }

        private bool CanExecuteUpload()
        {
            return true;
        }
    }
}