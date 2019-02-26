using MvvmCross.ViewModels;
using TaskDropper.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using MvvmCross.Navigation;
using TaskDropper.Core.Interface;
using Xamarin.Essentials;

namespace TaskDropper.Core.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
      
        

        public override async Task Initialize()
        {
            await base.Initialize();
        }

        public AboutViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
            Name = "Sergey Koshlatuu";
            Email = "koshsy6363@gmail.com";
        }
        public override void ViewAppearing()
        {
           
        }

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
    }
}

