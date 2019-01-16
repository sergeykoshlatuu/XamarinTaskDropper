using MvvmCross.ViewModels;
using TaskDropper.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using MvvmCross.Navigation;
using TaskDropper.Core.Interface;

namespace TaskDropper.Core.ViewModels
{
    public class AboutViewModel : MvxViewModel
    {
        //private ITaskRepository _taskRepository;
        private readonly IMvxNavigationService _navigationService;

        public override async Task Initialize()
        {
            await base.Initialize();

        }

        public AboutViewModel(IMvxNavigationService navigationService/*, ITaskRepository taskRepository*/)
        {
            _navigationService = navigationService;
            //_taskRepository = taskRepository;
            Name = "Sergey Koshlatuu";
            Email = "koshsy6363@gmail.com";
        }

        //public override void ViewAppearing()
        //{
        //    List<GoogleProfile> _templeteTasksList = _taskRepository.ListGoogleUsers();
        //    GoogleProfile profile = new GoogleProfile();

        //    profile = _templeteTasksList[_templeteTasksList.Count];

        //    Kind = profile.Kind;
        //    Etag = profile.Etag;
        //    Occupation = profile.Occupation;
        //    Gender = profile.Gender;
        //    ObjectType = profile.ObjectType;
        //    Id = profile.Id;
        //    DisplayName = profile.DisplayName;
        //    Name = profile.Name;
        //    Tagline = profile.Tagline;
        //    Url = profile.Url;
        //    Image = profile.Image;
        //    Organization = profile.Organizations;
        //    Placeslived = profile.PlacesLived;
        //    IsPlusUser = profile.IsPlusUser;
        //    CircledByCount = profile.CircledByCount;
        //    Verified = profile.Verified;
        //    Cover = profile.Cover;
        //}

        #region variables

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                RaisePropertyChanged(() => Email);
            }
        }

        private string _occupation;
        public string Occupation
        {
            get => _occupation;
            set
            {
                _occupation = value;
                RaisePropertyChanged(() => Occupation);
            }
        }

        private string _gender;
        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                RaisePropertyChanged(() => Gender
);
            }
        }

        private string _objectType;
        public string ObjectType
        {
            get => _objectType;
            set
            {
                _objectType = value;
                RaisePropertyChanged(() => ObjectType);
            }
        }

        private string _id;
        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged(() => Id);
            }
        }

        private string _displayName;
        public string DisplayName
        {
            get => _displayName;
            set
            {
                _displayName = value;
                RaisePropertyChanged(() => DisplayName);
            }
        }

        //private Name _name;
        //public Name Name
        //{
        //    get => _name;
        //    set
        //    {
        //        _name = value;
        //        RaisePropertyChanged(() => Name);
        //    }
        //}

        private string _tagline;
        public string Tagline
        {
            get => _tagline;
            set
            {
                _tagline = value;
                RaisePropertyChanged(() => Tagline);
            }
        }

        private string _url;
        public string Url
        {
            get => _url;
            set
            {
                _url= value;
                RaisePropertyChanged(() => Url);
            }
        }

        //private Image _image;
        //public Image Image
        //{
        //    get => _image;
        //    set
        //    {
        //        _image = value;
        //        RaisePropertyChanged(() => Image);
        //    }
        //}

        //private Organization[] _organization;
        //public Organization[] Organization
        //{
        //    get => _organization;
        //    set
        //    {
        //        _organization = value;
        //        RaisePropertyChanged(() => Organization);
        //    }
        //}

        //private Placeslived[]_placeslived;
        //public Placeslived[] Placeslived 
        //{
        //    get => _placeslived;
        //    set
        //    {
        //        _placeslived = value;
        //        RaisePropertyChanged(() => Placeslived);
        //    }
        //}

        private bool _isPlusUser;
        public bool IsPlusUser
        {
            get => _isPlusUser;
            set
            {
                _isPlusUser = value;
                RaisePropertyChanged(() => IsPlusUser);
            }
        }

        private int _circledByCount;
        public int CircledByCount
        {
            get => _circledByCount;
            set
            {
                _circledByCount = value;
                RaisePropertyChanged(() => CircledByCount);
            }
        }

        private bool _verified;
        public bool Verified
        {
            get => _verified;
            set
            {
                _verified = value;
                RaisePropertyChanged(() => Verified);
            }
        }

        //private Cover _cover;
        //public Cover Cover
        //{
        //    get => _cover;
        //    set
        //    {
        //        _cover = value;
        //        RaisePropertyChanged(() => Cover);
        //    }
        //}

        #endregion
    }
}

