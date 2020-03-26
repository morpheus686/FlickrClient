﻿using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace FlickrClient.Components
{
    public class ViewModelBinding : MarkupExtension
    {
        public Type ViewModelType { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {  
            if (ViewModelType == null)
            {
                throw new Exception("No ViewModel type supported!");
            }
            
            return ServiceLocator.Current.GetInstance(ViewModelType);
        }
    }
}
