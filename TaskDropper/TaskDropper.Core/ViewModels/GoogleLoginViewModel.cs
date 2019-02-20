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
        public override async Task Initialize()
        {
            await base.Initialize();
        }

        
        private readonly IMvxNavigationService _navigationService;
        private IDatabaseHelper _databaseHelper;
       

        public GoogleLoginViewModel(IMvxNavigationService navigationService,IDatabaseHelper databaseHelper)
        {
            _navigationService = navigationService;
            _databaseHelper = databaseHelper;
            ShowHomeViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<HomeViewModel>());
            ShowTaskListViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<TasksListViewModel>());
            ShowAboutViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<AboutViewModel>());
        }

      

        public void AddUserToTable(string email)
        {
            _databaseHelper.AddUserToTable(email);
            _databaseHelper.UpdateLastUser(email);
        }

        public IMvxAsyncCommand ShowHomeViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowTaskListViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowAboutViewModelCommand { get; private set; }

        public override void ViewAppearing()
        {

        }

    }
}