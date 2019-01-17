using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskDropper.Core.Models;
using TaskDropper.Core.Interface;

namespace TaskDropper.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public override async Task Initialize()
        {
            await base.Initialize();

        }
        private ITaskRepository _taskRepository;

        public HomeViewModel(IMvxNavigationService navigationService, ITaskRepository taskRepository)
        {
            _navigationService = navigationService;
            _taskRepository = taskRepository;
            TaskListViewModel = Mvx.IoCConstruct<TasksListViewModel>();
            AboutViewModel = Mvx.IoCConstruct<AboutViewModel>();
            ShowTaskChangedView = new MvxAsyncCommand<ItemTask>(ShowTaskChanged);
        }
        public IMvxCommand LogOutUser
        {
            get { return new MvxCommand(LogOutUsers); }
        }

        private void LogOutUsers()
        {
            _taskRepository.LogOutUser();
            _navigationService.Navigate<GoogleLoginViewModel>();
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
