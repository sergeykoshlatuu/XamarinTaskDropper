using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDropper.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskDropper.Forms.Pages
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Root, WrapInNavigationPage = false, NoHistory =true)]
    public partial class MainPage : MvxMasterDetailPage<MainViewModel>
    {
       

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {

            if (!ViewModel.IsUserLogin())
            {
                ViewModel.ShowGoogleLoginViewModelCommand.Execute(null);
            }
            else
            {
                ViewModel.ShowHomeViewModelCommand.Execute(null);
            }

            base.OnAppearing();
        }
    }
}