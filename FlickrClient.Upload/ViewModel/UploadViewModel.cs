using FlickrClient.Components.Commands;
using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
using FlickrClient.Upload.Data;
using FlickrClient.Upload.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FlickrClient.Upload.ViewModel
{
    internal class UploadViewModel : LoadableViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly IFlickrService _flickrService;
        private readonly IUploadService _uploadService;

        private bool _hasAccessToken;

        public ObservableCollection<UploadItemViewModel> UploadItems { get; }
        public ICommand UploadCommand { get; }

        public UploadViewModel(IDialogService dialogService,
            IFlickrService flickrService,
            IUploadService uploadService)
        {
            _dialogService = dialogService;
            _flickrService = flickrService;
            _uploadService = uploadService;

            UploadItems = new ObservableCollection<UploadItemViewModel>();

            UploadCommand = new AsyncCommand(UploadExecuted, CanExecuteUpload);
        }

        private async Task UploadExecuted()
        {
            UploadItems.Clear();
        }

        private bool CanExecuteUpload()
        {
            return _hasAccessToken;
        }

        protected override async Task InitializeInternalAsync()
        {
            await MaterialDesignThemes.Wpf.DialogHost.Show(new TextBlock() { Text = "Blubb" }, "DialogHost");
        }

        protected override void InitializeInternal()
        {
            _hasAccessToken = _flickrService.HasAccessToken();

            UploadItem uploadItem1 = new UploadItem()
            {
                Header = "Bild 1",
                Description = "Text von Bild 1",
                Tags = string.Empty,
                Location = new System.IO.FileInfo(@"D:\Bilder\60D\2020_10_01\darktable_exported\IMG_8536_01.jpg"),
                IsPublic = false
            };

            UploadItems.Add(new UploadItemViewModel(uploadItem1));

            UploadItem uploadItem2 = new UploadItem()
            {
                Header = "Bild 2",
                Description = "Text von Bild 2",
                Tags = string.Empty,
                Location = new System.IO.FileInfo(@"D:\Bilder\60D\2020_11_18\darktable_exported\IMG_9149_01.jpg"),
                IsPublic = true
            };

            UploadItems.Add(new UploadItemViewModel(uploadItem2));
        }
    }
}
