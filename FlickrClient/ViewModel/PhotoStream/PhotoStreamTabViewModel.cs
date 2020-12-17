using FlickrClient.DomainModel.Services;
using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrClient.ViewModel.PhotoStream
{
    public class PhotoStreamTabViewModel : TabViewModel
    {
        private readonly IFlickrService _flickrService;
        private readonly IDialogService _dialogService;
        private List<PhotostreamItemViewModel> _photos;

        public List<PhotostreamItemViewModel> Photos
        {
            get => _photos;
            private set
            {
                _photos = value;
                RaisePropertyChanged();
            }
        }

        public PhotoStreamTabViewModel(IFlickrService flickrService,
            IDialogService dialogService)
        {
            _flickrService = flickrService;
            _dialogService = dialogService;

            Header = "Photostream";
            PackIconKind = MaterialDesignThemes.Wpf.PackIconKind.PhotoLibrary;
        }

        protected override async Task InitializeInternalAsync()
        {
            var taskCompletion = new TaskCompletionSource<FlickrResult<PhotoCollection>>();

            _flickrService.GetAuthorizationInstance()
                .PeopleGetPhotosAsync(
                    PhotoSearchExtras.All,
                    result =>
                    {
                        taskCompletion.SetResult(result);
                    });

            var photos = await taskCompletion.Task;

            if (photos.HasError)
            {
                return;
            }

            Photos = photos.Result
                .Select(photo => new PhotostreamItemViewModel(photo, _dialogService))
                .ToList(); ;
        }
    }
}
