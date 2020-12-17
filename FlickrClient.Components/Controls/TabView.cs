using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlickrClient.Components.Controls
{
    public class TabView : LoadableView
    {
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register(
                "Caption", 
                typeof(string), 
                typeof(TabView), 
                new PropertyMetadata(String.Empty));

        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }
    }
}
