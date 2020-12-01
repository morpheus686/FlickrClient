using FlickrClient.DomainModel.Services;

namespace FlickrClient.Upload.Services
{
    internal class UploadService : IUploadService
    {
        private readonly IFlickrService _flickrService;

        public UploadService(IFlickrService flickrService)
        {
            _flickrService = flickrService;
        }
    }
}
