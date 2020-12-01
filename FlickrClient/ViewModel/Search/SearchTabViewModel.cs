using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public SearchTabViewModel(IFlickrService flickrService)
        {
            Header = "Suchen";
            PackIconKind = MaterialDesignThemes.Wpf.PackIconKind.Search;
            _flickrService = flickrService;
        }

        protected override async Task InitializeInternalAsync()
        {       
            PhotoSearchOptions photoSearchOptions = new PhotoSearchOptions();
            photoSearchOptions.Extras = PhotoSearchExtras.AllUrls | PhotoSearchExtras.Description | PhotoSearchExtras.OwnerName;
            photoSearchOptions.SortOrder = PhotoSearchSortOrder.Relevance;
            photoSearchOptions.Tags = "ET440";

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
