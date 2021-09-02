using FlickrClient.DomainModel.Services;
using FlickrClient.Upload.Data;
using FlickrNet;
using System;
using System.Threading.Tasks;

namespace FlickrClient.Upload.Services
{
    internal class UploadService : IUploadService
    {
        private readonly IFlickrService _flickrService;

        public UploadService(IFlickrService flickrService)
        {
            _flickrService = flickrService;
        }

        public async Task UploadPictureAsync(UploadItem uploadItem, Action<int, bool> progress)
        {
            Flickr flickr = _flickrService.GetInstance();

            flickr.OnUploadProgress += (s, e) =>
            {
                progress(e.ProcessPercentage, e.UploadComplete);
            };

            var taskCompletionSource = new TaskCompletionSource<FlickrResult<string>>();

            flickr.UploadPictureAsync(
                null,
                uploadItem.Location.FullName,
                uploadItem.Header,
                uploadItem.Description,
                uploadItem.Tags,
                uploadItem.IsPublic,
                true,
                true,
                ContentType.Photo,
                SafetyLevel.Safe,
                HiddenFromSearch.None,
                (result) =>
                {
                    taskCompletionSource.SetResult(result);
                });

            var flickrResult = await taskCompletionSource.Task;
        }
    }
}