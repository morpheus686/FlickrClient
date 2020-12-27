using FlickrClient.Components.Attributes;
using FlickrClient.Components.Controls;

namespace FlickrClient.View.Photo
{
    /// <summary>
    /// Interaktionslogik für PhotoDetailsDialog.xaml
    /// </summary>
    [View(nameof(PhotoDetailsDialog))]
    public partial class PhotoDetailsDialog : DialogView
    {
        public PhotoDetailsDialog()
        {
            InitializeComponent();
        }
    }
}