using CommonServiceLocator;
using FlickrClient.Components.Commands;
using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlickrClient.ViewModel
{
    public class MainWindowViewModel : LoadableViewModel
    {
        private readonly ObservableCollection<TabViewModel> _tabCollection;
        private readonly IDialogService _dialogService;

        public TabViewModel SelectedTab { get; set; }

        public ICommand OpenAuthentificationDialogCommand { get;}

        public ObservableCollection<TabViewModel> TabCollection
        {
            get { return _tabCollection; }
        }

        public MainWindowViewModel(IDialogService dialogService)
        {
            _tabCollection = new ObservableCollection<TabViewModel>();
            _dialogService = dialogService;

            OpenAuthentificationDialogCommand = new AsyncCommand(ExecuteOpenAuthentificationDialogCommand);
        }

        private async Task ExecuteOpenAuthentificationDialogCommand()
        {
            await _dialogService.ShowDialog("AuthentificationDialogView");
        }

        protected override void InitializeInternal()
        {
            var tabs = ServiceLocator.Current.GetAllInstances<TabViewModel>();

            foreach (var tab in tabs)
            {
                _tabCollection.Add(tab);
            }

            SelectedTab = tabs.FirstOrDefault();
            RaisePropertyChanged(nameof(SelectedTab));
        }
    }
}
