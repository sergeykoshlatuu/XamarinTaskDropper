using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCross.Commands;
using System.Windows.Input;
using TaskDropper.Core.Services;
using TaskDropper.Core.Interface;
using System.Threading.Tasks;


namespace TaskDropper.Core.ViewModels
{
    public class TaskChangedViewModel : MvxViewModel<ItemTask>
    {
        private readonly IMvxNavigationService _navigationService;
        private  ITaskRepository _taskRepositiry;

        public override async Task Initialize()
        {
            await base.Initialize();

        }

        public TaskChangedViewModel(IMvxNavigationService navigationService, ITaskRepository taskRepositiry)
        {
            _navigationService = navigationService;
            _taskRepositiry = taskRepositiry;
            CloseCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<TasksListViewModel>());
           
        }
        public IMvxAsyncCommand CloseCommand { get; set; }
        public IMvxCommand ShowViewTip { get; set; }
 

        private int _id;
        private string _title;
        private string _description;
        private bool _status;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged(() => Id);
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
                UpdateSaveButton();
                
            }
        }
        public void UpdateSaveButton()
        {
            if (Title != null && Title != " " && Title != "")
            {
                SaveStatusButton = true;
            }
            else
                SaveStatusButton = false;
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                RaisePropertyChanged(() => Description);
            }
        }

        public bool Status
        {
            get => _status;
            set
            {
                _status = value;
                RaisePropertyChanged(() => Status);
            }
        }
        public IMvxCommand SaveCommand
        {
            get { return new MvxCommand(SaveTask); }
        }    

        public IMvxCommand DeleteCommand
        {
            get { return new MvxCommand(DeleteTask); }
        }

        private bool _saveStatusButton;
        public bool SaveStatusButton {
            get =>_saveStatusButton;
            set
            {
                _saveStatusButton = value;
                RaisePropertyChanged(() => SaveStatusButton);
            }
            }

        private void DeleteTask()
        {
            ItemTask _deletedTask = new ItemTask(Id, Title, Description, Status);
            _taskRepositiry.DeleteTaskFromTable(_deletedTask);
            _navigationService.Navigate<TasksListViewModel>();
        }

        private void SaveTask()
        {
                ItemTask _addtask = new ItemTask(Id, Title, Description, Status);
                _taskRepositiry.AddToTable(_addtask);
                _navigationService.Navigate<TasksListViewModel>();
            
        }

        public override void Prepare(ItemTask parameter)
        {
            if (parameter!=null)
            {
                Id = parameter.Id;
                Title = parameter.Title;
                Description = parameter.Description;
                Status = parameter.Status;
            }
            UpdateSaveButton();
        }
    }
}
