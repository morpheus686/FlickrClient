using FlickrClient.DomainModel.Enumerations;
using FlickrClient.DomainModel.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrClient.Services
{    
    public class DialogService : IDialogService
    {
        public async Task<DialogResult> ShowDialog<VM>(VM viewModel, string DialogName)
        {
            return DialogResult.Ok;
        }
    }
}
