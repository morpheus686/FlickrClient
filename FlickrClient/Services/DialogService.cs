using FlickrClient.Components.Controls;
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
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                return mainWindow.DialogRegion;
            }

            throw new Exception("DialogRegion not found!");
        }

        public async Task<DialogResult> ShowDialog<VM>(VM viewModel, string dialogName)
        {
            var dialog = _viewService.GetView(dialogName);

            if (!(dialog is DialogView dialogView))
            {
                throw new Exception("Requested view is not a dialog!");
            }

            dialogView.DataContext = viewModel;
            _dialogRegion.Value.Content = dialogView;

            var result = await dialogView.Result.Task;

            _dialogRegion.Value.Content = null;

            return result;
        }
    }
}
