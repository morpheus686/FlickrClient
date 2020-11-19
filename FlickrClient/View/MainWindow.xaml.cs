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
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindowLoaded;
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModelBase vms)
            {
                vms.Initialize();
            }
        }
    }
}
