using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FlickrClient.Components.Controls
{
    public class PageNavigationControl : Control
    {     
        public static readonly DependencyProperty NextPageCommandProperty =
            DependencyProperty.Register(
                "NextPageCommand", 
                typeof(ICommand), 
                typeof(PageNavigationControl), 
                new PropertyMetadata(null));

        public static readonly DependencyProperty PageProperty =
            DependencyProperty.Register(
                "Page", 
                typeof(int), 
                typeof(PageNavigationControl),
                new PropertyMetadata(0));

        public static readonly DependencyProperty PageCountProperty =
            DependencyProperty.Register(
                "PageCount", 
                typeof(int), 
                typeof(PageNavigationControl), 
                new PropertyMetadata(0));

        public static readonly DependencyProperty PreviousPageCommandProperty =
            DependencyProperty.Register(
                "PreviousPageCommand",
                typeof(ICommand),
                typeof(PageNavigationControl),
                new PropertyMetadata(null));

        public ICommand NextPageCommand
        {
            get { return (ICommand)GetValue(NextPageCommandProperty); }
            set { SetValue(NextPageCommandProperty, value); }
        }

        public int Page
        {
            get { return (int)GetValue(PageProperty); }
            set { SetValue(PageProperty, value); }
        }

        public int PageCount
        {
            get { return (int)GetValue(PageCountProperty); }
            set { SetValue(PageCountProperty, value); }
        }

        public ICommand PreviousPageCommand
        {
            get { return (ICommand)GetValue(PreviousPageCommandProperty); }
            set { SetValue(PreviousPageCommandProperty, value); }
        }
    }
}
