using FlickrClient.Components.ViewModel;
using FlickrClient.ViewModel;
using System;
using System.Windows;

namespace FlickrClient.View
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isLoaded = false;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoadableViewModel lvm)
            {
                lvm.Initialize();
            }
        }
    }
}
