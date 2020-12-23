using FlickrClient.Components.ViewModel;

namespace FlickrClient.ViewModel.Dialog
{
    internal class MessageDialogViewModel : ViewModelBase
    {
        public string Message { get; }

        public MessageDialogViewModel(string message)
        {
            Message = message;
        }
    }
}
