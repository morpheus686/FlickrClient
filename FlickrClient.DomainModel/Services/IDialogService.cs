using System;
using System.Threading.Tasks;

namespace FlickrClient.DomainModel.Services
{
    public interface IDialogService
    {
        Task<object> ShowDialog<VM>(VM viewModel, string DialogName);
        Task<object> ShowDialog(string dialogName);
        Task ShowIndeterminateDialog(Func<Task> progressTask);
        Task ShowIndeterminateDialog(Func<Task> progressTask, string message);
        Task ShowIndeterminateDialog(Task worktask);
        Task ShowMessage(string message);
    }
}
