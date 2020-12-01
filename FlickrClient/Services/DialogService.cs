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

        public DialogService(IViewService viewService)
        {
            _viewService = viewService;
        }

        public Task<DialogResult> ShowDialog<VM>(VM viewModel, string dialogName)
        {
            throw new Exception();
        }
    }
}
