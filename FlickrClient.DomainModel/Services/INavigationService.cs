using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrClient.DomainModel.Services
{
    public interface INavigationService
    {
        void SetMainArea(string tabName);
    }
}
