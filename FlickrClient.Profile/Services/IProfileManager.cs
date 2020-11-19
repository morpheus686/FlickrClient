using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrClient.Profile.Services
{
    public interface IProfileManager
    {
        Flickr GetInstance();
        Flickr GetAuthInstance();
    }
}
