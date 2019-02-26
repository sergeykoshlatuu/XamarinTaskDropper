using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using TaskDropper.Core.Interface;
using Xamarin.Essentials;

namespace TaskDropper.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        public IMvxNavigationService _navigationService;
        protected BaseViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

        }

        public bool CheckInternetConnection()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
    public abstract class BaseViewModel<TParameter> : MvxViewModel<TParameter>
        where TParameter : class

    {
        public IMvxNavigationService _navigationService;
        protected BaseViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

        }

        public bool CheckInternetConnection()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
