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
        private IDatabaseHelper _databaseHelper;
        private readonly IPhotoService _photoService;
        private readonly IMvxPictureChooserTask _pictureChooserTask;
       
        private ITaskWebApiService _taskWebApiService;

        

        public TaskChangedViewModel(IMvxNavigationService navigationService,
            IDatabaseHelper databaseHelper, 
            IPhotoService photoService,
            IMvxPictureChooserTask pictureChooserTask,
            ITaskWebApiService taskWebApiService)
        {
            _photoService = photoService;
            _navigationService = navigationService;
            _databaseHelper = databaseHelper;
            _pictureChooserTask = pictureChooserTask;
            _taskWebApiService = taskWebApiService;
            UserId = _databaseHelper.GetLastUserId();
    }
        #region Public methods
        public override async Task Initialize()
        {
            await base.Initialize();

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
                Photo = parameter.PhotoTask;
            }
            UpdateSave();
            UpdateIsDetachEnabled();
        }

        public override void ViewAppearing()
        {
            UserEmail = _databaseHelper.GetLastUserEmail();
            RaisePropertyChanged(() => Photo);
            base.ViewAppearing();
        }

        public bool CheckPermissionForCamera()
        {
            return _photoService.CheckPermission();
        }
        #endregion

        #region variables and properties
        private int _id;
        private string _title;
        private string _description;
        private bool _status;
        private int _userId;
        private string _userEmail;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged(() => Id);
            }
        }
        public string UserEmail
        {
            get => _userEmail;
            set
            {
                _userEmail = value;
                RaisePropertyChanged(() => UserEmail);
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
        public bool Status
        {
            get => _status;
            set
            {
                _status = value;
                RaisePropertyChanged(() => Status);
            }
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
        private bool _isSavingEnabled;
        public bool IsSavingEnabled
        {
            get => _isSavingEnabled;
            set
            {
                _isSavingEnabled = value;
                RaisePropertyChanged(() => IsSavingEnabled);
            }
        }
        private bool _isDetachEnabled;
        public bool IsDetachEnabled
        {
            get => _isDetachEnabled;
            set
            {
                _isDetachEnabled = value;
                RaisePropertyChanged(() => IsDetachEnabled);
            }
        }
        private byte[] _photo;
        public byte[] Photo
        {
            get { return _photo; }
            set { _photo = value; RaisePropertyChanged(() => Photo); UpdateIsDetachEnabled(); }
        }
        #endregion

        #region Commands
        public IMvxCommand DettachPhoto
        {
            get { return new MvxCommand(DettachPhotos); }
        }

        public IMvxCommand SaveCommand
        {
            get { return new MvxCommand(SaveTask); }
        }

        public IMvxCommand DeleteCommand
        {
            get { return new MvxCommand(DeleteTask); }
        }

        public IMvxCommand LogOutUserCommand
        {
            get { return new MvxCommand(LogOutUser); }
        }

        public IMvxCommand BackCommand
        {
            get { return new MvxCommand(Back); }
        }

        public IMvxCommand TakePictureCommand
        {
            get { return new MvxCommand(DoTakePicture); }
        }

        public IMvxCommand ChoosePictureCommand
        {
            get { return new MvxCommand(DoChoosePicture); }
        }
        #endregion

        #region Private methods
        private void UpdateSave()
        {
            if (Title != null && Title != " " && Title != "")
            {
                IsSavingEnabled = true;
            }
            else
                IsSavingEnabled = false;
        }

        private void UpdateIsDetachEnabled()
        {
            if (Photo != null)
            {
                IsDetachEnabled = true;
            }
            else
                IsDetachEnabled = false;
        }

        private void DeleteTask()
        {
            _taskWebApiService.DeleteItemTaskAsync(Id.ToString());
            ItemTask _deletedTask = new ItemTask { Id=Id, UserId=UserId, Title=Title, Description=Description, Status=Status, PhotoTask=Photo, UserEmail=UserEmail };
            _databaseHelper.DeleteTaskFromTable(_deletedTask);
            _navigationService.Navigate<HomeViewModel>();
            //_navigationService.Navigate<TasksListViewModel>();

        }

        private void SaveTask()
        {
            ItemTask _addtask = new ItemTask {Id=Id,UserId = UserId, Title = Title, Description = Description, Status = Status, PhotoTask = Photo, UserEmail = UserEmail };
            //_databaseHelper.AddTaskToTable(_addtask);
            if (Id == 0)
            {
                _taskWebApiService.SaveItemTaskAsync(_addtask, true);
            }
            else
            {
                _taskWebApiService.SaveItemTaskAsync(_addtask, false);
            }
            _navigationService.Navigate<HomeViewModel>();
            //_navigationService.Navigate<TasksListViewModel>();
        }

        private void LogOutUser()
        {
            _databaseHelper.LogOutUser();
            _navigationService.Navigate<GoogleLoginViewModel>();
        }

        private void Back()
        {
            //_navigationService.Navigate<TasksListViewModel>();
            _navigationService.Navigate<HomeViewModel>();
        }

        private void DoTakePicture()
        {
            Action<byte[]> action = new Action<byte[]>(GetPhotoFromDroid); 

            _photoService.TakePictureFromCamera(action);
            UpdateIsDetachEnabled();
            RaisePropertyChanged(() => Photo);
        }

        private void DoChoosePicture()
        {
            Action<byte[]> action = new Action<byte[]>(GetPhotoFromDroid);

            _photoService.ChoosePictureFromGallary(action);    
            UpdateIsDetachEnabled();
            RaisePropertyChanged(() => Photo);
        }
      
        private void GetPhotoFromDroid(byte[] photos)
        {
            Photo= photos;
        }

        private void DettachPhotos()
        {
            Photo = null;
        }
        #endregion

    }
}
