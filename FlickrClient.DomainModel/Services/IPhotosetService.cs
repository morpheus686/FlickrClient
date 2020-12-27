using FlickrNet;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FlickrClient.DomainModel.Services
{
    public interface IPhotosetService
    {
        Task<Collection<ContextSet>> GetPhotosetsOfPhoto(string photoId);

        Task<Photoset> GetPhotoset(string photosetId);
    }
}