using FlickrClient.Components.ViewModel;
using FlickrClient.Upload.Data;
using System.IO;

namespace FlickrClient.Upload.ViewModel
{
    internal class UploadItemViewModel : ViewModelBase
    {
        internal UploadItem UploadItem { get; }

        public UploadItemViewModel(UploadItem uploadItem)
        {
            UploadItem = uploadItem;
        }

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

        public FileInfo Location
        {
            get => UploadItem.Location;
        }
    }
}