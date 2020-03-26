using FlickrClient.DomainModel.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrClient.ViewModel
{
    [Export]
    public class MainWindowViewModel
    {
        private readonly IDialogService _dialogService;

        [ImportingConstructor]
        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }
    }
}
