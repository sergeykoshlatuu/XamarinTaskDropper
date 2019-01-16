using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskDropper.Core.Models;

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
            TaskListViewModel = Mvx.IoCConstruct<TasksListViewModel>();
            AboutViewModel = Mvx.IoCConstruct<AboutViewModel>();
            ShowTaskChangedView = new MvxAsyncCommand<ItemTask>(ShowTaskChanged);
        }

        public IMvxCommand ShowTaskChangedView { get; set; }


        private async Task ShowTaskChanged(ItemTask _taskCreate)
        {
            var result = await _navigationService.Navigate<TaskChangedViewModel, ItemTask>(_taskCreate);
           
        }

       public TasksListViewModel TaskListViewModel;
       public AboutViewModel AboutViewModel;
    }
}
