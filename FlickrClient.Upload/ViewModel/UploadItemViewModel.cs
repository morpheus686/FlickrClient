using FlickrClient.Components.ViewModel;
using FlickrClient.Upload.Data;
using System.IO;

namespace FlickrClient.Upload.ViewModel
{
    internal class UploadItemViewModel : ViewModelBase
    {
        private readonly UploadItem _uploadItem;

        public UploadItemViewModel(UploadItem uploadItem)
        {
            _uploadItem = uploadItem;
        }

        public string Header
        {
            get => _uploadItem.Header;
            set => _uploadItem.Header = value;
        }

        public string Description
        {
            get => _uploadItem.Description;
            set => _uploadItem.Description = value;
        }

        public string Tags
        {
            get => _uploadItem.Tags; set => _uploadItem.Tags = value;
        }

        public bool IsPublic
        {
            get => _uploadItem.IsPublic;
            set => _uploadItem.IsPublic = value;
        }

        public FileInfo Location
        {
            get => _uploadItem.Location;
        }

    }
}
