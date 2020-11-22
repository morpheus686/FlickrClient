using FlickrClient.Components.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrClient.Upload.ViewModel
{
    internal class UploadItemTemplateViewModel : ViewModelBase
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
    }
}
