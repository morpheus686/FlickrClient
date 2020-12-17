using CommonServiceLocator;
using System;
using System.Windows;
using System.Windows.Markup;

namespace FlickrClient.Components
{
    public class ViewModelBinding : MarkupExtension
    {
        public Type ViewModelType { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(
                new DependencyObject());
            if (designTime)
            {
                return null;
            }

            if (ViewModelType == null)
            {
                throw new Exception("No ViewModel type supported!");
            }
            
            return ServiceLocator.Current.GetInstance(ViewModelType);
        }
    }
}
