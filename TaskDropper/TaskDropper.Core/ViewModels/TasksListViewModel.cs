using MvvmCross.ViewModels;
using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.Commands;
using TaskDropper.Core.Interface;
using TaskDropper.Core.Models;
using System.Collections.Generic;

namespace TaskDropper.Core.ViewModels
{
    public class TasksListViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public ITaskRepository _taskRepository;

        public override async Task Initialize()
        {
            await base.Initialize();


        }

        public TasksListViewModel(IMvxNavigationService navigationService, ITaskRepository taskRepositiry)
        {
            _navigationService = navigationService;
            _taskRepository = taskRepositiry;
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

        public override void ViewAppearing()
        {
            List<ItemTask> _templeteTasksList = _taskRepository.LoadListItems();
            TaskCollection = new MvxObservableCollection<ItemTask>(_templeteTasksList);
            //System.Console.WriteLine(TaskCollection);
        }
    }
}
