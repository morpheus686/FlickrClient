using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrClient.DomainModel.Services
{
    public interface IPhotoSearchService
    {
        Task<FlickrResult<PhotoCollection>> SearchPhotos(string searchText, PhotoSearchSortOrder sortOrder);
    }
}
