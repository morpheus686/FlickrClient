using FlickrClient.Components.Commands;
using FlickrClient.Components.ViewModel;
using FlickrClient.DomainModel.Services;
using FlickrNet;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlickrClient.ViewModel.Search
{
    public class SearchItemViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly Photo _photo;

        public ICommand OpenDetailsCommand { get; }

        public string LargeSquareThumbnailUrl { get => _photo.LargeSquareThumbnailUrl; }
        public string OwnerName { get => _photo.OwnerName; }
        public string Title { get => _photo.Title; }
        public DateTime DateTaken { get => _photo.DateTaken; }

        public SearchItemViewModel(IDialogService dialogService, Photo photo)
        {
            _dialogService = dialogService;
            _photo = photo;

            OpenDetailsCommand = new AsyncCommand(ExecuteOpenDetailsCommand);
        }

        private Task ExecuteOpenDetailsCommand()
        {
            return _dialogService.ShowDialog(this, "");
        }
    }
}
