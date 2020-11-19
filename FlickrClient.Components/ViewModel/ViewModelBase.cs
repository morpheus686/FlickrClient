using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlickrClient.Components.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
