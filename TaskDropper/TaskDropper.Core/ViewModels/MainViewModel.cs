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
        public MainViewModel(IMvxNavigationService navigationService
            , IDatabaseUserService databaseUserService
            ,ITaskWebApiService taskWebApiService):base(navigationService)
        {
            _databaseUserService = databaseUserService;
            _taskWebApiService = taskWebApiService;
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
        private ITaskWebApiService _taskWebApiService;
        #endregion

        #region commands
        public IMvxAsyncCommand ShowHomeViewModelCommand { get; private set; }       
        public IMvxAsyncCommand ShowGoogleLoginViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowAboutViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowTaskChangedViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowTaskListViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowFormsLogin { get; private set; }
        public IMvxAsyncCommand GetApiToken
        {
            get { return new MvxAsyncCommand(GetToken); }
        }
      
        #endregion

        #region methods
        public bool IsUserLogin()
        {
            if (_databaseUserService.GetLastUserId()!=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task GetToken()
        {
            await _taskWebApiService.GetToken();
        }

        public void LogOutUser()
        {
            _databaseUserService.LogOutUser();
        }
        #endregion
    }
}