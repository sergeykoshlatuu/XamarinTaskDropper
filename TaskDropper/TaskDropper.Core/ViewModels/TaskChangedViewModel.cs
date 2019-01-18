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
using MvvmCross.Plugin.PictureChooser;
using System.IO;

namespace TaskDropper.Core.ViewModels
{
    public class TaskChangedViewModel : MvxViewModel<ItemTask>
    {
        private readonly IMvxNavigationService _navigationService;
        private IDatabaseHelper _taskRepository;
        private readonly IMvxPictureChooserTask _pictureChooserTask;

        public override async Task Initialize()
        {
            await base.Initialize();

        }


        public TaskChangedViewModel(IMvxNavigationService navigationService, IDatabaseHelper taskRepositiry, IMvxPictureChooserTask pictureChooserTask)
        {
            _pictureChooserTask = pictureChooserTask;
            _navigationService = navigationService;
            _taskRepository = taskRepositiry;
            CloseCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<HomeViewModel>());
            UserId = _taskRepository.GetLastUserId();
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

        public void UpdatePhotoStatus()
        {
            if (Bytes!=null)
            {
                PhotoStatus = true;
            }
            else
                PhotoStatus = false;
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

        private bool _photoStatus;
        public bool PhotoStatus
        {
            get => _photoStatus;
            set
            {
                _photoStatus = value;
                RaisePropertyChanged(() => PhotoStatus);
            }
        }
        
        private void DeleteTask()
        {
            ItemTask _deletedTask = new ItemTask(Id,UserId, Title, Description, Status,Bytes);
            _taskRepository.DeleteTaskFromTable(_deletedTask);
            _navigationService.Navigate<HomeViewModel>();
        }

        private void SaveTask()
        {
            ItemTask _addtask = new ItemTask(Id,UserId, Title, Description, Status,Bytes);
            _taskRepository.AddTaskToTable(_addtask);
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
                Bytes = parameter.PhotoTask;
            }
            UpdateSave();
            UpdatePhotoStatus();
        }

        public IMvxCommand LogOutUser
        {
            get { return new MvxCommand(LogOutUsers); }
        }

        private void LogOutUsers()
        {
            _taskRepository.LogOutUser();
            _navigationService.Navigate<GoogleLoginViewModel>();
        }

       public IMvxCommand Back
        {
            get { return new MvxCommand(GoBack); }
        }

        private void GoBack()
        {
            _navigationService.Navigate<HomeViewModel>();
        }

        public IMvxCommand TakePictureCommand
        {
            get { return new MvxCommand(DoTakePicture); }
        }

        private void DoTakePicture()
        {
            _pictureChooserTask.TakePicture(400, 95, OnPicture, () => { });
            UpdatePhotoStatus();
            RaiseAllPropertiesChanged();

        }

        public IMvxCommand ChoosePictureCommand
        {
            get { return new MvxCommand(DoChoosePicture); }
        }
 

        private void DoChoosePicture()
        {
           _pictureChooserTask.ChoosePictureFromLibrary(400, 95, OnPicture, () => { });
            UpdatePhotoStatus();
            RaiseAllPropertiesChanged();
        }

        private byte[] _bytes;

        public byte[] Bytes
        {
            get { return _bytes; }
            set { _bytes = value; RaisePropertyChanged(() => Bytes); UpdatePhotoStatus(); }
        }

        private void OnPicture(Stream pictureStream)
        {
            var memoryStream = new MemoryStream();
            pictureStream.CopyTo(memoryStream);
            Bytes = memoryStream.ToArray();
        }

        public IMvxCommand DettachPhoto
        {
            get { return new MvxCommand(DettachPhotos); }
        }

        public void DettachPhotos()
        {
            Bytes = null;
        }
    }
}
