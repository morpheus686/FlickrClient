using FlickrClient.DomainModel.Services;
using FlickrClient.Services.Tools;
using FlickrNet;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FlickrClient.Services
{
    internal class GroupService : IGroupService
    {
        private readonly IFlickrService _flickrService;

        public GroupService(IFlickrService flickrService)
        {
            _flickrService = flickrService;
        }

        public async Task<Collection<ContextGroup>> GetGroupsOfPhoto(string photoId)
        {
            var contextResult = await ContextTools.GetAllContext(_flickrService, photoId);
            return contextResult.Result.Groups;
        }

        public async Task<GroupFullInfo> GetGroup(string groupId)
        {
            var flickr = _flickrService.GetInstance();
            var groupResultTcs = new TaskCompletionSource<FlickrResult<GroupFullInfo>>();

            flickr.GroupsGetInfoAsync(
                groupId,
                result =>
                {
                    groupResultTcs.SetResult(result);
                });

            var groupResult = await groupResultTcs.Task;

            return groupResult.Result;
        }
    }
}