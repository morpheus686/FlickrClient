using CommonServiceLocator;
using FlickrClient.DomainModel.Services;
using System;
using System.Threading.Tasks;

namespace FlickrClient.Components.ViewModel
{
    public class LoadableViewModel : ViewModelBase
    {
        public LoadableViewModel() : this(LoadDialogService())
        {
        }

        private static IDialogService LoadDialogService()
        {
            return ServiceLocator.Current.GetInstance<IDialogService>();
        }

        public LoadableViewModel(IDialogService dialogService)
        {
            DialogService = dialogService;
        }

        protected IDialogService DialogService { get; }

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

        protected Task InitializeInternalAsync(Func<Task> initializer)
        {
            return DialogService.ShowIndeterminateDialog(initializer);
        }
    }
}