using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCross.Commands;
using System.Windows.Input;
using TaskDropper.Core.Models;
using TaskDropper.Core.Interface;
using System.Threading.Tasks;


namespace TaskDropper.Core.ViewModels
{
    public class TaskChangedViewModel : MvxViewModel<ItemTask>
    {
        private readonly IMvxNavigationService _navigationService;
        private ITaskRepository _taskRepositiry;

        public override async Task Initialize()
        {
            await base.Initialize();

        }


        public TaskChangedViewModel(IMvxNavigationService navigationService, ITaskRepository taskRepositiry)
        {
            _navigationService = navigationService;
            _taskRepositiry = taskRepositiry;
            CloseCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<HomeViewModel>());
            UserId = _taskRepositiry.GetLastUserId();
        }
        public IMvxAsyncCommand CloseCommand { get; set; }
      
        private int _id;
        private string _title;
        private string _description;
        private bool _status;
        private int _userId;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged(() => Id);
            }
        }

        public int UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                RaisePropertyChanged(() => UserId);
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
                UpdateSave();

            }
        }
        public void UpdateSave()
        {
            if (Title != null && Title != " " && Title != "")
            {
                SaveStatus = true;
            }
            else
                SaveStatus = false;
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

        private bool _saveStatus;
        public bool SaveStatus
        {
            get => _saveStatus;
            set
            {
                _saveStatus = value;
                RaisePropertyChanged(() => SaveStatus);
            }
        }

        private void DeleteTask()
        {
            ItemTask _deletedTask = new ItemTask(Id,UserId, Title, Description, Status);
            _taskRepositiry.DeleteTaskFromTable(_deletedTask);
            _navigationService.Navigate<HomeViewModel>();
        }

        private void SaveTask()
        {
            ItemTask _addtask = new ItemTask(Id,UserId, Title, Description, Status);
            _taskRepositiry.AddToTable(_addtask);
            _navigationService.Navigate<HomeViewModel>();

        }

        public override void Prepare(ItemTask parameter)
        {
            if (parameter != null)
            {
                Id = parameter.Id;
                UserId = parameter.UserId;
                Title = parameter.Title;
                Description = parameter.Description;
                Status = parameter.Status;
            }
            UpdateSave();
        }
    }
}
