using FlickrClient.Components.Commands;
using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickrClient.ViewModel.Search
{
    public class SearchTabViewModel : ViewModelBase
    {
        private readonly IFlickrService _flickrService;
        private readonly IDialogService _dialogService;
        private readonly IPhotoSearchService _photoSearchService;

        private List<SearchItemViewModel> _photos;

        public List<SearchItemViewModel> Photos
        {
            get { return _photos; }
            private set
            {
                _photos = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<PhotoSearchSortOrder> SortOrder { get; set; }
        public PhotoSearchSortOrder SelectedSortOrder { get; set; }
        public string SearchText { get; set; }

        public AsyncCommand SearchCommand { get; }

        public SearchTabViewModel(IFlickrService flickrService,
            IDialogService dialogService,
            IPhotoSearchService photoSearchService)
        {
            _flickrService = flickrService;
            _dialogService = dialogService;
            _photoSearchService = photoSearchService;

            SortOrder = Enum.GetValues(typeof(PhotoSearchSortOrder)).Cast<PhotoSearchSortOrder>();
            SelectedSortOrder = PhotoSearchSortOrder.Relevance;

            SearchCommand = new AsyncCommand(ExecuteSearchCommand);
        }

        private async Task ExecuteSearchCommand()
        {
            await _dialogService.ShowIndeterminateDialog(SearchFotosAsync, $"Fotos von {SearchText} werden gesucht...");
        }

        private async Task SearchFotosAsync()
        {
            Photos = null;

            var searchResult = await _photoSearchService.SearchPhotos(SearchText, SelectedSortOrder);

            if (!searchResult.HasError)
            {
                Photos = searchResult.Result
                    .Select(item => new SearchItemViewModel(_dialogService, item))
                    .ToList();
            }
        }
    }
}