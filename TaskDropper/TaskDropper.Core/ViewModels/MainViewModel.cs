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
        private IDatabaseUserService _databaseUserService;
        public MainViewModel(IMvxNavigationService navigationService, IDatabaseUserService databaseUserService):base(navigationService)
        {
            _databaseUserService = databaseUserService;
            ShowHomeViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<HomeViewModel>()); 
            ShowGoogleLoginViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<GoogleLoginViewModel>());
        }
     
        public IMvxAsyncCommand ShowHomeViewModelCommand { get; private set; }       
        public IMvxAsyncCommand ShowGoogleLoginViewModelCommand { get; private set; }       

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
    }
}