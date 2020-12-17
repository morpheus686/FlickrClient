using FlickrClient.Components.Attributes;
using FlickrClient.Components.Controls;

namespace FlickrClient.View.Photostream
{
    /// <summary>
    /// Interaktionslogik für PhotostreamTabView.xaml
    /// </summary>
    [View(nameof(PhotostreamTabView))]
    public partial class PhotostreamTabView : TabView
    {
        public PhotostreamTabView()
        {
            InitializeComponent();
        }
    }
}
