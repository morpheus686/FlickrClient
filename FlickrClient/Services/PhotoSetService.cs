using FlickrClient.DomainModel.Services;
using FlickrNet;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FlickrClient.Services
{
    public class PhotoSetService : IPhotosetService
    {
        private readonly IFlickrService _flickrService;

        public PhotoSetService(IFlickrService flickrService)
        {
            _flickrService = flickrService;
        }

        public async Task<Collection<ContextSet>> GetPhotosetsOfPhoto(string photoId)
        {
            var flickr = _flickrService.GetInstance();
            var contextResultTcs = new TaskCompletionSource<FlickrResult<AllContexts>>();

            flickr.PhotosGetAllContextsAsync(
                photoId,
                result =>
                {
                    contextResultTcs.SetResult(result);
                });

            var contextResult = await contextResultTcs.Task;

            return contextResult.Result.Sets;
        }

        public async Task<Photoset> GetPhotoset(string photosetId)
        {
            var flickr = _flickrService.GetInstance();
            var photoSetResultTcs = new TaskCompletionSource<FlickrResult<Photoset>>();

            flickr.PhotosetsGetInfoAsync(
                photosetId,
                result =>
                {
                    photoSetResultTcs.SetResult(result);
                });

            var contextResult = await photoSetResultTcs.Task;

            return contextResult.Result;
        }
    }
}