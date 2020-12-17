using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
using FlickrNet;

namespace FlickrClient.ViewModel.PhotoStream
{
    public class PhotostreamItemViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly Photo _photo;

        public string Small320Url { get => _photo.Small320Url; }
        public string Title { get => _photo.Title; }
        public bool IsPublic { get => _photo.IsPublic; }
        public int? Views { get => _photo.Views; }
        public int? CountFaves { get => _photo.CountFaves; }
        public int? CountComments { get => _photo.CountComments; }

        public PhotostreamItemViewModel(Photo photo, IDialogService dialogService)
        {
            _dialogService = dialogService;
            _photo = photo;
        }
    }
}
