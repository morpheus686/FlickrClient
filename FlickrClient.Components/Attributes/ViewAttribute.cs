using System;

namespace FlickrClient.Components.Attributes
{
    public class ViewAttribute : Attribute
    {
        public string ViewName { get; }

        public ViewAttribute(string viewName)
        {
            ViewName = viewName;
        }
    }
}
