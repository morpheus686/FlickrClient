using FlickrClient.Components.ViewModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrClient.ViewModel
{
    public class TabViewModel : LoadableViewModel
    {
        private string _header;
        private PackIconKind _packIconKind;

        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }

        public PackIconKind PackIconKind
        {
            get { return _packIconKind; }
            set { _packIconKind = value; }
        }
    }
}
