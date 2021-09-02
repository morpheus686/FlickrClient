using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlickrClient.DomainModel.Services
{
    public interface IViewService
    {
        FrameworkElement GetView(string viewName);
    }
}