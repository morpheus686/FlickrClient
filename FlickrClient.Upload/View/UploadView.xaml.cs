using FlickrClient.Components.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlickrClient.Upload.View
{
    /// <summary>
    /// Interaktionslogik für UploadViewModel.xaml
    /// </summary>
    
    [View(nameof(UploadView))]
    public partial class UploadView
    {
        public UploadView()
        {
            InitializeComponent();
        }
    }
}
