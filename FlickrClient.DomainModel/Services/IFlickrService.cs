﻿using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrClient.DomainModel.Services
{
    public interface IFlickrService
    {
        Flickr GetInstance();
        Flickr GetAuthorizationInstance();
        bool HasAccessToken();
    }
}