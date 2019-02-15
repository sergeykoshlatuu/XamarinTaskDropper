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
        private readonly IPhotoService _photoService;
        private readonly IMvxPictureChooserTask _pictureChooserTask;
        public override async Task Initialize()
        {
            await base.Initialize();

        }


        public TaskChangedViewModel(IMvxNavigationService navigationService,
            IDatabaseHelper taskRepository, 
            IPhotoService photoService
            ,IMvxPictureChooserTask pictureChooserTask
            )
        {
            _photoService = photoService;
            _navigationService = navigationService;
            _taskRepository = taskRepository;
            _pictureChooserTask = pictureChooserTask;
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
                IsSavingEnabled = true;
            }
            else
                IsSavingEnabled = false;
        }

        public void UpdateIsDetachEnabled()
        {
            if (Photo!=null)
            {
                IsDetachEnabled = true;
            }
            else
                IsDetachEnabled = false;
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
        
        private void DeleteTask()
        {
            ItemTask _deletedTask = new ItemTask(Id,UserId, Title, Description, Status,Photo);
            _taskRepository.DeleteTaskFromTable(_deletedTask);
            _navigationService.Navigate<HomeViewModel>();
            //_navigationService.Navigate<TasksListViewModel>();

        }

        private void SaveTask()
        {
            ItemTask _addtask = new ItemTask(Id,UserId, Title, Description, Status,Photo);
            _taskRepository.AddTaskToTable(_addtask);
            _navigationService.Navigate<HomeViewModel>();
            //_navigationService.Navigate<TasksListViewModel>();
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

        public IMvxCommand LogOutUserCommand
        {
            get { return new MvxCommand(LogOutUser); }
        }

        private void LogOutUser()
        {
            _taskRepository.LogOutUser();
            _navigationService.Navigate<GoogleLoginViewModel>();
        }

       public IMvxCommand BackCommand
        {
            get { return new MvxCommand(Back); }
        }

        private void Back()
        {
            //_navigationService.Navigate<TasksListViewModel>();
            _navigationService.Navigate<HomeViewModel>();
        }

        public IMvxCommand TakePictureCommand
        {
            get { return new MvxCommand(DoTakePicture); }
        }

        private void DoTakePicture()
        {
            Action<byte[]> action = new Action<byte[]>(GetPhotoFromDroid); 
            if (Photo != null)
            {
                Photo = null;
                UpdateIsDetachEnabled();
                RaisePropertyChanged(() => Photo);
            }
            _photoService.TakePictureFromCamera(action);

            UpdateIsDetachEnabled();
            RaisePropertyChanged(() => Photo);
        }

        public IMvxCommand ChoosePictureCommand
        {
            get { return new MvxCommand(DoChoosePicture); }
        }
 

        private void DoChoosePicture()
        {
            Action<byte[]> action = new Action<byte[]>(GetPhotoFromDroid);
            if (Photo != null)
            {
                Photo = null;
                UpdateIsDetachEnabled();
                RaisePropertyChanged(() => Photo);
            }
            //_photoService.ChoosePictureFromGallary(action);    

            _pictureChooserTask.ChoosePictureFromLibrary(400, 95, pictureStream => {
                var memoryStream = new MemoryStream();
                pictureStream.CopyTo(memoryStream);
                Photo = memoryStream.ToArray();
                
            }, () => { });
            UpdateIsDetachEnabled();
            RaisePropertyChanged(() => Photo);
        }

        public override void ViewAppearing()
        {

            RaisePropertyChanged(() => Photo);
            base.ViewAppearing();
        }

        public bool CheckPermissionForCamera()
        {
            return _photoService.CheckPermission();
        }
      
        private void OnPicture(Stream stream)
        {
            var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            Photo = memoryStream.ToArray();
        }

        public void GetPhotoFromDroid(byte[] photos)
        {
            Photo= photos;
        }

        private byte[] _photo;

        public byte[] Photo
        {
            get { return _photo; }
            set { _photo = value; RaisePropertyChanged(() => Photo); UpdateIsDetachEnabled(); }
        } 
        public IMvxCommand DettachPhoto
        {
            get { return new MvxCommand(DettachPhotos); }
        }

        public void DettachPhotos()
        {
            Photo = null;
        }
    }
}
