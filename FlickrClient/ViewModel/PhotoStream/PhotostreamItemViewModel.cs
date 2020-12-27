using AsyncAwaitBestPractices.MVVM;
using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
using FlickrNet;
using System;
using System.Threading.Tasks;

namespace FlickrClient.ViewModel.PhotoStream
{
    public class PhotostreamItemViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly IPhotosetService _photosetService;
        private readonly IGroupService _groupService;
        private readonly Photo _photo;

        public PhotostreamItemViewModel(Photo photo,
            IDialogService dialogService,
            IPhotosetService photosetService,
            IGroupService groupService)
        {
            _dialogService = dialogService;
            _photosetService = photosetService;
            _groupService = groupService;

            _photo = photo;

            OpenDetailsCommand = new AsyncCommand(ExecuteOpenDetailsCommand);
        }

        public int? CountComments { get => _photo.CountComments; }
        public int? CountFaves { get => _photo.CountFaves; }
        public bool IsPublic { get => _photo.IsPublic; }
        public AsyncCommand OpenDetailsCommand { get; }
        public string Small320Url { get => _photo.Small320Url; }
        public string Title { get => _photo.Title; }
        public int? Views { get => _photo.Views; }
        public string Description { get => _photo.Description; }

        private Task ExecuteOpenDetailsCommand()
        {
            return _dialogService.ShowDialog(
                new PhotoDetailsDialogViewModel(_photo, _photosetService, _groupService),
                "PhotoDetailsDialog");
        }
    }
}