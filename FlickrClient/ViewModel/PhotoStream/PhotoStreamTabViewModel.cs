using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickrClient.ViewModel.PhotoStream
{
    public class PhotoStreamTabViewModel : LoadableViewModel
    {
        private const int FirstPageNumber = 1;

        private readonly IPhotostreamService _photostreamService;
        private readonly IDialogService _dialogService;
        private readonly ISettingsService _settingsService;

        private List<PhotostreamItemViewModel> _photos;

        public PageNavigationViewModel PageNavigationViewModel { get; }

        public List<PhotostreamItemViewModel> Photos
        {
            get => _photos;
            private set
            {
                _photos = value;
                RaisePropertyChanged();
            }
        }

        public PhotoStreamTabViewModel(IPhotostreamService photoSearchService,
            IDialogService dialogService,
            ISettingsService settingsService)
        {
            _photostreamService = photoSearchService;
            _dialogService = dialogService;

            _settingsService = settingsService;
            PageNavigationViewModel = new PageNavigationViewModel(GoToNextPage, GoToPreviousPage);
        }

        private Task GoToPreviousPage()
        {
            return _dialogService.ShowIndeterminateDialog(PreviousPageTask);
        }

        private Task PreviousPageTask()
        {
            int currentPage = PageNavigationViewModel.Page;
            return GetPhotostream(--currentPage);
        }

        private Task GoToNextPage()
        {
            return _dialogService.ShowIndeterminateDialog(NextPageTask);
        }

        private Task NextPageTask()
        {
            int currentPage = PageNavigationViewModel.Page;
            return GetPhotostream(++currentPage);
        }

        private async Task GetPhotostream(int page)
        {
            int maxPhotosPerPage = _settingsService.GetMaxPhotosPerPage();
            var photos = await _photostreamService.SearchUserPhotoStream(page, maxPhotosPerPage);

            if (photos.HasError)
            {
                return;
            }

            Photos = photos.Result
                .Select(photo => new PhotostreamItemViewModel(photo, _dialogService))
                .ToList();

            PageNavigationViewModel.Page = photos.Result.Page;
            PageNavigationViewModel.PageCount = photos.Result.Pages;
        }

        protected override Task InitializeInternalAsync()
        {
            return GetPhotostream(FirstPageNumber);
        }
    }
}
