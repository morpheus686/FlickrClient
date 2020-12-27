using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace FlickrClient.ViewModel.PhotoStream
{
    public class PhotoStreamTabViewModel : LoadableViewModel
    {
        private const int FirstPageNumber = 1;

        private readonly IDialogService _dialogService;
        private readonly IPhotosetService _photosetService;
        private readonly IGroupService _groupService;
        private readonly IPhotostreamService _photostreamService;
        private readonly ISettingsService _settingsService;

        public PageNavigationViewModel PageNavigationViewModel { get; }

        public ObservableCollection<PhotostreamItemViewModel> Photos
        {
            get;
        }

        public PhotoStreamTabViewModel(IPhotostreamService photoSearchService,
            IDialogService dialogService,
            ISettingsService settingsService,
            IPhotosetService photosetService,
            IGroupService groupService)
        {
            _photostreamService = photoSearchService;
            _dialogService = dialogService;
            _settingsService = settingsService;
            _photosetService = photosetService;
            _groupService = groupService;

            PageNavigationViewModel = new PageNavigationViewModel(GoToNextPage, GoToPreviousPage);
            Photos = new ObservableCollection<PhotostreamItemViewModel>();
        }

        protected override Task InitializeInternalAsync()
        {
            return InitializeInternalAsync(GetPhotostream);
        }

        private Task GetPhotostream()
        {
            return GetPhotostream(FirstPageNumber);
        }

        private async Task GetPhotostream(int page)
        {
            Photos.Clear();
            int maxPhotosPerPage = _settingsService.GetMaxPhotosPerPage();
            var photos = await _photostreamService.SearchUserPhotoStream(page, maxPhotosPerPage);

            if (photos.HasError)
            {
                return;
            }

            photos.Result
                .Select(photo => new PhotostreamItemViewModel(photo, _dialogService, _photosetService, _groupService))
                .ToList()
                .ForEach(Photos.Add);

            PageNavigationViewModel.Page = photos.Result.Page;
            PageNavigationViewModel.PageCount = photos.Result.Pages;
        }

        private Task GoToNextPage()
        {
            return _dialogService.ShowIndeterminateDialog(NextPageTask);
        }

        private Task GoToPreviousPage()
        {
            return _dialogService.ShowIndeterminateDialog(PreviousPageTask);
        }

        private Task NextPageTask()
        {
            int currentPage = PageNavigationViewModel.Page;
            return GetPhotostream(++currentPage);
        }

        private Task PreviousPageTask()
        {
            int currentPage = PageNavigationViewModel.Page;
            return GetPhotostream(--currentPage);
        }
    }
}