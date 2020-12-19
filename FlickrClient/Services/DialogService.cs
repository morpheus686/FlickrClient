using FlickrClient.DomainModel.Enumerations;
using FlickrClient.DomainModel.Services;
using FlickrClient.View;
using FlickrClient.View.Dialog;
using MaterialDesignThemes.Wpf;
using System;
using System.Threading.Tasks;

namespace FlickrClient.Services
{
    internal class DialogService : IDialogService
    {
        private const string IndeterminateProgressDialogViewName = "IndeterminateProgressDialogView";

        private readonly IViewService _viewService;
        private readonly Lazy<DialogHost> _dialogHost;

        public DialogService(IViewService viewService)
        {
            _viewService = viewService;
            _dialogHost = new Lazy<DialogHost>(LoadDialogHost);
        }

        private DialogHost LoadDialogHost()
        {     
            MainWindow mainWindow = App.Current.MainWindow as MainWindow;
            return mainWindow.DialogHost;            
        }

        public Task<object> ShowDialog<VM>(VM viewModel, string dialogName)
        {
            var view = _viewService.GetView(dialogName);
            view.DataContext = viewModel;

            return DialogHost.Show(view);
        }

        public async Task ShowIndeterminateDialog(Func<Task> progressTask)
        {
            OpenIndeterminateProgressDialog();
            await progressTask();
            CloseIndeterminateProgressDialog();
        }

        private void CloseIndeterminateProgressDialog()
        {
            _dialogHost.Value.IsOpen = false;
            _dialogHost.Value.DialogContent = null;
        }

        public Task<object> ShowDialog(string dialogName)
        {
            var view = _viewService.GetView(dialogName);
            return DialogHost.Show(view);
        }

        public async Task ShowIndeterminateDialog(Task worktask)
        {
            OpenIndeterminateProgressDialog();
            await worktask;
            CloseIndeterminateProgressDialog();
        }

        private void OpenIndeterminateProgressDialog(string message)
        {
            OpenIndeterminateProgressDialog();
            var dialogView = (IndeterminateProgressDialogView)_dialogHost.Value.DialogContent;

            dialogView.MessageTextBlock.Visibility = System.Windows.Visibility.Visible;
            dialogView.MessageTextBlock.Text = message;
        }

        private void OpenIndeterminateProgressDialog()
        {
            _dialogHost.Value.IsOpen = true;
            _dialogHost.Value.DialogContent = _viewService.GetView(IndeterminateProgressDialogViewName);
        }

        public async Task ShowIndeterminateDialog(Func<Task> progressTask, string message)
        {
            OpenIndeterminateProgressDialog(message);
            await progressTask();
            CloseIndeterminateProgressDialog();
        }
    }
}
