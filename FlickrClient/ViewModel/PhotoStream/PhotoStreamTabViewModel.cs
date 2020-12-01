using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrClient.ViewModel.PhotoStream
{
    public class PhotoStreamTabViewModel : TabViewModel
    {
        public PhotoStreamTabViewModel()
        {
            Header = "Photostream";
            PackIconKind = MaterialDesignThemes.Wpf.PackIconKind.PhotoLibrary;
        }
    }
}
