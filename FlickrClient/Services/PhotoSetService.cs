using FlickrClient.DomainModel.Services;
using FlickrClient.Services.Tools;
using FlickrNet;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FlickrClient.Services
{
    internal class PhotosetService : IPhotosetService
    {
        private readonly IFlickrService _flickrService;

        public PhotosetService(IFlickrService flickrService)
        {
            _flickrService = flickrService;
        }

        public async Task<Collection<ContextSet>> GetPhotosetsOfPhoto(string photoId)
        {
            var contextResult = await ContextTools.GetAllContext(_flickrService, photoId);
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

            var photosetResult = await photoSetResultTcs.Task;

            return photosetResult.Result;
        }
    }
}