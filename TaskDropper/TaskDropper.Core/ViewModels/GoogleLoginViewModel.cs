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
   public class GoogleLoginViewModel : BaseViewModel
    {
        #region constructors
        public GoogleLoginViewModel(IMvxNavigationService navigationService,IDatabaseUserService databaseUserService, ITaskWebApiService taskWebApiService):base(navigationService)
        {
            _databaseUserService = databaseUserService;
            _taskWebApiService = taskWebApiService;
            ShowHomeViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<HomeViewModel>());
            ShowTaskListViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<TasksListViewModel>());
            ShowAboutViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<AboutViewModel>());
        }
        #endregion

        #region variable
        private IDatabaseUserService _databaseUserService;
        private ITaskWebApiService _taskWebApiService;
        #endregion

        #region methods
        public void AddUserToTable(string email,string token)
        {
            _databaseUserService.AddUserToTable(email,token);
            _databaseUserService.UpdateLastUser(email);
           
        }
        
        public async Task GetToken()
        {
            await _taskWebApiService.GetToken();
        }
        #endregion

        #region commands
        public IMvxAsyncCommand ShowHomeViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowTaskListViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowAboutViewModelCommand { get; private set; }
        public IMvxAsyncCommand GetApiToken
        {
            get { return new MvxAsyncCommand(GetToken); }
        }
        #endregion

        #region overrides
        public override void ViewAppearing()
        {

        }

        public override async Task Initialize()
        {
            await base.Initialize();
        }
        #endregion
    }
}