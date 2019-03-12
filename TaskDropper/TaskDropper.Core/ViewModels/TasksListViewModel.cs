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
        #region constructors
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
            IsRefreshTaskCollection = false;
        }
        #endregion

        #region Commands
        public IMvxCommand ShowTaskChangedView { get; set; }

        public IMvxCommand LogOutUserCommand
        {
            get { return new MvxCommand(LogOutUser); }
        }

        public IMvxCommand LogOutUserFormsCommand
        {
            get { return new MvxCommand(LogOutFormsUser); }
        }

        private MvxCommand _refreshCommand;
        public MvxCommand RefreshTaskCommand => _refreshCommand = _refreshCommand ?? new MvxCommand(LoadTasks);
        #endregion

        #region variables and properties
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
        private IDatabaseUserService _databaseUserService;
        private IDatabaseTaskService _databaseTaskService;
        private ITaskWebApiService _taskWebApiService;

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
        #endregion

        #region methods
        private void LogOutUser()
        {
            _databaseUserService.LogOutUser();
            _navigationService.Navigate<GoogleLoginViewModel>();
        }

        private void LogOutFormsUser()
        {
            _databaseUserService.LogOutUser();
            _navigationService.Navigate<FormsLoginVieModel>();
        }

        private async Task ShowTaskChanged(ItemTask _taskCreate)
        {
            var result = await _navigationService.Navigate<TaskChangedViewModel, ItemTask>(_taskCreate);

        }

        private async void LoadTasks()
        {
            List<ItemTask> _templeteTasksList;
            IsRefreshTaskCollection = true;
            string userEmail = _databaseUserService.GetLastUserEmail();
            //userEmail = "koshsy6363@gmail.com";

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
        #endregion

        #region overrides
        public override async Task Initialize()
        {
            IsRefreshTaskCollection = false;
            await base.Initialize();
        }

        public override void ViewAppearing()
        {
            RefreshTaskCommand.Execute();
        }
        #endregion
    }
}