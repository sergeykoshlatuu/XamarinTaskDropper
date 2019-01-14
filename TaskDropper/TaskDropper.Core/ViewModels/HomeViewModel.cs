using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskDropper.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public override async Task Initialize()
        {
            await base.Initialize();

        }

        public HomeViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            AboutViewModel = new MvxAsyncCommand(async () => await _navigationService.Navigate<AboutViewModel>());
            TaskListViewModel = new MvxAsyncCommand(async () => await _navigationService.Navigate<TasksListViewModel>());
        }

        public IMvxAsyncCommand TaskListViewModel { get; private set; }
        public IMvxAsyncCommand AboutViewModel { get; private set; }

        public TasksListViewModel TasksListViewModel { get; set; }
        public AboutViewModel AboutsViewModel { get; set; }
    }
}
