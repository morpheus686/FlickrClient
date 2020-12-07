using FlickrClient.Components.Commands;
using FlickrClient.DomainModel.Services;
using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlickrClient.ViewModel.Search
{
    public class SearchTabViewModel : TabViewModel
    {
        private PhotoCollection _photos;
        private readonly IFlickrService _flickrService;
        private readonly IDialogService _dialogService;

        public PhotoCollection Photos
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
            Header = "Suchen";
            PackIconKind = MaterialDesignThemes.Wpf.PackIconKind.Search;

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

            PhotoSearchOptions photoSearchOptions = new PhotoSearchOptions();
            photoSearchOptions.Extras = PhotoSearchExtras.AllUrls | PhotoSearchExtras.Description | PhotoSearchExtras.OwnerName;
            photoSearchOptions.SortOrder = SelectedSortOrder;
            
            photoSearchOptions.Tags = SearchText;

            var flickr = _flickrService.GetInstance();
            var taskCompletionSource = new TaskCompletionSource<FlickrResult<PhotoCollection>>();

            flickr.PhotosSearchAsync(photoSearchOptions, result =>
            {
                taskCompletionSource.SetResult(result);
            });

            var searchResult = await taskCompletionSource.Task;

            if (!searchResult.HasError)
            {
                Photos = searchResult.Result;
            }
        }
    }
}
