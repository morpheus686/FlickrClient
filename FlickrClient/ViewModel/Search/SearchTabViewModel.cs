using FlickrClient.Components.Commands;
using FlickrClient.DomainModel.Services;
using FlickrNet;
using System.Threading.Tasks;

namespace FlickrClient.ViewModel.Search
{
    public class SearchTabViewModel : TabViewModel
    {
        private PhotoCollection photos;
        private readonly IFlickrService _flickrService;

        public PhotoCollection Photos
        {
            get { return photos; }
            private set 
            { 
                photos = value;
                RaisePropertyChanged();
            }
        }

        public string SearchText { get; set; }

        public AsyncCommand SearchCommand { get; }

        public SearchTabViewModel(IFlickrService flickrService)
        {
            Header = "Suchen";
            PackIconKind = MaterialDesignThemes.Wpf.PackIconKind.Search;
            _flickrService = flickrService;

            SearchCommand = new AsyncCommand(ExecuteSearchCommand);
        }

        private async Task ExecuteSearchCommand()
        {
            PhotoSearchOptions photoSearchOptions = new PhotoSearchOptions();
            photoSearchOptions.Extras = PhotoSearchExtras.AllUrls | PhotoSearchExtras.Description | PhotoSearchExtras.OwnerName;
            photoSearchOptions.SortOrder = PhotoSearchSortOrder.Relevance;
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
