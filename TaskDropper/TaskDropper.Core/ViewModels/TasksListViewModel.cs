using MvvmCross.ViewModels;
using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.Commands;
using TaskDropper.Core.Interface;
using TaskDropper.Core.Models;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace TaskDropper.Core.ViewModels
{
    public class TasksListViewModel : BaseViewModel
    {
        private IDatabaseUserService _databaseUserService;
        private IDatabaseTaskService _databaseTaskService;
        private ITaskWebApiService _taskWebApiService;
        public override async Task Initialize()
        {
           
            await base.Initialize();
        }



        public TasksListViewModel(IMvxNavigationService navigationService,
            IDatabaseUserService databaseUserService,
            ITaskWebApiService taskWebApiService,
            IDatabaseTaskService databaseTaskService)
            : base(navigationService)
        {
            _taskWebApiService = taskWebApiService;
            _databaseUserService = databaseUserService;
            _databaseTaskService = databaseTaskService;
            ShowTaskChangedView = new MvxAsyncCommand<ItemTask>(ShowTaskChanged);
        }

        public IMvxCommand ShowTaskChangedView { get; set; }


        private async Task ShowTaskChanged(ItemTask _taskCreate)
        {
            var result = await _navigationService.Navigate<TaskChangedViewModel, ItemTask>(_taskCreate);

        }


        private MvxObservableCollection<ItemTask> _taskCollection;

        public MvxObservableCollection<ItemTask> TaskCollection
        {
            get => _taskCollection;
            set
            {
                _taskCollection = value;
                RaisePropertyChanged(() => TaskCollection);
            }
        }
        private async void LoadTasks()
        {
            List<ItemTask> _templeteTasksList;
            IsRefreshTaskCollection = true;
            string userEmail = _databaseUserService.GetLastUserEmail();

            if (CheckInternetConnection())
            {
                 await _taskWebApiService.RefreshDataAsync(userEmail);
                _templeteTasksList = _databaseTaskService.LoadListItemsTask(userEmail);
            }
            else
            {
                _templeteTasksList = _databaseTaskService.LoadListItemsTask(userEmail);
            }
            TaskCollection = new MvxObservableCollection<ItemTask>(_templeteTasksList);
            IsRefreshTaskCollection = false;
        }

        private MvxCommand _refreshCommand;
        public MvxCommand RefreshTaskCommand => _refreshCommand = _refreshCommand ?? new MvxCommand(LoadTasks);

        private bool _isRefreshTaskCollection;
        public bool IsRefreshTaskCollection
        {
            get => _isRefreshTaskCollection;
            set
            {
                _isRefreshTaskCollection = value;
                RaisePropertyChanged(() => IsRefreshTaskCollection);
            }
        }
        
        public override void ViewAppearing()
        {
            RefreshTaskCommand.Execute();
        }
    }
}