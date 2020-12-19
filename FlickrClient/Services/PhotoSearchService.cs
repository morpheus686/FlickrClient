using FlickrClient.DomainModel.Services;
using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrClient.Services
{
    internal class PhotoSearchService : IPhotoSearchService
    {
        private readonly IFlickrService _flickrService;

        public PhotoSearchService(IFlickrService flickrService)
        {
            _flickrService = flickrService;
        }

        public Task<FlickrResult<PhotoCollection>> SearchPhotos(string searchText, PhotoSearchSortOrder sortOrder)
        {
            PhotoSearchOptions photoSearchOptions = new PhotoSearchOptions()
            {
                Extras = PhotoSearchExtras.All,
                SortOrder = sortOrder,
                Tags = searchText
            };

            var flickr = _flickrService.GetInstance();
            var taskCompletionSource = new TaskCompletionSource<FlickrResult<PhotoCollection>>();

            flickr.PhotosSearchAsync(photoSearchOptions, result =>
            {
                taskCompletionSource.SetResult(result);
            });

            return taskCompletionSource.Task;
        }
    }
}
