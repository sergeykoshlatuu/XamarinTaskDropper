using MvvmCross.Commands;
using MvvmCross.Forms.Views;
using System;
using System.Diagnostics;
using TaskDropper.Core.ViewModels;
using Xamarin.Forms;

namespace TaskDropper.Forms.Pages
{

    public partial class LoginPage : MvxContentPage<GoogleLoginViewModel>
    {
        public LoginPage()
        {
            try {
                
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            Subscribe();
        }
        // установка подписки на сообщения
        private  void Subscribe()
        {
            MessagingCenter.Subscribe<Page>(
                this, // кто подписывается на сообщения
                "Complete",   // название сообщения
                (sender) => {
                    ViewModel.ShowHomeViewModelCommand.Execute();                   
                });    // вызываемое действие

            MessagingCenter.Subscribe<Page>(
               this, // кто подписывается на сообщения
               "Failed",   // название сообщения
               (sender) => {
                   var action = DisplayActionSheet("Autentification failed", "Cancel", null);
               });    // вызываемое действие

            MessagingCenter.Subscribe<Page>(
               this, // кто подписывается на сообщения
               "Canceled",   // название сообщения
               (sender) => {
                   var action = DisplayActionSheet("You didn't completed the authentication process", "Cancel", null);
               });    // вызываемое действие

        }

        protected override void OnAppearing()
        {
            SetValue(HomeViewProperty, ViewModel.ShowHomeViewModelCommand);
            base.OnAppearing();
        }

        public static readonly BindableProperty HomeViewProperty =
               BindableProperty.Create("HomeView", // название обычного свойства
                   typeof(MvxAsyncCommand), // возвращаемый тип 
                   typeof(LoginPage), // тип,  котором объявляется свойство
                   null// значение по умолчанию
               );
        public MvxAsyncCommand HomeView
        {
            set
            {
                SetValue(HomeViewProperty, ViewModel.ShowHomeViewModelCommand);
            }
            get
            {
                return (MvxAsyncCommand)GetValue(HomeViewProperty);
            }

        }

    }
}
