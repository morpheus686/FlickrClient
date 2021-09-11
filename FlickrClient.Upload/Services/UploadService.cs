using FlickrClient.DomainModel.Services;
using FlickrClient.Upload.Data;
using FlickrNet;
using System;

namespace FlickrClient.Upload.Services
{
    internal class UploadService : IUploadService
    {
        private readonly IFlickrService _flickrService;

        public UploadService(IFlickrService flickrService)
        {
            _flickrService = flickrService;
        }

        public string UploadPicture(UploadItem uploadItem, Action<int, bool> progress)
        {
            Flickr flickr = _flickrService.GetInstance();

            flickr.OnUploadProgress += (s, e) =>
            {
                progress(e.ProcessPercentage, e.UploadComplete);
            };

            string result = flickr.UploadPicture(
                uploadItem.Location.FullName,
                uploadItem.Header,
                uploadItem.Description,
                uploadItem.Tags,
                uploadItem.IsPublic,
                false,
                false);

            return result;
        }
    }
}