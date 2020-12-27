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
        private readonly IDialogService _dialogService;

        public LoadableView() : this(GetDialogService())
        {
            Loaded += View_Loaded;
        }

        public LoadableView(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        private static IDialogService GetDialogService()
        {
            return ServiceLocator.Current.GetInstance<IDialogService>();
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
                if (loadTask.IsFaulted)
                {
                    await _dialogService.ShowMessage(loadTask.Exception.InnerExceptions.First().Message);
                }

                return;
            }

            try
            {
                await loadTask;
            }
            catch (Exception ex)
            {
                await _dialogService.ShowMessage(ex.Message);
            }
        }
    }
}