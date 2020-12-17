using FlickrClient.Components.Attributes;
using FlickrClient.Components.Controls;
using FlickrClient.Components.ViewModel;
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
    [View(nameof(SearchTabView))]
    public partial class SearchTabView : TabView
    {
        public SearchTabView()
        {
            InitializeComponent();
        }
    }
}
