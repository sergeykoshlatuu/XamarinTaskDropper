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

        private readonly IMvxNavigationService _navigationService;
        private IDatabaseHelper _taskRepository;

        public MainViewModel(IMvxNavigationService navigationService, IDatabaseHelper taskRepository)
        {
            _navigationService = navigationService;
            _taskRepository = taskRepository;
            ShowHomeViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<HomeViewModel>());
            ShowTaskListViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<TasksListViewModel>());
            ShowGoogleLoginViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<GoogleLoginViewModel>());
            ShowAboutViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<AboutViewModel>());
        }
     
        public IMvxAsyncCommand ShowHomeViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowTaskListViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowGoogleLoginViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowAboutViewModelCommand { get; private set; }

        public bool IsUserLogin()
        {
            if (_taskRepository.GetLastUserId()==1)
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
            _taskRepository.LogOutUser();
        }
    }
}