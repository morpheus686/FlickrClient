using FlickrClient.Upload.Data;
using System;
using System.Threading.Tasks;

namespace FlickrClient.Upload.Services
{
    internal interface IUploadService
    {
        Task UploadPictureAsync(UploadItem uploadItem, Action<int, bool> progress);
    }
}