using System;

namespace FlickrClient.Components.Exceptions
{
    public class ViewNotFoundException : Exception
    {
        public ViewNotFoundException() : base("Please check, if it is registered with the View attribute.")
        {

        }
    }
}
