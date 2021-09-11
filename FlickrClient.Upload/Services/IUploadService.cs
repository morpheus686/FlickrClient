using FlickrClient.Upload.Data;
using System;

namespace FlickrClient.Upload.Services
{
    internal interface IUploadService
    {
        string UploadPicture(UploadItem uploadItem, Action<int, bool> progress);
    }
}