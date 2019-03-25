using MvvmCross.ViewModels;
using TaskDropper.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using MvvmCross.Navigation;
using TaskDropper.Core.Interface;
using Xamarin.Essentials;
using MvvmCross.Commands;

namespace TaskDropper.Core.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {

        #region constructors
        public AboutViewModel(IMvxNavigationService navigationService,IDatabaseUserService databaseUserService) : base(navigationService)
        {
            Name = "Sport:";
            Email = "Footbal";

            _databaseUserService = databaseUserService;
            ShowTaskChangedView = new MvxAsyncCommand(async () => await _navigationService.Navigate<TaskChangedViewModel>());
        }
        #endregion

        #region variables and properties
        IDatabaseUserService _databaseUserService;

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

        #endregion

        #region overrides
        public override async Task Initialize()
        {
            await base.Initialize();
        }

        public override void ViewAppearing()
        {

        }

        #endregion

        #region Commands
        public IMvxCommand LogOutUserCommand
        {
            get { return new MvxCommand(LogOutUser); }
        }

        public IMvxCommand ShowTaskChangedView { get; set; }

        public IMvxCommand LogOutUserFormsCommand
        {
            get { return new MvxCommand(LogOutFormsUser); }
        }
        #endregion

        #region Methods
        private void LogOutFormsUser()
        {
            _databaseUserService.LogOutUser();
            _navigationService.Navigate<FormsLoginVieModel>();
        }

        private void LogOutUser()
        {
            _databaseUserService.LogOutUser();
            _navigationService.Navigate<GoogleLoginViewModel>();
        }

        #endregion
    }
}

