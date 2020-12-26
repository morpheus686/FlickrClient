using FlickrClient.Components.ViewModel;
using System;

namespace FlickrClient.ViewModel.Dialog
{
    internal class IndeterminateProgressDialogViewModel : ViewModelBase
    {
        private string _message;

        public IndeterminateProgressDialogViewModel() : this(String.Empty)
        {
        }

        public IndeterminateProgressDialogViewModel(string message)
        {
            _message = message;
        }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                RaisePropertyChanged();
            }
        }
    }
}