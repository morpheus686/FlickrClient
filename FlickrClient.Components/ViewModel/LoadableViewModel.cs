using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrClient.Components.ViewModel
{
    public class LoadableViewModel : ViewModelBase
    {
        public Task Initialize()
        {
            InitializeInternal();
            return InitializeInternalAsync();
        }

        protected virtual void InitializeInternal()
        {

        }

        protected virtual Task InitializeInternalAsync()
        {
            return Task.CompletedTask;
        }
    }
}
