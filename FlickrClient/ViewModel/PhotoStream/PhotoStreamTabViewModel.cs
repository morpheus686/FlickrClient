using FlickrClient.DomainModel.Services;
using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrClient.ViewModel.PhotoStream
{
    public class PhotoStreamTabViewModel : TabViewModel
    {
        private readonly IFlickrService _flickrService;
        private readonly IDialogService _dialogService;

        private PhotoCollection _photos;

        public PhotoCollection Photos
        {
            get => _photos;
            private set
            {
                _photos = value;
                RaisePropertyChanged();
            }
        }

        public PhotoStreamTabViewModel(IFlickrService flickrService,
            IDialogService dialogService)
        {
            _flickrService = flickrService;
            _dialogService = dialogService;

            Header = "Photostream";
            PackIconKind = MaterialDesignThemes.Wpf.PackIconKind.PhotoLibrary;

            Photos = _flickrService.GetAuthorizationInstance().PeopleGetPhotos(PhotoSearchExtras.All);
        }
    }
}
