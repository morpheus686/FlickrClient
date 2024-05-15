using FlickrClient.DomainModel.Services;
using FlickrClient.View;
using FlickrClient.View.Dialog;
using FlickrClient.ViewModel.Dialog;
using MaterialDesignThemes.Wpf;
using System;
using System.Threading.Tasks;

namespace FlickrClient.Services
{
    internal class DialogService : IDialogService
    {
        private const string IndeterminateProgressDialogViewName = "IndeterminateProgressDialogView";
        private const string MessageDialogViewName = "MessageDialogView";
        private const string DialogIdentifier = "DialogHost";
        private readonly Lazy<DialogHost> _dialogHost;
        private readonly IViewService _viewService;

        public DialogService(IViewService viewService)
        {
            _viewService = viewService;
            _dialogHost = new Lazy<DialogHost>(LoadDialogHost);
        }

        public Task<object> ShowDialog<VM>(VM viewModel, string dialogName)
        {
            var view = _viewService.GetView(dialogName);
            view.DataContext = viewModel;

            return DialogHost.Show(view, DialogIdentifier);
        }

        public Task<object> ShowDialog(string dialogName)
        {
            var view = _viewService.GetView(dialogName);
            return DialogHost.Show(view, DialogIdentifier);
        }

        public Task ShowIndeterminateDialog(Func<Task> progressTask)
        {
            return ShowIndeterminateDialog(progressTask, null);
        }

        public async Task ShowIndeterminateDialog(Task worktask)
        {
            try
            {
                OpenIndeterminateProgressDialog(null);
                await worktask;
            }
            finally
            {
                CloseIndeterminateProgressDialog();
            }
        }

        public async Task ShowIndeterminateDialog(Func<Task> progressTask, string message)
        {
            try
            {
                OpenIndeterminateProgressDialog(message);
                await progressTask();
            }
            finally
            {
                CloseIndeterminateProgressDialog();
            }
        }

        public Task ShowMessage(string message)
        {
            var view = _viewService.GetView(MessageDialogViewName);
            view.DataContext = new MessageDialogViewModel(message);

            return DialogHost.Show(view);
        }

        private void CloseIndeterminateProgressDialog()
        {
            _dialogHost.Value.IsOpen = false;
            _dialogHost.Value.DialogContent = null;
        }

        private DialogHost LoadDialogHost()
        {
            MainWindow mainWindow = App.Current.MainWindow as MainWindow;
            return mainWindow.DialogHost;
        }

        private void OpenIndeterminateProgressDialog(string message)
        {
            var indeterminateDialog = _viewService.GetView(IndeterminateProgressDialogViewName);
            indeterminateDialog.DataContext = new IndeterminateProgressDialogViewModel(message);

            _dialogHost.Value.DialogContent = indeterminateDialog;
            _dialogHost.Value.IsOpen = true;
        }
    }
}