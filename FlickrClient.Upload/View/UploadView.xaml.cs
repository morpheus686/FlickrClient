using FlickrClient.Components.Attributes;
using FlickrClient.Components.Controls;
using System.Windows;

namespace FlickrClient.Upload.View
{
    /// <summary>
    /// Interaktionslogik für UploadViewModel.xaml
    /// </summary>
    [View(nameof(UploadView))]
    public partial class UploadView : DialogView
    {
        public UploadView()
        {
            InitializeComponent();
        }

        private void Rectangle_DragOver(object sender, DragEventArgs e)
        {
            bool isFileDrop = e.Data.GetDataPresent(DataFormats.FileDrop);

            if (!isFileDrop)
            {
                e.Handled = true;
                e.Effects = DragDropEffects.None;
            }
        }

        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
            bool isFileDrop = e.Data.GetDataPresent(DataFormats.FileDrop);

            if (!isFileDrop)
            {
                return;
            }

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
        }
    }
}