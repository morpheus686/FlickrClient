using FlickrClient.Components.Attributes;
using FlickrClient.Components.Exceptions;
using FlickrClient.DomainModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FlickrClient.Services
{
    internal class ViewService : IViewService
    {
        private readonly Lazy<Dictionary<string, Type>> _viewDictionary;

        public ViewService()
        {
            _viewDictionary = new Lazy<Dictionary<string, Type>>(InitializeViewDictionary);
        }

        private Dictionary<string, Type> InitializeViewDictionary()
        {
            var viewTypeDictionary = new Dictionary<string, Type>();

            var viewsWithViewAttribute = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly.GetName().Name.StartsWith("Flickr"))
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(typeof(FlickrClient.Components.Controls.View)))
                .Where(type => type.CustomAttributes.Count() > 0)
                .Where(type => type.CustomAttributes.Any(customAttribute => customAttribute.AttributeType == typeof(ViewAttribute)));

            foreach (var view in viewsWithViewAttribute)
            {
                var result = view.CustomAttributes.Where(attr => attr.AttributeType == typeof(ViewAttribute))
                    .First();

                Attribute attribute = Attribute.GetCustomAttribute(view, typeof(ViewAttribute));

                if (attribute is ViewAttribute viewAttribute)
                {
                    viewTypeDictionary.Add(viewAttribute.ViewName, view);
                }
            }

            return viewTypeDictionary;
        }

        public FrameworkElement GetView(string viewName)
        {
            if (!_viewDictionary.Value.ContainsKey(viewName))
            {
                throw new ViewNotFoundException();
            }

            return (FrameworkElement)Activator.CreateInstance(_viewDictionary.Value[viewName]);
        }
    }
}