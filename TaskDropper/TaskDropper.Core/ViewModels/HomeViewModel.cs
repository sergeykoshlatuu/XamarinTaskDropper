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
        #region constructors
        public HomeViewModel(IMvxNavigationService navigationService
            //, IDatabaseUserService databaseUserService
            ):base(navigationService)
        {
            //_databaseUserService = databaseUserService;
            TaskListViewModel = Mvx.IoCConstruct<TasksListViewModel>();
            AboutViewModel = Mvx.IoCConstruct<AboutViewModel>();
            TaskChangedViewModel = Mvx.IoCConstruct<TaskChangedViewModel>();
            ShowTaskChangedViewCommand = new MvxAsyncCommand<ItemTask>(ShowTaskChanged);
        }
        #endregion

        #region overrides
        public override async Task Initialize()
        {
            await base.Initialize();

        }
        #endregion

        #region commands
        public IMvxCommand LogOutUserCommand
        {
            get { return new MvxCommand(LogOutUser); }
        }

        public IMvxCommand ShowTaskChangedViewCommand { get; set; }
        #endregion

        #region methods
        private void LogOutUser()
        {
            _databaseUserService.LogOutUser();
            _navigationService.Navigate<GoogleLoginViewModel>();
        }

        private async Task ShowTaskChanged(ItemTask _taskCreate)
        {
            var result = await _navigationService.Navigate<TaskChangedViewModel, ItemTask>(_taskCreate);           
        }
        #endregion

        #region variable
        private IDatabaseUserService _databaseUserService;
        public TasksListViewModel TaskListViewModel;
       public AboutViewModel AboutViewModel;
        public TaskChangedViewModel TaskChangedViewModel;
        #endregion
    }
}
