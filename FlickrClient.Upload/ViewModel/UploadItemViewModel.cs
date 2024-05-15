using FlickrClient.Components.ViewModel;
using FlickrClient.Upload.Data;
using FlickrClient.Upload.Services;
using System.IO;
using System.Threading.Tasks;

namespace FlickrClient.Upload.ViewModel
{
    internal class UploadItemViewModel : ViewModelBase
    {
        private readonly IUploadService _uploadService;
        private bool _isUploading = false;

        internal UploadItem UploadItem { get; }

        public UploadItemViewModel(
            string filePath,
            IUploadService uploadService)
        {
            UploadItem = new UploadItem(filePath);
            _uploadService = uploadService;
        }

        public bool IsUploading
        {
            get => _isUploading;
            private set
            {
                _isUploading = value;
                RaisePropertyChanged();
            }
        }

        public int ProgressInPercent { get; private set; }

        public string Header
        {
            get => UploadItem.Header;
            set => UploadItem.Header = value;
        }

        public string Description
        {
            get => UploadItem.Description;
            set => UploadItem.Description = value;
        }

        public string Tags
        {
            get => UploadItem.Tags;
            set => UploadItem.Tags = value;
        }

        public bool IsPublic
        {
            get => UploadItem.IsPublic;
            set => UploadItem.IsPublic = value;
        }

        public FileInfo Location => UploadItem.Location;

        private void ReportProgress(int percentage, bool isCompleted)
        {
            if (isCompleted)
            {
                IsUploading = false;
                return;
            }

            ProgressInPercent = percentage;
            RaisePropertyChanged(nameof(ProgressInPercent));
        }

        public async Task UploadPictureAsync()
        {
            IsUploading = true;
            string result = await Task.Run(() => _uploadService.UploadPicture(UploadItem, ReportProgress));
        }
    }
}