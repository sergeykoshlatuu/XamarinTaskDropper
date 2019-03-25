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
        #region constructors
        protected BaseViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            IsNoInternetVisible = false;
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                IsNoInternetVisible = true;
            }
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }
        #endregion

        #region variables and properties
        public IMvxNavigationService _navigationService;

        private bool _isNoInternetVisible;

        public bool IsNoInternetVisible
        {
            get
            {

                return _isNoInternetVisible;

            }
            set
            {
                _isNoInternetVisible = value;
                RaisePropertyChanged(() => IsNoInternetVisible);
            }
        }
        #endregion

        #region methods
        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess == NetworkAccess.Internet)
            {
                IsNoInternetVisible = true;
                return;
            }
            IsNoInternetVisible = false;
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
        #endregion
    }
    public abstract class BaseViewModel<TParameter> : MvxViewModel<TParameter>
        where TParameter : class

    {
       
        #region constructors
        protected BaseViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            IsNoInternetVisible = false;
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                IsNoInternetVisible = true;
            }
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }
        #endregion

        #region variables and properties
        public IMvxNavigationService _navigationService;
        private bool _isNoInternetVisible;

        public bool IsNoInternetVisible
        {
            get
            {

                return _isNoInternetVisible;

            }
            set
            {
                _isNoInternetVisible = value;
                RaisePropertyChanged(() => IsNoInternetVisible);
            }
        }
        #endregion

        #region methods
        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess == NetworkAccess.Internet)
            {
                IsNoInternetVisible = true;
                return;
            }
            IsNoInternetVisible = false;
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
        #endregion

    }
}
