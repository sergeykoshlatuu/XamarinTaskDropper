using MvvmCross.Commands;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskDropper.Core.ViewModels
{
    public class FormsLoginVieModel : BaseViewModel
    {
        #region constructors
        public FormsLoginVieModel(IMvxNavigationService navigationService) : base(navigationService)
        {

            ShowGoogleLogin = new MvxAsyncCommand(async () => await _navigationService.Navigate<GoogleLoginViewModel>());
        }
        #endregion

        #region commands
        public IMvxCommand ShowGoogleLogin { get; set; }
        #endregion

        #region overrides
        public override async Task Initialize()
        {
            await base.Initialize();
        }
        #endregion 
    }
}
