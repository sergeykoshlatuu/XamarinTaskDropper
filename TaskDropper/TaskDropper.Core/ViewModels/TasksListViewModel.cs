using MvvmCross.ViewModels;
using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.Commands;
using TaskDropper.Core.Interface;
using TaskDropper.Core.Models;
using System.Collections.Generic;

namespace TaskDropper.Core.ViewModels
{
    public class TasksListViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public IDatabaseHelper _databaseHelper;
        private ITaskWebApiService _taskWebApiService;
        public override async Task Initialize()
        {
            await base.Initialize();


        }

        public TasksListViewModel(IMvxNavigationService navigationService, IDatabaseHelper databaseHelper, ITaskWebApiService taskWebApiService)
        {
            _taskWebApiService = taskWebApiService;
            _navigationService = navigationService;
            _databaseHelper = databaseHelper;
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

        public async override void ViewAppearing()
        {
            int userId = _databaseHelper.GetLastUserId();
            string userEmail = _databaseHelper.GetLastUserEmail();
            //List<ItemTask> _templeteTasksList = _databaseHelper.LoadListItemsTask(userEmail);
            List<ItemTask> _templeteTasksList = await _taskWebApiService.RefreshDataAsync(userEmail);
            TaskCollection = new MvxObservableCollection<ItemTask>(_templeteTasksList);
            //System.Console.WriteLine(TaskCollection);
        }
    }
}