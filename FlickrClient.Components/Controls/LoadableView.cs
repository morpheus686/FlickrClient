using CommonServiceLocator;
using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FlickrClient.Components.Controls
{
    public class LoadableView : View
    {
        public LoadableView()
        {
            Loaded += View_Loaded;
        }

        private async void View_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is LoadableViewModel lvm)
            {
                await InitializeViewModel(lvm);
            }
        }

        private async Task InitializeViewModel(LoadableViewModel lvm)
        {
            Task loadTask = lvm.Initialize();

            if (loadTask.IsCompleted)
            {
                return;
            }

            await loadTask;
        }
    }
}