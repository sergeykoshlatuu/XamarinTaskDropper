using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskDropper.Core.ViewModels
{
    public class MainViewModel: MvxViewModel
    {
        public override async Task Initialize()
        {
            await base.Initialize();

        }

        private readonly IMvxNavigationService _navigationService;

        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowHomeViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<HomeViewModel>());
            ShowTaskListViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<TasksListViewModel>());
        }

        // MvvmCross Lifecycle

        // MVVM Properties

        // MVVM Commands
        public IMvxAsyncCommand ShowHomeViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowTaskListViewModelCommand { get; private set; }

        // Private methods
    }
}