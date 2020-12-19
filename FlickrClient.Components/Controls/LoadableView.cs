using CommonServiceLocator;
using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
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
                return;
            }

            await _dialogService.ShowIndeterminateDialog(loadTask);
        }
    }
}
