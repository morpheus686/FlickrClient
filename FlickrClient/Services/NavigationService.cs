using FlickrClient.DomainModel.Services;
using FlickrClient.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FlickrClient.Services
{
    internal class NavigationService : INavigationService
    {
        private readonly IViewService _viewService;
        private readonly Lazy<ContentControl> _contentControl;

        public NavigationService(IViewService viewService)
        {
            _viewService = viewService;
            _contentControl = new Lazy<ContentControl>(GetMainContentControl);
        }

        public void SetMainArea(string tabName)
        {
            var view = _viewService.GetView(tabName);
            _contentControl.Value.Content = view;
        }

        private ContentControl GetMainContentControl()
        {
            var mainWindow = App.Current.MainWindow as MainWindow;
            return mainWindow.MainArea;
        }
    }
}
