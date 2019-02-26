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
using Xamarin.Essentials;

namespace TaskDropper.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public override async Task Initialize()
        {
            await base.Initialize();

        }
        private IDatabaseUserService _databaseUserService;
        public HomeViewModel(IMvxNavigationService navigationService, IDatabaseUserService databaseUserService):base(navigationService)
        {
            _databaseUserService = databaseUserService;
            TaskListViewModel = Mvx.IoCConstruct<TasksListViewModel>();
            AboutViewModel = Mvx.IoCConstruct<AboutViewModel>();
            ShowTaskChangedViewCommand = new MvxAsyncCommand<ItemTask>(ShowTaskChanged);

            
        }


        

        public IMvxCommand LogOutUserCommand
        {
            get { return new MvxCommand(LogOutUser); }
        }

        private void LogOutUser()
        {
            _databaseUserService.LogOutUser();
            _navigationService.Navigate<GoogleLoginViewModel>();
        }

        public IMvxCommand ShowTaskChangedViewCommand { get; set; }


        private async Task ShowTaskChanged(ItemTask _taskCreate)
        {
            var result = await _navigationService.Navigate<TaskChangedViewModel, ItemTask>(_taskCreate);
           
        }

      

        public TasksListViewModel TaskListViewModel;
       public AboutViewModel AboutViewModel;
    }
}
