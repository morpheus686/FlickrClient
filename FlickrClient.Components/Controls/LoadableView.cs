using FlickrClient.Components.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlickrClient.Components.Controls
{
    public class LoadableView : View
    {
        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register(
                "IsLoading",
                typeof(bool),
                typeof(LoadableView),
                new PropertyMetadata(false));

        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        public LoadableView()
        {
            Loaded += View_Loaded;
        }

        private async void View_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is LoadableViewModel lvm)
            {
                IsLoading = true;
                await lvm.Initialize();
                IsLoading = false;
            }
        }
    }
}
