using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
using MaterialDesignThemes.Wpf;

namespace FlickrClient.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly TabViewModel _tabViewModel;

        public string Caption { get => _tabViewModel.Header;  }
        public PackIconKind PackIconKind { get => _tabViewModel.PackIconKind; }

        public NavigationItemViewModel(INavigationService navigationService,
            TabViewModel tabViewModel)
        {
            _navigationService = navigationService;
            _tabViewModel = tabViewModel;
        }
    }
}
