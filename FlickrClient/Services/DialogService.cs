using FlickrClient.DomainModel.Enumerations;
using FlickrClient.DomainModel.Services;
using FlickrClient.View;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FlickrClient.Services
{
    internal class DialogService : IDialogService
    {
        private readonly IViewService _viewService;
        private readonly Lazy<ContentControl> _dialogRegion;

        public DialogService(IViewService viewService)
        {
            _viewService = viewService;
            _dialogRegion = new Lazy<ContentControl>(LoadDialogRegion);
        }

        private ContentControl LoadDialogRegion()
        {
            if (!(Application.Current.MainWindow is MainWindow mainWindow))
            {
                throw new Exception("DialogRegion not found!");
            }

            return mainWindow.DialogRegion;
        }

        public async Task<DialogResult> ShowDialog<VM>(VM viewModel, string dialogName)
        {
            var dialog =  _viewService.GetView(dialogName);
            _dialogRegion.Value.Content = dialog ?? throw new Exception("Dialog not found!");
            _dialogRegion.Value.DataContext = viewModel;

            await Task.Delay(5000);

            _dialogRegion.Value.Content = null;

            return DialogResult.Ok;
        }
    }
}
