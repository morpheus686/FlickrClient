using FlickrClient.DomainModel.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrClient.DomainModel.Services
{
    public interface IDialogService
    {
        Task<object> ShowDialog<VM>(VM viewModel, string DialogName);
        Task<object> ShowDialog(string dialogName);
        Task ShowIndeterminateDialog(Func<Task> progressTask);
    }
}
