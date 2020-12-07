using FlickrClient.Components.Controls;
using FlickrClient.DomainModel.Enumerations;
using FlickrClient.DomainModel.Services;
using FlickrClient.View;
using MaterialDesignThemes.Wpf;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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

        public Task<DialogResult> ShowDialog<VM>(VM viewModel, string dialogName)
        { 
            throw new NotImplementedException();    
        }

        public async Task ShowIndeterminateDialog(Func<Task> progressTask)
        {
            _dialogHost.Value.IsOpen = true;
            _dialogHost.Value.DialogContent = _viewService.GetView(IndeterminateProgressDialogViewName);

            await progressTask();
  
            _dialogHost.Value.DialogContent = null;   
            _dialogHost.Value.IsOpen = false;     
        }
    }
}
