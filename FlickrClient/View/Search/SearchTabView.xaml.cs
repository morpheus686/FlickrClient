﻿using FlickrClient.Components.ViewModel;
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

namespace FlickrClient.View.Search
{
    /// <summary>
    /// Interaktionslogik für SearchTabView.xaml
    /// </summary>
    public partial class SearchTabView : UserControl
    {
        public SearchTabView()
        {
            InitializeComponent();
            Loaded += SearchTabView_Loaded;
        }

        private void SearchTabView_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoadableViewModel lvm)
            {
                lvm.Initialize();
            }
        }
    }
}
