using FlickrClient.DomainModel.Services;
using FlickrNet;
using System.Threading.Tasks;

namespace FlickrClient.Services.Tools
{
    internal static class ContextTools
    {
        public static Task<FlickrResult<AllContexts>> GetAllContext(IFlickrService flickrService, string photoId)
        {
            var flickr = flickrService.GetInstance();
            var contextResultTcs = new TaskCompletionSource<FlickrResult<AllContexts>>();

            flickr.PhotosGetAllContextsAsync(
                photoId,
                result =>
                {
                    contextResultTcs.SetResult(result);
                });

            return contextResultTcs.Task;
        }
    }
}