using FlickrClient.Components.Commands;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlickrClient.Components.ViewModel
{
    public class PageNavigationViewModel : ViewModelBase
    {    
        private const int FirstPageNumber = 1;

        private readonly Func<Task> _nextPageTask;
        private readonly Func<Task> _previousPageTask;

        private int pageCount;
        private int page;


        public ICommand NextPageCommand { get; }
        public ICommand PreviousPageCommand { get; }

        public int Page
        {
            get => page;
            set
            {
                page = value;
                RaisePropertyChanged();
            }
        }

        public int PageCount
        {
            get => pageCount;
            set
            {
                pageCount = value;
                RaisePropertyChanged();
            }
        }

        public PageNavigationViewModel(Func<Task> nextPageTask,
            Func<Task> previousPageTask)
        {
            _nextPageTask = nextPageTask;
            _previousPageTask = previousPageTask;

            NextPageCommand = new Command(CanExecuteNextPageCommand, ExecuteNextPageCommand);
            PreviousPageCommand = new Command(CanExecutePreviousPageCommand, ExecutePreviousPageCommand);
        }

        private async void ExecutePreviousPageCommand()
        {
            await _previousPageTask();
        }

        private bool CanExecutePreviousPageCommand()
        {
            return Page > FirstPageNumber;
        }

        private async void ExecuteNextPageCommand()
        {
            await _nextPageTask();
        }

        private bool CanExecuteNextPageCommand()
        {
            return Page < PageCount;
        }
    }
}
