using FlickrNet;

namespace FlickrClient.DomainModel.Services
{
    public interface IFlickrService
    {
        Flickr GetInstance();

        bool HasAccessToken();
    }
}