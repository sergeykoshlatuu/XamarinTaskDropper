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
        private ITaskRepository _taskRepository;
       

        public GoogleLoginViewModel(IMvxNavigationService navigationService,ITaskRepository taskRepository)
        {
            _navigationService = navigationService;
            _taskRepository = taskRepository;
            ShowHomeViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<HomeViewModel>());
            ShowTaskListViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<TasksListViewModel>());
            ShowAboutViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<AboutViewModel>());
        }

      

        public void AddUserToTable(string email)
        {
            _taskRepository.AddUserToTable(email);
            _taskRepository.UpdateLastUser(email);
        }

        public void PrintLastUser()
        {
            List<LastUser> lastUsers = _taskRepository.GetLastUser();
            for (int i = 0; i < lastUsers.Count; i++)
            {
                Console.WriteLine("__________________________");
                Console.WriteLine(lastUsers[i].Id);
                Console.WriteLine(lastUsers[i].Email);
                Console.WriteLine("__________________________");
            }
        }

        public IMvxAsyncCommand ShowHomeViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowTaskListViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowAboutViewModelCommand { get; private set; }



        
        public override void ViewAppearing()
        {

        }

    }
}