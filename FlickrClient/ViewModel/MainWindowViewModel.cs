using CommonServiceLocator;
using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace FlickrClient.ViewModel
{
    public class MainWindowViewModel : LoadableViewModel
    {
        private readonly ObservableCollection<TabViewModel> _tabCollection;

        public TabViewModel SelectedTab { get; set; }

        public ObservableCollection<TabViewModel> TabCollection
        {
            get { return _tabCollection; }
        }

        public MainWindowViewModel()
        {
            _tabCollection = new ObservableCollection<TabViewModel>();
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
