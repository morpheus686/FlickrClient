using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
using FlickrNet;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FlickrClient.ViewModel
{
    public class PhotoDetailsDialogViewModel : LoadableViewModel
    {
        private readonly Photo _photo;
        private readonly IPhotosetService _photosetService;
        private readonly IGroupService _groupService;

        private bool _isLoadingGroups;
        private bool _isLoadingPhotosets;

        public int? CountFaves { get => _photo.CountFaves; }
        public string Description { get => _photo.Description; }
        public DateTime UploadDate { get => _photo.DateUploaded; }
        public DateTime TakenDate { get => _photo.DateTaken; }
        public Collection<string> Tags { get => _photo.Tags; }

        public ObservableCollection<GroupFullInfo> GroupCollection { get; }

        public bool IsLoadingGroups
        {
            get { return _isLoadingGroups; }
            set
            {
                _isLoadingGroups = value;
                RaisePropertyChanged();
            }
        }

        public bool IsLoadingPhotosets
        {
            get => _isLoadingPhotosets;
            private set
            {
                _isLoadingPhotosets = value;
                RaisePropertyChanged();
            }
        }

        public string Medium800Url { get => _photo.Medium800Url; }

        public ObservableCollection<Photoset> PhotosetCollection { get; }

        public string Title { get => _photo.Title; }
        public int? Views { get => _photo.Views; }

        public PhotoDetailsDialogViewModel(Photo photo,
            IPhotosetService photosetService,
            IGroupService groupService)
        {
            _photo = photo;
            _photosetService = photosetService;
            _groupService = groupService;

            PhotosetCollection = new ObservableCollection<Photoset>();
            GroupCollection = new ObservableCollection<GroupFullInfo>();
        }

        protected override Task InitializeInternalAsync()
        {
            IsLoadingPhotosets = true;
            IsLoadingGroups = true;

            return Task.WhenAll(SetPhotosets(), SetGroups());
        }

        private async Task SetPhotosets()
        {
            var photosets = await _photosetService.GetPhotosetsOfPhoto(_photo.PhotoId);

            foreach (var item in photosets)
            {
                var photoset = await _photosetService.GetPhotoset(item.PhotosetId);
                PhotosetCollection.Add(photoset);
            }

            IsLoadingPhotosets = false;
        }

        private async Task SetGroups()
        {
            var groupsets = await _groupService.GetGroupsOfPhoto(_photo.PhotoId);

            foreach (var item in groupsets)
            {
                var group = await _groupService.GetGroup(item.GroupId);
                GroupCollection.Add(group);
            }

            IsLoadingGroups = false;
        }
    }
}