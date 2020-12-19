using FlickrClient.DomainModel.Services;
using FlickrNet;
using System.Threading.Tasks;

namespace FlickrClient.Services
{
    internal class PhotostreamService : IPhotostreamService
    {
        private readonly IFlickrService _flickrService;

        public PhotostreamService(IFlickrService flickrService)
        {
            _flickrService = flickrService;
        }

        public Task<FlickrResult<PhotoCollection>> SearchUserPhotoStream(int page, int imagesPerPage)
        {
            var taskCompletion = new TaskCompletionSource<FlickrResult<PhotoCollection>>();

            _flickrService.GetAuthorizationInstance()
                .PeopleGetPhotosAsync(
                    PhotoSearchExtras.All,
                    page,
                    imagesPerPage,
                    result =>
                    {
                        taskCompletion.SetResult(result);
                    });

            return taskCompletion.Task;
        }
    }
}
