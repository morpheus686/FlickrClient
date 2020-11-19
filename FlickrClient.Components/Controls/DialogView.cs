using FlickrClient.DomainModel.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlickrClient.Components.Controls
{
    public abstract class DialogView : LoadableView
    {
        public DialogView()
        {
            Result = new TaskCompletionSource<DialogResult>();
        }

        public TaskCompletionSource<DialogResult> Result { get; private set; }
    }
}
