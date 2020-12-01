using CommonServiceLocator;
using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FlickrClient.ViewModel
{
    public class MainWindowViewModel : LoadableViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly ObservableCollection<TabViewModel> _tabCollection;

        private object _selectedItem;

        public object SelectedItem
        {
            get { return _selectedItem; }
            set {
                _selectedItem = value;
                RaisePropertyChanged();
            }
        }


        public ObservableCollection<TabViewModel> TabCollection
        {
            get { return _tabCollection; }
        }

        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            _tabCollection = new ObservableCollection<TabViewModel>();
        }

        protected override void InitializeInternal()
        {
            var tabs = ServiceLocator.Current.GetAllInstances<TabViewModel>();

            foreach (var tab in tabs)
            {
                _tabCollection.Add(tab);
            }
        }
    }
}
