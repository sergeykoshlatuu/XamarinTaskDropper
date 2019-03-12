using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskDropper.Core.Interface;
using TaskDropper.Core.Models;

namespace TaskDropper.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region constructors
        public MainViewModel(IMvxNavigationService navigationService, IDatabaseUserService databaseUserService):base(navigationService)
        {
            _databaseUserService = databaseUserService;
            ShowHomeViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<HomeViewModel>()); 
            ShowGoogleLoginViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<GoogleLoginViewModel>());
            ShowAboutViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<AboutViewModel>());
            ShowTaskChangedViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<TaskChangedViewModel>());
            ShowTaskListViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<TasksListViewModel>());
            ShowFormsLogin = new MvxAsyncCommand(async () => await _navigationService.Navigate<FormsLoginVieModel>());
        }
        #endregion

        #region variable
        private IDatabaseUserService _databaseUserService;
        #endregion

        #region commands
        public IMvxAsyncCommand ShowHomeViewModelCommand { get; private set; }       
        public IMvxAsyncCommand ShowGoogleLoginViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowAboutViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowTaskChangedViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowTaskListViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowFormsLogin { get; private set; }
        #endregion

        #region methods
        public bool IsUserLogin()
        {
            if (_databaseUserService.GetLastUserId()==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void LogOutUser()
        {
            _databaseUserService.LogOutUser();
        }
        #endregion
    }
}