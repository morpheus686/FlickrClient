using FlickrNet;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FlickrClient.DomainModel.Services
{
    public interface IGroupService
    {
        Task<Collection<ContextGroup>> GetGroupsOfPhoto(string photoId);

        Task<GroupFullInfo> GetGroup(string photosetId);
    }
}