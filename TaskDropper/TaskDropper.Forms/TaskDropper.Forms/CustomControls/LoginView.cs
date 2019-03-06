using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TaskDropper.Forms.CustomControls
{
    public class LoginView : View
    {
        public static readonly BindableProperty HomeViewProperty =
               BindableProperty.Create("HomeView", // название обычного свойства
                   typeof(IMvxAsyncCommand), // возвращаемый тип 
                   typeof(LoginView), // тип,  котором объявляется свойство
                   "0"// значение по умолчанию
               );
        public IMvxAsyncCommand HomeView
        {
            set
            {
                SetValue(HomeViewProperty, value);
            }
            get
            {
                return (IMvxAsyncCommand)GetValue(HomeViewProperty);
            }

        }
    }
}
