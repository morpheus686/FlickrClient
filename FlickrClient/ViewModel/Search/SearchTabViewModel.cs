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
    public class SearchTabViewModel : LoadableViewModel
    {  
        private readonly IFlickrService _flickrService;
        private readonly IDialogService _dialogService;

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
            IDialogService dialogService)
        {
            _flickrService = flickrService;
            _dialogService = dialogService;

            SortOrder =  Enum.GetValues(typeof(PhotoSearchSortOrder)).Cast<PhotoSearchSortOrder>();
            SelectedSortOrder = PhotoSearchSortOrder.Relevance;

            SearchCommand = new AsyncCommand(ExecuteSearchCommand);
        }

        private async Task ExecuteSearchCommand()
        {
            await _dialogService.ShowIndeterminateDialog(SearchFotosAsync);
        }

        private async Task SearchFotosAsync()
        {        
            Photos = null;

            PhotoSearchOptions photoSearchOptions = new PhotoSearchOptions
            {
                Extras = PhotoSearchExtras.All,
                SortOrder = SelectedSortOrder,
                Tags = SearchText
            };

            var flickr = _flickrService.GetInstance();
            var taskCompletionSource = new TaskCompletionSource<FlickrResult<PhotoCollection>>();

            flickr.PhotosSearchAsync(photoSearchOptions, result =>
            {
                taskCompletionSource.SetResult(result);
            });

            var searchResult = await taskCompletionSource.Task;

            if (!searchResult.HasError)
            {
                Photos = searchResult.Result
                    .Select(item => new SearchItemViewModel(_dialogService, item))
                    .ToList();
            }
        }
    }
}
